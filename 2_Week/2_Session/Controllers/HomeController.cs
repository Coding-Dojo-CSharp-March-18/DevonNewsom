using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloAsp.Controllers
{
    public class HomeController : Controller
    {
        // Action
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet("redirecting")]
        public RedirectToActionResult RedirectThis()
        {
            System.Console.WriteLine("REDIRECTING\n");
            return RedirectToAction("Index");
        }
        [HttpGet("whatever/{type}")]
        public IActionResult Whatever(string type)
        {
            if(type != "view")
            {
                System.Console.WriteLine("REDIRECTING\n");
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}