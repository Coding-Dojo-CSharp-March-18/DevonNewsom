using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Books.Models
{
    public class Book
    {
        [Key]
        public int book_id {get;set;}
        [Display(Name="Title")] 
        [Required]
        public string title {get;set;}
        [Display(Name="Date Published")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_published {get;set;}
        public Author Author {get;set;}
    }
}
