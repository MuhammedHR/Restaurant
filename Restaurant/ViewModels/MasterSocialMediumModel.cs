using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterSocialMediumModel : BaseEntityModel
    {
        public List<MasterSocialMedium>? ListMasterSocialMedium { get; set; }

        public int MasterSocialMediumId { get; set; }

        [Display(Name = "SocialMediaIcon ")]

        public string? MasterSocialMediaIcon { get; set; } = null!;

        [Display(Name = "SocialMediaUrl ")]

        public string? MasterSocialMediaUrl { get; set; } = null!;
        public IFormFile? File { get; set; }

    }
}
