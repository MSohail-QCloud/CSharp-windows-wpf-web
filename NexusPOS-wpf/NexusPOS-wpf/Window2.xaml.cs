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
using System.Windows.Shapes;

namespace NexusPOS_wpf
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string FormName { get; set; }

        public Window2()
        {
            InitializeComponent();
        }

        private void FrameWithinGrid_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(FormName=="New_Sale")
            {
                this.Title = "New Sale";
                FrameWithinGrid.Navigate(new System.Uri("W2NewSale.xaml",
           UriKind.RelativeOrAbsolute));
            }
            else if (FormName == "New_Purchase")
            {
                this.Title = "New Purchase";
                FrameWithinGrid.Navigate(new System.Uri("Purchase.xaml",
           UriKind.RelativeOrAbsolute));
            }


            // FrameWithinGrid.Navigate(new System.Uri("AddProducts.xaml",
            //UriKind.RelativeOrAbsolute));
        }
    }
}
