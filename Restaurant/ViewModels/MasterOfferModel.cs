using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public partial class MasterOfferModel : BaseEntityModel
    {
        public List<MasterOffer>? ListMasterOffer { get; set; }

        public int MasterOfferId { get; set; }

        [Display(Name = "OfferTitle")]

        public string? MasterOfferTitle { get; set; }
        
        [Display(Name = "OfferBreef")]

        public string? MasterOfferBreef { get; set; }

        [Display(Name = "OfferDesc")]

        public string? MasterOfferDesc { get; set; }

        [Display(Name = "OfferImage")]

        public string? MasterOfferImageUrl { get; set; }
        public IFormFile? File { get; set; }

    }
}
