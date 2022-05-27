using System;
using System.Linq;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBase;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;



namespace testMvcProject.DataBaseDAOs.Users
{
    public class UserDAO : IUserManager
    {
        private readonly DBContext2 dBContext;

        public UserDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }



        public List<User> GetAll() => dBContext.Users.ToList();

        public void Create(User user)
        {
            dBContext.Users.Add(user);

            dBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var userR = dBContext.Users.FirstOrDefault(p => p.ID == id);
            if (userR != null)
            {
                dBContext.Users.Remove(userR);

                dBContext.SaveChanges();
            }
            
        }

        public  int? ContainTel(string tel) {
            DataBase.User user = dBContext.Users.FirstOrDefault(p => p.telephone == tel);
            if (user == null)
                return null;
            return user.ID;

        }

    }
}
