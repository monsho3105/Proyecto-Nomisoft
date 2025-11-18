using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{

    public partial class Ver_Emple : Form
    {

        // core columns that must be visible by default
        private readonly string[] coreColumns = { "Nombre", "Documento", "Cargo", "Salario", "Estado" };

        // aliases for possible DataTable column names for each logical column
        private readonly Dictionary<string, string[]> ColumnAliases = new Dictionary<string, string[]>
        {
            { "Tipo_Documento", new[] { "Tipo_Documento", "TipoDocumento", "Tipo de Documento", "TipoDocumento" } },
            { "Numero_Hijos", new[] { "Numero_Hijos", "NumeroHijos", "Numero de Hijos", "Numero de Hijos" } },
            { "Telefono", new[] { "Telefono", "Teléfono", "Telefono" } },
            { "Correo", new[] { "Correo", "Correo_Electronico", "Email", "Correo Electronico" } },
            { "Estado_Civil", new[] { "Estado_Civil", "EstadoCivil", "Estado Civil" } },
            { "Direccion", new[] { "Direccion", "Dirección", "Address" } },
            { "Cargo", new[] { "Cargo", "Puesto" } },
            { "Fecha_Nacimiento", new[] { "Fecha_Nacimiento", "FechaNacimiento", "Fecha de Nacimiento" } },
            { "Fecha_Ingreso", new[] { "Fecha_Ingreso", "FechaIngreso", "Fecha de Ingreso" } }
        };

        public Ver_Emple()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // sin bordes ni título
            this.TopLevel = false; // ya lo tienes
            this.Text = ""; // opcional, borra el texto del título

        }

        private void Ver_Emple_Load(object sender, EventArgs e)
        {
            try
            {
                var conexion = new Conexion();

                // Populate combo boxes from DB using the strongly-typed Designer controls
                // - comboBox_Departamento is the control you requested to populate from "departamento" column
                var deps = conexion.ObtenerDepartamentos();
                deps.Insert(0, ""); // allow empty selection (no filter)
                comboBox_Departamento.DataSource = deps;

                var cargos = conexion.ObtenerCargos();
                cargos.Insert(0, "");
                comboBox_Cargo.DataSource = cargos;

                var estados = conexion.ObtenerEstadosCiviles();
                estados.Insert(0, "");
                combo_Estado_Civil.DataSource = estados;

                // salario options (kept in Designer as comboBox_Salario_Base)
                if (comboBox_Salario_Base.Items.Count == 0)
                {
                    comboBox_Salario_Base.Items.AddRange(new object[] {
                        "", "1.400.000 - 1.999.999", "2.000.000 - 2.999.999", "3.000.000 - 4.999.999", "+ 5.000.000"
                    });
                }

                // ensure the empty entry is selected by default (no filter)
                if (comboBox_Salario_Base.Items.Count > 0)
                    comboBox_Salario_Base.SelectedIndex = 0;

                // optional: prevent typing so only the provided options can be chosen
                comboBox_Salario_Base.DropDownStyle = ComboBoxStyle.DropDownList;

                // Helper to read current control values and refresh the grid
                Action refreshGrid = () =>
                {
                    // Nombre and Documento filters are not present in this Designer; pass null for them.
                    string nombre = null;
                    string documento = null;
                    var departamento = comboBox_Departamento.SelectedItem as string;
                    var cargo = comboBox_Cargo.SelectedItem as string;
                    var estado = combo_Estado_Civil.SelectedItem as string;
                    var salario = comboBox_Salario_Base.SelectedItem as string;

                    // Pass the raw textbox contents as filter strings.
                    string fechaIngresoFilter = string.IsNullOrWhiteSpace(textBox_Fecha_Ingreso.Text)
                        ? null
                        : textBox_Fecha_Ingreso.Text.Trim();

                    string fechaNacimientoFilter = string.IsNullOrWhiteSpace(textBox_Fecha_Nacimiento.Text)
                        ? null
                        : textBox_Fecha_Nacimiento.Text.Trim();

                    // Try parse Numero_Hijos textbox; if parse succeeds pass the int, otherwise null (no numeric filter)
                    int? numeroHijos = null;
                    if (!string.IsNullOrWhiteSpace(textBox_Numero_Hijos.Text))
                    {
                        if (int.TryParse(textBox_Numero_Hijos.Text.Trim(), out var parsedHijos))
                        {
                            numeroHijos = parsedHijos;
                        }
                    }

                    // If any of the seguridad_social checkboxes are checked, request the joined data
                    bool includeSeguridad = (checkBox_EPS?.Checked == true) || (checkBox_Fondo_P?.Checked == true) || (checkBox_Fondo_C?.Checked == true);

                    DataTable dt;
                    dt = conexion.ObtenerResumenEmpleados(
                        nombre, documento, departamento, cargo, estado, salario,
                        fechaIngresoFilter, fechaNacimientoFilter, numeroHijos);

                    // If user requested seguridad columns, enrich the DataTable by looking up seguridad_social per documento
                    if (includeSeguridad)
                    {
                        // add columns if missing
                        if (!dt.Columns.Contains("EPS")) dt.Columns.Add("EPS", typeof(string));
                        if (!dt.Columns.Contains("Fondo_Pension")) dt.Columns.Add("Fondo_Pension", typeof(string));
                        if (!dt.Columns.Contains("Fondo_Cesantias")) dt.Columns.Add("Fondo_Cesantias", typeof(string));

                        // populate security columns per employee using existing Conexion.Buscar_Seguridad_Social
                        foreach (DataRow row in dt.Rows)
                        {
                            var docObj = row.Table.Columns.Contains("Documento") ? row["Documento"] : null;
                            if (docObj == null || docObj == DBNull.Value) continue;

                            string numeroDocumento = docObj.ToString();
                            var ss = conexion.Buscar_Seguridad_Social(numeroDocumento);
                            row["EPS"] = ss?.Eps ?? string.Empty;
                            row["Fondo_Pension"] = ss?.Fondo_Pension ?? string.Empty;
                            row["Fondo_Cesantias"] = ss?.Fondo_Cesantias ?? string.Empty;
                        }
                    }

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;

                    if (dataGridView1.Columns["Salario"] != null)
                    {
                        dataGridView1.Columns["Salario"].DefaultCellStyle.Format = "N2";
                        dataGridView1.Columns["Salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Rename seguridad_social columns to friendly headers if present
                    if (dataGridView1.Columns.Contains("EPS"))
                        dataGridView1.Columns["EPS"].HeaderText = "EPS";
                    if (dataGridView1.Columns.Contains("Fondo_Pension"))
                        dataGridView1.Columns["Fondo_Pension"].HeaderText = "Fondo Pensión";
                    if (dataGridView1.Columns.Contains("Fondo_Cesantias"))
                        dataGridView1.Columns["Fondo_Cesantias"].HeaderText = "Fondo Cesantías";

                    if (dataGridView1.Columns["Nombre"] != null) dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
                    if (dataGridView1.Columns["Documento"] != null) dataGridView1.Columns["Documento"].HeaderText = "Documento";
                    if (dataGridView1.Columns["Cargo"] != null) dataGridView1.Columns["Cargo"].HeaderText = "Cargo";
                    if (dataGridView1.Columns["Estado"] != null) dataGridView1.Columns["Estado"].HeaderText = "Estado";

                    // Ensure default visibility: show core columns, hide the rest (until checkboxes enable them)
                    EnsureDefaultColumnVisibility();
                };

                // Wire real-time updates: update whenever selection changes or the text changes
                comboBox_Departamento.SelectedIndexChanged += (s, ev) => refreshGrid();
                comboBox_Cargo.SelectedIndexChanged += (s, ev) => refreshGrid();
                combo_Estado_Civil.SelectedIndexChanged += (s, ev) => refreshGrid();
                comboBox_Salario_Base.SelectedIndexChanged += (s, ev) => refreshGrid();
                textBox_Fecha_Ingreso.TextChanged += (s, ev) => refreshGrid();
                textBox_Fecha_Nacimiento.TextChanged += (s, ev) => refreshGrid();
                textBox_Numero_Hijos.TextChanged += (s, ev) => refreshGrid();

                // wire seguridad_social checkboxes to refresh grid when toggled
                if (checkBox_EPS != null) checkBox_EPS.CheckedChanged += (s, ev) => refreshGrid();
                if (checkBox_Fondo_P != null) checkBox_Fondo_P.CheckedChanged += (s, ev) => refreshGrid();
                if (checkBox_Fondo_C != null) checkBox_Fondo_C.CheckedChanged += (s, ev) => refreshGrid();

                // Initial load (no filters)
                refreshGrid();

                // After initial binding wire checkboxes and set their initial checked state
                // Checkbox controls will reflect whether their column is visible after initial load.
                // Attach handlers now so initial check assignments don't fire update multiple times.
                checkBox_Tipo_Documento.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Numero_Hijos.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Telefono.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBoxCorreo_Electronico.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Estado_Civil.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Direccion.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Cargo.CheckedChanged += (s, ev) => UpdateColumnsVisibility();
                checkBox_Fecha_Nacimiento.CheckedChanged += (s, ev) => UpdateColumnsVisibility();

                // initialize checkbox states to reflect default visibility:
                // core columns -> checked (visible), optional columns -> unchecked (hidden)
                SetInitialCheckboxStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Changed fechaIngreso/fechaNacimiento parameter types to string so partial inputs like "2022" are forwarded.
        private void LoadGrid(Conexion conexion, string nombre, string documento, string departamento, string cargo, string estado, string salarioRange, string fechaIngreso = null, string fechaNacimiento = null, int? numeroHijos = null)
        {
            DataTable dt = conexion.ObtenerResumenEmpleados(
                nombre, documento, departamento, cargo, estado, salarioRange,
                fechaIngreso, fechaNacimiento, numeroHijos);

            dataGridView1.DataSource = dt;

            // Basic formatting
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            if (dataGridView1.Columns["Salario"] != null)
            {
                dataGridView1.Columns["Salario"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["Salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dataGridView1.Columns["Nombre"] != null) dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
            if (dataGridView1.Columns["Documento"] != null) dataGridView1.Columns["Documento"].HeaderText = "Documento";
            if (dataGridView1.Columns["Cargo"] != null) dataGridView1.Columns["Cargo"].HeaderText = "Cargo";
            if (dataGridView1.Columns["Estado"] != null) dataGridView1.Columns["Estado"].HeaderText = "Estado";

            // Ensure default visibility: show core columns, hide the rest (until checkboxes enable them)
            EnsureDefaultColumnVisibility();
        }

        // show core columns and hide everything else (if present in the grid)
        private void EnsureDefaultColumnVisibility()
        {
            if (dataGridView1.Columns == null) return;

            // hide all first
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Visible = false;

            // show core columns when present
            foreach (var core in coreColumns)
            {
                var found = FindExistingColumnName(core);
                if (found != null)
                    dataGridView1.Columns[found].Visible = true;
            }
        }

        // Set checkbox initial checked state to reflect visible core/optional columns
        private void SetInitialCheckboxStates()
        {
            // For checkboxes that represent core columns (Cargo) set to true if the column exists and is visible
            checkBox_Cargo.Checked = IsAnyAliasVisible("Cargo");

            // Optional columns default to unchecked (hidden) unless the column wasn't returned (no-op)
            checkBox_Tipo_Documento.Checked = IsAnyAliasVisible("Tipo_Documento");
            checkBox_Numero_Hijos.Checked = IsAnyAliasVisible("Numero_Hijos");
            checkBox_Telefono.Checked = IsAnyAliasVisible("Telefono");
            checkBoxCorreo_Electronico.Checked = IsAnyAliasVisible("Correo");
            checkBox_Estado_Civil.Checked = IsAnyAliasVisible("Estado_Civil");
            checkBox_Direccion.Checked = IsAnyAliasVisible("Direccion");
            checkBox_Fecha_Nacimiento.Checked = IsAnyAliasVisible("Fecha_Nacimiento");

            // After setting checkbox states, call UpdateColumnsVisibility to apply them (this will show/hide optional columns)
            UpdateColumnsVisibility();
        }

        // Returns true if any alias for logicalName exists in grid and is currently visible
        private bool IsAnyAliasVisible(string logicalName)
        {
            var alias = FindExistingColumnName(logicalName);
            if (alias == null) return false;
            return dataGridView1.Columns[alias].Visible;
        }

        // Find the actual DataGridView column name that matches any alias for logicalName.
        // Returns the first match or null.
        private string FindExistingColumnName(string logicalName)
        {
            string[] aliases;
            if (!ColumnAliases.TryGetValue(logicalName, out aliases))
                aliases = new[] { logicalName };

            foreach (var a in aliases)
            {
                if (dataGridView1.Columns.Contains(a))
                    return a;
            }

            // also check for exact logicalName as a fallback
            if (dataGridView1.Columns.Contains(logicalName))
                return logicalName;

            return null;
        }

        // Toggle visibility for expected column names; safe no-op if a column doesn't exist.
        private void UpdateColumnsVisibility()
        {
            // core columns remain visible regardless of checkbox (required by spec)
            foreach (var core in coreColumns)
            {
                var found = FindExistingColumnName(core);
                if (found != null)
                    dataGridView1.Columns[found].Visible = true;
            }

            // optional columns follow their checkboxes
            SetColumnVisibility("Tipo_Documento", checkBox_Tipo_Documento.Checked);
            SetColumnVisibility("Numero_Hijos", checkBox_Numero_Hijos.Checked);
            SetColumnVisibility("Telefono", checkBox_Telefono.Checked);
            SetColumnVisibility("Correo", checkBoxCorreo_Electronico.Checked);
            SetColumnVisibility("Estado_Civil", checkBox_Estado_Civil.Checked);
            SetColumnVisibility("Direccion", checkBox_Direccion.Checked);
            // Allow Cargo checkbox to also toggle cargo (it starts visible because it's core)
            SetColumnVisibility("Cargo", checkBox_Cargo.Checked);
            SetColumnVisibility("Fecha_Nacimiento", checkBox_Fecha_Nacimiento.Checked);
            // If Fecha_Ingreso column exists and you want a checkbox for it, map it too (no checkbox in Designer now)
        }

        private void SetColumnVisibility(string logicalName, bool visible)
        {
            var found = FindExistingColumnName(logicalName);
            if (found != null)
                dataGridView1.Columns[found].Visible = visible;
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            Admin_Menu back = new Admin_Menu();
            back.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox_Fecha_Ingreso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
