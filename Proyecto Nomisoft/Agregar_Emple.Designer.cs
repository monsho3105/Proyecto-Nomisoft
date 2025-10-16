namespace Proyecto_Nomisoft
{
    partial class Agregar_Emple
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
            this.label_Nombre1 = new System.Windows.Forms.Label();
            this.txt_Nombre1 = new System.Windows.Forms.TextBox();
            this.txt_Nombre2 = new System.Windows.Forms.TextBox();
            this.label_Nombre2 = new System.Windows.Forms.Label();
            this.txt_Apellido2 = new System.Windows.Forms.TextBox();
            this.label_Apellido2 = new System.Windows.Forms.Label();
            this.txt_Apellido1 = new System.Windows.Forms.TextBox();
            this.label_Apellido1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Com_Box_Tipo_Doc = new System.Windows.Forms.ComboBox();
            this.txt_Numero_Doc = new System.Windows.Forms.TextBox();
            this.label_Numero_Documento = new System.Windows.Forms.Label();
            this.label_Fecha_Nacimiento = new System.Windows.Forms.Label();
            this.txt_Fecha_Nacimiento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Nombre1
            // 
            this.label_Nombre1.AutoSize = true;
            this.label_Nombre1.Location = new System.Drawing.Point(42, 47);
            this.label_Nombre1.Name = "label_Nombre1";
            this.label_Nombre1.Size = new System.Drawing.Size(124, 20);
            this.label_Nombre1.TabIndex = 0;
            this.label_Nombre1.Text = "Primer Nombre *";
            // 
            // txt_Nombre1
            // 
            this.txt_Nombre1.Location = new System.Drawing.Point(181, 44);
            this.txt_Nombre1.Name = "txt_Nombre1";
            this.txt_Nombre1.Size = new System.Drawing.Size(203, 26);
            this.txt_Nombre1.TabIndex = 1;
            // 
            // txt_Nombre2
            // 
            this.txt_Nombre2.Location = new System.Drawing.Point(561, 44);
            this.txt_Nombre2.Name = "txt_Nombre2";
            this.txt_Nombre2.Size = new System.Drawing.Size(167, 26);
            this.txt_Nombre2.TabIndex = 3;
            this.txt_Nombre2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label_Nombre2
            // 
            this.label_Nombre2.AutoSize = true;
            this.label_Nombre2.Location = new System.Drawing.Point(412, 47);
            this.label_Nombre2.Name = "label_Nombre2";
            this.label_Nombre2.Size = new System.Drawing.Size(134, 20);
            this.label_Nombre2.TabIndex = 2;
            this.label_Nombre2.Text = "Segundo Nombre";
            this.label_Nombre2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_Apellido2
            // 
            this.txt_Apellido2.Location = new System.Drawing.Point(1332, 41);
            this.txt_Apellido2.Name = "txt_Apellido2";
            this.txt_Apellido2.Size = new System.Drawing.Size(167, 26);
            this.txt_Apellido2.TabIndex = 5;
            // 
            // label_Apellido2
            // 
            this.label_Apellido2.AutoSize = true;
            this.label_Apellido2.Location = new System.Drawing.Point(1171, 47);
            this.label_Apellido2.Name = "label_Apellido2";
            this.label_Apellido2.Size = new System.Drawing.Size(134, 20);
            this.label_Apellido2.TabIndex = 4;
            this.label_Apellido2.Text = "Segundo Apellido";
            // 
            // txt_Apellido1
            // 
            this.txt_Apellido1.Location = new System.Drawing.Point(961, 41);
            this.txt_Apellido1.Name = "txt_Apellido1";
            this.txt_Apellido1.Size = new System.Drawing.Size(167, 26);
            this.txt_Apellido1.TabIndex = 7;
            // 
            // label_Apellido1
            // 
            this.label_Apellido1.AutoSize = true;
            this.label_Apellido1.Location = new System.Drawing.Point(812, 47);
            this.label_Apellido1.Name = "label_Apellido1";
            this.label_Apellido1.Size = new System.Drawing.Size(124, 20);
            this.label_Apellido1.TabIndex = 6;
            this.label_Apellido1.Text = "Primer Apellido *";
            this.label_Apellido1.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tipo de documento *";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Com_Box_Tipo_Doc
            // 
            this.Com_Box_Tipo_Doc.FormattingEnabled = true;
            this.Com_Box_Tipo_Doc.Items.AddRange(new object[] {
            "Cedula de Ciudadania",
            "Tarjeta de Identidad",
            "Pasaporte",
            "Cedula de Extranjeria",
            "Visa ",
            "PPT",
            "PEP"});
            this.Com_Box_Tipo_Doc.Location = new System.Drawing.Point(209, 175);
            this.Com_Box_Tipo_Doc.Name = "Com_Box_Tipo_Doc";
            this.Com_Box_Tipo_Doc.Size = new System.Drawing.Size(205, 28);
            this.Com_Box_Tipo_Doc.TabIndex = 11;
            this.Com_Box_Tipo_Doc.SelectedIndexChanged += new System.EventHandler(this.Com_Box_Tipo_Doc_SelectedIndexChanged);
            // 
            // txt_Numero_Doc
            // 
            this.txt_Numero_Doc.Location = new System.Drawing.Point(662, 172);
            this.txt_Numero_Doc.Name = "txt_Numero_Doc";
            this.txt_Numero_Doc.Size = new System.Drawing.Size(203, 26);
            this.txt_Numero_Doc.TabIndex = 13;
            // 
            // label_Numero_Documento
            // 
            this.label_Numero_Documento.AutoSize = true;
            this.label_Numero_Documento.Location = new System.Drawing.Point(449, 175);
            this.label_Numero_Documento.Name = "label_Numero_Documento";
            this.label_Numero_Documento.Size = new System.Drawing.Size(185, 20);
            this.label_Numero_Documento.TabIndex = 14;
            this.label_Numero_Documento.Text = "Numero de documento * ";
            this.label_Numero_Documento.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // label_Fecha_Nacimiento
            // 
            this.label_Fecha_Nacimiento.AutoSize = true;
            this.label_Fecha_Nacimiento.Location = new System.Drawing.Point(42, 283);
            this.label_Fecha_Nacimiento.Name = "label_Fecha_Nacimiento";
            this.label_Fecha_Nacimiento.Size = new System.Drawing.Size(167, 20);
            this.label_Fecha_Nacimiento.TabIndex = 16;
            this.label_Fecha_Nacimiento.Text = "Fecha de nacimiento *";
            this.label_Fecha_Nacimiento.Click += new System.EventHandler(this.label2_Click_3);
            // 
            // txt_Fecha_Nacimiento
            // 
            this.txt_Fecha_Nacimiento.Location = new System.Drawing.Point(228, 283);
            this.txt_Fecha_Nacimiento.Name = "txt_Fecha_Nacimiento";
            this.txt_Fecha_Nacimiento.Size = new System.Drawing.Size(203, 26);
            this.txt_Fecha_Nacimiento.TabIndex = 15;
            this.txt_Fecha_Nacimiento.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Agregar_Emple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 1077);
            this.Controls.Add(this.label_Fecha_Nacimiento);
            this.Controls.Add(this.txt_Fecha_Nacimiento);
            this.Controls.Add(this.label_Numero_Documento);
            this.Controls.Add(this.txt_Numero_Doc);
            this.Controls.Add(this.Com_Box_Tipo_Doc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Apellido1);
            this.Controls.Add(this.label_Apellido1);
            this.Controls.Add(this.txt_Apellido2);
            this.Controls.Add(this.label_Apellido2);
            this.Controls.Add(this.txt_Nombre2);
            this.Controls.Add(this.label_Nombre2);
            this.Controls.Add(this.txt_Nombre1);
            this.Controls.Add(this.label_Nombre1);
            this.Name = "Agregar_Emple";
            this.Text = "Agregar_Emple";
            this.Load += new System.EventHandler(this.Agregar_Emple_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Nombre1;
        private System.Windows.Forms.TextBox txt_Nombre1;
        private System.Windows.Forms.TextBox txt_Nombre2;
        private System.Windows.Forms.Label label_Nombre2;
        private System.Windows.Forms.TextBox txt_Apellido2;
        private System.Windows.Forms.Label label_Apellido2;
        private System.Windows.Forms.TextBox txt_Apellido1;
        private System.Windows.Forms.Label label_Apellido1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Com_Box_Tipo_Doc;
        private System.Windows.Forms.TextBox txt_Numero_Doc;
        private System.Windows.Forms.Label label_Numero_Documento;
        private System.Windows.Forms.Label label_Fecha_Nacimiento;
        private System.Windows.Forms.TextBox txt_Fecha_Nacimiento;
    }
}