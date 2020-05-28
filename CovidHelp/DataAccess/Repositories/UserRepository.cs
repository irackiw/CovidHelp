using CovidHelp.DataAccess.Context;
using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
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

        public User GetUser(int userId)
        {
            return _context.User.FirstOrDefault(x => x.Id == userId);
        }

        public void InsertUser(User user)
        {
            if (user != null)
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
