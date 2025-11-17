using MySql.Data.MySqlClient;
using System;

namespace Proyecto_Nomisoft
{
    internal partial class Conexion
    {
        // DTO for the parameters table (adjust names/types if your DB uses different names)
        public class ParametrosNomina
        {
            public int Id { get; set; }
            public decimal? Porcentaje_EPS { get; set; }
            public decimal? Porcentaje_Pension { get; set; }
            public decimal? Porcentaje_Fondo_Solidaridad { get; set; }
            public decimal? Recargo_Nocturno { get; set; }
            public decimal? Recargo_HE_Diurna { get; set; }
            public decimal? Recargo_HE_Nocturna { get; set; }
            public decimal? Recargo_Dominical { get; set; }
            public decimal? Recargo_HE_Dominical { get; set; }
            public decimal? Recargo_HE_Dominical_Nocturna { get; set; }
            public decimal? SMMLV { get; set; }
            public decimal? Auxilio_Transporte { get; set; }
            public decimal? Valor_Hora_Ordinaria { get; set; }
            public DateTime? Fecha_Ultima_Actualizacion { get; set; }
        }

        // Read one parameters row. Change table name if yours differs.
        public ParametrosNomina Obtener_Parametros(int id = 0)
        {
            // Use `configuracion_nomina` table (your DB uses this table name)
            string sql = id > 0
                ? "SELECT * FROM `configuracion_nomina` WHERE `id` = @id LIMIT 1;"
                : "SELECT * FROM `configuracion_nomina` ORDER BY `id` DESC LIMIT 1;";

            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (id > 0) cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;
                        var p = new ParametrosNomina();
                        p.Id = r.IsDBNull(r.GetOrdinal("id")) ? 0 : r.GetInt32("id");
                        p.Porcentaje_EPS = r.IsDBNull(r.GetOrdinal("Porcentaje_EPS")) ? (decimal?)null : r.GetDecimal("Porcentaje_EPS");
                        p.Porcentaje_Pension = r.IsDBNull(r.GetOrdinal("Porcentaje_Pension")) ? (decimal?)null : r.GetDecimal("Porcentaje_Pension");
                        p.Porcentaje_Fondo_Solidaridad = r.IsDBNull(r.GetOrdinal("Porcentaje_Fondo_Solidaridad")) ? (decimal?)null : r.GetDecimal("Porcentaje_Fondo_Solidaridad");
                        p.Recargo_Nocturno = r.IsDBNull(r.GetOrdinal("Recargo_Nocturno")) ? (decimal?)null : r.GetDecimal("Recargo_Nocturno");
                        p.Recargo_HE_Diurna = r.IsDBNull(r.GetOrdinal("Recargo_HE_Diurna")) ? (decimal?)null : r.GetDecimal("Recargo_HE_Diurna");
                        p.Recargo_HE_Nocturna = r.IsDBNull(r.GetOrdinal("Recargo_HE_Nocturna")) ? (decimal?)null : r.GetDecimal("Recargo_HE_Nocturna");
                        p.Recargo_Dominical = r.IsDBNull(r.GetOrdinal("Recargo_Dominical")) ? (decimal?)null : r.GetDecimal("Recargo_Dominical");
                        p.Recargo_HE_Dominical = r.IsDBNull(r.GetOrdinal("Recargo_HE_Dominical")) ? (decimal?)null : r.GetDecimal("Recargo_HE_Dominical");
                        if (ColumnExists(r, "Recargo_HE_Dominical_Nocturna"))
                            p.Recargo_HE_Dominical_Nocturna = r.IsDBNull(r.GetOrdinal("Recargo_HE_Dominical_Nocturna")) ? (decimal?)null : r.GetDecimal("Recargo_HE_Dominical_Nocturna");
                        else if (ColumnExists(r, "Recargo_HE_Dominical_Noct"))
                            p.Recargo_HE_Dominical_Nocturna = r.IsDBNull(r.GetOrdinal("Recargo_HE_Dominical_Noct")) ? (decimal?)null : r.GetDecimal("Recargo_HE_Dominical_Noct");

                        p.SMMLV = r.IsDBNull(r.GetOrdinal("SMMLV")) ? (decimal?)null : r.GetDecimal("SMMLV");
                        p.Auxilio_Transporte = r.IsDBNull(r.GetOrdinal("Auxilio_Transporte")) ? (decimal?)null : r.GetDecimal("Auxilio_Transporte");
                        p.Valor_Hora_Ordinaria = r.IsDBNull(r.GetOrdinal("Valor_Hora_Ordinaria")) ? (decimal?)null : r.GetDecimal("Valor_Hora_Ordinaria");
                        p.Fecha_Ultima_Actualizacion = r.IsDBNull(r.GetOrdinal("Fecha_Ultima_Actualizacion")) ? (DateTime?)null : r.GetDateTime("Fecha_Ultima_Actualizacion");
                        return p;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database select (configuracion_nomina) failed: " + ex.Message, ex);
                }
            }
        }

        // Insert or update parameters row. If p.Id <= 0 an INSERT is performed; otherwise UPDATE by id.
        public void Guardar_Parametros(ParametrosNomina p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            // set/update timestamp
            p.Fecha_Ultima_Actualizacion = DateTime.Now;

            // Validate numeric ranges to avoid MySQL "Out of range" errors.
            // Adjust ranges if your DB columns have different precision/scale.
            void ValidateRange(decimal? value, decimal min, decimal max, string name)
            {
                if (value.HasValue && (value.Value < min || value.Value > max))
                    throw new ArgumentOutOfRangeException(name, $"Value {value.Value} for '{name}' is outside allowed range [{min}, {max}].");
            }

            // Percentages: expect 0..100 (if your DB stores fractions 0..1 change accordingly)
            ValidateRange(p.Porcentaje_EPS, 0m, 100m, nameof(p.Porcentaje_EPS));
            ValidateRange(p.Porcentaje_Pension, 0m, 100m, nameof(p.Porcentaje_Pension));
            ValidateRange(p.Porcentaje_Fondo_Solidaridad, 0m, 100m, nameof(p.Porcentaje_Fondo_Solidaridad));

            // Recargos: small fractions like 0.35 (allow up to 10 to be safe)
            ValidateRange(p.Recargo_Nocturno, 0m, 10m, nameof(p.Recargo_Nocturno));
            ValidateRange(p.Recargo_HE_Diurna, 0m, 10m, nameof(p.Recargo_HE_Diurna));
            ValidateRange(p.Recargo_HE_Nocturna, 0m, 10m, nameof(p.Recargo_HE_Nocturna));
            ValidateRange(p.Recargo_Dominical, 0m, 10m, nameof(p.Recargo_Dominical));
            ValidateRange(p.Recargo_HE_Dominical, 0m, 10m, nameof(p.Recargo_HE_Dominical));
            ValidateRange(p.Recargo_HE_Dominical_Nocturna, 0m, 10m, nameof(p.Recargo_HE_Dominical_Nocturna));

            // Monetary values: non-negative
            ValidateRange(p.SMMLV, 0m, decimal.MaxValue, nameof(p.SMMLV));
            ValidateRange(p.Auxilio_Transporte, 0m, decimal.MaxValue, nameof(p.Auxilio_Transporte));
            ValidateRange(p.Valor_Hora_Ordinaria, 0m, decimal.MaxValue, nameof(p.Valor_Hora_Ordinaria));

            if (p.Id > 0)
            {
                string sql = @"
                    UPDATE `configuracion_nomina` SET
                        `Porcentaje_EPS` = @Porcentaje_EPS,
                        `Porcentaje_Pension` = @Porcentaje_Pension,
                        `Porcentaje_Fondo_Solidaridad` = @Porcentaje_Fondo_Solidaridad,
                        `Recargo_Nocturno` = @Recargo_Nocturno,
                        `Recargo_HE_Diurna` = @Recargo_HE_Diurna,
                        `Recargo_HE_Nocturna` = @Recargo_HE_Nocturna,
                        `Recargo_Dominical` = @Recargo_Dominical,
                        `Recargo_HE_Dominical` = @Recargo_HE_Dominical,
                        `Recargo_HE_Dominical_Nocturna` = @Recargo_HE_Dominical_Nocturna,
                        `SMMLV` = @SMMLV,
                        `Auxilio_Transporte` = @Auxilio_Transporte,
                        `Valor_Hora_Ordinaria` = @Valor_Hora_Ordinaria,
                        `Fecha_Ultima_Actualizacion` = @Fecha_Ultima_Actualizacion
                    WHERE `id` = @Id LIMIT 1;";
                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    AddParametroDecimal(cmd, "@Porcentaje_EPS", p.Porcentaje_EPS);
                    AddParametroDecimal(cmd, "@Porcentaje_Pension", p.Porcentaje_Pension);
                    AddParametroDecimal(cmd, "@Porcentaje_Fondo_Solidaridad", p.Porcentaje_Fondo_Solidaridad);
                    AddParametroDecimal(cmd, "@Recargo_Nocturno", p.Recargo_Nocturno);
                    AddParametroDecimal(cmd, "@Recargo_HE_Diurna", p.Recargo_HE_Diurna);
                    AddParametroDecimal(cmd, "@Recargo_HE_Nocturna", p.Recargo_HE_Nocturna);
                    AddParametroDecimal(cmd, "@Recargo_Dominical", p.Recargo_Dominical);
                    AddParametroDecimal(cmd, "@Recargo_HE_Dominical", p.Recargo_HE_Dominical);
                    AddParametroDecimal(cmd, "@Recargo_HE_Dominical_Nocturna", p.Recargo_HE_Dominical_Nocturna);
                    AddParametroDecimal(cmd, "@SMMLV", p.SMMLV);
                    AddParametroDecimal(cmd, "@Auxilio_Transporte", p.Auxilio_Transporte);
                    AddParametroDecimal(cmd, "@Valor_Hora_Ordinaria", p.Valor_Hora_Ordinaria);
                    cmd.Parameters.AddWithValue("@Fecha_Ultima_Actualizacion", (object)p.Fecha_Ultima_Actualizacion ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database update (configuracion_nomina) failed: " + ex.Message, ex);
                    }
                }
            }
            else
            {
                string sql = @"
                    INSERT INTO `configuracion_nomina` (
                        `Porcentaje_EPS`,`Porcentaje_Pension`,`Porcentaje_Fondo_Solidaridad`,
                        `Recargo_Nocturno`,`Recargo_HE_Diurna`,`Recargo_HE_Nocturna`,
                        `Recargo_Dominical`,`Recargo_HE_Dominical`,`Recargo_HE_Dominical_Nocturna`,
                        `SMMLV`,`Auxilio_Transporte`,`Valor_Hora_Ordinaria`,`Fecha_Ultima_Actualizacion`
                    ) VALUES (
                        @Porcentaje_EPS,@Porcentaje_Pension,@Porcentaje_Fondo_Solidaridad,
                        @Recargo_Nocturno,@Recargo_HE_Diurna,@Recargo_HE_Nocturna,
                        @Recargo_Dominical,@Recargo_HE_Dominical,@Recargo_HE_Dominical_Nocturna,
                        @SMMLV,@Auxilio_Transporte,@Valor_Hora_Ordinaria,@Fecha_Ultima_Actualizacion
                    );";
                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    AddParametroDecimal(cmd, "@Porcentaje_EPS", p.Porcentaje_EPS);
                    AddParametroDecimal(cmd, "@Porcentaje_Pension", p.Porcentaje_Pension);
                    AddParametroDecimal(cmd, "@Porcentaje_Fondo_Solidaridad", p.Porcentaje_Fondo_Solidaridad);
                    AddParametroDecimal(cmd, "@Recargo_Nocturno", p.Recargo_Nocturno);
                    AddParametroDecimal(cmd, "@Recargo_HE_Diurna", p.Recargo_HE_Diurna);
                    AddParametroDecimal(cmd, "@Recargo_HE_Nocturna", p.Recargo_HE_Nocturna);
                    AddParametroDecimal(cmd, "@Recargo_Dominical", p.Recargo_Dominical);
                    AddParametroDecimal(cmd, "@Recargo_HE_Dominical", p.Recargo_HE_Dominical);
                    AddParametroDecimal(cmd, "@Recargo_HE_Dominical_Nocturna", p.Recargo_HE_Dominical_Nocturna);
                    AddParametroDecimal(cmd, "@SMMLV", p.SMMLV);
                    AddParametroDecimal(cmd, "@Auxilio_Transporte", p.Auxilio_Transporte);
                    AddParametroDecimal(cmd, "@Valor_Hora_Ordinaria", p.Valor_Hora_Ordinaria);
                    cmd.Parameters.AddWithValue("@Fecha_Ultima_Actualizacion", (object)p.Fecha_Ultima_Actualizacion ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database insert (configuracion_nomina) failed: " + ex.Message, ex);
                    }
                }
            }
        }

        // helper to add decimal parameters as DBNull when null
        private static void AddParametroDecimal(MySqlCommand cmd, string name, decimal? value)
        {
            cmd.Parameters.AddWithValue(name, (object)value ?? DBNull.Value);
        }

        // helper: check reader has column (safe for variations in column name)
        private static bool ColumnExists(MySqlDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName) >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}