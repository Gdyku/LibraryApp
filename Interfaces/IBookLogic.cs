using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DtoModels;

namespace Library.Interfaces
{
    public interface IBookLogic
    {
        Task<List<BookDTO>> GetBooks();
        Task<BookDTO> GetBook(Guid id);
        Task CreateBook(BookDTO book);
        Task EditBook(BookDTO updatedBook);
        Task DeleteBook(Guid id);
    }
}
