using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks.Models
{
    public class ReviewDetail
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ReviewContent { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ReviewId}] {Title}";
    }
}
