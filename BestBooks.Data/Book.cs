using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Data
{
    public class Book
    {
        List<Book> _books = new List<Book>();
       public enum Genre { scienceFiction, satire, drama, action, romance, mystery, horror, selfHelp, health, guide, childrens, spirituality, science, history, fantasy, comic, journal, series, biography, autobiography, poetry}
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public  Genre BookGenre { get; set; }
        [Key]
        public int ReviewId { get; set; }
        public decimal AvgBookRating { get; set; }
    }
}
