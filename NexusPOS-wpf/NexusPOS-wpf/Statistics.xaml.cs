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

namespace NexusPOS_wpf
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
        }

        // btn alarm
        private void btnDebit_Click(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("Alarms.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("Settings.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void Statistics1_Loaded(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("Settings.xaml",
            UriKind.RelativeOrAbsolute));
        }
    }
}
