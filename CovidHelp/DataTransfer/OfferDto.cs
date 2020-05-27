using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CovidHelp.DataTransfer
{
    [Table("offer")]
    public class OfferDto
    {
        [Key]
        [DataMember]
        [Column("id")]
        public int OfferId { get; set; }
        [DataMember]
        [Column("title")]
        public String Title { get; set; }
        [DataMember]
        [Column("description")]
        public String Description { get; set; }
        [DataMember]
        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        [Column("valid_to")]
        public DateTime ValidToDate { get; set; }
        [DataMember]
        [Column("city")]
        public String City { get; set; }
    }
}
