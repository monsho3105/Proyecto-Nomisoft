using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Editar_seg_social : Form
    {
        private Conexion conexion;

        // Enforce constants for ARL and Caja de Compensación
        private const string DefaultArl = "sura";
        private const string DefaultCaja = "colsubsidio";

        public Editar_seg_social()
        {
            InitializeComponent();

            // initialize conexion and wire events
            conexion = new Conexion();
            button_Actualizar.Click += button_Actualizar_Click;

            // lookup when user leaves the documento textbox or presses Enter
            textBox1.Leave += (s, ev) => LookupEmpleado();
            textBox1.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { ev.Handled = true; ev.SuppressKeyPress = true; LookupEmpleado(); }
            };
        }

        private void LookupEmpleado()
        {
            var numero = (textBox1.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(numero)) { textBox2.Text = string.Empty; return; }

            var emp = conexion.Buscar_Empleado(numero);
            if (emp == null) { textBox2.Text = string.Empty; MessageBox.Show("Empleado no encontrado."); return; }

            var parts = new[] { emp.Primer_Nombre, emp.Segundo_Nombre, emp.Primer_Apellido, emp.Segundo_Apellido };
            textBox2.Text = string.Join(" ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }

        // Click actualizar -> update seguridad_social row for the provided documento
        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            if (conexion == null) conexion = new Conexion();

            var numero = (textBox1.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Ingrese número de documento.");
                return;
            }

            try
            {
                var existing = conexion.Buscar_Seguridad_Social(numero);
                if (existing == null)
                {
                    MessageBox.Show("No existe un registro de seguridad social para ese número de documento.");
                    return;
                }

                // Read values from controls (use selected item or typed text)
                var eps = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text?.Trim() ?? string.Empty;
                var fondoPension = comboBox2.SelectedItem?.ToString() ?? comboBox2.Text?.Trim() ?? string.Empty;
                var fondoCesantias = comboBox3.SelectedItem?.ToString() ?? comboBox3.Text?.Trim() ?? string.Empty;

                // Build update object; always enforce ARL and Caja defaults
                var nuevo = new Conexion.SeguridadSocial
                {
                    Id = existing.Id,
                    Numero_Documento = existing.Numero_Documento, // keep same key
                    Eps = string.IsNullOrWhiteSpace(eps) ? existing.Eps : eps,
                    Fondo_Pension = string.IsNullOrWhiteSpace(fondoPension) ? existing.Fondo_Pension : fondoPension,
                    Arl = DefaultArl,
                    Caja_Compensacion = DefaultCaja,
                    Fondo_Cesantias = string.IsNullOrWhiteSpace(fondoCesantias) ? existing.Fondo_Cesantias : fondoCesantias
                };

                conexion.Editar_Seguridad_Social(existing.Id, nuevo);
                MessageBox.Show("Registro de seguridad social actualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar seguridad social: " + ex.Message);
            }
        }
    }
}
