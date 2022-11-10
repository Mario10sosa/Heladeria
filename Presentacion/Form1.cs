using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
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
        private Form activeform = null;
        private void openForm(Form childrem)
        {
            if (activeform != null)
                activeform.Hide();
            activeform = childrem;
            childrem.TopLevel = false;
            childrem.FormBorderStyle = FormBorderStyle.None;
            childrem.Dock = DockStyle.Fill;
            panelFormChildren.Controls.Add(childrem);
            panelFormChildren.Tag = childrem;
            childrem.BringToFront();
            childrem.Show();

        }
        private void customizeDesing()
        {
            panelMediaSudmenu.Visible = false;
        }
        private void hideSudMenu()
        {
            if (panelMediaSudmenu.Visible == true)
                panelMediaSudmenu.Visible = false;

        }
        private void showSudMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSudMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Sistema_Click(object sender, EventArgs e)
        {
            showSudMenu(panelMediaSudmenu);
        }

        private void btnRegistroPersonal_Click(object sender, EventArgs e)
        {
            openForm(new FrmCliente());
            hideSudMenu();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void btnRegistroHelado_Click(object sender, EventArgs e)
        {
            openForm(new FrmHelados());
            hideSudMenu();
        }
    }
}
