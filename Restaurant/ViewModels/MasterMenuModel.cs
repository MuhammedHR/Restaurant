using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterMenuModel : BaseEntityModel
    {
        public List<MasterMenu>? ListMasterMenu { get; set; }

        public int MasterMenuId { get; set; }

        [Display(Name = "MenuName")]


        public string? MasterMenuName { get; set; } = null!;
       
        [Display(Name = "MenuUrl ")]

        public string? MasterMenuUrl { get; set; } = null!;

    }
}
