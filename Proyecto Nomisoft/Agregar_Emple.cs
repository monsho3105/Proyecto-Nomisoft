using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Agregar_Emple : Form
    {
        public Agregar_Emple()
        {
            InitializeComponent();
           
            this.BackgroundImageLayout = ImageLayout.Zoom; // o Stretch si prefieres

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // sin bordes ni título
            this.TopLevel = false; // ya lo tienes
            this.Text = ""; // opcional, borra el texto del título

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Com_Box_Tipo_Doc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void Agregar_Emple_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_4(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_5(object sender, EventArgs e)
        {

        }

        private void label2_Click_6(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void label2_Click_7(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            var conexion = new Conexion();

            if (Com_Box_Tipo_Doc.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string Tipo_Documento = Com_Box_Tipo_Doc.SelectedItem.ToString();

            DateTime Fecha_Nacimiento;
            DateTime Fecha_Ingreso;
            string[] dateFormats = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };

            var fechaNacInput = (txt_Fecha_Nacimiento.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(fechaNacInput))
            {
                MessageBox.Show("Ingrese la fecha de nacimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use InvariantCulture so '/' in format strings matches a literal '/' regardless of the machine's CurrentCulture
            if (!DateTime.TryParseExact(fechaNacInput, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Fecha_Nacimiento))
            {
                MessageBox.Show("Fecha de nacimiento inválida. Use un formato válido (ej. dd/MM/yyyy o yyyy-MM-dd).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fechaIngInput = (txt_Fecha_Ingreso.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(fechaIngInput))
            {
                MessageBox.Show("Ingrese la fecha de ingreso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(fechaIngInput, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out Fecha_Ingreso))
            {
                MessageBox.Show("Fecha de ingreso inválida. Use un formato válido (ej. dd/MM/yyyy o yyyy-MM-dd).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_Hijos.Text, out int Hijos))
            {
                MessageBox.Show("Número de hijos inválido. Ingrese un número entero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conexion.Agregar_Empleado(
                    txt_Nombre1.Text, txt_Nombre2.Text, txt_Apellido1.Text, txt_Apellido2.Text,
                    Tipo_Documento, txt_Numero_Doc.Text, Fecha_Nacimiento,
                    txt_Telefono.Text, txt_Correo.Text, txt_Direccion.Text, txt_Estado_Civil.Text,
                    Hijos, txt_Cargo.Text, txt_Departamento.Text, Fecha_Ingreso,
                    text_Tipo_Contrato.Text, txt_Salario.Text, txt_Estado.Text);

                MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- Begin: add seguridad_social record using comboBox_Eps, comboBox_Pension, comboBox_Cesantias ---
                // Find combo boxes safely by name (in case designer named them as requested)
                ComboBox FindCombo(string name) => this.Controls.Find(name, true).FirstOrDefault() as ComboBox;

                var cbEps = FindCombo("comboBox_Eps");
                var cbPension = FindCombo("comboBox_Pension");
                var cbCesantias = FindCombo("comboBox_Cesantias");

                var eps = cbEps?.SelectedItem?.ToString() ?? cbEps?.Text?.Trim() ?? string.Empty;
                var fondoPension = cbPension?.SelectedItem?.ToString() ?? cbPension?.Text?.Trim() ?? string.Empty;
                var fondoCesantias = cbCesantias?.SelectedItem?.ToString() ?? cbCesantias?.Text?.Trim() ?? string.Empty;

                var numeroDoc = (txt_Numero_Doc.Text ?? string.Empty).Trim();

                // Only attempt insert if at least one seguridad_social value provided
                if (!string.IsNullOrWhiteSpace(eps) || !string.IsNullOrWhiteSpace(fondoPension) || !string.IsNullOrWhiteSpace(fondoCesantias))
                {
                    try
                    {
                        var existing = conexion.Buscar_Seguridad_Social(numeroDoc);
                        if (existing != null)
                        {
                            MessageBox.Show("Ya existe información de seguridad social para este número de documento. Seomitió la inserción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // default ARL and Caja if you want to set them here
                            var defaultArl = "sura";
                            var defaultCaja = "colsubsidio";

                            conexion.Agregar_Seguridad_Social(numeroDoc, eps, fondoPension, defaultArl, defaultCaja, fondoCesantias);
                            MessageBox.Show("Registro de seguridad social agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exSec)
                    {
                        MessageBox.Show("Error al agregar seguridad social: " + exSec.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // --- End: seguridad_social insert ---
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Menu Back = new Admin_Menu();
            Back.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
