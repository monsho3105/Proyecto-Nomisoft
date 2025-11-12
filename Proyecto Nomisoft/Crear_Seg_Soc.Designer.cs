namespace Proyecto_Nomisoft
{
    partial class Crear_Seg_Soc
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
            this.textBox_documento = new System.Windows.Forms.TextBox();
            this.TextBox_Nombre = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_regresar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button_registrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_documento
            // 
            this.textBox_documento.Location = new System.Drawing.Point(169, 70);
            this.textBox_documento.Name = "textBox_documento";
            this.textBox_documento.Size = new System.Drawing.Size(236, 26);
            this.textBox_documento.TabIndex = 0;
            this.textBox_documento.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextBox_Nombre
            // 
            this.TextBox_Nombre.Location = new System.Drawing.Point(711, 73);
            this.TextBox_Nombre.Name = "TextBox_Nombre";
            this.TextBox_Nombre.Size = new System.Drawing.Size(347, 26);
            this.TextBox_Nombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Documento";
            // 
            // button_buscar
            // 
            this.button_buscar.Image = global::Proyecto_Nomisoft.Properties.Resources.lupa;
            this.button_buscar.Location = new System.Drawing.Point(429, 38);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(103, 91);
            this.button_buscar.TabIndex = 3;
            this.button_buscar.UseVisualStyleBackColor = true;
            // 
            // button_regresar
            // 
            this.button_regresar.Location = new System.Drawing.Point(52, 765);
            this.button_regresar.Name = "button_regresar";
            this.button_regresar.Size = new System.Drawing.Size(120, 48);
            this.button_regresar.TabIndex = 4;
            this.button_regresar.Text = "regresar";
            this.button_regresar.UseVisualStyleBackColor = true;
            this.button_regresar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "EPS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fondo_Pension";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 545);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fondo de Cesantias";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sanitas",
            "SURA",
            "Compensar",
            "Nueva EPS",
            "Salud Total",
            "Famisanar",
            "Coosalud",
            "SOS",
            "Asmet Salud",
            "Sabia Salud",
            "Capresoca",
            "Dusakawi EPSI",
            "Mallamas EPSI",
            "Manexka EPSI",
            "AIC EPSI",
            "Medimás EPS"});
            this.comboBox1.Location = new System.Drawing.Point(337, 288);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 28);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia",
            "Fondo Nacional del Ahorro"});
            this.comboBox2.Location = new System.Drawing.Point(337, 537);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(237, 28);
            this.comboBox2.TabIndex = 10;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Colpensiones",
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia"});
            this.comboBox3.Location = new System.Drawing.Point(337, 401);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(237, 28);
            this.comboBox3.TabIndex = 11;
            // 
            // button_registrar
            // 
            this.button_registrar.Location = new System.Drawing.Point(938, 765);
            this.button_registrar.Name = "button_registrar";
            this.button_registrar.Size = new System.Drawing.Size(120, 48);
            this.button_registrar.TabIndex = 12;
            this.button_registrar.Text = "registrar";
            this.button_registrar.UseVisualStyleBackColor = true;
            // 
            // Crear_Seg_Soc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 873);
            this.Controls.Add(this.button_registrar);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_regresar);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_Nombre);
            this.Controls.Add(this.textBox_documento);
            this.Name = "Crear_Seg_Soc";
            this.Text = "Crear_Seg_Soc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_documento;
        private System.Windows.Forms.MaskedTextBox TextBox_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_regresar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button_registrar;
    }
}