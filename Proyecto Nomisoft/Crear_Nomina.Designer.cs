namespace Proyecto_Nomisoft
{
    partial class Crear_Nomina
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Empleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Periodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Dias_S = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Dias_N = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Dias_F = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Extras_D = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Extras_N = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_F_N = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Extras_F_D = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Bonificaciones = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Comisiones = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.button_Lupa = new System.Windows.Forms.Button();
            this.Button_Crear = new System.Windows.Forms.Button();
            this.Total_Dev = new System.Windows.Forms.Label();
            this.Total_Ded = new System.Windows.Forms.Label();
            this.Neto_Pagar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.Location = new System.Drawing.Point(183, 47);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(261, 26);
            this.textBox_Documento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Empleado";
            // 
            // textBox_Empleado
            // 
            this.textBox_Empleado.Location = new System.Drawing.Point(698, 47);
            this.textBox_Empleado.Name = "textBox_Empleado";
            this.textBox_Empleado.Size = new System.Drawing.Size(426, 26);
            this.textBox_Empleado.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Periodo";
            // 
            // textBox_Periodo
            // 
            this.textBox_Periodo.Location = new System.Drawing.Point(183, 123);
            this.textBox_Periodo.Name = "textBox_Periodo";
            this.textBox_Periodo.Size = new System.Drawing.Size(261, 26);
            this.textBox_Periodo.TabIndex = 5;
            this.textBox_Periodo.TextChanged += new System.EventHandler(this.textBox_Periodo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dias Diurno";
            // 
            // textBox_Dias_S
            // 
            this.textBox_Dias_S.Location = new System.Drawing.Point(183, 234);
            this.textBox_Dias_S.Name = "textBox_Dias_S";
            this.textBox_Dias_S.Size = new System.Drawing.Size(261, 26);
            this.textBox_Dias_S.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dias nocturnos";
            // 
            // textBox_Dias_N
            // 
            this.textBox_Dias_N.Location = new System.Drawing.Point(619, 240);
            this.textBox_Dias_N.Name = "textBox_Dias_N";
            this.textBox_Dias_N.Size = new System.Drawing.Size(261, 26);
            this.textBox_Dias_N.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(943, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dias Festivos";
            // 
            // textBox_Dias_F
            // 
            this.textBox_Dias_F.Location = new System.Drawing.Point(1052, 246);
            this.textBox_Dias_F.Name = "textBox_Dias_F";
            this.textBox_Dias_F.Size = new System.Drawing.Size(261, 26);
            this.textBox_Dias_F.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Extras Diurnas";
            // 
            // textBox_Extras_D
            // 
            this.textBox_Extras_D.Location = new System.Drawing.Point(183, 321);
            this.textBox_Extras_D.Name = "textBox_Extras_D";
            this.textBox_Extras_D.Size = new System.Drawing.Size(261, 26);
            this.textBox_Extras_D.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(510, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "esxtras Nocturnas";
            // 
            // textBox_Extras_N
            // 
            this.textBox_Extras_N.Location = new System.Drawing.Point(684, 327);
            this.textBox_Extras_N.Name = "textBox_Extras_N";
            this.textBox_Extras_N.Size = new System.Drawing.Size(261, 26);
            this.textBox_Extras_N.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "extras festivas N";
            // 
            // textBox_F_N
            // 
            this.textBox_F_N.Location = new System.Drawing.Point(684, 422);
            this.textBox_F_N.Name = "textBox_F_N";
            this.textBox_F_N.Size = new System.Drawing.Size(261, 26);
            this.textBox_F_N.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "estras festivas D";
            // 
            // textBox_Extras_F_D
            // 
            this.textBox_Extras_F_D.Location = new System.Drawing.Point(183, 410);
            this.textBox_Extras_F_D.Name = "textBox_Extras_F_D";
            this.textBox_Extras_F_D.Size = new System.Drawing.Size(261, 26);
            this.textBox_Extras_F_D.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Bonificaciones";
            // 
            // textBox_Bonificaciones
            // 
            this.textBox_Bonificaciones.Location = new System.Drawing.Point(183, 528);
            this.textBox_Bonificaciones.Name = "textBox_Bonificaciones";
            this.textBox_Bonificaciones.Size = new System.Drawing.Size(261, 26);
            this.textBox_Bonificaciones.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(511, 528);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Comisiones";
            // 
            // textBox_Comisiones
            // 
            this.textBox_Comisiones.Location = new System.Drawing.Point(655, 528);
            this.textBox_Comisiones.Name = "textBox_Comisiones";
            this.textBox_Comisiones.Size = new System.Drawing.Size(261, 26);
            this.textBox_Comisiones.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 706);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Total Devengado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 777);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Total Deducciones";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 859);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Neto a pagar";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(91, 1015);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(130, 56);
            this.button.TabIndex = 31;
            this.button.Text = "button1";
            this.button.UseVisualStyleBackColor = true;
            // 
            // button_Lupa
            // 
            this.button_Lupa.Location = new System.Drawing.Point(478, 46);
            this.button_Lupa.Name = "button_Lupa";
            this.button_Lupa.Size = new System.Drawing.Size(31, 34);
            this.button_Lupa.TabIndex = 32;
            this.button_Lupa.Text = "Lupa";
            this.button_Lupa.UseVisualStyleBackColor = true;
            this.button_Lupa.Click += new System.EventHandler(this.button_Lupa_Click_1);
            // 
            // Button_Crear
            // 
            this.Button_Crear.Location = new System.Drawing.Point(947, 987);
            this.Button_Crear.Name = "Button_Crear";
            this.Button_Crear.Size = new System.Drawing.Size(157, 84);
            this.Button_Crear.TabIndex = 33;
            this.Button_Crear.Text = "crear";
            this.Button_Crear.UseVisualStyleBackColor = true;
            this.Button_Crear.Click += new System.EventHandler(this.Button_Crear_Click_1);
            // 
            // Total_Dev
            // 
            this.Total_Dev.AutoSize = true;
            this.Total_Dev.Location = new System.Drawing.Point(233, 706);
            this.Total_Dev.Name = "Total_Dev";
            this.Total_Dev.Size = new System.Drawing.Size(0, 20);
            this.Total_Dev.TabIndex = 34;
            // 
            // Total_Ded
            // 
            this.Total_Ded.AutoSize = true;
            this.Total_Ded.Location = new System.Drawing.Point(233, 777);
            this.Total_Ded.Name = "Total_Ded";
            this.Total_Ded.Size = new System.Drawing.Size(0, 20);
            this.Total_Ded.TabIndex = 35;
            // 
            // Neto_Pagar
            // 
            this.Neto_Pagar.AutoSize = true;
            this.Neto_Pagar.Location = new System.Drawing.Point(233, 859);
            this.Neto_Pagar.Name = "Neto_Pagar";
            this.Neto_Pagar.Size = new System.Drawing.Size(0, 20);
            this.Neto_Pagar.TabIndex = 36;
            // 
            // Crear_Nomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 1166);
            this.Controls.Add(this.Neto_Pagar);
            this.Controls.Add(this.Total_Ded);
            this.Controls.Add(this.Total_Dev);
            this.Controls.Add(this.Button_Crear);
            this.Controls.Add(this.button_Lupa);
            this.Controls.Add(this.button);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_Comisiones);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_Bonificaciones);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_Extras_F_D);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_F_N);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Extras_N);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Extras_D);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Dias_F);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Dias_N);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Dias_S);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Periodo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Empleado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Documento);
            this.Name = "Crear_Nomina";
            this.Text = "Crear_Nomina";
            this.Load += new System.EventHandler(this.Crear_Nomina_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Empleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Periodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Dias_S;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Dias_N;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Dias_F;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Extras_D;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Extras_N;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_F_N;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Extras_F_D;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Bonificaciones;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Comisiones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button_Lupa;
        private System.Windows.Forms.Button Button_Crear;
        private System.Windows.Forms.Label Total_Dev;
        private System.Windows.Forms.Label Total_Ded;
        private System.Windows.Forms.Label Neto_Pagar;
    }
}