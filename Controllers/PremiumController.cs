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
        private readonly UserEditViewModal userModel;
        
        public PremiumController(AppDbContext dbContext, IUserRepository userRepository)
        {
            this._dbContext = dbContext;
            this._userRepository = userRepository;
            this.userModel = new UserEditViewModal();
          
        }

        public IActionResult Index()
        {          
            var userList = _userRepository.GetUsers();
            return View(userList);
        }

        [HttpGet]
        public ActionResult Index(Guid userId)
        {
            var userList = _userRepository.GetUser(userId);
            return View(userList);
        }

        // GET: Premium/Create
        public ActionResult Create(Guid UserId)
        {
            var user = _userRepository.CreateUser();
            return View(user);           
        }
        

        // POST: Premium/Create        
        [HttpPost]
        public ActionResult Create(UserEditViewModal model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                   bool saved = _userRepository.SaveUser(model);
                   if (saved)
                   {
                        return RedirectToAction("Index", new { @userId = model.UserId });
                   }

                }
                return NotFound();                
                
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}