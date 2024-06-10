using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class MasterCategoryMenu : BaseEntity
    {

        
        public int MasterCategoryMenuId { get; set; }

        [Display(Name = "CategoryName")]
        public string? MasterCategoryMenuName { get; set; }

    }
}
