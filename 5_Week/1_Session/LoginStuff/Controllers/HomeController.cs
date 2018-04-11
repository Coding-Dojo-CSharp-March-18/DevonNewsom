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
        public HomeController()
        {

        }
        [HttpGet("")]
        public IActionResult Index()
        {
        
            return View();
        }

        [HttpGet("signup")]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpGet("test")]
        public IActionResult Redirecting()
        {
            return RedirectToRoute("");
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
                
                string createUser = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', NOW(), NOW());";
                DbConnector.Execute(createUser);
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
                string checkUserWithEmail = $"SELECT * FROM users WHERE email = '{user.email}'";
            List<Dictionary<string, object>> userFromDB = DbConnector.Query(checkUserWithEmail);
                if(userFromDB.Count < 1)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                }
                else
                {
                    Dictionary<string, object> actualUser = userFromDB.First();
                    // check hashed password for user with email
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, (string)actualUser["password"], user.password);
                    if(result == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("email", "Invalid Email/Password");
                    }
                }
                // with query to db for user with email
            

            }
            if(ModelState.IsValid)
                return RedirectToAction("LoginView");
            return View("LoginView", user);
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
