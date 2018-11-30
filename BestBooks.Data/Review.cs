using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Data
{
    class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        public int Rating { get; set; }
        public Guid OwnerId { get; set; }
    }
}
