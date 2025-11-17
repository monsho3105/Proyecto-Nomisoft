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

        public Deprendible()
        {
            InitializeComponent();

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
                this.button_Imprimir.Click -= button_Imprimir_Click;
                this.button_Imprimir.Click += button_Imprimir_Click;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando desprendibles: " + ex.Message);
            }
        }

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
                return;
            }

            var escaped = txt.Replace("'", "''");
            dv.RowFilter = $"Convert(Numero_Documento, 'System.String') LIKE '%{escaped}%'";
            dataGridView1.DataSource = dv;
        }

        private void button_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            string[] orderedNames = new[]
            {
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

                if (val == null)
                {
                    displayValue = "";
                }
                else if (val is decimal || val is decimal?)
                {
                    decimal d = Convert.ToDecimal(val);

                    // No "$" for these fields
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

                    if (quantityFields.Contains(name))
                        displayValue = d.ToString("N2");  // no $
                    else
                        displayValue = d.ToString("C");   // with $
                }
                else if (val is DateTime dt)
                {
                    displayValue = dt.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    displayValue = val.ToString();
                }

                // Create a single cell that contains: left text, dotted leader, right text
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
    }
}
