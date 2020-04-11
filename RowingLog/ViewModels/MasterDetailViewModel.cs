using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace RowingLog.ViewModels
{
    public class MasterDetailViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;

        public MasterDetailViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override async void ViewAppearing()
        {
            try
            {
                base.ViewAppearing();

                await this.navigationService.Navigate<MenuViewModel>();
                await this.navigationService.Navigate<Concept2ViewModel>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
