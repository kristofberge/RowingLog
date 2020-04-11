using System.Collections.Generic;

namespace RowingLog.Repository.Local
{
    public interface ILocalRepo<T>
    {
        void Insert(T item);
        void InsertRange(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        void Upsert(T item);
        void Clear();
        IEnumerable<T> GetAll();
        T Get(string id);
        bool Exists(string id);
    }
}
