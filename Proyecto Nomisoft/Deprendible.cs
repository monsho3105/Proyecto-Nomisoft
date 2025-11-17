using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Deprendible : Form
    {
        // cache full result for local filtering
        private DataTable _nominasTable;

        public Deprendible()
        {
            InitializeComponent();

            // wire textbox filter safely
            if (this.textBox_Documento != null)
            {
                this.textBox_Documento.TextChanged -= textBox_Documento_TextChanged;
                this.textBox_Documento.TextChanged += textBox_Documento_TextChanged;
            }

            // wire regresar button if present
            if (this.button_Regresar != null)
            {
                this.button_Regresar.Click -= button_Regresar_Click;
                this.button_Regresar.Click += button_Regresar_Click;
            }

            LoadNominas();
        }

        private void LoadNominas()
        {
            try
            {
                var conexion = new Conexion();
                _nominasTable = conexion.ObtenerResumenNominasTabla();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _nominasTable;

                // show only requested columns and make them fill the grid width
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.Visible = c.Name == "Numero_Documento" || c.Name == "Periodo" || c.Name == "Neto_Pagar";
                    // ensure no wrapping so row height is stable
                    c.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    c.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                }

                // layout: occupy entire width
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.ScrollBars = ScrollBars.Vertical;

                // set proportional column widths with FillWeight
                if (dataGridView1.Columns.Contains("Numero_Documento"))
                {
                    var c = dataGridView1.Columns["Numero_Documento"];
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    c.FillWeight = 35; // percent-like weight
                    c.HeaderText = "Documento";
                }

                if (dataGridView1.Columns.Contains("Periodo"))
                {
                    var c = dataGridView1.Columns["Periodo"];
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    c.FillWeight = 20;
                    c.HeaderText = "Periodo";
                }

                if (dataGridView1.Columns.Contains("Neto_Pagar"))
                {
                    var c = dataGridView1.Columns["Neto_Pagar"];
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    c.FillWeight = 45;
                    c.HeaderText = "Neto Pagar";
                    c.DefaultCellStyle.Format = "N2";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando desprendibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // live filter by Numero_Documento
        private void textBox_Documento_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(textBox_Documento.Text);
        }

        private void ApplyFilter(string filterText)
        {
            if (_nominasTable == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            var txt = (filterText ?? string.Empty).Trim();
            var dv = _nominasTable.DefaultView;

            if (string.IsNullOrEmpty(txt))
            {
                dv.RowFilter = string.Empty;
                dataGridView1.DataSource = dv;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                return;
            }

            // escape single quote
            var escaped = txt.Replace("'", "''");
            dv.RowFilter = $"Convert(Numero_Documento, 'System.String') LIKE '%{escaped}%'";
            dataGridView1.DataSource = dv;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }

        private void button_Regresar_Click_1(object sender, EventArgs e)
        {
            button_Regresar_Click(sender, e);
        }

        private void button_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
