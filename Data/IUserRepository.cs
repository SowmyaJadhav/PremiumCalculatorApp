using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;

namespace PremiumCalculatorApp.Data
{
    public interface IUserRepository
    {
        List<UserDisplayViewModel> GetUsers();
        List<UserDisplayViewModel> GetUser(Guid userId);
        UserEditViewModal CreateUser();
        bool SaveUser(UserEditViewModal userEdit);
       
    }
}
