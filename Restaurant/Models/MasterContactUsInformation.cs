using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public  class MasterContactUsInformation : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        [Display(Name = "ContactUsDesc")]

        public string? MasterContactUsInformationIdesc { get; set; }
       
        [Display(Name = "ContactUsIcon")]

        public string? MasterContactUsInformationIconUrl { get; set; }

        [Display(Name = "ContactUsRedirect")]

        public string? MasterContactUsInformationRedirect { get; set; }
    }
}
