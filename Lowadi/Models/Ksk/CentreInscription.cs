using Newtonsoft.Json;

namespace Lowadi.Models.Ksk
{
    public partial class CentreInscription
    {
        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("hasContent")] public bool HasContent { get; set; }
    }
}