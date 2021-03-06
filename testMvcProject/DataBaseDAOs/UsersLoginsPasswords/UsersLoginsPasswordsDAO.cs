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

        public bool isAdmin(string tel)
        {
            if (dBContext.UsersLoginsPasswords.FirstOrDefault(p => p.Login == tel && p.Is_admin) != null)
                return true;
            return false;
        }

        public void changePass(string tel, string pass)
        {
            DataBase.UserLoginPassword user = dBContext.UsersLoginsPasswords.FirstOrDefault(p => p.Login == tel);

            user.Password = pass;
                dBContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();

        }
        
        public UserLoginPassword Get(string tel) => dBContext.UsersLoginsPasswords.FirstOrDefault(p => p.Login == tel);


    }
}
