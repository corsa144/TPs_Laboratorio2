﻿using System;
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

namespace FabricaForm
{
    public partial class FormFabrica : Form
    {
        Fabrica fabrica;
        public FormFabrica()
        {
            InitializeComponent();
            fabrica = Fabrica.GetFabrica((UInt32)this.nudCantidad.Value);
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
                fabrica = fabrica.LeerTexto();//leo las computadoras
                fabrica = fabrica.LeerXml();//leo los celulares
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
            //this.Cargar_ComboBox();
            //this.cmbProductos.SelectedItem = "Computadora";
        }
        /// <summary>
        /// Guarda en archivo de texto y en xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!object.ReferenceEquals(fabrica,null))
            {
                try
                {
                    fabrica.Guardar();//Guardo en archivo de texto las computadoras
                    if (fabrica.GuardarXml())//guardo en xml los celulares
                    {
                        MessageBox.Show("Se guardaron los celulares");
                    }
                    else
                    {
                        MessageBox.Show("No se guardaron los celulares");
                    }
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

        private void mostrarProductos()
        {
            this.rtbMostrar.Clear();
            this.rtbMostrar.Text = fabrica.MostrarProductos();
        }
    }
}
