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
        // Prevent double-execution when the Click handler is wired twice
        private bool _isCreatingNomina = false;

        public Crear_Nomina()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ensure designer-forwarding handler is removed so the logic runs only once.
            // Designer may have wired Button_Crear -> Button_Crear_Click_1; remove that subscription if present.
            this.Button_Crear.Click -= Button_Crear_Click_1;

            // Wire the single, canonical handler
            this.Button_Crear.Click += button_Crear_Click;

            // Load configuration from database; fallback to sensible defaults if DB access fails.
            try
            {
                var conexion = new Conexion();
                var cfg = conexion.Obtener_Configuracion_Nomina();
                if (cfg != null)
                {
                    // keep as dynamic to preserve existing code usage
                    configuracion_nomina = cfg;
                }
                else
                {
                    configuracion_nomina = new
                    {
                        Recargo_Nocturno = 0.35m,
                        Recargo_Dominical = 0.75m,
                        Recargo_HE_Diurna = 0.25m,
                        Recargo_HE_Nocturna = 0.75m,
                        Recargo_HE_Dominical = 0.75m,
                        // per your request this value comes from DB Recargo_HE_Diurna if not present; default here:
                        Recargo_HE_Dominical_Nocturna = 0.90m
                    };
                }
            }
            catch
            {
                // if DB read fails, keep defaults so UI still works
                configuracion_nomina = new
                {
                    Recargo_Nocturno = 0.35m,
                    Recargo_Dominical = 0.75m,
                    Recargo_HE_Diurna = 0.25m,
                    Recargo_HE_Nocturna = 0.75m,
                    Recargo_HE_Dominical = 0.75m,
                    Recargo_HE_Dominical_Nocturna = 0.90m
                };
            }

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
            // Prevent double-execution when the handler is wired twice (designer + manual)
            if (_isCreatingNomina) return;
            _isCreatingNomina = true;
            if (Button_Crear != null) Button_Crear.Enabled = false;

            try
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
                    decimal? deducciones = ParseDecimalNullable(textBox_Deducciones?.Text);

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

                    // Payment for diurnos (Pago_Dias) = diasS * 8 * valor_Hora
                    decimal? Pago_Dias = null;
                    if (valor_Hora.HasValue && diasS.HasValue)
                    {
                        Pago_Dias = (decimal)diasS.Value * 8m * valor_Hora.Value;
                    }

                    // Valor_Dias_Nocturnos = valor_Hora * (diasN * 8) * (1 + Recargo_Nocturno)
                    decimal? Valor_Dias_Nocturnos = null;
                    if (valor_Hora.HasValue && diasN.HasValue)
                    {
                        decimal recargoNocturno = 0m;
                        try { recargoNocturno = Convert.ToDecimal(configuracion_nomina.Recargo_Nocturno); } catch { recargoNocturno = 0m; }
                        Valor_Dias_Nocturnos = (decimal)diasN.Value * 8m * valor_Hora.Value * (1m + recargoNocturno);
                    }

                    // Valor_Dias_Festivos = valor_Hora * (diasF * 8) * (1 + Recargo_Dominical)
                    decimal? Valor_Dias_Festivos = null;
                    if (valor_Hora.HasValue && diasF.HasValue)
                    {
                        decimal recargoDominical = 0m;
                        try { recargoDominical = Convert.ToDecimal(configuracion_nomina.Recargo_Dominical); } catch { recargoDominical = 0m; }
                        Valor_Dias_Festivos = (decimal)diasF.Value * 8m * valor_Hora.Value * (1m + recargoDominical);
                    }

                    // Valor_Horas_Extras_Diurnas = valor_Hora * extrasD * (1 + Recargo_HE_Diurna)
                    decimal? Valor_Horas_Extras_Diurnas = null;
                    if (valor_Hora.HasValue && extrasD.HasValue)
                    {
                        decimal recargoHED = 0m;
                        try { recargoHED = Convert.ToDecimal(configuracion_nomina.Recargo_HE_Diurna); } catch { recargoHED = 0m; }
                        Valor_Horas_Extras_Diurnas = extrasD.Value * valor_Hora.Value * (1m + recargoHED);
                    }

                    // Valor_Horas_Extras_Nocturnas = valor_Hora * extrasN * (1 + Recargo_HE_Nocturna)
                    decimal? Valor_Horas_Extras_Nocturnas = null;
                    if (valor_Hora.HasValue && extrasN.HasValue)
                    {
                        decimal recargoHEN = 0m;
                        try { recargoHEN = Convert.ToDecimal(configuracion_nomina.Recargo_HE_Nocturna); } catch { recargoHEN = 0m; }
                        Valor_Horas_Extras_Nocturnas = extrasN.Value * valor_Hora.Value * (1m + recargoHEN);
                    }

                    // Valor_Horas_Extras_Festivas_Diurnas = valor_Hora * extrasF_D * (1 + Recargo_HE_Dominical)
                    decimal? Valor_Horas_Extras_Festivas_Diurnas = null;
                    if (valor_Hora.HasValue && extrasF_D.HasValue)
                    {
                        decimal recargoHEDom = 0m;
                        try { recargoHEDom = Convert.ToDecimal(configuracion_nomina.Recargo_HE_Dominical); } catch { recargoHEDom = 0m; }
                        Valor_Horas_Extras_Festivas_Diurnas = extrasF_D.Value * valor_Hora.Value * (1m + recargoHEDom);
                    }

                    // Valor_Horas_Extras_Festivas_Nocturnas = valor_Hora * extrasF_N * (1 + Recargo_HE_Dominical_Nocturna)
                    decimal? Valor_Horas_Extras_Festivas_Nocturnas = null;
                    if (valor_Hora.HasValue && extrasF_N.HasValue)
                    {
                        decimal recargoHEDomNoct = 0m;
                        try { recargoHEDomNoct = Convert.ToDecimal(configuracion_nomina.Recargo_HE_Dominical_Nocturna); } catch { recargoHEDomNoct = 0m; }
                        Valor_Horas_Extras_Festivas_Nocturnas = extrasF_N.Value * valor_Hora.Value * (1m + recargoHEDomNoct);
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
                        Deducciones = deducciones,

                        Valor_Dias = Pago_Dias,
                        Valor_Dias_Nocturnos = Valor_Dias_Nocturnos,
                        Valor_Dias_Festivos = Valor_Dias_Festivos,
                        Valor_Horas_Extras_Diurnas = Valor_Horas_Extras_Diurnas,
                        Valor_Horas_Extras_Nocturnas = Valor_Horas_Extras_Nocturnas,
                        Valor_Horas_Extras_Festivas_Diurnas = Valor_Horas_Extras_Festivas_Diurnas,
                        Valor_Horas_Extras_Festivas_Nocturnas = Valor_Horas_Extras_Festivas_Nocturnas,

                        Estado = "Por liquidar"
                    };

                    // Read SMMLV from the proper place: first try parametros, then fallback to configuracion_nomina
                    try
                    {
                        decimal smmlv = 0m;
                        decimal? auxilioParam = null;

                        // Prefer parameters table (parametros_nomina) which holds SMMLV and Auxilio_Transporte
                        try
                        {
                            var parametros = conexion.Obtener_Parametros();
                            if (parametros != null)
                            {
                                if (parametros.SMMLV.HasValue) smmlv = parametros.SMMLV.Value;
                                if (parametros.Auxilio_Transporte.HasValue) auxilioParam = parametros.Auxilio_Transporte.Value;
                            }
                        }
                        catch
                        {
                            // ignore and fallback below
                        }

                        // fallback to dynamic configuracion_nomina if parameters did not provide SMMLV
                        if (smmlv == 0m)
                        {
                            try { smmlv = Convert.ToDecimal(configuracion_nomina.SMMLV); } catch { smmlv = 0m; }
                        }

                        // Debugging help: show values when running debug build
#if DEBUG
                        System.Diagnostics.Debug.WriteLine(
    "SMMLV=" + smmlv.ToString("N2", CultureInfo.CurrentCulture) + ", " +
    "Salario=" + (emp.Salario_Base.HasValue ? emp.Salario_Base.Value.ToString("N2", CultureInfo.CurrentCulture) : "NULL") + ", " +
    "AuxilioParametro=" + (auxilioParam.HasValue ? auxilioParam.Value.ToString("N2", CultureInfo.CurrentCulture) : "NULL")
);
#endif

                        if (smmlv > 0m && emp.Salario_Base.HasValue)
                        {
                            var salario = emp.Salario_Base.Value;
                            // use salary < SMMLV * 2 as requested
                            if (salario < smmlv * 2m)
                            {
                                // prefer the Auxilio_Transporte from parametros table when present
                                nomina.Auxilio_Transporte = auxilioParam ?? 200000m;
                            }
                        }
                    }
                    catch
                    {
                        // ignore problems reading SMMLV; leave Auxilio_Transporte as provided
                    }

                    // Compute IBC = sum of the specified Valor_* fields plus Comisiones and Bonificaciones.
                    // Treat nullable fields as zero for the sum.
                    decimal IBC = (Pago_Dias ?? 0m)
                                + (Valor_Dias_Nocturnos ?? 0m)
                                + (Valor_Dias_Festivos ?? 0m)
                                + (Valor_Horas_Extras_Diurnas ?? 0m)
                                + (Valor_Horas_Extras_Nocturnas ?? 0m)
                                + (Valor_Horas_Extras_Festivas_Diurnas ?? 0m)
                                + (Valor_Horas_Extras_Festivas_Nocturnas ?? 0m)
                                + (comisiones ?? 0m)
                                + (bonificaciones ?? 0m);

                    // Save IBC to nomina.Total_Devengado and show it in the read-only textBox_Tot_Dev.
                    nomina.Total_Devengado = IBC;
                    if (textBox_Tot_Dev != null)
                        textBox_Tot_Dev.Text = IBC.ToString("N2", CultureInfo.CurrentCulture);

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
            finally
            {
                _isCreatingNomina = false;
                if (Button_Crear != null) Button_Crear.Enabled = true;
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
        // Designer may be wired to Button_Crear_Click_1; provide a delegate to the implemented handler to fix the missing-method error.
        private void Button_Crear_Click_1(object sender, EventArgs e)
        {
            
            button_Crear_Click(sender, e);
        }

        private void TextBox_Periodo_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            // Validate the periodo format on leave and provide feedback
            if (!IsValidPeriodo(tb.Text) && !string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("Periodo inválido. Use formato yyyy-mm (ej. 2025-08).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
            }
        }
    }
}
