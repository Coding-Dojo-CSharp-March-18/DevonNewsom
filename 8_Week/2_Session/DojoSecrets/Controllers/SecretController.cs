using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Secrets.Models;

namespace Secrets.Controllers
{
    [Route("secret")]
    public class SecretController : Controller
    {
        private MyContext _context;
        public SecretController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {

            return View(new DashboardViewModel()
            {
                AllSecrets = _context.secrets.Include(s => s.Likes).ToList(),
                UserId = (int)HttpContext.Session.GetInt32("id")
            });
        }
        [HttpGet("like/{id}")]
        public IActionResult Like(int id)
        {
            // Add A Like to _context.likes
            Like newLike = new Like()
            {
                user_id = (int)HttpContext.Session.GetInt32("id"),
                secret_id = id
            };
            _context.likes.Add(newLike);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            // query for secret with id
            Secret toDelete = _context.secrets.SingleOrDefault(s => s.secret_id == id);
            if(toDelete == null)
                return RedirectToAction("Index");
            // if secretToDelete.user_id != active user.user_id
            if(toDelete.user_id != (int)HttpContext.Session.GetInt32("id"))
                return RedirectToAction("Index");

            // .Remove from _context.secrets
            _context.secrets.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");            
        }

    }

}
