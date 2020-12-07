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
    public partial class FormProducto : Form
    {
        Producto producto;
        public FormProducto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            producto = new Producto();
            if(this.txtNombre.Text.Length > 2)
            {
                producto.Nombre = txtNombre.Text;
            }
            else
            {
                throw new NombreProductoExeption("Error! Debe igresar un nombre con mas de 2 caracteres");
            }
            double precio;
            if(double.TryParse(this.txtPrecio.Text,out precio))
            {
                producto.Precio = precio;
            }
            else
            {
                throw new NombreProductoExeption("Error! debe ingresar un precio valido!");
            }
            try
            {
                ConexionSQL sql = new ConexionSQL();
                sql.GuardarProducto(producto);
                MessageBox.Show("Se guardo correctamente!");

            }catch(Exception ex)
            {
                throw new ArchivosException("Error al conectar con la base de datos!", ex);
            }
            finally
            {
                this.Close();
            }

        }
    }
}
