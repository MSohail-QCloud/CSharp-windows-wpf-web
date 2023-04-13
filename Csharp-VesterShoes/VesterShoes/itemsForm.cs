using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Windows;
using VesterShoes.classes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace VesterShoes
{
    public partial class itemsForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col2 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col3 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col4 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col5 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col6 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col7 = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection col8 = new AutoCompleteStringCollection();
        functions f=new functions();
        public itemsForm( string cname,string custcode,string LogUser,string SysUser)
        {
            InitializeComponent();
            LoadgridArticle();
            LoadgridColor();
            LoadgridMaterial();
            Loadgridsol();
            LoadgridVesterType();
            LoadgridSize();
            LoadgridStamp();
            Loadgridshooleast();
            txtCustomerId.Text = custcode;
            txtCompanyName.Text = cname;
            LoginUser = LogUser;
            SystemUser= SysUser;
            //comboBox6.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailSM));

        }

        int updateitem = 0;
        public itemsForm(string cname, string custcode,int order,int sort,int itemid)
        {
            InitializeComponent();
            LoadgridArticle();
            LoadgridColor();
            LoadgridMaterial();
            Loadgridsol();
            LoadgridVesterType();
            LoadgridSize();
            LoadgridStamp();
            Loadgridshooleast();
            txtCustomerId.Text = custcode;
            txtCompanyName.Text = cname;
            txtOrderID.Text = order.ToString();
            txtSortid.Text = sort.ToString();
            ItemId = itemid;
            updateitem = 1;
            loadItem();
        }

        private void loadItem()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            string query = "select a.ArticleID,t.VesterTypeID,c.ColorID,m.MaterialID,sol.SolID,s.SizeID,st.StampID,sh.ShooleastID , a.Article,t.VesterType,c.ColorName,m.MaterialName,sol.SolName,s.SizeName,st.StampName,sh.ShooLeastNumber from tblItems i, tblArticle a," +
                            "tblVesterType t,tblColor c,tblMaterial m, tblSol sol,tblSize s,tblStamp st,tblshooleast sh where i.ArticleID = a.ArticleID and i.VesterTypeID = t.VesterTypeID and i.ColorID = c.ColorID and"+
                            " i.MaterialID = m.MaterialID and i.SolID = sol.SolID and i.SizeID = s.SizeID and i.StampID = st.StampID and i.ShooleastID = sh.ShooleastID and i.ItemsID="+ItemId+"";
            SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    lblArticleID.Text = dr["ArticleID"].ToString();
                    lbltypeid.Text = dr["VesterTypeID"].ToString();
                    lblColorId.Text = dr["ColorID"].ToString();
                    lblMaterialID.Text = dr["MaterialID"].ToString();
                    lblSolId.Text = dr["SolID"].ToString();
                    lblSizeID.Text = dr["SizeID"].ToString();
                    lblStampId.Text = dr["StampID"].ToString();
                    lblLastID.Text = dr["ShooleastID"].ToString();
                    txtsearchArticle.Text = dr["Article"].ToString();
                    txtSearchType.Text = dr["VesterType"].ToString();
                    //GridType.sele= dr["VesterType"].ToString();
                    txtSearchColor.Text = dr["ColorName"].ToString();
                    txtSearchMaterail.Text = dr["MaterialName"].ToString();
                    txtSearchSol.Text = dr["SolName"].ToString();
                    txtSearchsize.Text = dr["SizeName"].ToString();
                    txtSearchStamp.Text = dr["StampName"].ToString();
                    txtSearchShooLeast.Text = dr["ShooLeastNumber"].ToString();
                }
            }
            BuildItemString();
            int orderdetailid = f.findnumber("select orderdetailID from tblOrders where OrderID='" + txtOrderID.Text + "' and SortID='" + txtSortid.Text + "'");
            //selecting data about recipe steps
            string query1 = "select * from tblRecipeSteps where orderdetailID=" + orderdetailid + "";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon);//Advised to use parameterized query
            using (SqlDataReader dr = cmd1.ExecuteReader())
            {
                if (dr.Read())
                {
                    bool cm = bool.Parse(dr["CM"].ToString());
                    if (cm == true)
                    {
                        checkBoxCM.Checked = true;
                    }else if (cm==false)
                    {
                        checkBoxCM.Checked = false;
                    }
                   bool SM = bool.Parse(dr["SM"].ToString());
                    if (SM == true)
                    {
                        checkBoxSM.Checked = true;
                    }
                    else if (SM == false)
                    {
                        checkBoxSM.Checked = bool.Parse(dr["AM"].ToString());
                    }
                    checkBoxAM.Checked = bool.Parse(dr["AM"].ToString());
                    checkBoxBM.Checked= bool.Parse(dr["BM"].ToString());
                    checkBoxPM.Checked= bool.Parse(dr["PM"].ToString());
                    checkBoxProiM.Checked = bool.Parse(dr["ProiM"].ToString());
                    checkBoxFM.Checked = bool.Parse(dr["FM"].ToString());
                }
            }
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            callRate();
        }
       
        SqlDataAdapter da;
        

        private void LoadgridSize()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select SizeID, SizeName as Size from tblSize where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
              SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridSize.DataSource = dtarticle;
            // ReSharper disable once PossibleNullReferenceException
            GridSize.Columns["SizeID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void LoadgridStamp()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select StampID, StampName as Stamp from tblStamp where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridStamp.DataSource = dtarticle;
            GridStamp.Columns["StampID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void Loadgridshooleast()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select ShooleastID,ShooLeastNumber as Pharma from tblshooleast where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridShoolest.DataSource = dtarticle;
            GridShoolest.Columns["ShooleastID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        private void LoadgridArticle()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select ArticleID,Article from tblArticle where Active = 1 order by Article ";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridArticle.DataSource = dtarticle;
            GridArticle.Columns["ArticleID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void LoadgridVesterType()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select VesterTypeID,vestertype as Type from tblvestertype where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridType.DataSource = dtarticle;
            GridType.Columns["VesterTypeID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void LoadgridColor()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select ColorID, ColorName as Color from tblColor where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridColor.DataSource = dtarticle;
            GridColor.Columns["ColorID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void LoadgridMaterial()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select MaterialID,MaterialName as Material from tblMaterial where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridMaterial.DataSource = dtarticle;
            GridMaterial.Columns["MaterialID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void Loadgridsol()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select SolID,solname as  Sole from tblSol where Active = 1";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            GridSol.DataSource = dtarticle;
            GridSol.Columns["SolID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }


        public int ItemId { get; set; }
        public string Gvar { get; set; }
        public string CustomerId { get; set; }
        public string CustomerCompnay { get; set; }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            
            txtsearchArticle.Focus();
            if (updateitem==0)
            {
                txtOrderID.Text = f.createNumber("Select top 1 OrderId  from tblOrders  order by OrderId desc").ToString();
            }
            txtOrderNumber.Text = txtOrderID.Text + "-" + txtSortid.Text;

        }

        int checkrate = 0;
        private void callRate()
        {
            try
            {
                checkrate = 0;
                if (txtSearchType.Text != "" && txtSearchMaterail.Text != "" && txtSearchSol.Text != "")
                {
                    string s =
                        "select ItemRate from tblCustItemsRate where vestertypeid = "+lbltypeid.Text+ " and ProfileId='" + txtCustomerId.Text+"' and solid = "+lblSolId.Text+" and materialid = "+lblMaterialID.Text+"";
                    checkrate = f.findnumber(s);
                    txtrate2.Text = checkrate.ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
           
        }
        private void clear()
        {
            txtsearchArticle.Text = "";
            txtSearchType.Text = "";
            txtSearchsize.Text = "";
            txtSearchColor.Text = "";
            txtSearchMaterail.Text = "";
            txtSearchSol.Text = "";
            txtSearchStamp.Text = "";
            txtSearchShooLeast.Text = "";
            txtitemId.Text = "";
            txtitemdetail2.Text = "";
            txtqty2.Text = "12";
            txtrate2.Text = "";


        }

        int successfullOperation = 0;
        private void txtsearchArticle_Leave(object sender, EventArgs e)
        {
            if (txtsearchArticle.Text.Trim() != "")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblArticle where Article='" + txtsearchArticle.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblArticleID.Text = dr["ArticleID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }

                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Article Do you want to add it?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    if (txtsearchArticle.Text.Trim() != "")
                                    {
                                        string StrQuery = "INSERT INTO tblArticle (Article,updateby,updatein,updateon) VALUES ('" + txtsearchArticle.Text.Trim() + "','"+LoginUser+"','"+SystemUser+"','"+DateTime.Now+"')";

                                        using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                                        {
                                            comm.ExecuteNonQuery();
                                        }
                                    }

                                    //BuildItemString();

                                }
                                catch (Exception es)
                                {
                                    System.Windows.MessageBox.Show(es.Message);
                                }

                                finally
                                {
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridArticle();
                                    //txtSearchType.Focus();
                                }
                                txtsearchArticle_Leave(sender,e);
                            }
                            else
                            {
                                txtsearchArticle.Text = "";
                                txtsearchArticle.Focus();
                            }
                        }
                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            txtSearchType.Focus();
                        }

                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }
        public string LoginUser { get; set; }
        public string SystemUser { get; set; }
        private void txtSearchType_Leave(object sender, EventArgs e)
        {
            if (txtSearchType.Text.Trim() != "")
            {
                try
                {

                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblVesterType where vestertype='" + txtSearchType.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lbltypeid.Text = dr["VesterTypeID"].ToString();

                            BuildItemString();
                            successfullOperation = 1;
                        }
                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Shoo Type Do you want to add it? '" + txtSearchType.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                               
                                 string StrQuery = "INSERT INTO tblVesterType (vestertype,updateby,updatein,updateon) VALUES ('" + txtSearchType.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";
                                using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridVesterType();
                                   
                                txtSearchType_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchType.Focus();
                            }
                        }

                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            //txtSearchColor.Focus();
                            
                        }
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
            callRate();
        }
        SqlDataReader dr;
        private void txtSearchColor_Leave(object sender, EventArgs e)
        {
            if (txtSearchColor.Text.Trim() != "")
            {

                try
                {

                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblColor where ColorName ='" + txtSearchColor.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblColorId.Text = dr["ColorID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }

                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Color Do you want to add it? '" + txtSearchColor.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    string StrQuery = "INSERT INTO tblColor (ColorName,updateby,updatein,updateon) VALUES ('" + txtSearchColor.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    //BuildItemString();

                                }
                                catch (Exception es)
                                {
                                    System.Windows.MessageBox.Show(es.Message);
                                }

                                finally
                                {
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridColor();
                                    //txtSearchMaterail.Focus();
                                }
                                txtSearchColor_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchMaterail.Focus();
                            }
                        }

                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            txtSearchMaterail.Focus();
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }

        private void txtSearchMaterail_Leave(object sender, EventArgs e)
        {
            if (txtSearchMaterail.Text.Trim() != "")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblMaterial where materialname ='" + txtSearchMaterail.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblMaterialID.Text = dr["MaterialID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }

                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Material Do you want to add it? '" + txtSearchColor.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                    string StrQuery = "INSERT INTO tblMaterial (materialname,Active,updateby,updatein,updateon) VALUES ('" + txtSearchMaterail.Text + "','"+1+ "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    //BuildItemString();

                              
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridMaterial();
                                txtSearchMaterail_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchSol.Focus();
                            }
                        }

                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            txtSearchSol.Focus();
                            
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
            callRate();
        }
        private void BuildItemString()
        {
            //txtSearch.Text = txtsearchArticle.Text + " " + txtSearchType.Text + " " + txtSearchColor.Text + " " + txtSearchMaterail.Text + " " + txtSearchSol.Text + " " + txtSearchsize.Text + " " + txtSearchStamp.Text + " " + txtSearchShooLeast.Text;
            this.Text = txtsearchArticle.Text.Trim() + " " + txtSearchType.Text.Trim() + " " + txtSearchColor.Text.Trim() + " " + txtSearchMaterail.Text.Trim() + " " + txtSearchSol.Text.Trim() + " " + txtSearchsize.Text.Trim() + " " + txtSearchStamp.Text.Trim() + " " + txtSearchShooLeast.Text.Trim();
        }

        private void txtSearchSol_Leave(object sender, EventArgs e)
        {
            if (txtSearchSol.Text.Trim() != "")
            {

                try
                {

                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblSol where solname ='" + txtSearchSol.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        if (dr.Read())
                        {
                            lblSolId.Text = dr["SolID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }

                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Sole Type Do you want to add it? '" + txtSearchColor.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                string StrQuery = "INSERT INTO tblSol (solname,updateby,updatein,updateon) VALUES ('" + txtSearchSol.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    //BuildItemString();

                               
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    Loadgridsol();
                                    //txtSearchsize.Focus();
                                
                                txtSearchSol_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchsize.Focus();
                            }
                        }

                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                          
                            txtSearchsize.Focus();
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
            callRate();
        }

        private void txtsearchArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (  e.KeyCode == Keys.Tab)
            {
                txtSearchType.Focus();
            }
        }

        private void txtSearchType_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchColor.Focus();
            }
        }

        private void txtSearchColor_KeyDown(object sender, KeyEventArgs e)

        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchMaterail.Focus();
            }
        }

        private void txtSearchMaterail_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchSol.Focus();
            }
        }

        private void txtSearchSol_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchsize.Focus();
            }
        }

        private void saverate()
        {
            if (txtrate2.Text != "")
            {
                //int getrate = 0;
                try
                {
                    SqlDataReader dr;
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string s =
                       "select ItemRate from tblCustItemsRate where ProfileId='" + txtCustomerId.Text + "' and vestertypeid = " + lbltypeid.Text + " and solid = " + lblSolId.Text + " and materialid = " + lblMaterialID.Text + "";
                    SqlCommand cmd = new SqlCommand(s, sqlcon); //Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        checkrate = int.Parse(dr.GetValue(0).ToString());
                    }
                    else
                    {
                        vc.Insert(
                            "insert into tblCustItemsRate (ProfileId,ItemRate,vestertypeid,solid,materialid,updateby,updatein,updateon)values(" +
                            txtCustomerId.Text + "," + txtrate2.Text + "," + lbltypeid.Text + "," + lblSolId.Text + "," +
                            lblMaterialID.Text + ",'" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "') ");
                    }
                    if (checkrate != int.Parse(txtrate2.Text))
                    {
                        vc.Update("UPDATE tblCustItemsRate SET ItemRate = '" + txtrate2.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "' where vestertypeid = " + lbltypeid.Text + " and solid = " + lblSolId.Text + " and materialid = " + lblMaterialID.Text + " ");
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saverate();
            if (txtsearchArticle.Text.Trim()!="" && txtSearchType.Text.Trim() != "" && txtSearchColor.Text.Trim() != "" && txtSearchMaterail.Text.Trim() != "" && txtSearchSol.Text.Trim() != "" && txtSearchsize.Text.Trim() != "" && txtSearchStamp.Text.Trim() != "" && txtSearchShooLeast.Text.Trim() != "" && txtqty2.Text!="" && txtrate2.Text!="")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select itemsid,ItemsDescription from tblItems where ItemsDescription ='" + Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtitemId.Text = (dr.GetValue(0).ToString());
                            txtitemdetail2.Text = (dr.GetValue(1).ToString());
                            successfullOperation = 1;
                        }
                    }
                    //dr.Close();

                    if (successfullOperation == 0 )
                    {
                        //if (txtSearch.Text != "")
                        //{
                        string strQuery = "INSERT INTO tblItems (itemsdescription,ArticleID,VesterTypeID,ColorID,MaterialID,SolID,SizeID,ShooleastID,StampID,Active,updateby,updatein,updateon) VALUES ('" + this.Text + "','" + lblArticleID.Text + "','" + lbltypeid.Text + "','" + lblColorId.Text + "','" + lblMaterialID.Text + "','" + lblSolId.Text + "','" + lblSizeID.Text + "','" + lblLastID.Text + "','" + lblStampId.Text + "','" + '1' + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";
                        if (sqlcon.State != ConnectionState.Open)
                        {
                            sqlcon.Open();
                        }
                        using (SqlCommand comm = new SqlCommand(strQuery, sqlcon))
                        {
                            comm.ExecuteNonQuery();
                        }
                        btnSave_Click(sender, e);                        
                    }
                    if (successfullOperation == 1)
                    {
                        btnsav2_Click(sender, e);
                        MessageBox.Show("Order Saved.");
                        txtOrderNumber.Text = txtOrderID.Text + "-" + txtSortid.Text;
                    }
                    
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                    successfullOperation = 0;
                    
                }
            }
            else
            {
                MessageBox.Show("Must Fill All TextBoxes.");
            }
        }

        private void txtSearchsize_Leave(object sender, EventArgs e)
        {
            if (txtSearchsize.Text.Trim() != "")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblSize where SizeName ='" + txtSearchsize.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblSizeID.Text = dr["SizeID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }

                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Size Do you want to add it? '" + txtSearchsize.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    string strQuery = "INSERT INTO tblSize (SizeName,updateby,updatein,updateon) VALUES ('" + txtSearchsize.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(strQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    //BuildItemString();

                                }
                                catch (Exception es)
                                {
                                    System.Windows.MessageBox.Show(es.Message);
                                }

                                finally
                                {
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridSize();
                                    //txtSearchStamp.Focus();
                                }
                                txtSearchsize_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchsize.Text = "";
                                txtSearchsize.Focus();
                            }
                        }

                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            txtSearchStamp.Focus();
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }

        private void txtSearchStamp_Leave(object sender, EventArgs e)
        {
            if (txtSearchStamp.Text.Trim() != "")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblStamp where StampName ='" + txtSearchStamp.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblStampId.Text = dr["StampID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }
                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Stamp Name Do you want to add it? '" + txtSearchStamp.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    string strQuery = "INSERT INTO tblStamp (StampName,updateby,updatein,updateon ) VALUES ('" + txtSearchStamp.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(strQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception es)
                                {
                                    System.Windows.MessageBox.Show(es.Message);
                                }

                                finally
                                {
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    LoadgridStamp();
                                    //txtSearchShooLeast.Focus();
                                }
                                txtSearchStamp_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchStamp.Text = "";
                                txtSearchStamp.Focus();
                            }
                        }
                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            txtSearchShooLeast.Focus();
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }

        private void txtSearchShooLeast_Leave(object sender, EventArgs e)
        {
            if (txtSearchShooLeast.Text.Trim() != "")
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    string query = "Select * from tblshooleast where ShooLeastNumber ='" + txtSearchShooLeast.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblLastID.Text = dr["ShooleastID"].ToString();
                            BuildItemString();
                            successfullOperation = 1;
                        }
                        else
                        {
                            dr.Close();
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Is it New Frame Name Do you want to add it? '" + txtSearchShooLeast.Text + "' ", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    string strQuery = "INSERT INTO tblshooleast (ShooLeastNumber,updateby,updatein,updateon ) VALUES ('" + txtSearchShooLeast.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";

                                    using (SqlCommand comm = new SqlCommand(strQuery, sqlcon))
                                    {
                                        comm.ExecuteNonQuery();
                                    }
                                    //BuildItemString();
                                }
                                catch (Exception es)
                                {
                                    System.Windows.MessageBox.Show(es.Message);
                                }
                                finally
                                {
                                    if (sqlcon.State != ConnectionState.Closed)
                                    {
                                        sqlcon.Close();
                                    }
                                    Loadgridshooleast();
                                    //btnSave.Focus();
                                }
                                txtSearchShooLeast_Leave(sender,e);
                            }
                            else
                            {
                                txtSearchShooLeast.Text = "";
                                txtSearchShooLeast.Focus();
                            }
                        }
                        if (successfullOperation == 1)
                        {
                            dr.Close();
                            successfullOperation = 0;
                            btnSave.Focus();
                        }
                    }
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }

        private void txtSearchsize_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchStamp.Focus();
            }
        }

        private void txtSearchStamp_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                txtSearchShooLeast.Focus();
            }
        }

        private void txtSearchShooLeast_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void GridSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                lblSizeID.Text = (GridSize.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchsize.Text = (GridSize.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchStamp.Focus();
            }
            

        }

        private void GridStamp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
