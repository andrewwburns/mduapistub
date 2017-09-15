using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class RefreshAccountRequest
    {
        [JsonProperty(PropertyName = "SessionGuid")]
        public Guid SessionGuid { get; set; }
        [JsonProperty(PropertyName = "PlatformId")]
        public Guid PlatformId { get; set; }
    }
}