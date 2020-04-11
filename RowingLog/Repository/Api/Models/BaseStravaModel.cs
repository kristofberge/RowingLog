using Newtonsoft.Json;

namespace RowingLog.Repository.Api.Models
{
    public class BaseStravaModel
    {
        [JsonProperty(PropertyName = "resource_state")]
        public int ResourceState { get; set; }
    }
}
