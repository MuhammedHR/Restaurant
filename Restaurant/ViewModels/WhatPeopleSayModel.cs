using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class WhatPeopleSayModel : BaseEntityModel
    {

        public List<WhatPeopleSay>? ListWhatPeopleSay { get; set; }

        public int WhatPeopleSayId { get; set; }
        public string? WhatPeopleSayName { get; set; }

        public string? WhatPeopleSayDescription { get; set; }

        public string? WhatPeopleSayImage { get; set; }

        public IFormFile? File { get; set; }


    }
}
