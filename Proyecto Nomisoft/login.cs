using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Nomisoft
{
    public partial class login : Form
    {
        // Admin credentials (hardcoded)
        private const string AdminUser = "1";
        private const string AdminPass = "1";

        // Store real password separately so the textbox only shows a fixed mask
        private string _realPassword = string.Empty;
        private const string PasswordPlaceholder = "CONTRASEÑA";
        private const char MaskChar = '*';

        public login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

          
            this.BackgroundImageLayout = ImageLayout.Stretch; // Ajusta al tamaño del formulario
            this.Resize += (s, e) => this.Invalidate();

            // Ensure events are wired (Designer already wires some; these ensure behavior)
            this.txtPass.KeyPress -= txtPass_KeyPress;
            this.txtPass.KeyPress += txtPass_KeyPress;
            this.txtPass.KeyDown -= txtPass_KeyDown;
            this.txtPass.KeyDown += txtPass_KeyDown;
            this.txtPass.Enter -= txtPass_Enter;
            this.txtPass.Enter += txtPass_Enter;
            this.txtPass.Leave -= txtPass_Leave;
            this.txtPass.Leave += txtPass_Leave;

            // Initialize placeholder if designer default differs
            if (string.IsNullOrEmpty(txtPass.Text)) ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read values and ignore placeholder texts
            string user = (txtUser.Text ?? string.Empty).Trim();
            string pass = _realPassword; // use stored real password

            if (string.Equals(user, "USUARIO", StringComparison.OrdinalIgnoreCase)) user = string.Empty;

            // Admin shortcut
            if (user == AdminUser && pass == AdminPass)
            {
                Admin_Menu admin = new Admin_Menu();
                admin.Show();
                this.Hide();
                return;
            }

            // Allow any registered empleado to log in when user == pass == Numero_Documento
            if (!string.IsNullOrEmpty(user) && user == pass)
            {
                try
                {
                    var conexion = new Conexion();
                    var emp = conexion.Buscar_Empleado(user);
                    if (emp != null)
                    {
                        // successful employee login -> open Deprendible filtered to this document
                        Deprendible desp = new Deprendible(user);
                        desp.Show();
                        this.Hide();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error verificando credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // fallback: invalid credentials
            MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtUser_Enter(object sender, EventArgs e) { }

        private void txtUser_Leave(object sender, EventArgs e) { }

        private void txtUser_MouseEnter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtUser_MouseLeave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtPass_MouseEnter(object sender, EventArgs e) { }

        private void txtPass_MouseLeave(object sender, EventArgs e) { }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            // Clear placeholder and prepare for masked input
            if (txtPass.Text == PasswordPlaceholder || txtPass.Text == "")
            {
                _realPassword = string.Empty;
                UpdatePasswordDisplay();
                txtPass.ForeColor = Color.WhiteSmoke;
            }
        }

        // Intercept printable characters and build real password, but show one '*' per char
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ignore control keys here; handle printable characters
            if (!char.IsControl(e.KeyChar))
            {
                // append char to real password and prevent it from being shown directly
                _realPassword += e.KeyChar;
                UpdatePasswordDisplay();
                e.Handled = true; // prevent default character insertion
            }
        }

        // Handle backspace/delete and navigation keys
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (_realPassword.Length > 0)
                {
                    _realPassword = _realPassword.Substring(0, _realPassword.Length - 1);
                    UpdatePasswordDisplay();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                // Treat delete same as clear in this simple masked input
                _realPassword = string.Empty;
                UpdatePasswordDisplay();
                e.Handled = true;
            }
            // allow arrows, tab, enter to behave normally
        }

        // Keep KeyUp handler if designer references it
        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            // no-op or add additional logic if required
        }

        private void UpdatePasswordDisplay()
        {
            if (string.IsNullOrEmpty(_realPassword))
            {
                SetPasswordPlaceholder();
                return;
            }

            // show a mask with one '*' per real character
            txtPass.UseSystemPasswordChar = false;
            txtPass.Text = new string(MaskChar, _realPassword.Length);
            txtPass.ForeColor = Color.WhiteSmoke;

            // keep caret at end
            txtPass.SelectionStart = txtPass.Text.Length;
        }

        private void SetPasswordPlaceholder()
        {
            txtPass.UseSystemPasswordChar = false;
            txtPass.Text = PasswordPlaceholder;
            txtPass.ForeColor = Color.LightGray;
            txtPass.SelectionStart = 0;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            // Prevent external edits from breaking the stored password.
            // If user somehow pasted text, replace display with mask and try to sync real value length.
            // Best-effort: if the display is not the placeholder or mask, restore the appropriate display.
            if (txtPass.Focused) return; // actual input handled on KeyPress/KeyDown
            if (string.IsNullOrEmpty(_realPassword))
                SetPasswordPlaceholder();
            else
                UpdatePasswordDisplay();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_realPassword))
            {
                SetPasswordPlaceholder();
            }
            else
            {
                // keep showing mask when leaving
                UpdatePasswordDisplay();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Application.Exit();

        private void btnMinimzar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }

        private void txtPass_TextChanged_1(object sender, EventArgs e) { }

        private void TxtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
