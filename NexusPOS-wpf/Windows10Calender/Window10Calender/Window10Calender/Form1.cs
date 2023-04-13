using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Window10Calender
{
    public partial class Form1 : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public Form1()
        {
            InitializeComponent();
        }

        //Subject, Date, Starttime, Duration h

        private void btnStart_Click(object sender, EventArgs e)
        {
            IList<string> lines = await FileIO.ReadLinesAsync(File);
            string[] AppointmentDetails = lines.Split(chDelimited);



            //
        }
    }
}
