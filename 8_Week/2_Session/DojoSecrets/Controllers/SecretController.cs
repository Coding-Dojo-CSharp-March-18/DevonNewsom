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
        public static int NumSecretsToShow = 3;
        public User LoggedIn
        {
            get { return _context.users.SingleOrDefault(u => u.user_id == (int)HttpContext.Session.GetInt32("id")); }
        }
        private MyContext _context;
        public SecretController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if(LoggedIn == null)
                return RedirectToAction("Index", "Home");

            DashboardModel viewModel = new DashboardModel()
            {
                RecentSecrets = _context.secrets
                    .Include(s => s.Likes)
                    .OrderByDescending(s => s.created_at)
                    .Take(NumSecretsToShow)
                    .ToList(),
                LoggedInUser = LoggedIn,
                NewSecret = null
            };
            ViewBag.Recent = viewModel.RecentSecrets;
            return View(viewModel);
        }
        [HttpPost("create")]
        public IActionResult Create(DashboardModel model)
        {
            Secret newSecret = model.NewSecret;
            if(ModelState.IsValid)
            {
                _context.secrets.Add(newSecret);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            DashboardModel viewModel = new DashboardModel()
            {
                RecentSecrets = _context.secrets.OrderByDescending(s => s.created_at).Take(NumSecretsToShow).ToList(),
                LoggedInUser = LoggedIn,
                NewSecret = newSecret
            };
            return View("Index", viewModel);
        }
        [HttpGet("secret/delete/{secretId}")]
        public IActionResult Delete(int secretId)
        {
            // delete secret!
            Secret someSecret = _context.secrets.SingleOrDefault(s => s.secret_id == secretId && s.user_id == LoggedIn.user_id);
            if(someSecret != null)
            {
                _context.secrets.Remove(someSecret);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet("secret/like/{secretId}")]
        public IActionResult Like(int secretId)
        {
            // like secret!
            Secret someSecret = _context.secrets.SingleOrDefault(s => s.secret_id == secretId);
            if(someSecret != null)
            {
                Like newLike = new Like()
                {
                    secret_id = secretId,
                    user_id = LoggedIn.user_id
                };
                _context.likes.Add(newLike);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
