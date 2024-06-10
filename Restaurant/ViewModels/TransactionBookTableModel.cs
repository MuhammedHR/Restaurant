using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class TransactionBookTableModel : BaseEntityModel
    {
        public List<TransactionBookTable>? ListTransactionBookTable { get; set; }

        public int TransactionBookTableId { get; set; }

        [Display(Name = "BookTableFullName ")]

        public string? TransactionBookTableFullName { get; set; }

        [Display(Name = "BookTableEmail ")]

        public string? TransactionBookTableEmail { get; set; }

        [Display(Name = "BookTableMobileNumber ")]

        public string? TransactionBookTableMobileNumber { get; set; }

        [Display(Name = "BookTableDate ")]

        public DateTime? TransactionBookTableDate { get; set; }
    }
}
