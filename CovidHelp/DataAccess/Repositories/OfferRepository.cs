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

        public void DeleteOffer(int offerId)
        {
            throw new NotImplementedException();
        }

        public IList<Offer> GetUserOffersByUserId(int userId)
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

        public IList<Offer> GetUserAppliedOffersByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Offer GetOffer(int offerId)
        {
            throw new NotImplementedException();
        }

        public Offer UpdateOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public void InsertOffer(Offer offer, int userId)
        {
            if (offer != null)
            {
                _context.Offer.Add(offer);
                _context.UserOffer.Add(new UserOffer
                {
                    CreatedAt = DateTime.Now,
                    Offer = offer,
                    UserId = (uint) userId
                });
                _context.SaveChanges();
            }
        }
    }
}
