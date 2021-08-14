using Microsoft.AspNetCore.Mvc;
using PremiumCalculatorApp.Data;
using PremiumCalculatorApp.ViewModels;
using System;

namespace PremiumCalculatorApp.Controllers
{
    public class PremiumController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserRepository _userRepository;
       

      /// <summary>
      /// Constructor to initialize Database, UserRepository and OccupationRepository Objects
      /// </summary>
      /// <param name="dbContext"></param>
      /// <param name="userRepository"></param>
        public PremiumController(AppDbContext dbContext, IUserRepository userRepository)
        {
            this._dbContext = dbContext;
            this._userRepository = userRepository;         
              
        }
      

        /// <summary>
        /// First Action Method triggered to load the UserEditView
        /// </summary>
        /// <returns>UserEditView Model</returns>
        // GET: Premium/Create
        [HttpGet]
        public ActionResult Create()
        {
            UserEditViewModal model = new UserEditViewModal();         
            model.OccupationList = _userRepository.LoadOccupationList();
            ViewBag.OccupationList = model.OccupationList;          
            return View(model);           
        }
        
        /// <summary>
        /// Action is triggred when Occupation dropdownlist is selected to Calculate Monthly Premium
        /// </summary>
        /// <param name="model">UserEditView & UserDisplayView</param>
        /// <returns>Calculated Monthly Premium and User entered data</returns>
        // POST: Premium/Create        
        [HttpPost("Create")]
        public ActionResult Create(UserEditViewModal model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saved = _userRepository.SaveUser(model);
                    if (saved)
                    {
                        ModelState["MonthlyPremium"].RawValue = model.MonthlyPremium;                     
                        
                        model.OccupationList = _userRepository.LoadOccupationList();
                        ViewBag.OccupationList = model.OccupationList;                     

                        return View(model);
                    }
                }
                model.OccupationList = _userRepository.LoadOccupationList();
                ViewBag.OccupationList = model.OccupationList;
                return View(model);               
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}