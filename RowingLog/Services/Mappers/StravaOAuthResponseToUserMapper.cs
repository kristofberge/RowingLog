using RowingLog.Common.Enums;
using RowingLog.Models;
using RowingLog.Repository.Api.Models;

namespace RowingLog.Services.Mappers
{
    public class StravaOAuthResponseToStravaUserMapper : IMapper<OAuthResponse, StravaUser>
    {
        private readonly IMapperService mapper;

        public StravaOAuthResponseToStravaUserMapper(IMapperService mapper)
        {
            this.mapper = mapper;
        }

        public StravaUser Map(OAuthResponse from)
        {
            return new StravaUser
            {
                StravaId = from.Athlete.Id,
                Username = from.Athlete.Username,
                FirstName = from.Athlete.FirstName,
                LastName = from.Athlete.LastName,
                Country = from.Athlete.Country,
                City = from.Athlete.City,
                Sex = mapper.Map<string, Sex>(from.Athlete.Sex),
                HasPremium = from.Athlete.Premium,
                HasSummit = from.Athlete.Summit,
                State = from.Athlete.State,
                AccessToken = from.AccessToken,
                RefreshToken = from.RefreshToken,
                Avatar = from.Athlete.Profile
            };
        }
    }
}
