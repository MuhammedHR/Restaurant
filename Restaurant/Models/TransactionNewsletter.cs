using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class TransactionNewsletter : BaseEntity
    {
        public int TransactionNewsletterId { get; set; }

        [Display(Name = "NewsletterEmail ")]

        public string? TransactionNewsletterEmail { get; set; }
    }
}
