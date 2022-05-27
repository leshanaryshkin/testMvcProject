using System;
using testMvcProject.DataBase;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.Resources.Furniture
{
    public interface IFurnitureManager
    {
        void Create(DataBase.Furniture furniture);
        List<DataBase.Furniture> GetAll();
        DataBase.Furniture ContainFurniture(string furnitureName);
        void ChangeActualPosition(string name);
    }
}
