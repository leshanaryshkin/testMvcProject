using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.UsersLoginsPasswords

{
    public interface IUserLoginsPasswordsManager
    {
        void Create(UserLoginPassword usersLoginsPasswords);
        void Delete(int ID);
        bool ContainAccount(string tel, string password);
        bool isAdmin(string tel);
    }
}
