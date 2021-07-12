using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Backend.Models
{
    public class ApiUserRequest
    {
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime LastActivityDate { get; set; }
    }
}
