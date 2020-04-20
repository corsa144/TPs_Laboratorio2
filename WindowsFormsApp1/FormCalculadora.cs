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

namespace WindowsFormsApp1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }
        
        public void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        public static double Operar(string numeroUno, string numeroDos, string operador)
        {
            return Calculadora.Operar(new Numero(numeroUno), new Numero(numeroDos), operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if(!(this.lblResultado.Text is null || this.lblResultado.Text == ""))
            {
                this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
            }
            
        }

        private void btnConvetirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (!(this.lblResultado.Text is null || this.lblResultado.Text == ""))
            {
                this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
            }
        }
        
    }
}
