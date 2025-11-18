using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Parametros : Form
    {
        private DataTable _configTable;

        public Parametros()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // sin bordes ni título
            this.TopLevel = false; // ya lo tienes
            this.Text = ""; // opcional, borra el texto del título


            // wire save button
            if (this.button_Guardar != null)
            {
                this.button_Guardar.Click -= button_Guardar_Click;
                this.button_Guardar.Click += button_Guardar_Click;
            }

            LoadConfiguracionNomina();
        }

        private void LoadConfiguracionNomina()
        {
            try
            {
                var conexion = new Conexion();
                DataTable dt = conexion.ObtenerConfiguracionNominaTabla();

                _configTable = dt;

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _configTable;

                // Size to content and enable horizontal scrolling
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.ScrollBars = ScrollBars.Both;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }

        // Save changes from the DataGridView back to the DB
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var conexion = new Conexion();

                // Use the currently bound table (may be _configTable)
                var dt = dataGridView1.DataSource as DataTable ?? _configTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay configuración para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Iterate rows and map to DTO then save
                foreach (DataRow row in dt.Rows)
                {
                    var p = new Conexion.ParametrosNomina();

                    // Id (if present)
                    if (dt.Columns.Contains("id") && row["id"] != DBNull.Value)
                    {
                        int idVal;
                        if (int.TryParse(row["id"].ToString(), out idVal)) p.Id = idVal;
                    }

                    p.Porcentaje_EPS = GetDecimal(row, "Porcentaje_EPS");
                    p.Porcentaje_Pension = GetDecimal(row, "Porcentaje_Pension");
                    p.Porcentaje_Fondo_Solidaridad = GetDecimal(row, "Porcentaje_Fondo_Solidaridad");
                    p.Recargo_Nocturno = GetDecimal(row, "Recargo_Nocturno");
                    p.Recargo_HE_Diurna = GetDecimal(row, "Recargo_HE_Diurna");
                    p.Recargo_HE_Nocturna = GetDecimal(row, "Recargo_HE_Nocturna");
                    p.Recargo_Dominical = GetDecimal(row, "Recargo_Dominical");
                    p.Recargo_HE_Dominical = GetDecimal(row, "Recargo_HE_Dominical");
                    p.Recargo_HE_Dominical_Nocturna = GetDecimal(row, "Recargo_HE_Dominical_Nocturna");
                    p.SMMLV = GetDecimal(row, "SMMLV");
                    p.Auxilio_Transporte = GetDecimal(row, "Auxilio_Transporte");
                    p.Valor_Hora_Ordinaria = GetDecimal(row, "Valor_Hora_Ordinaria");

                    // Guardar_Parametros will set Fecha_Ultima_Actualizacion itself
                    conexion.Guardar_Parametros(p);
                }

                MessageBox.Show("Configuración guardada correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload to reflect DB values (and IDs)
                LoadConfiguracionNomina();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static decimal? GetDecimal(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName)) return null;
            var val = row[columnName];
            if (val == null || val == DBNull.Value) return null;

            var s = val.ToString().Trim();
            decimal parsed;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out parsed)) return parsed;

            // Fallback replacing comma with dot and invariant culture
            var norm = s.Replace(',', '.');
            if (decimal.TryParse(norm, NumberStyles.Number, CultureInfo.InvariantCulture, out parsed)) return parsed;

            return null;
        }

        private void Parametros_Load(object sender, EventArgs e)
        {

        }
    }
}
