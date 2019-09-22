﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookShopDb _context;

        public BookController(BookShopDb context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetListOfBooks()
        {
            return View();
        }
    }
}