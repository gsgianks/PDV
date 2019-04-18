using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> getPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
        bool Delete(Order order);
        Order GetById(int id);
        string GetOrderNumber(int orderId);
        
     }
}
