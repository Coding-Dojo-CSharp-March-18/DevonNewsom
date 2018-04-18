using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ModelsContinued.Models
{
    public class User
    {
        [Display(Name="First Name")]
        [Required]
        [MinLength(2, ErrorMessage="Name Fields must be 2 or more characters")]
        public string first_name {get;set;}
        [Display(Name="Last Name")]
        [Required]
        [MinLength(2, ErrorMessage="Name Fields must be 2 or more characters")]
        public string last_name {get;set;}
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [Display(Name="Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string confirm {get;set;}
        public DateTime created_at {get;set;}
        public User()
        {
            created_at = DateTime.Now;
        }
    }
    public class LogUser
    {
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string log_email {get;set;}
        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 or more characters")]
        [DataType(DataType.Password)]
        public string log_password {get;set;}
        public int secret_code {get;set;}
    }
    public class Message
    {
        public int message_id {get;set;}
        public int user_id {get;set;}
        public string content {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public User Author {get;set;}
    }
}