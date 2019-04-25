using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.UI.Shared;
using ServiciosCore.Entidades;

namespace POS.UI.Productos
{
    /// <summary>
    /// Interaction logic for frmProducto.xaml
    /// </summary>
    public partial class FrmProducto : Window
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //obtenemos los datos del form
            var producto = new Producto
            {
                IdProveedor = 1,//TODO = pendiente combobox,
                IdCategoria = 1,//TODO = pendiente combobox,
                Nombre = txtNombre.Text,
                CodigoBarra = txtCodBarra.Text,
                Stock = Convert.ToInt16(txtStock.Text),
                PrecioCosto = Convert.ToDecimal(txtPrecioCosto.Text),
                Existencia = Convert.ToInt16(txtExistencias.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                Utilidad = Convert.ToDecimal(txtUtilidad.Text),
                Impuesto = Convert.ToDecimal(txtImpuesto.Text),
                Descuento = Convert.ToDecimal(txtDescuento.Text),
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "des"//TODO = pendiente tomar de login
            };

            //enviamos a guardar el producto
            var respuesta = ApiClienteFactory.Instance.GuardarProducto(producto);
        }

    }
}
