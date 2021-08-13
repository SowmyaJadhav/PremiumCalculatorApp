using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorApp.ViewModels
{
    public class CommonUserViewModel
    {
        public UserEditViewModal UserEdit { get; set; }
        public List<UserDisplayViewModel> UserDisplay { get; set; }
    }
       
}
