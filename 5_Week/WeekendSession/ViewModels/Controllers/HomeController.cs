using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace ViewModels.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            User user = new User()
            {
                FirstName = "Devon",
                LastName = "Newsom",
                Email = "sup@sup.com"
            };
            IndexViewModel model = new IndexViewModel()
            {
                TheUser = user,
                Now = DateTime.Now,
                Words = new string[]
                {
                    "Here", "are", "some", "random", "words"

                }
            };
            return View(model);
        }
    }
}
