using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestBooks_MVC.Models
{
    public class BookListItem
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}