using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterSlider> ListSlider { get; set; }
        public List<MasterMenu> ListMenu { get; set; }
        public List<MasterCategoryMenu> ListCategoryMenu { get; set; }
        public List<MasterContactUsInformation> ListContactUsInformation { get; set; }
        public List<MasterItemMenu> ListItemMenu { get; set; }
        public MasterOffer Offer { get; set; }
        public List<MasterPartner> ListPartner { get; set; }
        public List<MasterService> ListService { get; set; }
        public List<MasterSocialMedium> ListSocialMedium { get; set; }
        public List<MasterWorkingHour> ListWorkingHour { get; set; }

        public List<WhatPeopleSay> ListWhatPeopleSay { get; set; }


        public MasterItemMenu MasterItemMenu { get; set; }

        public TransactionBookTable TransactionBookTable { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public TransactionContactU TransactionContactU { get; set; }



        public SystemSetting SystemSetting { get; set; }

    }
}
