using DITest.Models;
using Microsoft.EntityFrameworkCore;

namespace DITest
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Person> people {get;set;}
    }
}