using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Crear_Nomina : Form
    {
        public Crear_Nomina()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Crear_Nomina_Load(object sender, EventArgs e)
        {

        }

        // Added: look up empleado by document and show full name in textBox_Empleado
        private void button_Lupa_Click(object sender, EventArgs e)
        {
            
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

        // Validate periodo: only allow "yyyy-mm-1" or "yyyy-mm-2"
        private static bool IsValidPeriodo(string periodo)
        {
            if (string.IsNullOrWhiteSpace(periodo)) return false;
            // yyyy-(01..12)-1 or yyyy-(01..12)-2
            var rx = new Regex(@"^\d{4}-(0[1-9]|1[0-2])-(1|2)$", RegexOptions.Compiled);
            return rx.IsMatch(periodo.Trim());
        }

        // Call this from your "Agregar/Guardar" button before attempting to insert
        private bool ValidatePeriodoOrShow()
        {
            var periodo = (textBox_Periodo.Text ?? string.Empty).Trim();
            if (!IsValidPeriodo(periodo))
            {
                MessageBox.Show("Periodo inválido. Use formato yyyy-mm-1 o yyyy-mm-2 (ej. 2025-08-1).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Periodo.Focus();
                return false;
            }
            return true;
        }

        // Optional: wire this to the textBox_Periodo Validating event to block focus loss when invalid
        private void textBox_Periodo_Validating(object sender, CancelEventArgs e)
        {
            var periodo = (textBox_Periodo.Text ?? string.Empty).Trim();
            if (!IsValidPeriodo(periodo))
            {
                MessageBox.Show("Periodo inválido. Use formato yyyy-mm-1 o yyyy-mm-2 (ej. 2025-08-1).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // prevents leaving the control
            }
        }
    }
}
