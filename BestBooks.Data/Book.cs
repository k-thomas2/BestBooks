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
        readonly List<Book> _books = new List<Book>();
        public enum Genre { ScienceFiction, Satire, Drama, Action, Romance, Mystery, Horror, SelfHelp, Health, Guide, Childrens, Spirituality, Science, History, Fantasy, Comic, Journal, Series, Biography, Autobiography, Poetry }
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
        public virtual Review Review { get; set; }
        public decimal AvgBookRating { get; set; }
    }
}
