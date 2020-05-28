using System;
using System.Collections.Generic;
using CovidHelp.Models;

namespace CovidHelp.DataTransfer
{
    public partial class Offer
    {
        public Offer()
        {
            UserAppliedOffer = new HashSet<UserAppliedOffer>();
            UserOffer = new HashSet<UserOffer>();
        }

        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidTo { get; set; }
        public string City { get; set; }
        public uint? PhotoId { get; set; }

        public virtual File Photo { get; set; }
        public virtual ICollection<UserAppliedOffer> UserAppliedOffer { get; set; }
        public virtual ICollection<UserOffer> UserOffer { get; set; }
    }
}
