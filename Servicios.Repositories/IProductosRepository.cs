using Servicios.Models;
using System.Collections.Generic;

namespace Servicios.Repositories
{
    public interface IProductosRepository : IRepository<Inv_Productos>
    {
        IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm);

        /// <summary>
        /// Obtiene un producto por código de barra
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        Inv_Productos GetProductByBarCode(string barCode);
    }
}
