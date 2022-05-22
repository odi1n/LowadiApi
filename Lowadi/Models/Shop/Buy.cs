using Newtonsoft.Json;

namespace Lowadi.Models.Shop
{
    public class Buy : PurchaseInfo
    {
        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("achatPass")] public string AchatPass { get; set; }
        [JsonProperty("categorie")] public string Categorie { get; set; }
        [JsonProperty("stock")] public string Stock { get; set; }
    }
}