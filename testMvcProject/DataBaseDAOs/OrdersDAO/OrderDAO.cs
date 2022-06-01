using System;
using System.Collections.Generic;
using System.Linq;
using testMvcProject.DataBase;
using testMvcProject.DataBaseDAOs.OrdersDAO;
namespace testMvcProject.DataBaseDAOs.OrdersDAO
{
    public class OrderDAO : IOrderManager
    {
        
        private readonly DBContext2 dBContext;

        public OrderDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Order> GetAll() => dBContext.Orders.ToList();
        public void Add(Order order)
        {
            dBContext.Orders.Add(order);
            dBContext.SaveChanges();
        }





    }
}
