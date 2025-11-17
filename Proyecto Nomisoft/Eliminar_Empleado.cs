using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Eliminar_Empleado : Form
    {
        // keep the full result so we can filter on every keystroke
        private DataTable _employeesTable;

        public Eliminar_Empleado()
        {
            InitializeComponent();
            LoadActiveEmployees();

            // Wire text change for live filtering (textBox1 is the Identificacion textbox in Designer)
            if (this.textBox_Identificacion != null)
            {
                this.textBox_Identificacion.TextChanged -= textBox1_TextChanged;
                this.textBox_Identificacion.TextChanged += textBox1_TextChanged;
            }

            // Wire delete button click
            if (this.button_Eliminar != null)
            {
                this.button_Eliminar.Click -= button_Eliminar_Click;
                this.button_Eliminar.Click += button_Eliminar_Click;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadActiveEmployees()
        {
            try
            {
                var conexion = new Conexion();
                var all = conexion.ObtenerResumenEmpleados(); // returns columns: Nombre, Documento, Cargo, Salario, Estado, Primer_Nombre, ...

                if (all == null || all.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    _employeesTable = null;
                    return;
                }

                // Filter rows where Estado == "Activo" (case-insensitive)
                var activeRows = all.AsEnumerable()
                    .Where(r => string.Equals(Convert.ToString(r["Estado"]), "Activo", StringComparison.OrdinalIgnoreCase));

                // Build a result table with the requested columns
                var result = new DataTable();
                result.Columns.Add("Numero_Documento", typeof(string));
                result.Columns.Add("Nombre", typeof(string));
                result.Columns.Add("Cargo", typeof(string));
                result.Columns.Add("Departamento", typeof(string));

                foreach (var r in activeRows)
                {
                    var doc = Convert.ToString(r["Documento"]) ?? string.Empty;
                    var nombre = Convert.ToString(r["Nombre"]) ?? string.Empty;
                    var cargo = Convert.ToString(r["Cargo"]) ?? string.Empty;
                    var departamento = Convert.ToString(r["Departamento"]) ?? string.Empty;

                    result.Rows.Add(doc, nombre, cargo, departamento);
                }

                _employeesTable = result;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _employeesTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Live filter handler
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(textBox_Identificacion.Text);
        }

        // Applies case-insensitive substring filter against Numero_Documento and Nombre
        private void ApplyFilter(string filterText)
        {
            if (_employeesTable == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            var txt = (filterText ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(txt))
            {
                dataGridView1.DataSource = _employeesTable;
                return;
            }

            var matched = _employeesTable.AsEnumerable()
                .Where(r =>
                {
                    var doc = (r.Field<string>("Numero_Documento") ?? string.Empty);
                    var nombre = (r.Field<string>("Nombre") ?? string.Empty);
                    return doc.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0
                        || nombre.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0;
                });

            var filtered = _employeesTable.Clone();
            foreach (var row in matched)
                filtered.ImportRow(row);

            dataGridView1.DataSource = filtered;
        }

        // New: when user clicks Eliminar, mark selected empleado as Inactivo
        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Determine selected row (prefer selected rows, fallback to current row)
                DataGridViewRow row = null;
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                    row = dataGridView1.SelectedRows[0];
                else if (dataGridView1.CurrentRow != null)
                    row = dataGridView1.CurrentRow;

                if (row == null)
                {
                    MessageBox.Show("Seleccione un empleado en la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Try to get Numero_Documento by column name, fallback to first cell
                string numero = null;
                if (row.Cells["Numero_Documento"] != null)
                    numero = Convert.ToString(row.Cells["Numero_Documento"].Value);
                else if (row.Cells.Count > 0)
                    numero = Convert.ToString(row.Cells[0].Value);

                numero = (numero ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(numero))
                {
                    MessageBox.Show("No se pudo determinar el número de documento del empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"¿Desea marcar al empleado con documento '{numero}' como Inactivo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var conexion = new Conexion();
                var nuevo = new Conexion.Empleado
                {
                    Numero_Documento = numero,
                    Estado = "Inactivo"
                };

                // Update only the Estado column
                conexion.Editar_Empleado(numero, nuevo, "Estado");

                MessageBox.Show("Empleado marcado como Inactivo.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the grid to remove the now-inactive record from active list
                LoadActiveEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Menu Back = new Admin_Menu();
            Back.Show();
            this.Hide();
        }
    }
}
