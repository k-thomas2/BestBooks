using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedNote { get; set; }

        public override string ToString() => Content;
    }
}
