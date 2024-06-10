using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MasterWorkingHour : BaseEntity
    {
        public int MasterWorkingHourId { get; set; }
        public string? MasterWorkingHoursIdName { get; set; }
        public string? MasterWorkingHoursIdTimeFormTo { get; set; }
    }
}
