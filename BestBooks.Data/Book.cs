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
       public enum Genre { scienceFiction, satire, drama, action, romance, mystery, horror, selfHelp, health, guide, childrens, spirituality, science, history, fantasy, comic, journal, series, biography, autobiography, poetry}
        [Key]
        public int BookId { get; set; }
        //[Required]
        //public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public  Genre BookGenre { get; set; }
        public int ReviewId { get; set; }
        public decimal BookRating { get; set; }
    }
}
