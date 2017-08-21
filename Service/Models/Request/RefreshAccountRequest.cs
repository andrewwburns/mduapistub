using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class RefreshAccountRequest
    {
        [JsonProperty(PropertyName = "AuthToken")]
        public Guid AuthToken { get; set; }
        [JsonProperty(PropertyName = "AuthPlatformId")]
        public Guid AuthPlatformId { get; set; }
        [JsonProperty(PropertyName = "Funcationname")]
        public string FunctionName { get; set; }
    }
}