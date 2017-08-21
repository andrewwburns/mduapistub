using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Response
{
    public class BaseResult
    {
        [JsonProperty(PropertyName = "SessionGuid")]
        public Guid SessionGuid { get; set; }
        [JsonProperty(PropertyName = "ValidationCode")]
        public string ValidationCode { get; set; }
        [JsonProperty(PropertyName = "ValidationDescription")]
        public string ValidationDescription { get; set; }
        [JsonProperty(PropertyName = "Successful")]
        public bool Successful { get; set; }
    }
}