using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class LoginRequest
    {
        [Required]
        [MinLength(length: 1, ErrorMessage = "username required.")]
        public string UserName { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "password required.")]
        public string Password { get; set; }

        [Required]
        [MinLength(length: 1, ErrorMessage = "installation id required.")]
        public string InstallationId { get; set; }

        [Required(ErrorMessage = "placeform id is required")]
        public Guid PlatformId { get; set; }

    }
}