using System.ComponentModel.DataAnnotations;

namespace Test.Services.Models
{
    public class LifeSpan
    {
        /// <summary>
        /// Время жизни пользователя в днях
        /// </summary>
        [Required]
        public ushort LifeSpanDays { get; set; }

        /// <summary>
        /// Кол-во таких пользователей
        /// </summary>
        [Required]
        public int Count { get; set; }
    }
}