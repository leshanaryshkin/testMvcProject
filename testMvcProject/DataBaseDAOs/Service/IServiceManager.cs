using System.Collections.Generic;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.Service
{
    public interface IServiceManager
    {
        List<AdditionalService> GetAll();
        void Add(AdditionalService newService);
        void ChangeActual(string name);
        AdditionalService Get(string name);
    }
}