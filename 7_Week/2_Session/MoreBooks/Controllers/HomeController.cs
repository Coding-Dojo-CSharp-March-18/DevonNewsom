using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Books.Models;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private BookContext _dbContext;
        public HomeController(BookContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Register(RegUser user)
        {
            if(_dbContext.users.SingleOrDefault(us => us.username == user.username) != null)
                ModelState.AddModelError("username", "Username is TAKEN!");

            if(ModelState.IsValid)
            {
                PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();

                User newGuy = new User()
                {
                    first_name = user.first_name,
                    last_name = user.last_name,
                    username = user.username,
                    password = hasher.HashPassword(user, user.password)
                };


                _dbContext.users.Add(newGuy);
                _dbContext.SaveChanges();
                HttpContext.Session.SetInt32("id", newGuy.user_id);
                return RedirectToAction("Index", "Book");
            }
            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser user)
        {
            User testUser = _dbContext.users.SingleOrDefault(us => us.username == user.LogUsername);
            if(testUser == null)
                ModelState.AddModelError("LogUsername", "Invalid alias/password");
            
            else
            {
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                if(hasher.VerifyHashedPassword(user, testUser.password, user.LogPassword) 
                    == PasswordVerificationResult.Failed)
                    ModelState.AddModelError("LogUsername", "Invalid alias/password");
            }
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("id", testUser.user_id);
                return RedirectToAction("Index", "Book");
            }
            return View("Index");

        }

        
    }
}
