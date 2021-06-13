namespace VentasForm
{
    partial class FabricaForm
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
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeerTexto
            // 
            this.btnLeerTexto.Location = new System.Drawing.Point(24, 193);
            this.btnLeerTexto.Name = "btnLeerTexto";
            this.btnLeerTexto.Size = new System.Drawing.Size(130, 45);
            this.btnLeerTexto.TabIndex = 4;
            this.btnLeerTexto.Text = "Leer";
            this.btnLeerTexto.UseVisualStyleBackColor = true;
            this.btnLeerTexto.Click += new System.EventHandler(this.btnLeerTexto_Click);
            // 
            // btnGuardarTexto
            // 
            this.btnGuardarTexto.Location = new System.Drawing.Point(177, 193);
            this.btnGuardarTexto.Name = "btnGuardarTexto";
            this.btnGuardarTexto.Size = new System.Drawing.Size(134, 45);
            this.btnGuardarTexto.TabIndex = 11;
            this.btnGuardarTexto.Text = "Guardar";
            this.btnGuardarTexto.UseVisualStyleBackColor = true;
            this.btnGuardarTexto.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(328, 193);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(130, 45);
            this.btnAgregarProducto.TabIndex = 12;
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
            this.nudCantidad.Location = new System.Drawing.Point(177, 95);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 15;
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
            this.rtbMostrar.TabIndex = 16;
            this.rtbMostrar.Text = "";
            // 
            // FabricaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 489);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnGuardarTexto);
            this.Controls.Add(this.btnLeerTexto);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FabricaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabrica";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
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
    }
}

