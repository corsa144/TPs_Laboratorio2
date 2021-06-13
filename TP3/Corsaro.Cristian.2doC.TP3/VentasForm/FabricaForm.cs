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
using Archivos;

namespace VentasForm
{
    public partial class FabricaForm : Form
    {
        Fabrica fabrica;
        public FabricaForm()
        {
            fabrica = Fabrica.GetFabrica();
            InitializeComponent();
        }
        /// <summary>
        /// Carga los datos al producto desde el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerTexto_Click(object sender, EventArgs e)
        {
            try
            {
                fabrica = fabrica.LeerTexto();
                fabrica = fabrica.LeerXml();
            }catch(ArchivosException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Cargar_ComboBox();
            //this.cmbProductos.SelectedItem = "Computadora";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!object.ReferenceEquals(fabrica,null))
            {
                try
                {
                    fabrica.Guardar();
                    if (fabrica.GuardarXml())
                    {
                        MessageBox.Show("Se guardo el stock");
                    }
                    else
                    {
                        MessageBox.Show("No se guardo el stock");
                    }
                    MessageBox.Show("Se guardo la fabrica!");
                }
                catch (ArchivosException)
                {
                    MessageBox.Show("No se puede guardar.");
                }
            }
            else
            {
                MessageBox.Show("Debe cargar la fabrica");
            }

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormProducto formularioProducto = new FormProducto(fabrica);
            formularioProducto.ShowDialog();
            this.rtbMostrar.Text = fabrica.MostrarProductos();
            //this.Cargar_ComboBox();
        }
    }
}
