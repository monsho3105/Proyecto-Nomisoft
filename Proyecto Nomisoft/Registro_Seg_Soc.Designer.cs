namespace Proyecto_Nomisoft
{
    partial class Registro_Seg_Soc
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox_Documento = new System.Windows.Forms.TextBox();
            this.textBox_empleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Eps = new System.Windows.Forms.ComboBox();
            this.combo_Pension = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_Cesantias = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Registrar = new System.Windows.Forms.Button();
            this.button_lupa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.Location = new System.Drawing.Point(255, 93);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(231, 26);
            this.textBox_Documento.TabIndex = 2;
            // 
            // textBox_empleado
            // 
            this.textBox_empleado.Location = new System.Drawing.Point(743, 99);
            this.textBox_empleado.Name = "textBox_empleado";
            this.textBox_empleado.Size = new System.Drawing.Size(434, 26);
            this.textBox_empleado.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "EPS";
            // 
            // combo_Eps
            // 
            this.combo_Eps.FormattingEnabled = true;
            this.combo_Eps.Items.AddRange(new object[] {
            "Sanitas",
            "SURA",
            "Compensar",
            "Nueva EPS",
            "Salud Total",
            "Famisanar",
            "Coosalud ",
            "SOS",
            "Asmet Salud",
            "Sabia Salud",
            "Capresoca",
            "Dusakawi EPSI",
            "Mallamas EPSI",
            "Manexka EPSI",
            "AIC EPSI",
            "Medimás EPS"});
            this.combo_Eps.Location = new System.Drawing.Point(268, 216);
            this.combo_Eps.Name = "combo_Eps";
            this.combo_Eps.Size = new System.Drawing.Size(271, 28);
            this.combo_Eps.TabIndex = 6;
            // 
            // combo_Pension
            // 
            this.combo_Pension.FormattingEnabled = true;
            this.combo_Pension.Items.AddRange(new object[] {
            "Colpensiones",
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia"});
            this.combo_Pension.Location = new System.Drawing.Point(268, 284);
            this.combo_Pension.Name = "combo_Pension";
            this.combo_Pension.Size = new System.Drawing.Size(271, 28);
            this.combo_Pension.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fondo de Pensiones";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // combo_Cesantias
            // 
            this.combo_Cesantias.FormattingEnabled = true;
            this.combo_Cesantias.Items.AddRange(new object[] {
            "Porvenir",
            "",
            "Protección",
            "",
            "Colfondos",
            "",
            "Skandia",
            "",
            "Fondo Nacional del Ahorro (FNA)"});
            this.combo_Cesantias.Location = new System.Drawing.Point(268, 360);
            this.combo_Cesantias.Name = "combo_Cesantias";
            this.combo_Cesantias.Size = new System.Drawing.Size(271, 28);
            this.combo_Cesantias.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fondo de Cesantias";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 64);
            this.button1.TabIndex = 11;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Registrar
            // 
            this.button_Registrar.Location = new System.Drawing.Point(901, 634);
            this.button_Registrar.Name = "button_Registrar";
            this.button_Registrar.Size = new System.Drawing.Size(194, 64);
            this.button_Registrar.TabIndex = 12;
            this.button_Registrar.Text = "Registrar";
            this.button_Registrar.UseVisualStyleBackColor = true;
            this.button_Registrar.Click += new System.EventHandler(this.button_Registrar_Click);
            // 
            // button_lupa
            // 
            this.button_lupa.Location = new System.Drawing.Point(700, 99);
            this.button_lupa.Name = "button_lupa";
            this.button_lupa.Size = new System.Drawing.Size(22, 26);
            this.button_lupa.TabIndex = 13;
            this.button_lupa.Text = "lupa";
            this.button_lupa.UseVisualStyleBackColor = true;
            // 
            // Registro_Seg_Soc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 804);
            this.Controls.Add(this.button_lupa);
            this.Controls.Add(this.button_Registrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo_Cesantias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_Pension);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combo_Eps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_empleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Documento);
            this.Controls.Add(this.label1);
            this.Name = "Registro_Seg_Soc";
            this.Text = "Registro_Seg_Soc";
            this.Load += new System.EventHandler(this.Registro_Seg_Soc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.TextBox textBox_empleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Eps;
        private System.Windows.Forms.ComboBox combo_Pension;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_Cesantias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Registrar;
        private System.Windows.Forms.Button button_lupa;
    }
}