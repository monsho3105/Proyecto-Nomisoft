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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.textBox_Documento.Location = new System.Drawing.Point(315, 115);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(267, 26);
            this.textBox_Documento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1242, 401);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_Regresar
            // 
            this.button_Regresar.Location = new System.Drawing.Point(80, 665);
            this.button_Regresar.Name = "button_Regresar";
            this.button_Regresar.Size = new System.Drawing.Size(150, 51);
            this.button_Regresar.TabIndex = 3;
            this.button_Regresar.Text = "Regresar";
            this.button_Regresar.UseVisualStyleBackColor = true;
            this.button_Regresar.Click += new System.EventHandler(this.button_Regresar_Click_1);
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.Location = new System.Drawing.Point(894, 665);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(148, 51);
            this.button_Imprimir.TabIndex = 4;
            this.button_Imprimir.Text = "Imprrmir";
            this.button_Imprimir.UseVisualStyleBackColor = true;
            // 
            // Deprendible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 757);
            this.Controls.Add(this.button_Imprimir);
            this.Controls.Add(this.button_Regresar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Documento);
            this.Name = "Deprendible";
            this.Text = "Deprendible";
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