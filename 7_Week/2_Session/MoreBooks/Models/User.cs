using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Books.Models
{
    public class User
    {
        [Key]
        public int user_id {get;set;}
        [Display(Name="First Name")]
        [Required]
        [MinLength(2, ErrorMessage="Name Fields must be 2 or more characters")]
        public string first_name {get;set;}
        [Display(Name="Last Name")]
        [Required]
        [MinLength(2, ErrorMessage="Name Fields must be 2 or more characters")]
        public string last_name {get;set;}
        [Display(Name="Username")]
        [MinLength(2, ErrorMessage="Name Fields must be 2 or more characters")]
        [Required]
        public string username {get;set;}
        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string password {get;set;}
        
        public DateTime created_at {get;set;}
        public List<Review> WrittenReviews {get;set;}
        public User()
        {
            created_at = DateTime.Now;
        }
    }
    public class RegUser : User
    {
        [Display(Name="Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string confirm {get;set;}
    }
    public class LogUser
    {
        [Display(Name="Username")]
        [Required]
        public string LogUsername {get;set;}
        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}
    }
    
}