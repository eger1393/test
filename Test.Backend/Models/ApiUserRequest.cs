using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Backend.Models
{
    public class ApiUserRequest
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime LastActivityDate { get; set; }
    }
}
