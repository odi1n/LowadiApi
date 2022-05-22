using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lowadi.Models.Shop
{
    public class Sell : PurchaseInfo
    {
        [JsonProperty("message")] public List<string> MessageList { get; set; }
    }
}