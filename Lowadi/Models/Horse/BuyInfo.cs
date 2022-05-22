using Lowadi.Models.Shop;
using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class BuyInfo
    {
        [JsonProperty("externalRedirection")] public long ExternalRedirection { get; set; }

        [JsonProperty("redirection")] public string Redirection { get; set; }
    }
}