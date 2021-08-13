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
       
        /// <summary>
        /// Returns the Calculated Premium stored in the Database based on User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

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
                    userDisplay.Occupation = _context.Occupations.Find(x.OccupationId).OccupationName;
                    usersDisplay.Add(userDisplay);
                }
                return usersDisplay;
            }
            return null;
        }

        /// <summary>
        /// Retrives all the Occupations from database and assigns it to userEdit model occupationlist 
        /// </summary>
        /// <returns></returns>
        public UserEditViewModal LoadOccupationList()
        {
            var userInfo = new UserEditViewModal()
            {
                OccupationList = _occupationRepository.GetAllOccupations(),
            };
            return userInfo;
        }

        /// <summary>
        /// Premium is calculated for the new User and saved to the Database
        /// </summary>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        public Guid SaveUser(UserEditViewModal userEdit)
        {
            if (userEdit != null)
            {                        
                   
                    var user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        Name = userEdit.Name,
                        Age = userEdit.Age,
                        DateOfBirth = userEdit.DateOfBirth,
                        DeathSumInsured = userEdit.DeathSumInsured,
                        OccupationId = userEdit.SelectedOccupationId,
                       
                    };
                    user.Occupation = _context.Occupations.Find(userEdit.SelectedOccupationId);
                    var factor = new RatingFactor();
                    factor.Factor = _context.RatingFactors.Find(user.Occupation.RatingId).Factor;
                    user.MonthlyPremium = (user.DeathSumInsured * factor.Factor * user.Age) / 1000 * 12;                   

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user.UserId;                
            }
            
            return Guid.Empty;
        }
    }
}
