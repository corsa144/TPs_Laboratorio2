namespace VentasForm
{
    partial class FormProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gBCalidad = new System.Windows.Forms.GroupBox();
            this.rBTaller = new System.Windows.Forms.RadioButton();
            this.rBStock = new System.Windows.Forms.RadioButton();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbSistemaComputadora = new System.Windows.Forms.ComboBox();
            this.cmbSistemaCelular = new System.Windows.Forms.ComboBox();
            this.cmbTipoComputadora = new System.Windows.Forms.ComboBox();
            this.gBCalidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(34, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(34, 113);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(177, 20);
            this.txtPrecio.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(106, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre del producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Costo del producto";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(34, 403);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(177, 74);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(34, 188);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(177, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(31, 162);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Text = "Codigo";
            // 
            // gBCalidad
            // 
            this.gBCalidad.Controls.Add(this.rBTaller);
            this.gBCalidad.Controls.Add(this.rBStock);
            this.gBCalidad.Location = new System.Drawing.Point(34, 256);
            this.gBCalidad.Name = "gBCalidad";
            this.gBCalidad.Size = new System.Drawing.Size(177, 109);
            this.gBCalidad.TabIndex = 10;
            this.gBCalidad.TabStop = false;
            this.gBCalidad.Text = "Pasó control de calidad";
            // 
            // rBTaller
            // 
            this.rBTaller.AutoSize = true;
            this.rBTaller.Location = new System.Drawing.Point(6, 66);
            this.rBTaller.Name = "rBTaller";
            this.rBTaller.Size = new System.Drawing.Size(85, 17);
            this.rBTaller.TabIndex = 1;
            this.rBTaller.Text = "Pasa al taller";
            this.rBTaller.UseVisualStyleBackColor = true;
            // 
            // rBStock
            // 
            this.rBStock.AutoSize = true;
            this.rBStock.Checked = true;
            this.rBStock.Location = new System.Drawing.Point(7, 34);
            this.rBStock.Name = "rBStock";
            this.rBStock.Size = new System.Drawing.Size(89, 17);
            this.rBStock.TabIndex = 0;
            this.rBStock.TabStop = true;
            this.rBStock.Text = "Pasa al stock";
            this.rBStock.UseVisualStyleBackColor = true;
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(250, 38);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbProducto.TabIndex = 4;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // cmbSistemaComputadora
            // 
            this.cmbSistemaComputadora.FormattingEnabled = true;
            this.cmbSistemaComputadora.Location = new System.Drawing.Point(250, 112);
            this.cmbSistemaComputadora.Name = "cmbSistemaComputadora";
            this.cmbSistemaComputadora.Size = new System.Drawing.Size(121, 21);
            this.cmbSistemaComputadora.TabIndex = 5;
            // 
            // cmbSistemaCelular
            // 
            this.cmbSistemaCelular.FormattingEnabled = true;
            this.cmbSistemaCelular.Location = new System.Drawing.Point(250, 187);
            this.cmbSistemaCelular.Name = "cmbSistemaCelular";
            this.cmbSistemaCelular.Size = new System.Drawing.Size(121, 21);
            this.cmbSistemaCelular.TabIndex = 6;
            // 
            // cmbTipoComputadora
            // 
            this.cmbTipoComputadora.FormattingEnabled = true;
            this.cmbTipoComputadora.Location = new System.Drawing.Point(250, 256);
            this.cmbTipoComputadora.Name = "cmbTipoComputadora";
            this.cmbTipoComputadora.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoComputadora.TabIndex = 7;
            // 
            // FormProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(383, 505);
            this.Controls.Add(this.cmbTipoComputadora);
            this.Controls.Add(this.cmbSistemaCelular);
            this.Controls.Add(this.cmbSistemaComputadora);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.gBCalidad);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProducto";
            this.Load += new System.EventHandler(this.FormProducto_Load);
            this.gBCalidad.ResumeLayout(false);
            this.gBCalidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gBCalidad;
        private System.Windows.Forms.RadioButton rBTaller;
        private System.Windows.Forms.RadioButton rBStock;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbSistemaComputadora;
        private System.Windows.Forms.ComboBox cmbSistemaCelular;
        private System.Windows.Forms.ComboBox cmbTipoComputadora;
    }
}