using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestBooks.Data.Book;

namespace BestBooks.Models
{
   public class BookDetail
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public Genre BookGenre { get; set; }
        public decimal AvgBookRating { get; set; }

        public override string ToString() => $"[{BookId}] {Title}, {AuthorName}, {Description}, {BookGenre}, {AvgBookRating}";
       
    }
}
