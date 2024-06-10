using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterPartnerModel : BaseEntityModel
    {
        public List<MasterPartner>? ListMasterPartner { get; set; }

        public int MasterPartnerId { get; set; }

        [Display(Name = "PartnerName")]

        public string? MasterPartnerName { get; set; }

        [Display(Name = "PartnerLogo")]

        public string? MasterPartnerLogoImageUrl { get; set; }

        [Display(Name = "PartnerWebsiteUrl")]

        public string? MasterPartnerWebsiteUrl { get; set; }
        public IFormFile? File { get; set; }


    }
}
