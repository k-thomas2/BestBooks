using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Models
{
    public class ReviewEdit
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ReviewContent { get; set; }
    }
}
