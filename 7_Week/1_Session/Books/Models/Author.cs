using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Books.Models
{
    public class Author
    {
        [Key]
        public int author_id {get;set;}
        [Required]
        [Display(Name="Full Name")] 
        public string name {get;set;}
        [Display(Name="D.O.B.")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime dob {get;set;}
        public List<Book> Bibliogrpahy {get;set;}
    }
}
