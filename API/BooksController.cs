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

        [Route("getbooks")]
        [HttpGet]
        public async Task<List<BookDTO>> GetBooksAsync()
        {
            try
            {
                return await _bookLogic.GetBooks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getbook/{id}")]
        [HttpGet]
        public async Task<BookDTO> GetBookAsync(Guid id)
        {
            try
            {
                return await _bookLogic.GetBook(id);
            }
            catch (Exception)
            {
                throw;
            } 
        }

        [Route("createbook")]
        [HttpPost]
        public async Task CreatBookAsync([FromBody] BookDTO book)
        {
            try
            {
                await _bookLogic.CreateBook(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("editbook/{id}")]
        [HttpPut]
        public async Task EditBookAsync([FromBody] BookDTO book)
        {
            try
            {
                await _bookLogic.EditBook(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("deletebook/{id}")]
        [HttpDelete]
        public async Task DeleteBookAsync(Guid id)
        {
            try
            {
                await _bookLogic.DeleteBook(id);
            }
            catch (Exception)
            {
                throw;
            } 
        }
    }
}
