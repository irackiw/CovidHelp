using System;
using System.Collections.Generic;

namespace CovidHelp.DataTransfer
{
    public partial class UserOffer
    {
        public uint Id { get; set; }
        public uint? UserId { get; set; }
        public uint? OfferId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}
