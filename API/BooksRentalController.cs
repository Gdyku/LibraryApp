using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using System.Threading.Tasks;
using Library.DtoModels;

namespace Library.API
{
    [Route("api/[controller]")]
    public class BooksRentalController : ApiController
    {
        private readonly IBooksRentalLogic _booksRentalLogic;
        public BooksRentalController(IBooksRentalLogic booksRentalLogic)
        {
            _booksRentalLogic = booksRentalLogic;
        }

        [HttpPut]
        public async Task BorrowBook(Guid clientId, Guid bookId)
        {
            await _booksRentalLogic.BorrowBook(clientId, bookId);
        }

        [HttpPut]
        public async Task ReturnBook(Guid clientId, Guid bookId)
        {
            await _booksRentalLogic.ReturnBook(clientId, bookId);
        }

    }
}
