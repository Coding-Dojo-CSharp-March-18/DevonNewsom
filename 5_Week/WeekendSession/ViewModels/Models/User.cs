using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class User
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Email {get;set;}
    }
    public class IndexViewModel
    {
        public User TheUser {get;set;}
        public DateTime Now {get;set;}
        public string[] Words {get;set;}
    }
}