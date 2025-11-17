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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ver_Emple Next = new Ver_Emple();   
            Next.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editar_Empleados Next = new Editar_Empleados();
            Next.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminar_Empleado Next = new Eliminar_Empleado();
            Next.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu_Nomina next = new Menu_Nomina();
            next.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar_Emple Next = new Agregar_Emple();
            Next.Show();
            this.Hide();

        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            Seleccion Back = new Seleccion();
            Back.Show();
            this.Hide();    
        }
    }

    internal class ConexionDB
    {
        private string connectionString
           = "Server=localhost;Database=nomisoft;User ID=root;Password=Misioner@31";

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
}
