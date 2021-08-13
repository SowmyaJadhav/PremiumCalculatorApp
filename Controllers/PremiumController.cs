using Microsoft.AspNetCore.Mvc;
using PremiumCalculatorApp.Data;
using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            CommonUserViewModel model = new CommonUserViewModel();            
            model.UserDisplay = new List<UserDisplayViewModel>(); 
            model.UserEdit = _userRepository.LoadOccupationList();
            ViewBag.OccupationList = model.UserEdit.OccupationList;          
            return View(model);           
        }
        
        /// <summary>
        /// Action is triggred when Occupation dropdownlist is selected to Calculate Monthly Premium
        /// </summary>
        /// <param name="model">UserEditView & UserDisplayView</param>
        /// <returns>Calculated Monthly Premium and User entered data</returns>
        // POST: Premium/Create        
        [HttpPost("Create")]
        public ActionResult Create(CommonUserViewModel model)
        {
            try
            {
                
                if (ModelState.IsValid)
                {                   
                   var savedUserId = _userRepository.SaveUser(model.UserEdit);
                   if (savedUserId != Guid.Empty)
                   {
                        CommonUserViewModel updatedModel = new CommonUserViewModel();
                        var userList = _userRepository.GetUser(savedUserId);
                        updatedModel.UserDisplay = userList.ToList();                        
                        updatedModel.UserEdit = model.UserEdit;
                        updatedModel.UserEdit = _userRepository.LoadOccupationList();
                        ViewBag.OccupationList = updatedModel.UserEdit.OccupationList;
                        return View(updatedModel);                        
                   }

                }
                model.UserEdit = _userRepository.LoadOccupationList();
                ViewBag.OccupationList = model.UserEdit.OccupationList;
                return View(model);               
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}