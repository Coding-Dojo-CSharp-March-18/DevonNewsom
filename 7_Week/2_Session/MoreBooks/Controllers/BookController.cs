using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private int LoggedUserId
        {
            get { return _dbContext.users.SingleOrDefault(u => u.user_id == (int)HttpContext.Session.GetInt32("id")).user_id; }
        }
        private DateTime GenXStart
        {
            get { return new DateTime(1963, 1, 1); }
        }
        private DateTime GenXEnd
        {
            get { return new DateTime(1973, 12, 31); }
        }
        private BookContext _dbContext;
        public BookController(BookContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // Get familiar with .Any() and .All()
            List<Book> NotReviewedBooks = _dbContext.books
                .Include(b => b.Author)
                .Include(b => b.ReceivedReviews)
                    .ThenInclude(r => r.ReviewedBook)
                .Where(b => b.ReceivedReviews.All(r => r.user_id != LoggedUserId))
                .ToList();

            List<Book> ReviewedBooks = _dbContext.books
                .Include(b => b.Author)
                .Include(b => b.ReceivedReviews)
                    .ThenInclude(r => r.ReviewedBook)
                .Where(b => b.ReceivedReviews.Any(r => r.user_id == LoggedUserId))
                .ToList();
            BookIndex modelForIndex = new BookIndex()
            {
                Reviewed = ReviewedBooks,
                NotReviewed = NotReviewedBooks
            };
            return View(modelForIndex);
        }
    }
}
