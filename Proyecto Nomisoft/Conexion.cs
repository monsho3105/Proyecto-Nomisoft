using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Proyecto_Nomisoft
{
    internal partial class Conexion
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

        // Returns a DataTable with Nombre, Documento, Cargo, Salario and Estado.
        // All parameters are optional; empty/null values are ignored.
        // fechaIngresoFilter and fechaNacimientoFilter accept partial strings (will match against date text) or full parseable dates.
        public DataTable ObtenerResumenEmpleados(
            string nombre = null,
            string documento = null,
            string departamento = null,
            string cargo = null,
            string estadoCivil = null,
            string salarioRange = null,
            string fechaIngresoFilter = null,
            string fechaNacimientoFilter = null,
            int? numeroHijos = null)
        {
            var dt = new DataTable();
            var sb = new StringBuilder();
            sb.Append(@"
        SELECT
            -- convenient combined display name
            CONCAT(
                COALESCE(`Primer_Nombre`, ''), ' ',
                COALESCE(`Segundo_Nombre`, ''), ' ',
                COALESCE(`Primer_Apellido`, ''), ' ',
                COALESCE(`Segundo_Apellido`, '')
            ) AS Nombre,
            `Numero_Documento` AS Documento,
            `Cargo`,
            `Salario_Base` AS Salario,
            `Estado`,
            -- include all underlying columns so the grid can show them on demand
            `Primer_Nombre`,
            `Segundo_Nombre`,
            `Primer_Apellido`,
            `Segundo_Apellido`,
            `Tipo_Documento`,
            `Fecha_Nacimiento`,
            `Telefono`,
            `Correo`,
            `Direccion`,
            `Estado_Civil`,
            `Numero_Hijos`,
            `Departamento`,
            `Fecha_Ingreso`,
            `Tipo_Contrato`
        FROM `empleados`
        WHERE 1 = 1
    ");

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    sb.Append(" AND CONCAT(COALESCE(`Primer_Nombre`,''),' ',COALESCE(`Segundo_Nombre`,''),' ',COALESCE(`Primer_Apellido`,''),' ',COALESCE(`Segundo_Apellido`,'')) LIKE @Nombre");
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(documento))
                {
                    sb.Append(" AND `Numero_Documento` LIKE @Documento");
                    cmd.Parameters.AddWithValue("@Documento", "%" + documento.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(departamento))
                {
                    sb.Append(" AND `Departamento` = @Departamento");
                    cmd.Parameters.AddWithValue("@Departamento", departamento.Trim());
                }

                if (!string.IsNullOrWhiteSpace(cargo))
                {
                    sb.Append(" AND `Cargo` = @Cargo");
                    cmd.Parameters.AddWithValue("@Cargo", cargo.Trim());
                }

                if (!string.IsNullOrWhiteSpace(estadoCivil))
                {
                    sb.Append(" AND `Estado_Civil` = @EstadoCivil");
                    cmd.Parameters.AddWithValue("@EstadoCivil", estadoCivil.Trim());
                }

                if (!string.IsNullOrWhiteSpace(salarioRange))
                {
                    decimal? min = null, max = null;
                    var key = salarioRange.Trim();

                    switch (key)
                    {
                        case "1.400.000 - 1.999.999":
                            min = 1400000m; max = 1999999.99m; break;
                        case "2.000.000 - 2.999.999":
                            min = 2000000m; max = 2999999.99m; break;
                        case "3.000.000 - 4.999.999":
                            min = 3000000m; max = 4999999.99m; break;
                        case "+ 5.000.000":
                        case "+5.000.000":
                            min = 5000000m; break;
                    }

                    if (min.HasValue)
                    {
                        sb.Append(" AND `Salario_Base` >= @MinSalario");
                        cmd.Parameters.AddWithValue("@MinSalario", min.Value);
                    }

                    if (max.HasValue)
                    {
                        sb.Append(" AND `Salario_Base` <= @MaxSalario");
                        cmd.Parameters.AddWithValue("@MaxSalario", max.Value);
                    }
                }

                // Fecha_Ingreso filter: if parseable, exact date; otherwise partial-match against MySQL textual representation (YYYY-MM-DD)
                if (!string.IsNullOrWhiteSpace(fechaIngresoFilter))
                {
                    var txt = fechaIngresoFilter.Trim();
                    if (DateTime.TryParse(txt, out var dtIngres))
                    {
                        sb.Append(" AND DATE(`Fecha_Ingreso`) = @FechaIngreso");
                        cmd.Parameters.AddWithValue("@FechaIngreso", dtIngres.Date);
                    }
                    else
                    {
                        sb.Append(" AND CAST(`Fecha_Ingreso` AS CHAR) LIKE @FechaIngresoLike");
                        cmd.Parameters.AddWithValue("@FechaIngresoLike", "%" + txt + "%");
                    }
                }

                // Fecha_Nacimiento filter: same behavior as Fecha_Ingreso
                if (!string.IsNullOrWhiteSpace(fechaNacimientoFilter))
                {
                    var txt = fechaNacimientoFilter.Trim();
                    if (DateTime.TryParse(txt, out var dtNac))
                    {
                        sb.Append(" AND DATE(`Fecha_Nacimiento`) = @FechaNacimiento");
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dtNac.Date);
                    }
                    else
                    {
                        sb.Append(" AND CAST(`Fecha_Nacimiento` AS CHAR) LIKE @FechaNacimientoLike");
                        cmd.Parameters.AddWithValue("@FechaNacimientoLike", "%" + txt + "%");
                    }
                }

                // Filter by Numero_Hijos if provided (exact match)
                if (numeroHijos.HasValue)
                {
                    sb.Append(" AND `Numero_Hijos` = @NumeroHijos");
                    cmd.Parameters.AddWithValue("@NumeroHijos", numeroHijos.Value);
                }

                sb.Append(" ORDER BY Nombre;");

                cmd.CommandText = sb.ToString();

                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // Distinct value helpers (Departamento, Cargo, Estado_Civil)
        public List<string> ObtenerDepartamentos() => ObtenerDistinctValues("Departamento");
        public List<string> ObtenerCargos() => ObtenerDistinctValues("Cargo");
        public List<string> ObtenerEstadosCiviles() => ObtenerDistinctValues("Estado_Civil");

        private List<string> ObtenerDistinctValues(string columnName)
        {
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Departamento", "Cargo", "Estado_Civil"
            };

            if (!allowed.Contains(columnName))
                throw new ArgumentException("Invalid column", nameof(columnName));

            var list = new List<string>();

            string query = $"SELECT DISTINCT `{columnName}` FROM `empleados` WHERE `{columnName}` IS NOT NULL AND `{columnName}` <> '' ORDER BY `{columnName}`;";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var val = reader.IsDBNull(0) ? null : reader.GetString(0);
                            if (!string.IsNullOrWhiteSpace(val))
                                list.Add(val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select failed: " + ex.Message, ex);
                }
            }

            return list;
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

            bool wantsKeyChange = campos.Any(x => string.Equals(x, "Numero_Documento", StringComparison.OrdinalIgnoreCase));

            // special case: if also includes Fecha_Nacimiento, ignore it for updates (derived field)
            if (campos.Contains("Fecha_Nacimiento", StringComparer.OrdinalIgnoreCase))
            {
                campos.Remove("Fecha_Nacimiento");
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
                            assignments.Add("`Segundo_Apellido` = @Segundo_Segundo_Apellido");
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

        public class SeguridadSocial
        {
            public int Id { get; set; }
            public string Numero_Documento { get; set; }
            public string Eps { get; set; }
            public string Fondo_Pension { get; set; }
            public string Arl { get; set; }
            public string Caja_Compensacion { get; set; }
            public string Fondo_Cesantias { get; set; }
        }

        public SeguridadSocial Buscar_Seguridad_Social(string numeroDocumento)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento)) return null;

            string sql = @"
                SELECT Id, Numero_Documento, Eps, Fondo_Pension, Arl, Caja_Compensacion, Fondo_Cesantias
                FROM `seguridad_social`
                WHERE `Numero_Documento` = @numeroDocumento
                LIMIT 1;";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento.Trim());

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var ss = new SeguridadSocial();
                        int i = 0;
                        ss.Id = reader.IsDBNull(i) ? 0 : reader.GetInt32(i); i++;
                        ss.Numero_Documento = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        ss.Eps = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        ss.Fondo_Pension = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        ss.Arl = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        ss.Caja_Compensacion = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        ss.Fondo_Cesantias = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        return ss;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select failed: " + ex.Message, ex);
                }
            }
        }

        // Add this method to your Conexion class
        public void Agregar_Seguridad_Social(string numeroDocumento, string eps, string fondoPension, string arl, string cajaCompensacion, string fondoCesantias)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento)) throw new ArgumentException("numeroDocumento is required", nameof(numeroDocumento));

            // Check duplicate by Numero_Documento
            string checkSql = "SELECT COUNT(1) FROM `seguridad_social` WHERE `Numero_Documento` = @numeroDocumento;";
            using (var conn = new MySqlConnection(connectionString))
            using (var checkCmd = new MySqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento.Trim());
                try
                {
                    conn.Open();
                    var countObj = checkCmd.ExecuteScalar();
                    var count = Convert.ToInt32(countObj ?? 0);
                    if (count > 0)
                        throw new InvalidOperationException($"El número de documento '{numeroDocumento}' ya existe en seguridad_social.");
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new Exception("Database check failed: " + ex.Message, ex);
                }
            }

            // Insert new record
            string insertSql = @"
                INSERT INTO `seguridad_social` (Numero_Documento, Eps, Fondo_Pension, Arl, Caja_Compensacion, Fondo_Cesantias)
                VALUES (@numeroDocumento, @eps, @fondoPension, @arl, @cajaCompensacion, @fondoCesantias);
            ";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento.Trim());
                cmd.Parameters.AddWithValue("@eps", (object)eps ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fondoPension", (object)fondoPension ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@arl", (object)arl ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cajaCompensacion", (object)cajaCompensacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fondoCesantias", (object)fondoCesantias ?? DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database insert failed: " + ex.Message, ex);
                }
            }
        }

        // Add this method to your existing Conexion class.
        // Note: adjust table/column names to match your database schema if they differ.
        public void Editar_Seguridad_Social(string numeroDocumento, string eps, string fondoPension, string arl, string cajaCompensacion, string fondoCesantias)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento)) throw new ArgumentException("numeroDocumento is required", nameof(numeroDocumento));

            var sql = @"
                UPDATE `seguridad_social`
                SET `eps` = @eps,
                    `fondo_pension` = @fondoPension,
                    `arl` = @arl,
                    `caja_compensacion` = @cajaCompensacion,
                    `fondo_cesantias` = @fondoCesantias
                WHERE `numero_documento` = @numeroDocumento;
            ";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@eps", (object)eps ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fondoPension", (object)fondoPension ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@arl", (object)arl ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cajaCompensacion", (object)cajaCompensacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fondoCesantias", (object)fondoCesantias ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento.Trim());

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database update (seguridad_social) failed: " + ex.Message, ex);
                }
            }
        }

        public class Nomina
        {
            public string Numero_Documento { get; set; }
            public string Periodo { get; set; }
            public DateTime? Fecha_Creacion { get; set; }

            // Days are now stored as DECIMAL in the DB -> use decimal? here
            public decimal? Dias_Diurnos { get; set; }
            public decimal? Valor_Dias { get; set; }

            public decimal? Dias_Nocturnos { get; set; }
            public decimal? Valor_Dias_Nocturnos { get; set; }

            public decimal? Dias_Festivos { get; set; }
            public decimal? Valor_Dias_Festivos { get; set; }

            public decimal? Horas_Extras_Diurnas { get; set; }
            public decimal? Valor_Horas_Extras_Diurnas { get; set; }

            public decimal? Horas_Extras_Nocturnas { get; set; }
            public decimal? Valor_Horas_Extras_Nocturnas { get; set; }

            public decimal? Horas_Extras_Festivas_Diurnas { get; set; }
            public decimal? Valor_Horas_Extras_Festivas_Diurnas { get; set; }

            public decimal? Horas_Extras_Festivas_Nocturnas { get; set; }
            public decimal? Valor_Horas_Extras_Festivas_Nocturnas { get; set; }

            public decimal? Bonificaciones { get; set; }
            public decimal? Comisiones { get; set; }
            public decimal? Auxilio_Transporte { get; set; }
            public decimal? Deducciones { get; set; }
            public decimal? Aporte_Salud { get; set; }
            public decimal? Aporte_Pension { get; set; }
            public decimal? Total_Devengado { get; set; }
            public decimal? Total_Deducciones { get; set; }
            public decimal? Neto_Pagar { get; set; }
            public string Estado { get; set; }
        }
        // Add these members inside the existing 'internal partial class Conexion' in Conexion.cs

        // DTO for configuration
        public class ConfiguracionNomina
        {
            public decimal? Recargo_Nocturno { get; set; }
            public decimal? Recargo_Dominical { get; set; }
            public decimal? Recargo_HE_Diurna { get; set; }
            public decimal? Recargo_HE_Nocturna { get; set; }
            public decimal? Recargo_HE_Dominical { get; set; }
            // per your mapping request, this value will be taken from DB Recargo_HE_Diurna if the specific column is not provided
            public decimal? Recargo_HE_Dominical_Nocturna { get; set; }

            // Added: SMMLV and default Auxilio_Transporte stored in configuracion_nomina table
            public decimal? SMMLV { get; set; }
            public decimal? Auxilio_Transporte { get; set; }
        }

        // Add methods to insert and query nomina records
        public void Agregar_Nomina(Nomina n)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            if (string.IsNullOrWhiteSpace(n.Numero_Documento)) throw new ArgumentException("Numero_Documento required", nameof(n.Numero_Documento));
            if (string.IsNullOrWhiteSpace(n.Periodo)) throw new ArgumentException("Periodo required", nameof(n.Periodo));

            // prevent duplicate (Numero_Documento + Periodo)
            string checkSql = "SELECT COUNT(1) FROM `nomina` WHERE `Numero_Documento` = @numero AND `Periodo` = @periodo;";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(checkSql, conn))
            {
                cmd.Parameters.AddWithValue("@numero", n.Numero_Documento.Trim());
                cmd.Parameters.AddWithValue("@periodo", n.Periodo.Trim());
                try
                {
                    conn.Open();
                    var cnt = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    if (cnt > 0) throw new InvalidOperationException($"Nomina for '{n.Numero_Documento}' and periodo '{n.Periodo}' already exists.");
                }
                catch (InvalidOperationException) { throw; }
                catch (Exception ex) { throw new Exception("Database check failed: " + ex.Message, ex); }
            }

            string insertSql = @"
        INSERT INTO `nomina` (
            `Numero_Documento`,`Periodo`,`Fecha_Creacion`,
            `Dias_Diurnos`,`Valor_Dias`,
            `Dias_Nocturnos`,`Valor_Dias_Nocturnos`,
            `Dias_Festivos`,`Valor_Dias_Festivos`,
            `Horas_Extras_Diurnas`,`Valor_Horas_Extras_Diurnas`,
            `Horas_Extras_Nocturnas`,`Valor_Horas_Extras_Nocturnas`,
            `Horas_Extras_Festivas_Diurnas`,`Valor_Horas_Extras_Festivas_Diurnas`,
            `Horas_Extras_Festivas_Nocturnas`,`Valor_Horas_Extras_Festivas_Nocturnas`,
            `Bonificaciones`,`Comisiones`,`Auxilio_Transporte`,
            `Deducciones`,`Aporte_Salud`,`Aporte_Pension`,
            `Total_Devengado`,`Total_Deducciones`,`Neto_Pagar`,`Estado`
        ) VALUES (
            @Numero_Documento,@Periodo,@Fecha_Creacion,
            @Dias_Diurnos,@Valor_Dias,
            @Dias_Nocturnos,@Valor_Dias_Nocturnos,
            @Dias_Festivos,@Valor_Dias_Festivos,
            @Horas_Extras_Diurnas,@Valor_Horas_Extras_Diurnas,
            @Horas_Extras_Nocturnas,@Valor_Horas_Extras_Nocturnas,
            @Horas_Extras_Festivas_Diurnas,@Valor_Horas_Extras_Festivas_Diurnas,
            @Horas_Extras_Festivas_Nocturnas,@Valor_Horas_Extras_Festivas_Nocturnas,
            @Bonificaciones,@Comisiones,@Auxilio_Transporte,
            @Deducciones,@Aporte_Salud,@Aporte_Pension,
            @Total_Devengado,@Total_Deducciones,@Neto_Pagar,@Estado
        );";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@Numero_Documento", n.Numero_Documento.Trim());
                cmd.Parameters.AddWithValue("@Periodo", n.Periodo.Trim());
                cmd.Parameters.AddWithValue("@Fecha_Creacion", (object)n.Fecha_Creacion ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Diurnos", (object)n.Dias_Diurnos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias", (object)n.Valor_Dias ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Nocturnos", (object)n.Dias_Nocturnos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias_Nocturnos", (object)n.Valor_Dias_Nocturnos ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Festivos", (object)n.Dias_Festivos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias_Festivos", (object)n.Valor_Dias_Festivos ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Diurnas", (object)n.Horas_Extras_Diurnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Diurnas", (object)n.Valor_Horas_Extras_Diurnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Nocturnas", (object)n.Horas_Extras_Nocturnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Nocturnas", (object)n.Valor_Horas_Extras_Nocturnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Festivas_Diurnas", (object)n.Horas_Extras_Festivas_Diurnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Festivas_Diurnas", (object)n.Valor_Horas_Extras_Festivas_Diurnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Festivas_Nocturnas", (object)n.Horas_Extras_Festivas_Nocturnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Festivas_Nocturnas", (object)n.Valor_Horas_Extras_Festivas_Nocturnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Bonificaciones", (object)n.Bonificaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Comisiones", (object)n.Comisiones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Auxilio_Transporte", (object)n.Auxilio_Transporte ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Deducciones", (object)n.Deducciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Aporte_Salud", (object)n.Aporte_Salud ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Aporte_Pension", (object)n.Aporte_Pension ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Total_Devengado", (object)n.Total_Devengado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Total_Deducciones", (object)n.Total_Deducciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Neto_Pagar", (object)n.Neto_Pagar ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", (object)n.Estado ?? DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database insert (nomina) failed: " + ex.Message, ex);
                }
            }
        }

        public Nomina Buscar_Nomina(string numeroDocumento, string periodo)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento) || string.IsNullOrWhiteSpace(periodo)) return null;

            string sql = @"SELECT * FROM `nomina` WHERE `Numero_Documento` = @numero AND `Periodo` = @periodo LIMIT 1;";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@numero", numeroDocumento.Trim());
                cmd.Parameters.AddWithValue("@periodo", periodo.Trim());

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var n = new Nomina();
                        Func<string, int> g = name => reader.GetOrdinal(name);

                        n.Numero_Documento = reader.IsDBNull(g("Numero_Documento")) ? null : reader.GetString(g("Numero_Documento"));
                        n.Periodo = reader.IsDBNull(g("Periodo")) ? null : reader.GetString(g("Periodo"));
                        n.Fecha_Creacion = reader.IsDBNull(g("Fecha_Creacion")) ? (DateTime?)null : reader.GetDateTime(g("Fecha_Creacion"));

                        // read decimal fields using GetDecimal (match DB DECIMAL)
                        n.Dias_Diurnos = reader.IsDBNull(g("Dias_Diurnos")) ? (decimal?)null : reader.GetDecimal(g("Dias_Diurnos"));
                        n.Valor_Dias = reader.IsDBNull(g("Valor_Dias")) ? (decimal?)null : reader.GetDecimal(g("Valor_Dias"));

                        n.Dias_Nocturnos = reader.IsDBNull(g("Dias_Nocturnos")) ? (decimal?)null : reader.GetDecimal(g("Dias_Nocturnos"));
                        n.Valor_Dias_Nocturnos = reader.IsDBNull(g("Valor_Dias_Nocturnos")) ? (decimal?)null : reader.GetDecimal(g("Valor_Dias_Nocturnos"));

                        n.Dias_Festivos = reader.IsDBNull(g("Dias_Festivos")) ? (decimal?)null : reader.GetDecimal(g("Dias_Festivos"));
                        n.Valor_Dias_Festivos = reader.IsDBNull(g("Valor_Dias_Festivos")) ? (decimal?)null : reader.GetDecimal(g("Valor_Dias_Festivos"));

                        n.Horas_Extras_Diurnas = reader.IsDBNull(g("Horas_Extras_Diurnas")) ? (decimal?)null : reader.GetDecimal(g("Horas_Extras_Diurnas"));
                        n.Valor_Horas_Extras_Diurnas = reader.IsDBNull(g("Valor_Horas_Extras_Diurnas")) ? (decimal?)null : reader.GetDecimal(g("Valor_Horas_Extras_Diurnas"));

                        n.Horas_Extras_Nocturnas = reader.IsDBNull(g("Horas_Extras_Nocturnas")) ? (decimal?)null : reader.GetDecimal(g("Horas_Extras_Nocturnas"));
                        n.Valor_Horas_Extras_Nocturnas = reader.IsDBNull(g("Valor_Horas_Extras_Nocturnas")) ? (decimal?)null : reader.GetDecimal(g("Valor_Horas_Extras_Nocturnas"));

                        n.Horas_Extras_Festivas_Diurnas = reader.IsDBNull(g("Horas_Extras_Festivas_Diurnas")) ? (decimal?)null : reader.GetDecimal(g("Horas_Extras_Festivas_Diurnas"));
                        n.Valor_Horas_Extras_Festivas_Diurnas = reader.IsDBNull(g("Valor_Horas_Extras_Festivas_Diurnas")) ? (decimal?)null : reader.GetDecimal(g("Valor_Horas_Extras_Festivas_Diurnas"));

                        n.Horas_Extras_Festivas_Nocturnas = reader.IsDBNull(g("Horas_Extras_Festivas_Nocturnas")) ? (decimal?)null : reader.GetDecimal(g("Horas_Extras_Festivas_Nocturnas"));
                        n.Valor_Horas_Extras_Festivas_Nocturnas = reader.IsDBNull(g("Valor_Horas_Extras_Festivas_Nocturnas")) ? (decimal?)null : reader.GetDecimal(g("Valor_Horas_Extras_Festivas_Nocturnas"));

                        n.Bonificaciones = reader.IsDBNull(g("Bonificaciones")) ? (decimal?)null : reader.GetDecimal(g("Bonificaciones"));
                        n.Comisiones = reader.IsDBNull(g("Comisiones")) ? (decimal?)null : reader.GetDecimal(g("Comisiones"));
                        n.Auxilio_Transporte = reader.IsDBNull(g("Auxilio_Transporte")) ? (decimal?)null : reader.GetDecimal(g("Auxilio_Transporte"));

                        n.Deducciones = reader.IsDBNull(g("Deducciones")) ? (decimal?)null : reader.GetDecimal(g("Deducciones"));
                        n.Aporte_Salud = reader.IsDBNull(g("Aporte_Salud")) ? (decimal?)null : reader.GetDecimal(g("Aporte_Salud"));
                        n.Aporte_Pension = reader.IsDBNull(g("Aporte_Pension")) ? (decimal?)null : reader.GetDecimal(g("Aporte_Pension"));

                        n.Total_Devengado = reader.IsDBNull(g("Total_Devengado")) ? (decimal?)null : reader.GetDecimal(g("Total_Devengado"));
                        n.Total_Deducciones = reader.IsDBNull(g("Total_Deducciones")) ? (decimal?)null : reader.GetDecimal(g("Total_Deducciones"));
                        n.Neto_Pagar = reader.IsDBNull(g("Neto_Pagar")) ? (decimal?)null : reader.GetDecimal(g("Neto_Pagar"));

                        n.Estado = reader.IsDBNull(g("Estado")) ? null : reader.GetString(g("Estado"));

                        return n;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select (nomina) failed: " + ex.Message, ex);
                }
            }
        }

        // Optional: get all nominas for an employee (simple helper)
        public List<Nomina> Obtener_Nominas_Por_Empleado(string numeroDocumento)
        {
            var list = new List<Nomina>();
            if (string.IsNullOrWhiteSpace(numeroDocumento)) return list;

            string sql = "SELECT * FROM `nomina` WHERE `Numero_Documento` = @numero ORDER BY `Fecha_Creacion` DESC;";
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@numero", numeroDocumento.Trim());
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var n = new Nomina
                            {
                                Numero_Documento = reader.IsDBNull(reader.GetOrdinal("Numero_Documento")) ? null : reader.GetString("Numero_Documento"),
                                Periodo = reader.IsDBNull(reader.GetOrdinal("Periodo")) ? null : reader.GetString("Periodo"),
                                Fecha_Creacion = reader.IsDBNull(reader.GetOrdinal("Fecha_Creacion")) ? (DateTime?)null : reader.GetDateTime("Fecha_Creacion"),
                                // other fields can be mapped similarly if needed
                            };
                            list.Add(n);
                        }
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select (nomina list) failed: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Reads payroll configuration from DB. Expects a single row in table `configuracion_nomina`
        /// with columns matching the property names. If `Recargo_HE_Dominical_Nocturna` column
        /// does not exist or is NULL, its value will be taken from `Recargo_HE_Diurna` (as requested).
        /// </summary>
        public ConfiguracionNomina Obtener_Configuracion_Nomina()
        {
            const string sql = @"
                SELECT
                    Recargo_Nocturno,
                    Recargo_Dominical,
                    Recargo_HE_Diurna,
                    Recargo_HE_Nocturna,
                    Recargo_HE_Dominical,
                    -- try to read explicit column; if not present, we'll handle it below
                    Recargo_HE_Dominical_Nocturna,
                    SMMLV,
                    Auxilio_Transporte
                FROM `configuracion_nomina`
                LIMIT 1;";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        Func<string, bool> hasColumn = name =>
                        {
                            try { return reader.GetOrdinal(name) >= 0; }
                            catch { return false; }
                        };

                        var cfg = new ConfiguracionNomina();

                        int ord;
                        ord = reader.GetOrdinal("Recargo_Nocturno");
                        cfg.Recargo_Nocturno = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);

                        ord = reader.GetOrdinal("Recargo_Dominical");
                        cfg.Recargo_Dominical = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);

                        ord = reader.GetOrdinal("Recargo_HE_Diurna");
                        cfg.Recargo_HE_Diurna = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);

                        ord = reader.GetOrdinal("Recargo_HE_Nocturna");
                        cfg.Recargo_HE_Nocturna = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);

                        ord = reader.GetOrdinal("Recargo_HE_Dominical");
                        cfg.Recargo_HE_Dominical = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);

                        // Try to read Recargo_HE_Dominical_Nocturna; if missing or null, fallback to Recargo_HE_Diurna
                        decimal? recargoHEDomNoct = null;
                        if (hasColumn("Recargo_HE_Dominical_Nocturna"))
                        {
                            try
                            {
                                ord = reader.GetOrdinal("Recargo_HE_Dominical_Nocturna");
                                recargoHEDomNoct = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);
                            }
                            catch
                            {
                                recargoHEDomNoct = null;
                            }
                        }

                        cfg.Recargo_HE_Dominical_Nocturna = recargoHEDomNoct ?? cfg.Recargo_HE_Diurna;

                        // Read SMMLV and Auxilio_Transporte if present
                        if (hasColumn("SMMLV"))
                        {
                            try
                            {
                                ord = reader.GetOrdinal("SMMLV");
                                cfg.SMMLV = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);
                            }
                            catch
                            {
                                cfg.SMMLV = null;
                            }
                        }

                        if (hasColumn("Auxilio_Transporte"))
                        {
                            try
                            {
                                ord = reader.GetOrdinal("Auxilio_Transporte");
                                cfg.Auxilio_Transporte = reader.IsDBNull(ord) ? (decimal?)null : reader.GetDecimal(ord);
                            }
                            catch
                            {
                                cfg.Auxilio_Transporte = null;
                            }
                        }

                        return cfg;
                    }
                }
                catch (Exception ex)
                {
                    // Bubble up or return null — choose to throw for visibility in development
                    throw new Exception("Database select (configuracion_nomina) failed: " + ex.Message, ex);
                }
            }
        }

        // Add this method to the existing 'internal partial class Conexion' (near Agregar_Nomina)
        public void Editar_Nomina(Nomina n)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            if (string.IsNullOrWhiteSpace(n.Numero_Documento)) throw new ArgumentException("Numero_Documento required", nameof(n.Numero_Documento));
            if (string.IsNullOrWhiteSpace(n.Periodo)) throw new ArgumentException("Periodo required", nameof(n.Periodo));

            string updateSql = @"
        UPDATE `nomina` SET
            `Fecha_Creacion` = @Fecha_Creacion,
            `Dias_Diurnos` = @Dias_Diurnos,
            `Valor_Dias` = @Valor_Dias,
            `Dias_Nocturnos` = @Dias_Nocturnos,
            `Valor_Dias_Nocturnos` = @Valor_Dias_Nocturnos,
            `Dias_Festivos` = @Dias_Festivos,
            `Valor_Dias_Festivos` = @Valor_Dias_Festivos,
            `Horas_Extras_Diurnas` = @Horas_Extras_Diurnas,
            `Valor_Horas_Extras_Diurnas` = @Valor_Horas_Extras_Diurnas,
            `Horas_Extras_Nocturnas` = @Horas_Extras_Nocturnas,
            `Valor_Horas_Extras_Nocturnas` = @Valor_Horas_Extras_Nocturnas,
            `Horas_Extras_Festivas_Diurnas` = @Horas_Extras_Festivas_Diurnas,
            `Valor_Horas_Extras_Festivas_Diurnas` = @Valor_Horas_Extras_Festivas_Diurnas,
            `Horas_Extras_Festivas_Nocturnas` = @Horas_Extras_Festivas_Nocturnas,
            `Valor_Horas_Extras_Festivas_Nocturnas` = @Valor_Horas_Extras_Festivas_Nocturnas,
            `Bonificaciones` = @Bonificaciones,
            `Comisiones` = @Comisiones,
            `Auxilio_Transporte` = @Auxilio_Transporte,
            `Deducciones` = @Deducciones,
            `Aporte_Salud` = @Aporte_Salud,
            `Aporte_Pension` = @Aporte_Pension,
            `Total_Devengado` = @Total_Devengado,
            `Total_Deducciones` = @Total_Deducciones,
            `Neto_Pagar` = @Neto_Pagar,
            `Estado` = @Estado
        WHERE `Numero_Documento` = @Numero_Documento AND `Periodo` = @Periodo
        LIMIT 1;
    ";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(updateSql, conn))
            {
                cmd.Parameters.AddWithValue("@Fecha_Creacion", (object)n.Fecha_Creacion ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Diurnos", (object)n.Dias_Diurnos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias", (object)n.Valor_Dias ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Nocturnos", (object)n.Dias_Nocturnos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias_Nocturnos", (object)n.Valor_Dias_Nocturnos ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Dias_Festivos", (object)n.Dias_Festivos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Dias_Festivos", (object)n.Valor_Dias_Festivos ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Diurnas", (object)n.Horas_Extras_Diurnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Diurnas", (object)n.Valor_Horas_Extras_Diurnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Nocturnas", (object)n.Horas_Extras_Nocturnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Nocturnas", (object)n.Valor_Horas_Extras_Nocturnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Festivas_Diurnas", (object)n.Horas_Extras_Festivas_Diurnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Festivas_Diurnas", (object)n.Valor_Horas_Extras_Festivas_Diurnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Horas_Extras_Festivas_Nocturnas", (object)n.Horas_Extras_Festivas_Nocturnas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Valor_Horas_Extras_Festivas_Nocturnas", (object)n.Valor_Horas_Extras_Festivas_Nocturnas ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Bonificaciones", (object)n.Bonificaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Comisiones", (object)n.Comisiones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Auxilio_Transporte", (object)n.Auxilio_Transporte ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Deducciones", (object)n.Deducciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Aporte_Salud", (object)n.Aporte_Salud ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Aporte_Pension", (object)n.Aporte_Pension ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Total_Devengado", (object)n.Total_Devengado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Total_Deducciones", (object)n.Total_Deducciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Neto_Pagar", (object)n.Neto_Pagar ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", (object)n.Estado ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Numero_Documento", n.Numero_Documento.Trim());
                cmd.Parameters.AddWithValue("@Periodo", n.Periodo.Trim());

                try
                {
                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    if (affected == 0)
                        throw new InvalidOperationException("No se encontró la nómina para actualizar.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Database update (nomina) failed: " + ex.Message, ex);
                }
            }
        }

        // Add this method near the other nomina/configuration helpers in the existing 'internal partial class Conexion'
        public DataTable ObtenerConfiguracionNominaTabla()
        {
            var dt = new DataTable();
            string sql = "SELECT * FROM `configuracion_nomina`;";

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
            using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            return dt;
        }
        // Add this method inside the existing `internal partial class Conexion` in Conexion.cs
        public DataTable ObtenerResumenNominasTabla()
        {
            var dt = new DataTable();
            string sql = @"
        SELECT
            `Numero_Documento`,
            `Periodo`,
            `Neto_Pagar`
        FROM `nomina`
        WHERE `Estado` = 'Liquidado'
        ORDER BY `Fecha_Creacion` DESC;";

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
            using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            return dt;
        }
    }
}
