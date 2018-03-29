using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace SessionLec.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            if(HttpContext.Session.GetObjectAsJson<List<string>>("names") == null)
                HttpContext.Session.SetObjectAsJson("names", new List<string>());

            // does session count exist yet?
            // if not, set it to 0
            if(HttpContext.Session.GetInt32("count") == null)
                HttpContext.Session.SetInt32("count", 0);

            // set ViewBag so that we can render session data
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            ViewBag.Names = HttpContext.Session.GetObjectAsJson<List<string>>("names");
            
            return View();
        }

        [HttpGet("counter")]
        public IActionResult Count()
        {
            // grab whats in session
            int currCount = (int)HttpContext.Session.GetInt32("count");
            // increment variable
            currCount++;
            
            // store new count in session
            HttpContext.Session.SetInt32("count", currCount);
            Console.WriteLine("REDIRECTING");
            return RedirectToAction("Index");
        }
        [HttpGet("reset")]
        public IActionResult ResetSessionCount()
        {
            // HttpContext.Session.Clear();
            HttpContext.Session.Remove("count");
            Console.WriteLine("REDIRECTING");
            return RedirectToAction("Index");
        }
        [HttpPost("name")]
        public IActionResult Name(string name)
        {
            // get List<string> from session
            List<string> currNames = HttpContext.Session.GetObjectAsJson<List<string>>("names");

            // reset counter for new user
            HttpContext.Session.SetInt32("count", 0);

            // add new name to List<string>
            currNames.Add(name);

            // store updated List<string> in session
            HttpContext.Session.SetObjectAsJson("names", currNames);

            Console.WriteLine($"SUBMITTED: {name}");
            Console.WriteLine("REDIRECTING");
            return RedirectToAction("Index");
        }
    }
}