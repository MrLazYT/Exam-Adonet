using BookstoreDBLib;
using BookstoreDBLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDBLib
{
    public abstract class LoginManager
    {
        public static bool LogIn(BookstoreDB context, User user)
        {
            bool res = false;

            if (context.Users.ContainsEmailPassword(user))
            {
                res = true;
                user = context.Users.GetUserByEmailAndPassword(user);
                FileUserManager.WriteUser(user);
            }
            else
            {
                res = false;
            }

            return res;
        }

        public static void Register(BookstoreDB context, User user)
        {
            context.Add(user);

            context.SaveChanges();
        }
    }
}