lblStampId.Text = (GridStamp.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchStamp.Text = (GridStamp.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchShooLeast.Focus();
                callRate();
            }
            
        }

        private void GridShoolest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
lblLastID.Text = (GridShoolest.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchShooLeast.Text = (GridShoolest.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            btnSave.Focus();
            }
            
        }

        private void GridArticle_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
lblArticleID.Text = (GridArticle.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtsearchArticle.Text = (GridArticle.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchType.Focus();
            }
            
        }

        private void GridType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
    lbltypeid.Text = (GridType.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchType.Text = (GridType.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchColor.Focus();
            }
            
        }

        private void GridColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblColorId.Text = (GridColor.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSearchColor.Text = (GridColor.Rows[e.RowIndex].Cells[1].Value.ToString());
                BuildItemString();
                txtSearchMaterail.Focus();
            }

        }

        private void GridMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
 lblMaterialID.Text = (GridMaterial.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchMaterail.Text = (GridMaterial.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchSol.Focus();
            }
           
        }

        private void GridSol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
lblSolId.Text = (GridSol.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearchSol.Text = (GridSol.Rows[e.RowIndex].Cells[1].Value.ToString());
            BuildItemString();
            txtSearchsize.Focus();
            }
            
        }

        private void txtsearchArticle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchType_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchType.Text != "")
            //{
            //    da = new SqlDataAdapter("Select vestertype as Type from tblvestertype", sqlcon);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            col2.Add(dt.Rows[i]["Type"].ToString());
            //        }
            //    }
            //    txtSearchType.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    txtSearchType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSearchType.AutoCompleteCustomSource = col2;
            //}
           
        }

        private void txtSearchColor_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchColor.Text != "")
            //{
            //    da = new SqlDataAdapter("Select ColorName as Color from tblColor", sqlcon);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            col3.Add(dt.Rows[i]["Color"].ToString());
            //        }
            //    }
            //    txtSearchColor.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    txtSearchColor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSearchColor.AutoCompleteCustomSource = col3;
            //}
            
        }

        private void txtSearchMaterail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchSol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchsize_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchsize.Text != "")
            //{
            //    da = new SqlDataAdapter("Select SizeName as Size from tblSize", sqlcon);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            col6.Add(dt.Rows[i]["Size"].ToString());
            //        }
            //    }
            //    else
            //    {
            //        //System.Windows.MessageBox.Show("Name not found");
            //    }
            //    txtSearchsize.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    txtSearchsize.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSearchsize.AutoCompleteCustomSource = col6;
            //}
        }

        private void txtSearchStamp_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchStamp.Text != "")
            //{
            //    da = new SqlDataAdapter("Select StampName as Stamp from tblStamp", sqlcon);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            col7.Add(dt.Rows[i]["Stamp"].ToString());
            //        }
            //    }
            //    else
            //    {
            //        //System.Windows.MessageBox.Show("Name not found");
            //    }
            //    txtSearchStamp.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    txtSearchStamp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSearchStamp.AutoCompleteCustomSource = col7;
            //}
        }

        private void txtSearchShooLeast_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchShooLeast.Text != "")
            //{
            //    da = new SqlDataAdapter("Select ShooLeastNumber as Pharma from tblshooleast", sqlcon);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            col8.Add(dt.Rows[i]["Pharma"].ToString());
            //        }
            //    }
            //    else
            //    {
            //        //System.Windows.MessageBox.Show("Name not found");
            //    }
            //    txtSearchShooLeast.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    txtSearchShooLeast.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSearchShooLeast.AutoCompleteCustomSource = col8;
            //}
        }

        private void autoarticle()
        {
            if (txtsearchArticle.Text != "")
            {
                GridArticle.Refresh();
                //GridListofItem.CurrentCell = GridListofItem.Rows[0].Cells[0];
                var dataTable = GridArticle.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.RowFilter = string.Format("Article  '%{0}%'", txtsearchArticle.Text);
                //dataTable.DefaultView.RowFilter = $"Article LIKE '%{int.Parse(txtsearchArticle.Text)}%'";
                GridArticle.ClearSelection();
                if (GridArticle.Rows.Count > 0)
                {
                    GridArticle.Rows[0].Selected = true;
                }
            }
            else
            {
                GridArticle.ClearSelection();
                if (GridArticle.Rows.Count > 0)
                {
                    GridArticle.Rows[0].Selected = true;
                }
                GridArticle.DataSource = f.ReturnDataTable("");
            }

        }

        private void txtsearchArticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            //if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchMaterail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchStamp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtSearchShooLeast_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        //VesterShoes

        int rate, qty;
        private void totalamount()
        {
            if (txtqty2.Text.Trim() == "")
            {
                qty = 0;
            }
            else
            {
                try
                {
                    qty = int.Parse(txtqty2.Text.Trim());
                }
                catch (Exception)
                {
                    txtqty2.Text = "";
                    qty = 0;
                }
            }
            if (txtrate2.Text == "")
            {
                rate = 0;
            }
            else
            {
                try
                {
                    rate = int.Parse(txtrate2.Text.Trim());
                }
                catch (Exception)
                {
                    txtrate2.Text = "";
                    rate = 0;
                }
            }
            txttotal.Text = (qty * rate).ToString();

        }


        private void btnsav2_Click(object sender, EventArgs e)
        {
            successfullOperation = 0;
            //sortid++;
            if (txtitemdetail2.Text != "" && txtqty2.Text != "" && txtrate2.Text != "" && int.Parse(txtqty2.Text) >= 0 && int.Parse(txtrate2.Text) >= 0 && int.Parse(txttotal.Text) >= 0)
            {
                //if (gridOrderDejtail.Items.Count == 0)
                {
                    try
                    {
                        string dt = ((DateTime)DateTime.Now).ToString("yyyy-MM-dd");
                        string strQuery = "";
                        if (updateitem==0)
                        {
                            strQuery = "INSERT INTO tblOrders (OrderId,SortID,ProfileId,ItemsID,ItemsQty,ItemsRate,ItemsTotal,OrderStatus,jobStates,Complete,OrderDatetime,CustomerPO,Enteredon,Enteredby) VALUES ('" + txtOrderID.Text + "','" + txtSortid.Text + "','" + txtCustomerId.Text + "','" + txtitemId.Text + "','" + txtqty2.Text + "','" + txtrate2.Text + "','" + txttotal.Text + "','" + 1 + "','" + 0 + "','" + 0 + "','" + dt + "','"  + ComboNote.Text + "','"+DateTime.Now+"','"+LoginUser+"')";
                        }
                        else
                        {
                         strQuery = "update tblOrders set ItemsID="+txtitemId.Text+ ", CustomerPO="+ComboNote.Text+" , ItemsQty=" + txtqty2.Text+ " , ItemsRate="+txtrate2.Text+ " , ItemsTotal="+txttotal.Text+ ", Enteredon='"+DateTime.Now+"',Enteredby='"+LoginUser+"' where OrderID=" + txtOrderID.Text+" and  sortid="+txtSortid.Text+" ";
                        }

                        if (sqlcon.State != ConnectionState.Open)
                        {
                            sqlcon.Open();
                        }
                        using (SqlCommand comm = new SqlCommand(strQuery, sqlcon))
                        {
                            comm.ExecuteNonQuery();
                        }

                        if (updateitem == 0)
                        {
                            int orderdetailid = f.findnumber("select orderdetailID from tblOrders order by orderdetailID desc");
                            string s = "INSERT INTO tblrecipeSteps (orderdetailID,CM,SM,AM,BM,PM,ProiM,FM,updatedBy,updatedon) VALUES ('" + orderdetailid + "','" + cm + "','" + sm + "','" + am + "','" + bm + "','" + pm + "','" + pr + "','" + fm + "','"+LoginUser+"','"+DateTime.Now+"')";
                            vc.Insert(s);
                            string s2 = "INSERT INTO tblRecipeStepsDetail (orderdetailID,CM,SM,AM,BM,PM,ProiM,FM,updatedBy,updatedon) VALUES ('" + orderdetailid + "','" + comboBox1.SelectedIndex + "','" + comboBox6.SelectedIndex + "','" + comboBox2.SelectedIndex + "','" + comboBox3.SelectedIndex + "','" + comboBox7.SelectedIndex + "','" + comboBox5.SelectedIndex + "','" + comboBox4.SelectedIndex + "','" + LoginUser + "','" + DateTime.Now + "')";
                            vc.Insert(s2);
                        }
                        else
                        {
                            int orderdetailid = f.findnumber("select orderdetailID from tblOrders where OrderID='"+txtOrderID.Text+"' and SortID='"+txtSortid.Text+"'");
                            string s = "update tblRecipeSteps set CM='" + cm + "', SM='" + sm + "',AM='" + am + "',BM='" + bm + "',PM='" + pm + "',ProiM='" + pr + "',FM='" + fm + "' ,updatedBy='" + LoginUser + "',updatedon='" + DateTime.Now + "' WHERE orderdetailID='" + orderdetailid + "'";
                            vc.Insert(s);
                            
                            string s2 = "update tblRecipeStepsDetail set CM='" + comboBox1.SelectedIndex + "', SM='" + comboBox6.SelectedIndex + "',AM='" + comboBox2.SelectedIndex + "',BM='" + comboBox3.SelectedIndex + "',PM='" + comboBox7.SelectedIndex + "',ProiM='" + comboBox5.SelectedIndex + "',FM='" + comboBox4.SelectedIndex + "' , updatedBy='" + LoginUser + "',updatedon='" + DateTime.Now + "'  WHERE orderdetailID='" + orderdetailid + "'";
                            vc.Insert(s2);
                        }
                        

                        panel2.Visible = false;
                        panel1.Visible = true;
                        txtOrderID_TextChanged(sender, e);

                    }
                    catch (Exception es)
                    {
                        System.Windows.MessageBox.Show(es.Message);
                    }

                    finally
                    {
                        if (sqlcon.State != ConnectionState.Closed)
                        {
                            sqlcon.Close();
                        }
                    }
                    //lblofficenumber.Visibility = Visibility.Visible;
                    //lblofficeaddress.Visibility = Visibility.Visible;
                    //lblpname.Visibility = Visibility.Visible;
                    //lblCompanyName.Visibility = Visibility.Visible;
                    //btnAddOrder.IsEnabled = false;
                }
                //clear();
                //txtsearchArticle.Text = "";
                //txtSearchType.Text = "";
                //txtSearchsize.Text = "";
                //txtSearchColor.Text = "";
                //txtSearchMaterail.Text = "";
                //txtSearchSol.Text = "";
                //txtSearchStamp.Text = "";
                //txtSearchShooLeast.Text = "";
                //txtitemId.Text = "";
                //txtitemdetail2.Text = "";
                //txtqty2.Text = "12";
                //txtrate2.Text = "";
            }
        }

        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {
            if (txtSortid.Text!="" && updateitem==0)
            {
                txtSortid.Text = (int.Parse(txtSortid.Text) + 1).ToString();
            }
            else
            {
                txtSortid.Text = "1";
            }
        }

        private void txtqty2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtrate2.Focus();
            }
        }

        private void txtCustomerPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtrate2.Focus();
            }
        }

        private void txtrate2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttotal.Focus();
            }
        }

        private void txttotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsav2.Focus();
            }
        }

        private void txtqty2_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtqty2_TextChanged(object sender, EventArgs e)
        {
            totalamount();
        }

        private void txtrate2_TextChanged(object sender, EventArgs e)
        {
            totalamount();
        }
        VestureClass vc=new VestureClass();
        private void txtrate2_Leave(object sender, EventArgs e)
        {
            //if (txtrate2.Text != "")
            //{
            //    int getrate = 0;
            //    try
            //    {
            //        SqlDataReader dr;
            //        sqlcon.Open();
            //        string query = "select ItemRate from tblCustItemsRate where ItemsID='" + txtitemId.Text + "' and ProfileId='" + txtCustomerId.Text + "'";
            //        SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
            //        dr = cmd.ExecuteReader();
            //        if (dr.Read())
            //        {
            //            getrate = int.Parse(dr.GetValue(0).ToString());
            //        }
            //        else
            //        {
            //            vc.Insert("INSERT INTO tblCustItemsRate (ItemsID,ProfileId,ItemRate) VALUES ('" + txtitemId.Text + "','" + txtCustomerId.Text + "','" + txtrate2.Text + "')");
            //        }
            //        if (getrate != int.Parse(txtrate2.Text))
            //        {
            //            vc.Update("UPDATE tblCustItemsRate SET ItemRate = '" + txtrate2.Text + "' WHERE ItemsID = '" + txtitemId.Text + "' and ProfileId='" + txtCustomerId.Text + "' ");
            //        }
            //    }
            //    catch (Exception es)
            //    {
            //        System.Windows.Forms.MessageBox.Show(es.Message.ToString());
            //        return;
            //    }
            //    finally
            //    {
            //        sqlcon.Close();
            //    }
            //}
        }

        private void txtSearchMaterail_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        int cm = 1;
        int sm = 1;
        int am = 1;
        int bm = 1;
        int pm = 1;
        int pr = 0;
        int fm = 1;
        int jm = 0;

        private void checkBoxCM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCM.Checked)
            {
                cm = 1;
            }
            else
            {
                cm = 0;
            }

        }

        private void checkBoxAM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAM.Checked)
            {
                am = 1;
            }
            else
            {
                am = 0;
            }

        }

        private void checkBoxBM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBM.Checked)
            {
                bm = 1;
            }
            else
            {
                bm = 0;
            }
        }

        private void checkBoxFM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFM.Checked)
            {
                fm = 1;
            }
            else
            {
                fm = 0;
            }
        }

        private void checkBoxPM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPM.Checked)
            {
                pm = 1;
            }
            else
            {
                pm = 0;
            }
        }

        private void checkBoxProiM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProiM.Checked)
            {
                pr = 1;
            }
            else
            {
                pr = 0;
            }
        }

        private void checkBoxSM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSM.Checked)
            {
                sm = 1;
            }
            else
            {
                sm = 0;
            }
        }

        float cmRate = 0;
        float smRate = 0;
        float amRate = 0;
        float bmRate = 0;
        float pmRate = 0;
        float prRate = 0;
        float fmRate = 0;
        float jmRate = 0;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateCM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where vender_type_id = 0 and  venderWorkCatagory = '"+comboBox1.SelectedIndex+ "' and MaterialID='"+lblMaterialID.Text+"' and ColorID=0 and active = 1"))
                    .ToString();
            cmRate = float.Parse(txtVrateCM.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateAM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where ColorID=0 and vender_type_id = 4 and venderWorkCatagory = '" + comboBox2.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1"))
                    .ToString();
            amRate = float.Parse(txtVrateAM.Text);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateBM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where ColorID=0 and vender_type_id = 5 and venderWorkCatagory = '" + comboBox3.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1"))
                    .ToString();
            bmRate= float.Parse(txtVrateBM.Text);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateFM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where vender_type_id = 6 and venderWorkCatagory = '" + comboBox4.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1"))
                    //"select VenderRate from tblvenderRate where vender_type_id = 6 and venderWorkCatagory = '" + comboBox4.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID='"+lblColorId.Text+"' and active = 1"))
                    .ToString();
            fmRate= float.Parse(txtVrateFM.Text);

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVratePtM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where vender_type_id = 2 and venderWorkCatagory = '" + comboBox7.SelectedIndex + "' and MaterialID='"+lblMaterialID.Text+"' and ColorID=0 and  active = 1"))
                    .ToString();
            pmRate= float.Parse(txtVratePtM.Text);

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateProi.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where vender_type_id = 3 and venderWorkCatagory = '" + comboBox5.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and active = 1"))
                    .ToString();
            prRate = float.Parse(txtVrateProi.Text);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateSM.Text =
                (f.findnumberfloat(
                    "select VenderRate from tblvenderRate where vender_type_id = 1 and venderWorkCatagory = '" + comboBox6.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and active = 1"))
                    .ToString();
            smRate= float.Parse(txtVrateSM.Text);

        }

        private void txtVrateCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar!='.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateBM_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateFM_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateProi_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtVrateCM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVrateAM_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtVrateBM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVrateFM_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtVratePtM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVrateProi_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVrateSM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtVrateCM_Leave(object sender, EventArgs e)
        {
            if (txtVrateCM.Text == "")
            {
                txtVrateCM.Text = "0";
                return;
            }
            if (cmRate == float.Parse(txtVrateCM.Text))
            {
                return;
            }
            //if (float.Parse(txtVrateCM.Text) < 0)
            //{
            //    txtVrateCM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where vender_type_id = 0 and  venderWorkCatagory = '" +
                comboBox1.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (0,'" + lblMaterialID.Text+"','" + comboBox1.SelectedIndex + "','" + txtVrateCM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateCM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text+ "' and vender_type_id=0 and venderWorkCatagory='" + comboBox1.SelectedIndex + "' and active=1");
            }
        }

        private void txtVrateAM_Leave(object sender, EventArgs e)
        {
            if (txtVrateAM.Text == "")
            {
                txtVrateAM.Text = "0";
                return;
            }
            if (amRate == float.Parse(txtVrateAM.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateAM.Text) < 1)
            //{
            //    txtVrateAM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where ColorID=0 and vender_type_id = 4 and venderWorkCatagory = '" +
                comboBox2.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (4,'" + lblMaterialID.Text + "','" + comboBox2.SelectedIndex + "','" + txtVrateAM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateAM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "' and vender_type_id=4 and venderWorkCatagory='" + comboBox2.SelectedIndex + "' and active=1");
            }
        }

        private void txtVrateBM_Leave(object sender, EventArgs e)
        {
            if (txtVrateBM.Text == "")
            {
                txtVrateBM.Text = "0";
                return;
            }
            if (bmRate == float.Parse(txtVrateBM.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateBM.Text) < 1)
            //{
            //    txtVrateBM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where ColorID=0 and vender_type_id = 5 and venderWorkCatagory = '" +
                comboBox3.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (5,'" + lblMaterialID.Text + "','" + comboBox3.SelectedIndex + "','" + txtVrateBM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateBM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "' and vender_type_id=5 and venderWorkCatagory='" + comboBox3.SelectedIndex + "' and active=1");
            }
        }

        private void txtVrateFM_Leave(object sender, EventArgs e)
        {
            if (txtVrateFM.Text == "")
            {
                txtVrateFM.Text = "0";
                return;
            }
            if (fmRate == float.Parse(txtVrateFM.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateFM.Text) < 1)
            //{
            //    txtVrateFM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where vender_type_id = 6 and venderWorkCatagory = '" +
                comboBox4.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (6,'" + lblMaterialID.Text + "','" + comboBox4.SelectedIndex + "','" + txtVrateFM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateFM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "'   and vender_type_id=6 and venderWorkCatagory='" + comboBox4.SelectedIndex + "' and active=1");
            }
        }

        private void txtVratePtM_Leave(object sender, EventArgs e)
        {
            if (txtVratePtM.Text == "")
            {
                txtVratePtM.Text = "0";
                return;
            }
            if (pmRate == float.Parse(txtVratePtM.Text))
            {
                
                return;
            }
            //if (int.Parse(txtVratePtM.Text) < 1)
            //{
            //    txtVratePtM.Text = "0";
            //    return;
            //}
            int num =f.findnumber(
                    "select count(*) from tblvenderRate where vender_type_id = 2 and venderWorkCatagory = '" + comboBox7.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and  active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (2,'" + lblMaterialID.Text + "','" + comboBox7.SelectedIndex + "','" + txtVratePtM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVratePtM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "' and vender_type_id=2 and venderWorkCatagory='" + comboBox7.SelectedIndex + "' and active=1");
            }
        }

        private void txtVrateProi_Leave(object sender, EventArgs e)
        {
            if (txtVrateProi.Text == "")
            {
                txtVrateProi.Text = "0";
                return;
            }
            if (prRate == float.Parse(txtVrateProi.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateProi.Text) < 1)
            //{
            //    txtVrateProi.Text = "0";
            //    return;

            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where vender_type_id = 3 and venderWorkCatagory = '" +
                comboBox5.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (3,'" + lblMaterialID.Text + "','" + comboBox5.SelectedIndex + "','" + txtVrateProi.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateProi.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "'and vender_type_id=3 and venderWorkCatagory='" + comboBox5.SelectedIndex + "' and active=1");
            }
        }

        private void txtVrateSM_Leave(object sender, EventArgs e)
        {
            if (txtVrateSM.Text=="")
            {
                txtVrateSM.Text = "0";
                return;
            }
            if (smRate == float.Parse(txtVrateSM.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateSM.Text)<1)
            //{
            //    txtVrateSM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where vender_type_id = 1 and venderWorkCatagory = '" +
                comboBox6.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and ColorID=0 and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (1,'" + lblMaterialID.Text + "','" + comboBox6.SelectedIndex + "','" + txtVrateSM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateSM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "' and  vender_type_id=1 and venderWorkCatagory='" + comboBox6.SelectedIndex + "' and active=1");
            }
        }

        private void lblMaterialID_TextChanged(object sender, EventArgs e)
        {
            comboBox4.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailFM));
            comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailAM));
            comboBox3.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailBM));
            comboBox1.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailCM));
            comboBox5.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailProi));
            comboBox7.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailPM));
            comboBox8.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailJM));
            comboBox6.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailSM));
            comboBox2.SelectedIndex = 1;
        }

        private void txtVrateFM_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblColorId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtVratePtM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearchArticle_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkBoxJM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxJM.Checked)
            {
                jm = 1;
            }
            else
            {
                jm = 0;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVrateJM.Text =
                (f.findnumber(
                    "select VenderRate from tblvenderRate where ColorID=0 and vender_type_id = 7 and venderWorkCatagory = '" + comboBox8.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1"))
                    .ToString();
            jmRate = float.Parse(txtVrateBM.Text);
        }

        private void txtVrateJM_TextChanged(object sender, EventArgs e)
        {
            if (txtVrateJM.Text == "")
            {
                txtVrateJM.Text = "0";
                return;
            }
            if (jmRate == float.Parse(txtVrateJM.Text))
            {
                return;
            }
            //if (int.Parse(txtVrateJM.Text) < 1)
            //{
            //    txtVrateJM.Text = "0";
            //    return;
            //}
            int num = f.findnumber(
                "select count(*) from tblvenderRate where vender_type_id = 7 and venderWorkCatagory = '" +
                comboBox8.SelectedIndex + "' and MaterialID='" + lblMaterialID.Text + "' and active = 1");
            if (num == 0)
            {
                vc.Insert("INSERT INTO tblvenderRate (vender_type_id,MaterialID,VenderWorkCatagory,VenderRate,updateby,updatein,updateon) VALUES (7,'" + lblMaterialID.Text + "','" + comboBox8.SelectedIndex + "','" + txtVrateJM.Text + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')");
            }
            else
            {
                vc.Update("update tblvenderRate set VenderRate='" + txtVrateJM.Text + "',updateby='" + LoginUser + "',updatein='" + SystemUser + "',updateon='" + DateTime.Now + "'  where MaterialID='" + lblMaterialID.Text + "'   and vender_type_id=7 and venderWorkCatagory='" + comboBox8.SelectedIndex + "' and active=1");
            }
        }

        private void txtrate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
