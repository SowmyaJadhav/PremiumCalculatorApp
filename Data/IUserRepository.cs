using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;

namespace PremiumCalculatorApp.Data
{
    public interface IUserRepository
    {     
        List<Occupation> LoadOccupationList();
        bool SaveUser(UserEditViewModal userEdit);       
    }
}
