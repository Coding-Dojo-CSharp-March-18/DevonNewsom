using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloDI.Models;

namespace HelloDI.Controllers
{
    public class HomeController : Controller
    {
        private Person _thePerson;
        // accept services here:
        public HomeController(Person myPerson)
        {
            _thePerson = myPerson;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Person = _thePerson;
            return View();
        }
    }
}
