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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Sales";
            
            FrameWithinGrid.Navigate(new System.Uri("Sales.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnQout_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Qoutation";
            FrameWithinGrid.Navigate(new System.Uri("Qout.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Customer";
            FrameWithinGrid.Navigate(new System.Uri("Customer.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Products";
            FrameWithinGrid.Navigate(new System.Uri("Products.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnAcountPay_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Accounts";
            FrameWithinGrid.Navigate(new System.Uri("AccountsPayable.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Registers";
            FrameWithinGrid.Navigate(new System.Uri("Register.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Users";
            FrameWithinGrid.Navigate(new System.Uri("User.xaml",
            UriKind.RelativeOrAbsolute));
        }

        //private void btnStat_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Title = "Statistics";
        //    FrameWithinGrid.Navigate(new System.Uri("Statistics.xaml",
        //    UriKind.RelativeOrAbsolute));
        //}

        private void btnHelpCenter_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "HelpCenter";
            FrameWithinGrid.Navigate(new System.Uri("Helpcenter.xaml",
            UriKind.RelativeOrAbsolute));
        }

        private void btnstatictics_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Statistics";
            FrameWithinGrid.Navigate(new System.Uri("Statistics.xaml",
            UriKind.RelativeOrAbsolute));
        }
    }
}
