using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CovidHelp.DataTransfer
{
    [Table("user")]
    public class UserDto
    {
        [Key]
        [DataMember]
        [Column("id")]
        public int UserId { get; set; }
        [DataMember]
        [Column("first_name")]
        public String FirstName { get; set; }
        [DataMember]
        [Column("last_name")]
        public String LastName { get; set; }
        [DataMember]
        [Column("pesel")]
        public int Pesel { get; set; }
        [DataMember]
        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        [Column("updated_at")]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        [Column("email")]
        public String Email { get; set; }
    }
}
