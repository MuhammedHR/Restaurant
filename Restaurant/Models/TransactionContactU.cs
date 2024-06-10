using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class TransactionContactU : BaseEntity
    {
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
