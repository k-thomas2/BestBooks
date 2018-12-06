using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Models
{
    public class ReviewCreate
    {
        public int BookId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage ="Please enter at least 1 character.")]
        public string Title { get; set; }
        [MaxLength(400, ErrorMessage ="There are too many characters in this field.")]
        public string Summary { get; set; }
        public string ReviewContent { get; set; }

        public override string ToString() => Title;
      
    }
}
