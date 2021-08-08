using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<SelectListItem> GetOccupations()
        {
           
                List<SelectListItem> occupations = _dbcontext.Occupations.AsNoTracking()
                    .OrderBy(n => n.OccupationName)
                        .Select(n =>
                        new SelectListItem 
                        {
                            Value = n.OccupationId.ToString(),
                            Text = n.OccupationName
                        }).ToList();
                var occupationtip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select occupation ---"
                };
                occupations.Insert(0, occupationtip);
                return new SelectList(occupations, "Value", "Text");
            
        }
    }
}
