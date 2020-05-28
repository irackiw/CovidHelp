using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Offer GetOffer(int offerId);
        Offer UpdateOffer(Offer offer);
        void InsertOffer(Offer offer, int userId);
        void DeleteOffer(int offerId);
        IList<Offer> GetUserOffersByUserId(int userId);
        IList<Offer> GetUserAppliedOffersByUserId(int userId);
    }
}
