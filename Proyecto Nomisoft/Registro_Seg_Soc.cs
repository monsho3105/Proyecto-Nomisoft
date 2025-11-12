using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Registro_Seg_Soc : Form
    {
        // Conexion instance reused for lookups
        private Conexion conexion;

        // Enforce constants for ARL and Caja de Compensación
        private const string DefaultArl = "sura";
        private const string DefaultCaja = "colsubsidio";

        public Registro_Seg_Soc()
        {
            InitializeComponent();
        }

        private void Registro_Seg_Soc_Load(object sender, EventArgs e)
        {
            // create connection helper once
            conexion = new Conexion();

            // lookup when user leaves the documento textbox or presses Enter
            textBox_Documento.Leave += (s, ev) => LookupEmpleado();
            textBox_Documento.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { ev.Handled = true; ev.SuppressKeyPress = true; LookupEmpleado(); }
            };
        }

        // helper that uses Conexion
        private void LookupEmpleado()
        {
            var numero = (textBox_Documento.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(numero)) { textBox_empleado.Text = string.Empty; return; }

            var emp = conexion.Buscar_Empleado(numero);
            if (emp == null) { textBox_empleado.Text = string.Empty; MessageBox.Show("Empleado no encontrado."); return; }

            var parts = new[] { emp.Primer_Nombre, emp.Segundo_Nombre, emp.Primer_Apellido, emp.Segundo_Apellido };
            textBox_empleado.Text = string.Join(" ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }

        // button_lupa should trigger name lookup
        private void button_lupa_Click(object sender, EventArgs e)
        {
            try
            {
                LookupEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message);
            }
        }

        // button_Registrar is wired in the Designer; implement insert/update here using the Designer ComboBoxes
        private void button_Registrar_Click(object sender, EventArgs e)
        {
            if (conexion == null) conexion = new Conexion();

            var numero = (textBox_Documento.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Ingrese número de documento.");
                return;
            }

            // Use the Designer controls: combo_Eps, combo_Pension, combo_Cesantias
            var eps = combo_Eps.SelectedItem?.ToString() ?? combo_Eps.Text?.Trim() ?? string.Empty;
            var fondoPension = combo_Pension.SelectedItem?.ToString() ?? combo_Pension.Text?.Trim() ?? string.Empty;
            var fondoCesantias = combo_Cesantias.SelectedItem?.ToString() ?? combo_Cesantias.Text?.Trim() ?? string.Empty;

            try
            {
                // Check for existing record first. If exists, do NOT update — inform the user.
                var existing = conexion.Buscar_Seguridad_Social(numero);
                if (existing != null)
                {
                    // Found an existing seguridad_social for this document — do not update or insert.
                    MessageBox.Show("El número de documento ya está registrado. No se puede registrar nuevamente.");
                    return;
                }

                // No existing record -> insert. Enforce default ARL and Caja de Compensación on insert.
                conexion.Agregar_Seguridad_Social(numero, eps, fondoPension, DefaultArl, DefaultCaja, fondoCesantias);
                MessageBox.Show("Registro de seguridad social agregado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar seguridad social: " + ex.Message);
            }
        }

        private void button_Registrar_Seg_Soc_Click(object sender, EventArgs e)
        {
            // kept for compatibility if other code calls it; forward to the wired handler
            button_Registrar_Click(sender, e);
        }
    }
}
