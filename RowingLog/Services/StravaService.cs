using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Refit;
using RowingLog.Models;
using RowingLog.Repository.Api;
using RowingLog.Repository.Api.Models;
using RowingLog.Repository.Local;
using static RowingLog.Common.Constants;
using static RowingLog.Repository.Api.ApiConstants;

namespace RowingLog.Services
{
    public class StravaService : IStravaService
    {
        private readonly Lazy<IStravaApi> stravaApi;
        private readonly ILocalRepo<StravaActivity> activitiesRepo;
        private readonly ICurrentUserService userService;
        private readonly IMapperService mapper;

        StravaUser StravaUser => this.userService.CurrentUser.StravaUser;

        public StravaService(
            IApiFactory apiFactory,
            ILocalRepo<StravaActivity> activitiesRepo,
            ICurrentUserService userService,
            IMapperService mapper)
        {
            this.stravaApi = apiFactory.Api<IStravaApi>();
            this.activitiesRepo = activitiesRepo;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<bool> PerformOAuth(string code)
        {
            try
            {
                var authParams = new StravaAuthParams
                {
                    ClientId = StravaClientId,
                    ClientSecret = StravaClientSecret,
                    Code = code,
                    GrantType = GrantTypeAuthorizartionCode,
                    Scope = "read"
                };
                var response = await this.stravaApi.Value.GetStravaToken(authParams);
                var user = this.mapper.Map<OAuthResponse, StravaUser>(response);
                this.userService.SetStravaUser(user);
                return true;
            }
            catch (ApiException apiEx)
            {
                Debug.WriteLine(apiEx.Message);
                return false;
            }
        }

        public IObservable<IEnumerable<StravaActivity>> GetActivities(int page = 1)
        {
            return Observable.Create<IEnumerable<StravaActivity>>(async (observer, token) =>
            {
                try
                {
                    if (!token.IsCancellationRequested)
                    {
                        if (page == 1) // We only cache the first page
                        {
                            PushCachedActivities(observer);
                        }

                        var apiActivities = await PerformAuthorizedApiCall(this.stravaApi.Value.GetActivities(GetToken(), page)).ConfigureAwait(false);
                        var activities = apiActivities.Select(a => this.mapper.Map<StravaApiActivity, StravaActivity>(a));

                        observer.OnNext(activities);

                        if (page == 1)
                        {
                            UpdateCachedActivities(activities);
                        }
                    }
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
            });
        }

        private void PushCachedActivities(IObserver<IEnumerable<StravaActivity>> observer)
        {
            var cachedActivities = this.activitiesRepo.GetAll();
            observer.OnNext(cachedActivities);
        }

        private void UpdateCachedActivities(IEnumerable<StravaActivity> activities)
        {
            this.activitiesRepo.Clear();
            this.activitiesRepo.InsertRange(activities);
        }

        private async Task<T> PerformAuthorizedApiCall<T>(Task<T> task)
        {
            try
            {
                return await task;
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Refreshtoken();
                    return await task;
                }

                // TODO return a custom exception for the VM to handle
                return default;
            }
        }

        private async Task Refreshtoken()
        {
            StravaUser stravaUser = this.userService.CurrentUser.StravaUser;

            var refreshParams = new StravaRefreshParams
            {
                ClientId = StravaClientId,
                ClientSecret = StravaClientSecret,
                RefreshToken = stravaUser.RefreshToken
            };

            var response = await this.stravaApi.Value.RefreshStravaToken(refreshParams);

            stravaUser.RefreshToken = response.RefreshToken;
            stravaUser.AccessToken = response.AccessToken;
            this.userService.SetStravaUser(stravaUser);
        }

        private string GetToken() => $"{Bearer} {StravaUser.AccessToken}";
    }
}
