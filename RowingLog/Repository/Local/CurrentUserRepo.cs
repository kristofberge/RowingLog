using LiteDB;
using RowingLog.Models;
using RowingLog.Services;

namespace RowingLog.Repository.Local
{
    public class CurrentUserRepo : AbstractLocalRepo<User>
    {
        public CurrentUserRepo(IPlatformService platformService) : base(platformService)
        {
            
        }
    }
}
