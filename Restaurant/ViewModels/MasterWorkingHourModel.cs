using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterWorkingHourModel : BaseEntityModel
    {
        public List<MasterWorkingHour>? ListMasterWorkingHour { get; set; }

        public int MasterWorkingHourId { get; set; }

        [Display(Name = "WorkingHoursName ")]

        public string? MasterWorkingHoursIdName { get; set; }

        [Display(Name = "WorkingHoursTimeFormTo ")]

        public string? MasterWorkingHoursIdTimeFormTo { get; set; }
    }
}
