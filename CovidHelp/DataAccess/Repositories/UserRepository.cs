using CovidHelp.DataAccess.Repositories.Interfaces;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        public IList<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public IList<User> GetUsers(IList<int> userIds)
        {
            return _context.User.Where(u => userIds.Contains((int)u.Id)).ToList();
        }

        public User GetUser(int userId)
        {
            return _context.User.FirstOrDefault(x => x.Id == userId);
        }

        public User Login(UserLogin userLogin)
        {
            var User = _context.User.FirstOrDefault(x => x.Email == userLogin.Email);

            if (null == User) return User;

            /*var passwordValidated = VerifyPassword(User.Password, userLogin.Password);
            if (!passwordValidated) return null;*/

            return User;
        }

        public void InsertUser(User user)
        {
            if (user != null)
            {
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.Password = CryptPassword(user.Password);
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        private string CryptPassword(string plainPassword)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }

        }

        private bool VerifyPassword(string plainPassword, string md5Password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hashOfInput = CryptPassword(plainPassword);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(hashOfInput, md5Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
