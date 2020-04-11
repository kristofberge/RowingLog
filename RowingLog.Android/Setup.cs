using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace RowingLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        protected override IMvxApplication CreateApp() => new App();

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();


        }
    }
}
