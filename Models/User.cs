using System;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.Models
{
    public class User
    {

        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        [Required]
        public int RatingId { get; set; }

        [Required]
        public float DeathSumInsured { get; set; }

        [Required]
        public float MonthlyPremium { get; set; }
    }
}
