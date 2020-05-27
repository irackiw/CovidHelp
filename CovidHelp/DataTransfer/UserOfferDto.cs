using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CovidHelp.DataTransfer
{
    [Table("user_offer")]
    public class UserOfferDto
    {
        [Key]
        [DataMember]
        [Column("id")]
        public int UserOfferId { get; set; }
        [DataMember]
        [Column("user_id")]
        public int UserId { get; set; }
        [DataMember]
        [Column("offer_id")]
        public int OfferId { get; set; }
        [DataMember]
        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
    }
}
