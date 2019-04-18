using FluentAssertions;
using Servicios.BusinessLogic.Implementations;
using Servicios.BusinessLogic.Intefaces;
using Servicios.BussinesLogicTest.Mocked;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Servicios.BussinesLogicTest
{
  
    public class OrderLogicTest
    {

        private readonly IUnitOfWork _unitMocked;
        private readonly IOrderLogic _orderLogic;

        public OrderLogicTest()
        {
            var unitMocked = new OrderRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _orderLogic = new OrderLogic(_unitMocked);
        }

        [Fact]
        public void GetOrderNumber_Order_Test()
        {
            var result = _orderLogic.GetOrderNumber(1);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }
    }
}
