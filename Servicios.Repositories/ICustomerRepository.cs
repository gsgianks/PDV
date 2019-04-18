using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPageList(int page, int rows);
    }
}
