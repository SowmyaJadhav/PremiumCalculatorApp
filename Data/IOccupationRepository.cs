using Microsoft.AspNetCore.Mvc.Rendering;
using PremiumCalculatorApp.Models;
using System.Collections.Generic;

namespace PremiumCalculatorApp.Data
{
    public interface IOccupationRepository
    {       
        List<Occupation> GetAllOccupations();
    }
}
