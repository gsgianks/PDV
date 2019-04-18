using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface ICustomerLogic
    {
        IEnumerable<CustomerList> CustomerPageList(int page, int rows);
        Customer GetById(int id);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
