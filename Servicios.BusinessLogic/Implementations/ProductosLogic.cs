using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.BusinessLogic.Implementations
{
    public class ProductosLogic : IProductosLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductosLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Inv_Productos producto) => _unitOfWork.Producto.Delete(producto);

        public Inv_Productos GetById(int id) => _unitOfWork.Producto.GetById(id);

        /// <summary>
        /// Inserta un producto en base de datos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public int Insert(Inv_Productos producto)
        {

            //validamos si existe el producto
            if (GetProductByBarCode(producto.CodigoBarra) == null)
            {
                //inserta producto
                return _unitOfWork.Producto.Insert(producto);
            }
            else
            {
                //producto ya existe
                return -99;
            }
        }

        public IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm) => _unitOfWork.Producto.ProductosListaPaginada(page, rows, seachTerm);

        public bool Update(Inv_Productos producto) => _unitOfWork.Producto.Update(producto);

        /// <summary>
        /// Obtiene un producto por código de barra
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public Inv_Productos GetProductByBarCode(string barCode)
        {
            return _unitOfWork.Producto.GetProductByBarCode(barCode);
        }
    }
}
