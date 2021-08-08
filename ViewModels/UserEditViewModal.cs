using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.ViewModels
{
    public class UserEditViewModal
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [RangeAttribute(1,100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = " Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Occupation")]
        public int SelectedOccupationId { get; set; }
        public IEnumerable<SelectListItem> OccupationList { get; set; }
        [Required]
        [Display(Name = "Death Sum Insured")]
        public float DeathSumInsured { get; set; }

        [Display(Name = "Monthly Premium")]
        public double MonthlyPremium { get; set; }
    }
}
