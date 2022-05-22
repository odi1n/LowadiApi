using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class FieldsErrors
    {
        [JsonProperty("invalidUser")]
        public InvalidUser InvalidUser { get; set; }
    }
}
