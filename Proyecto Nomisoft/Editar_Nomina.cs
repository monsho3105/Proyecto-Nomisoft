using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Proyecto_Nomisoft
{
    public partial class Editar_Nomina : Form
    {
        // keep the loaded nomina so we can reference original values if needed
        private Conexion.Nomina _loadedNomina;

        public Editar_Nomina()
        {
            InitializeComponent();

            // Wire the lookup button(s) if present in the Designer.
            if (this.button_Lupa != null)
            {
                // ensure single, known handler
                this.button_Lupa.Click -= button_Lupa_Click;
                this.button_Lupa.Click -= button_Lupa_Click_1;
                this.button_Lupa.Click += button_Lupa_Click;
            }

            // Ensure the periodo button uses our handler (avoid duplicate subscriptions)
            if (this.button_Periodo != null)
            {
                // remove any designer-assigned legacy handler and attach the clear handler
                this.button_Periodo.Click -= button1_Click;
                this.button_Periodo.Click -= button_Periodo_Click;
                this.button_Periodo.Click += button_Periodo_Click;
            }

            // Apply periodo input restrictions similar to Crear_Nomina
            if (textBox_Periodo != null)
            {
                textBox_Periodo.MaxLength = 7; // "yyyy-mm"
                textBox_Periodo.KeyPress += TextBox_Periodo_KeyPress;
                textBox_Periodo.TextChanged += textBox_Periodo_TextChanged;
                textBox_Periodo.Leave += TextBox_Periodo_Leave;
            }

            // Make computed totals read-only so the user cannot edit them.
            if (textBox_Neto_Pagar != null)
            {
                textBox_Neto_Pagar.ReadOnly = true;
                textBox_Neto_Pagar.TabStop = false;
            }

            if (textBox_Tot_Ded != null)
            {
                textBox_Tot_Ded.ReadOnly = true;
                textBox_Tot_Ded.TabStop = false;
            }

            if (textBox_Tot_Devengado != null)
            {
                textBox_Tot_Devengado.ReadOnly = true;
                textBox_Tot_Devengado.TabStop = false;
            }
        }

        // Keep existing logic here; new button_Periodo_Click will call into it.
        private void button1_Click(object sender, EventArgs e)
        {
            // Use textBox_Periodo and textBox_Documento to load the nomina and fill form fields.
            var periodo = (textBox_Periodo.Text ?? string.Empty).Trim();
            var numero = (textBox_Documento.Text ?? string.Empty).Trim();

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
                var conexion = new Conexion();
                var nom = conexion.Buscar_Nomina(numero, periodo);

                if (nom == null)
                {
                    MessageBox.Show("Nómina no encontrada para ese documento y periodo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    textBox_Dias_S.Text = string.Empty;
                    textBox_Dias_N.Text = string.Empty;
                    textBox_Dias_F.Text = string.Empty;
                    textBox_Extras_D.Text = string.Empty;
                    textBox_Extras_N.Text = string.Empty;
                    textBox_Extras_F_D.Text = string.Empty;
                    textBox_F_N.Text = string.Empty;
                    textBox_Bonificaciones.Text = string.Empty;
                    textBox_Comisiones.Text = string.Empty;
                    // Clear the deductions input as well
                    if (textBox_Deducciones != null) textBox_Deducciones.Text = string.Empty;
                    if (textBox_Tot_Devengado != null) textBox_Tot_Devengado.Text = string.Empty;
                    if (textBox_Tot_Ded != null) textBox_Tot_Ded.Text = string.Empty;
                    if (textBox_Neto_Pagar != null) textBox_Neto_Pagar.Text = string.Empty;
                    _loadedNomina = null;
                    return;
                }

                // store loaded nomina for later reference
                _loadedNomina = nom;

                // Populate numeric/text fields safely
                textBox_Dias_S.Text = nom.Dias_Diurnos?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_Dias_N.Text = nom.Dias_Nocturnos?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_Dias_F.Text = nom.Dias_Festivos?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;

                textBox_Extras_D.Text = nom.Horas_Extras_Diurnas?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_Extras_N.Text = nom.Horas_Extras_Nocturnas?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_Extras_F_D.Text = nom.Horas_Extras_Festivas_Diurnas?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_F_N.Text = nom.Horas_Extras_Festivas_Nocturnas?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;

                textBox_Bonificaciones.Text = nom.Bonificaciones?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                textBox_Comisiones.Text = nom.Comisiones?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                // Populate the deductions input with the stored Deducciones value
                if (textBox_Deducciones != null)
                    textBox_Deducciones.Text = nom.Deducciones?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;

                if (textBox_Tot_Devengado != null)
                    textBox_Tot_Devengado.Text = nom.Total_Devengado?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                if (textBox_Tot_Ded != null)
                    textBox_Tot_Ded.Text = nom.Total_Deducciones?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                if (textBox_Neto_Pagar != null)
                    textBox_Neto_Pagar.Text = nom.Neto_Pagar?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // New explicit handler for button_Periodo that delegates to the existing logic.
        private void button_Periodo_Click(object sender, EventArgs e)
        {
            // Call the existing implementation so Designer wiring (if any) and constructor wiring converge.
            button1_Click(sender, e);
        }

        // Replicates Crear_Nomina lookup: fills textBox_Empleado from textBox_Documento
        private void button_Lupa_Click(object sender, EventArgs e)
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
                    if (textBox_Empleado != null) textBox_Empleado.Text = string.Empty;
                    return;
                }

                var partes = new[] { emp.Primer_Nombre, emp.Segundo_Nombre, emp.Primer_Apellido, emp.Segundo_Apellido };
                var nombreCompleto = string.Join(" ", partes.Where(p => !string.IsNullOrWhiteSpace(p)));
                if (textBox_Empleado != null) textBox_Empleado.Text = nombreCompleto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Lupa_Click_1(object sender, EventArgs e)
        {
            // Designer wired to this method — delegate to the implemented handler to avoid duplicate code/side-effects.
            button_Lupa_Click(sender, e);
        }

        // Validate yyyy-mm period
        private static bool IsValidPeriodo(string periodo)
        {
            if (string.IsNullOrWhiteSpace(periodo)) return false;
            var rx = new Regex(@"^\d{4}-(0[1-9]|1[0-2])$");
            return rx.IsMatch(periodo.Trim());
        }

        // --- Periodo input helpers copied from Crear_Nomina ---

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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        // When user clicks Edit (Button_Editar wired to this), compute values and update DB record.
        private void Button_Crear_Click(object sender, EventArgs e)
        {
            // Validate inputs
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
                // If we loaded a nomina earlier, prefer keeping original values when the textbox is empty.
                // Use parsed textbox value when the user typed something; otherwise keep _loadedNomina values.
                decimal? diasS = !string.IsNullOrWhiteSpace(textBox_Dias_S?.Text)
                    ? ParseDecimalNullable(textBox_Dias_S.Text)
                    : _loadedNomina?.Dias_Diurnos;

                decimal? diasN = !string.IsNullOrWhiteSpace(textBox_Dias_N?.Text)
                    ? ParseDecimalNullable(textBox_Dias_N.Text)
                    : _loadedNomina?.Dias_Nocturnos;

                decimal? diasF = !string.IsNullOrWhiteSpace(textBox_Dias_F?.Text)
                    ? ParseDecimalNullable(textBox_Dias_F.Text)
                    : _loadedNomina?.Dias_Festivos;

                decimal? extrasD = !string.IsNullOrWhiteSpace(textBox_Extras_D?.Text)
                    ? ParseDecimalNullable(textBox_Extras_D.Text)
                    : _loadedNomina?.Horas_Extras_Diurnas;

                decimal? extrasN = !string.IsNullOrWhiteSpace(textBox_Extras_N?.Text)
                    ? ParseDecimalNullable(textBox_Extras_N.Text)
                    : _loadedNomina?.Horas_Extras_Nocturnas;

                decimal? extrasF_D = !string.IsNullOrWhiteSpace(textBox_Extras_F_D?.Text)
                    ? ParseDecimalNullable(textBox_Extras_F_D.Text)
                    : _loadedNomina?.Horas_Extras_Festivas_Diurnas;

                decimal? extrasF_N = !string.IsNullOrWhiteSpace(textBox_F_N?.Text)
                    ? ParseDecimalNullable(textBox_F_N.Text)
                    : _loadedNomina?.Horas_Extras_Festivas_Nocturnas;

                decimal? bonificaciones = !string.IsNullOrWhiteSpace(textBox_Bonificaciones?.Text)
                    ? ParseDecimalNullable(textBox_Bonificaciones.Text)
                    : _loadedNomina?.Bonificaciones;

                decimal? comisiones = !string.IsNullOrWhiteSpace(textBox_Comisiones?.Text)
                    ? ParseDecimalNullable(textBox_Comisiones.Text)
                    : _loadedNomina?.Comisiones;

                decimal? deducciones = !string.IsNullOrWhiteSpace(textBox_Deducciones?.Text)
                    ? ParseDecimalNullable(textBox_Deducciones.Text)
                    : _loadedNomina?.Deducciones;

                var conexion = new Conexion();

                // load empleado to get salario
                var emp = conexion.Buscar_Empleado(numero);
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

                // configuration (recargos, SMMLV etc.)
                var cfg = conexion.Obtener_Configuracion_Nomina();

                // compute valor_hora
                decimal valor_Hora = emp.Salario_Base.Value / 240m;

                // compute values same as Crear_Nomina
                decimal? Pago_Dias = null;
                if (diasS.HasValue) Pago_Dias = diasS.Value * 8m * valor_Hora;

                decimal recargoNocturno = cfg?.Recargo_Nocturno ?? 0m;
                decimal? Valor_Dias_Nocturnos = diasN.HasValue ? diasN.Value * 8m * valor_Hora * (1m + recargoNocturno) : (decimal?)null;

                decimal recargoDominical = cfg?.Recargo_Dominical ?? 0m;
                decimal? Valor_Dias_Festivos = diasF.HasValue ? diasF.Value * 8m * valor_Hora * (1m + recargoDominical) : (decimal?)null;

                decimal recargoHED = cfg?.Recargo_HE_Diurna ?? 0m;
                decimal? Valor_Horas_Extras_Diurnas = extrasD.HasValue ? extrasD.Value * valor_Hora * (1m + recargoHED) : (decimal?)null;

                decimal recargoHEN = cfg?.Recargo_HE_Nocturna ?? 0m;
                decimal? Valor_Horas_Extras_Nocturnas = extrasN.HasValue ? extrasN.Value * valor_Hora * (1m + recargoHEN) : (decimal?)null;

                decimal recargoHEDom = cfg?.Recargo_HE_Dominical ?? 0m;
                decimal? Valor_Horas_Extras_Festivas_Diurnas = extrasF_D.HasValue ? extrasF_D.Value * valor_Hora * (1m + recargoHEDom) : (decimal?)null;

                decimal recargoHEDomNoct = cfg?.Recargo_HE_Dominical_Nocturna ?? cfg?.Recargo_HE_Diurna ?? 0m;
                decimal? Valor_Horas_Extras_Festivas_Nocturnas = extrasF_N.HasValue ? extrasF_N.Value * valor_Hora * (1m + recargoHEDomNoct) : (decimal?)null;

                // IBC (sum of values + comisiones + bonificaciones)
                decimal IBC = (Pago_Dias ?? 0m)
                            + (Valor_Dias_Nocturnos ?? 0m)
                            + (Valor_Dias_Festivos ?? 0m)
                            + (Valor_Horas_Extras_Diurnas ?? 0m)
                            + (Valor_Horas_Extras_Nocturnas ?? 0m)
                            + (Valor_Horas_Extras_Festivas_Diurnas ?? 0m)
                            + (Valor_Horas_Extras_Festivas_Nocturnas ?? 0m)
                            + (comisiones ?? 0m)
                            + (bonificaciones ?? 0m);

                // prestaciones: aportes
                decimal aporteSalud = decimal.Round(IBC * 0.04m, 2, MidpointRounding.AwayFromZero);
                decimal aportePension = decimal.Round(IBC * 0.04m, 2, MidpointRounding.AwayFromZero);

                decimal totalDeducciones = (deducciones ?? 0m) + aporteSalud + aportePension;
                decimal netoPagar = decimal.Round(IBC - totalDeducciones, 2, MidpointRounding.AwayFromZero);

                // Preserve Auxilio_Transporte from loaded nomina when the user didn't provide a new value.
                decimal? auxilioTransporte = _loadedNomina?.Auxilio_Transporte;

                // Build nomina object to update
                var nomina = new Conexion.Nomina
                {
                    Numero_Documento = numero,
                    Periodo = periodo,
                    Fecha_Creacion = DateTime.Now,

                    Dias_Diurnos = diasS,
                    Dias_Nocturnos = diasN,
                    Dias_Festivos = diasF,

                    Horas_Extras_Diurnas = extrasD,
                    Horas_Extras_Nocturnas = extrasN,
                    Horas_Extras_Festivas_Diurnas = extrasF_D,
                    Horas_Extras_Festivas_Nocturnas = extrasF_N,

                    Bonificaciones = bonificaciones,
                    Comisiones = comisiones,
                    Auxilio_Transporte = auxilioTransporte,
                    Deducciones = deducciones,

                    Valor_Dias = Pago_Dias,
                    Valor_Dias_Nocturnos = Valor_Dias_Nocturnos,
                    Valor_Dias_Festivos = Valor_Dias_Festivos,
                    Valor_Horas_Extras_Diurnas = Valor_Horas_Extras_Diurnas,
                    Valor_Horas_Extras_Nocturnas = Valor_Horas_Extras_Nocturnas,
                    Valor_Horas_Extras_Festivas_Diurnas = Valor_Horas_Extras_Festivas_Diurnas,
                    Valor_Horas_Extras_Festivas_Nocturnas = Valor_Horas_Extras_Festivas_Nocturnas,

                    Aporte_Salud = aporteSalud,
                    Aporte_Pension = aportePension,

                    Total_Devengado = IBC,
                    Total_Deducciones = totalDeducciones,
                    Neto_Pagar = netoPagar,
                    Estado = "Por liquidar"
                };

                // Update DB
                conexion.Editar_Nomina(nomina);

                // Update UI totals (readonly fields)
                if (textBox_Tot_Devengado != null) textBox_Tot_Devengado.Text = IBC.ToString("N2", CultureInfo.CurrentCulture);
                if (textBox_Tot_Ded != null) textBox_Tot_Ded.Text = totalDeducciones.ToString("N2", CultureInfo.CurrentCulture);
                if (textBox_Neto_Pagar != null) textBox_Neto_Pagar.Text = netoPagar.ToString("N2", CultureInfo.CurrentCulture);

                MessageBox.Show("Nómina actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException invEx)
            {
                MessageBox.Show("No se pudo actualizar nómina: " + invEx.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helpers
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

        private void button_Regread_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }
    }
}
