using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Library.DtoModels;
using Library.Models;
using System.Data.Entity;
using Library.Logic;
using AutoMapper;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController()
        {
            _context = new DataContext();
        }

        public async Task<ActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        public ActionResult Details(Guid id)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == id);

            if (book == null)
                return HttpNotFound();

            return View("BookForm" );
        }

        public ActionResult Delete(Guid id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}