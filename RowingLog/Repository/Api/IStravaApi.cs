using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RowingLog.Repository.Api.Models;
using static RowingLog.Repository.Api.ApiConstants;

namespace RowingLog.Repository.Api
{
    public interface IStravaApi
    {
        [Post("/oauth/token")]
        Task<OAuthResponse> GetStravaToken([Query] StravaAuthParams authParams);

        [Post("/oauth/token")]
        Task<OAuthResponse> RefreshStravaToken([Query] StravaRefreshParams refreshParams);

        [Get("/athlete/activities")]
        Task<IEnumerable<StravaApiActivity>> GetActivities([Header(Authorization)] string bearerToken, [Query] int page = 1);
    }
}
