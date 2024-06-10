using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class TransactionContactUModel : BaseEntityModel
    {
        public List<TransactionContactU>? ListTransactionContactU { get; set; }

        public int TransactionContactUId { get; set; }

        [Display(Name = "ContactUsFullName ")]

        public string? TransactionContactUsFullName { get; set; }

        [Display(Name = "ContactUsEmail ")]

        public string? TransactionContactUsEmail { get; set; }

        [Display(Name = "ContactUsSubject ")]

        public string? TransactionContactUsSubject { get; set; }

        [Display(Name = "ContactUsMessage ")]

        public string? TransactionContactUsMessage { get; set; }
    }
}
