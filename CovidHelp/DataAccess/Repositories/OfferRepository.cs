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

        public IList<Offer> GetOffersByUserId(int userId)
        {
            var userOffers = _context.UserOffer.Where(x => x.UserId == userId).ToList();
            var offers = new List<Offer>();
            if (userOffers.Any())
            {
                offers = (from offer in _context.Offer
                    from userOffer in _context.UserOffer
                    where offer.Id == userOffer.OfferId
                    select offer).ToList();
            }

            return offers;
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
