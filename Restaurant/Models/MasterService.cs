using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MasterService : BaseEntity
    {
        public int MasterServiceId { get; set; }
        public string? MasterServicesTitle { get; set; }
        public string? MasterServicesDesc { get; set; }
        public string? MasterServicesIcon { get; set; }
    }
}
