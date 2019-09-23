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
                Year = newbook.Year };

            await this._context.Books.AddAsync(book);

            await this._context.SaveChangesAsync();

            return View();
        }
    }
}