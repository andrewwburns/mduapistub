using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class UpdateNonMemberRequest
    {
        [JsonProperty(PropertyName = "SessionGuid")]
        public Guid SessionGuid { get; set; }
        [JsonProperty(PropertyName = "PlatformId")]
        public Guid PlatformId { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "FirstName is required.")]
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "LastName is required.")]
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "Country is required.")]
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "Role is required.")]
        [JsonProperty(PropertyName = "Role")]
        public string Role { get; set; }
    }
}