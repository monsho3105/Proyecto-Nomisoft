using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Liquidar_Nomina : Form
    {
        // keep full result so we can filter locally
        private DataTable _nominasTable;

        public Liquidar_Nomina()
        {
            InitializeComponent();

            // wire textbox filter
            if (this.textBox_Identificacion != null)
            {
                this.textBox_Identificacion.TextChanged -= textBox_Identificacion_TextChanged;
                this.textBox_Identificacion.TextChanged += textBox_Identificacion_TextChanged;
            }

            // wire liquidar button click (safe: remove old handler then add)
            if (this.button_Liquidar != null)
            {
                this.button_Liquidar.Click -= button_Liquidar_Click;
                this.button_Liquidar.Click += button_Liquidar_Click;
            }

            LoadNominasPorLiquidar();
        }

        private void LoadNominasPorLiquidar()
        {
            try
            {
                var conexion = new Conexion();
                // Use the correct parameter name: 'estado' is not valid, use 'estadoCivil' or another supported parameter
                DataTable dt = conexion.ObtenerResumenEmpleados(estadoCivil: "Por liquidar");

                _nominasTable = dt; // cache for filtering

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _nominasTable;

                // Size columns to their content so width adapts to text length
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Disable wrapping so column width reflects single-line text length
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                // Ensure horizontal scrollbar is available for navigation when total width exceeds viewport
                dataGridView1.ScrollBars = ScrollBars.Both;

                // Allow the user to resize columns if they want different widths
                dataGridView1.AllowUserToResizeColumns = true;

                // Keep row autosizing off to avoid tall rows when text is long
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando nóminas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Live filter handler
        private void textBox_Identificacion_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(textBox_Identificacion.Text);
        }

        // Filter nominas by Numero_Documento (case-insensitive substring)
        private void ApplyFilter(string filterText)
        {
            if (_nominasTable == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            var txt = (filterText ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(txt))
            {
                dataGridView1.DataSource = _nominasTable;
                // restore sizing
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                return;
            }

            var matched = _nominasTable.AsEnumerable()
                .Where(r =>
                {
                    var doc = Convert.ToString(r["Numero_Documento"]) ?? string.Empty;
                    return doc.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0;
                });

            var filtered = _nominasTable.Clone();
            foreach (var row in matched)
                filtered.ImportRow(row);

            dataGridView1.DataSource = filtered;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Click handler: mark selected nomina as Liquidado
        private void button_Liquidar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = null;
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                    row = dataGridView1.SelectedRows[0];
                else if (dataGridView1.CurrentRow != null)
                    row = dataGridView1.CurrentRow;

                if (row == null)
                {
                    MessageBox.Show("Seleccione una nómina en la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Prefer named columns, fallback to first columns
                string numero = null;
                string periodo = null;

                if (dataGridView1.Columns.Contains("Numero_Documento"))
                    numero = Convert.ToString(row.Cells["Numero_Documento"].Value);
                else if (row.Cells.Count > 0)
                    numero = Convert.ToString(row.Cells[0].Value);

                if (dataGridView1.Columns.Contains("Periodo"))
                    periodo = Convert.ToString(row.Cells["Periodo"].Value);
                else if (row.Cells.Count > 1)
                    periodo = Convert.ToString(row.Cells[1].Value);

                numero = (numero ?? string.Empty).Trim();
                periodo = (periodo ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(periodo))
                {
                    MessageBox.Show("No se pudo determinar Numero_Documento y/o Periodo de la nómina seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"¿Desea marcar la nómina {numero} / {periodo} como 'Liquidado'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var conexion = new Conexion();
                // conexion.ActualizarEstadoNomina(numero, periodo, "Liquidado");
                // Workaround: Use Editar_Nomina to update the state
                var nomina = conexion.Buscar_Nomina(numero, periodo);
                if (nomina == null)
                {
                    MessageBox.Show("No se encontró la nómina seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                nomina.Estado = "Liquidado";
                conexion.Editar_Nomina(nomina);

                MessageBox.Show("Estado actualizado a 'Liquidado'.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh grid
                LoadNominasPorLiquidar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al liquidar la nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }
    }
}
