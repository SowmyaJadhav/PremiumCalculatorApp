using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.Models
{
    public class RatingFactor
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public decimal Factor { get; set; }        
    }
}
