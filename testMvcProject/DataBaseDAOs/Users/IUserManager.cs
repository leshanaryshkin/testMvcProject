using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.Users
{
    public interface IUserManager
    {
        List<User> GetAll();
        void Create(User user);
        void Delete(int ID);
        int? ContainTel(string tel);
        User Get(string tel);
    }
}
