using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_Nomisoft
{
    public partial class Admin_Menu : Form
    {
        public Admin_Menu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;       // quita los bordes
            this.WindowState = FormWindowState.Maximized;      // pantalla completa
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;                           // quita los botones de título
            this.Text = "";                                     // borra el texto del título

            this.BackgroundImage = Properties.Resources.fondo_inicio;
            this.BackgroundImageLayout = ImageLayout.Zoom;

            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.BorderStyle = BorderStyle.None;
            panelContenedor.BackColor = Color.Transparent;
            panelContenedor.BringToFront();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Limpia el panel antes de cargar algo nuevo
            panelContenedor.Controls.Clear();

            // Crea una instancia del formulario Ver_emple
            Ver_Emple verEmpleForm = new Ver_Emple();

            // Configura el formulario para que se comporte como un control
            verEmpleForm.TopLevel = false;
            verEmpleForm.Dock = DockStyle.Fill;

            // Agrega el formulario al panel y lo muestra
            panelContenedor.Controls.Add(verEmpleForm);
            verEmpleForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Editar_Empleados editarForm = new Editar_Empleados(); // instancia del formulario

            editarForm.TopLevel = false; // permite incrustarlo
            editarForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(editarForm); // lo agrega al panel
            editarForm.Show(); // lo muestra
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Eliminar_Empleado eliminarForm = new Eliminar_Empleado(); // instancia del formulario

            eliminarForm.TopLevel = false; // permite incrustarlo
            eliminarForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(eliminarForm); // lo agrega al panel
            eliminarForm.Show(); // lo muestra
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Editar_Nomina editarNominaForm = new Editar_Nomina(); // instancia del formulario

            editarNominaForm.TopLevel = false; // permite incrustarlo
            editarNominaForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(editarNominaForm); // lo agrega al panel
            editarNominaForm.Show(); // lo muestra
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Agregar_Emple agregarForm = new Agregar_Emple(); // instancia del formulario

            agregarForm.TopLevel = false; // permite incrustarlo
            agregarForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(agregarForm); // lo agrega al panel
            agregarForm.Show(); // lo muestra


            this.BackgroundImage = Image.FromFile(@"C:\Users\dg262\Downloads\WhatsApp Image 2025-11-18 at 9.57.18 AM.jpeg");

        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            login Back = new login();
            Back.Show();
            this.Hide();
        }

        private void panelver_emple_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Crear_Nomina crearNominaForm = new Crear_Nomina(); // instancia del formulario

            crearNominaForm.TopLevel = false; // permite incrustarlo
            crearNominaForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(crearNominaForm); // lo agrega al panel
            crearNominaForm.Show(); // lo muestra
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Liquidar_Nomina liquidarNominaForm = new Liquidar_Nomina(); // instancia del formulario

            liquidarNominaForm.TopLevel = false; // permite incrustarlo
            liquidarNominaForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(liquidarNominaForm); // lo agrega al panel
            liquidarNominaForm.Show(); // lo muestra
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear(); // limpia el panel

            Parametros parametrosForm = new Parametros(); // instancia del formulario

            parametrosForm.TopLevel = false; // permite incrustarlo
            parametrosForm.Dock = DockStyle.Fill; // ocupa todo el panel

            panelContenedor.Controls.Add(parametrosForm); // lo agrega al panel
            parametrosForm.Show(); // lo muestra
        }

        internal class ConexionDB
        {
            private string connectionString
               = "Server=localhost;Database=nomisoft;User ID=root;Password=daniel123";

            public bool Conectandoando()
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            // Note: Salario_Base is DECIMAL(10,2) in DB -> use decimal? here
            public void Agregar_Empleado(string Primer_Nombre, string Segundo_Nombre, string Primer_Apellido,
               string Segundo_Apellido, string Tipo_Documento, string Numero_Documento, DateTime Fecha_Nacimiento,
               string Telefono, string Correo, string Direccion, string Estado_Civil, int Numero_Hijos, string Cargo,
               string Departamento, DateTime Fecha_Ingreso, string Tipo_Contrato, decimal? Salario_Base, string Estado)
            {
                string Query = @"
            INSERT INTO `empleados` (
              `Primer_Nombre`, `Segundo_Nombre`, `Primer_Apellido`, `Segundo_Apellido`,
              `Tipo_Documento`, `Numero_Documento`, `Fecha_Nacimiento`, `Telefono`, `Correo`,
              `Direccion`, `Estado_Civil`, `Numero_Hijos`, `Cargo`, `Departamento`, `Fecha_Ingreso`,
              `Tipo_Contrato`, `Salario_Base`, `Estado`
            ) VALUES (
              @Primer_Nombre, @Segundo_Nombre, @Primer_Apellido, @Segundo_Apellido,
              @Tipo_Documento, @Numero_Documento, @Fecha_Nacimiento, @Telefono, @Correo,
              @Direccion, @Estado_Civil, @Numero_Hijos, @Cargo, @Departamento, @Fecha_Ingreso,
              @Tipo_Contrato, @Salario_Base, @Estado
            );";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Primer_Nombre", Primer_Nombre);
                    command.Parameters.AddWithValue("@Segundo_Nombre", Segundo_Nombre);
                    command.Parameters.AddWithValue("@Primer_Apellido", Primer_Apellido);
                    command.Parameters.AddWithValue("@Segundo_Apellido", Segundo_Apellido);
                    command.Parameters.AddWithValue("@Tipo_Documento", Tipo_Documento);
                    command.Parameters.AddWithValue("@Numero_Documento", Numero_Documento);
                    command.Parameters.AddWithValue("@Fecha_Nacimiento", Fecha_Nacimiento);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Correo", Correo);
                    command.Parameters.AddWithValue("@Direccion", Direccion);
                    command.Parameters.AddWithValue("@Estado_Civil", Estado_Civil);
                    command.Parameters.AddWithValue("@Numero_Hijos", Numero_Hijos);
                    command.Parameters.AddWithValue("@Cargo", Cargo);
                    command.Parameters.AddWithValue("@Departamento", Departamento);
                    command.Parameters.AddWithValue("@Fecha_Ingreso", Fecha_Ingreso);
                    command.Parameters.AddWithValue("@Tipo_Contrato", Tipo_Contrato);

                    // pass DBNull.Value when salary is null
                    command.Parameters.AddWithValue("@Salario_Base", (object)Salario_Base ?? DBNull.Value);

                    command.Parameters.AddWithValue("@Estado", Estado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database insert failed: " + ex.Message, ex);
                    }
                }
            }

            public class Empleado
            {
                public string Primer_Nombre { get; set; }
                public string Segundo_Nombre { get; set; }
                public string Primer_Apellido { get; set; }
                public string Segundo_Apellido { get; set; }
                public string Tipo_Documento { get; set; }
                public string Numero_Documento { get; set; }
                public DateTime? Fecha_Nacimiento { get; set; }
                public string Telefono { get; set; }
                public string Correo { get; set; }
                public string Direccion { get; set; }
                public string Estado_Civil { get; set; }
                public int? Numero_Hijos { get; set; }
                public string Cargo { get; set; }
                public string Departamento { get; set; }
                public DateTime? Fecha_Ingreso { get; set; }
                public string Tipo_Contrato { get; set; }

                // changed to decimal? so you can perform math later
                public decimal? Salario_Base { get; set; }

                public string Estado { get; set; }
            }

            public Empleado Buscar_Empleado(string numeroDocumento)
            {
                string query = @"
SELECT
    `Primer_Nombre`, `Segundo_Nombre`, `Primer_Apellido`, `Segundo_Apellido`,
    `Tipo_Documento`, `Numero_Documento`, `Fecha_Nacimiento`, `Telefono`, `Correo`,
    `Direccion`, `Estado_Civil`, `Numero_Hijos`, `Cargo`, `Departamento`, `Fecha_Ingreso`,
    `Tipo_Contrato`, `Salario_Base`, `Estado`
FROM `empleados`
WHERE `Numero_Documento` = @Numero_Documento
LIMIT 1;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero_Documento", numeroDocumento ?? string.Empty);

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                                return null;

                            int i = 0;
                            var emp = new Empleado();

                            emp.Primer_Nombre = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Segundo_Nombre = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Primer_Apellido = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Segundo_Apellido = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Tipo_Documento = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Numero_Documento = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                            if (reader.IsDBNull(i)) emp.Fecha_Nacimiento = null;
                            else emp.Fecha_Nacimiento = reader.GetDateTime(i);
                            i++;

                            emp.Telefono = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Correo = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Direccion = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Estado_Civil = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                            if (reader.IsDBNull(i)) emp.Numero_Hijos = null;
                            else emp.Numero_Hijos = reader.GetInt32(i);
                            i++;

                            emp.Cargo = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                            emp.Departamento = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                            if (reader.IsDBNull(i)) emp.Fecha_Ingreso = null;
                            else emp.Fecha_Ingreso = reader.GetDateTime(i);
                            i++;

                            emp.Tipo_Contrato = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                            // read DECIMAL as decimal
                            if (reader.IsDBNull(i)) emp.Salario_Base = null;
                            else emp.Salario_Base = reader.GetDecimal(i);
                            i++;

                            emp.Estado = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                            return emp;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database select failed: " + ex.Message, ex);
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // cierra toda la app
        }
    }
}
