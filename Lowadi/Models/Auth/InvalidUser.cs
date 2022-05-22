using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class InvalidUser
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("position")]
        public List<string> Position { get; set; }

        [JsonProperty("highlight")]
        public string Highlight { get; set; }

        [JsonProperty("values")]
        public List<object> Values { get; set; }
    }
}
