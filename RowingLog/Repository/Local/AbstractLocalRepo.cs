using System.Collections.Generic;
using System.IO;
using LiteDB;
using RowingLog.Models;
using RowingLog.Services;

namespace RowingLog.Repository.Local
{
    public abstract class AbstractLocalRepo<T> : ILocalRepo<T> where T : BaseModel
    {
        private readonly IPlatformService platformService;

        private LiteDatabase _database;

        protected LiteCollection<T> Collection { get; private set; }

        protected AbstractLocalRepo(IPlatformService platformService)
        {
            this.platformService = platformService;

            InitializeDatabase();

            var mapper = BsonMapper.Global;

            mapper.Entity<T>().Id(item => item.Id);
        }

        public virtual void Insert(T item)
        {
            Collection.Insert(item);
        }

        public void InsertRange(IEnumerable<T> items)
        {
            Collection.InsertBulk(items);
        }

        public virtual void Update(T item)
        {
            Collection.Update(item);
        }

        public virtual void Delete(T item)
        {
            Collection.Delete(i => i.Id.Equals(item.Id));
        }

        public void Upsert(T item)
        {
            Collection.Upsert(item);
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.FindAll();
        }

        public T Get(string id)
        {
            return Collection.FindOne(i => i.Id == id);
        }

        public bool Exists(string id)
        {
            return Collection.Exists(i => i.Id == id);
        }

        public void Clear()
        {
            _database.DropCollection(Collection.Name);
        }

        private void InitializeDatabase()
        {
            string dbPath = this.platformService.DatabaseLocation;
            System.Diagnostics.Debug.WriteLine($"Database path: {dbPath}");

            if (!string.IsNullOrEmpty(dbPath) && !File.Exists(dbPath))
            {
                File.Create(dbPath).Dispose();
            }

            _database = new LiteDatabase(dbPath);
            Collection = _database.GetCollection<T>();
        }
    }
}
