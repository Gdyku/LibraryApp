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
    public class BooksController : ApiController
    {
        private readonly IBookLogic _bookLogic;
        public BooksController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        [HttpGet('getbooks')]
        public async Task<List<BookDTO>> GetBooksAsync()
        {
            return await _bookLogic.GetBooks();
        }

        [HttpGet('getbooks/{id}')]
        public async Task<BookDTO> GetBookAsync(Guid id)
        {
            return await _bookLogic.GetBook(id);
        }

        [HttpPost('createbook')]
        public async Task CreatBookAsync([FromBody] BookDTO book)
        {
            await _bookLogic.CreateBook(book);
        }

        [HttpPut('editbook')]
        public async Task EditBookAsync([FromBody] BookDTO book)
        {
            await _bookLogic.EditBook(book);
        }

        [HttpDelete('deletebook/{id}')]
        public async Task DeleteBookAsync(Guid id)
        {
            await _bookLogic.DeleteBook(id);
        }
    }
}
