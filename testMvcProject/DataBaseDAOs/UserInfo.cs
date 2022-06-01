using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;

namespace testMvcProject.DataBaseDAOs
{
    public class UserInfo
    {
        public readonly IUserManager UserManager;
        public readonly IUserLoginsPasswordsManager UserLoginsPasswordsManager;

        public UserInfo(IUserManager UserManager, IUserLoginsPasswordsManager UserLoginsPasswordsManager)
        {
            this.UserManager = UserManager;
            this.UserLoginsPasswordsManager = UserLoginsPasswordsManager;
        }
    }
}