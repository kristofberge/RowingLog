using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RowingLog.Common.Enums;
using Xamarin.Forms;

namespace RowingLog.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;

        private MvxObservableCollection<MenuItem> menuItems;
        private ICommand showDetailsPageCommand;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.showDetailsPageCommand = new MvxAsyncCommand<AppPage>(ShowDetailsPage);
            MenuItems = new MvxObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Text = "Concept 2 Log",
                    Page = AppPage.Concept2,
                    Command =this.showDetailsPageCommand
                },
                new MenuItem
                {
                    Text = "Strava",
                    Page = AppPage.Strava,
                    Command =this.showDetailsPageCommand
                }
            };
        }

        public MvxObservableCollection<MenuItem> MenuItems
        {
            get => this.menuItems;
            set => SetProperty(ref this.menuItems, value);
        }

        private async Task ShowDetailsPage(AppPage page)
        {
            switch (page)
            {
                case AppPage.Concept2:
                    await this.navigationService.Navigate<Concept2ViewModel>();
                    break;
                case AppPage.Strava:
                    await this.navigationService.Navigate<StravaViewModel>();
                    break;
            }
            HideMenu();
        }

        private void HideMenu()
        {
            var mainPage = Application.Current.MainPage;
            if (mainPage is MasterDetailPage masterPage)
            {
                masterPage.IsPresented = false;
            }
            else if (mainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nesterMasterPage)
            {
                nesterMasterPage.IsPresented = false;
            }
        }
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
        public AppPage Page { get; set; }
    }
}
