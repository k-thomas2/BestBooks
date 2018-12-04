using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Data
{
   public class Review
    {
        public int ReviewId { get; set; }
        public Guid OwnderId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ReviewContent { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public decimal AvgBookRating { get; set; }
    }
}
