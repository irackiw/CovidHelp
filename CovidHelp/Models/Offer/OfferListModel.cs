using System;
using CovidHelp.DataTransfer;

namespace CovidHelp.Models.Offer
{
    public class OfferListModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidTo { get; set; }
        public string City { get; set; }
        public virtual File Photo { get; set; }
    }
}
