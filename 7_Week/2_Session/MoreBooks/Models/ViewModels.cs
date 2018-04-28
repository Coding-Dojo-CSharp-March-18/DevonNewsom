using System.Collections.Generic;

namespace Books.Models
{
    public class BookIndex
    {
        public List<Book> NotReviewed {get;set;}
        public List<Book> Reviewed {get;set;}
    }
}