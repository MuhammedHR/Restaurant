using Restaurant.Models;
using System;
using System.Collections.Generic;

namespace Restaurant.ViewModels
{
    public  class MasterContactUsInformationModel : BaseEntityModel
    {
        public List<MasterContactUsInformation>? ListMasterContactUsInformation { get; set; }

        public int MasterContactUsInformationId { get; set; }
        public string? MasterContactUsInformationIdesc { get; set; }
        public string? MasterContactUsInformationIconUrl { get; set; }
        public string? MasterContactUsInformationRedirect { get; set; }

    }
}
