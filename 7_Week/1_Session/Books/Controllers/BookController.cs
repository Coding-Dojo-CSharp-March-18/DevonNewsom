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
    public class BookController : Controller
    {
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
            List<Book> BooksByGenXers = _dbContext.books
                .Include(b => b.Author)
                .Where(b => b.Author.dob < GenXEnd && b.Author.dob > GenXStart)
                .ToList();
            return View(BooksByGenXers);
        }
    }
}
