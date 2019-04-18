using System.Collections.Generic;
using System.Linq;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Order order)
        {
            return _unitOfWork.Order.Delete(order);
        }

        public Order GetById(int id)
        {
            return _unitOfWork.Order.GetById(id);
        }

        public OrderList GetOrderById(int orderId)
        {
            return _unitOfWork.Order.GetOrderById(orderId);
        }

        public IEnumerable<OrderList> getPaginatedOrder(int page, int rows)
        {
            return _unitOfWork.Order.getPaginatedOrder(page, rows);
        }

        public string GetOrderNumber(int orderId) {
            var list = _unitOfWork.Order.GetList();
            if (list == null) return string.Empty;
            var record = list.First(x => x.Id == orderId);
            return record.OrderNumber;
        }
    }
}
