using System;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.OrderContent
{
    public interface IUserContentManager
    {
        void Create(DataBase.OrderContain content);
        List<DataBase.OrderContain> GetAll();
        void ChangeActualPosition(int id);


    }
}
