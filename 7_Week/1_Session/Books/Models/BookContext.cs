using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Books.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options) {}
        public DbSet<Book> books {get;set;}
        public DbSet<Author> authors {get;set;}
    }
}
