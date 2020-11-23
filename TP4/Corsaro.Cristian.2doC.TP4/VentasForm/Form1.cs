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
            producto.Tipo = (Tipo)this.cbTipo.SelectedItem;
            venta.Concepto = (Venta.ConceptoDePago)this.cbConcepto.SelectedItem;
            venta.Vender();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbTipo.DataSource = Enum.GetValues(typeof(Tipo));
            this.cbTipo.SelectedItem = Tipo.celular;
            this.cbConcepto.DataSource = Enum.GetValues(typeof(Venta.ConceptoDePago));
            this.cbConcepto.SelectedItem = Venta.ConceptoDePago.venta;
        }
    }
}
