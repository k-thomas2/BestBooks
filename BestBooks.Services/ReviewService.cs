using BestBooks.Data;
using BestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static BestBooks.Data.ApplicationUser;

namespace BestBooks.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        //GET:Create
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Summary = model.Summary,
                    ReviewContent = model.ReviewContent,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Review.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get Reviews
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Review
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new ReviewListItem
                                    {
                                        ReviewId = e.ReviewId,
                                        Title = e.Title,
                                        CreatedUtc = e.CreatedUtc
                                    }
                                     );
                return query.ToArray();
            }
        }

        //GET Reviews by Id
        public ReviewDetail GetReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Review
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        Title = entity.Title,
                        Summary = entity.Summary,
                        ReviewContent = entity.ReviewContent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        //Update Reviews
        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Review
                        .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Summary = model.Summary;
                entity.ReviewContent = model.ReviewContent;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }

        //Delete Review
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Review
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);
                ctx.Review.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
