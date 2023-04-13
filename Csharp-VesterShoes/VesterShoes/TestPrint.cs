using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VesterShoes.Reports;

namespace VesterShoes
{
    public partial class TestPrint : Form
    {
        public TestPrint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //jobCardForm jcd = new jobCardForm("",dt,5, 4, "15", 4, 50,"Rafique");
            //jcd.Show();
        }
    }
}
