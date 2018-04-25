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
    [Route("authors")]
    // localhost:5000/authors
    public class AuthorController : Controller
    {
        private BookContext _dbContext;
        public AuthorController(BookContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Author> AllAuthors = _dbContext.authors.ToList();
            return View(AllAuthors);
        }
        // localhost:5000/authors/{some author id}
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            Author toShow = _dbContext.authors.Include(a => a.Bibliogrpahy)
                .SingleOrDefault(a => a.author_id == id);

            return View(toShow);
        }
    }
}
