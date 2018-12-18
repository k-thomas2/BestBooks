using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
    }
}
