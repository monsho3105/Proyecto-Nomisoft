namespace Proyecto_Nomisoft
{
    partial class Liquidar_Nomina
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
            this.textBox_Identificacion = new System.Windows.Forms.TextBox();
            this.buttonRegresar = new System.Windows.Forms.Button();
            this.Identificacion = new System.Windows.Forms.Label();
            this.button_Liquidar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Identificacion
            // 
            this.textBox_Identificacion.Location = new System.Drawing.Point(270, 67);
            this.textBox_Identificacion.Name = "textBox_Identificacion";
            this.textBox_Identificacion.Size = new System.Drawing.Size(229, 26);
            this.textBox_Identificacion.TabIndex = 0;
            // 
            // buttonRegresar
            // 
            this.buttonRegresar.Location = new System.Drawing.Point(97, 617);
            this.buttonRegresar.Name = "buttonRegresar";
            this.buttonRegresar.Size = new System.Drawing.Size(169, 66);
            this.buttonRegresar.TabIndex = 1;
            this.buttonRegresar.Text = "Regresar";
            this.buttonRegresar.UseVisualStyleBackColor = true;
            this.buttonRegresar.Click += new System.EventHandler(this.buttonRegresar_Click);
            // 
            // Identificacion
            // 
            this.Identificacion.AutoSize = true;
            this.Identificacion.Location = new System.Drawing.Point(113, 67);
            this.Identificacion.Name = "Identificacion";
            this.Identificacion.Size = new System.Drawing.Size(103, 20);
            this.Identificacion.TabIndex = 2;
            this.Identificacion.Text = "Identificacion";
            // 
            // button_Liquidar
            // 
            this.button_Liquidar.Location = new System.Drawing.Point(958, 617);
            this.button_Liquidar.Name = "button_Liquidar";
            this.button_Liquidar.Size = new System.Drawing.Size(169, 66);
            this.button_Liquidar.TabIndex = 3;
            this.button_Liquidar.Text = "Liquidar";
            this.button_Liquidar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1235, 398);
            this.dataGridView1.TabIndex = 4;
            // 
            // Liquidar_Nomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 742);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Liquidar);
            this.Controls.Add(this.Identificacion);
            this.Controls.Add(this.buttonRegresar);
            this.Controls.Add(this.textBox_Identificacion);
            this.Name = "Liquidar_Nomina";
            this.Text = "Liquidar_Nomina";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Identificacion;
        private System.Windows.Forms.Button buttonRegresar;
        private System.Windows.Forms.Label Identificacion;
        private System.Windows.Forms.Button button_Liquidar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}