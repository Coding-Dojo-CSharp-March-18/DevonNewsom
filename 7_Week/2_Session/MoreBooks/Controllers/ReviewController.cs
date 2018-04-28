using Books.Models;
using Microsoft.AspNetCore.Mvc;
namespace Books.Controllers
{
    [Route("reviews")]
    public class ReviewController : Controller
    {
        [HttpPost("create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                // add review
                return RedirectToAction("Index", "Book");
            }
            return View("Show", "Book");
        }
    }
}