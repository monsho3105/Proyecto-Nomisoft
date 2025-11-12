namespace Proyecto_Nomisoft
{
    partial class Menu_Nomina
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
            this.button_Crear_Seg_Soc = new System.Windows.Forms.Button();
            this.button_Editar_Nomina = new System.Windows.Forms.Button();
            this.button_Liquidar = new System.Windows.Forms.Button();
            this.button_Crear_Nomina = new System.Windows.Forms.Button();
            this.button_Editar_Seg_Soc = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button_regresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Crear_Seg_Soc
            // 
            this.button_Crear_Seg_Soc.Location = new System.Drawing.Point(111, 79);
            this.button_Crear_Seg_Soc.Name = "button_Crear_Seg_Soc";
            this.button_Crear_Seg_Soc.Size = new System.Drawing.Size(217, 65);
            this.button_Crear_Seg_Soc.TabIndex = 0;
            this.button_Crear_Seg_Soc.Text = "crear seguridad social";
            this.button_Crear_Seg_Soc.UseVisualStyleBackColor = true;
            // 
            // button_Editar_Nomina
            // 
            this.button_Editar_Nomina.Location = new System.Drawing.Point(631, 233);
            this.button_Editar_Nomina.Name = "button_Editar_Nomina";
            this.button_Editar_Nomina.Size = new System.Drawing.Size(204, 88);
            this.button_Editar_Nomina.TabIndex = 1;
            this.button_Editar_Nomina.Text = "editar nomina";
            this.button_Editar_Nomina.UseVisualStyleBackColor = true;
            // 
            // button_Liquidar
            // 
            this.button_Liquidar.Location = new System.Drawing.Point(111, 402);
            this.button_Liquidar.Name = "button_Liquidar";
            this.button_Liquidar.Size = new System.Drawing.Size(217, 78);
            this.button_Liquidar.TabIndex = 2;
            this.button_Liquidar.Text = "Liquidar Nomina";
            this.button_Liquidar.UseVisualStyleBackColor = true;
            // 
            // button_Crear_Nomina
            // 
            this.button_Crear_Nomina.Location = new System.Drawing.Point(111, 233);
            this.button_Crear_Nomina.Name = "button_Crear_Nomina";
            this.button_Crear_Nomina.Size = new System.Drawing.Size(217, 81);
            this.button_Crear_Nomina.TabIndex = 3;
            this.button_Crear_Nomina.Text = "Crear nomina";
            this.button_Crear_Nomina.UseVisualStyleBackColor = true;
            this.button_Crear_Nomina.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Editar_Seg_Soc
            // 
            this.button_Editar_Seg_Soc.Location = new System.Drawing.Point(631, 79);
            this.button_Editar_Seg_Soc.Name = "button_Editar_Seg_Soc";
            this.button_Editar_Seg_Soc.Size = new System.Drawing.Size(204, 76);
            this.button_Editar_Seg_Soc.TabIndex = 4;
            this.button_Editar_Seg_Soc.Text = "Editar Seguridad social";
            this.button_Editar_Seg_Soc.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(631, 402);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(204, 78);
            this.button6.TabIndex = 5;
            this.button6.Text = "Editar parametros";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button_regresar
            // 
            this.button_regresar.Location = new System.Drawing.Point(129, 620);
            this.button_regresar.Name = "button_regresar";
            this.button_regresar.Size = new System.Drawing.Size(243, 146);
            this.button_regresar.TabIndex = 6;
            this.button_regresar.Text = "Regresar";
            this.button_regresar.UseVisualStyleBackColor = true;
            this.button_regresar.Click += new System.EventHandler(this.button7_Click);
            // 
            // Menu_Nomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 866);
            this.Controls.Add(this.button_regresar);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button_Editar_Seg_Soc);
            this.Controls.Add(this.button_Crear_Nomina);
            this.Controls.Add(this.button_Liquidar);
            this.Controls.Add(this.button_Editar_Nomina);
            this.Controls.Add(this.button_Crear_Seg_Soc);
            this.Name = "Menu_Nomina";
            this.Text = "Menu_Nomina";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Crear_Seg_Soc;
        private System.Windows.Forms.Button button_Editar_Nomina;
        private System.Windows.Forms.Button button_Liquidar;
        private System.Windows.Forms.Button button_Crear_Nomina;
        private System.Windows.Forms.Button button_Editar_Seg_Soc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button_regresar;
    }
}