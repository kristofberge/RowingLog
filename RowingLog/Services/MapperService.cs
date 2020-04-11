using MvvmCross.IoC;
using RowingLog.Common.Enums;
using RowingLog.Models;
using RowingLog.Repository.Api.Models;
using RowingLog.Services.Mappers;

namespace RowingLog.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMvxIoCProvider ioCProvider;

        public MapperService(IMvxIoCProvider ioCProvider)
        {
            this.ioCProvider = ioCProvider;

            RegisterMappers();
        }

        public TTo Map<TFrom, TTo>(TFrom from)
        {
            return this.ioCProvider.Resolve<IMapper<TFrom, TTo>>().Map(from);
        }

        private void RegisterMappers()
        {
            this.ioCProvider.LazyConstructAndRegisterSingleton<IMapper<OAuthResponse, StravaUser>, StravaOAuthResponseToStravaUserMapper>();
            this.ioCProvider.LazyConstructAndRegisterSingleton<IMapper<string, Sex>, SexStringToEnumMapper>();
            this.ioCProvider.LazyConstructAndRegisterSingleton<IMapper<StravaActivityType, ActivityType>, StravaActivityTypeMapper>();
            this.ioCProvider.LazyConstructAndRegisterSingleton<IMapper<StravaApiActivity, StravaActivity>, StravaActivityMapper>();
        }
    }
}
