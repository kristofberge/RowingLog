using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using RowingLog.Models;
using RowingLog.Repository.Api;
using RowingLog.Repository.Local;
using RowingLog.Services;
using RowingLog.ViewModels;

namespace RowingLog
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Api")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Repo")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType(() => Mvx.IoCProvider);

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IStravaService, StravaService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMapperService, MapperService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICurrentUserService, CurrentUserService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IApiFactory, ApiFactory>();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ILocalRepo<User>, CurrentUserRepo>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ILocalRepo<StravaActivity>, StravaActivitiesRepo>();

            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}
