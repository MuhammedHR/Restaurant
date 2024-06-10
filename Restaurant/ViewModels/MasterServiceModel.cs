using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterServiceModel : BaseEntityModel
    {
        public List<MasterService>? ListMasterService { get; set; }

        public int MasterServiceId { get; set; }

        [Display(Name = "ServicesTitle")]

        public string? MasterServicesTitle { get; set; }

        [Display(Name = "ServicesDesc")]

        public string? MasterServicesDesc { get; set; }
        public string? MasterServicesIcon { get; set; }

    }
}
