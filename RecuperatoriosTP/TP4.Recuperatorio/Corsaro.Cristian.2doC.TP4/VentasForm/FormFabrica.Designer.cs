namespace FabricaForm
{
    partial class FormFabrica
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLeerTexto = new System.Windows.Forms.Button();
            this.btnGuardarTexto = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.btnLeerSQL = new System.Windows.Forms.Button();
            this.gBGuardar = new System.Windows.Forms.GroupBox();
            this.cmbGuardar = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGuardarSQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.gBGuardar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLeerTexto
            // 
            this.btnLeerTexto.Location = new System.Drawing.Point(24, 219);
            this.btnLeerTexto.Name = "btnLeerTexto";
            this.btnLeerTexto.Size = new System.Drawing.Size(134, 45);
            this.btnLeerTexto.TabIndex = 2;
            this.btnLeerTexto.Text = "Leer";
            this.btnLeerTexto.UseVisualStyleBackColor = true;
            this.btnLeerTexto.Click += new System.EventHandler(this.btnLeerTexto_Click);
            // 
            // btnGuardarTexto
            // 
            this.btnGuardarTexto.Location = new System.Drawing.Point(13, 57);
            this.btnGuardarTexto.Name = "btnGuardarTexto";
            this.btnGuardarTexto.Size = new System.Drawing.Size(134, 45);
            this.btnGuardarTexto.TabIndex = 3;
            this.btnGuardarTexto.Text = "Guardar";
            this.btnGuardarTexto.UseVisualStyleBackColor = true;
            this.btnGuardarTexto.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(328, 219);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(130, 45);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "Agregar producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(174, 36);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(119, 13);
            this.lblCantidad.TabIndex = 14;
            this.lblCantidad.Text = "Espacio para productos";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(177, 74);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 1;
            this.nudCantidad.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(12, 270);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(454, 207);
            this.rtbMostrar.TabIndex = 5;
            this.rtbMostrar.Text = "";
            // 
            // btnLeerSQL
            // 
            this.btnLeerSQL.Location = new System.Drawing.Point(24, 164);
            this.btnLeerSQL.Name = "btnLeerSQL";
            this.btnLeerSQL.Size = new System.Drawing.Size(134, 43);
            this.btnLeerSQL.TabIndex = 16;
            this.btnLeerSQL.Text = "Leer en base de datos";
            this.btnLeerSQL.UseVisualStyleBackColor = true;
            this.btnLeerSQL.Click += new System.EventHandler(this.btnLeerSQL_Click);
            // 
            // gBGuardar
            // 
            this.gBGuardar.Controls.Add(this.cmbGuardar);
            this.gBGuardar.Controls.Add(this.btnGuardarTexto);
            this.gBGuardar.Location = new System.Drawing.Point(164, 156);
            this.gBGuardar.Name = "gBGuardar";
            this.gBGuardar.Size = new System.Drawing.Size(158, 108);
            this.gBGuardar.TabIndex = 17;
            this.gBGuardar.TabStop = false;
            this.gBGuardar.Text = "Guardar:";
            // 
            // cmbGuardar
            // 
            this.cmbGuardar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuardar.FormattingEnabled = true;
            this.cmbGuardar.Location = new System.Drawing.Point(13, 30);
            this.cmbGuardar.Name = "cmbGuardar";
            this.cmbGuardar.Size = new System.Drawing.Size(134, 21);
            this.cmbGuardar.TabIndex = 18;
            this.cmbGuardar.SelectedValueChanged += new System.EventHandler(this.cmbGuardar_SelectedValueChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(24, 113);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(134, 45);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "Reparar Producto";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(328, 113);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(130, 45);
            this.btnBorrar.TabIndex = 19;
            this.btnBorrar.Text = "Despachar Producto";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGuardarSQL
            // 
            this.btnGuardarSQL.Location = new System.Drawing.Point(328, 164);
            this.btnGuardarSQL.Name = "btnGuardarSQL";
            this.btnGuardarSQL.Size = new System.Drawing.Size(130, 43);
            this.btnGuardarSQL.TabIndex = 20;
            this.btnGuardarSQL.Text = "Guardar en base de datos";
            this.btnGuardarSQL.UseVisualStyleBackColor = true;
            this.btnGuardarSQL.Click += new System.EventHandler(this.btnGuardarSQL_Click);
            // 
            // FormFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 489);
            this.Controls.Add(this.btnGuardarSQL);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.gBGuardar);
            this.Controls.Add(this.btnLeerSQL);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnLeerTexto);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFabrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabrica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFabrica_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.gBGuardar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLeerTexto;
        private System.Windows.Forms.Button btnGuardarTexto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.Button btnLeerSQL;
        private System.Windows.Forms.GroupBox gBGuardar;
        private System.Windows.Forms.ComboBox cmbGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGuardarSQL;
    }
}

