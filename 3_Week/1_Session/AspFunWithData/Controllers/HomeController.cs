using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspFunWithData.Controllers
{
    public class HomeController : Controller
    {
        public string LatestName;
        [HttpGet("")]
        public IActionResult Index()
        {

            string[] names = new string[]
            {
            "Scott",
                "Daniel",
                "Nicki",
                "Devon"
            };
            ViewBag.Names = names;
            ViewBag.Color = "Pink";
            ViewBag.LatestName = HttpContext.Session.GetString("name");
            return View();
        }
        [HttpPost("addname")]
        public IActionResult AddName(string first_name, string last_name)
        {
            HttpContext.Session.SetString("name", $"{first_name} {last_name}");

            return RedirectToAction("Index");
        }
    }
}