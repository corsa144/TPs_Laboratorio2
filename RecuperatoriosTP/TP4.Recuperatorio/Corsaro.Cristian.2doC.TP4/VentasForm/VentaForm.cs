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
        //Producto producto;
        Venta venta;
        public VentaForm()
        {
            InitializeComponent();
           // producto = new Producto();
        }
        /// <summary>
        /// Carga los datos al producto desde el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            venta = new Venta();
            if (!object.ReferenceEquals(this.cmbProductos.SelectedItem ,null))
            {
                venta.Productos.Add((Producto)this.cmbProductos.SelectedItem);
            }
            else
            {
                venta = null;
                throw new NombreProductoExeption("Error.Debe seleccionar un producto!");
            }

            if (this.txtNombreCliente.Text.Length > 2)
            {
                venta.NombreCliente = this.txtNombreCliente.Text;
            }
            else
            {
                venta = null;
                throw new NombreProductoExeption("Error.Nombre debe tener más de dos caracteres!");
            }

            try
            {
                venta.Vender();
                MessageBox.Show("Se concreto la venta!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cargar_ComboBox();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!object.ReferenceEquals(venta,null))
            {
                try
                {
                    venta.Vender();
                    MessageBox.Show("Se guardo la venta!");
                }
                catch (ArchivosException)
                {
                    MessageBox.Show("No se puede guardar.");
                }
            }
            else
            {
                MessageBox.Show("Debe cargar la venta");
            }

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormProducto formularioProducto = new FormProducto();
            formularioProducto.ShowDialog();
            this.Cargar_ComboBox();
        }

        public void Cargar_ComboBox()
        {
            ConexionSQL sql = new ConexionSQL();
            List<Producto> prod = sql.LeerProducto();
            this.cmbProductos.Items.Clear();
            foreach(Producto p in prod)
            {
                this.cmbProductos.Items.Add(p);
            }
            this.cmbProductos.DisplayMember = "Nombre";
        }
    }
}
