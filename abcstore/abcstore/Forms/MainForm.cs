using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using abcstore.Forms;
using System.Reflection;


namespace abcstore
{
    public delegate string MyDel(string str);
    public partial class MainForm : Form
    {
        private ToolStripMenuItem MnuStripItem;

        public MainForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public string Username { get; set; }
        addproductform apf;
        DataSet ds = new DataSet();


        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            apf = new addproductform { MdiParent = this };
            apf.Show();
        }
        public void SubMenu(ToolStripMenuItem mnu, string submenu)
        {
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT FRM_NAME FROM vw_pagerole WHERE MENUPARVAL='" + submenu + "' and status = 1 and UID = '" + Username + "' ", con);
            SqlDataAdapter adapter = new SqlDataAdapter("select  mp.Main_menu, msm.Form_code, msm.form_Name, r.u_name from MenuParent mp ,MenuSubmenue msm, Rights r where mp.Manu_Par_value = msm.Manu_Par_value and mp.Manu_Par_value = r.Manu_Par_value and msm.menue_submenue_code  = r.menue_submenue_code and r.Rights_invisible = 1 and mp.Main_menu='" + mnu + "'  and r.u_name = '" + Username + "' ", con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(row["form_Name"].ToString(), null, new EventHandler(ChildClick));
                mnu.DropDownItems.Add(item);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MnuStrip = new MenuStrip();
            base.Controls.Add(this.MnuStrip);
            MnuStrip.BackColor = Color.FromArgb(4, 71, 3);
            MnuStrip.ForeColor = Color.Orange;
            MnuStrip.Font = new Font("Arial", 12);

            //string selectCommandText = "SELECT MAINMNU,MENUPARVAL,STATUS FROM MNU_PARENT where status = 'Y'";
            string selectCommandText = "select Main_menu,Manu_Par_value,Status from MenuParent where Status='Y'";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, con);
            DataTable dataTable = new DataTable();
            con.Open();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                this.MnuStripItem = new ToolStripMenuItem(row["Main_menu"].ToString());
                this.SubMenu(this.MnuStripItem, row["Manu_Par_value"].ToString());
                MnuStrip.Items.Add(this.MnuStripItem);
            }
            base.MainMenuStrip = MnuStrip;
            con.Close();
        }
        //tchild click
        string eventclick;
        private void ChildClick(object sender, EventArgs e)
        {
            string querry = ("select Form_code from MenuSubmenue where form_Name='" + sender.ToString() + "'");
                    SqlCommand cmdd = new SqlCommand(querry, con);
                    con.Open();

                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {

                        eventclick = (string)dbr["Form_code"];
                        label1.Text = eventclick;
                    }
                    con.Close();
                   




           // SqlDataAdapter adapter = new SqlDataAdapter("SELECT FRM_CODE FROM MNU_SUBMENU WHERE FRM_NAME='" + sender.ToString() + "'", con);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            
            
           
            
        }

        //
        //Assembly assembly = Assembly.LoadFile(Application.ExecutablePath);
        //foreach (System.Type type in assembly.GetTypes())
        //{
        //    if ((type.BaseType == typeof(Form)) && (type.Name == dataTable.Rows[0][0].ToString()))
        //    {
        //        Form form = (Form)assembly.CreateInstance(type.ToString());
        //        foreach (Form form2 in base.MdiChildren)
        //        {
        //            form2.Close();
        //        }
        //        form.MdiParent = this;
        //        form.WindowState = FormWindowState.Maximized;
        //        form.Show();
        //    }
        //    }
        //}

        //public void ChildClick(object sender, System.EventArgs e)
        //{
        //    string frmName = sender.ToString();
        //    if (frmName == "Exit")
        //    {
        //        //exitToolStripMenuItem_Click(sender, e);
        //    }

        //    //string frmName1 = sender.ToString();
        //    if (frmName == "NEW RECIPES")
        //    {
        //        //newRecipe newMDIChild1 = new newRecipe();
        //        //newMDIChild1.Show();
        //        //newMDIChild1.MdiParent = this;
        //        //pictureBox1.Hide();
        //        ////label3.Hide();
        //        //panel1.Hide();
        //        //panel2.Hide();
        //    }

        //    if (frmName == "BATCH ENTRY")
        //    {
        //        //batchEntry newMDIChild2 = new batchEntry();
        //        //newMDIChild2.Show();
        //        //newMDIChild2.MdiParent = this;
        //        //pictureBox1.Hide();
        //        ////label3.Hide();
        //        //panel1.Hide();
        //        //panel2.Hide();
        //    }

        //    if (frmName == "MANUAL BATCH ENTRY FORM")
        //    {
        //        //batchEntryManual newMDIChild3 = new batchEntryManual();
        //        //newMDIChild3.Show();
        //        //newMDIChild3.MdiParent = this;
        //        //pictureBox1.Hide();
        //        ////label3.Hide();
        //        //panel1.Hide();
        //        //panel2.Hide();
        //    }
        //}

        //public void SubMenu(ToolStripMenuItem mnu, string submenu)
        //{
        //    String Seqchild = "select * from MenuSubmenue WHERE Manu_Par_value='" + submenu + "'";
        //    SqlDataAdapter dachildmnu = new SqlDataAdapter(Seqchild, con);
        //    DataTable dtchild = new DataTable();
        //    dachildmnu.Fill(dtchild);

        //    foreach (DataRow dr in dtchild.Rows)
        //    {
        //        ToolStripMenuItem SSMenu = new ToolStripMenuItem(dr["form_Name"].ToString(), null, new EventHandler(ChildClick));
        //        mnu.DropDownItems.Add(SSMenu);
        //    }
        //}

        //private void ChildClick(object sender, EventArgs e)
        //{
        //    // MessageBox.Show(string.Concat("You have Clicked ", sender.ToString(), " Menu"), "Menu Items Event",MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    String Seqtx = "SELECT Form_code FROM MenuSubmenue WHERE form_Name='" + sender.ToString() + "'";
        //    SqlDataAdapter datransaction = new SqlDataAdapter(Seqtx, con);
        //    DataTable dtransaction = new DataTable();
        //    datransaction.Fill(dtransaction);

        //    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
        //    foreach (Type type in frmAssembly.GetTypes())
        //    {
        //        //MessageBox.Show(type.Name); 
        //        if (type.BaseType == typeof(Form))
        //        {
        //            if (type.Name == dtransaction.Rows[0][0].ToString())
        //            {
        //                Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());
        //                // then when you want to close all of them simple call the below code

        //                foreach (Form form in this.MdiChildren)
        //                {
        //                    form.Close();
        //                }

        //                frmShow.MdiParent = this;
        //                frmShow.WindowState = FormWindowState.Maximized;
        //                //frmShow.ControlBox = false;
        //                frmShow.Show();
        //            } 
        //        }
        //    }
        // } 




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 1,
                MdiParent = this
            };
            pf.Show();
        }

        private void addVenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 0,
                MdiParent = this
            };
            pf.Show();
        }

        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productform prf = new Productform { MdiParent = this };
            prf.Show();
        }

        private void messToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Invoiceform inf = new Invoiceform
            {
                MdiParent = this,
                resultradiobutton = 0
            };
            inf.Show();
        }

        private void tuckShopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Invoiceform inf = new Invoiceform
            {
                MdiParent = this,
                resultradiobutton = 1
            };
            inf.Show();
        }

        private void updateProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProductsForm upf = new UpdateProductsForm { MdiParent = this };
            upf.Show();
        }

        private void tuckShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrderForm pofm = new PurchaseOrderForm
            {
                MdiParent = this,
                Resultradiobutton = 0
            };
            pofm.Show();
        }

        private void messToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrderForm pofm = new PurchaseOrderForm
            {
                MdiParent = this,
                Resultradiobutton = 1
            };
            pofm.Show();
        }

        private void openPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPO pop = new OpenPO { MdiParent = this };
            pop.Show();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerForm lfm = new LedgerForm { MdiParent = this };
            lfm.Show();
        }

        private void guestInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Invoiceform inf = new Invoiceform
            {
                MdiParent = this,
                resultradiobutton = 2
            };
            inf.Show();
        }

        private void openInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoiceform inf = new Invoiceform
            {
                MdiParent = this,
                OpenInvoicefm = 1 //for open invoice
            };
            inf.Show();
        }

        private void viewOrUpdateProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 1,
                openprofilefm = 1,
                MdiParent = this
            };
            pf.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 1,
                openprofilefm = 1,
                MdiParent = this
            };
            pf.Show();
        }

        private void viewOrUpdateVenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 0,
                openprofilefm = 1,
                MdiParent = this
            };
            pf.Show();
        }

        private void viewVenderProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileform pf = new profileform
            {
                profiletype = 0,
                openprofilefm = 1,
                MdiParent = this
            };
            pf.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void deleteProductsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateProductsForm upf = new UpdateProductsForm
            {
                MdiParent = this,
                DeleteFm = 1
            };
            upf.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender,e);
        }

        private void manageRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRights mr = new ManageRights();
            mr.MdiParent = this;
            mr.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.MdiParent = this;
            cp.username = Username;
            cp.Show();
        }
    }
    //class EventProgram
    //{
    //    event MyDel MyEvent;

    //    public EventProgram()
    //    {
    //        this.MyEvent += new MyDel(this.WelcomeUser);
    //    }

    //    public string WelcomeUser(string username)
    //    {
    //        return "Welcome " + username;
    //    }

        //static void Main(string[] args)
        //{
        //    EventProgram obj1 = new EventProgram();
        //    string result = obj1.MyEvent("Tutorials Point");
        //    Console.WriteLine(result);
        //}
    //}
}
