using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization; // <-- added

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

                // Parse Salario_Base string into decimal (handles comma or dot separators)
                decimal? salarioDecimal = null;
                if (!string.IsNullOrWhiteSpace(Salario_Base))
                {
                    // Try current culture first (supports comma decimals in many locales)
                    if (!decimal.TryParse(Salario_Base, NumberStyles.Number, CultureInfo.CurrentCulture, out var parsed))
                    {
                        // Fallback: replace comma with dot and try invariant culture
                        var normalized = Salario_Base.Replace(',', '.');
                        if (!decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out parsed))
                        {
                            throw new ArgumentException($"Invalid Salario_Base value: '{Salario_Base}'", nameof(Salario_Base));
                        }
                    }
                    salarioDecimal = parsed;
                }

                if (salarioDecimal.HasValue)
                    command.Parameters.AddWithValue("@Salario_Base", salarioDecimal.Value);
                else
                    command.Parameters.AddWithValue("@Salario_Base", DBNull.Value);

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

        // DTO to hold employee data returned from DB
        public class Empleado
        {
            public string Primer_Nombre { get; set; }
            public string Segundo_Nombre { get; set; }
            public string Primer_Apellido { get; set; }
            public string Segundo_Apellido { get; set; }
            public string Tipo_Documento { get; set; }
            public string Numero_Documento { get; set; } // varchar in DB -> string here
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
            public decimal? Salario_Base { get; set; } // changed to decimal? to match DB DECIMAL(10,2)
            public string Estado { get; set; }
        }

        // Returns Empleado or null if not found
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
                        emp.Salario_Base = reader.IsDBNull(i) ? (decimal?)null : reader.GetDecimal(i); i++; // FIXED: use GetDecimal instead of GetString
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

        // PSEUDOCODE (detailed):
        // 1. Method signature: Editar_Empleado(string originalNumeroDocumento, Empleado nuevo, params string[] camposCambiados)
        // 2. Validate originalNumeroDocumento not null/empty and camposCambiados has at least one entry.
        // 3. Define allowed columns mapping to properties (same names as DB columns).
        // 4. For each campo in camposCambiados:
        //    a. Normalize name.
        //    b. If not allowed -> throw ArgumentException.
        //    c. Add "`Column` = @Param" to assignment list.
        //    d. Add parameter to MySqlCommand with the value taken from `nuevo` (use DBNull.Value for nullables).
        // 5. Build UPDATE SQL: "UPDATE `empleados` SET {assignments} WHERE `Numero_Documento` = @OriginalNumero_Documento LIMIT 1;"
        // 6. Add parameter @OriginalNumero_Documento with the original key value.
        // 7. Open connection, ExecuteNonQuery inside try/catch. On exception, rethrow with contextual message.
        // 8. Caller is responsible to call this with the list of changed textboxes (field names matching DB column names).
        public void Editar_Empleado(string originalNumeroDocumento, Empleado nuevo, params string[] camposCambiados)
        {
            if (string.IsNullOrWhiteSpace(originalNumeroDocumento))
                throw new ArgumentException("originalNumeroDocumento is required.", nameof(originalNumeroDocumento));

            if (camposCambiados == null || camposCambiados.Length == 0)
                throw new ArgumentException("At least one field must be provided in camposCambiados.", nameof(camposCambiados));

            // allowed fields (must match DB column names)
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Primer_Nombre","Segundo_Nombre","Primer_Apellido","Segundo_Apellido",
                "Tipo_Documento","Numero_Documento","Fecha_Nacimiento","Telefono","Correo",
                "Direccion","Estado_Civil","Numero_Hijos","Cargo","Departamento","Fecha_Ingreso",
                "Tipo_Contrato","Salario_Base","Estado"
            };

            // Build a modifiable list of trimmed field names
            var campos = new List<string>();
            foreach (var raw in camposCambiados)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                campos.Add(raw.Trim());
            }

            if (campos.Count == 0)
                throw new ArgumentException("At least one non-empty field must be provided in camposCambiados.", nameof(camposCambiados));

            // If caller requested to change the primary key, validate and prevent duplicates
            bool wantsKeyChange = false;
            foreach (var c in campos)
            {
                if (string.Equals(c, "Numero_Documento", StringComparison.OrdinalIgnoreCase))
                {
                    wantsKeyChange = true;
                    break;
                }
            }

            if (wantsKeyChange)
            {
                var newKey = (nuevo.Numero_Documento ?? string.Empty).Trim();
                var origKey = originalNumeroDocumento.Trim();

                if (string.Equals(newKey, origKey, StringComparison.OrdinalIgnoreCase))
                {
                    // No real change -> remove the key update
                    campos.RemoveAll(x => string.Equals(x, "Numero_Documento", StringComparison.OrdinalIgnoreCase));
                    wantsKeyChange = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(newKey))
                        throw new ArgumentException("New Numero_Documento cannot be empty.", nameof(nuevo.Numero_Documento));

                    // Duplicate check: do not allow setting to an existing key
                    var existing = Buscar_Empleado(newKey);
                    if (existing != null)
                        throw new InvalidOperationException($"El número de documento '{newKey}' ya está en uso por otro empleado.");
                }
            }

            var assignments = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;

                foreach (var campo in campos)
                {
                    if (!allowed.Contains(campo))
                        throw new ArgumentException($"Field '{campo}' is not allowed to be updated.", nameof(camposCambiados));

                    // Add assignment and parameter based on field name
                    switch (campo)
                    {
                        case "Primer_Nombre":
                            assignments.Add("`Primer_Nombre` = @Primer_Nombre");
                            command.Parameters.AddWithValue("@Primer_Nombre", (object)nuevo.Primer_Nombre ?? DBNull.Value);
                            break;
                        case "Segundo_Nombre":
                            assignments.Add("`Segundo_Nombre` = @Segundo_Nombre");
                            command.Parameters.AddWithValue("@Segundo_Nombre", (object)nuevo.Segundo_Nombre ?? DBNull.Value);
                            break;
                        case "Primer_Apellido":
                            assignments.Add("`Primer_Apellido` = @Primer_Apellido");
                            command.Parameters.AddWithValue("@Primer_Apellido", (object)nuevo.Primer_Apellido ?? DBNull.Value);
                            break;
                        case "Segundo_Apellido":
                            assignments.Add("`Segundo_Apellido` = @Segundo_Apellido");
                            command.Parameters.AddWithValue("@Segundo_Apellido", (object)nuevo.Segundo_Apellido ?? DBNull.Value);
                            break;
                        case "Tipo_Documento":
                            assignments.Add("`Tipo_Documento` = @Tipo_Documento");
                            command.Parameters.AddWithValue("@Tipo_Documento", (object)nuevo.Tipo_Documento ?? DBNull.Value);
                            break;
                        case "Numero_Documento":
                            assignments.Add("`Numero_Documento` = @Numero_Documento");
                            command.Parameters.AddWithValue("@Numero_Documento", (object)nuevo.Numero_Documento ?? DBNull.Value);
                            break;
                        case "Fecha_Nacimiento":
                            assignments.Add("`Fecha_Nacimiento` = @Fecha_Nacimiento");
                            command.Parameters.AddWithValue("@Fecha_Nacimiento", (object)(nuevo.Fecha_Nacimiento.HasValue ? (object)nuevo.Fecha_Nacimiento.Value : DBNull.Value));
                            break;
                        case "Telefono":
                            assignments.Add("`Telefono` = @Telefono");
                            command.Parameters.AddWithValue("@Telefono", (object)nuevo.Telefono ?? DBNull.Value);
                            break;
                        case "Correo":
                            assignments.Add("`Correo` = @Correo");
                            command.Parameters.AddWithValue("@Correo", (object)nuevo.Correo ?? DBNull.Value);
                            break;
                        case "Direccion":
                            assignments.Add("`Direccion` = @Direccion");
                            command.Parameters.AddWithValue("@Direccion", (object)nuevo.Direccion ?? DBNull.Value);
                            break;
                        case "Estado_Civil":
                            assignments.Add("`Estado_Civil` = @Estado_Civil");
                            command.Parameters.AddWithValue("@Estado_Civil", (object)nuevo.Estado_Civil ?? DBNull.Value);
                            break;
                        case "Numero_Hijos":
                            assignments.Add("`Numero_Hijos` = @Numero_Hijos");
                            command.Parameters.AddWithValue("@Numero_Hijos", (object)(nuevo.Numero_Hijos.HasValue ? (object)nuevo.Numero_Hijos.Value : DBNull.Value));
                            break;
                        case "Cargo":
                            assignments.Add("`Cargo` = @Cargo");
                            command.Parameters.AddWithValue("@Cargo", (object)nuevo.Cargo ?? DBNull.Value);
                            break;
                        case "Departamento":
                            assignments.Add("`Departamento` = @Departamento");
                            command.Parameters.AddWithValue("@Departamento", (object)nuevo.Departamento ?? DBNull.Value);
                            break;
                        case "Fecha_Ingreso":
                            assignments.Add("`Fecha_Ingreso` = @Fecha_Ingreso");
                            command.Parameters.AddWithValue("@Fecha_Ingreso", (object)(nuevo.Fecha_Ingreso.HasValue ? (object)nuevo.Fecha_Ingreso.Value : DBNull.Value));
                            break;
                        case "Tipo_Contrato":
                            assignments.Add("`Tipo_Contrato` = @Tipo_Contrato");
                            command.Parameters.AddWithValue("@Tipo_Contrato", (object)nuevo.Tipo_Contrato ?? DBNull.Value);
                            break;
                        case "Salario_Base":
                            assignments.Add("`Salario_Base` = @Salario_Base");
                            command.Parameters.AddWithValue("@Salario_Base", (object)(nuevo.Salario_Base.HasValue ? (object)nuevo.Salario_Base.Value : DBNull.Value));
                            break;
                        case "Estado":
                            assignments.Add("`Estado` = @Estado");
                            command.Parameters.AddWithValue("@Estado", (object)nuevo.Estado ?? DBNull.Value);
                            break;
                    }
                }

                if (assignments.Count == 0)
                    throw new ArgumentException("No valid fields found in camposCambiados.", nameof(camposCambiados));

                // Add original key parameter
                command.Parameters.AddWithValue("@OriginalNumero_Documento", originalNumeroDocumento);

                string setClause = string.Join(", ", assignments);
                command.CommandText = $"UPDATE `empleados` SET {setClause} WHERE `Numero_Documento` = @OriginalNumero_Documento LIMIT 1;";

                try
                {
                    connection.Open();
                    int affected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database update failed: " + ex.Message, ex);
                }
            }
        }
    }
}
