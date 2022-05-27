using System;
using testMvcProject.DataBase;
using System.Linq;
using testMvcProject.DataBaseDAOs.Users;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testMvcProject.DataBaseDAOs.UsersLoginsPasswords
{
    public class UsersLoginsPasswordsDAO : IUserLoginsPasswordsManager
    {
        private readonly DBContext2 dBContext;

        public UsersLoginsPasswordsDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Create(UserLoginPassword usersLoginsPasswords)
        {
            dBContext.UsersLoginsPasswords.Add(usersLoginsPasswords);

            dBContext.SaveChanges();

        }

        public void Delete(int ID)
        {
            var userR = dBContext.UsersLoginsPasswords.FirstOrDefault(p => p.ID == ID);
            if (userR != null)
            {
                dBContext.UsersLoginsPasswords.Remove(userR);
                dBContext.SaveChanges();
            }
        }

        public bool ContainAccount(string tel, string password)
        {
            var userR = dBContext.UsersLoginsPasswords.FirstOrDefault(
                p => p.Login == tel && p.Password == password);
            if (userR == null)
                return false;
            return true;

        }
    }
}
