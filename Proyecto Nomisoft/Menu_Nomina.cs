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
    public partial class Menu_Nomina : Form
    {
        public Menu_Nomina()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_Menu back = new Admin_Menu();
            back.Show();
            this.Hide();
        }

        private void button_Crear_Seg_Soc_Click(object sender, EventArgs e)
        {
            Crear_Seg_Soc next = new Crear_Seg_Soc();
            next.Show();
            this.Hide();
        }
    }
}
