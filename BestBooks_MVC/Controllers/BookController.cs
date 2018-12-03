using BestBooks.Models;
using BestBooks_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestBooks_MVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var model = new BookListItem[0];
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}