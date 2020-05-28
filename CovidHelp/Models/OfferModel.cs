using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidHelp.DataTransfer;

namespace CovidHelp.Models
{
    public class OfferModel
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidTo { get; set; }
        public string City { get; set; }
        public File Photo { get; set; }
    }
}
