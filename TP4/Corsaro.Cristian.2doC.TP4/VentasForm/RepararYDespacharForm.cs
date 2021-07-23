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

namespace FabricaForm
{
    public partial class RepararYDespacharForm : Form
    {
        Fabrica fabrica;
        bool estado;
        FormFabrica formulario;
        public RepararYDespacharForm(Fabrica fabrica, bool estado, FormFabrica formularioPricipal)
        {
            InitializeComponent();
            this.fabrica = fabrica;
            this.estado = estado;
            this.formulario = formularioPricipal;
        }
        /// <summary>
        /// Repara o despacha el producto segun corresponda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepararDespachar_Click(object sender, EventArgs e)
        {
            if (estado)
            {
                if (!ReferenceEquals(fabrica.Productos, null))
                {
                    foreach(Producto item in fabrica.Productos)
                    {
                        if(item.Codigo == this.nudRepararDespachar.Value)
                        {
                            SQL sql = new SQL();
                            if (sql.ModificarSQL(item.Codigo))
                            {
                                item.PasoControlCalidad = true;
                                MessageBox.Show("Se reparó el producto");
                            }
                            else
                            {
                                MessageBox.Show("No se pudo modificar la base de datos");
                            }
                        }
                    }
                }
            }
            else
            {
                if(!ReferenceEquals(fabrica.Productos, null))
                {
                    for(int i = 0; i < fabrica.Productos.Count; i++)
                    {
                        if(fabrica.Productos[i].Codigo == this.nudRepararDespachar.Value)
                        {
                            SQL sql = new SQL();
                            if (sql.BorrarSQL(fabrica.Productos[i].Codigo))
                            {
                                fabrica.Productos.RemoveAt(i);
                                MessageBox.Show("Se despachó el producto");
                            }
                            else
                            {
                                MessageBox.Show("No se pudo despachar el producto");
                            }
                        }
                    }
                }
            }
            this.formulario.mostrarProductos();
            this.Close();
        }
    }
}
