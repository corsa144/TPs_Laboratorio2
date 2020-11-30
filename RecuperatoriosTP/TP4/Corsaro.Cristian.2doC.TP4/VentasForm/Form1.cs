using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace VentasForm
{
    public partial class VentaForm : Form
    {
        Producto producto;
        Venta venta;
        public VentaForm()
        {
            InitializeComponent();
            producto = new Producto();
            venta = new Venta();
        }
        /// <summary>
        /// Carga los datos al producto desde el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            if(this.txtNombreDelProducto.Text.Length > 2)
            {
                producto.Nombre = this.txtNombreDelProducto.Text;
                venta.NombreProducto = this.txtNombreDelProducto.Text;
            }
            else
            {
                throw new NombreProductoExeption("Error.Nombre debe tener más de dos caracteres!");
            }
            double resultado;
            if(double.TryParse(this.txtPrecio.Text,out resultado))
            {
                if(resultado > 0)
                {
                    producto.Precio = resultado;
                    venta.PrecioProducto = resultado;
                }
                else
                {
                    throw new NombreProductoExeption("Error.Precio debe ser mayor a 0");
                }
            }
            else
            {
                throw new NombreProductoExeption("Error.Precio debe ser mayor a 0");
            }
            if (this.txtNombreCliente.Text.Length > 2)
            {
                venta.NombreCliente = this.txtNombreDelProducto.Text;
            }
            else
            {
                throw new NombreProductoExeption("Error.Nombre debe tener más de dos caracteres!");
            }
            int resultadoCodigo;
            if (int.TryParse(this.txtCodigoVenta.Text, out resultadoCodigo))
            {
                if (resultadoCodigo > 0 && this.txtCodigoVenta.Text.Length > 2)
                {
                    venta.Codigo = resultadoCodigo;
                }
                else
                {
                    throw new NombreProductoExeption("Error.Codigo debe ser mayor a 0 y tener mas de dos numeros");
                }
            }
            else
            {
                throw new NombreProductoExeption("Error.Codigo debe ser mayor a 0 y tener mas de dos numeros");
            }
            venta.Vender();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.txtPrecio.Text.Length > 2 && this.txtCodigoVenta.Text.Length > 2)
            {
                try
                {
                    venta.Vender();
                }
                catch (ArchivosException)
                {
                    MessageBox.Show("No se puede guardar.");
                }
            }
            else
            {
                MessageBox.Show("Debe cargar precio y codigo");
            }

        }
    }
}
