using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloEF.Models;
using Microsoft.AspNetCore.Identity;

namespace HelloEF.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        public HomeController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("")] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("users/{id}")]
        public IActionResult Show(int id)
        {
            return View(_dbContext.users.SingleOrDefault(user => user.user_id == id));
        }
        
        [HttpPost("create")]
        public IActionResult Create(RegUser user)
        {
            if(_dbContext.users.SingleOrDefault(userToCheck => userToCheck.email == user.email) != null)
                ModelState.AddModelError("email", "Email already exists.");

            if(ModelState.IsValid)
            {
                PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
                User toCreate = new User()
                {
                    first_name = user.first_name,
                    last_name = user.last_name,
                    email = user.email,
                    password = hasher.HashPassword(user, user.password)
                };
                // create a user EF style!
                _dbContext.users.Add(toCreate);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
    }
}