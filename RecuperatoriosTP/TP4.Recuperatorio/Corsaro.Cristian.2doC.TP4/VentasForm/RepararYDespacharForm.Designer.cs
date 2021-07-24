namespace FabricaForm
{
    partial class RepararYDespacharForm
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
            this.nudRepararDespachar = new System.Windows.Forms.NumericUpDown();
            this.btnRepararDespachar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepararDespachar)).BeginInit();
            this.SuspendLayout();
            // 
            // nudRepararDespachar
            // 
            this.nudRepararDespachar.Location = new System.Drawing.Point(72, 64);
            this.nudRepararDespachar.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudRepararDespachar.Name = "nudRepararDespachar";
            this.nudRepararDespachar.Size = new System.Drawing.Size(120, 20);
            this.nudRepararDespachar.TabIndex = 0;
            // 
            // btnRepararDespachar
            // 
            this.btnRepararDespachar.Location = new System.Drawing.Point(72, 158);
            this.btnRepararDespachar.Name = "btnRepararDespachar";
            this.btnRepararDespachar.Size = new System.Drawing.Size(120, 51);
            this.btnRepararDespachar.TabIndex = 1;
            this.btnRepararDespachar.Text = "Reparar o Despachar";
            this.btnRepararDespachar.UseVisualStyleBackColor = true;
            this.btnRepararDespachar.Click += new System.EventHandler(this.btnRepararDespachar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo del producto:";
            // 
            // RepararYDespacharForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(254, 289);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRepararDespachar);
            this.Controls.Add(this.nudRepararDespachar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepararYDespacharForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RepararYDespacharForm";
            this.Load += new System.EventHandler(this.RepararYDespacharForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRepararDespachar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudRepararDespachar;
        private System.Windows.Forms.Button btnRepararDespachar;
        private System.Windows.Forms.Label label1;
    }
}