using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Proyecto_Nomisoft
{
    // Partial extension for Conexion: helpers for `seguridad_social` table
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
    }
}