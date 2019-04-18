using AutoFixture;
using Moq;
using Servicios.Models;
using Servicios.Repositories;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicios.BussinesLogicTest.Mocked
{
    public class OrderRepositoryMocked
    {
        private readonly List<Order> _orders;

        public OrderRepositoryMocked()
        {
            _orders = GetOrders();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Order)
                .Returns(GetOrderRepositoryMocked());

            return mocked.Object;

        }

        public IOrderRepository GetOrderRepositoryMocked()
        {

            var orderMocked = new Mock<IOrderRepository>();

            orderMocked.Setup(c => c.GetList())
                .Returns(_orders);

            return orderMocked.Object;
        }

        public List<Order> GetOrders() {
            var fixture = new Fixture();
            var orders = fixture.CreateMany<Order>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                orders[i].Id = i + 1;
            }
            return orders;

        }
    }
}
