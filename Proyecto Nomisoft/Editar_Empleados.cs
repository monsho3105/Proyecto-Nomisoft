using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class Editar_Empleados : Form
    {
        // cached original record (set after Buscar_Empleado)
        private Conexion.Empleado originalEmpleado;
        private string originalNumeroDocumento;

        public Editar_Empleados()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // sin bordes ni título
            this.TopLevel = false; // ya lo tienes
            this.Text = ""; // opcional, borra el texto del título

        }

        private void txt_Numero_Doc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Nombre1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Editar_Empleados_Load(object sender, EventArgs e)
        {

        }

        private void txt_Nombre2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Apellido1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Apellido2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Com_Box_Tipo_Doc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Fecha_Nacimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Correo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Estado_Civil_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Hijos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Cargo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Departamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Fecha_Ingreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_Tipo_Contrato_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Estado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = txt_Numero_Doc.Text?.Trim();
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Ingrese el número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var conexion = new Conexion();
                var empleado = conexion.Buscar_Empleado(ID);

                if (empleado == null)
                {
                    MessageBox.Show("Empleado no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // clear fields except searched ID
                    txt_Nombre1.Text = "";
                    txt_Nombre2.Text = "";
                    txt_Apellido1.Text = "";
                    txt_Apellido2.Text = "";
                    Com_Box_Tipo_Doc.Text = "";
                    txt_Fecha_Nacimiento.Text = "";
                    txt_Telefono.Text = "";
                    txt_Correo.Text = "";
                    txt_Direccion.Text = "";
                    txt_Estado_Civil.Text = "";
                    txt_Hijos.Text = "";
                    txt_Cargo.Text = "";
                    txt_Departamento.Text = "";
                    txt_Fecha_Ingreso.Text = "";
                    text_Tipo_Contrato.Text = "";
                    txt_Salario.Text = "";
                    txt_Estado.Text = "";

                    originalEmpleado = null;
                    originalNumeroDocumento = null;

                    return;
                }

                // populate controls
                txt_Nombre1.Text = empleado.Primer_Nombre ?? "";
                txt_Nombre2.Text = empleado.Segundo_Nombre ?? "";
                txt_Apellido1.Text = empleado.Primer_Apellido ?? "";
                txt_Apellido2.Text = empleado.Segundo_Apellido ?? "";

                Com_Box_Tipo_Doc.Text = empleado.Tipo_Documento ?? "";
                txt_Numero_Doc.Text = empleado.Numero_Documento ?? "";

                txt_Fecha_Nacimiento.Text = empleado.Fecha_Nacimiento.HasValue
                    ? empleado.Fecha_Nacimiento.Value.ToString("yyyy-MM-dd")
                    : "";

                txt_Telefono.Text = empleado.Telefono ?? "";
                txt_Correo.Text = empleado.Correo ?? "";
                txt_Direccion.Text = empleado.Direccion ?? "";
                txt_Estado_Civil.Text = empleado.Estado_Civil ?? "";
                txt_Hijos.Text = empleado.Numero_Hijos.HasValue ? empleado.Numero_Hijos.Value.ToString() : "";
                txt_Cargo.Text = empleado.Cargo ?? "";
                txt_Departamento.Text = empleado.Departamento ?? "";

                txt_Fecha_Ingreso.Text = empleado.Fecha_Ingreso.HasValue
                    ? empleado.Fecha_Ingreso.Value.ToString("yyyy-MM-dd")
                    : "";

                text_Tipo_Contrato.Text = empleado.Tipo_Contrato ?? "";
                txt_Salario.Text = empleado.Salario_Base.HasValue ? empleado.Salario_Base.Value.ToString() : "";
                txt_Estado.Text = empleado.Estado ?? "";

                // cache original employee so Guardar knows what changed
                originalEmpleado = empleado;
                originalNumeroDocumento = empleado.Numero_Documento?.Trim() ?? "";

                // enable for editing (now allow editing Numero_Documento)
                Control[] controlsToEnable = {
                    txt_Nombre1, txt_Nombre2, txt_Apellido1, txt_Apellido2,
                    Com_Box_Tipo_Doc, txt_Numero_Doc, txt_Fecha_Nacimiento, txt_Telefono,
                    txt_Correo, txt_Direccion, txt_Estado_Civil, txt_Hijos,
                    txt_Cargo, txt_Departamento, txt_Fecha_Ingreso, text_Tipo_Contrato,
                    txt_Salario, txt_Estado
                };

                foreach (var ctrl in controlsToEnable)
                {
                    ctrl.Enabled = true;
                    ctrl.Refresh();
                }

                txt_Nombre1.Focus();
                MessageBox.Show("Empleado encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
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

            // parse salary into decimal? (match Agregar_Empleado parsing logic)
            decimal? salarioDecimal = null;
            var salarioInput = (txt_Salario.Text ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(salarioInput))
            {
                if (!decimal.TryParse(salarioInput, NumberStyles.Number, CultureInfo.CurrentCulture, out var parsedSalario))
                {
                    var normalized = salarioInput.Replace(',', '.');
                    if (!decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out parsedSalario))
                    {
                        MessageBox.Show($"Salario inválido: '{txt_Salario.Text}'", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                salarioDecimal = parsedSalario;
            }

            try
            {
                // If originalNumeroDocumento is null/empty => add new employee
                if (string.IsNullOrWhiteSpace(originalNumeroDocumento))
                {
                    conexion.Agregar_Empleado(
                        txt_Nombre1.Text, txt_Nombre2.Text, txt_Apellido1.Text, txt_Apellido2.Text,
                        Tipo_Documento, txt_Numero_Doc.Text, Fecha_Nacimiento,
                        txt_Telefono.Text, txt_Correo.Text, txt_Direccion.Text, txt_Estado_Civil.Text,
                        Hijos, txt_Cargo.Text, txt_Departamento.Text, Fecha_Ingreso,
                        text_Tipo_Contrato.Text, txt_Salario.Text, txt_Estado.Text);

                    MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // After adding employee, optionally add seguridad_social
                    var numero = (txt_Numero_Doc.Text ?? string.Empty).Trim();
                    var eps = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text?.Trim() ?? string.Empty;
                    var fondoPension = comboBox3.SelectedItem?.ToString() ?? comboBox3.Text?.Trim() ?? string.Empty;
                    var fondoCesantias = comboBox2.SelectedItem?.ToString() ?? comboBox2.Text?.Trim() ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(eps) || !string.IsNullOrWhiteSpace(fondoPension) || !string.IsNullOrWhiteSpace(fondoCesantias))
                    {
                        try
                        {
                            var existingSS = conexion.Buscar_Seguridad_Social(numero);
                            if (existingSS != null)
                            {
                                MessageBox.Show("Ya existe información de seguridad social para este empleado. Seomitió la inserción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                var defaultArl = "sura";
                                var defaultCaja = "colsubsidio";
                                conexion.Agregar_Seguridad_Social(numero, eps, fondoPension, defaultArl, defaultCaja, fondoCesantias);
                                MessageBox.Show("Registro de seguridad social agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception exSS)
                        {
                            MessageBox.Show("Error al agregar seguridad social: " + exSS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Build nuevo DTO from form input
                    var nuevo = new Conexion.Empleado
                    {
                        Primer_Nombre = txt_Nombre1.Text?.Trim(),
                        Segundo_Nombre = txt_Nombre2.Text?.Trim(),
                        Primer_Apellido = txt_Apellido1.Text?.Trim(),
                        Segundo_Apellido = txt_Apellido2.Text?.Trim(),
                        Tipo_Documento = Tipo_Documento,
                        Numero_Documento = txt_Numero_Doc.Text?.Trim(),
                        Fecha_Nacimiento = Fecha_Nacimiento,
                        Telefono = txt_Telefono.Text?.Trim(),
                        Correo = txt_Correo.Text?.Trim(),
                        Direccion = txt_Direccion.Text?.Trim(),
                        Estado_Civil = txt_Estado_Civil.Text?.Trim(),
                        Numero_Hijos = Hijos,
                        Cargo = txt_Cargo.Text?.Trim(),
                        Departamento = txt_Departamento.Text?.Trim(),
                        Fecha_Ingreso = Fecha_Ingreso,
                        Tipo_Contrato = text_Tipo_Contrato.Text?.Trim(),
                        Salario_Base = salarioDecimal,
                        Estado = txt_Estado.Text?.Trim()
                    };

                    // Determine changed fields
                    var campos = new List<string>();

                    if (!string.Equals(nuevo.Primer_Nombre ?? "", originalEmpleado.Primer_Nombre ?? "", StringComparison.Ordinal))
                        campos.Add("Primer_Nombre");

                    if (!string.Equals(nuevo.Segundo_Nombre ?? "", originalEmpleado.Segundo_Nombre ?? "", StringComparison.Ordinal))
                        campos.Add("Segundo_Nombre");

                    if (!string.Equals(nuevo.Primer_Apellido ?? "", originalEmpleado.Primer_Apellido ?? "", StringComparison.Ordinal))
                        campos.Add("Primer_Apellido");

                    if (!string.Equals(nuevo.Segundo_Apellido ?? "", originalEmpleado.Segundo_Apellido ?? "", StringComparison.Ordinal))
                        campos.Add(" Segundo_Apellido");

                    if (!string.Equals(nuevo.Tipo_Documento ?? "", originalEmpleado.Tipo_Documento ?? "", StringComparison.Ordinal))
                        campos.Add("Tipo_Documento");

                    // Numero_Documento: allow change only if different from the original
                    if (!string.Equals(nuevo.Numero_Documento ?? "", originalNumeroDocumento ?? "", StringComparison.Ordinal))
                        campos.Add("Numero_Documento");

                    if (!Nullable.Equals(nuevo.Fecha_Nacimiento, originalEmpleado.Fecha_Nacimiento))
                        campos.Add("Fecha_Nacimiento");

                    if (!string.Equals(nuevo.Telefono ?? "", originalEmpleado.Telefono ?? "", StringComparison.Ordinal))
                        campos.Add("Telefono");

                    if (!string.Equals(nuevo.Correo ?? "", originalEmpleado.Correo ?? "", StringComparison.Ordinal))
                        campos.Add("Correo");

                    if (!string.Equals(nuevo.Direccion ?? "", originalEmpleado.Direccion ?? "", StringComparison.Ordinal))
                        campos.Add("Direccion");

                    if (!string.Equals(nuevo.Estado_Civil ?? "", originalEmpleado.Estado_Civil ?? "", StringComparison.Ordinal))
                        campos.Add("Estado_Civil");

                    if (!Nullable.Equals(nuevo.Numero_Hijos, originalEmpleado.Numero_Hijos))
                        campos.Add("Numero_Hijos");

                    if (!string.Equals(nuevo.Cargo ?? "", originalEmpleado.Cargo ?? "", StringComparison.Ordinal))
                        campos.Add("Cargo");

                    if (!string.Equals(nuevo.Departamento ?? "", originalEmpleado.Departamento ?? "", StringComparison.Ordinal))
                        campos.Add("Departamento");

                    if (!Nullable.Equals(nuevo.Fecha_Ingreso, originalEmpleado.Fecha_Ingreso))
                        campos.Add("Fecha_Ingreso");

                    if (!string.Equals(nuevo.Tipo_Contrato ?? "", originalEmpleado.Tipo_Contrato ?? "", StringComparison.Ordinal))
                        campos.Add("Tipo_Contrato");

                    if (!Nullable.Equals(nuevo.Salario_Base, originalEmpleado.Salario_Base))
                        campos.Add("Salario_Base");

                    if (!string.Equals(nuevo.Estado ?? "", originalEmpleado.Estado ?? "", StringComparison.Ordinal))
                        campos.Add("Estado");

                    // Prepare seguridad_social values (combo boxes)
                    var numero = (nuevo.Numero_Documento ?? string.Empty).Trim();
                    var eps = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text?.Trim() ?? string.Empty;
                    var fondoPension = comboBox3.SelectedItem?.ToString() ?? comboBox3.Text?.Trim() ?? string.Empty;
                    var fondoCesantias = comboBox2.SelectedItem?.ToString() ?? comboBox2.Text?.Trim() ?? string.Empty;

                    if (campos.Count == 0)
                    {
                        // No empleado changes: but maybe seguridad_social (combo boxes) changed -> handle separately
                        try
                        {
                            var existingSS = conexion.Buscar_Seguridad_Social(numero);

                            if (existingSS == null)
                            {
                                // nothing in DB yet; if user provided any seguridad_social values, insert
                                if (!string.IsNullOrWhiteSpace(eps) || !string.IsNullOrWhiteSpace(fondoPension) || !string.IsNullOrWhiteSpace(fondoCesantias))
                                {
                                    var defaultArl = "sura";
                                    var defaultCaja = "colsubsidio";
                                    conexion.Agregar_Seguridad_Social(numero, eps, fondoPension, defaultArl, defaultCaja, fondoCesantias);
                                    MessageBox.Show("Registro de seguridad social agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("No se detectaron cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                // Compare combos with existing values to decide if update needed
                                bool ssNeedsUpdate = false;
                                var nuevoSS = new Conexion.SeguridadSocial
                                {
                                    Eps = string.IsNullOrWhiteSpace(eps) ? null : eps,
                                    Fondo_Pension = string.IsNullOrWhiteSpace(fondoPension) ? null : fondoPension,
                                    Fondo_Cesantias = string.IsNullOrWhiteSpace(fondoCesantias) ? null : fondoCesantias
                                };

                                if (nuevoSS.Eps != null && !string.Equals(nuevoSS.Eps, existingSS.Eps, StringComparison.Ordinal))
                                    ssNeedsUpdate = true;
                                if (nuevoSS.Fondo_Pension != null && !string.Equals(nuevoSS.Fondo_Pension, existingSS.Fondo_Pension, StringComparison.Ordinal))
                                    ssNeedsUpdate = true;
                                if (nuevoSS.Fondo_Cesantias != null && !string.Equals(nuevoSS.Fondo_Cesantias, existingSS.Fondo_Cesantias, StringComparison.Ordinal))
                                    ssNeedsUpdate = true;

                                if (ssNeedsUpdate)
                                {
                                    // use the string overload: pass numeroDocumento + all 6 parameters
                                    conexion.Editar_Seguridad_Social(
                                        existingSS.Numero_Documento,
                                        nuevoSS.Eps,
                                        nuevoSS.Fondo_Pension,
                                        existingSS.Arl,
                                        existingSS.Caja_Compensacion,
                                        nuevoSS.Fondo_Cesantias
                                    );
                                    MessageBox.Show("Registro de seguridad social actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("No se detectaron cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        catch (InvalidOperationException invEx)
                        {
                            MessageBox.Show("No se pudo actualizar seguridad social: " + invEx.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        catch (Exception exSS)
                        {
                            MessageBox.Show("Error al modificar seguridad social: " + exSS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Call Editar_Empleado (it will validate primary-key changes and duplicates)
                    try
                    {
                        conexion.Editar_Empleado(originalNumeroDocumento, nuevo, campos.ToArray());

                        // update cache after successful update
                        originalEmpleado = nuevo;
                        originalNumeroDocumento = nuevo.Numero_Documento?.Trim() ?? "";

                        MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // --- Now update seguridad_social using comboBox values ---
                        try
                        {
                            var existingSS = conexion.Buscar_Seguridad_Social(numero);

                            if (existingSS == null)
                            {
                                // if no seguridad_social exists, add it only if at least one value provided
                                if (!string.IsNullOrWhiteSpace(eps) || !string.IsNullOrWhiteSpace(fondoPension) || !string.IsNullOrWhiteSpace(fondoCesantias))
                                {
                                    var defaultArl = "sura";
                                    var defaultCaja = "colsubsidio";
                                    conexion.Agregar_Seguridad_Social(numero, eps, fondoPension, defaultArl, defaultCaja, fondoCesantias);
                                    MessageBox.Show("Registro de seguridad social agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                // prepare partial update: set property to null to skip updating it in DB
                                var nuevoSS = new Conexion.SeguridadSocial
                                {
                                    Eps = string.IsNullOrWhiteSpace(eps) ? null : eps,
                                    Fondo_Pension = string.IsNullOrWhiteSpace(fondoPension) ? null : fondoPension,
                                    Fondo_Cesantias = string.IsNullOrWhiteSpace(fondoCesantias) ? null : fondoCesantias
                                };

                                if (nuevoSS.Eps != null || nuevoSS.Fondo_Pension != null || nuevoSS.Fondo_Cesantias != null)
                                {
                                    // use the Editar overload that accepts all required parameters
                                    conexion.Editar_Seguridad_Social(
                                        numero,
                                        nuevoSS.Eps,
                                        nuevoSS.Fondo_Pension,
                                        existingSS.Arl, // preserve current ARL value
                                        existingSS.Caja_Compensacion, // preserve current Caja value
                                        nuevoSS.Fondo_Cesantias
                                    );
                                    MessageBox.Show("Registro de seguridad social actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                // else: nothing to update
                            }
                        }
                        catch (InvalidOperationException invEx)
                        {
                            MessageBox.Show("No se pudo actualizar seguridad social: " + invEx.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exSS)
                        {
                            MessageBox.Show("Error al modificar seguridad social: " + exSS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidOperationException invEx)
                    {
                        MessageBox.Show("No se pudo actualizar: " + invEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin_Menu Back = new Admin_Menu();
            Back.Show();
            this.Hide();
        }
    }
}
