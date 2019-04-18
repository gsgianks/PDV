using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<OrderList> getPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
    }
}
