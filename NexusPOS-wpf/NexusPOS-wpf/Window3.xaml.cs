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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public string FormName { get; set; }
        public int PerosonID { get; set; }
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (FormName == "Addpeople")
            {
                this.Title = "Add Person";
                FrameWithinGrid.Navigate(new System.Uri("AddPeople.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (FormName == "Updatepeople")
            {
                this.Title = "Update Person Information";
                FrameWithinGrid.Navigate(new System.Uri("UpdatePeople.xaml?id='"+PerosonID+"'", UriKind.Relative));
            }
            else if (FormName == "Add_Products")
            {
                this.Title = "Add Products";

                FrameWithinGrid.Navigate(new System.Uri("AddProducts.xaml",
           UriKind.RelativeOrAbsolute));
            }
            else if (FormName == "AddTask")
            {
                this.Title = "Add Tasks";

                FrameWithinGrid.Navigate(new System.Uri("AddTask.xaml",
           UriKind.RelativeOrAbsolute));
            }
        }

       
    }
}
