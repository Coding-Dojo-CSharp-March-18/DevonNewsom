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
        public List<Review> ReceivedReviews {get;set;}
    }
    public class Review
    {
        [Key]
        public int review_id {get;set;}
        public string title {get;set;}
        public string content {get;set;}
        [Range(1,5, ErrorMessage = "Rating must be 1-5")]
        public int rating {get;set;}
        public DateTime created_at {get;set;}
        public User Reviewer {get;set;}
        public Book ReviewedBook {get;set;}
        public int book_id {get;set;}
        public int user_id {get;set;}
        public Review()
        {
            created_at = DateTime.Now;
        }
    }
}
