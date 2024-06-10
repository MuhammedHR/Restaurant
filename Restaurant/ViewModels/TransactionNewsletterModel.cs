using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class TransactionNewsletterModel : BaseEntityModel
    {
        public List<TransactionNewsletter>? ListTransactionNewsletter { get; set; }

        public int TransactionNewsletterId { get; set; }

        [Display(Name = "NewsletterEmail ")]

        public string? TransactionNewsletterEmail { get; set; }
    }
}
