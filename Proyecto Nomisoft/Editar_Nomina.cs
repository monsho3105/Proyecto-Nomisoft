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
                    Total_Dev.Text = string.Empty;
                    Total_Ded.Text = string.Empty;
                    Neto_Pagar.Text = string.Empty;
                    return;
                }

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

                Total_Dev.Text = nom.Total_Devengado?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                Total_Ded.Text = nom.Total_Deducciones?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
                Neto_Pagar.Text = nom.Neto_Pagar?.ToString("N2", CultureInfo.CurrentCulture) ?? string.Empty;
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
    }
}
