using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.Repositories
{
    public interface ISupplierRepository: IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPageList(int page, int rows, string seachTerm);
    }
}
