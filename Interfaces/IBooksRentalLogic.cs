using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBooksRentalLogic
    {
        Task BorrowBook(Guid clientId, Guid bookId);
        Task ReturnBook(Guid clientId, Guid bookId);
    }
}