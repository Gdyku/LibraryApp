using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Guid> BooksID { get; set; }
        public BooksRental RentalHistory { get; set; }
    }
}