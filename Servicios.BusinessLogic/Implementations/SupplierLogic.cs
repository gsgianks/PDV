using System.Collections.Generic;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Supplier supplier) => _unitOfWork.Supplier.Delete(supplier);

        public Supplier GetById(int id) => _unitOfWork.Supplier.GetById(id);

        public int Insert(Supplier supplier) => _unitOfWork.Supplier.Insert(supplier);

        public IEnumerable<Supplier> SupplierPageList(int page, int rows, string seachTerm) => _unitOfWork.Supplier.SupplierPageList(page, rows, seachTerm);

        public bool Update(Supplier supplier) => _unitOfWork.Supplier.Update(supplier);
    }
}
