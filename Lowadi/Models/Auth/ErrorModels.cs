using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lowadi.Models
{
    public partial class ErrorModels
    {
        [JsonProperty("errors")] public List<string> Errors { get; set; }

        [JsonProperty("errorsText")] public string ErrorsText { get; set; }

        [JsonProperty("message")] public object Message { get; set; }

        [JsonProperty("messageText")] public string MessageText { get; set; }

        [JsonProperty("redirection")] public Uri Redirection { get; set; }

        [JsonProperty("fieldsErrors")] public FieldsErrors FieldsErrors { get; set; }
    }
}