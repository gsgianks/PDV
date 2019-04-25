using ServiciosCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore.Utilidades.Api
{
    public partial class ApiCliente
    {
        /// <summary>
        /// Consume el método Productos/Agregar del web api
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Message<Producto>> GuardarProducto(Producto producto)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Productos/Agregar"));
            return await PostAsync<Producto>(requestUrl, producto);
        }
    }
}
