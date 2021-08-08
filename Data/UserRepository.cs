using Microsoft.EntityFrameworkCore;
using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculatorApp.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IOccupationRepository _occupationRepository;
        public UserRepository(AppDbContext context, IOccupationRepository occupationRepository)
        {
            this._context = context;
            this._occupationRepository = occupationRepository;
        }

        public List<UserDisplayViewModel> GetUsers()
        {

            List<User> userInfo = new List<User>();
            userInfo = _context.Users.AsNoTracking()
                .Include(x => x.Occupation)
                .ToList();

            if (userInfo != null)
            {
                var usersDisplay = new List<UserDisplayViewModel>();
                foreach (var x in userInfo)
                {
                    var userDisplay = new UserDisplayViewModel()
                    {
                        UserId = x.UserId,
                        Name = x.Name,
                        Age = x.Age,
                        DateOfBirth = x.DateOfBirth,
                        Occupation = x.Occupation.OccupationName
                    };
                    usersDisplay.Add(userDisplay);
                }
                return usersDisplay;
            }
            return null;
        }


        public List<UserDisplayViewModel> GetUser(Guid userId)
        {

            var userInfo = new List<User>();
                      
            userInfo = _context.Users.Where(x => x.UserId == userId).ToList();            

            if (userInfo != null)
            {
                var usersDisplay = new List<UserDisplayViewModel>();
                foreach (var x in userInfo)
                {

                    var userDisplay = new UserDisplayViewModel()
                    {
                        UserId = x.UserId,
                        Name = x.Name,
                        Age = x.Age,
                        DateOfBirth = x.DateOfBirth, 
                        DeathSumInsured = x.DeathSumInsured,
                        MonthlyPremium = x.MonthlyPremium
                    };
                    var occupation = new Occupation();
                    userDisplay.Occupation = _context.Occupations.Where(x => x.OccupationId == x.OccupationId).FirstOrDefault().OccupationName;
                    usersDisplay.Add(userDisplay);
                }
                    return usersDisplay;
            }
            return null;
        }

        public UserEditViewModal CreateUser()
        {
          // var oRepo = new OccupationRepository(_context);

            var userInfo = new UserEditViewModal()
            {
                UserId = Guid.NewGuid().ToString(),
                OccupationList = _occupationRepository.GetOccupations(),

            };
            return userInfo;
        }

       
        public bool SaveUser(UserEditViewModal userEdit)
        {
            if (userEdit != null)
            {
                if (Guid.TryParse(userEdit.UserId, out Guid newGuid))
                {            
                   
                    var user = new User()
                    {
                        UserId = newGuid,
                        Name = userEdit.Name,
                        Age = userEdit.Age,
                        DateOfBirth = userEdit.DateOfBirth,
                        DeathSumInsured = userEdit.DeathSumInsured,
                        OccupationId = userEdit.SelectedOccupationId,
                       
                    };
                    user.Occupation = _context.Occupations.Find(userEdit.SelectedOccupationId);
                    var factor = new RatingFactor();
                    factor.Factor = _context.RatingFactors.Find(user.Occupation.RatingId).Factor; 
                    var premium = (user.DeathSumInsured * factor.Factor * user.Age) / 1000 * 12;
                    user.MonthlyPremium = Convert.ToInt32(premium);

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            
            return false;
        }
    }
}
