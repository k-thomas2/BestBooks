﻿using BestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestBooks_MVC.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var model = new ReviewListItem[0];
            return View(model);
        }
    }
}