using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RowingLog.Models;
using RowingLog.Repository.Api.Models;

namespace RowingLog.Services
{
    public interface IStravaService
    {
        Task<bool> PerformOAuth(string code);
        IObservable<IEnumerable<StravaActivity>> GetActivities(int page = 1);
    }
}
