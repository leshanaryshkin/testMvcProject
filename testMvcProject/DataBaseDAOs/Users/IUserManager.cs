using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.Users
{
    public interface IUserManager
    {
        Task<IList<User>> GetAll();
        Task Create(User user);
        Task Delete(int ID);
        bool ContainTel(string tel);

    }
}
