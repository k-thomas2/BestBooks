using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestBooks.Data.Book;

namespace BestBooks.Models
{
     public class BookCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public Genre BookGenre { get; set; }
        public decimal Rating { get; set; }

        public override string ToString() => Title;
    }
}
