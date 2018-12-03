using BestBooks.Data;
using BestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestBooks.Data.ApplicationUser;

namespace BestBooks.Services
{
   public class BookService
    {
        private readonly Guid _userId;

        public BookService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    AuthorName = model.Author,
                    Description = model.Description,
                    AvgBookRating = model.Rating,
                    BookGenre = model.Genre,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new BookListItem
                            {
                                BookId = e.BookId,
                                Title = e.Title,
                                Author = e.AuthorName,

                            }
                        );
                return query.ToArray();
            }
        }
    }
}
