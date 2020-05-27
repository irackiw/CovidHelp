using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        OfferDto GetUser(int offerId);
        OfferDto UpdateUser(OfferDto offer);
        OfferDto InsertUser(OfferDto offer);
        void DeleteUser(int offerId);
    }
}
