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
                    BookGenre = model.BookGenre,
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

        public BookDetail GetBookById(int bookId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == bookId && e.OwnerId == _userId);
                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        AuthorName = entity.AuthorName,
                        Description = entity.Description,
                        BookGenre = entity.BookGenre,
                        AvgBookRating = entity.AvgBookRating

                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == model.BookId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.AuthorName = model.AuthorName;
                entity.Description = model.Description;
                entity.BookGenre = model.BookGenre;
                entity.AvgBookRating = model.AvgBookRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == bookId && e.OwnerId == _userId);
                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
