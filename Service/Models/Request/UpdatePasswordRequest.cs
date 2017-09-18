using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class UpdatePasswordRequest
    {
        [JsonProperty(PropertyName = "SessionGuid")]
        public Guid SessionGuid { get; set; }
        [JsonProperty(PropertyName = "PlatformId")]
        public Guid PlatformId { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "Password is required.")]
        [JsonProperty(PropertyName = "Password")]
        public string FirstName { get; set; }
    }
}