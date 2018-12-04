using BestBooks.Models;
using BestBooks.Services;
using BestBooks_MVC.Models;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            var model = service.GetBooks();

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateBookService();

            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your book was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Book could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(id);

            return View(model);
        }




        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }


    }
}