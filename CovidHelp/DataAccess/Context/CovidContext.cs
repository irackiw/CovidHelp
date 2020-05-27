using CovidHelp.DataTransfer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Context
{
    public class CovidContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public DbSet<OfferDto> Offers { get; set; }
        public DbSet<UserOfferDto> UserOffers { get; set; }
        public DbSet<UserAppliedOffer> UserAppliedOffers { get; set; }

        public CovidContext(DbContextOptions<CovidContext> options) : base(options)
        {

        }
    }
}
