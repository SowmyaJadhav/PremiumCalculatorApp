using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PremiumCalculatorApp.Data
{
    public interface IOccupationRepository
    {
        IEnumerable<SelectListItem> GetOccupations();
    }
}
