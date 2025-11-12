using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Crear_Seg_Soc : Form
    {
        private Conexion conexion;
        private const string DefaultArl = "sura";
        private const string DefaultCaja = "colsubsidio";

        public Crear_Seg_Soc()
        {
            InitializeComponent();

            // create shared Conexion instance
            conexion = new Conexion();

            // wire the click handlers
            this.button_buscar.Click += this.button_buscar_Click;

            // wire registrar if the button exists in the Designer
            var btns = this.Controls.Find("button_registrar", true);
            if (btns.Length > 0 && btns[0] is Button btnRegistrar)
            {
                btnRegistrar.Click += this.button_registrar_Click;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                var numero = textBox_documento.Text?.Trim();
                if (string.IsNullOrEmpty(numero))
                {
                    MessageBox.Show("Ingrese un número de documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var emp = conexion.Buscar_Empleado(numero);

                if (emp == null)
                {
                    TextBox_Nombre.Text = string.Empty;
                    MessageBox.Show("Empleado no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TextBox_Nombre.Text = string.Format("{0} {1} {2} {3}",
                    emp.Primer_Nombre ?? string.Empty,
                    emp.Segundo_Nombre ?? string.Empty,
                    emp.Primer_Apellido ?? string.Empty,
                    emp.Segundo_Apellido ?? string.Empty).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Safe helper: read a ComboBox (or other control with Text) by name at runtime.
        private string GetControlText(string controlName)
        {
            var found = this.Controls.Find(controlName, true);
            if (found.Length == 0) return string.Empty;
            var c = found[0];
            if (c is ComboBox cb) return cb.SelectedItem?.ToString() ?? cb.Text?.Trim() ?? string.Empty;
            return c.Text?.Trim() ?? string.Empty;
        }

        // Insert seguridad_social using values from combo boxes:
        // expected combo names (Designer): "combo_Eps", "combo_Pension", "combo_Cesantias"
        private void button_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                var numero = textBox_documento.Text?.Trim();
                if (string.IsNullOrEmpty(numero))
                {
                    MessageBox.Show("Ingrese número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // read combo values by name (defensive: avoids compile-time dependency on Designer field names)
                var eps = GetControlText("combo_Eps");
                var fondoPension = GetControlText("combo_Pension");
                var fondoCesantias = GetControlText("combo_Cesantias");

                // simple validation
                if (string.IsNullOrWhiteSpace(eps) && string.IsNullOrWhiteSpace(fondoPension) && string.IsNullOrWhiteSpace(fondoCesantias))
                {
                    var res = MessageBox.Show("No se detectaron valores en los combo boxes. ¿Desea continuar con campos vacíos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes) return;
                }

                // do not duplicate
                var existing = conexion.Buscar_Seguridad_Social(numero);
                if (existing != null)
                {
                    MessageBox.Show("El número de documento ya está registrado en seguridad social.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // insert (enforce defaults for ARL and Caja de Compensación)
                conexion.Agregar_Seguridad_Social(numero, eps, fondoPension, DefaultArl, DefaultCaja, fondoCesantias);
                MessageBox.Show("Registro de seguridad social agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar seguridad social: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu_Nomina back = new Menu_Nomina();
            back.Show();
            this.Hide();
        }
    }
}
