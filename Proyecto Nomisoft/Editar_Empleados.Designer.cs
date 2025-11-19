namespace Proyecto_Nomisoft
{
    partial class Editar_Empleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editar_Empleados));
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Salario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Estado = new System.Windows.Forms.TextBox();
            this.label_Tipo_Contrato = new System.Windows.Forms.Label();
            this.text_Tipo_Contrato = new System.Windows.Forms.TextBox();
            this.label_Fecha_Ingreso = new System.Windows.Forms.Label();
            this.txt_Fecha_Ingreso = new System.Windows.Forms.TextBox();
            this.label_Departamento = new System.Windows.Forms.Label();
            this.txt_Departamento = new System.Windows.Forms.TextBox();
            this.label_Cargo = new System.Windows.Forms.Label();
            this.txt_Cargo = new System.Windows.Forms.TextBox();
            this.label_Hijos = new System.Windows.Forms.Label();
            this.txt_Hijos = new System.Windows.Forms.TextBox();
            this.Label_Estado_Civil = new System.Windows.Forms.Label();
            this.txt_Estado_Civil = new System.Windows.Forms.TextBox();
            this.label_Direccion = new System.Windows.Forms.Label();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.label_Correo = new System.Windows.Forms.Label();
            this.txt_Correo = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.label_Fecha_Nacimiento = new System.Windows.Forms.Label();
            this.txt_Fecha_Nacimiento = new System.Windows.Forms.TextBox();
            this.label_Numero_Documento = new System.Windows.Forms.Label();
            this.txt_Numero_Doc = new System.Windows.Forms.TextBox();
            this.txt_Apellido1 = new System.Windows.Forms.TextBox();
            this.label_Apellido1 = new System.Windows.Forms.Label();
            this.txt_Apellido2 = new System.Windows.Forms.TextBox();
            this.label_Apellido2 = new System.Windows.Forms.Label();
            this.txt_Nombre2 = new System.Windows.Forms.TextBox();
            this.label_Nombre2 = new System.Windows.Forms.Label();
            this.txt_Nombre1 = new System.Windows.Forms.TextBox();
            this.label_Nombre1 = new System.Windows.Forms.Label();
            this.Com_Box_Tipo_Doc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Guardar
            // 
            this.button_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Guardar.FlatAppearance.BorderSize = 0;
            this.button_Guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Guardar.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Guardar.ForeColor = System.Drawing.Color.White;
            this.button_Guardar.Location = new System.Drawing.Point(1005, 993);
            this.button_Guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(236, 55);
            this.button_Guardar.TabIndex = 76;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = false;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 75;
            // 
            // txt_Salario
            // 
            this.txt_Salario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Salario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Salario.Location = new System.Drawing.Point(306, 725);
            this.txt_Salario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Salario.Multiline = true;
            this.txt_Salario.Name = "txt_Salario";
            this.txt_Salario.Size = new System.Drawing.Size(533, 33);
            this.txt_Salario.TabIndex = 74;
            this.txt_Salario.TextChanged += new System.EventHandler(this.txt_Salario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 678);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 73;
            // 
            // txt_Estado
            // 
            this.txt_Estado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Estado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Estado.Location = new System.Drawing.Point(891, 725);
            this.txt_Estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Estado.Multiline = true;
            this.txt_Estado.Name = "txt_Estado";
            this.txt_Estado.Size = new System.Drawing.Size(480, 28);
            this.txt_Estado.TabIndex = 72;
            this.txt_Estado.TextChanged += new System.EventHandler(this.txt_Estado_TextChanged);
            // 
            // label_Tipo_Contrato
            // 
            this.label_Tipo_Contrato.AutoSize = true;
            this.label_Tipo_Contrato.Location = new System.Drawing.Point(442, 596);
            this.label_Tipo_Contrato.Name = "label_Tipo_Contrato";
            this.label_Tipo_Contrato.Size = new System.Drawing.Size(0, 16);
            this.label_Tipo_Contrato.TabIndex = 71;
            // 
            // text_Tipo_Contrato
            // 
            this.text_Tipo_Contrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.text_Tipo_Contrato.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_Tipo_Contrato.Location = new System.Drawing.Point(870, 642);
            this.text_Tipo_Contrato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Tipo_Contrato.Multiline = true;
            this.text_Tipo_Contrato.Name = "text_Tipo_Contrato";
            this.text_Tipo_Contrato.Size = new System.Drawing.Size(501, 35);
            this.text_Tipo_Contrato.TabIndex = 70;
            this.text_Tipo_Contrato.TextChanged += new System.EventHandler(this.text_Tipo_Contrato_TextChanged);
            // 
            // label_Fecha_Ingreso
            // 
            this.label_Fecha_Ingreso.AutoSize = true;
            this.label_Fecha_Ingreso.Location = new System.Drawing.Point(44, 596);
            this.label_Fecha_Ingreso.Name = "label_Fecha_Ingreso";
            this.label_Fecha_Ingreso.Size = new System.Drawing.Size(0, 16);
            this.label_Fecha_Ingreso.TabIndex = 69;
            // 
            // txt_Fecha_Ingreso
            // 
            this.txt_Fecha_Ingreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Fecha_Ingreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Fecha_Ingreso.Location = new System.Drawing.Point(300, 641);
            this.txt_Fecha_Ingreso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Fecha_Ingreso.Multiline = true;
            this.txt_Fecha_Ingreso.Name = "txt_Fecha_Ingreso";
            this.txt_Fecha_Ingreso.Size = new System.Drawing.Size(533, 35);
            this.txt_Fecha_Ingreso.TabIndex = 68;
            this.txt_Fecha_Ingreso.TextChanged += new System.EventHandler(this.txt_Fecha_Ingreso_TextChanged);
            // 
            // label_Departamento
            // 
            this.label_Departamento.AutoSize = true;
            this.label_Departamento.Location = new System.Drawing.Point(492, 531);
            this.label_Departamento.Name = "label_Departamento";
            this.label_Departamento.Size = new System.Drawing.Size(0, 16);
            this.label_Departamento.TabIndex = 67;
            // 
            // txt_Departamento
            // 
            this.txt_Departamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Departamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Departamento.Location = new System.Drawing.Point(870, 571);
            this.txt_Departamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Departamento.Multiline = true;
            this.txt_Departamento.Name = "txt_Departamento";
            this.txt_Departamento.Size = new System.Drawing.Size(490, 23);
            this.txt_Departamento.TabIndex = 66;
            this.txt_Departamento.TextChanged += new System.EventHandler(this.txt_Departamento_TextChanged);
            // 
            // label_Cargo
            // 
            this.label_Cargo.AutoSize = true;
            this.label_Cargo.Location = new System.Drawing.Point(53, 531);
            this.label_Cargo.Name = "label_Cargo";
            this.label_Cargo.Size = new System.Drawing.Size(0, 16);
            this.label_Cargo.TabIndex = 65;
            // 
            // txt_Cargo
            // 
            this.txt_Cargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Cargo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Cargo.Location = new System.Drawing.Point(306, 571);
            this.txt_Cargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Cargo.Multiline = true;
            this.txt_Cargo.Name = "txt_Cargo";
            this.txt_Cargo.Size = new System.Drawing.Size(533, 23);
            this.txt_Cargo.TabIndex = 64;
            this.txt_Cargo.TextChanged += new System.EventHandler(this.txt_Cargo_TextChanged);
            // 
            // label_Hijos
            // 
            this.label_Hijos.AutoSize = true;
            this.label_Hijos.Location = new System.Drawing.Point(444, 464);
            this.label_Hijos.Name = "label_Hijos";
            this.label_Hijos.Size = new System.Drawing.Size(0, 16);
            this.label_Hijos.TabIndex = 63;
            // 
            // txt_Hijos
            // 
            this.txt_Hijos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Hijos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Hijos.Location = new System.Drawing.Point(870, 482);
            this.txt_Hijos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Hijos.Multiline = true;
            this.txt_Hijos.Name = "txt_Hijos";
            this.txt_Hijos.Size = new System.Drawing.Size(490, 25);
            this.txt_Hijos.TabIndex = 62;
            this.txt_Hijos.TextChanged += new System.EventHandler(this.txt_Hijos_TextChanged);
            // 
            // Label_Estado_Civil
            // 
            this.Label_Estado_Civil.AutoSize = true;
            this.Label_Estado_Civil.Location = new System.Drawing.Point(44, 464);
            this.Label_Estado_Civil.Name = "Label_Estado_Civil";
            this.Label_Estado_Civil.Size = new System.Drawing.Size(0, 16);
            this.Label_Estado_Civil.TabIndex = 61;
            // 
            // txt_Estado_Civil
            // 
            this.txt_Estado_Civil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Estado_Civil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Estado_Civil.Location = new System.Drawing.Point(306, 482);
            this.txt_Estado_Civil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Estado_Civil.Multiline = true;
            this.txt_Estado_Civil.Name = "txt_Estado_Civil";
            this.txt_Estado_Civil.Size = new System.Drawing.Size(547, 25);
            this.txt_Estado_Civil.TabIndex = 60;
            this.txt_Estado_Civil.TextChanged += new System.EventHandler(this.txt_Estado_Civil_TextChanged);
            // 
            // label_Direccion
            // 
            this.label_Direccion.AutoSize = true;
            this.label_Direccion.Location = new System.Drawing.Point(434, 396);
            this.label_Direccion.Name = "label_Direccion";
            this.label_Direccion.Size = new System.Drawing.Size(0, 16);
            this.label_Direccion.TabIndex = 59;
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Direccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Direccion.Location = new System.Drawing.Point(870, 396);
            this.txt_Direccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Direccion.Multiline = true;
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(490, 30);
            this.txt_Direccion.TabIndex = 58;
            this.txt_Direccion.TextChanged += new System.EventHandler(this.txt_Direccion_TextChanged);
            // 
            // label_Correo
            // 
            this.label_Correo.AutoSize = true;
            this.label_Correo.Location = new System.Drawing.Point(44, 391);
            this.label_Correo.Name = "label_Correo";
            this.label_Correo.Size = new System.Drawing.Size(0, 16);
            this.label_Correo.TabIndex = 57;
            // 
            // txt_Correo
            // 
            this.txt_Correo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Correo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Correo.Location = new System.Drawing.Point(306, 405);
            this.txt_Correo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Correo.Multiline = true;
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(531, 35);
            this.txt_Correo.TabIndex = 56;
            this.txt_Correo.TextChanged += new System.EventHandler(this.txt_Correo_TextChanged);
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(507, 319);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(0, 16);
            this.labelTelefono.TabIndex = 55;
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Telefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Telefono.Location = new System.Drawing.Point(870, 319);
            this.txt_Telefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Telefono.Multiline = true;
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(490, 28);
            this.txt_Telefono.TabIndex = 54;
            this.txt_Telefono.TextChanged += new System.EventHandler(this.txt_Telefono_TextChanged);
            // 
            // label_Fecha_Nacimiento
            // 
            this.label_Fecha_Nacimiento.AutoSize = true;
            this.label_Fecha_Nacimiento.Location = new System.Drawing.Point(44, 312);
            this.label_Fecha_Nacimiento.Name = "label_Fecha_Nacimiento";
            this.label_Fecha_Nacimiento.Size = new System.Drawing.Size(0, 16);
            this.label_Fecha_Nacimiento.TabIndex = 53;
            // 
            // txt_Fecha_Nacimiento
            // 
            this.txt_Fecha_Nacimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Fecha_Nacimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Fecha_Nacimiento.Location = new System.Drawing.Point(310, 319);
            this.txt_Fecha_Nacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Fecha_Nacimiento.Multiline = true;
            this.txt_Fecha_Nacimiento.Name = "txt_Fecha_Nacimiento";
            this.txt_Fecha_Nacimiento.Size = new System.Drawing.Size(529, 31);
            this.txt_Fecha_Nacimiento.TabIndex = 52;
            this.txt_Fecha_Nacimiento.TextChanged += new System.EventHandler(this.txt_Fecha_Nacimiento_TextChanged);
            // 
            // label_Numero_Documento
            // 
            this.label_Numero_Documento.AutoSize = true;
            this.label_Numero_Documento.Location = new System.Drawing.Point(31, 33);
            this.label_Numero_Documento.Name = "label_Numero_Documento";
            this.label_Numero_Documento.Size = new System.Drawing.Size(0, 16);
            this.label_Numero_Documento.TabIndex = 51;
            // 
            // txt_Numero_Doc
            // 
            this.txt_Numero_Doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Numero_Doc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Numero_Doc.Location = new System.Drawing.Point(306, 84);
            this.txt_Numero_Doc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Numero_Doc.Multiline = true;
            this.txt_Numero_Doc.Name = "txt_Numero_Doc";
            this.txt_Numero_Doc.Size = new System.Drawing.Size(527, 28);
            this.txt_Numero_Doc.TabIndex = 50;
            this.txt_Numero_Doc.TextChanged += new System.EventHandler(this.txt_Numero_Doc_TextChanged);
            // 
            // txt_Apellido1
            // 
            this.txt_Apellido1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Apellido1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Apellido1.Location = new System.Drawing.Point(880, 165);
            this.txt_Apellido1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Apellido1.Multiline = true;
            this.txt_Apellido1.Name = "txt_Apellido1";
            this.txt_Apellido1.Size = new System.Drawing.Size(223, 22);
            this.txt_Apellido1.TabIndex = 47;
            this.txt_Apellido1.TextChanged += new System.EventHandler(this.txt_Apellido1_TextChanged);
            // 
            // label_Apellido1
            // 
            this.label_Apellido1.AutoSize = true;
            this.label_Apellido1.Location = new System.Drawing.Point(728, 123);
            this.label_Apellido1.Name = "label_Apellido1";
            this.label_Apellido1.Size = new System.Drawing.Size(0, 16);
            this.label_Apellido1.TabIndex = 46;
            // 
            // txt_Apellido2
            // 
            this.txt_Apellido2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Apellido2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Apellido2.Location = new System.Drawing.Point(1159, 165);
            this.txt_Apellido2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Apellido2.Name = "txt_Apellido2";
            this.txt_Apellido2.Size = new System.Drawing.Size(222, 15);
            this.txt_Apellido2.TabIndex = 45;
            this.txt_Apellido2.TextChanged += new System.EventHandler(this.txt_Apellido2_TextChanged);
            // 
            // label_Apellido2
            // 
            this.label_Apellido2.AutoSize = true;
            this.label_Apellido2.Location = new System.Drawing.Point(1047, 123);
            this.label_Apellido2.Name = "label_Apellido2";
            this.label_Apellido2.Size = new System.Drawing.Size(0, 16);
            this.label_Apellido2.TabIndex = 44;
            // 
            // txt_Nombre2
            // 
            this.txt_Nombre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Nombre2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Nombre2.Location = new System.Drawing.Point(590, 165);
            this.txt_Nombre2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Nombre2.Name = "txt_Nombre2";
            this.txt_Nombre2.Size = new System.Drawing.Size(224, 15);
            this.txt_Nombre2.TabIndex = 43;
            this.txt_Nombre2.TextChanged += new System.EventHandler(this.txt_Nombre2_TextChanged);
            // 
            // label_Nombre2
            // 
            this.label_Nombre2.AutoSize = true;
            this.label_Nombre2.Location = new System.Drawing.Point(372, 123);
            this.label_Nombre2.Name = "label_Nombre2";
            this.label_Nombre2.Size = new System.Drawing.Size(0, 16);
            this.label_Nombre2.TabIndex = 42;
            // 
            // txt_Nombre1
            // 
            this.txt_Nombre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txt_Nombre1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Nombre1.Location = new System.Drawing.Point(310, 165);
            this.txt_Nombre1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Nombre1.Multiline = true;
            this.txt_Nombre1.Name = "txt_Nombre1";
            this.txt_Nombre1.Size = new System.Drawing.Size(231, 22);
            this.txt_Nombre1.TabIndex = 41;
            this.txt_Nombre1.TextChanged += new System.EventHandler(this.txt_Nombre1_TextChanged);
            // 
            // label_Nombre1
            // 
            this.label_Nombre1.AutoSize = true;
            this.label_Nombre1.Location = new System.Drawing.Point(44, 123);
            this.label_Nombre1.Name = "label_Nombre1";
            this.label_Nombre1.Size = new System.Drawing.Size(0, 16);
            this.label_Nombre1.TabIndex = 40;
            // 
            // Com_Box_Tipo_Doc
            // 
            this.Com_Box_Tipo_Doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.Com_Box_Tipo_Doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Com_Box_Tipo_Doc.FormattingEnabled = true;
            this.Com_Box_Tipo_Doc.Items.AddRange(new object[] {
            "Cedula de Ciudadania",
            "Tarjeta de Identidad",
            "Pasaporte",
            "Cedula de Extranjeria",
            "Visa ",
            "PPT",
            "PEP"});
            this.Com_Box_Tipo_Doc.Location = new System.Drawing.Point(306, 244);
            this.Com_Box_Tipo_Doc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Com_Box_Tipo_Doc.Name = "Com_Box_Tipo_Doc";
            this.Com_Box_Tipo_Doc.Size = new System.Drawing.Size(535, 24);
            this.Com_Box_Tipo_Doc.TabIndex = 49;
            this.Com_Box_Tipo_Doc.SelectedIndexChanged += new System.EventHandler(this.Com_Box_Tipo_Doc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 48;
            // 
            // button_Buscar
            // 
            this.button_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(153)))));
            this.button_Buscar.FlatAppearance.BorderSize = 0;
            this.button_Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Buscar.Font = new System.Drawing.Font("Sans Serif Collection", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.Color.White;
            this.button_Buscar.Location = new System.Drawing.Point(900, 73);
            this.button_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(114, 48);
            this.button_Buscar.TabIndex = 77;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = false;
            this.button_Buscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia",
            "Fondo Nacional del Ahorro"});
            this.comboBox2.Location = new System.Drawing.Point(306, 950);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(1132, 24);
            this.comboBox2.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(814, 733);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 83;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Colpensiones",
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia"});
            this.comboBox3.Location = new System.Drawing.Point(870, 870);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(568, 24);
            this.comboBox3.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 735);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 81;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.comboBox1.Location = new System.Drawing.Point(306, 870);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(558, 24);
            this.comboBox1.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 733);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 79;
            // 
            // Editar_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1587, 1055);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Salario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Estado);
            this.Controls.Add(this.label_Tipo_Contrato);
            this.Controls.Add(this.text_Tipo_Contrato);
            this.Controls.Add(this.label_Fecha_Ingreso);
            this.Controls.Add(this.txt_Fecha_Ingreso);
            this.Controls.Add(this.label_Departamento);
            this.Controls.Add(this.txt_Departamento);
            this.Controls.Add(this.label_Cargo);
            this.Controls.Add(this.txt_Cargo);
            this.Controls.Add(this.label_Hijos);
            this.Controls.Add(this.txt_Hijos);
            this.Controls.Add(this.Label_Estado_Civil);
            this.Controls.Add(this.txt_Estado_Civil);
            this.Controls.Add(this.label_Direccion);
            this.Controls.Add(this.txt_Direccion);
            this.Controls.Add(this.label_Correo);
            this.Controls.Add(this.txt_Correo);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.txt_Telefono);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editar_Empleados";
            this.Text = "Editar_Empleados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Editar_Empleados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Salario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Estado;
        private System.Windows.Forms.Label label_Tipo_Contrato;
        private System.Windows.Forms.TextBox text_Tipo_Contrato;
        private System.Windows.Forms.Label label_Fecha_Ingreso;
        private System.Windows.Forms.TextBox txt_Fecha_Ingreso;
        private System.Windows.Forms.Label label_Departamento;
        private System.Windows.Forms.TextBox txt_Departamento;
        private System.Windows.Forms.Label label_Cargo;
        private System.Windows.Forms.TextBox txt_Cargo;
        private System.Windows.Forms.Label label_Hijos;
        private System.Windows.Forms.TextBox txt_Hijos;
        private System.Windows.Forms.Label Label_Estado_Civil;
        private System.Windows.Forms.TextBox txt_Estado_Civil;
        private System.Windows.Forms.Label label_Direccion;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.Label label_Correo;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Label label_Fecha_Nacimiento;
        private System.Windows.Forms.TextBox txt_Fecha_Nacimiento;
        private System.Windows.Forms.Label label_Numero_Documento;
        private System.Windows.Forms.TextBox txt_Numero_Doc;
        private System.Windows.Forms.TextBox txt_Apellido1;
        private System.Windows.Forms.Label label_Apellido1;
        private System.Windows.Forms.TextBox txt_Apellido2;
        private System.Windows.Forms.Label label_Apellido2;
        private System.Windows.Forms.TextBox txt_Nombre2;
        private System.Windows.Forms.Label label_Nombre2;
        private System.Windows.Forms.TextBox txt_Nombre1;
        private System.Windows.Forms.Label label_Nombre1;
        private System.Windows.Forms.ComboBox Com_Box_Tipo_Doc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Buscar;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}