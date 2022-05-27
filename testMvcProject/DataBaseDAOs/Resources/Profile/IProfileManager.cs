using System;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.Resources.Profile
{
    public interface IProfileManager
    {
        void Create(DataBase.Profile profile);
        List<DataBase.Profile> GetAll();
        DataBase.Profile ContainProfile(string profileName);
        void ChangeActualPosition(string name);

    }
}
