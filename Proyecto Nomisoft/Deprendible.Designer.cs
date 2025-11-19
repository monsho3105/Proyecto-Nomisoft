namespace Proyecto_Nomisoft
{
    partial class Deprendible
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

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deprendible));
            this.textBox_Documento = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Regresar = new System.Windows.Forms.Button();
            this.button_Imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Documento.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Documento.Location = new System.Drawing.Point(390, 201);
            this.textBox_Documento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Documento.Multiline = true;
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(447, 29);
            this.textBox_Documento.TabIndex = 0;
            this.textBox_Documento.TextChanged += new System.EventHandler(this.TextBox_Documento_TextChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(310, 285);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1448, 521);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_Regresar
            // 
            this.button_Regresar.BackColor = System.Drawing.Color.Transparent;
            this.button_Regresar.FlatAppearance.BorderSize = 0;
            this.button_Regresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Regresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Regresar.Location = new System.Drawing.Point(310, 810);
            this.button_Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Regresar.Name = "button_Regresar";
            this.button_Regresar.Size = new System.Drawing.Size(223, 54);
            this.button_Regresar.TabIndex = 3;
            this.button_Regresar.UseVisualStyleBackColor = false;
            this.button_Regresar.Click += new System.EventHandler(this.button_Regresar_Click);
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.BackColor = System.Drawing.Color.Transparent;
            this.button_Imprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Imprimir.FlatAppearance.BorderSize = 0;
            this.button_Imprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Imprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Imprimir.Location = new System.Drawing.Point(1511, 810);
            this.button_Imprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(255, 66);
            this.button_Imprimir.TabIndex = 4;
            this.button_Imprimir.UseVisualStyleBackColor = false;
            this.button_Imprimir.Click += new System.EventHandler(this.button_Imprimir_Click_1);
            // 
            // Deprendible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1924, 1008);
            this.Controls.Add(this.button_Imprimir);
            this.Controls.Add(this.button_Regresar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_Documento);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Deprendible";
            this.Text = "Deprendible";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Deprendible_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Regresar;
        private System.Windows.Forms.Button button_Imprimir;
    }
}