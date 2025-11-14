using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace Proyecto_Nomisoft
{
    public partial class Crear_Nomina : Form
    {
        private dynamic configuracion_nomina;

        public Crear_Nomina()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Example: assign configuracion_nomina from a global/static config, or create a stub
            // Replace this with your actual configuration retrieval logic
            configuracion_nomina = new { Recargo_Nocturno = 0.35m, Recargo_Dominical = 0.75m, Recargo_HE_Diurna = 0.25m };

            // wire the crear button click here (avoids editing Designer.cs)
            this.Button_Crear.Click += button_Crear_Click;

            // Enforce yyyy-mm format for periodo
            if (textBox_Periodo != null)
            {
                textBox_Periodo.MaxLength = 7; // "yyyy-mm"
                textBox_Periodo.KeyPress += TextBox_Periodo_KeyPress;
                textBox_Periodo.TextChanged += textBox_Periodo_TextChanged;
                textBox_Periodo.Leave += TextBox_Periodo_Leave;
            }
        }

        private void Crear_Nomina_Load(object sender, EventArgs e)
        {

        }

        // Added: look up empleado by document and show full name in textBox_Empleado
        private void button_Lupa_Click(object sender, EventArgs e)
        {
            // If designer wired the other method, delegate to it
            button_Lupa_Click_1(sender, e);
        }

        private void button_Lupa_Click_1(object sender, EventArgs e)
        {
            var numero = (textBox_Documento.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Ingrese el número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var conexion = new Conexion();
                var emp = conexion.Buscar_Empleado(numero);

                if (emp == null)
                {
                    MessageBox.Show("Empleado no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Empleado.Text = string.Empty;
                    return;
                }

                // Build display name from available name parts
                var partes = new[] { emp.Primer_Nombre, emp.Segundo_Nombre, emp.Primer_Apellido, emp.Segundo_Apellido };
                var nombreCompleto = string.Join(" ", partes.Where(p => !string.IsNullOrWhiteSpace(p)));
                textBox_Empleado.Text = nombreCompleto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Only allow periodo formats "yyyy-mm" (e.g. 2025-08)
        private static bool IsValidPeriodo(string periodo)
        {
            if (string.IsNullOrWhiteSpace(periodo)) return false;
            var rx = new Regex(@"^\d{4}-(0[1-9]|1[0-2])$", RegexOptions.Compiled);
            return rx.IsMatch(periodo.Trim());
        }

        // Called when user clicks Button_Crear
        private void button_Crear_Click(object sender, EventArgs e)
        {
            var numero = (textBox_Documento.Text ?? string.Empty).Trim();
            var periodo = (textBox_Periodo.Text ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Ingrese el número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Documento.Focus();
                return;
            }

            if (!IsValidPeriodo(periodo))
            {
                MessageBox.Show("Periodo inválido. Use formato yyyy-mm (ej. 2025-08).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Periodo.Focus();
                return;
            }

            try
            {
                // Parse optional numeric fields safely (null if invalid/empty)
                int? diasS = ParseIntNullable(textBox_Dias_S?.Text);
                int? diasN = ParseIntNullable(textBox_Dias_N?.Text);
                int? diasF = ParseIntNullable(textBox_Dias_F?.Text);

                decimal? extrasD = ParseDecimalNullable(textBox_Extras_D?.Text);
                decimal? extrasN = ParseDecimalNullable(textBox_Extras_N?.Text);
                decimal? extrasF_D = ParseDecimalNullable(textBox_Extras_F_D?.Text);
                decimal? extrasF_N = ParseDecimalNullable(textBox_F_N?.Text);

                decimal? bonificaciones = ParseDecimalNullable(textBox_Bonificaciones?.Text);
                decimal? comisiones = ParseDecimalNullable(textBox_Comisiones?.Text);

                var conexion = new Conexion();

                // Get empleado to read Salario_Base and compute valor_Hora
                decimal? valor_Hora = null;
                var emp = conexion.Buscar_Empleado(numero);

                // Validate employee and salary before computing values
                if (emp == null)
                {
                    MessageBox.Show("Empleado no encontrado. Verifique el número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_Documento.Focus();
                    return;
                }

                if (!emp.Salario_Base.HasValue)
                {
                    MessageBox.Show("El empleado no tiene definido Salario_Base. Complete la ficha del empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_Documento.Focus();
                    return;
                }

                // divide salario base by 240 as requested
                valor_Hora = emp.Salario_Base.Value / 240m;

                // Compute valor_dias for diurnos: diasS * 8 * valor_Hora
                decimal? valor_dias = null;
                if (valor_Hora.HasValue && diasS.HasValue)
                {
                    valor_dias = (decimal)diasS.Value * 8m * valor_Hora.Value;
                }

                // Compute valor_dias_nocturnos: valor_Hora * (diasN * 8) * (1 + Recargo_Nocturno)
                decimal? valor_dias_nocturnos = null;
                if (valor_Hora.HasValue && diasN.HasValue)
                {
                    decimal recargo = 0m;
                    try
                    {
                        recargo = Convert.ToDecimal(configuracion_nomina.Recargo_Nocturno);
                    }
                    catch
                    {
                        recargo = 0m;
                    }

                    valor_dias_nocturnos = (decimal)diasN.Value * 8m * valor_Hora.Value * (1m + recargo);
                }

                // Compute valor_dias_festivos: valor_Hora * (diasF * 8) * (1 + Recargo_Dominical)
                decimal? valor_dias_festivos = null;
                if (valor_Hora.HasValue && diasF.HasValue)
                {
                    decimal recargoDominical = 0m;
                    try
                    {
                        recargoDominical = Convert.ToDecimal(configuracion_nomina.Recargo_Dominical);
                    }
                    catch
                    {
                        recargoDominical = 0m;
                    }

                    valor_dias_festivos = (decimal)diasF.Value * 8m * valor_Hora.Value * (1m + recargoDominical);
                }

                // Compute valor_horas_extras_diurnas: valor_Hora * extrasD * (1 + Recargo_HE_Diurna)
                decimal? valor_horas_extras_diurnas = null;
                if (valor_Hora.HasValue && extrasD.HasValue)
                {
                    decimal recargoHE = 0m;
                    try
                    {
                        recargoHE = Convert.ToDecimal(configuracion_nomina.Recargo_HE_Diurna);
                    }
                    catch
                    {
                        recargoHE = 0m;
                    }

                    valor_horas_extras_diurnas = extrasD.Value * valor_Hora.Value * (1m + recargoHE);
                }

                var nomina = new Conexion.Nomina
                {
                    Numero_Documento = numero,
                    Periodo = periodo,
                    Fecha_Creacion = DateTime.Now,
                    Dias_Diurnos = diasS.HasValue ? (decimal?)diasS.Value : null,
                    Dias_Nocturnos = diasN.HasValue ? (decimal?)diasN.Value : null,
                    Dias_Festivos = diasF.HasValue ? (decimal?)diasF.Value : null,

                    Horas_Extras_Diurnas = extrasD,
                    Horas_Extras_Nocturnas = extrasN,
                    Horas_Extras_Festivas_Diurnas = extrasF_D,
                    Horas_Extras_Festivas_Nocturnas = extrasF_N,

                    Bonificaciones = bonificaciones,
                    Comisiones = comisiones,

                    // Set computed values into the nomina DTO so they will be saved to DB columns
                    Valor_Dias = valor_dias,
                    Valor_Dias_Nocturnos = valor_dias_nocturnos,
                    Valor_Dias_Festivos = valor_dias_festivos,
                    Valor_Horas_Extras_Diurnas = valor_horas_extras_diurnas,

                    // minimal fields set; extend mapping from UI controls as needed
                    Estado = "Por liquidar"
                };

                conexion.Agregar_Nomina(nomina);

                MessageBox.Show("Nómina agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException invEx)
            {
                MessageBox.Show("No se pudo agregar nómina: " + invEx.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int? ParseIntNullable(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Trim();
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out var i)) return i;
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out i)) return i;
            return null;
        }

        private static decimal? ParseDecimalNullable(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Trim();
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out var d)) return d;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out d)) return d;
            return null;
        }

        // Restrict key input to digits and single '-' at position 4; allow control keys
        private void TextBox_Periodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            var tb = sender as TextBox;
            if (tb == null) { e.Handled = true; return; }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
            {
                // prevent exceeding max length when no selection
                if (tb.SelectionLength == 0 && tb.Text.Length >= tb.MaxLength)
                    e.Handled = true;
                return;
            }

            // Allow single '-' only at position 4 (zero-based index)
            if (e.KeyChar == '-')
            {
                if (tb.Text.Contains("-")) { e.Handled = true; return; }
                if (tb.SelectionStart != 4) { e.Handled = true; return; }
                return;
            }

            // otherwise reject
            e.Handled = true;
        }

        // Auto-insert '-' after typing 4 digits and validate visual feedback
        private void textBox_Periodo_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            var originalSelection = tb.SelectionStart;
            var text = tb.Text ?? string.Empty;

            // Remove any characters other than digits and '-'
            var cleaned = new string(text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            // If user pasted digits without '-', insert it after 4 digits
            if (!cleaned.Contains("-") && cleaned.Length > 4)
            {
                cleaned = cleaned.Insert(4, "-");
            }

            // Trim to max length
            if (cleaned.Length > tb.MaxLength)
                cleaned = cleaned.Substring(0, tb.MaxLength);

            if (cleaned != text)
            {
                tb.Text = cleaned;
                // restore selection reasonably
                tb.SelectionStart = Math.Min(originalSelection, tb.Text.Length);
            }

            // visual feedback
            tb.BackColor = IsValidPeriodo(tb.Text) || string.IsNullOrEmpty(tb.Text) ? SystemColors.Window : Color.MistyRose;
        }

        // On leaving the field, if non-empty and invalid, show a short message and focus back
        private void TextBox_Periodo_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;
            if (string.IsNullOrWhiteSpace(tb.Text)) return;

            if (!IsValidPeriodo(tb.Text))
            {
                MessageBox.Show("Periodo inválido. Use formato yyyy-mm (ej. 2025-08).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
            }
        }
    }
}
