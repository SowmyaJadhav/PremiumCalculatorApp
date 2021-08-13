using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PremiumCalculatorApp.Models;
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
        [Display(Name = "Age")]       
        [Range(1, 150, ErrorMessage = "The {0} field is invalid, select Date of Birth")]
        public int Age { get; set; }

        [Required]        
        [Display(Name = " Date Of Birth")] 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public int SelectedOccupationId { get; set; }
        
        public List<Occupation> OccupationList { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.1", "9999.99", ErrorMessage = "The {0} field is required")]
        [Display(Name = "Death Sum Insured")]
        public decimal DeathSumInsured { get; set; }

        [Display(Name = "Monthly Premium")]
        public decimal MonthlyPremium { get; set; }
    }
}
