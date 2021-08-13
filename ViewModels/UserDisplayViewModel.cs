using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculatorApp.ViewModels
{
    public class UserDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid UserId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "Death Sum Insured")]
        public decimal DeathSumInsured { get; set; }

        [Display(Name = "Monthly Premium")]
        public decimal MonthlyPremium{ get; set; }
    }
}
