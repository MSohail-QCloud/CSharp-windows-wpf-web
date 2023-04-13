using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VesterShoes.classes;

namespace VesterShoes
{
    public partial class FormProfileFm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        functions f=new functions();
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        

        public FormProfileFm(string abc,string loguser,string sysUser)
        {
            InitializeComponent();
            DisableallControl();
            CombProfileType.DataSource = Enum.GetNames(typeof(enumClass.profileType));
            CombVenderType.DataSource = Enum.GetNames(typeof(enumClass.ProcessStates));
            var = abc;
            LoginUser = loguser;
            SystemUser = sysUser;
        }
        public int GlobalVar { get; set; }
        public string LoginUser { get; set; }
        public string SystemUser { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(btnSave.Text);
            if (btnSave.Text == "OK")
            {
                if (lblProfileId.Text!="")
                {
                    GlobalVar = int.Parse(lblProfileId.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }
            else if (btnSave.Text == "Save")
            {
                if (txtProfileName.Text != "" && txtCompnyName.Text!="")
                {
                    string abc=f.findname("select PName from tblProfile where PName = '"+txtProfileName.Text+"'");
                    if (CombVenderType.SelectedIndex!=0 && abc!="")
                    {
                        MessageBox.Show("This name is already exist.");
                        return;
                    }
                    { 

                    try
                        {
                            string StrQuery =
                                "INSERT INTO tblprofile (ProfileId,pname,pgaurdianname,pcompanyname,pmobile,pofficenumber,pcnic,PhomeAddress,paddress,ptype,vender_type_id,PGaurdianNameID,updateby,updatein,updateon) VALUES ('" +
                                lblProfileId.Text + "','" + txtProfileName.Text + "','" + CommCombo.Text + "','" +
                                txtCompnyName.Text + "','" + txtPMobile.Text + "','" + txtPOfficeNumber.Text + "','" +
                                txtCnic.Text + "','" + txtHomeAddress.Text + "','" + txtOfficeAddress.Text + "','" +
                                CombProfileType.SelectedIndex + "','" + CombVenderType.SelectedIndex + "','" + CommCombo.SelectedValue + "','" + LoginUser + "','" + SystemUser+ "','" + DateTime.Now+ "')";
                            sqlcon.Open();
                            using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                            {
                                comm.ExecuteNonQuery();
                            }
                            Clear();
                            btnNewProfile_Click(sender, e);

                        }
                        catch (Exception es)
                        {
                            MessageBox.Show(es.Message);
                        }

                        finally
                        {
                            sqlcon.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Person Name and Company Name is necessary.");
                }
             }
            else if (btnSave.Text == "Update")
            {
                if (txtProfileName.Text != "")
                {
                    if(CommCombo.Text.Contains("--No-- Customer"))
                    {
                        CommCombo.Text = "";
                    }
                    //vc.Update("UPDATE tblMaterOrde SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "', OrderSave='" + 0 + "' ,Cancel='" + 1 + "' WHERE MaterOrderID = '" + lblOrderID.Content + "'");
                    vc.Update("update tblProfile set PName='"+txtProfileName.Text+"',PGaurdianName='"+CommCombo.Text+ "',PCompanyName='"+txtCompnyName.Text+ "',Pmobile='"+txtPMobile.Text+ "',POfficeNumber='"+txtPOfficeNumber.Text+ "',PCnic='"+txtCnic.Text+ "',Paddress='"+txtOfficeAddress.Text+ "',PhomeAddress='"+txtHomeAddress.Text+ "',PType='"+CombProfileType.SelectedIndex+ "',vender_type_id='"+CombVenderType.SelectedIndex+ "' ,PGaurdianNameID='" + CommCombo.SelectedValue + "', updateby='"+LoginUser+"',updatein='"+SystemUser+"',updateon='"+DateTime.Now+"' where ProfileId='" + lblProfileId.Text+"'");
                    btnSave.Text = "OK";
                    DisableallControl();
                    btnSave.Focus();
                    btnNewProfile.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please Enter Person Name.");
                }
            }
            if (var == "Orderform")
            {
                LoadgridCustomer();
            }
            if (var == "Vendeform")
            {                
                loadvendergrid();
            }
            //LoadgridCustomer();

        }
        VestureClass vc = new VestureClass();

        string var;
        private void FormCustomerFm_Load(object sender, EventArgs e)
        {
            LoadcommCombo();

            if (var== "Orderform")
            {
                gridVender.SendToBack();
                Text = "Customer Detail";
                btnSave.Text = "OK";
                LoadgridCustomer();
            }
            if (var == "AddInfo")
            {
                Text = "Add New Info";
                groupBox1.Enabled = false;
                btnSave.Text = "Save";
                txtProfileName.Focus();
            }
            if (var == "Vendeform")
            {
                Gridcustomer.SendToBack();
                Text = "Vender Detail";
                loadvendergrid();
                btnSave.Text = "OK";
            }
            
        }

        private void LoadcommCombo()
        {
            SqlCommand sqlCmd = new SqlCommand("select ProfileId,PCompanyName from tblProfile where PType='3' and Active=1", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
            DictionaryCustomer.Add(-1, "--No-- Customer");
            while (sqlReader.Read())
            {
                string name = sqlReader["PCompanyName"].ToString();
                int Value = int.Parse(sqlReader["ProfileId"].ToString());
                DictionaryCustomer.Add(Value, name);
            }
            CommCombo.DisplayMember = "Value";
            CommCombo.ValueMember = "Key";
            CommCombo.DataSource = new BindingSource(DictionaryCustomer, null);
            CommCombo.SelectedIndex = 0;
            sqlReader.Close();
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        private void Clear()
        {
            txtCnic.Text = "";
            txtCompnyName.Text = "";
            txtHomeAddress.Text = "";
            txtOfficeAddress.Text = "";
            CommCombo.SelectedIndex=0;
            txtPMobile.Text = "";
            txtPOfficeNumber.Text = "";
            txtProfileName.Text = "";            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalVar = 0;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            Width = 954;
            StartPosition = 0;
            LoadcommCombo();
            btnSave.Text = "Save";
            int numb = f.createNumber("Select top 1 profileid  from tblprofile  order by profileid desc");
            lblProfileId.Text = numb.ToString();
            enableallcontrol();
            Clear();
        }

        private void enableallcontrol()
        {
            txtProfileName.Enabled = true;
            txtHomeAddress.Enabled = true; ;
            txtOfficeAddress.Enabled = true;
            CommCombo.Enabled = true;
            txtPMobile.Enabled = true;
            txtPOfficeNumber.Enabled= true;
            txtCompnyName.Enabled = true;
            txtCnic.Enabled = true;
            CombProfileType.Enabled = true;
            CombVenderType.Enabled = true;
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCustomerID.Text != "")
                {
                    custid = int.Parse(txtCustomerID.Text);
                    if (var == "Orderform")
                    {
                        LoadProfileDetail(0);
                    }
                    if (var == "AddInfo")
                    {
                        LoadProfileDetail(3);
                    }
                    btnModify.Visible = true;
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                txtSerchCompanyName.Focus();
            }
        }

        int custid;
        int profiletype;
        private void LoadProfileDetail(int ptypeid)
        {
            try
            {
                lblProfileId.Text = "";
                Clear();
                SqlDataReader dr;
                sqlcon.Open();
                string query = "";
                if (ptypeid!=3)
                {
                   query = "Select * from tblprofile where ProfileId='" + custid + "' and PType='" + ptypeid + "' and Active=1";
                }
                else
                {
                    query = "Select * from tblprofile where ProfileId='" + custid + "' and active =1 ";
                }
                
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblProfileId.Text= (dr.GetValue(0).ToString());
                    txtProfileName.Text= (dr.GetValue(1).ToString()).Trim();
                    CommCombo.SelectedValue=int.Parse( (dr.GetValue(12).ToString()));
                    txtPMobile.Text= (dr.GetValue(4).ToString()).Trim();
                    txtPOfficeNumber.Text= (dr.GetValue(5).ToString()).Trim();
                    txtCnic.Text= (dr.GetValue(6).ToString()).Trim();
                    txtCompnyName.Text= (dr.GetValue(3).ToString()).Trim();
                    txtHomeAddress.Text= (dr.GetValue(8).ToString()).Trim();
                    txtOfficeAddress.Text= (dr.GetValue(7).ToString()).Trim();
                    profiletype =int.Parse (dr.GetValue(9).ToString());
                    int Vendertype =int.Parse (dr.GetValue(10).ToString());
                    CombProfileType.SelectedIndex = profiletype;
                    CombVenderType.SelectedIndex = Vendertype;

                    DisableallControl();
                    btnSave.Text = "OK";
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.MessageBox.Show("No Record Found, or Please check your ID.");
                }
                dr.Close();

            }
            catch (Exception es)
            {
                System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                return;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void DisableallControl()
        {
            txtProfileName.Enabled = false;
            txtHomeAddress.Enabled =false;
            txtOfficeAddress.Enabled = false;
            CommCombo.Enabled = false;
            txtPMobile.Enabled = false;
            txtPOfficeNumber.Enabled = false;
            txtCompnyName.Enabled = false;
            txtCnic.Enabled = false;
            CombProfileType.Enabled = false;
            CombVenderType.Enabled = false;
        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CombProfileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CombProfileType.SelectedIndex == 1)
            {
                CombVenderType.Visible = true;
            }
            else 
            if (CombProfileType.SelectedIndex == 3)
            {
                CommCombo.Text = "";
            }
            else
            {
                CombVenderType.Visible = false;
                CombVenderType.Focus();
            }
        }

        private void txtPMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                txtPOfficeNumber.Focus();
            }
        }

        private void txtPMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPOfficeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        SqlDataAdapter da;
        private void txtSerchCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (txtSerchCompanyName.Text != "")
            {
                da = new SqlDataAdapter("Select PCompanyName as CompanyName from tblProfile where Active=1", sqlcon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        coll.Add(dt.Rows[i]["CompanyName"].ToString());
                    }
                }
                txtSerchCompanyName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSerchCompanyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSerchCompanyName.AutoCompleteCustomSource = coll;
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Width = 1080;
            LoadcommCombo();
            enableallcontrol();
            btnSave.Text = "Update";
            btnNewProfile.Visible = false;
            btnModify.Visible = false;
            
        }

        private void txtSerchCompanyName_Enter(object sender, EventArgs e)
        {
            txtSerchCompanyName.BorderStyle=BorderStyle.FixedSingle;
        }

        private void txtCustomerID_Enter(object sender, EventArgs e)
        {
            txtCustomerID.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtProfileName_Enter(object sender, EventArgs e)
        {
            txtProfileName.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtOfficeAddress_Enter(object sender, EventArgs e)
        {
            txtOfficeAddress.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtHomeAddress_Enter(object sender, EventArgs e)
        {
            txtHomeAddress.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtCompnyName_Enter(object sender, EventArgs e)
        {
            txtCompnyName.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtCnic_Enter(object sender, EventArgs e)
        {
            txtCnic.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtPOfficeNumber_Enter(object sender, EventArgs e)
        {
            txtPOfficeNumber.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtPMobile_Enter(object sender, EventArgs e)
        {
            txtPMobile.BorderStyle=BorderStyle.FixedSingle;
            
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            txtCustomerID.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSerchCompanyName_Leave(object sender, EventArgs e)
        {
            txtSerchCompanyName.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtProfileName_Leave(object sender, EventArgs e)
        {
            txtProfileName.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtPMobile_Leave(object sender, EventArgs e)
        {
            txtPMobile.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtPOfficeNumber_Leave(object sender, EventArgs e)
        {
            txtPOfficeNumber.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtCnic_Leave(object sender, EventArgs e)
        {
            txtCnic.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtCompnyName_Leave(object sender, EventArgs e)
        {
            txtCompnyName.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtHomeAddress_Leave(object sender, EventArgs e)
        {
            txtHomeAddress.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtOfficeAddress_Leave(object sender, EventArgs e)
        {
            txtOfficeAddress.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProfileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                CommCombo.Focus();
            }
    }

        private void txtPGaurdianName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                txtPMobile.Focus();
            }
        }

        private void txtPOfficeNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                txtCnic.Focus();
            }
        }

        private void txtCnic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                txtCompnyName.Focus();
            }
        }

        private void txtCompnyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                txtHomeAddress.Focus();
            }
        }

        private void txtHomeAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
               txtOfficeAddress .Focus();
            }
        }

        private void txtOfficeAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                CombProfileType.Focus();
            }
        }

        private void CombVenderType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtProfileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtPGaurdianName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtCompnyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtHomeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtOfficeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void LoadgridCustomer()
        {

            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select ProfileId,PName,PGaurdianName,PCompanyName from tblProfile where PType='0' and Active=1 ";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            Gridcustomer.DataSource = dtarticle;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        private void tabCustomer_Enter(object sender, EventArgs e)
        {
            LoadgridCustomer();
        }

        private void loadvendergrid()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select ProfileId,PName,tb.vender_type_name from tblProfile tp join tblProcessStates tb on tp.vender_type_id=tb.vender_type_id where PType='1' and tp.Active=1 ";
            cmd3.ExecuteNonQuery();
            DataTable dtarticle = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtarticle);
            gridVender.DataSource = dtarticle;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        private void Gridcustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void gridVender_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void gridVender_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerID.Text = (gridVender.Rows[e.RowIndex].Cells[0].Value.ToString());
                lblProfileId.Text = txtCustomerID.Text;
                custid = int.Parse(txtCustomerID.Text);
                LoadProfileDetail(3);
                btnModify.Visible = true;
            }
        }

        private void Gridcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerID.Text = (Gridcustomer.Rows[e.RowIndex].Cells[0].Value.ToString());
                custid = int.Parse(txtCustomerID.Text);
                lblProfileId.Text = custid.ToString();
                LoadProfileDetail(0);
                btnModify.Visible = true;
            }
        }

        private void Gridcustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerID.Text = (Gridcustomer.Rows[e.RowIndex].Cells[0].Value.ToString());
                lblProfileId.Text = txtCustomerID.Text;
                custid = int.Parse(txtCustomerID.Text);
                LoadProfileDetail(0);
            }
        }

        private void gridVender_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerID.Text = gridVender.Rows[e.RowIndex].Cells[0].Value.ToString();
                custid = int.Parse(txtCustomerID.Text);
                lblProfileId.Text = txtCustomerID.Text;
                LoadProfileDetail(3);
            }
        }

        private void Gridcustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Gridcustomer_CellClick(sender, e);
            btnSave_Click(sender, e);
        }

        private void gridVender_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gridVender_CellClick(sender, e);
            btnSave_Click(sender, e);
        }

        private void Gridcustomer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Gridcustomer_CellClick(sender, e);
            btnSave_Click(sender, e);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
    }
}
