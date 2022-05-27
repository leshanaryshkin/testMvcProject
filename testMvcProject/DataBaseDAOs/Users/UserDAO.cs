using System;
using System.Linq;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBase;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace testMvcProject.DataBaseDAOs.Users
{
    public class UserDAO : IUserManager
    {
        private readonly DBContext2 dBContext;

        public UserDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }



        public async Task<IList<User>> GetAll() => await dBContext.Users.ToListAsync();

        public async Task Create(User user)
        {
            

            dBContext.Users.Add(new User
            {
               Adress = user.Adress, Name = user.Name, telephone = user.telephone
            }) ;
            await dBContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userR = dBContext.Users.Find(id);
            if (userR != null)
            {
                dBContext.Users.Remove(userR);
                await dBContext.SaveChangesAsync();
            }
            
        }

        public  bool ContainTel(string tel) {
            DataBase.User user = dBContext.Users.FirstOrDefault(p => p.telephone == tel);
            if (user == null)
                return false;
            return true;

        }
    }
}
