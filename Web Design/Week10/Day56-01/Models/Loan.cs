using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Day56_01.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [MinLength(2)]
        [HtmlAttributeName("Borrower Name")]
        public string BorrowerName { get; set; }
        [HtmlAttributeName("Lender Name")]
        public string LenderName { get; set; }
        [Range(1,500000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }
    }
}
