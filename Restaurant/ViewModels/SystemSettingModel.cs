using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class SystemSettingModel : BaseEntityModel
    {
        public List<SystemSetting>? ListSystemSetting { get; set; }

        public int SystemSettingId { get; set; }

        [Display(Name = "Logo ")]

        public string? SystemSettingLogoImageUrl { get; set; }

        [Display(Name = "Logo2 ")]

        public string? SystemSettingLogoImageUrl2 { get; set; }

        [Display(Name = "Copyright ")]

        public string? SystemSettingCopyright { get; set; }

        [Display(Name = "WelcomeNoteTitle ")]

        public string? SystemSettingWelcomeNoteTitle { get; set; }

        [Display(Name = "WelcomeNoteBreef ")]

        public string? SystemSettingWelcomeNoteBreef { get; set; }

        [Display(Name = "WelcomeNoteDesc ")]

        public string? SystemSettingWelcomeNoteDesc { get; set; }

        [Display(Name = "WelcomeNoteUrl ")]

        public string? SystemSettingWelcomeNoteUrl { get; set; }
        [Display(Name = "WelcomeNoteUrlNoteImage ")]

        public string? SystemSettingWelcomeNoteImageUrl { get; set; }

        [Display(Name = "MapLocation ")]

        public string? SystemSettingMapLocation { get; set; }
        public IFormFile? File { get; set; }
        public IFormFile? File2 { get; set; }
        public IFormFile? File3 { get; set; }
        public IFormFile? File4 { get; set; }
    }
}
