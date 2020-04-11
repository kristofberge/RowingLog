using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RowingLog.Common.Enums;
using RowingLog.Models;
using RowingLog.Services;
using Xamarin.Forms;
using static RowingLog.Common.Constants;

namespace RowingLog.ViewModels
{
    public class StravaViewModel : MvxViewModel
    {
        private readonly IStravaService stravaService;
        private readonly ICurrentUserService userService;

        private ICommand webViewNavigatingCommand;
        private string webViewUrl;
        private bool isLoggedIn;
        private bool isBusy;
        private MvxObservableCollection<StravaActivityItemViewModel> activities;

        private int currentPage = 0;

        public StravaViewModel(
            IStravaService stravaService,
            ICurrentUserService userService)
        {
            this.stravaService = stravaService;
            this.userService = userService;

            WebViewNavigatingCommand = new MvxAsyncCommand<WebNavigatingEventArgs>(OnWebViewNavigating);
        }

        public override void ViewAppearing()
        {
            try
            {
                base.ViewAppearing();

                IsLoggedIn = this.userService.CurrentUser.StravaUser != null;

                if (IsLoggedIn)
                {
                    LoadActivities();
                }
                else
                {
                    var uri = new UriBuilder(StravaOAuthUri)
                    {
                        Query = new StringBuilder()
                            .Append($"client_id={StravaClientId}")
                            .Append("&response_type=code")
                            .Append($"&redirect_uri={StravaRedirectUri}")
                            .Append("&approval_prompt=auto")
                            .Append("&scope=read,activity:read")
                        .ToString()
                    };

                    WebViewUrl = uri.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public ICommand WebViewNavigatingCommand
        {
            get => this.webViewNavigatingCommand;
            set => SetProperty(ref this.webViewNavigatingCommand, value);
        }

        public string WebViewUrl
        {
            get => this.webViewUrl;
            set => SetProperty(ref this.webViewUrl, value);
        }

        public bool IsLoggedIn
        {
            get => this.isLoggedIn;
            set => SetProperty(ref this.isLoggedIn, value);
        }

        public bool IsBusy
        {
            get => this.isBusy;
            set => SetProperty(ref this.isBusy, value);
        }

        public MvxObservableCollection<StravaActivityItemViewModel> Activities
        {
            get => this.activities;
            set => SetProperty(ref this.activities, value);
        }

        private void LoadActivities()
        {
            IsBusy = true;
            this.stravaService.GetActivities(++currentPage).Subscribe(OnActivitiesReceived, OnError);
        }

        private void OnActivitiesReceived(IEnumerable<StravaActivity> newActivities)
        {
            IsBusy = true;
            Debug.WriteLine("Updating activities");
            if (newActivities.Any())
            {
                var viewModels = newActivities.Select(a => CreateActivityViewModel(a));
                if (currentPage == 1)
                {
                    Activities = new MvxObservableCollection<StravaActivityItemViewModel>(viewModels);
                }
                else
                {
                    Activities.AddRange(viewModels);
                }
            }
            IsBusy = false;
        }

        private void OnError(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            IsBusy = false;
        }

        private StravaActivityItemViewModel CreateActivityViewModel(StravaActivity activity)
        {
            var test = new StravaActivityItemViewModel
            {
                Name = activity.Name,
                AthleteName = $"{this.userService.CurrentUser.StravaUser.FirstName} {this.userService.CurrentUser.StravaUser.LastName}",
                AthleteAvatar = this.userService.CurrentUser.StravaUser.Avatar,
                Date = activity.StartTime.Date.ToLongDateString(), // TODO humanize date
                Distance = CalculateDistance(activity.Distance, activity.Type),
                DistanceUnit = GetDistanceUnit(activity.Type),
                Split = CalculateSplitForType(activity.AverageSpeed, activity.Type),
                SplitUnit = GetSplitUnit(activity.Type),
                Type = GetTypeString(activity.Type)
            };
            return test;
        }

        private string CalculateDistance(double distance, ActivityType type)
        {
            // assuming distance is in meters
            switch (type)
            {
                case ActivityType.IndoorRowing:
                case ActivityType.WaterRowing:
                    return distance.ToString("N0");
                default:
                    var kms = distance / 1000;
                    return kms.ToString("N2");
            }
        }

        private string GetDistanceUnit(ActivityType type)
        {
            switch (type)
            {
                case ActivityType.IndoorRowing:
                case ActivityType.WaterRowing:
                    return "m";
                default:
                    return "km";
            }
        }

        private string CalculateSplitForType(double averageSpeed, ActivityType type)
        {
            // assuming averageSpeed is in m/s
            switch (type)
            {
                case ActivityType.WaterRowing:
                case ActivityType.IndoorRowing:
                    var secPer500m = Math.Pow(averageSpeed, -1) * 500;
                    var timePer500m = TimeSpan.FromSeconds(secPer500m);
                    var formattedTimePer500m = $"{timePer500m.Minutes}:{timePer500m.Seconds}.{timePer500m.Milliseconds.ToString().Substring(0, 1)}";
                    return formattedTimePer500m;
                case ActivityType.Run:
                    var secPer1000m = Math.Pow(averageSpeed, -1) * 1000;
                    var timePer1000m = TimeSpan.FromSeconds(secPer1000m);
                    var formattedTimePer1000m = $"{timePer1000m.Minutes}:{timePer1000m.Seconds}";
                    return formattedTimePer1000m;
                default:
                    var kph = averageSpeed * 3600 / 1000;
                    return kph.ToString("N2");
            }
        }

        private string GetSplitUnit(ActivityType type)
        {
            switch (type)
            {
                case ActivityType.WaterRowing:
                case ActivityType.IndoorRowing:
                    return "/500m";
                case ActivityType.Run:
                    return "/km";
                default:
                    return "km/h";
            }
        }

        private string GetTypeString(ActivityType type)
        {
            return type switch
            {
                ActivityType.IndoorCycling => "Indoor ride",
                ActivityType.IndoorRowing => "Indoor row",
                ActivityType.RoadCycling => "Ride",
                ActivityType.SkiErg => "Ski erg",
                ActivityType.WaterRowing => "Row",
                _ => type.ToString(),
            };
        }

        private async Task OnWebViewNavigating(WebNavigatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Url))
            {
                return;
            }

            Debug.WriteLine($"Webview navigating to {e.Url}");
            var url = new Uri(e.Url);

            if (url.Host.Contains("rowinglog"))
            {
                await HandleUserAnsweredPermission(url);
            }
        }

        private async Task HandleUserAnsweredPermission(Uri url)
        {
            var code = HttpUtility.ParseQueryString(url.Query).Get("code");
            var error = HttpUtility.ParseQueryString(url.Query).Get("error");

            HandleError(error);
            await HandleCode(code);
        }

        private static void HandleError(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                Debug.WriteLine($"Error with Strava login: {error}");
            }
        }

        private async Task HandleCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                if (await this.stravaService.PerformOAuth(code))
                {
                    IsLoggedIn = true;
                    LoadActivities();
                }
            }
        }
    }
}
