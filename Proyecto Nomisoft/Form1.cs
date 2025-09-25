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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            

        }

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

        private void txtPass_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtPass_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.WhiteSmoke;
                txtPass.UseSystemPasswordChar = true;  
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text != "CONTRASEÑA" && txtPass.Text.Length > 0)
            {
                txtPass.UseSystemPasswordChar = true;
            }

            // Si se borra todo el texto, mostrar el placeholder sin puntitos
            if (txtPass.Text.Length == 0)
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.UseSystemPasswordChar = false;
                txtPass.ForeColor = Color.WhiteSmoke;

                // Mover el cursor al inicio
                txtPass.Select(0, 0);
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.WhiteSmoke;
                txtPass.UseSystemPasswordChar = false; 

            }
            else
            {
                // Mantener los puntitos si hay texto real
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimzar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPass.UseSystemPasswordChar == false && txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA" || string.IsNullOrEmpty(txtPass.Text))
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
