using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowadi.Models
{
    public partial class FieldsErrors
    {
        [JsonProperty("invalidUser")]
        public InvalidUser InvalidUser { get; set; }
    }
}
