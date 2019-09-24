using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application;
using BookShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly BookShopDb _context;

        public AdminController(BookShopDb context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var bookToDelete = this._context.Books.Find(id);

            this._context.Books.Remove(bookToDelete);

            await this._context.SaveChangesAsync();

            return RedirectToAction("GetListOfBooks", "Book");
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View("AddBook");
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto newbook)
        {
            Book book = new Book() { Name = newbook.Name,
                Author = newbook.Author,
                Janre = newbook.Janre,
                Year = newbook.Year ,Price=newbook.Price};

            await this._context.Books.AddAsync(book);

            await this._context.SaveChangesAsync();

            return RedirectToAction("GetListOfBooks", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Book book= await this._context.Books.FindAsync(id);
            BookEdit edit = new BookEdit()
            {
                Id = id,
                Name = book.Name,
                Author = book.Author,
                Janre = book.Janre,
                Price = book.Price,
                Year = book.Year
            };

            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEdit bookedit)
        {
            Book book = await this._context.Books.FindAsync(bookedit.Id);

            book.Name = bookedit.Name;

            book.Janre = bookedit.Janre;

            book.Author = bookedit.Author;

            book.Price = bookedit.Price;

            await this._context.SaveChangesAsync();

            return RedirectToAction("GetListOfBooks", "Book");
        }
    }
}