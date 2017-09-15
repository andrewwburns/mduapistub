using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(length: 1, ErrorMessage = "userName is required.")]
        [JsonProperty(PropertyName = "userName")]
        public string Username { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "password is required.")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "email is required.")]
        [JsonProperty(PropertyName = "email")]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "platform is required.")]
        [JsonProperty(PropertyName = "platformId")]
        public string PlatformId { get; set; }

        [JsonProperty(PropertyName = "details")]
        public UserDetails Details { get; set; }
        public class UserDetails
        {
            [JsonProperty(PropertyName = "FirstName")]
            public string FirstName { get; set; }

            [JsonProperty(PropertyName = "LastName")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "Country")]
            public string Country { get; set; }

            [JsonProperty(PropertyName = "Role")]
            public string Role { get; set; }
        }

        public RegisterRequest()
        {
            Details = new UserDetails();
        }
    }
}