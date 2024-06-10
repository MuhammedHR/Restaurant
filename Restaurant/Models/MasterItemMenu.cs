using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class MasterItemMenu : BaseEntity
    {
        public int MasterItemMenuId { get; set; }


        public int? MasterCategoryMenuId { get; set; }

        [Display(Name = "ItemName")]

        public string? MasterItemMenuTitle { get; set; }

        [Display(Name = "ItemBreef")]

        public string? MasterItemMenuBreef { get; set; }

        [Display(Name = "ItemDesc")]

        public string? MasterItemMenuDesc { get; set; }

        [Display(Name = "ItemPrice")]

        public decimal? MasterItemMenuPrice { get; set; }

        [Display(Name = "ItemImage")]

        public string? MasterItemMenuImageUrl { get; set; }

        [Display(Name = "ItemDate")]
        [DataType(DataType.Date)]
        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
    }
}
