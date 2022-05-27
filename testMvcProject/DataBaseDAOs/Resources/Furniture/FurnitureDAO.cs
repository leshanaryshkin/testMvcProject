using System;
using testMvcProject.DataBase;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace testMvcProject.DataBaseDAOs.Resources.Furniture
{
    public class FurnitureDAO : IFurnitureManager
    {
        private readonly DBContext2 dBContext;

        public FurnitureDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Create(DataBase.Furniture furniture)
        {
            dBContext.Furnitures.Add(furniture);

            dBContext.SaveChanges();
        }

        public List<DataBase.Furniture> GetAll() => dBContext.Furnitures.ToList();
        
        
        public DataBase.Furniture ContainFurniture(string furnitureName) => dBContext.Furnitures.FirstOrDefault(p => p.Name == furnitureName);



        public void ChangeActualPosition(string name)
        {
            DataBase.Furniture furniture = new DataBase.Furniture();
            furniture = ContainFurniture(name);
            if (furniture != null)
            {
                furniture.isActualPosition = !furniture.isActualPosition;
                dBContext.Entry(furniture).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();
            }
        }




    }
}
