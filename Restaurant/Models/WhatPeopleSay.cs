namespace Restaurant.Models
{
    public class WhatPeopleSay : BaseEntity
    {
        public int WhatPeopleSayId { get; set; }
        public string? WhatPeopleSayName { get; set; }

        public string? WhatPeopleSayDescription { get; set; }

        public string? WhatPeopleSayImage { get; set; }


    }
}
