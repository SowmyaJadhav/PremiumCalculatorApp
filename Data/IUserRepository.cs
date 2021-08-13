using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;

namespace PremiumCalculatorApp.Data
{
    public interface IUserRepository
    {
       
        List<UserDisplayViewModel> GetUser(Guid userId);
         UserEditViewModal LoadOccupationList();
        Guid SaveUser(UserEditViewModal userEdit);
       
    }
}
