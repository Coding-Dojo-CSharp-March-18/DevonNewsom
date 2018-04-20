using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloEF.Models
{
   public class MyContext : DbContext
   {
       public MyContext(DbContextOptions options) : base(options) {}
       // Provide DbSet<ModelClasses>
       public DbSet<User> users {get;set;}

   }
}