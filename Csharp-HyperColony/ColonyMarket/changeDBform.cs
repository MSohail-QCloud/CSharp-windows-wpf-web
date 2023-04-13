using ColonyMarket.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColonyMarket
{
    public partial class changeDBform : Form
    {
        functions f = new functions();
        ClassConnectionString cstring = new ClassConnectionString();
        public changeDBform()
        {
            InitializeComponent();
        }

        private void changeDBform_Load(object sender, EventArgs e)
        {
            try
            {
                string abc = cstring.GetConnectionString("Accdbx");
                string[] str = abc.Split(';');
                string[] str1 = str[1].Split('=');
                //lblolddb.Text = str1[1];
                string[] str2= str1[1].Split('\\');
                lblolddb.Text = str2[str2.Length-1];
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            txtbrowsepath.Text = "";
            lblbrowsedbName.Text = "";
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            openFileDlg.DefaultExt = ".accdb";
            openFileDlg.Filter = "Text documents (.accdb)|*.accdb";
            // Set initial directory    
            //openFileDlg.InitialDirectory = @"D:\";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                txtbrowsepath.Text = openFileDlg.FileName;
                string[] str2 = txtbrowsepath.Text.Split('\\');
                lblbrowsedbName.Text = str2[str2.Length - 1];
            }
        }

        private void txtbrowsepath_TextChanged(object sender, EventArgs e)
        {
            //string abc = @"" + txtbrowsepath.Text;
            //string tst = (@abc.Replace("//", "/"));
            //if (!File.Exists(tst))
            //{
            //    txtbrowsepath.BackColor=;
            //}
            //else
            //{
            //    lblbrowsepath.BorderBrush = System.Windows.Media.Brushes.Red;
            //}
        }

        //change path
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblbrowsedbName.Text=="" || lblbrowsedbName.Text== "_______________________________________")
            {
                txtbrowsepath.Text = "No Path is Selected.";
                return;
            }
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["Accdbx"].ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+txtbrowsepath.Text+"; Jet OLEDB:Database Password=hypercolony";
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            // Get file path of current process 
            var filePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //var filePath = Application.ExecutablePath;  // for WinForms

            // Start program
            Process.Start(filePath);

            // For Windows Forms app
            Application.Exit();

            // For all Windows application but typically for Console app.
            //Environment.Exit(0);

        }
    }
}
