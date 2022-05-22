using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lowadi.Models.Shop
{
    public partial class PurchaseInfo
    {
        [JsonProperty("errorsText")] public string ErrorsText { get; set; }

        [JsonProperty("messageText")] public string MessageText { get; set; }

        [JsonProperty("message")] public List<string> Message { get; set; }

        [JsonProperty("retour")] public string Retour { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("nombre")] public long Nombre { get; set; }

        [JsonProperty("montant")] public long Montant { get; set; }

        [JsonProperty("updatedCurrency")] public long UpdatedCurrency { get; set; }
    }
}