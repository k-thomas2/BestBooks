using BestBooks.Models;
using BestBooks.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReviews();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();

           if(service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your review has been created.";
            return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created.");

            return View(model);

        }

        public ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }
        //Review Edit 
        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    Title = detail.Title,
                    Summary = detail.Summary,
                    ReviewContent = detail.ReviewContent
                };
            return View(model);
        }
        //POST: Review Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReviewService();
            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your review was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your review could not be updated.");
            return View(model);
        }

    }
}