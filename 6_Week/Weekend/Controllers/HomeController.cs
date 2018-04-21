using System.Linq;
using DITest.Models;
using Microsoft.AspNetCore.Mvc;
namespace DITest.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        public HomeController(MyContext context, DogFactory factory)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_dbContext.people.ToList());
        }
    }
}
