using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestBooks.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        List<Book> _books = new List<Book>();
        public enum Genre { scienceFiction, satire, drama, action, romance, mystery, horror, selfHelp, health, guide, childrens, spirituality, science, history, fantasy, comic, journal, series, biography, autobiography, poetry }
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Genre BookGenre { get; set; }
        [Required]
        public int ReviewId { get; set; }
        public decimal AvgBookRating { get; set; }

        //public static implicit operator Book(Book v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
