using Refit;

namespace RowingLog.Repository.Api.Models
{
    public abstract class BaseStravaAuthParams
    {
        [AliasAs("client_id")]
        public string ClientId { get; set; }

        [AliasAs("client_secret")]
        public string ClientSecret { get; set; }

        public virtual string GrantType { get; set; }
    }

    public class StravaAuthParams : BaseStravaAuthParams
    {
        [AliasAs("grant_type")]
        public override string GrantType => Common.Constants.GrantTypeAuthorizartionCode;

        [AliasAs("scope")]
        public string Scope { get; set; }

        [AliasAs("code")]
        public string Code { get; set; }
    }

    public class StravaRefreshParams : BaseStravaAuthParams
    {
        [AliasAs("grant_type")]
        public override string GrantType => Common.Constants.GrantTypeRefreshToken;

        [AliasAs("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
