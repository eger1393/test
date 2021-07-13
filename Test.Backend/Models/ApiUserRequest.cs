using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Backend.Models
{
    public class ApiUserRequest
    {
        /// <summary>
        /// Премя регистрации
        /// </summary>
        [Required]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Время последней активности
        /// </summary>
        [Required]
        public DateTime LastActivityDate { get; set; }
    }
}
