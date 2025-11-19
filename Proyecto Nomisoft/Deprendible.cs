using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;

namespace Proyecto_Nomisoft
{
    public partial class Deprendible : Form
    {
        private DataTable _nominasTable;
        private string _initialDocumento; // filter value provided from login

        public Deprendible()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Zoom; // o Stretch si prefieres
            if (this.textBox_Documento != null)
            {
                this.textBox_Documento.TextChanged -= textBox_Documento_TextChanged;
                this.textBox_Documento.TextChanged += textBox_Documento_TextChanged;
            }

            if (this.button_Regresar != null)
            {
                this.button_Regresar.Click -= button_Regresar_Click;
                this.button_Regresar.Click += button_Regresar_Click;
            }

            if (this.button_Imprimir != null)
            {
                this.button_Imprimir.Click -= button_Imprimir_Click_1;
                this.button_Imprimir.Click += button_Imprimir_Click_1;
            }

            LoadNominas();
        }

        // New overload: allow caller (login) to pass the Numero_Documento to pre-filter the grid
        public Deprendible(string numeroDocumento) : this()
        {
            _initialDocumento = (numeroDocumento ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(_initialDocumento))
            {
                // pre-fill the Periodo textbox is left to the user; we apply the document-only filter now
                ApplyFilter(string.Empty);
            }
        }

