using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ColonyMarket.classes;
using MessageBox = System.Windows.MessageBox;
using System.IO;
using System.Diagnostics;

namespace ColonyMarket
{
    public partial class AddaProject : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f = new functions();
        public AddaProject()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {


        }

        private void AddaProject_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            dtPickerColonyStart.Value = DateTime.Now;
            grpHypeMarket.Location = new Point(273, 54);
            grpEmployees.Location = new Point(273, 54);
            grpDevelopers.Location = new Point(273, 54);
            grpExpenses.Location = new Point(273, 54);
            grpOwnerDetail.Location = new Point(273, 54);
            grpRules.Location = new Point(273, 54);
            grpPlots.Location = new Point(273, 54);
            grpProjectName.Location = new Point(273, 54);
            grpHypeMarket.Visible = true;
            grpDevelopers.Visible = false;
            grpEmployees.Visible = false;
            grpExpenses.Visible = false;
            grpOwnerDetail.Visible = false;
            grpRules.Visible = false;
            grpPlots.Visible = false;
            grpProjectName.Visible = false;
            LoadCombogrpPlotDimension();
            loadProjName();
            loadGridFacility();
            dtgrpExpensesDateExpense.Value = DateTime.Now;
            //tbl_main.Columns.Add("Ser#");
            //tbl_main.Columns.Add("Head");
            //tbl_main.Columns.Add("ExpDetail");
            //tbl_main.Columns.Add("Amount");
        }


        private void loadProjName()
        {
            if (lblProjectID.Text == "")
            {
                return;
            }
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                int b = 0;
                string query = "Select  ProjectName,CreationDate,Area,Price,Rate_Marla,XtraRate_on_special,MinimumAdvance  from Projects where ProjectID=" + lblProjectID.Text + "";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtProjectName.Text = dr.GetValue(0).ToString();
                    dtPickerColonyStart.Value = DateTime.Parse(dr.GetValue(1).ToString());
                    txtgrpPnameArea.Text = dr.GetValue(2).ToString();
                    txtgrpPnameProjectPrice.Text = dr.GetValue(3).ToString();
                    txtgrpownerRateMarla.Text = dr.GetValue(4).ToString();
                    txtXtraSpecialMarla.Text = dr.GetValue(5).ToString();
                    txtgrpOwnerMinimumAdvance.Text = dr.GetValue(6).ToString();
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                //int b = 0;
                string query = "Select * from  Profile where ProfileID=0 ";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtgrpprjNameCNIC.Text = dr.GetValue(2).ToString();
                    txtgrpprjNameAddress.Text = dr.GetValue(4).ToString();
                    txtgrpprjNameMobileNumber.Text = dr.GetValue(3).ToString();
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LblErrorMsg.Text = "";
            string node = treeView1.SelectedNode.Name.ToString();
            if (node == "ProjectName")
            {
                grpHypeMarket.Visible = false;
                grpEmployees.Visible = false;
                grpExpenses.Visible = false;
                grpOwnerDetail.Visible = false;
                grpDevelopers.Visible = false;
                grpRules.Visible = false;
                grpPlots.Visible = false;
                grpProjectName.Visible = true;
                return;
            }
            if (node == "OwnersDetail")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                if (lblProjectID.Text != "")
                {
                    grpHypeMarket.Visible = false;
                    grpEmployees.Visible = false;
                    grpDevelopers.Visible = false;
                    grpExpenses.Visible = false;
                    grpOwnerDetail.BringToFront();
                    grpRules.Visible = false;
                    grpPlots.Visible = false;
                    grpProjectName.Visible = false;
                    grpOwnerDetail.Visible = true;

                    FillOwnersList();
                }
                else
                {
                    LblErrorMsg.Text = "First Add Project Name.";
                }

                return;
            }
            if (node == "Plots")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                if (lblProjectID.Text != "")
                {
                    grpHypeMarket.Visible = false;
                    grpEmployees.Visible = false;
                    grpDevelopers.Visible = false;
                    grpExpenses.Visible = false;
                    grpOwnerDetail.Visible = false;
                    grpRules.Visible = false;
                    grpProjectName.Visible = false;
                    grpPlots.Visible = true;

                    loadPanel();
                }
                else
                {
                    LblErrorMsg.Text = "First Add Project Name.";
                }
                return;

            }
            if (node == "Rules")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                if (lblProjectID.Text != "")
                {
                    grpHypeMarket.Visible = false;
                    grpEmployees.Visible = false;
                    grpDevelopers.Visible = false;
                    grpExpenses.Visible = false;
                    grpOwnerDetail.Visible = false;
                    grpPlots.Visible = false;
                    grpProjectName.Visible = false;
                    grpRules.Visible = true;

                    findrules();
                }
                else
                {
                    LblErrorMsg.Text = "First Add Project Name.";
                }
                return;
            }
            if (node == "Employees")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                if (lblProjectID.Text != "")
                {
                    grpHypeMarket.Visible = false;
                    grpExpenses.Visible = false;
                    grpDevelopers.Visible = false;
                    grpOwnerDetail.Visible = false;
                    grpRules.Visible = false;
                    grpPlots.Visible = false;
                    grpProjectName.Visible = false;
                    grpEmployees.Visible = true;

                    LoadCombogrpEmpDesignation();
                    FillEmployeeList();
                }
                else
                {
                    LblErrorMsg.Text = "First Add Project Name.";
                }
                return;
            }
            if (node == "Expenses")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                grpHypeMarket.Visible = false;
                grpEmployees.Visible = false;
                grpDevelopers.Visible = false;
                grpOwnerDetail.Visible = false;
                grpRules.Visible = false;
                grpPlots.Visible = false;
                grpProjectName.Visible = false;
                grpExpenses.Visible = true;
                loadComboExpenseHead();
                loadComboExpenseCat();
                return;
            }
            if (node == "Developers")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                grpHypeMarket.Visible = false;
                grpEmployees.Visible = false;
                grpDevelopers.Visible = false;
                grpOwnerDetail.Visible = false;
                grpRules.Visible = false;
                grpPlots.Visible = false;
                grpProjectName.Visible = false;
                grpExpenses.Visible = false;
                grpDevelopers.Visible = true;
                FillDeveloperList();
                return;
            }
            if (node == "HypeMarket")
            {
                int projid = f.findnumber("select top 1 ProjectID from Projects");
                if (projid == 0)
                {
                    LblErrorMsg.Text = "Please Add Project Detail.";
                    treeView1.SelectedNode = treeView1.Nodes.Find("ProjectName", true)[0];
                    return;
                }
                grpEmployees.Visible = false;
                grpDevelopers.Visible = false;
                grpExpenses.Visible = false;
                grpOwnerDetail.Visible = false;
                grpRules.Visible = false;
                grpPlots.Visible = false;
                grpProjectName.Visible = false;
                grpHypeMarket.Visible = true;
            }
        }
        //DataTable tbl_main = new DataTable("tbl_main");
        private void findrules()
        {
            bool chkrules = f.Selectbool("Select NoofInstallments from Rules where ProjectID=" + lblProjectID.Text + "");
            if (chkrules)
            {
                txtgrpRulesNoofInstallments.Enabled = true;
                txtgrpRulesNoofInstallments.Text =
                (f.findnumber("Select NoofInstallments from Rules where ProjectID=" + lblProjectID.Text + "").ToString());
                btngrprulesmodify.Visible = true;
            }

        }

        int ProjectID;

        private void btnGrpProjectNameSave_Click(object sender, EventArgs e)
        {
            try
            {


                LblErrorMsg.Text = "";
                if (txtProjectName.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Project Name.";
                    return;
                }
                if (txtgrpownerRateMarla.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Rate/Marla.";
                    return;
                }
                if (txtgrpprjNameCNIC.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter CNIC.";
                    return;
                }

                if (txtXtraSpecialMarla.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Xtra Rate / Marla on special Location.";
                    return;
                }
                if (txtgrpOwnerMinimumAdvance.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Minimum Advance.";
                    return;
                }
                //bool chkName= f.Selectbool("SELECT ProjectName from Projects where ProjectName='" + txtProjectName.Text + "'  and ProjectID!="+lblProjectID.Text+" ");
                //if (chkName==true)
                //{
                //    LblErrorMsg.Text = "This Name is Already Registered";
                //    return;
                //}
                DateTime dt = dtPickerColonyStart.Value;
                string date = dt.ToString("dd-MM-yyyy");
                LblErrorMsg.Text = "";
                bool findpid = f.Selectbool("SELECT ProjectID from Projects where ProjectID=" + lblProjectID.Text + " order by ProjectID desc");
                if (findpid == true)
                {
                    f.Update("update Projects set ProjectName='" + txtProjectName.Text + "',CreationDate='" + date + "',Area=" + txtgrpPnameArea.Text + " , Price=" + txtgrpPnameProjectPrice.Text + ",Rate_Marla=" + txtgrpownerRateMarla.Text + ",XtraRate_on_special=" + txtXtraSpecialMarla.Text + ",MinimumAdvance=" + txtgrpOwnerMinimumAdvance.Text + " where ProjectID=" + lblProjectID.Text + " ");
                    bool finprofileid = f.Selectbool("Select ProfileID from Profile where ProfileID=0");
                    if (finprofileid == true)
                    {
                        f.Update("update Profile set PName='" + txtProjectName.Text + "',Pcnic=" + txtgrpprjNameCNIC.Text + ",PMobile=" + txtgrpprjNameMobileNumber.Text + " , PAddress='" + txtgrpprjNameAddress.Text + "' where ProfileID=0 ");
                    }
                    else
                    {
                        f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(0,'" + txtProjectName.Text + "'," + txtgrpprjNameCNIC.Text + "," + txtgrpprjNameMobileNumber.Text + ",'" + txtgrpprjNameAddress.Text + "')");
                    }
                    LblErrorMsg.Text = "Data Updated";
                }
                else
                {
                    int pid = f.createNumber("SELECT Top 1 ProjectID from Projects order by ProjectID desc");
                    ProjectID = pid;
                    lblProjectID.Text = pid.ToString();
                    bool finprofileid = f.Selectbool("Select ProfileID from Profile where ProfileID=0");
                    if (finprofileid == true)
                    {
                        f.Update("update Profile set PName='" + txtProjectName.Text + "',Pcnic=" + txtgrpprjNameCNIC.Text + ",PMobile=" + txtgrpprjNameMobileNumber.Text + " , PAddress='" + txtgrpprjNameAddress.Text + "' where ProfileID=0 ");
                    }
                    else
                    {
                        f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(0,'" + txtProjectName.Text + "'," + txtgrpprjNameCNIC.Text + "," + txtgrpprjNameMobileNumber.Text + ",'" + txtgrpprjNameAddress.Text + "')");
                    }
                    //int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(0,'" + txtProjectName.Text + "'," + txtgrpprjNameCNIC.Text + "," + txtgrpprjNameMobileNumber.Text + ",'" + txtgrpprjNameAddress.Text + "')");
                    LblErrorMsg.Text = "Data Saved";
                }
            }
            catch (Exception s)
            {
                LblErrorMsg.Text = s.Message;
            }
            try
            {
                string abc = cstring.GetConnectionString("Accdbx");
                string[] str = abc.Split(';');
                string[] str1 = str[1].Split('=');
                string[] str2 = str1[1].Split('\\');
                string oldNameFullPath = str1[1];
                string newNameFullPath = "";
                newNameFullPath = Path.GetDirectoryName(oldNameFullPath);
                newNameFullPath = Path.Combine(newNameFullPath, txtProjectName.Text + ".accdb");
                System.IO.File.Move(oldNameFullPath, newNameFullPath);

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["Accdbx"].ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + newNameFullPath + "; Jet OLEDB:Database Password=hypercolony";
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
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

            //txtProjectName.Enabled = false;
            //lblProjectName.Text = txtProjectName.Text;
            //btnGrpProjectNameSave.Enabled = false;
            //dtPickerColonyStart.Enabled = false;
            //txtgrpPnameArea.Enabled = false;
            //txtgrpPnameProjectPrice.Enabled = false;

        }

        ClassConnectionString cstring = new ClassConnectionString();
        private void btngrpOwnerDetailAddOwner_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (txtgrpOwnerDetailAddCnic.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill CNIC.";
                    return;
                }
                if (txtgrpOwnerDetailAddCnic.Text.Length != 13)
                {
                    LblErrorMsg.Text = "Please Enter 13-Digit CNIC Number without dashes.";
                    return;
                }
                if (txtgrpOwnerDetailAddName.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill Name.";
                    return;
                }
                if (txtgrpOwnerDetailAddAddress.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill Address.";
                    return;
                }
                if (txtgrpOwnerDetailAddMobile.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Mobile Number.";
                    return;
                }
                if (lblgrpownerdetailProfileID.Text == "")
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtgrpOwnerDetailAddName.Text + "','" + txtgrpOwnerDetailAddCnic.Text + "','" + txtgrpOwnerDetailAddMobile.Text + "','" + txtgrpOwnerDetailAddAddress.Text + "')");
                    lblgrpownerdetailProfileID.Text = (f.findnumber("SELECT ProfileID from Profile where Pcnic='" + txtgrpOwnerDetailAddCnic.Text + "' order by ProfileID desc")).ToString();
                }
                bool test =
                    f.Selectbool("Select * from Owners where ProfileID=" + lblgrpownerdetailProfileID.Text +
                                 " and ProjectID=" + lblProjectID.Text + " ");
                if (test)
                {
                    LblErrorMsg.Text = "This owner is already registered for this project.";
                    return;
                }
                string profit = combogrpOwnerProfit.Text;
                profit = profit.Replace(@"%", "");
                int profitshare = int.Parse(profit);
                //LblErrorMsg.Text = "";
                f.Insert("insert into Owners(ProfileID,ProjectID,ProfitShare,SpNote) values('" + lblgrpownerdetailProfileID.Text + "','" + lblProjectID.Text + "'," + profitshare + ",'" + txtgrpOwnerNote.Text + "')");
                txtgrpOwnerDetailAddName.Text = "";
                txtgrpOwnerDetailAddCnic.Text = "";
                txtgrpOwnerDetailAddMobile.Text = "";
                txtgrpOwnerDetailAddAddress.Text = "";
                FillOwnersList();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void FillOwnersList()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select f.PName,f.Pcnic,f.PMobile,f.PAddress,o.ProfitShare,o.SpNote from Profile f inner join Owners o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                    lblProjectID.Text + "";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridOwnerDetail1.AutoGenerateColumns = false;
                gridOwnerDetail1.DataSource = ds.Tables["Table"].DefaultView;
                gridOwnerDetail1.ClearSelection();
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    arrorderid = int.Parse(dr["orderID"].ToString());
                //    arrMaterOrderID = int.Parse(dr["MaterOrderID"].ToString());
                //    arrSortID = int.Parse(dr["SortID"].ToString());
                //    arrProfileId = int.Parse(dr["ProfileId"].ToString());
                //    arrCopanyname = (dr["Copanyname"].ToString());
                //    arrItemsID = int.Parse(dr["ItemsID"].ToString());
                //    arrItemsDescription = (dr["ItemsDescription"].ToString());
                //    arrIsStampAdded = int.Parse(dr["IsStampAdded"].ToString());
                //    arrisBoxAdded = int.Parse(dr["isBoxAdded"].ToString());
                //    arrItemsQty = int.Parse(dr["ItemsQty"].ToString());
                //    arrjobStates = int.Parse(dr["jobStates"].ToString());
                //    string insertQuery = "INSERT INTO tblProcessing (orderID,MaterOrderID,SortID,ProfileId,Copanyname,ItemsID,ItemsDescription,IsStampAdded,isBoxAdded,ItemsQty,Enteredon,Enteredby,jobStates) VALUES ('" + arrorderid + "','" + arrMaterOrderID + "','" + arrSortID + "','" + arrProfileId + "','" + arrCopanyname + "','" + arrItemsID + "','" + arrItemsDescription + "','" + arrIsStampAdded + "','" + arrisBoxAdded + "','" + arrItemsQty + "','" + dt + "','" + "Enteredby" + "','" + arrjobStates + "')";
                //    using (SqlCommand comm = new SqlCommand(insertQuery, sqlcon))
                //    {
                //        comm.ExecuteNonQuery();
                //    }

                //}
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }
        }
        private void FillEmployeeList()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select * from ((Profile f inner join EmployeesProject e on e.ProfileID = f.ProfileID ) inner join DesignationsList l  on  e.DesignationID=l.DesignationID) where e.ProjectID = " +
                    lblProjectID.Text + "";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridEmployeeList.AutoGenerateColumns = false;
                gridEmployeeList.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void btngrpPlotaddDimension_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (txtgrpPlotsNodimensionWidth.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Width.";
                    return;
                }
                if (txtgrpPlotsNodimensionLength.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Length.";
                    return;
                }
                bool abc = f.Selectbool("select * from PlotsDimensionsList where Dimensions='" + txtgrpPlotsNodimensionWidth.Text + "'");
                float dwidth = float.Parse(txtgrpPlotsNodimensionWidth.Text);
                float dLength = float.Parse(txtgrpPlotsNodimensionLength.Text);
                //float ar = (dwidth * dLength) / 272;
                string dimension = dwidth + "X" + dLength;
                if (abc == false)
                {
                    f.Insert("insert into PlotsDimensionsList (Dimensions,DWidth,DLength,Area,Active) values('" + dimension + "'," + dwidth + "," + dLength + "," + txtgrpPlotsArea.Text + ",'1')");
                }
                LoadCombogrpPlotDimension();
                txtgrpPlotsNodimensionWidth.Text = "";
                txtgrpPlotsNodimensionLength.Text = "";
                txtgrpPlotsNodimensionWidth.Enabled = false;
                txtgrpPlotsNodimensionLength.Enabled = false;
                btngrpPlotaddDimension.Visible = false;
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void LoadCombogrpPlotDimension()
        {
            try
            {
                OleDbCommand sqlCmd = new OleDbCommand("select Dimensions,DimensionListID from PlotsDimensionsList where Active=1 ", olecon);
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                OleDbDataReader sqlReader = sqlCmd.ExecuteReader();
                Dictionary<string, string> DictionaryCustomer = new Dictionary<string, string>();
                DictionaryCustomer.Add("-1", "--No-- Dimension");
                while (sqlReader.Read())
                {
                    string name = sqlReader["Dimensions"].ToString();
                    string Value = (sqlReader["DimensionListID"].ToString());
                    DictionaryCustomer.Add(Value, name);
                }
                CombGrpPlotDimensions.DisplayMember = "Value";
                CombGrpPlotDimensions.ValueMember = "Key";
                CombGrpPlotDimensions.DataSource = new BindingSource(DictionaryCustomer, null);

                //CombGrpPlotDimensions.SelectedIndex = 0;
                sqlReader.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }

        }
        private void LoadCombogrpEmpDesignation()
        {
            try
            {
                OleDbCommand sqlCmd = new OleDbCommand("select DesignationTitle,DesignationID from DesignationsList where Active=1 ", olecon);
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                OleDbDataReader sqlReader = sqlCmd.ExecuteReader();
                Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
                DictionaryCustomer.Add(-1, "--No-- Designation");
                while (sqlReader.Read())
                {
                    string name = sqlReader["DesignationTitle"].ToString();
                    int Value = int.Parse(sqlReader["DesignationID"].ToString());
                    DictionaryCustomer.Add(Value, name);
                }
                combgrpEmployeeDesignationList.DisplayMember = "Value";
                combgrpEmployeeDesignationList.ValueMember = "Key";
                combgrpEmployeeDesignationList.DataSource = new BindingSource(DictionaryCustomer, null);
                //CombGrpPlotDimensions.SelectedIndex = 0;
                sqlReader.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }

        }

        private void CombGrpPlotDimensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CombGrpPlotDimensions.SelectedIndex == 0)
            {
                txtgrpPlotsNodimensionWidth.Enabled = true;
                txtgrpPlotsNodimensionLength.Enabled = true;
                btngrpPlotaddDimension.Visible = true;
            }
            else
            {
                txtgrpPlotsNodimensionWidth.Enabled = false;
                txtgrpPlotsNodimensionLength.Enabled = false;
                btngrpPlotaddDimension.Visible = false;

                txtplotAreaOnDimension.Text = f.findFloatNumber("select Area from PlotsDimensionsList where DimensionListID=" + CombGrpPlotDimensions.SelectedValue + "").ToString();
            }
        }

        //btngrpPlotAddPlots
        private void button1_Click(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            if (CombGrpPlotDimensions.SelectedIndex < 1)
            {
                LblErrorMsg.Text = "Must select Dimension.";
                return;
            }
            if (txtgrpPlotStartPlotNumb.Text == "")
            {
                LblErrorMsg.Text = "Must Enter Starting Plot Number.";
                return;
            }
            if (txtGrpNoofPlot.Text == "")
            {
                LblErrorMsg.Text = "Must Enter No of Plots of selected Dimension " + CombGrpPlotDimensions.SelectedText + ".";
                return;
            }
            if (txtplotAreaOnDimension.Text == "")
            {
                LblErrorMsg.Text = "Must Enter Size of Plot of selected Dimension " + CombGrpPlotDimensions.SelectedText + ".";
                return;
            }
            try
            {
                int numbofplots = int.Parse(txtGrpNoofPlot.Text);
                int startNo = int.Parse(txtgrpPlotStartPlotNumb.Text);
                for (int i = 0; i < numbofplots; i++)
                {
                    bool abc = f.Selectbool("select PlotNumber from PlotsList where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + startNo + " ");
                    if (abc)
                    {
                        f.Update("update PlotsList set DimensionListID=" + CombGrpPlotDimensions.SelectedValue + ", plotArea=" + txtplotAreaOnDimension.Text + " where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + startNo + "");
                    }
                    else
                    {
                        f.Insert("insert into PlotsList (ProjectID,DimensionListID,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,plotArea,isShop,p_s_name,p_S_number,plotOwner) values(" + lblProjectID.Text + "," + CombGrpPlotDimensions.SelectedValue + ",0,0,0,0," + txtplotAreaOnDimension.Text + "," + ComboPlotOrShop.SelectedIndex + ",'" + ComboPlotOrShop.Text + "-" + startNo + "'," + startNo + ",0)");
                    }
                    startNo++;
                    txtgrpPlotStartPlotNumb.Text = "";
                    txtGrpNoofPlot.Text = "";
                }
                loadPanel();

            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void loadPanel()
        {
            int xaxis = 5;
            int yaxis = 5;
            int rWidth = 100;
            int rLength = 100;
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            int rowCounter = 0;


            panel1.Controls.Clear();
            DataSet ds = new DataSet();
            if (ds.Tables["table"] != null)
            {
                ds.Tables["table"].Clear();
            }

            olecon.Open();
            string checkNow = "select PlotNumber,Dimensions,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,p_s_name,p_S_number from PlotsList l inner join PlotsDimensionsList p on p.DimensionListID=l.DimensionListID where ProjectID=" + lblProjectID.Text + " order by l.PlotNumber";
            OleDbDataAdapter oladapt = new OleDbDataAdapter(checkNow, olecon);
            oladapt.Fill(ds, "table");
            olecon.Close();
            //PictureBox[] Shapes = new PictureBox[ds.Tables["table"].Rows.Count];
            int countplots = ds.Tables["table"].Rows.Count;
            for (int j = 0; j < countplots; j++)
            {
                g.DrawRectangle(p, xaxis, yaxis, rWidth, rLength);
                //label
                string Plotno = (ds.Tables["table"].Rows[j][6].ToString());
                string PlotDimension = (ds.Tables["table"].Rows[j][1].ToString());
                //Rectangle[] Shapes = new Rectangle[countplots];
                Label lpno = new Label
                {
                    Location = new Point(xaxis + 7, yaxis + 2),
                    Size = new Size(80, 20),
                    Name = "lblplotno_" + Plotno,
                    Text = Plotno,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };
                lpno.Click += new EventHandler(onclickgrpplotlbl);
                Label lDimen = new Label
                {
                    Location = new Point(xaxis + 5, yaxis + 30),
                    Size = new Size(90, 20),
                    Name = "lblplotdim_" + PlotDimension,
                    Text = PlotDimension,
                    Font = new Font("Arial", 16, FontStyle.Regular)
                };

                panel1.Controls.Add(lpno);
                panel1.Controls.Add(lDimen);
                //*************

                int isSpecial = int.Parse(ds.Tables["table"].Rows[j][2].ToString());
                if (isSpecial == 1)
                {
                    int iscorner = int.Parse(ds.Tables["table"].Rows[j][3].ToString());
                    if (iscorner == 1)
                    {
                        g.DrawArc(p, xaxis, yaxis, rWidth, rLength, 0, 90);

                    }
                    int IsParkFace = int.Parse(ds.Tables["table"].Rows[j][4].ToString());
                    if (IsParkFace == 1)
                    {
                        g.DrawArc(p, xaxis, yaxis, rWidth, rLength, 0, 90);

                    }
                    int IsMainBulevard = int.Parse(ds.Tables["table"].Rows[j][4].ToString());
                    if (IsMainBulevard == 1)
                    {
                        g.DrawArc(p, xaxis, yaxis, rWidth, rLength, 0, 90);
                    }
                }
                rowCounter++;
                xaxis = xaxis + rWidth + 5;
                if (rowCounter == 5)
                {
                    rowCounter = 0;
                    yaxis = yaxis + rLength + 5;
                    xaxis = 5;
                }
            }
            panel1.Show();
        }

        public void onclickgrpplotlbl(object sender, EventArgs e)
        {
            grpPlotCorner.Visible = false;
            Label lbl = (sender as Label);
            string plotname = (lbl.Text);
            int plotno = f.findnumber("select PlotNumber from PlotsList where p_s_name='" + plotname + "' ");
            lblgrpPlotsetPlotCorner.Text = plotno.ToString();
            grpPlotCorner.Visible = true;
        }

        private void grpPlotCorner_VisibleChanged(object sender, EventArgs e)
        {
            if (grpPlotCorner.Visible)
            {
                int IsSpecial = f.findnumber("select IsSpecial from PlotsList where PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " and ProjectID=" + lblProjectID.Text + "");
                if (IsSpecial == 0)
                {
                    rdbtngrpPlotNone.Select();
                    return;
                }
                int iscorner = f.findnumber("select IsCorner from PlotsList where PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " and ProjectID=" + lblProjectID.Text + "");
                if (iscorner == 0)
                {
                    rdbtngrpPlotOneCorner.Select();
                    return;
                }
                int ismain = f.findnumber("select IsMainBulevard from PlotsList where PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " and ProjectID=" + lblProjectID.Text + "");
                if (ismain == 0)
                {
                    rdbtngrpPlot4Corner.Select();
                    return;
                }
                int IsParkFace = f.findnumber("select IsParkFace from PlotsList where PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " and ProjectID=" + lblProjectID.Text + "");
                if (IsParkFace == 0)
                {
                    rdbtngrpPlot2Corner.Select();
                }
            }
        }

        //none
        private void rdbtngrpPlotNone_CheckedChanged(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            if (rdbtngrpPlotNone.Checked)
            {
                try
                {
                    f.Update("update PlotsList set IsSpecial=0 , IsCorner=0 , IsParkFace=0 , IsMainBulevard=0 where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " ");
                }
                catch (Exception es)
                {
                    LblErrorMsg.Text = es.Message;
                }
                loadPanel();
            }
        }

        //corner
        private void rdbtngrpPlotOneCorner_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (rdbtngrpPlotOneCorner.Checked)
                {
                    f.Update("update PlotsList set IsSpecial=1 , IsCorner=1 , IsParkFace=0 , IsMainBulevard=0 where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " ");
                    loadPanel();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }
        //park face
        private void rdbtngrpPlot2Corner_CheckedChanged(object sender, EventArgs e)

        {
            try
            {
                LblErrorMsg.Text = "";
                if (rdbtngrpPlot2Corner.Checked)
                {
                    f.Update("update PlotsList set IsSpecial=1 , IsParkFace=1 , IsMainBulevard=0 where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " ");
                    loadPanel();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        //main bule
        private void rdbtngrpPlot4Corner_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (rdbtngrpPlot4Corner.Checked)
                {
                    f.Update("update PlotsList set IsSpecial=1 , IsMainBulevard=1 ,  IsCorner=0 , IsParkFace=0 where ProjectID=" + lblProjectID.Text + " and PlotNumber=" + lblgrpPlotsetPlotCorner.Text + " ");
                    loadPanel();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void grpRules_Enter(object sender, EventArgs e)
        {

        }

        private void btngrpRulesSaveRules_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                f.Insert("insert into Rules (ProjectID,NoofInstallments) VALUES(" + lblProjectID.Text + "," + txtgrpRulesNoofInstallments.Text + ")");
                txtgrpRulesNoofInstallments.Enabled = false;
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void btngrprulesmodify_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                f.Update("update Rules  set NoofInstallments=" + txtgrpRulesNoofInstallments.Text + " where ProjectID=" + lblProjectID.Text + "");
                txtgrpRulesNoofInstallments.Enabled = false;
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void btngrpEmployeeAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (txtgrpEmployeeEmpCNIC.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill CNIC.";
                    return;
                }
                if (txtgrpEmployeeEmpCNIC.Text.Length != 13)
                {
                    LblErrorMsg.Text = "Please Enter 13-Digit CNIC Number without dashes.";
                    return;
                }
                if (txtgrpEmployeeEmpName.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Name.";
                    return;
                }
                if (txtgrpEmployeeEmpAddress.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Address.";
                    return;
                }
                if (txtgrpEmployeeEmpSallery.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Sallery.";
                    return;
                }
                if (txtgrpEmployeeEmpMobile.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Mobile Number.";
                    return;
                }
                if (lblEmployeeid.Text == "")
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtgrpEmployeeEmpName.Text + "','" + txtgrpEmployeeEmpCNIC.Text + "','" + txtgrpEmployeeEmpMobile.Text + "','" + txtgrpEmployeeEmpAddress.Text + "')");
                    lblEmployeeid.Text = (f.findnumber("SELECT ProfileID from Profile where Pcnic='" + txtgrpEmployeeEmpCNIC.Text + "' order by ProfileID desc")).ToString();
                }
                bool test =
                    f.Selectbool("Select * from EmployeesProject where ProfileID=" + lblEmployeeid.Text + " and ProjectID=" + lblProjectID.Text + " ");
                if (test)
                {
                    LblErrorMsg.Text = "This Employee is already registered for this project.";
                    return;
                }
                //LblErrorMsg.Text = "";
                if (combgrpEmployeeDesignationList.SelectedIndex < 1)
                {
                    LblErrorMsg.Text = "Select Designation.";
                    return;
                }
                DateTime dt = dtPickgrpEmployeeEmpJobStarting.Value;
                string date = dt.ToString("dd-MM-yyyy");
                //int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                //f.Insert("insert into Profile(PName,Pcnic,PMobile,PAddress) values('" + txtgrpEmployeeEmpName.Text + "','" + txtgrpEmployeeEmpCNIC.Text + "','" + txtgrpEmployeeEmpMobile.Text + "','" + txtgrpEmployeeEmpAddress.Text + "')");
                //int Proid = f.findnumber("SELECT Top 1 ProfileID from Profile order by ProfileID desc");
                f.Insert("insert into EmployeesProject(ProfileID,ProjectID,JoiningDate,Sallery,DesignationID,Active ) values(" + lblEmployeeid.Text + "," + lblProjectID.Text + "," + date + "," + txtgrpEmployeeEmpSallery.Text + "," + combgrpEmployeeDesignationList.SelectedValue + ",1)");
                txtgrpEmployeeEmpName.Text = "";
                txtgrpEmployeeEmpCNIC.Text = "";
                txtgrpEmployeeEmpMobile.Text = "";
                txtgrpEmployeeEmpAddress.Text = "";
                FillEmployeeList();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void txtgrpEmployeeEmpSallery_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtgrpPlotsNodimensionWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 46 /*for dot . */))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtgrpPlotsNodimensionLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 46 /*for dot . */))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtGrpNoofPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpPlotStartPlotNumb_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProjectName_Enter(object sender, EventArgs e)
        {
            txtProjectName.BorderStyle = BorderStyle.FixedSingle;
        }

        private void dtPickerColonyStart_Enter(object sender, EventArgs e)
        {
            // dtPickerColonyStart.sh = BorderStyle.FixedSingle;
        }

        private void txtgrpPnameArea_Enter(object sender, EventArgs e)
        {
            txtgrpPnameArea.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtgrpPnameProjectPrice_Enter(object sender, EventArgs e)
        {
            txtgrpPnameProjectPrice.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtPickerColonyStart.Focus();
            }
        }

        private void dtPickerColonyStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpPnameArea.Focus();
            }
        }

        private void txtgrpPnameArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpPnameProjectPrice.Focus();
            }
        }

        private void txtgrpPnameProjectPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnGrpProjectNameSave.Focus();
            }
        }

        private void txtgrpPnameProjectPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pbAddFacility_Click(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            if (txtFacilities.Text == "")
            {
                LblErrorMsg.Text = "Enter Facility";
                return;
            }
            bool test =
                f.Selectbool("Select FacilityName from ColonyFascilites where FacilityName='" + txtFacilities.Text + "' and ProjectID=" + lblProjectID.Text + " ");
            if (test)
            {
                LblErrorMsg.Text = "This Facility is already Add for this project.";
                return;
            }
            try
            {
                f.Insert("Insert into ColonyFascilites (ProjectID,FacilityName) Values(" + lblProjectID.Text + ",'" + txtFacilities.Text + "')");
                loadGridFacility();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Record Not Update :" + es.Message;
            }
        }

        private void loadGridFacility()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select FacilityName from ColonyFascilites where ProjectID = " + lblProjectID.Text + "";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridgrpPnameFascilities.AutoGenerateColumns = false;
                gridgrpPnameFascilities.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }
        }


        private void grpProjectName_VisibleChanged(object sender, EventArgs e)
        {
            if (grpProjectName.Visible == true)
            {
                txtProjectName.Focus();
            }
        }

        private void txtFacilities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                pbAddFacility_Click(sender, e);
            }
        }

        private void txtgrpPlotsNodimensionWidth_TextChanged(object sender, EventArgs e)
        {
            if (txtgrpPlotsNodimensionWidth.Text == "" || txtgrpPlotsNodimensionLength.Text == "")
            {
                return;
            }
            calculateArea();
        }

        private void txtgrpPlotsNodimensionLength_TextChanged(object sender, EventArgs e)
        {
            if (txtgrpPlotsNodimensionWidth.Text == "" || txtgrpPlotsNodimensionLength.Text == "")
            {
                return;
            }
            calculateArea();
        }

        private void calculateArea()
        {

            float length = float.Parse(txtgrpPlotsNodimensionLength.Text);
            float width = float.Parse(txtgrpPlotsNodimensionWidth.Text);
            txtgrpPlotsArea.Text = (Math.Round((length * width / 270), 2)).ToString();
        }

        private void CombGrpPlotDimensions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (CombGrpPlotDimensions.SelectedIndex == 0)
                {
                    txtgrpPlotsNodimensionWidth.Focus();
                }
                else
                {
                    txtGrpNoofPlot.Focus();
                }
            }
        }

        private void txtgrpPlotsNodimensionWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpPlotsNodimensionLength.Focus();
            }
        }

        private void txtgrpPlotsNodimensionLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpPlotsArea.Focus();
            }
        }

        private void txtgrpPlotsArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btngrpPlotaddDimension.Focus();
            }
        }

        private void btngrpPlotaddDimension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                CombGrpPlotDimensions.Focus();
            }
        }

        private void txtGrpNoofPlot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpPlotStartPlotNumb.Focus();
            }
        }

        private void txtgrpPlotStartPlotNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btngrpPlotAddPlots.Focus();
            }
        }

        private void btngrpPlotAddPlots_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                CombGrpPlotDimensions.Focus();
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void txtgrpOwnerDetailAddCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtgrpOwnerDetailAddCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtgrpOwnerDetailAddCnic.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblgrpownerdetailProfileID.Text = dr["ProfileID"].ToString();
                    txtgrpOwnerDetailAddName.Text = dr["PName"].ToString();
                    txtgrpOwnerDetailAddMobile.Text = dr["PMobile"].ToString();
                    txtgrpOwnerDetailAddAddress.Text = dr["PAddress"].ToString();
                    txtgrpOwnerDetailAddName.Enabled = false;
                    txtgrpOwnerDetailAddAddress.Enabled = false;
                    txtgrpOwnerDetailAddMobile.Enabled = false;
                }
            }
            else
            {
                lblgrpownerdetailProfileID.Text = "";
                txtgrpOwnerDetailAddName.Enabled = true;
                txtgrpOwnerDetailAddAddress.Enabled = true;
                txtgrpOwnerDetailAddMobile.Enabled = true;
            }
        }

        private void btngrpOwnerdetailNew_Click(object sender, EventArgs e)
        {
            txtgrpOwnerDetailAddCnic.Text = "";
            txtgrpOwnerDetailAddAddress.Text = "";
            txtgrpOwnerDetailAddMobile.Text = "";
            txtgrpOwnerDetailAddName.Text = "";
            lblgrpownerdetailProfileID.Text = "";
            btngrpOwnerDetailAddOwner.Enabled = true;
            btngrpownerdetailModify.Enabled = false;
            btngrpOwnerdetailDelete.Enabled = false;
        }

        private void txtgrpOwnerDetailAddCnic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (lblgrpownerdetailProfileID.Text != "")
                {
                    combogrpOwnerProfit.Focus();
                }
                else
                {
                    txtgrpOwnerDetailAddName.Focus();
                }
            }
        }

        private void txtgrpOwnerDetailAddCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpOwnerDetailAddName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpOwnerDetailAddMobile.Focus();

            }
        }

        private void txtgrpOwnerDetailAddMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpOwnerDetailAddAddress.Focus();

            }
        }

        private void txtgrpOwnerDetailAddAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                combogrpOwnerProfit.Focus();

            }
        }

        private void combogrpOwnerProfit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpOwnerNote.Focus();

            }
        }

        private void txtgrpOwnerNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btngrpOwnerDetailAddOwner.Focus();

            }
        }

        private void gridOwnerDetail_SelectionChanged(object sender, EventArgs e)
        {
            //if (e.RowIndex >= 0)
            int rowindex = e.GetHashCode();
            if (e.GetHashCode() >= 0)
            {
                txtgrpOwnerDetailAddName.Text = (gridOwnerDetail1.Rows[rowindex].Cells[0].Value.ToString());
                txtgrpOwnerDetailAddCnic.Text = (gridOwnerDetail1.Rows[rowindex].Cells[1].Value.ToString());
                txtgrpOwnerDetailAddAddress.Text = (gridOwnerDetail1.Rows[rowindex].Cells[2].Value.ToString());
                txtgrpOwnerDetailAddMobile.Text = (gridOwnerDetail1.Rows[rowindex].Cells[3].Value.ToString());
                combogrpOwnerProfit.SelectedText = (gridOwnerDetail1.Rows[rowindex].Cells[4].Value.ToString());
                txtgrpOwnerNote.Text = (gridOwnerDetail1.Rows[rowindex].Cells[5].Value.ToString());
                btngrpOwnerDetailAddOwner.Enabled = false;
                btngrpOwnerdetailDelete.Enabled = true;
                btngrpownerdetailModify.Enabled = true;
            }
        }

        private void txtgrpEmployeeEmpCNIC_TextChanged(object sender, EventArgs e)
        {
            if (txtgrpEmployeeEmpCNIC.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtgrpEmployeeEmpCNIC.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblEmployeeid.Text = dr["ProfileID"].ToString();
                    txtgrpEmployeeEmpName.Text = dr["PName"].ToString();
                    txtgrpEmployeeEmpMobile.Text = dr["PMobile"].ToString();
                    txtgrpEmployeeEmpAddress.Text = dr["PAddress"].ToString();
                    txtgrpEmployeeEmpName.Enabled = false;
                    txtgrpEmployeeEmpMobile.Enabled = false;
                    txtgrpEmployeeEmpAddress.Enabled = false;
                }
            }
            else
            {
                lblEmployeeid.Text = "";
                txtgrpEmployeeEmpName.Enabled = true;
                txtgrpEmployeeEmpMobile.Enabled = true;
                txtgrpEmployeeEmpAddress.Enabled = true;
            }
        }

        private void txtgrpEmployeeEmpCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpEmployeeEmpCNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (lblEmployeeid.Text != "")
                {
                    txtgrpEmployeeEmpSallery.Focus();
                }
                else
                {
                    txtgrpEmployeeEmpName.Focus();
                }
            }
        }

        private void txtgrpEmployeeEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpEmployeeEmpMobile.Focus();
            }
        }

        private void txtgrpEmployeeEmpMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpEmployeeEmpAddress.Focus();
            }
        }

        private void txtgrpEmployeeEmpAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgrpEmployeeEmpSallery.Focus();
            }
        }

        private void txtgrpEmployeeEmpSallery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtPickgrpEmployeeEmpJobStarting.Focus();
            }
        }

        private void dtPickgrpEmployeeEmpJobStarting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                combgrpEmployeeDesignationList.Focus();
            }
        }

        private void combgrpEmployeeDesignationList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btngrpEmployeeAddEmployee.Focus();
            }
        }

        private void btngrpEmployeeNewEmp_Click(object sender, EventArgs e)
        {
            txtgrpEmployeeEmpCNIC.Text = "";
            txtgrpEmployeeEmpAddress.Text = "";
            txtgrpEmployeeEmpMobile.Text = "";
            txtgrpEmployeeEmpName.Text = "";
            lblEmployeeid.Text = "";
            btngrpEmployeeAddEmployee.Enabled = true;
            btngrpEmployeeModify.Enabled = false;
            btngrpEmployeeDelete.Enabled = false;
        }

        private void grpProjectName_Enter(object sender, EventArgs e)
        {

        }

        private void pboxAddExpenseHead_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                if (txtgrpexpenseHeadname.Text == "")
                {
                    LblErrorMsg.Text = "Fill or Select Head Name.";
                    return;
                }
                int previexpid = f.findnumber("select ExpID  from expenseHead where HeadName='" + txtgrpexpenseHeadname.Text + "' order by ExpID desc");
                if (previexpid == 0)
                {
                    int expid = f.createNumber("select ExpID  from expenseHead order by ExpID desc");
                    f.Insert("insert into expenseHead(ExpID,HeadName) values(" + expid + ",'" + txtgrpexpenseHeadname.Text + "')");
                    previexpid = expid;  
                }
                int previCatid = f.findnumber("select CatagoryID  from expenseCatagory where CatagoryName='" + txtgrpexpenseCatagoryname.Text + "' order by CatagoryID desc");
                if (previCatid == 0)
                {
                    int CATid = f.createNumber("select CatagoryID  from expenseCatagory order by CatagoryID desc");
                    f.Insert("insert into expenseCatagory(CatagoryID,ExpID,CatagoryName) values(" + CATid + "," + previexpid + ",'" + txtgrpexpenseCatagoryname.Text + "')");
                }
                txtgrpexpenseCatagoryname.Text = "";
                loadComboExpenseHead();
                loadComboExpenseCat();               
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        int ExpenseID = 0;
        private void loadComboExpenseCat()
        {
            combgrpexpenseCatagoryname.Items.Clear();
            DataSet ds = f.Select("select CatagoryID,CatagoryName   from expenseCatagory order by CatagoryID");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                combgrpexpenseCatagoryname.Items.Add(dr["CatagoryName"].ToString());
            }
        }

        private void loadComboExpenseHead()
        {
            txtgrpexpenseHeadname.Items.Clear();
            DataSet ds = f.Select("select ExpID,HeadName from expenseHead order by ExpID");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtgrpexpenseHeadname.Items.Add(dr["HeadName"].ToString());
            }
        }
        private void loadComboExpenses()
        {
            //gridExpenseDetila.Rows.Clear();
            //DataSet ds = f.Select("select LedgerID, HeadName,ExpenseDetail,Credit  from  Ledger l inner join expenseHead e on e.ExpID = l.ExpID where ProjectID="+lblProjectID.Text+ " and isexpenses=1 order by LedgerID desc ");

            DataSet ds = f.Select("Select RecordDate,LedgerID, CatagoryName, ExpenseDetail, Debit  from Ledger d inner join expenseCatagory p on p.CatagoryID = d.CatagoryID where d.ProjectID=" + lblProjectID.Text + " ");
            if (ds.Tables["table"].Rows.Count >= 0)
            {
                gridExpenseDetila.AutoGenerateColumns = false;
                gridExpenseDetila.DataSource = ds.Tables["table"].DefaultView;
                gridExpenseDetila.ClearSelection();
            }

        }
        //catagory combobox
        private void combgrpexpenseHeadname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExpenseID =
                f.findnumber("select CatagoryID from expenseCatagory where CatagoryName='" + combgrpexpenseCatagoryname.Text + "'");
        }

        private void txtExpenseDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LblErrorMsg.Text = "";
                //if (comboDevComapny.Text == "" && comboDevComapny.SelectedIndex < 0)
                //{
                //    LblErrorMsg.Text = "Select Developer.";
                //    return;
                //}
                if (ExpenseID == 0)
                {
                    LblErrorMsg.Text = "Select Head";
                    return;
                }
                if (txtgrpexpenseExpenseDetail.Text == "")
                {
                    LblErrorMsg.Text = "Enter Expense Detail";
                    return;
                }
                if (txtExpenseAmount.Text == "")
                {
                    LblErrorMsg.Text = "Enter Expense Amount";
                    return;
                }
                if (combgrpexpenseCatagoryname.Text == "")
                {
                    LblErrorMsg.Text = "Select Catagory";
                    return;
                }
                //if (radioButton4.Checked == false && combogrpExpenseEmployeelist.Items.Count <= 1)
                //{
                //    LblErrorMsg.Text = "No, Person Exists";
                //    return;
                //}
                DateTime dt1 = dtgrpExpensesDateExpense.Value;
                string dt = dt1.ToString("dd-MM-yyyy");
                //int month = dt1.Month;

                f.Insert("insert into Ledger(ProjectID,Debit,Credit,RecordDate,isexpenses,CatagoryID,ExpenseDetail,Remarks,isPropertyOwner) " +
                 "values('" + lblProjectID.Text + "','" + txtExpenseAmount.Text + "',0,'" + dt + "',1," + ExpenseID + ",'" + txtgrpexpenseExpenseDetail.Text + "','Expenses',"+isownerPayment+")");
                //int ledgerid = f.findnumber("select top 1 LedgerID from Ledger order by LedgerID desc ");
                //if (radioButton4.Checked) //expense
                //{
                //    f.Insert("insert into EmployeeSallary(LedgerID,ProfileID,SalMonth,PaidDatetime,Sallery) " +
                // "values(" + ledgerid + "," + combogrpExpenseEmployeelist.SelectedValue + "," + month + ",'" + dt + "'," + txtExpenseAmount.Text + ")");
                //}
                //if (radioButton2.Checked) //owner
                //{
                //    //f.findnumber("select top 1 LedgerID from Ledger order by LedgerID desc ");
                //    f.Insert("insert into OwnerPayments(LedgerID,ProfileID,InstallMonth,PaidDatetime,Payment) " +
                // "values(" + ledgerid + "," + combogrpExpenseEmployeelist.SelectedValue + "," + month + ",'" + dt + "'," + txtExpenseAmount.Text + ")");
                //}
                //else if (radioButton3.Checked) //dev
                //{
                //    //f.findnumber("select top 1 LedgerID from Ledger order by LedgerID desc ");
                //    f.Insert("insert into DevelopersPaid(LedgerID,ProfileID,PayMonth,PaidDatetime,DeveloperProfit) " +
                // "values(" + ledgerid + "," + combogrpExpenseEmployeelist.SelectedValue + "," + month + ",'" + dt + "'," + txtExpenseAmount.Text + ")");
                //}
                loadComboExpenses();
                txtExpenseAmount.Text = "";
                txtgrpexpenseExpenseDetail.Text = "";
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
        }

        private void label46_Click(object sender, EventArgs e)
        {
        }


        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtXtraSpecialMarla_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgrpprjNameCNIC_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtgrpprjNameCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpprjNameMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpprjNameCNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgrpDevCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtgrpDevCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtgrpDevCnic.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblgrpDevProfileID.Text = dr["ProfileID"].ToString();
                    txtgrpDevName.Text = dr["PName"].ToString();
                    txtDevMobille.Text = dr["PMobile"].ToString();
                    txtgrpDevAddress.Text = dr["PAddress"].ToString();
                    txtgrpDevName.Enabled = false;
                    txtgrpDevAddress.Enabled = false;
                    txtDevMobille.Enabled = false;
                }
            }
            else
            {
                lblgrpDevProfileID.Text = "";
                txtgrpDevName.Enabled = true;
                txtgrpDevAddress.Enabled = true;
                txtDevMobille.Enabled = true;
            }
        }

        private void btngrpDevSave_Click(object sender, EventArgs e)
        {
            try
            {


                LblErrorMsg.Text = "";
                if (txtgrpDevCnic.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill CNIC.";
                    return;
                }
                if (txtgrpDevCnic.Text.Length != 13)
                {
                    LblErrorMsg.Text = "Please Enter 13-Digit CNIC Number without dashes.";
                    return;
                }
                if (txtgrpDevName.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill Name.";
                    txtgrpDevName.Focus();
                    return;
                }
                if (txtDevMobille.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Mobile Number.";
                    txtDevMobille.Focus();
                    return;
                }
                if (txtgrpDevAddress.Text == "")
                {
                    LblErrorMsg.Text = "Please Fill Address.";
                    txtgrpDevAddress.Focus();
                    return;
                }

                if (CombogrpDevProfitOnProfit.Text == "")
                {
                    LblErrorMsg.Text = "Please Select Profit Rate";
                    CombogrpDevProfitOnProfit.Focus();
                    return;
                }

                if (lblgrpDevProfileID.Text == "")
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtgrpDevName.Text + "','" + txtgrpDevCnic.Text + "','" + txtDevMobille.Text + "','" + txtgrpDevAddress.Text + "')");
                    lblgrpDevProfileID.Text = profileid.ToString();
                }
                if (txtgrpDevCompnyName.Text == "")
                {
                    LblErrorMsg.Text = "Please Enter Company Name.";
                    return;
                }
                //check developer registered
                bool test =
                    f.Selectbool("Select * from Developers where ProfileID=" + lblgrpDevProfileID.Text +
                                 " and ProjectID=" + lblProjectID.Text + " ");
                if (test)
                {
                    LblErrorMsg.Text = "This Developer is already registered for this project.";
                    return;
                }
                string profit = CombogrpDevProfitOnProfit.Text;
                profit = profit.Replace(@"%", "");
                int profitshare = int.Parse(profit);
                //LblErrorMsg.Text = "";
                f.Insert("insert into Developers(ProfileID,ProjectID,ProfitShare,CompanyName,SpNote) values('" + lblgrpDevProfileID.Text + "','" + lblProjectID.Text + "'," + profitshare + " ,'" + txtgrpDevCompnyName.Text + "','" + txtgrpDeveloperNote.Text + "')");
                txtgrpDevName.Text = "";
                txtgrpDevCnic.Text = "";
                txtDevMobille.Text = "";
                txtgrpDevAddress.Text = "";
                lblgrpDevProfileID.Text = "";
                FillDeveloperList();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
        }
        private void FillDeveloperList()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select f.PName,f.Pcnic,f.PMobile,f.PAddress,o.ProfitShare,o.CompanyName,o.SpNote from Profile f inner join Developers o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                    lblProjectID.Text + "";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridgrpDeveloper.AutoGenerateColumns = false;
                gridgrpDeveloper.DataSource = ds.Tables["Table"].DefaultView;
                gridgrpDeveloper.ClearSelection();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void btngrpDevNew_Click(object sender, EventArgs e)
        {
            lblgrpDevProfileID.Text = "";
            txtgrpDevName.Text = "";
            txtgrpDevCnic.Text = "";
            txtDevMobille.Text = "";
            txtgrpDevAddress.Text = "";
            txtgrpDevCompnyName.Text = "";
            txtgrpDeveloperNote.Text = "";
            CombogrpDevProfitOnProfit.Text = "";
            txtgrpDevName.Enabled = true;
            txtgrpDevCnic.Enabled = true;
            txtDevMobille.Enabled = true;
            txtgrpDevAddress.Enabled = true;
        }

        private void btngrpDevDelete_Click(object sender, EventArgs e)
        {
            if (lblgrpDevProfileID.Text == "")
            {
                return;
            }
            try
            {
                f.Update("update Developers set Active=0 where ProfileID=" + lblgrpDevProfileID.Text + " ");

            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }

        }

        private void gridgrpDeveloper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            //int rowindex = e.GetHashCode();
            //if (rowindex >= 0)
            {
                int rowindex = e.RowIndex;
                txtgrpDevName.Text = (gridgrpDeveloper.Rows[rowindex].Cells[0].Value.ToString());
                txtgrpDevCnic.Text = (gridgrpDeveloper.Rows[rowindex].Cells[1].Value.ToString());
                txtgrpDevAddress.Text = (gridgrpDeveloper.Rows[rowindex].Cells[2].Value.ToString());
                txtDevMobille.Text = (gridgrpDeveloper.Rows[rowindex].Cells[3].Value.ToString());
                CombogrpDevProfitOnProfit.SelectedText = (gridgrpDeveloper.Rows[rowindex].Cells[4].Value.ToString());
                txtgrpDevCompnyName.Text = (gridgrpDeveloper.Rows[rowindex].Cells[5].Value.ToString());
                txtgrpDeveloperNote.Text = (gridgrpDeveloper.Rows[rowindex].Cells[6].Value.ToString());
                txtgrpDevCnic.Enabled = false;
                btngrpDevNew.Enabled = true;
                btngrpDevSave.Enabled = false;
                btngrpDevDelete.Enabled = true;
                btngrpDevModify.Enabled = true;
            }
        }

        private void btngrpDevModify_Click(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            string profit = CombogrpDevProfitOnProfit.Text;
            profit = profit.Replace(@"%", "");
            int profitshare = int.Parse(profit);
            try
            {
                f.Update("update Developers set ProfitShare=" + profitshare + ",CompanyName='" + txtgrpDevCompnyName.Text + "',SpNote=" + txtgrpDeveloperNote.Text + " where ProfileID=" + lblgrpDevProfileID.Text + " ");
                txtgrpDevName.Text = "";
                txtgrpDevCnic.Text = "";
                txtDevMobille.Text = "";
                txtgrpDevAddress.Text = "";
                txtgrpDevCnic.Enabled = true;
                btngrpDevNew.Enabled = false;
                btngrpDevSave.Enabled = true;
                btngrpDevDelete.Enabled = false;
                btngrpDevModify.Enabled = false;
                FillDeveloperList();
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
        }

        private void btngrpownerdetailModify_Click(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            string profit = combogrpOwnerProfit.Text;
            profit = profit.Replace(@"%", "");
            int profitshare = int.Parse(profit);
            try
            {
                f.Update("update Owners set ProfitShare=" + profitshare + ",SpNote=" + txtgrpDeveloperNote.Text + " where ProfileID=" + lblgrpownerdetailProfileID.Text + " ");

            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
            txtgrpOwnerDetailAddName.Text = "";
            txtgrpOwnerDetailAddCnic.Text = "";
            txtgrpOwnerDetailAddMobile.Text = "";
            txtgrpDevAddress.Text = "";
            FillOwnersList();
        }

        private void btngrpOwnerdetailDelete_Click(object sender, EventArgs e)
        {
            if (lblgrpownerdetailProfileID.Text == "")
            {
                return;
            }
            try
            {
                f.Update("update Owners set Active=0 where ProfileID=" + lblgrpownerdetailProfileID.Text + " ");

            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
        }

        //private void loadComboDevCompany()
        //{
        //    comboDevComapny.Items.Clear();
        //    DataSet ds = f.Select("select f.ProfileID , f.PName from Profile f inner join Developers o on o.ProfileID = f.ProfileID order by CompanyName ");
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        comboDevComapny.Items.Add(dr["PName"].ToString());
        //    }
        //}

        private void grpExpenses_Enter(object sender, EventArgs e)
        {

        }

        private void grpPlots_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btngrpRulesaddDesignation_Click(object sender, EventArgs e)
        {
            LblErrorMsg.Text = "";
            try
            {
                f.Insert("insert into DesignationsList (DesignationTitle,Description) VALUES('" + txtgrpRulesdesignation.Text + "','" + txtgrpRulesDesignationDetail.Text + "')");

            }
            catch (Exception es)
            {
                LblErrorMsg.Text = es.Message;
            }
            txtgrpRulesdesignation.Text = "";
            txtgrpRulesDesignationDetail.Text = "";
            LblErrorMsg.Text = "Designation Saved.";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //saller check grp expenses

        }
        //1 employees
        //2 owners
        //3 developerss
        private void LoadCombogrpExpensesEmplist(int who)
        {
            string str = "";
            try
            {
                if (who == 1)//sallery
                {
                    str =
                    "select o.ProfileID , f.PName from Profile f inner join EmployeesProject o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                    lblProjectID.Text + "";
                }
                else if (who == 2) //owner
                {
                    str =
                    "select o.ProfileID , f.PName from Profile f inner join Owners o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                    lblProjectID.Text + "";
                }
                else if (who == 3)//dev
                {
                    str =
                    "select o.ProfileID , o.CompanyName from Profile f inner join Developers o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                    lblProjectID.Text + "";
                }
                OleDbCommand sqlCmd = new OleDbCommand(str, olecon);
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                OleDbDataReader sqlReader = sqlCmd.ExecuteReader();
                Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
                DictionaryCustomer.Add(-1, "--!!--");
                while (sqlReader.Read())
                {
                    //string name = sqlReader["PName"].ToString();
                    //int Value = int.Parse(sqlReader["ProfileID"].ToString());
                    //ds.Tables["table"].Rows[j][2].ToString()

                    string name = sqlReader[1].ToString();
                    int Value = int.Parse(sqlReader[0].ToString());
                    DictionaryCustomer.Add(Value, name);
                }
                //combogrpExpenseEmployeelist.DisplayMember = "Value";
                //combogrpExpenseEmployeelist.ValueMember = "Key";
               // combogrpExpenseEmployeelist.DataSource = new BindingSource(DictionaryCustomer, null);
                //CombGrpPlotDimensions.SelectedIndex = 0;
                sqlReader.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                LblErrorMsg.Text = "Error: " + es.Message;
            }

        }
        //is sallery in expense
        //ownerr paiid
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                isownerPayment = 1;
            }

        }
        //expense
        int isownerPayment = 0;
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                isownerPayment =0;
            }
        }

        private void txtgrpEmployeeEmpMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtExpenseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgrpexpenseHeadname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pboxAddExpenseHead_Click(sender, e);
            }

        }

        private void txtgrpRulesdesignation_TextChanged(object sender, EventArgs e)
        {
            txtgrpRulesDesignationDetail.Text = txtgrpRulesdesignation.Text;
        }

        private void txtgrpexpenseHeadname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
