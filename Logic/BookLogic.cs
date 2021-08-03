using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Interfaces;
using AutoMapper;
using Library.Models;
using System.Data.Entity;
using Library.DtoModels;

namespace Library.Logic
{
    public class BookLogic : IBookLogic
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public BookLogic(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBook(BookDTO book)
        {
            var mappedBook = _mapper.Map<BookDTO, Book>(book);
            mappedBook.IsBorrowed = false;

            _context.Books.Add(mappedBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);

            if (id != book.ID)
                throw new Exception("Book cannot be found");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task EditBook(BookDTO updatedBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == updatedBook.ID);

            if (updatedBook.ID != book.ID)
                throw new Exception("Book cannot be found");

            book.Title = updatedBook.Title ?? book.Title;
            book.Author = updatedBook.Author ?? book.Author ;
            book.Category = updatedBook.Category ?? book.Category;
            book.ReleaseDate = updatedBook.ReleaseDate;
            book.IsBorrowed = updatedBook.IsBorrowed;

            await _context.SaveChangesAsync();
        }

        public async Task<BookDTO> GetBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);

            if (id != book.ID)
                throw new Exception("Wrong id");

            var mappedBook = _mapper.Map<Book, BookDTO>(book);

            return mappedBook;
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            var mappedBooks = _mapper.Map<List<Book>, List<BookDTO>>(books);

            return mappedBooks;
        }
    }
}
