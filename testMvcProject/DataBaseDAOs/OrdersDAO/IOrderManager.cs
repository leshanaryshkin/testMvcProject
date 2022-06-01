using System.Collections.Generic;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.OrdersDAO
{
    public interface IOrderManager
    {
        List<Order> GetAll();
        void Add(Order order);
    }
}
