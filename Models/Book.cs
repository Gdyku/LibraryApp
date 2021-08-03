using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsBorrowed { get; set; }
        public BooksRental RentalHistory { get; set; }

        //postawić widoki
        //ajax
        //autoryzacja
    }
}