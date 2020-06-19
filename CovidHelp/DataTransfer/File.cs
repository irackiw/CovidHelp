using System;
using System.Collections.Generic;

namespace CovidHelp.DataTransfer
{
    public partial class File
    {
        public File()
        {
            Offer = new HashSet<Offer>();
        }

        public uint Id { get; set; }
        public string Filename { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}
