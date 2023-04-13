using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Backup_Application_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //link ttp://www.networkcomms.net/creating-a-wpf-file-transfer-application/

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text=="admin" && TxtPassword.Password=="admin" )
            {
                Hide();
                WorkWindow ww = new WorkWindow();
                ww.ShowDialog();

            }
            else
            {
                MessageBox.Show("Your are cheater.");
            }

        }
    }
}
