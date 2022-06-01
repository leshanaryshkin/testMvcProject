using System;
using testMvcProject.DataBase;
using System.Linq;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.OrderContent
{
    public class UserContentDAO
    {
        private readonly DBContext2 dBContext;

        public UserContentDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        void Create(List<Window> windows)
        {
            /*foreach(var window in windows)
            {
                DataBase.OrderContent order = new DataBase.OrderContent();
                order.ID = 
                

                dBContext.OrderContents.Add()
            }*/
        }
        //List<DataBase.OrderContain> GetAll() => dBContext.ToList();
        void ChangeActualPosition(int id) { }

    }
}
