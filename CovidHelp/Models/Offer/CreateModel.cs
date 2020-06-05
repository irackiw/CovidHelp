using System;

namespace CovidHelp.Models.Offer
{
    public class CreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ValidTo { get; set; }
        public string City { get; set; }
    }
}
