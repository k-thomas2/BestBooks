using BestBooks.Data;
using BestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
