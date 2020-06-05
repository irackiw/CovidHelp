using System;
using System.Collections.Generic;
using CovidHelp.Models;

namespace CovidHelp.DataTransfer
{
    public partial class User
    {
        public User()
        {
            UserAppliedOffer = new HashSet<UserAppliedOffer>();
            UserOffer = new HashSet<UserOffer>();
        }

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Pesel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserAppliedOffer> UserAppliedOffer { get; set; }
        public virtual ICollection<UserOffer> UserOffer { get; set; }
    }
}
