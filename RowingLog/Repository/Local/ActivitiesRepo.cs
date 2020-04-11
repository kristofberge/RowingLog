using System.Collections.Generic;
using RowingLog.Models;
using RowingLog.Services;

namespace RowingLog.Repository.Local
{
    public class StravaActivitiesRepo : AbstractLocalRepo<StravaActivity>
    {
        public StravaActivitiesRepo(IPlatformService platformService) : base(platformService)
        {

        }
    }
}
