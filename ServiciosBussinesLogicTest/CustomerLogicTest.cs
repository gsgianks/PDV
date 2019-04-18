using Servicios.BussinesLogicTest.Mocked;
using Xunit;
using FluentAssertions;
using Servicios.UnitOfWork;
using Servicios.BusinessLogic.Intefaces;
using Servicios.BusinessLogic.Implementations;
using Servicios.Models;

namespace ServiciosBussinesLogicTest
{
    public class CustomerLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly ICustomerLogic _customerLogic;

        public CustomerLogicTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerLogic = new CustomerLogic(_unitMocked);
        }

        [Fact]
        public void GetById_Customer_Test()
        {
            var result = _customerLogic.GetById(1);
            result.Should().NotBeNull(); //Validación que no devulva null
            result.Id.Should().BeGreaterThan(0); //Validación que el Id sea mayor a 0
        }

        [Fact(DisplayName ="[CustomerLogic] Insert")]
        public void Insert_Customer_Test()
        {
            var customer = new Customer()
            {
                Id = 101,
                City = "Lima",
                Country = "Peru",
                FirstName = "Cesar",
                LastName = "Vallejo",
                Phone = "999999"
            };
            var result = _customerLogic.Insert(customer);
            result.Should().Be(101); //Validación que devuelva el mismo Id que se envió
        }

        [Fact(DisplayName = "[CustomerLogic] Update")]
        public void Update_Customer_Test()
        {
            var customer = new Customer()
            {
                Id = 1,
                City = "Lima",
                Country = "Peru",
                FirstName = "Pablo",
                LastName = "Neruda",
                Phone = "999999333"
            };
            var result = _customerLogic.Update(customer);
            var currentCustomer = _customerLogic.GetById(1);
            currentCustomer.Should().NotBeNull();
            currentCustomer.Id.Should().Be(customer.Id);
            currentCustomer.City.Should().Be(customer.City);
            currentCustomer.Country.Should().Be(customer.Country);
            currentCustomer.FirstName.Should().Be(customer.FirstName);
            currentCustomer.LastName.Should().Be(customer.LastName);
            currentCustomer.Phone.Should().Be(customer.Phone);
            result.Should().BeTrue(); //Validación que devuelva true
        }

    }
}