        private void LoadNominas()
        {
            try
            {
                var conexion = new Conexion();
                _nominasTable = conexion.ObtenerResumenNominasTabla();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _nominasTable;

                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.Visible = c.Name == "Numero_Documento" || c.Name == "Periodo" || c.Name == "Neto_Pagar";
                    c.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    c.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                }

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.ScrollBars = ScrollBars.Vertical;

                if (dataGridView1.Columns.Contains("Numero_Documento"))
                {
                    var c = dataGridView1.Columns["Numero_Documento"];
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    c.FillWeight = 35;
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

                // If an initial document filter was provided before LoadNominas completed,
                // ensure filter is applied now (safety if constructor ordering changed).
                if (!string.IsNullOrEmpty(_initialDocumento))
                {
                    ApplyFilter(string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando desprendibles: " + ex.Message);
            }
        }

        private void textBox_Documento_TextChanged(object sender, EventArgs e)
        {
            // textBox_Documento is used to filter by Periodo (per request)
            ApplyFilter(textBox_Documento.Text);
        }

        // ApplyFilter now combines initial Documento equality (if provided) AND Periodo LIKE (from textbox)
        private void ApplyFilter(string periodoFilter)
        {
            if (_nominasTable == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            var dv = _nominasTable.DefaultView;
            string docFilter = string.Empty;
            string periodo = (periodoFilter ?? string.Empty).Trim();

            if (!string.IsNullOrEmpty(_initialDocumento))
            {
                // exact match on Numero_Documento
                var escapedDoc = _initialDocumento.Replace("'", "''");
                docFilter = $"Convert(Numero_Documento, 'System.String') = '{escapedDoc}'";
            }

            string periodoClause = string.Empty;
            if (!string.IsNullOrEmpty(periodo))
            {
                var escapedPeriodo = periodo.Replace("'", "''");
                periodoClause = $"Convert(Periodo, 'System.String') LIKE '%{escapedPeriodo}%'";
            }

            if (!string.IsNullOrEmpty(docFilter) && !string.IsNullOrEmpty(periodoClause))
                dv.RowFilter = $"{docFilter} AND {periodoClause}";
            else if (!string.IsNullOrEmpty(docFilter))
                dv.RowFilter = docFilter;
            else if (!string.IsNullOrEmpty(periodoClause))
                dv.RowFilter = periodoClause;
            else
                dv.RowFilter = string.Empty;

            dataGridView1.DataSource = dv;
        }

        private void button_Regresar_Click(object sender, EventArgs e)
        {
            login back = new login();
            back.Show();
            this.Close();
        }

        // keep existing imprimir logic in one place; Designer currently hooks the _Click_1 handler,
        // so forward that to the main implementation.
        private void button_Imprimir_Click_1(object sender, EventArgs e)
        {
            button_Imprimir_Click(sender, e);
        }

        private void button_Imprimir_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Seleccione una nómina en la tabla primero.");
                    return;
                }

                string numero = null;
                string periodo = null;

                if (dataGridView1.Columns.Contains("Numero_Documento"))
                    numero = Convert.ToString(row.Cells["Numero_Documento"].Value);

                if (dataGridView1.Columns.Contains("Periodo"))
                    periodo = Convert.ToString(row.Cells["Periodo"].Value);

                numero = (numero ?? "").Trim();
                periodo = (periodo ?? "").Trim();

                if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(periodo))
                {
                    MessageBox.Show("No se pudo determinar Documento o Periodo.");
                    return;
                }

                var conexion = new Conexion();
                var nomina = conexion.Buscar_Nomina(numero, periodo);
                if (nomina == null)
                {
                    MessageBox.Show("No se encontró la nómina.");
                    return;
                }

                var emp = conexion.Buscar_Empleado(numero);

                GenerarPDF(nomina, emp);

                MessageBox.Show("PDF generado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando PDF: " + ex.Message);
            }
        }

        internal void GenerarPDF(Conexion.Nomina nomina, Conexion.Empleado emp)
        {
            string folder = @"C:\Users\yeiso\Desktop\NOMISOFT\Desprendibles";
            string docPart = SanitizeFileName(nomina?.Numero_Documento ?? "unknown");
            string periodoPart = SanitizeFileName(nomina?.Periodo ?? "unknown");
            string ruta = Path.Combine(folder, $"Desprendible_{docPart}_{periodoPart}.pdf");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font subTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font texto = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            Document doc = new Document(PageSize.LETTER);
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            Paragraph encabezado = new Paragraph("DESPRENDIBLE DE NÓMINA\n\n", titulo);
            encabezado.Alignment = Element.ALIGN_CENTER;
            doc.Add(encabezado);

            string nombreEmpleado = emp == null ? "" :
                string.Join(" ", new[] {
                        emp.Primer_Nombre, emp.Segundo_Nombre,
                        emp.Primer_Apellido, emp.Segundo_Apellido
                }.Where(p => !string.IsNullOrWhiteSpace(p)));

            PdfPTable tablaEmpleado = new PdfPTable(2);
            tablaEmpleado.WidthPercentage = 100;
            tablaEmpleado.SetWidths(new float[] { 30, 70 });

            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Empleado:", subTitulo)) { Border = 0 });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase(nombreEmpleado, texto)) { Border = 0 });

            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Documento:", subTitulo)) { Border = 0 });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase(nomina?.Numero_Documento ?? "", texto)) { Border = 0 });

            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Cargo:", subTitulo)) { Border = 0 });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase(emp?.Cargo ?? "", texto)) { Border = 0 });

            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Periodo:", subTitulo)) { Border = 0 });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase(nomina?.Periodo ?? "", texto)) { Border = 0 });

            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Fecha Creación:", subTitulo)) { Border = 0 });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase(nomina?.Fecha_Creacion?.ToString("yyyy-MM-dd HH:mm") ?? "", texto)) { Border = 0 });

            doc.Add(tablaEmpleado);
            doc.Add(new Paragraph("\n"));

            doc.Add(new Paragraph("DETALLE NÓMINA (todos los campos)", subTitulo));
            doc.Add(new Paragraph("\n"));

            string[] orderedNames = new[] {
                    "Fecha_Creacion","Dias_Diurnos","Valor_Dias","Dias_Nocturnos","Valor_Dias_Nocturnos",
                    "Dias_Festivos","Valor_Dias_Festivos","Horas_Extras_Diurnas","Valor_Horas_Extras_Diurnas",
                    "Horas_Extras_Nocturnas","Valor_Horas_Extras_Nocturnas","Horas_Extras_Festivas_Diurnas",
                    "Valor_Horas_Extras_Festivas_Diurnas","Horas_Extras_Festivas_Nocturnas",
                    "Valor_Horas_Extras_Festivas_Nocturnas","Bonificaciones","Comisiones",
                    "Auxilio_Transporte","Deducciones","Aporte_Salud","Aporte_Pension",
                    "Total_Devengado","Total_Deducciones","Neto_Pagar","Estado"
                };

            PdfPTable tablaDetalle = new PdfPTable(2);
            tablaDetalle.WidthPercentage = 100;
            tablaDetalle.SetWidths(new float[] { 60, 40 });

            var nominaType = typeof(Conexion.Nomina);

            foreach (var name in orderedNames)
            {
                var prop = nominaType.GetProperty(name);
                if (prop == null) continue;

                object val = prop.GetValue(nomina);

                string displayName = name.Replace('_', ' ');
                string displayValue;

                string[] quantityFields =
                {
                        "Dias_Diurnos",
                        "Dias_Nocturnos",
                        "Dias_Festivos",
                        "Horas_Extras_Diurnas",
                        "Horas_Extras_Nocturnas",
                        "Horas_Extras_Festivas_Diurnas",
                        "Horas_Extras_Festivas_Nocturnas"
                    };

                var propType = prop.PropertyType;
                var coreType = Nullable.GetUnderlyingType(propType) ?? propType;
                bool isNumericType = coreType == typeof(decimal) || coreType == typeof(double) ||
                                     coreType == typeof(float) || coreType == typeof(int) ||
                                     coreType == typeof(long) || coreType == typeof(short);

                if (val == null)
                {
                    if (isNumericType)
                    {
                        decimal zero = 0m;
                        displayValue = quantityFields.Contains(name) ? zero.ToString("N2") : zero.ToString("C");
                    }
                    else
                    {
                        displayValue = "";
                    }
                }
                else if (val is decimal || val is decimal?)
                {
                    decimal d = Convert.ToDecimal(val);
                    if (quantityFields.Contains(name))
                        displayValue = d.ToString("N2");
                    else
                        displayValue = d.ToString("C");
                }
                else if (val is DateTime dt)
                {
                    displayValue = dt.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    var s = val as string;
                    if (isNumericType && string.IsNullOrWhiteSpace(s))
                    {
                        decimal zero = 0m;
                        displayValue = quantityFields.Contains(name) ? zero.ToString("N2") : zero.ToString("C");
                    }
                    else
                    {
                        displayValue = val.ToString();
                    }
                }

                var dotted = new DottedLineSeparator() { Gap = 2f, Offset = -1f };
                Phrase leaderPhrase = new Phrase();
                leaderPhrase.Add(new Chunk(displayName + " ", subTitulo));
                leaderPhrase.Add(new Chunk(dotted));
                leaderPhrase.Add(new Chunk(" " + displayValue, texto));

                PdfPCell leaderCell = new PdfPCell(leaderPhrase)
                {
                    Border = Rectangle.NO_BORDER,
                    Padding = 4,
                    Colspan = 2
                };

                tablaDetalle.AddCell(leaderCell);
            }

            doc.Add(tablaDetalle);
            doc.Add(new Paragraph("\n"));

            doc.Close();
        }

        private static string SanitizeFileName(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "unknown";
            var invalid = Path.GetInvalidFileNameChars();
            return new string(input.Select(ch => invalid.Contains(ch) ? '_' : ch).ToArray())
                .Replace(' ', '_')
                .Trim();
        }

        private void Deprendible_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_Documento_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}