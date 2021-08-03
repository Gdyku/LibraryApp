using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DtoModels
{
    public class ClientDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Guid> BooksID { get; set; }
        public BooksRentalDTO RentalHistory { get; set; }
    }
}