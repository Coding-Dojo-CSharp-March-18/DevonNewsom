using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsContinued.Models;

namespace ModelsContinued.Controllers
{
    public class HomeController : Controller
    {
        // int? user_id;
        private UserFactory _userFactory;
        public HomeController()
        {
            _userFactory = new UserFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            

            return View();
        }
        [HttpGet("users")]
        public IActionResult Users()
        {
            return View(_userFactory.AllUsers());
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            // TODO: prevent duplicate email from being used
            
            if(ModelState.IsValid)
            {
                //TODO: Hash user's password for DB storage
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                string hashedPW = hasher.HashPassword(user, user.password);
                user.password = hashedPW;
                _userFactory.CreateUser(user);

                return RedirectToAction("LoginView");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser user)
        {
            // TODO: login the user
            if(ModelState.IsValid)
            {
                // check that email is in the database
                if(_userFactory.UserExists(user.log_email))
                {
                    ModelState.AddModelError("log_email", "Invalid Email/Password");
                }
                else
                {
                    Dictionary<string, object> actualUser = userFromDB.First();
                    // check hashed password for user with email
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, (string)actualUser["password"], user.log_password);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("log_email", "Invalid Email/Password");
                    }
                }
                // with query to db for user with email
            

            }
            if(ModelState.IsValid)
                return RedirectToAction("Index");
            return View("Index");
            // log user in!

        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            // TODO: prevent unauthorized users from viewing this page!
            int? userOrNull = HttpContext.Session.GetInt32("id");
            if(userOrNull == null)
                return RedirectToAction("Index");

            return View();
        }
    }
}
