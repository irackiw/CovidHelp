using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var offer = GetOffer(offerId);
            _context.Offer.Remove(offer);
        }
        //Cos mi tutaj nie pasuje, trzeba dodac dodawanie ofert zeby to przetestowac, ale wydaje mi sie ze cos tutaj zjebalem
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
        //Cos mi tutaj nie pasuje, trzeba dodac dodawanie ofert zeby to przetestowac, ale wydaje mi sie ze cos tutaj zjebalem 
        public IList<Offer> GetUserAppliedOffersByUserId(int userId)
        {
            var userAppliedOffers = _context.UserAppliedOffer.Where(x => x.UserId == userId).ToList();
            var offers = new List<Offer>();
            if (userAppliedOffers.Any())
            {
                offers = (from offer in _context.Offer
                    from userOffer in _context.UserAppliedOffer
                    where offer.Id == userOffer.OfferId
                    select offer).ToList();
            }

            return offers;
        }

        public Offer GetOffer(int offerId)
        {
           return _context.Offer.Where(x => x.Id == offerId).First();
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
