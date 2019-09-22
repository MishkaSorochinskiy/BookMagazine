﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class UserController : Controller
    {
        private readonly BookShopDb _context;

        public UserController(BookShopDb context)
        {
            this._context = context;
        }

        public IActionResult GetProfileStatistic()
        {
            return View();
        }
    }
}