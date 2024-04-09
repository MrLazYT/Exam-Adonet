using BookstoreDBLib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDBLib
{
    public static class UsersPlugin
    {
        public static bool ContainsEmailPassword(this DbSet<User> Users, User user)
        {
            bool res = false;
            foreach (User dbUser in Users)
            {
                res = dbUser.Email == user.Email && dbUser.Password == user.Password;

                if (res)
                {
                    break;
                }
            }

            return res;
        }

        public static User GetUserByEmailAndPassword(this DbSet<User> Users, User user)
        {
            User res = new User();

            foreach (User dbUser in Users)
            {
                if (dbUser.Email == user.Email && dbUser.Password == user.Password)
                {
                    res = dbUser;
                    break;
                }
            }

            return res;
        }
    }
}
