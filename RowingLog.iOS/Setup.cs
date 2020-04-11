using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using RowingLog.iOS.Services;
using RowingLog.Services;
using UIKit;

namespace RowingLog.iOS
{
    public class Setup : MvxFormsIosSetup<App, FormsApp>
    {

        protected override IMvxApplication CreateApp() => new App();

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPlatformService, PlatformService>();
        }
    }
}
