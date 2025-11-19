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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Regresar = new System.Windows.Forms.Button();
            this.button_Imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.Location = new System.Drawing.Point(338, 127);
            this.textBox_Documento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(238, 22);
            this.textBox_Documento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periodo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(286, 330);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1104, 321);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_Regresar
            // 
            this.button_Regresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Regresar.BackgroundImage")));
            this.button_Regresar.Location = new System.Drawing.Point(251, 667);
            this.button_Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Regresar.Name = "button_Regresar";
            this.button_Regresar.Size = new System.Drawing.Size(133, 41);
            this.button_Regresar.TabIndex = 3;
            this.button_Regresar.Text = "Regresar";
            this.button_Regresar.UseVisualStyleBackColor = true;
            this.button_Regresar.Click += new System.EventHandler(this.button_Regresar_Click);
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.Location = new System.Drawing.Point(1238, 707);
            this.button_Imprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(132, 41);
            this.button_Imprimir.TabIndex = 4;
            this.button_Imprimir.Text = "Imprrmir";
            this.button_Imprimir.UseVisualStyleBackColor = true;
            this.button_Imprimir.Click += new System.EventHandler(this.button_Imprimir_Click_1);
            // 
            // Deprendible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1429, 792);
            this.Controls.Add(this.button_Imprimir);
            this.Controls.Add(this.button_Regresar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Regresar;
        private System.Windows.Forms.Button button_Imprimir;
    }
}