using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int ReviewId { get; set; }
        public virtual Review Review { get; set;}
        [Required]
        [MaxLength(250, ErrorMessage ="There are too many characters in this field.")]
        public string Content { get; set; }
        public Guid OwnerId { get; set; }
    }
}
