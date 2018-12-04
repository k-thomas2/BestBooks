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
                        .Where(e => e.OwnderId == _userId)
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
    }
}
