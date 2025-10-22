using MySql.Data.MySqlClient;
using System;

namespace Proyecto_Nomisoft
{
    internal class Conexion
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

        public void Agregar_Empleado(string Primer_Nombre, string Segundo_Nombre, string Primer_Apellido,
           string Segundo_Apellido, string Tipo_Documento, string Numero_Documento, DateTime Fecha_Nacimiento,
           string Telefono, string Correo, string Direccion, string Estado_Civil, int Numero_Hijos, string Cargo,
           string Departamento, DateTime Fecha_Ingreso, string Tipo_Contrato, string Salario_Base, string Estado)
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
                command.Parameters.AddWithValue("@Salario_Base", Salario_Base);
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


        public bool Buscar_Empleado(
            string numeroDocumento,
            System.Windows.Forms.TextBox txtPrimer_Nombre,
            System.Windows.Forms.TextBox txtSegundo_Nombre,
            System.Windows.Forms.TextBox txtPrimer_Apellido,
            System.Windows.Forms.TextBox txtSegundo_Apellido,
            System.Windows.Forms.TextBox txtTipo_Documento,
            System.Windows.Forms.TextBox txtNumero_Documento,
            System.Windows.Forms.TextBox txtFecha_Nacimiento,
            System.Windows.Forms.TextBox txtTelefono,
            System.Windows.Forms.TextBox txtCorreo,
            System.Windows.Forms.TextBox txtDireccion,
            System.Windows.Forms.TextBox txtEstado_Civil,
            System.Windows.Forms.TextBox txtNumero_Hijos,
            System.Windows.Forms.TextBox txtCargo,
            System.Windows.Forms.TextBox txtDepartamento,
            System.Windows.Forms.TextBox txtFecha_Ingreso,
            System.Windows.Forms.TextBox txtTipo_Contrato,
            System.Windows.Forms.TextBox txtSalario_Base,
            System.Windows.Forms.TextBox txtEstado)
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

            // Helper local to clear all text boxes if no record is found
            void ClearAll()
            {
                txtPrimer_Nombre.Text = "";
                txtSegundo_Nombre.Text = "";
                txtPrimer_Apellido.Text = "";
                txtSegundo_Apellido.Text = "";
                txtTipo_Documento.Text = "";
                txtNumero_Documento.Text = "";
                txtFecha_Nacimiento.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
                txtEstado_Civil.Text = "";
                txtNumero_Hijos.Text = "";
                txtCargo.Text = "";
                txtDepartamento.Text = "";
                txtFecha_Ingreso.Text = "";
                txtTipo_Contrato.Text = "";
                txtSalario_Base.Text = "";
                txtEstado.Text = "";
            }

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
                        {
                            ClearAll();
                            return false;
                        }

                        // Column ordinals in the same order as the SELECT list
                        int i = 0;

                        txtPrimer_Nombre.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtSegundo_Nombre.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtPrimer_Apellido.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtSegundo_Apellido.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtTipo_Documento.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtNumero_Documento.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

                        // Fecha_Nacimiento (DateTime)
                        if (reader.IsDBNull(i)) { txtFecha_Nacimiento.Text = ""; } 
                        else { txtFecha_Nacimiento.Text = reader.GetDateTime(i).ToString("yyyy-MM-dd"); }
                        i++;

                        txtTelefono.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtCorreo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtDireccion.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtEstado_Civil.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

                        // Numero_Hijos (int)
                        if (reader.IsDBNull(i)) { txtNumero_Hijos.Text = ""; }
                        else { txtNumero_Hijos.Text = reader.GetInt32(i).ToString(); }
                        i++;

                        txtCargo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtDepartamento.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

                        // Fecha_Ingreso (DateTime)
                        if (reader.IsDBNull(i)) { txtFecha_Ingreso.Text = ""; }
                        else { txtFecha_Ingreso.Text = reader.GetDateTime(i).ToString("yyyy-MM-dd"); }
                        i++;

                        txtTipo_Contrato.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtSalario_Base.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
                        txtEstado.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

                        return true;
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
