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
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage ="There are too many characters in this field.")]
        public string Summary { get; set; }
        [Key]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        public int Rating { get; set; }
        public Guid OwnerId { get; set; }
    }
}
