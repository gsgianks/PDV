using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.BusinessLogic.Implementations
{
    public class ProductosLogic: IProductosLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductosLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Inv_Productos producto) => _unitOfWork.Producto.Delete(producto);

        public Inv_Productos GetById(int id) => _unitOfWork.Producto.GetById(id);

        public int Insert(Inv_Productos producto) => _unitOfWork.Producto.Insert(producto);

        public IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm) => _unitOfWork.Producto.ProductosListaPaginada(page, rows, seachTerm);

        public bool Update(Inv_Productos producto) => _unitOfWork.Producto.Update(producto);
    }
}
