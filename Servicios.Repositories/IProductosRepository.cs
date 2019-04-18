using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Repositories
{
    public interface IProductosRepository : IRepository<Inv_Productos>
    {
        IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm);
    }
}
