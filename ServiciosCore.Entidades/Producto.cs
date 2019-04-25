using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore.Entidades
{
    public class Producto
    {
        public Int32 Id { get; set; }
        public Int16 IdProveedor { get; set; }
        public byte IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Impuesto { get; set; }
        public Int16 Stock { get; set; }
        public Int16 Existencia { get; set; }
        public decimal Descuento { get; set; }
        public string CodigoBarra { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
