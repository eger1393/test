using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// День регистрации
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// День последней активности
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Время жизни пользователя(кол-во дней с момента регистрации до момента последней активности)
        /// </summary>
        public UInt16 LifeSpanDays { get; set; }
    }
}