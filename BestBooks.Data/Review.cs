using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Data
{
   public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public Guid OwnderId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string ReviewContent { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public decimal AvgBookRating { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
