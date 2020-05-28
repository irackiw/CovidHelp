using CovidHelp.DataTransfer;
using CovidHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int userId);
        User UpdateUser(User user);
        void InsertUser(User user);
        void DeleteUser(int userId);
    }
}
