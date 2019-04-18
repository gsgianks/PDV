using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Models
{
    public class OrderList
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalRecords { get; set; }
        public List<OrderItemList> OrderDetails { get; set; }
        public void setDetails(List<OrderItemList> details)
        {
            OrderDetails = details.Where(x => x.OrderId == OrderId).ToList();
        }
    }
}
