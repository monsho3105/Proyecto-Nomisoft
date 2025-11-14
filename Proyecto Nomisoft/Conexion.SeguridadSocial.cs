using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace Proyecto_Nomisoft
{
    // Partial extension for Conexion: helpers for `seguridad_social` and `nomina` tables
    internal partial class Conexion
    {
        // Insert a new seguridad_social record
        public void Agregar_Seguridad_Social(string numeroDocumento, string eps, string fondoPension, string arl, string cajaCompensacion, string fondoCesantias)
        {
            var query = @"
                INSERT INTO `seguridad_social`
                    (`numero_documento`,`eps`,`fondo_pension`,`arl`,`caja_compensacion`,`fondo_cesantias`)
                VALUES
                    (@NumeroDocumento, @EPS, @FondoPension, @ARL, @CajaCompensacion, @FondoCesantias);
            ";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NumeroDocumento", (object)numeroDocumento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EPS", (object)eps ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FondoPension", (object)fondoPension ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ARL", (object)arl ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CajaCompensacion", (object)cajaCompensacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FondoCesantias", (object)fondoCesantias ?? DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database insert (seguridad_social) failed: " + ex.Message, ex);
                }
            }
        }

        // Find seguridad_social by numero_documento (returns null if not found)
        public SeguridadSocial Buscar_Seguridad_Social(string numeroDocumento)
        {
            var query = @"
                SELECT
                    `id`,`numero_documento`,`eps`,`fondo_pension`,`arl`,`caja_compensacion`,`fondo_cesantias`
                FROM `seguridad_social`
                WHERE `numero_documento` = @NumeroDocumento
                LIMIT 1;
            ";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NumeroDocumento", (object)numeroDocumento ?? string.Empty);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var s = new SeguridadSocial();
                        int i = 0;
                        s.Id = reader.IsDBNull(i) ? 0 : reader.GetInt32(i); i++;
                        s.Numero_Documento = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        s.Eps = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        s.Fondo_Pension = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        s.Arl = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        s.Caja_Compensacion = reader.IsDBNull(i) ? null : reader.GetString(i); i++;
                        s.Fondo_Cesantias = reader.IsDBNull(i) ? null : reader.GetString(i); i++;

                        return s;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select (seguridad_social) failed: " + ex.Message, ex);
                }
            }
        }

        // Update seguridad_social by id (only update provided fields in SeguridadSocial object)
        public void Editar_Seguridad_Social(int id, SeguridadSocial nuevo)
        {
            if (id <= 0) throw new ArgumentException("id must be a positive integer.", nameof(id));

            var sb = new System.Text.StringBuilder();
            sb.Append("UPDATE `seguridad_social` SET ");

            var assignments = new System.Collections.Generic.List<string>();
            if (nuevo.Numero_Documento != null) assignments.Add("`numero_documento` = @NumeroDocumento");
            if (nuevo.Eps != null) assignments.Add("`eps` = @EPS");
            if (nuevo.Fondo_Pension != null) assignments.Add("`fondo_pension` = @FondoPension");
            if (nuevo.Arl != null) assignments.Add("`arl` = @ARL");
            if (nuevo.Caja_Compensacion != null) assignments.Add("`caja_compensacion` = @CajaCompensacion");
            if (nuevo.Fondo_Cesantias != null) assignments.Add("`fondo_cesantias` = @FondoCesantias");

            if (assignments.Count == 0) return; // nothing to update

            sb.Append(string.Join(", ", assignments));
            sb.Append(" WHERE `id` = @Id LIMIT 1;");

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                if (nuevo.Numero_Documento != null) cmd.Parameters.AddWithValue("@NumeroDocumento", nuevo.Numero_Documento);
                if (nuevo.Eps != null) cmd.Parameters.AddWithValue("@EPS", nuevo.Eps);
                if (nuevo.Fondo_Pension != null) cmd.Parameters.AddWithValue("@FondoPension", nuevo.Fondo_Pension);
                if (nuevo.Arl != null) cmd.Parameters.AddWithValue("@ARL", nuevo.Arl);
                if (nuevo.Caja_Compensacion != null) cmd.Parameters.AddWithValue("@CajaCompensacion", nuevo.Caja_Compensacion);
                if (nuevo.Fondo_Cesantias != null) cmd.Parameters.AddWithValue("@FondoCesantias", nuevo.Fondo_Cesantias);

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

        // Nomina DTO updated to match new table schema (many numeric columns are DECIMAL in DB)
        public class Nomina
        {
            public string Numero_Documento { get; set; }
            public string Periodo { get; set; }
            public DateTime? Fecha_Creacion { get; set; }

            // Use decimal? since DB columns are DECIMAL(...)
            public decimal? Dias_Diurnos { get; set; }
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
            `Dias_Diurnos`,`Dias_Nocturnos`,`Valor_Dias_Nocturnos`,
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
            @Dias_Diurnos,@Dias_Nocturnos,@Valor_Dias_Nocturnos,
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

                        // read DECIMAL columns as decimal
                        n.Dias_Diurnos = reader.IsDBNull(g("Dias_Diurnos")) ? (decimal?)null : reader.GetDecimal(g("Dias_Diurnos"));
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

        public DataTable ObtenerResumenEmpleadosConSeguridad(
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
            var sb = new System.Text.StringBuilder();
            sb.Append(@"
SELECT
    CONCAT(
        COALESCE(e.`Primer_Nombre`, ''), ' ',
        COALESCE(e.`Segundo_Nombre`, ''), ' ',
        COALESCE(e.`Primer_Apellido`, ''), ' ',
        COALESCE(e.`Segundo_Apellido`, '')
    ) AS Nombre,
    e.`Numero_Documento` AS Documento,
    e.`Cargo`,
    e.`Salario_Base` AS Salario,
    e.`Estado`,
    ss.`eps` AS EPS,
    ss.`fondo_pension` AS Fondo_Pension,
    ss.`fondo_cesantias` AS Fondo_Cesantias,
    -- include underlying empleado columns for on-demand use
    e.`Primer_Nombre`, e.`Segundo_Nombre`, e.`Primer_Apellido`, e.`Segundo_Apellido`,
    e.`Tipo_Documento`, e.`Fecha_Nacimiento`, e.`Telefono`, e.`Correo`, e.`Direccion`,
    e.`Estado_Civil`, e.`Numero_Hijos`, e.`Departamento`, e.`Fecha_Ingreso`, e.`Tipo_Contrato`
FROM `empleados` e
LEFT JOIN `seguridad_social` ss ON ss.`numero_documento` = e.`Numero_Documento`
WHERE 1 = 1
");

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    sb.Append(" AND CONCAT(COALESCE(e.`Primer_Nombre`,''),' ',COALESCE(e.`Segundo_Nombre`,''),' ',COALESCE(e.`Primer_Apellido`,''),' ',COALESCE(e.`Segundo_Apellido`,'')) LIKE @Nombre");
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(documento))
                {
                    sb.Append(" AND e.`Numero_Documento` LIKE @Documento");
                    cmd.Parameters.AddWithValue("@Documento", "%" + documento.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(departamento))
                {
                    sb.Append(" AND e.`Departamento` = @Departamento");
                    cmd.Parameters.AddWithValue("@Departamento", departamento.Trim());
                }

                if (!string.IsNullOrWhiteSpace(cargo))
                {
                    sb.Append(" AND e.`Cargo` = @Cargo");
                    cmd.Parameters.AddWithValue("@Cargo", cargo.Trim());
                }

                if (!string.IsNullOrWhiteSpace(estadoCivil))
                {
                    sb.Append(" AND e.`Estado_Civil` = @EstadoCivil");
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
                        sb.Append(" AND e.`Salario_Base` >= @MinSalario");
                        cmd.Parameters.AddWithValue("@MinSalario", min.Value);
                    }

                    if (max.HasValue)
                    {
                        sb.Append(" AND e.`Salario_Base` <= @MaxSalario");
                        cmd.Parameters.AddWithValue("@MaxSalario", max.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(fechaIngresoFilter))
                {
                    var txt = fechaIngresoFilter.Trim();
                    if (DateTime.TryParse(txt, out var dtIngres))
                    {
                        sb.Append(" AND DATE(e.`Fecha_Ingreso`) = @FechaIngreso");
                        cmd.Parameters.AddWithValue("@FechaIngreso", dtIngres.Date);
                    }
                    else
                    {
                        sb.Append(" AND CAST(e.`Fecha_Ingreso` AS CHAR) LIKE @FechaIngresoLike");
                        cmd.Parameters.AddWithValue("@FechaIngresoLike", "%" + txt + "%");
                    }
                }

                if (!string.IsNullOrWhiteSpace(fechaNacimientoFilter))
                {
                    var txt = fechaNacimientoFilter.Trim();
                    if (DateTime.TryParse(txt, out var dtNac))
                    {
                        sb.Append(" AND DATE(e.`Fecha_Nacimiento`) = @FechaNacimiento");
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dtNac.Date);
                    }
                    else
                    {
                        sb.Append(" AND CAST(e.`Fecha_Nacimiento` AS CHAR) LIKE @FechaNacimientoLike");
                        cmd.Parameters.AddWithValue("@FechaNacimientoLike", "%" + txt + "%");
                    }
                }

                if (numeroHijos.HasValue)
                {
                    sb.Append(" AND e.`Numero_Hijos` = @NumeroHijos");
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
    }
}