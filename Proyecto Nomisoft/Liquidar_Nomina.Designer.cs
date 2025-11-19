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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liquidar_Nomina));
            this.textBox_Identificacion = new System.Windows.Forms.TextBox();
            this.button_Liquidar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Identificacion
            // 
            this.textBox_Identificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.textBox_Identificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Identificacion.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Identificacion.ForeColor = System.Drawing.Color.White;
            this.textBox_Identificacion.Location = new System.Drawing.Point(276, 360);
            this.textBox_Identificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Identificacion.Multiline = true;
            this.textBox_Identificacion.Name = "textBox_Identificacion";
            this.textBox_Identificacion.Size = new System.Drawing.Size(408, 39);
            this.textBox_Identificacion.TabIndex = 0;
            // 
            // button_Liquidar
            // 
            this.button_Liquidar.BackColor = System.Drawing.Color.Transparent;
            this.button_Liquidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Liquidar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.button_Liquidar.FlatAppearance.BorderSize = 0;
            this.button_Liquidar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Liquidar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Liquidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Liquidar.Location = new System.Drawing.Point(1483, 866);
            this.button_Liquidar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Liquidar.Name = "button_Liquidar";
            this.button_Liquidar.Size = new System.Drawing.Size(199, 95);
            this.button_Liquidar.TabIndex = 3;
            this.button_Liquidar.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 465);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1622, 397);
            this.dataGridView1.TabIndex = 4;
            // 
            // Liquidar_Nomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1710, 1055);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Liquidar);
            this.Controls.Add(this.textBox_Identificacion);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Liquidar_Nomina";
            this.Text = "Liquidar_Nomina";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Liquidar_Nomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Identificacion;
        private System.Windows.Forms.Button button_Liquidar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}