using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.Models
{
    public class Occupation
    {
        [Key]
        [Required]
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }

        [Required]
        public int RatingId { get; set; }

    }
}
