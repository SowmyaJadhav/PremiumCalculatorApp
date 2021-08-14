using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PremiumCalculatorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.ViewModels
{
    public class UserEditViewModal
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Required ( AllowEmptyStrings = false, ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]        
        [Display(Name = "Age")]       
        [Range(1, 150, ErrorMessage = "Please select Date of Birth  ")]
        public int Age { get; set; }

        [Required]        
        [Display(Name = " Date Of Birth")] 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

       
        [Display(Name = "Occupation")]
        [Required]
        [Range(1, 7, ErrorMessage = "Please select Occupation ")]
        public int SelectedOccupationId { get; set; }
        
        public List<Occupation> OccupationList { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DefaultValue("0.00")]
        [Range(typeof(decimal), "0.1", "9999.99", ErrorMessage = "The {0} field is required")]
        [Display(Name = "Death Sum Insured Amount")]
        public decimal DeathSumInsured { get; set; }

        [Display(Name = "Monthly Premium")]
        public decimal MonthlyPremium { get; set; }
    }
}
