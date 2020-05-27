using CovidHelp.DataAccess.Context;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CovidContext _context;
        public UserRepository(CovidContext context)
        {
            _context = context;
        }
        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public UserDto InsertUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserDto UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
