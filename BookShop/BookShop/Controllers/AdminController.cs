using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public IActionResult AddBook()
        {
            return View("GetListOfBooks");
        }
    }
}