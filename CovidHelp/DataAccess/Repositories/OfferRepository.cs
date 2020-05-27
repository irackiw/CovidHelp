using CovidHelp.DataAccess.Context;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public OfferDto GetUser(int offerId)
        {
            throw new NotImplementedException();
        }

        public OfferDto InsertUser(OfferDto offer)
        {
            throw new NotImplementedException();
        }

        public OfferDto UpdateUser(OfferDto offer)
        {
            throw new NotImplementedException();
        }
    }
}
