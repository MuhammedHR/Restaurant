using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterSliderModel : BaseEntityModel
    {
        public List<MasterSlider>? ListMasterSlider { get; set; }

        public int MasterSliderId { get; set; }

        [Display(Name = "SliderTitle ")]

        public string? MasterSliderTitle { get; set; }

        [Display(Name = "SliderBreef ")]

        public string? MasterSliderBreef { get; set; }

        [Display(Name = "SliderDesc ")]

        public string? MasterSliderDesc { get; set; }

        [Display(Name = "SliderUrl ")]

        public string? MasterSliderUrl { get; set; }
        
        [Display(Name = "SliderImage ")]

        public string? MasterSliderImage { get; set; }

        public IFormFile? File { get; set; }

    }
}
