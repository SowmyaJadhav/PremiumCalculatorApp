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
        /// Retrives all the Occupations from database and assigns it to userEdit model occupationlist 
        /// </summary>
        /// <returns></returns>
        public List<Occupation> LoadOccupationList()
        {
            var userInfo = new UserEditViewModal()
            {
                OccupationList = _occupationRepository.GetAllOccupations(),
            };
            return userInfo.OccupationList;
        }

        /// <summary>
        /// Premium is calculated for the new User and saved to the Database
        /// </summary>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        public bool SaveUser(UserEditViewModal userEdit)
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
                userEdit.MonthlyPremium = user.MonthlyPremium;

                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
