using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IProductosLogic
    {
        IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm);
        Inv_Productos GetById(int id);
        int Insert(Inv_Productos producto);
        bool Update(Inv_Productos producto);
        bool Delete(Inv_Productos producto);
    }
}
