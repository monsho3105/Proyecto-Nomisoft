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
            this.button_Regresar = new System.Windows.Forms.Button();
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
            this.button_Guardar.Location = new System.Drawing.Point(1008, 802);
            this.button_Guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(292, 77);
            this.button_Guardar.TabIndex = 76;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "Salario Base";
            // 
            // txt_Salario
            // 
            this.txt_Salario.Location = new System.Drawing.Point(209, 678);
            this.txt_Salario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Salario.Name = "txt_Salario";
            this.txt_Salario.Size = new System.Drawing.Size(181, 22);
            this.txt_Salario.TabIndex = 74;
            this.txt_Salario.TextChanged += new System.EventHandler(this.txt_Salario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 678);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 73;
            this.label2.Text = "Estado ";
            // 
            // txt_Estado
            // 
            this.txt_Estado.Location = new System.Drawing.Point(631, 673);
            this.txt_Estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Estado.Name = "txt_Estado";
            this.txt_Estado.Size = new System.Drawing.Size(181, 22);
            this.txt_Estado.TabIndex = 72;
            this.txt_Estado.TextChanged += new System.EventHandler(this.txt_Estado_TextChanged);
            // 
            // label_Tipo_Contrato
            // 
            this.label_Tipo_Contrato.AutoSize = true;
            this.label_Tipo_Contrato.Location = new System.Drawing.Point(442, 596);
            this.label_Tipo_Contrato.Name = "label_Tipo_Contrato";
            this.label_Tipo_Contrato.Size = new System.Drawing.Size(107, 16);
            this.label_Tipo_Contrato.TabIndex = 71;
            this.label_Tipo_Contrato.Text = "Tipo de Contrato";
            // 
            // text_Tipo_Contrato
            // 
            this.text_Tipo_Contrato.Location = new System.Drawing.Point(607, 596);
            this.text_Tipo_Contrato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Tipo_Contrato.Name = "text_Tipo_Contrato";
            this.text_Tipo_Contrato.Size = new System.Drawing.Size(181, 22);
            this.text_Tipo_Contrato.TabIndex = 70;
            this.text_Tipo_Contrato.TextChanged += new System.EventHandler(this.text_Tipo_Contrato_TextChanged);
            // 
            // label_Fecha_Ingreso
            // 
            this.label_Fecha_Ingreso.AutoSize = true;
            this.label_Fecha_Ingreso.Location = new System.Drawing.Point(44, 596);
            this.label_Fecha_Ingreso.Name = "label_Fecha_Ingreso";
            this.label_Fecha_Ingreso.Size = new System.Drawing.Size(97, 16);
            this.label_Fecha_Ingreso.TabIndex = 69;
            this.label_Fecha_Ingreso.Text = "Fecha_Ingreso";
            // 
            // txt_Fecha_Ingreso
            // 
            this.txt_Fecha_Ingreso.Location = new System.Drawing.Point(209, 596);
            this.txt_Fecha_Ingreso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Fecha_Ingreso.Name = "txt_Fecha_Ingreso";
            this.txt_Fecha_Ingreso.Size = new System.Drawing.Size(181, 22);
            this.txt_Fecha_Ingreso.TabIndex = 68;
            this.txt_Fecha_Ingreso.TextChanged += new System.EventHandler(this.txt_Fecha_Ingreso_TextChanged);
            // 
            // label_Departamento
            // 
            this.label_Departamento.AutoSize = true;
            this.label_Departamento.Location = new System.Drawing.Point(492, 531);
            this.label_Departamento.Name = "label_Departamento";
            this.label_Departamento.Size = new System.Drawing.Size(93, 16);
            this.label_Departamento.TabIndex = 67;
            this.label_Departamento.Text = "Departamento";
            // 
            // txt_Departamento
            // 
            this.txt_Departamento.Location = new System.Drawing.Point(658, 531);
            this.txt_Departamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Departamento.Name = "txt_Departamento";
            this.txt_Departamento.Size = new System.Drawing.Size(181, 22);
            this.txt_Departamento.TabIndex = 66;
            this.txt_Departamento.TextChanged += new System.EventHandler(this.txt_Departamento_TextChanged);
            // 
            // label_Cargo
            // 
            this.label_Cargo.AutoSize = true;
            this.label_Cargo.Location = new System.Drawing.Point(53, 531);
            this.label_Cargo.Name = "label_Cargo";
            this.label_Cargo.Size = new System.Drawing.Size(44, 16);
            this.label_Cargo.TabIndex = 65;
            this.label_Cargo.Text = "Cargo";
            // 
            // txt_Cargo
            // 
            this.txt_Cargo.Location = new System.Drawing.Point(167, 529);
            this.txt_Cargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Cargo.Name = "txt_Cargo";
            this.txt_Cargo.Size = new System.Drawing.Size(181, 22);
            this.txt_Cargo.TabIndex = 64;
            this.txt_Cargo.TextChanged += new System.EventHandler(this.txt_Cargo_TextChanged);
            // 
            // label_Hijos
            // 
            this.label_Hijos.AutoSize = true;
            this.label_Hijos.Location = new System.Drawing.Point(444, 464);
            this.label_Hijos.Name = "label_Hijos";
            this.label_Hijos.Size = new System.Drawing.Size(46, 16);
            this.label_Hijos.TabIndex = 63;
            this.label_Hijos.Text = "Hijos *";
            // 
            // txt_Hijos
            // 
            this.txt_Hijos.Location = new System.Drawing.Point(520, 464);
            this.txt_Hijos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Hijos.Name = "txt_Hijos";
            this.txt_Hijos.Size = new System.Drawing.Size(36, 22);
            this.txt_Hijos.TabIndex = 62;
            this.txt_Hijos.TextChanged += new System.EventHandler(this.txt_Hijos_TextChanged);
            // 
            // Label_Estado_Civil
            // 
            this.Label_Estado_Civil.AutoSize = true;
            this.Label_Estado_Civil.Location = new System.Drawing.Point(44, 464);
            this.Label_Estado_Civil.Name = "Label_Estado_Civil";
            this.Label_Estado_Civil.Size = new System.Drawing.Size(86, 16);
            this.Label_Estado_Civil.TabIndex = 61;
            this.Label_Estado_Civil.Text = "Estado Civil *";
            // 
            // txt_Estado_Civil
            // 
            this.txt_Estado_Civil.Location = new System.Drawing.Point(209, 464);
            this.txt_Estado_Civil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Estado_Civil.Name = "txt_Estado_Civil";
            this.txt_Estado_Civil.Size = new System.Drawing.Size(181, 22);
            this.txt_Estado_Civil.TabIndex = 60;
            this.txt_Estado_Civil.TextChanged += new System.EventHandler(this.txt_Estado_Civil_TextChanged);
            // 
            // label_Direccion
            // 
            this.label_Direccion.AutoSize = true;
            this.label_Direccion.Location = new System.Drawing.Point(434, 396);
            this.label_Direccion.Name = "label_Direccion";
            this.label_Direccion.Size = new System.Drawing.Size(72, 16);
            this.label_Direccion.TabIndex = 59;
            this.label_Direccion.Text = "Direccion *";
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Location = new System.Drawing.Point(599, 396);
            this.txt_Direccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(608, 22);
            this.txt_Direccion.TabIndex = 58;
            this.txt_Direccion.TextChanged += new System.EventHandler(this.txt_Direccion_TextChanged);
            // 
            // label_Correo
            // 
            this.label_Correo.AutoSize = true;
            this.label_Correo.Location = new System.Drawing.Point(44, 391);
            this.label_Correo.Name = "label_Correo";
            this.label_Correo.Size = new System.Drawing.Size(118, 16);
            this.label_Correo.TabIndex = 57;
            this.label_Correo.Text = "Correo Electronico";
            // 
            // txt_Correo
            // 
            this.txt_Correo.Location = new System.Drawing.Point(209, 391);
            this.txt_Correo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(181, 22);
            this.txt_Correo.TabIndex = 56;
            this.txt_Correo.TextChanged += new System.EventHandler(this.txt_Correo_TextChanged);
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(507, 319);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(61, 16);
            this.labelTelefono.TabIndex = 55;
            this.labelTelefono.Text = "Telefono";
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Location = new System.Drawing.Point(596, 317);
            this.txt_Telefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(181, 22);
            this.txt_Telefono.TabIndex = 54;
            this.txt_Telefono.TextChanged += new System.EventHandler(this.txt_Telefono_TextChanged);
            // 
            // label_Fecha_Nacimiento
            // 
            this.label_Fecha_Nacimiento.AutoSize = true;
            this.label_Fecha_Nacimiento.Location = new System.Drawing.Point(44, 312);
            this.label_Fecha_Nacimiento.Name = "label_Fecha_Nacimiento";
            this.label_Fecha_Nacimiento.Size = new System.Drawing.Size(140, 16);
            this.label_Fecha_Nacimiento.TabIndex = 53;
            this.label_Fecha_Nacimiento.Text = "Fecha de nacimiento *";
            // 
            // txt_Fecha_Nacimiento
            // 
            this.txt_Fecha_Nacimiento.Location = new System.Drawing.Point(209, 312);
            this.txt_Fecha_Nacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Fecha_Nacimiento.Name = "txt_Fecha_Nacimiento";
            this.txt_Fecha_Nacimiento.Size = new System.Drawing.Size(181, 22);
            this.txt_Fecha_Nacimiento.TabIndex = 52;
            this.txt_Fecha_Nacimiento.TextChanged += new System.EventHandler(this.txt_Fecha_Nacimiento_TextChanged);
            // 
            // label_Numero_Documento
            // 
            this.label_Numero_Documento.AutoSize = true;
            this.label_Numero_Documento.Location = new System.Drawing.Point(31, 33);
            this.label_Numero_Documento.Name = "label_Numero_Documento";
            this.label_Numero_Documento.Size = new System.Drawing.Size(155, 16);
            this.label_Numero_Documento.TabIndex = 51;
            this.label_Numero_Documento.Text = "Numero de documento * ";
            // 
            // txt_Numero_Doc
            // 
            this.txt_Numero_Doc.Location = new System.Drawing.Point(220, 30);
            this.txt_Numero_Doc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Numero_Doc.Name = "txt_Numero_Doc";
            this.txt_Numero_Doc.Size = new System.Drawing.Size(181, 22);
            this.txt_Numero_Doc.TabIndex = 50;
            this.txt_Numero_Doc.TextChanged += new System.EventHandler(this.txt_Numero_Doc_TextChanged);
            // 
            // txt_Apellido1
            // 
            this.txt_Apellido1.Location = new System.Drawing.Point(860, 118);
            this.txt_Apellido1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Apellido1.Name = "txt_Apellido1";
            this.txt_Apellido1.Size = new System.Drawing.Size(149, 22);
            this.txt_Apellido1.TabIndex = 47;
            this.txt_Apellido1.TextChanged += new System.EventHandler(this.txt_Apellido1_TextChanged);
            // 
            // label_Apellido1
            // 
            this.label_Apellido1.AutoSize = true;
            this.label_Apellido1.Location = new System.Drawing.Point(728, 123);
            this.label_Apellido1.Name = "label_Apellido1";
            this.label_Apellido1.Size = new System.Drawing.Size(107, 16);
            this.label_Apellido1.TabIndex = 46;
            this.label_Apellido1.Text = "Primer Apellido *";
            // 
            // txt_Apellido2
            // 
            this.txt_Apellido2.Location = new System.Drawing.Point(1190, 118);
            this.txt_Apellido2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Apellido2.Name = "txt_Apellido2";
            this.txt_Apellido2.Size = new System.Drawing.Size(149, 22);
            this.txt_Apellido2.TabIndex = 45;
            this.txt_Apellido2.TextChanged += new System.EventHandler(this.txt_Apellido2_TextChanged);
            // 
            // label_Apellido2
            // 
            this.label_Apellido2.AutoSize = true;
            this.label_Apellido2.Location = new System.Drawing.Point(1047, 123);
            this.label_Apellido2.Name = "label_Apellido2";
            this.label_Apellido2.Size = new System.Drawing.Size(115, 16);
            this.label_Apellido2.TabIndex = 44;
            this.label_Apellido2.Text = "Segundo Apellido";
            // 
            // txt_Nombre2
            // 
            this.txt_Nombre2.Location = new System.Drawing.Point(505, 121);
            this.txt_Nombre2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Nombre2.Name = "txt_Nombre2";
            this.txt_Nombre2.Size = new System.Drawing.Size(149, 22);
            this.txt_Nombre2.TabIndex = 43;
            this.txt_Nombre2.TextChanged += new System.EventHandler(this.txt_Nombre2_TextChanged);
            // 
            // label_Nombre2
            // 
            this.label_Nombre2.AutoSize = true;
            this.label_Nombre2.Location = new System.Drawing.Point(372, 123);
            this.label_Nombre2.Name = "label_Nombre2";
            this.label_Nombre2.Size = new System.Drawing.Size(114, 16);
            this.label_Nombre2.TabIndex = 42;
            this.label_Nombre2.Text = "Segundo Nombre";
            // 
            // txt_Nombre1
            // 
            this.txt_Nombre1.Location = new System.Drawing.Point(167, 123);
            this.txt_Nombre1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Nombre1.Name = "txt_Nombre1";
            this.txt_Nombre1.Size = new System.Drawing.Size(181, 22);
            this.txt_Nombre1.TabIndex = 41;
            this.txt_Nombre1.TextChanged += new System.EventHandler(this.txt_Nombre1_TextChanged);
            // 
            // label_Nombre1
            // 
            this.label_Nombre1.AutoSize = true;
            this.label_Nombre1.Location = new System.Drawing.Point(44, 123);
            this.label_Nombre1.Name = "label_Nombre1";
            this.label_Nombre1.Size = new System.Drawing.Size(106, 16);
            this.label_Nombre1.TabIndex = 40;
            this.label_Nombre1.Text = "Primer Nombre *";
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
            this.Com_Box_Tipo_Doc.Location = new System.Drawing.Point(192, 226);
            this.Com_Box_Tipo_Doc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Com_Box_Tipo_Doc.Name = "Com_Box_Tipo_Doc";
            this.Com_Box_Tipo_Doc.Size = new System.Drawing.Size(183, 24);
            this.Com_Box_Tipo_Doc.TabIndex = 49;
            this.Com_Box_Tipo_Doc.SelectedIndexChanged += new System.EventHandler(this.Com_Box_Tipo_Doc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Tipo de documento *";
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(491, 10);
            this.button_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(292, 77);
            this.button_Buscar.TabIndex = 77;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Regresar
            // 
            this.button_Regresar.Location = new System.Drawing.Point(128, 790);
            this.button_Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Regresar.Name = "button_Regresar";
            this.button_Regresar.Size = new System.Drawing.Size(292, 77);
            this.button_Regresar.TabIndex = 78;
            this.button_Regresar.Text = "Regresar";
            this.button_Regresar.UseVisualStyleBackColor = true;
            this.button_Regresar.Click += new System.EventHandler(this.button1_Click_1);
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
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Porvenir",
            "Protección",
            "Colfondos",
            "Skandia",
            "Fondo Nacional del Ahorro"});
            this.comboBox2.Location = new System.Drawing.Point(1020, 735);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(211, 24);
            this.comboBox2.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(814, 733);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Fondo de Cesantias";
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
            this.comboBox3.Location = new System.Drawing.Point(572, 733);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(211, 24);
            this.comboBox3.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 735);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "Fondo_Pension";
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
            this.comboBox1.Location = new System.Drawing.Point(156, 733);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 24);
            this.comboBox1.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 733);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "EPS";
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
            this.Controls.Add(this.button_Regresar);
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
        private System.Windows.Forms.Button button_Regresar;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}