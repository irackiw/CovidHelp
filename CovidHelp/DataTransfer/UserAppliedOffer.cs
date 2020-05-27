using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataTransfer
{
    [Table("user_applied_offer")]
    public class UserAppliedOffer
    {
        [Key]
        [Column("id")]
        public int UserOfferId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("offer_id")]
        public int OfferId { get; set; }
        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
    }
}
