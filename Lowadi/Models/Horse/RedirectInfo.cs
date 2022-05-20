using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class RedirectInfo
    {
        [JsonProperty("redirection")] public string Redirection { get; set; }

        [JsonProperty("externalRedirection")] public long ExternalRedirection { get; set; }
    }
}