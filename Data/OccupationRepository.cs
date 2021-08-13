using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumCalculatorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculatorApp.Data
{
    public class OccupationRepository: IOccupationRepository
    {
        private readonly AppDbContext _dbcontext;
        public OccupationRepository(AppDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
       
        public List<Occupation> GetAllOccupations()
        {
            List<Occupation> occupations = new List<Occupation>();

            occupations = (from list in _dbcontext.Occupations
                           select list).ToList();
            occupations.Insert(0, new Occupation { OccupationId = 0 , OccupationName = "--- select occupation ---" });
            return occupations;
        }
    }
}
