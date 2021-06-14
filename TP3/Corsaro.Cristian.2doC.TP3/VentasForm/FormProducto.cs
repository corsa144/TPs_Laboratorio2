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
        Celular celular;
        Computadora computadora;
        Fabrica fabrica;
        public FormProducto(Fabrica fabrica)
        {
            this.fabrica = fabrica;
            InitializeComponent();
        }
        /// <summary>
        /// agrega un producto a la fabrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbProducto.SelectedIndex == 0)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(this.txtNombre.Text) && this.txtNombre.Text.Length > 2)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un nombre valido!");
                        }
                        double precio;
                        if (!string.IsNullOrEmpty(this.txtPrecio.Text) && double.TryParse(this.txtPrecio.Text, out precio))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un precio valido!");
                        }
                        int codigo;
                        if (!string.IsNullOrEmpty(this.txtCodigo.Text))
                        {
                            if (!int.TryParse(this.txtCodigo.Text, out codigo))
                            {
                                MessageBox.Show("Ingrese un codigo valido!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un codigo!");
                        }
                    }
                    catch (NombreProductoExeption ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Reintente. {ex.InnerException.Message}");
                    }
                    // Lectura
                    Computadora.ESistemaOperativo sistemaOperativo;
                    Enum.TryParse<Computadora.ESistemaOperativo>(cmbSistemaComputadora.SelectedValue.ToString(), out sistemaOperativo);
                    // Lectura
                    Computadora.TipoComputadora tipo;
                    Enum.TryParse<Computadora.TipoComputadora>(cmbTipoComputadora.SelectedValue.ToString(), out tipo);
                    computadora = new Computadora(int.Parse(this.txtCodigo.Text), this.txtNombre.Text, int.Parse(this.txtPrecio.Text), tipo,
                        sistemaOperativo, this.rBStock.Checked);
                    this.fabrica.Productos.Add(computadora);
                    MessageBox.Show("Se agrego una computadora!");
                }
                else
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(this.txtNombre.Text) && this.txtNombre.Text.Length > 2)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un nombre valido!");
                        }
                        double precio;
                        if (!string.IsNullOrEmpty(this.txtPrecio.Text) && double.TryParse(this.txtPrecio.Text, out precio))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un precio valido!");
                        }
                        int codigo;
                        if (!string.IsNullOrEmpty(this.txtCodigo.Text))
                        {
                            if (!int.TryParse(this.txtCodigo.Text, out codigo))
                            {
                                MessageBox.Show("Ingrese un codigo valido!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un codigo!");
                        }
                    }
                    catch (NombreProductoExeption ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Reintente. {ex.InnerException.Message}");
                    }
                    // Lectura
                    Celular.SistemaOperativo cSistemas;
                    Enum.TryParse<Celular.SistemaOperativo>(this.cmbSistemaCelular.SelectedValue.ToString(), out cSistemas);

                    celular = new Celular(int.Parse(this.txtCodigo.Text), this.txtNombre.Text, int.Parse(this.txtPrecio.Text),
                        cSistemas, this.rBStock.Checked);
                    this.fabrica.Productos.Add(celular);
                    MessageBox.Show("Se agrego un Celular!");
                }
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show($"Reintente. {ex.InnerException.Message}");
            }

        }
        /// <summary>
        /// carga valores por defecto en los combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProducto_Load(object sender, EventArgs e)
        {
            this.cmbProducto.Items.Add("Computadora");
            this.cmbProducto.Items.Add("Celular");
            this.cmbProducto.SelectedValue = "Computadora";
            this.cmbProducto.SelectedText = "Computadora";
            this.cmbProducto.SelectedIndex = 0;
            this.cmbSistemaCelular.Enabled = false;
            // Carga
            this.cmbSistemaCelular.DataSource = Enum.GetValues(typeof(Celular.SistemaOperativo));
           
            // Carga
            this.cmbSistemaComputadora.DataSource = Enum.GetValues(typeof(Computadora.ESistemaOperativo));
         
            // Carga
            this.cmbTipoComputadora.DataSource = Enum.GetValues(typeof(Computadora.TipoComputadora));
            
            /*this.cmbSistemaComputadora.Items.Add("Sin sistema operativo");
            this.cmbSistemaComputadora.Items.Add("Windows");
            this.cmbSistemaComputadora.Items.Add("Linux");
            this.cmbSistemaComputadora.Items.Add("OSX");
            this.cmbSistemaComputadora.SelectedValue = "Sin sistema operativo";
            this.cmbSistemaComputadora.SelectedText = "Sin sistema operativo";
            this.cmbSistemaCelular.Items.Add("Andorid");
            this.cmbSistemaCelular.Items.Add("IOS");
            this.cmbSistemaCelular.SelectedValue = "Android";
            this.cmbSistemaCelular.SelectedText = "Android";
            this.cmbTipoComputadora.Items.Add("Escritorio");
            this.cmbTipoComputadora.Items.Add("Notebook");
            this.cmbTipoComputadora.SelectedValue = "Notebook";
            this.cmbTipoComputadora.SelectedText = "Notebook";
            */
        }
        /// <summary>
        /// habilita o deshabilita controles del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbProducto.SelectedIndex == 0)
            {
                this.cmbSistemaCelular.Enabled = false;
                this.cmbSistemaComputadora.Enabled = true;
                this.cmbTipoComputadora.Enabled = true;
            }
            else
            {
                this.cmbSistemaCelular.Enabled = true;
                this.cmbSistemaComputadora.Enabled = false;
                this.cmbTipoComputadora.Enabled = false;
            }
        }
    }
}
