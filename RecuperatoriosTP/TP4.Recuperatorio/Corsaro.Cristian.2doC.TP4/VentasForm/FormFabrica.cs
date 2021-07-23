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
using System.Threading;

namespace FabricaForm
{
    public delegate void DelegadoClickGuardar();
    public partial class FormFabrica : Form
    {
        public event DelegadoClickGuardar EventoClickGuardar;
        Fabrica fabrica;
        //Celular celular;
        //Computadora computadora;
        List<Thread> hilos;
        public FormFabrica()
        {
            InitializeComponent();
            fabrica = Fabrica.GetFabrica((UInt32)this.nudCantidad.Value);
            hilos = new List<Thread>();
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
                fabrica.Productos.Clear();//para que se guarde una sola vez limpio la lista de productos
                fabrica = fabrica.LeerTexto();
                fabrica = fabrica.LeerXml();
                mostrarProductos();
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbGuardar.Items.Add("Computadoras");
            this.cmbGuardar.Items.Add("Celulares");
            this.cmbGuardar.Items.Add("Todo");
            this.cmbGuardar.SelectedValue = "Computadoras";
            this.cmbGuardar.SelectedText = "Computadoras";
            this.cmbGuardar.SelectedIndex = 0;
            //this.EventoClickGuardar += this.GuardarTexto;
            //this.Cargar_ComboBox();
            //this.cmbProductos.SelectedItem = "Computadora";
        }
        /// <summary>
        /// Guarda en archivo de texto, en xml y base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.EventoClickGuardar.Invoke();
        }

        private void GuardarXml()
        {
            if (!object.ReferenceEquals(fabrica, null))
            {
                try
                {
                    if (fabrica.GuardarXml())
                    {
                        MessageBox.Show("Se guardaron los celulares");
                    }
                    else
                    {
                        MessageBox.Show("No se guardaron los celulares");
                    }
                }
                catch (ArchivosException)
                {
                    MessageBox.Show("No se puede guardar.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Debe cargar la fabrica");
            }
        }

        private void GuardarTexto()
        {
            Thread hilo = new Thread(fabrica.Guardar);
            hilos.Add(hilo);
            if (!object.ReferenceEquals(fabrica, null))
            {
                try
                {
                    hilo.Start();
                    MessageBox.Show("Se guardaron las computadoras!");
                }
                catch (ArchivosException)
                {
                    MessageBox.Show("No se puede guardar.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
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
            mostrarProductos();
            //this.Cargar_ComboBox();
        }

        public void mostrarProductos()
        {
            this.rtbMostrar.Clear();
            this.rtbMostrar.Text = fabrica.MostrarProductos();
        }
        
        /// <summary>
        /// Lee de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerSQL_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            fabrica.Productos = sql.LeerSQL();
            this.mostrarProductos();
        }
        /// <summary>
        /// Aborto todos los hilos antes de cerrar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread t in this.hilos)
            {
                if (!object.ReferenceEquals(t, null) && t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        private void cmbGuardar_SelectedValueChanged(object sender, EventArgs e)
        {
            this.EventoClickGuardar -= this.GuardarXml;
            this.EventoClickGuardar -= this.GuardarTexto;
            if (this.cmbGuardar.SelectedIndex == 0)
            {
                this.EventoClickGuardar += this.GuardarTexto;
            }else if(this.cmbGuardar.SelectedIndex == 1)
            {
                this.EventoClickGuardar += this.GuardarXml;
            }
            else
            {
                this.EventoClickGuardar += this.GuardarXml;
                this.EventoClickGuardar += this.GuardarTexto;
            }
        }

        private void btnGuardarSQL_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            if (!ReferenceEquals(fabrica.Productos, null) && sql.GuardarSQL(fabrica.Productos))
            {
                MessageBox.Show("Se guardó en base de datos!");
            }
            else
            {
                MessageBox.Show("No se guardó en la base de datos!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            RepararYDespacharForm formulario = new RepararYDespacharForm(this.fabrica, true,this);
            formulario.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            RepararYDespacharForm formulario = new RepararYDespacharForm(this.fabrica, false,this);
            formulario.Show();
        }
    }
}
