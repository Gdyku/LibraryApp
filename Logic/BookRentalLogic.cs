using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Models;
using System.Data.Entity;
using Library.DtoModels;

namespace Library.Logic
{
    public class BookRentalLogic : IBooksRentalLogic
    {
        private readonly DataContext _context;
        private BooksRental rentalTable = new BooksRental();
        public BookRentalLogic(DataContext context)
        {
            _context = context;
        }
        public async Task BorrowBook(Guid clientId, Guid bookId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ID == clientId);
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);

            if (book.IsBorrowed)
                throw new Exception("This book is borrowed. Try another one");
            else if (clientId != client.ID)
                throw new Exception("Couldn't find client");
            else if (bookId != book.ID)
                throw new Exception("Couldn't find book");

            book.IsBorrowed = true;
            client.BooksID.Add(bookId);
            rentalTable.BorrowDate.Add(DateTime.Now);
            
            await _context.SaveChangesAsync();
        }

        public async Task ReturnBook(Guid clientId, Guid bookId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ID == clientId);
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);
            
            if (clientId != client.ID)
                throw new Exception("Couldn't find client");
            else if (bookId != book.ID)
                throw new Exception("Couldn't find book");

            book.IsBorrowed = false;
            client.BooksID.Remove(bookId);
            rentalTable.ReturnDate.Add(DateTime.Now);

            await _context.SaveChangesAsync();

        }
    }
}
