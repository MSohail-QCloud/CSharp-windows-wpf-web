using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ColonyMarket.classes;
using Color = System.Windows.Media.Color;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Forms.Label;
//using Label = System.Windows.Forms.Label;
using Pen = System.Windows.Media.Pen;
using Point = System.Windows.Point;
using Size = System.Windows.Size;
using TreeView = System.Windows.Controls.TreeView;
using System.Management;

namespace ColonyMarket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f= new functions();
        int numberOfColumns = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProject_OnClick(object sender, RoutedEventArgs e)
        {
            lblErrorMsg.Content = "";
            AddaProject ap=new AddaProject();
            ap.ShowDialog();
            //olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
            TreeView1_OnLoaded(sender,e);
            findprojectDetail();
            loadPlotPanel(1);
            loadShopPanel(1);
        }

        private void findprojectDetail()
        {
            lblErrorMsg.Content = "";
            try
            {
                lblProjectID.Content = "1".ToString();
                lblProjectname.Content = f.findName("select ProjectName  from Projects where ProjectID=1 ");
                fillOwnerslist();
                loadPlotPanel(1);
            }
            catch (Exception es)
            {
                lblErrorMsg.Content = es.Message;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblErrorMsg.Content = "";
            findprojectDetail();
            try
            {
                //varDate();
                int gridwidth =int.Parse( PlotGrid.ActualWidth.ToString());
                numberOfColumns = gridwidth/100;
                for (int i = 0; i < numberOfColumns; i++)
                {
                    PlotGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    PlotGrid.RowDefinitions.Add(new RowDefinition());
                }

                //int gridwidth = int.Parse(PlotGrid.ActualWidth.ToString());
                numberOfColumns = gridwidth / 100;
                for (int i = 0; i < numberOfColumns; i++)
                {
                    ShopGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    ShopGrid.RowDefinitions.Add(new RowDefinition());
                }
                lblProjectID.Content = "1";
                loadPlotPanel(1);
                loadShopPanel(1);
                lblErrorMsg.Content = "System ID: " + f.SystemID();
            }
            catch(Exception es)
            {
                System.Windows.MessageBox.Show(es.Message);
            }
        }

       

        public void varDate()
        {
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;

            if ( y > 2021)
            {
                System.Windows.MessageBox.Show(" Please Contact to Administrator.");
                System.Windows.Application.Current.Shutdown();
            }
        }


        private void TreeView1_OnLoaded(object sender, RoutedEventArgs e)
        {
            ////lboxProjects.Items.Clear();
            //TreeView1.Items.Clear();
            //lblErrorMsg.Content = "";
            //DataSet ds1=new DataSet();
            //ds1 = f.Select("Select ProjectName from Projects where Active=1 and Completed=0");
            //TreeViewItem item = new TreeViewItem();
            //item.IsExpanded = true;
            ////item.Header = "Running Projects";
            //if (ds1.Tables.Count > 0)
            //{
            //    foreach (DataRow row in ds1.Tables[0].Rows)
            //    {
            //        string project= (row["ProjectName"].ToString());
            //        item.Items.Add(project);
            //    }
            //}
            //TreeView1.Items.Add(item);
        }

        private void fillOwnerslist()
        {
            lboxOwners.Items.Clear();
            DataSet ds2 = new DataSet();
            ds2 = f.Select("Select PName from Profile f inner join Owners o on f.ProfileID=o.ProfileID where o.ProjectID="+lblProjectID.Content+"  ");
            
            if (ds2.Tables.Count > 0)
            {
                int sr = 1;
                foreach (DataRow row in ds2.Tables[0].Rows)
                {
                    string project = (sr +" - "+row["PName"].ToString());
                    lboxOwners.Items.Add(project);
                    sr++;
                }
            }
        }
        private void TreeView1_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            lblErrorMsg.Content = "";
            try
            {
                var item = (string)e.NewValue;
                int projnumb = f.findnumber("select ProjectID from Projects where ProjectName='" + item + "'");
                lblProjectID.Content = projnumb.ToString();
                lblProjectname.Content = item;
                fillOwnerslist();
                loadPlotPanel(projnumb);
            }
            catch (Exception es)
            {
                lblErrorMsg.Content = es.Message;
            }
        }

        private void loadPlotPanel(int projID)
        {
            PlotGrid.Children.Clear();
            int rowCounter = 0;
            int colCounter = 0;

            try
            {
                DataSet ds = new DataSet();
                if (ds.Tables["table"] != null)
                {
                    ds.Tables["table"].Clear();
                }

                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                string checkNow = "select PlotNumber,Dimensions,IsSpecial   ,IsCorner,IsParkFace,IsMainBulevard,isSold,isForSold,IsIninstallment,SaleNumber,isShop,p_s_name,p_S_number from PlotsList l inner join PlotsDimensionsList p on p.DimensionListID=l.DimensionListID where ProjectID=" + projID + " and isShop=0 order by l.PlotNumber";
                OleDbDataAdapter oladapt = new OleDbDataAdapter(checkNow, olecon);
                oladapt.Fill(ds, "table");
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                int countplots = ds.Tables["table"].Rows.Count;
                for (int j = 0; j < countplots; j++)
                {
                    string Plotno = (ds.Tables["table"].Rows[j][0].ToString());
                    string Plotname = (ds.Tables["table"].Rows[j][11].ToString());
                    string PlotDimension = (ds.Tables["table"].Rows[j][1].ToString());
                    string PlotSold = (ds.Tables["table"].Rows[j][6].ToString());
                    string isforSold = (ds.Tables["table"].Rows[j][7].ToString());
                    string isininstallment = (ds.Tables["table"].Rows[j][8].ToString());
                    string isshop = (ds.Tables["table"].Rows[j][11].ToString());

                    System.Windows.Controls.Button lPno = new System.Windows.Controls.Button
                    {
                        Margin = new Thickness(5),
                        Width = 90,
                        Height = 90,
                        Name = "lblplot_" + Plotno,
                        Content = Plotname,
                        VerticalContentAlignment = VerticalAlignment.Top,
                        BorderThickness = new Thickness(2, 2, 2, 2),
                        FontSize = 20
                    };
                    lPno.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                    lPno.Background = System.Windows.Media.Brushes.OrangeRed;
                    if (int.Parse(PlotSold) == 1)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.Yellow;
                        lPno.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (int.Parse(isininstallment) == 1)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.LawnGreen;
                        lPno.Background = System.Windows.Media.Brushes.LawnGreen;
                    }
                    if (int.Parse(isforSold) == 0 && int.Parse(isininstallment) == 0)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.White;
                        lPno.Background = System.Windows.Media.Brushes.DeepSkyBlue;
                    }

                    lPno.Click += new RoutedEventHandler(btnclick);

                    //lPno.BorderBrush = Brushes.Black;
                    Grid.SetColumn(lPno, colCounter);
                    Grid.SetRow(lPno, rowCounter);
                    PlotGrid.Children.Add(lPno);




                    //*************
                    int IsSpecial = int.Parse(ds.Tables["table"].Rows[j][2].ToString());
                    if (IsSpecial == 1)
                    {
                        //System.Windows.Controls.Label lblCorner = new System.Windows.Controls.Label
                        //{
                        //    Width = 40,
                        //    Height = 40,
                        //    Name = "lblcorn_" + PlotDimension,
                        //    VerticalAlignment = VerticalAlignment.Bottom,
                        //    Foreground = new SolidColorBrush(Colors.Red),
                        //    Content = ">",
                        //    BorderThickness = new Thickness(0, 0, 0, 0),
                        //    FontSize = 20
                        //};
                        //Grid.SetColumn(lblCorner, colCounter);
                        //Grid.SetRow(lblCorner, rowCounter);
                        //PlotGrid.Children.Add(lblCorner);




                        int IsCorner = int.Parse(ds.Tables["table"].Rows[j][3].ToString());
                        if (IsCorner == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            PlotGrid.Children.Add(p);
                        }
                        int IsParkFace = int.Parse(ds.Tables["table"].Rows[j][4].ToString());
                        if (IsParkFace == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            PlotGrid.Children.Add(p);
                        }
                        int IsMainBulevard = int.Parse(ds.Tables["table"].Rows[j][5].ToString());
                        if (IsMainBulevard == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            PlotGrid.Children.Add(p);
                        }
                    }

                    System.Windows.Controls.Label lDimen = new System.Windows.Controls.Label
                    {
                        //Width = 80,
                        //Height = 40,
                        Name = "lblplotdim_" + Plotno,
                        Margin = new Thickness(2, 0, 0, 0),
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Center,

                        Content = PlotDimension,
                        BorderThickness = new Thickness(0, 0, 0, 0),
                        FontSize = 20
                    };
                    Grid.SetColumn(lDimen, colCounter);
                    Grid.SetRow(lDimen, rowCounter);
                    PlotGrid.Children.Add(lDimen);

                    colCounter++;
                    if (colCounter >= numberOfColumns)
                    {
                        colCounter = 0;
                        rowCounter++;
                        PlotGrid.RowDefinitions.Add(new RowDefinition());
                    }
                }
                int totalplots = f.findnumber("select count(*) from PlotsList where ProjectID="+lblProjectID.Content+"");
                int soldplots = f.findnumber("select count(*) from Deals where salenumber=1");
                lblSoldStatus.Content = soldplots.ToString() + "/" + totalplots;
                lblForSaleStatus.Content = (totalplots - soldplots).ToString();
               lblinInstallStatus.Content = f.findnumber("select count(*) from Deals where isfinal=1  and isComplete=0");
                lblnoForShops.Content = f.findnumber("select count(*) from PlotsList where ProjectID=" + lblProjectID.Content + " and isShop=1");

            }
            catch (Exception es)
            {
                lblErrorMsg.Content = es.Message;
            }
        }
        private void loadShopPanel(int projID)
        {
            ShopGrid.Children.Clear();
            int rowCounter = 0;
            int colCounter = 0;

            try
            {
                DataSet ds = new DataSet();
                if (ds.Tables["table"] != null)
                {
                    ds.Tables["table"].Clear();
                }

                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                string checkNow = "select PlotNumber,Dimensions,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,isSold,isForSold,IsIninstallment,SaleNumber,isShop,p_s_name,p_S_number from PlotsList l inner join PlotsDimensionsList p on p.DimensionListID=l.DimensionListID where ProjectID=" + projID + " and isShop=1 order by l.PlotNumber";
                OleDbDataAdapter oladapt = new OleDbDataAdapter(checkNow, olecon);
                oladapt.Fill(ds, "table");
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                int countplots = ds.Tables["table"].Rows.Count;
                for (int j = 0; j < countplots; j++)
                {
                    string Plotno = (ds.Tables["table"].Rows[j][0].ToString());
                    string Plotname = (ds.Tables["table"].Rows[j][11].ToString());
                    string PlotDimension = (ds.Tables["table"].Rows[j][1].ToString());
                    string PlotSold = (ds.Tables["table"].Rows[j][6].ToString());
                    string isforSold = (ds.Tables["table"].Rows[j][7].ToString());
                    string isininstallment = (ds.Tables["table"].Rows[j][8].ToString());
                    string isshop = (ds.Tables["table"].Rows[j][11].ToString());

                    System.Windows.Controls.Button lPno = new System.Windows.Controls.Button
                    {
                        Margin = new Thickness(5),
                        Width = 90,
                        Height = 90,
                        Name = "lblplot_" + Plotno,
                        Content = Plotname,
                        VerticalContentAlignment = VerticalAlignment.Top,
                        BorderThickness = new Thickness(2, 2, 2, 2),
                        FontSize = 20
                    };
                    lPno.BorderBrush = System.Windows.Media.Brushes.Pink;
                    lPno.Background = System.Windows.Media.Brushes.Pink;
                    if (int.Parse(PlotSold) == 1)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.Yellow;
                        lPno.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (int.Parse(isininstallment) == 1)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.LawnGreen;
                        lPno.Background = System.Windows.Media.Brushes.LawnGreen;
                    }
                    if (int.Parse(isforSold) == 0 && int.Parse(isininstallment) == 0)
                    {
                        lPno.BorderBrush = System.Windows.Media.Brushes.Black;
                        lPno.Background = System.Windows.Media.Brushes.Blue;
                    }

                    lPno.Click += new RoutedEventHandler(btnclick);

                    //lPno.BorderBrush = Brushes.Black;
                    Grid.SetColumn(lPno, colCounter);
                    Grid.SetRow(lPno, rowCounter);
                    ShopGrid.Children.Add(lPno);
                    //*************
                    int IsSpecial = int.Parse(ds.Tables["table"].Rows[j][2].ToString());
                    if (IsSpecial == 1)
                    {
                        //System.Windows.Controls.Label lblCorner = new System.Windows.Controls.Label
                        //{
                        //    Width = 40,
                        //    Height = 40,
                        //    Name = "lblcorn_" + PlotDimension,
                        //    VerticalAlignment = VerticalAlignment.Bottom,
                        //    Foreground = new SolidColorBrush(Colors.Red),
                        //    Content = ">",
                        //    BorderThickness = new Thickness(0, 0, 0, 0),
                        //    FontSize = 20
                        //};
                        //Grid.SetColumn(lblCorner, colCounter);
                        //Grid.SetRow(lblCorner, rowCounter);
                        //PlotGrid.Children.Add(lblCorner);
                        int IsCorner = int.Parse(ds.Tables["table"].Rows[j][3].ToString());
                        if (IsCorner == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            ShopGrid.Children.Add(p);
                        }
                        int IsParkFace = int.Parse(ds.Tables["table"].Rows[j][4].ToString());
                        if (IsParkFace == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            ShopGrid.Children.Add(p);
                        }
                        int IsMainBulevard = int.Parse(ds.Tables["table"].Rows[j][5].ToString());
                        if (IsMainBulevard == 1)
                        {
                            Polygon p = new Polygon();
                            p.Stroke = System.Windows.Media.Brushes.Maroon;
                            p.Fill = System.Windows.Media.Brushes.Red;
                            p.StrokeThickness = 1;
                            p.HorizontalAlignment = HorizontalAlignment.Left;
                            p.VerticalAlignment = VerticalAlignment.Center;
                            p.Points = new PointCollection() { new Point(10, 67), new Point(10, 87), new Point(30, 87) };
                            //p.Points = new PointCollection() { new Point(10, 10), new Point(10,30), new Point(30, 10) };
                            Grid.SetColumn(p, colCounter);
                            Grid.SetRow(p, rowCounter);
                            ShopGrid.Children.Add(p);
                        }
                    }

                    System.Windows.Controls.Label lDimen = new System.Windows.Controls.Label
                    {
                        //Width = 80,
                        //Height = 40,
                        Name = "lblplotdim_" + PlotDimension,
                        Margin = new Thickness(2, 0, 0, 0),
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Center,

                        Content = PlotDimension,
                        BorderThickness = new Thickness(0, 0, 0, 0),
                        FontSize = 20
                    };
                    Grid.SetColumn(lDimen, colCounter);
                    Grid.SetRow(lDimen, rowCounter);
                    ShopGrid.Children.Add(lDimen);

                    colCounter++;
                    if (colCounter >= numberOfColumns)
                    {
                        colCounter = 0;
                        rowCounter++;
                        ShopGrid.RowDefinitions.Add(new RowDefinition());
                    }
                }
                int totalplots = f.findnumber("select count(*) from PlotsList where ProjectID=" + lblProjectID.Content + "");
                int soldplots = f.findnumber("select count(*) from Deals where salenumber=1");
                lblSoldStatus.Content = soldplots.ToString() + "/" + totalplots;
                lblForSaleStatus.Content = (totalplots - soldplots).ToString();
                lblinInstallStatus.Content = f.findnumber("select count(*) from Deals where isfinal=1  and isComplete=0");

            }
            catch (Exception es)
            {
                lblErrorMsg.Content = es.Message;
            }
        }

        int count_Click = 0;
        private void btnclick(object sender, RoutedEventArgs e)
        {
            string old_Plotno = lblplotID.Content.ToString();
       
            //grpPlotCorner.Visible = false;
            System.Windows.Controls.Button lbl = (sender as System.Windows.Controls.Button);
           
            string plotno = (lbl.Name);
            
            string[] info = plotno.Split('_');
            int plotn = int.Parse(info[1]);
            lblplotID.Content = plotn.ToString();

            string s = "select Dimensions,Area,plotOwner,SaleNumber,isForSold,p_s_name from PlotsList pl inner join PlotsDimensionsList pd on pl.DimensionListID=pd.DimensionListID where pl.PlotNumber=" + lblplotID.Content+ " and pl.ProjectID="+lblProjectID.Content+"";
            OleDbDataReader dr;
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            string ownerid = "";
            if (dr.Read())
            {
                lblplotDimension.Content = (dr.GetValue(0).ToString());
                lblplotArea.Content = (dr.GetValue(1).ToString());
                ownerid = (dr.GetValue(2).ToString());
                lblSaleID.Content = (dr.GetValue(3).ToString());
                lblplotName.Content = (dr.GetValue(5).ToString());
                string isforsold= (dr.GetValue(4).ToString());
                if (isforsold=="0")
                {
                    rbtnNotForSale.IsChecked = true;
                }
                else
                {
                    rbtnforsale.IsChecked = true;
                }
                
            }
            if (olecon.State != ConnectionState.Closed)
            {
                olecon.Close();

            }
            dr.Close();
            rbtnNotForSale.Visibility = Visibility.Visible;
            rbtnforsale.Visibility = Visibility.Visible;
            if (ownerid=="")
            {
                lblOwnerName.Content = "Project Ownership";
            }
            else
            {
                int plotownerid = int.Parse(ownerid);
                lblOwnerName.Content = f.findName("select PName from Profile where ProfileID="+plotownerid+"");
            }
            if (lblplotID.Content.ToString() == old_Plotno)
            {
                if (lblplotID.Content.ToString() == "")
                {
                    lblErrorMsg.Content = "Select Plot Number.";
                    return;
                }
                Soldfm sm = new Soldfm(int.Parse(lblProjectID.Content.ToString()), int.Parse(lblplotID.Content.ToString()), int.Parse(lblSaleID.Content.ToString()), (lblProjectname.Content.ToString()));
                sm.Show();
                loadPlotPanel(int.Parse(lblProjectID.Content.ToString()));
            }
            else
            {
                old_Plotno = lblplotID.Content.ToString();
            }
            //bool test =
            //    f.Selectbool("Select FacilityName from ColonyFascilites where FacilityName='" + txtFacilities.Text + "' and ProjectID=" + lblProjectID.Text + " ");
            //if (test)
            //{
            //    lblErrorMsg.Content= "This Facility is already Add for this project.";
            //    return;
            //}

            //lblgrpPlotsetPlotCorner.Text = plotno.ToString();
            //grpPlotCorner.Visible = true;
        }

        private void lboxProjects_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lblErrorMsg.Content = "zsdfsfds";
            //try
            //{
            //    //var item = (string)e.NewValue;
            //    int projnumb = f.findnumber("select ProjectID from Projects where ProjectName='" + item + "'");
            //    lblProjectID.Content = projnumb.ToString();
            //    lblProjectname.Content = item;
            //    fillOwnerslist();
            //    loadPlotPanel(projnumb);
            //}
            //catch (Exception es)
            //{
            //    lblErrorMsg.Content = es.Message;
            //}
        }

        private void lboxProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblplotID.Content.ToString()=="")
            {
                lblErrorMsg.Content = "Select Plot Number.";
                return;
            }
            Soldfm sm=new Soldfm(int.Parse(lblProjectID.Content.ToString()),int.Parse(lblplotID.Content.ToString()),int.Parse(lblSaleID.Content.ToString()),(lblProjectname.Content.ToString()));
            sm.ShowDialog();
            loadPlotPanel(1);
            loadShopPanel(1);
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lblProjectID.Content.ToString() == "" && lblplotID.Content.ToString() == "")
                {
                    return;
                }
                int salnumb = f.createNumber("Select salenumber  from Deals where  ProjectID=" + lblProjectID.Content + " and PlotNumber=" + lblplotID.Content + " order by DealID desc");
                f.Update("update PlotsList set isForSold=1,isSold=0,SaleNumber=" + salnumb + "  where ProjectID=" + lblProjectID.Content + " and PlotNumber=" + lblplotID.Content + " ");
                loadPlotPanel(int.Parse(lblProjectID.Content.ToString()));
            }
            catch (Exception es)
            {
                lblErrorMsg.Content = "This Project is Read-Only.";
            }
            
        }

        private void RbtnNotForSale_OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
            if (lblProjectID.Content.ToString() == "" && lblplotID.Content.ToString() == "")
                        {
                            return;
                        }
                        int salnumb = f.findnumber("Select salenumber  from Deals where  ProjectID=" + lblProjectID.Content + " and PlotNumber=" + lblplotID.Content + " order by DealID desc");
                        f.Update("update PlotsList set isForSold=0,SaleNumber=" + salnumb + "  where ProjectID=" + lblProjectID.Content + " and PlotNumber=" + lblplotID.Content + " and IsIninstallment=0");
                        loadPlotPanel(int.Parse(lblProjectID.Content.ToString()));
                        loadShopPanel(int.Parse(lblProjectID.Content.ToString()));
            }
            catch (Exception es)
            {
                lblErrorMsg.Content = es.Message;
            }
            
        }

        private void BtnReports_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblProjectID.Content.ToString()=="")
            {
                lblErrorMsg.Content = "Please Select Project ID";
                return;
            }
            AllReportform ap=new AllReportform(int.Parse(lblProjectID.Content.ToString()));
            ap.Show();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown(0);
        }

        private void Btnrefresh_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblProjectID.Content=="")
            {
                return;
            }
            loadPlotPanel(int.Parse(lblProjectID.Content.ToString()));
            loadShopPanel(int.Parse(lblProjectID.Content.ToString()));
        }

        private void BtnAgents_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblProjectID.Content.ToString() == "")
            {
                lblErrorMsg.Content = "Please Select Project ID";
                return;
            }
            Agentfrm ap = new Agentfrm();
            ap.ShowDialog();
        }

        private void BtnLedger_OnClick(object sender, RoutedEventArgs e)
        {
            Ledger ap = new Ledger();
            ap.ShowDialog();
        }

        private void Btnchangepassword_OnClick(object sender, RoutedEventArgs e)
        {
            MyProfile ap = new MyProfile();
            ap.ShowDialog();
        }

        private void BtnSTatics_OnClick(object sender, RoutedEventArgs e)
        {
            Statistics ap = new Statistics(int.Parse(lblProjectID.Content.ToString()));
            ap.ShowDialog();
        }

        private void btnChangeDB_Click(object sender, RoutedEventArgs e)
        {
            changeDBform ap = new changeDBform();
            ap.ShowDialog();
        }
    }
}
