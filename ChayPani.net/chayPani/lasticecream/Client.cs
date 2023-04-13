using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lasticecream
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void بلنگوالافارمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillScreen bls = new BillScreen();
            bls.MdiParent = this;            
            bls.Show();
            bls.clear_Selection();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void فارمزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            فارمزToolStripMenuItem.ForeColor = Color.Black;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            بلنگوالافارمToolStripMenuItem_Click( sender,  e);
        }
    }
}
