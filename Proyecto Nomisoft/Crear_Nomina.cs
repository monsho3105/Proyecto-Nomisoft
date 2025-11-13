using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
