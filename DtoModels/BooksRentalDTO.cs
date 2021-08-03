using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DtoModels
{
    public class BooksRentalDTO
    {
        public Guid ID { get; set; }
        public Guid BookID { get; set; }
        public Guid ClientID { get; set; }
        public List<DateTime> BorrowDate { get; set; }
        public List<DateTime> ReturnDate { get; set; }
    }
}