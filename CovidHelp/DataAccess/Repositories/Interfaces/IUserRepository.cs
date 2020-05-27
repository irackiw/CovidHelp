using CovidHelp.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetUser(int userId);
        UserDto UpdateUser(UserDto user);
        UserDto InsertUser(UserDto user);
        void DeleteUser(int userId);
    }
}
