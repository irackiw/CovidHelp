using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Offer GetUser(int offerId);
        Offer UpdateUser(Offer offer);
        Offer InsertUser(Offer offer);
        void DeleteUser(int offerId);
    }
}
