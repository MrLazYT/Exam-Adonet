using BookstoreDBLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLib
{
    public abstract class FileUserManager
    {
        private static string fileName = "user.dat";

        public static void ReadUser(User user)
        {
            using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                user.Name = br.ReadString();
                user.Surname = br.ReadString();
                user.Email = br.ReadString();
                user.Password = br.ReadString();
            }
        }

        public static void WriteUser(User user)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
            {
                bw.Write(user.Name);
                bw.Write(user.Surname);
                bw.Write(user.Email);
                bw.Write(user.Password);
            }
        }

        public static bool isFileExists()
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Open, FileAccess.Write))) { }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
