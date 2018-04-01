using Microsoft.AspNetCore.Mvc;

namespace weekend_session
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetObjectAsJson("friends", Friend.MakeFriends());
            return View();
        }
    }
}