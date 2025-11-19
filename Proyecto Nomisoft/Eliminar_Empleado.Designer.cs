namespace Proyecto_Nomisoft
{
    partial class Eliminar_Empleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Identificacion = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificacion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_Identificacion
            // 
            this.textBox_Identificacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_Identificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Identificacion.Font = new System.Drawing.Font("Sans Serif Collection", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Identificacion.Location = new System.Drawing.Point(348, 93);
            this.textBox_Identificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Identificacion.Name = "textBox_Identificacion";
            this.textBox_Identificacion.Size = new System.Drawing.Size(260, 48);
            this.textBox_Identificacion.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(103, 232);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1553, 538);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Eliminar.FlatAppearance.BorderSize = 0;
            this.button_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Eliminar.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Eliminar.ForeColor = System.Drawing.Color.White;
            this.button_Eliminar.Location = new System.Drawing.Point(797, 805);
            this.button_Eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(315, 54);
            this.button_Eliminar.TabIndex = 4;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = false;
            this.button_Eliminar.Click += new System.EventHandler(this.Button_Eliminar_Click_1);
            // 
            // Eliminar_Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1687, 898);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_Identificacion);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Eliminar_Empleado";
            this.Text = "Eliminar_Empleado";
            this.Load += new System.EventHandler(this.Eliminar_Empleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Identificacion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Eliminar;
    }
}