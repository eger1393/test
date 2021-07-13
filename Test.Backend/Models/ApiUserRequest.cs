using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
