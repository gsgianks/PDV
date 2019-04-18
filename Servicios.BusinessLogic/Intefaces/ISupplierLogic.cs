using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface ISupplierLogic
    {
        IEnumerable<Supplier> SupplierPageList(int page, int rows, string seachTerm);
        Supplier GetById(int id);
        int Insert(Supplier supplier);
        bool Update(Supplier supplier);
        bool Delete(Supplier supplier);
    }
}
