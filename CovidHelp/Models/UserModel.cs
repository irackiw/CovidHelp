using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidHelp.DataTransfer;

namespace CovidHelp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Pesel { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public IList<DataTransfer.Offer> UserOffers { get; set; }
        public IList<DataTransfer.Offer> UserAppliedOffer { get; set; }

    }
}
