using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidHelp.DataAccess.Context;
using CovidHelp.Models;

namespace CovidHelp.DataAccess.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly CovidContext _context;
        public OfferRepository(CovidContext context)
        {
            _context = context;
        }
        public void DeleteUser(int offerId)
        {
            throw new NotImplementedException();
        }

        public Offer GetUser(int offerId)
        {
            throw new NotImplementedException();
        }

        public Offer InsertUser(Offer offer)
        {
            throw new NotImplementedException();
        }

        public Offer UpdateUser(Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
