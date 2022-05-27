using System;
using testMvcProject.DataBase;
using System.Linq;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.Resources.Profile
{
    public class ProfileDAO : IProfileManager
    {
        private readonly DBContext2 dBContext;

        public ProfileDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Create(DataBase.Profile profile)
        {
            dBContext.Profiles.Add(profile);

            dBContext.SaveChanges();
        }

        public List<DataBase.Profile> GetAll() => dBContext.Profiles.ToList();


        public DataBase.Profile ContainProfile(string profileName)
            => dBContext.Profiles.FirstOrDefault(p => p.Name == profileName);



        public void ChangeActualPosition(string name)
        {
            DataBase.Profile profile = new DataBase.Profile();
            profile = ContainProfile(name);
            if (profile != null)
            {
                profile.isActualPosition = !profile.isActualPosition;
                dBContext.Entry(profile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();
            }
        }

    }
}
