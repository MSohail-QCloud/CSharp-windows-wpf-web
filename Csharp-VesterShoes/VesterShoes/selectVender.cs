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
    public partial class selectVender : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        VestureClass vc = new VestureClass();
        public string LoginUser { get; set; }
        public string SystemUser1 { get; set; }
        public int jobid{ get; set; }
        public int vTypeNumb{ get; set; }
         int VenderId=0;
         DateTime issuedate;
        public selectVender(int jid,int vtnumb,string loguser,string sysuser)
        {
            InitializeComponent();
            jobid = jid;
            vTypeNumb = vtnumb;
            comboBox1.DataSource = Enum.GetNames(typeof(enumClass.ProcessStates));
            LoginUser = loguser;
            SystemUser = sysuser;
            SystemUser1 = sysuser;
        }
        
        
        int retjobid;
        int materialid;
        int itemid;
       //VestureClass vc= new VestureClass();
        private void selectVender_Load(object sender, EventArgs e)
        {
            
            //vender week
            DayOfWeek desiredDay = DayOfWeek.Friday;
            int offsetAmount = (int)desiredDay - (int)DateTime.Now.DayOfWeek;
            DateTime lastWeekfriday = DateTime.Now.AddDays(offsetAmount-7);
            dtPickerIssueDate.MinDate= lastWeekfriday.AddDays(-1);
            dtPickerIssueDate.MaxDate = DateTime.Today;
            
            try
            {
                string vquery = "select * from tblVenderOrders where ProcessiingID = '" + jobid + "' order by vender_type_id";
                DataTable vorderhistorydt = vc.selectdatatable(vquery);
                string chkSteps = "select CM,SM,PM,ProiM,AM,BM,FM,JM,ItemsID from tblRecipeSteps s, tblOrders o where s.orderdetailID=o.orderdetailID and o.JobID='" + jobid + "' ";
                DataTable StepsDT = vc.selectdatatable(chkSteps);
                string vorderdetail =
                    "select CM,SM,PM,ProiM,AM,BM,FM,JM from tblRecipeStepsDetail d, tblOrders o where d.orderdetailID=o.orderdetailID and o.JobID='" + jobid + "'";
                DataTable vorderdetaildt = vc.selectdatatable(vorderdetail);
                comboBox1.SelectedIndex = vTypeNumb;
                string chk = vorderdetaildt.Rows[0][vTypeNumb].ToString();
                comboBox2.SelectedIndex = int.Parse(vorderdetaildt.Rows[0][vTypeNumb].ToString());
                if (vorderhistorydt.Rows.Count>0)
                {
                    for (int i = 0; i < vTypeNumb+1; i++)
                    {
                        bool stepvalue = bool.Parse(StepsDT.Rows[0][i].ToString());
                         itemid = int.Parse(StepsDT.Rows[0][8].ToString());
                        var result = vorderhistorydt.Select("vender_type_id = '" + i + "'");
                        //if (result[9].ToString()=="" && result.Count() < 0)
                        string retQty ="";
                        int count = result.Count();
                        if (count>0)
                        {
                            retQty = result[0][9].ToString();
                        }
                        else
                        {
                            retQty = "";
                        }
                        if (retQty=="")
                        {
                            if (vTypeNumb == 6)
                            {
                                if (stepvalue && i != vTypeNumb)
                                {
                                    lblerr.Text = @"Previouse Step ( " + (enumClass.ProcessStates) i + @" ) is Missing";
                                    return;
                                }
                            }
                            if (stepvalue==false && i==vTypeNumb)
                            {
                                lblerr.Text= @"Step ( " + (enumClass.ProcessStates)i + @" ) is Not Allowed.)";
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (vTypeNumb!=0)
                    {
                        lblerr.Text = "First Step is Pending.";
                    }
                }
                materialid = f.findnumber("select MaterialID from tblOrders o, tblItems i where o.ItemsID=i.ItemsID and o.JobID='" + jobid+"' ");
                float vrate = f.findnumberfloat("select VenderRate from tblVenderRate where vender_type_id='" + vTypeNumb + "' and  VenderWorkCatagory='" + comboBox2.SelectedIndex + "' and MaterialID='"+materialid+"' and  Active=1");
                txtRate.Text = vrate.ToString();
                venderComboLoad();
                SqlDataReader dr = null;
           
                Text = "JOb ID # " + jobid;
                //dtPickerIssueDate.Value = DateTime.Now;
               if (vorderhistorydt.Rows.Count > 0)
                {
                    var result = vorderhistorydt.Select("vender_type_id = '"+vTypeNumb+"'");
                    int ab = result.Count();
                    if ( ab>0)
                    {
                        lblerr.Text = @" ";
                        retjobid = int.Parse(result[0][0].ToString());
                        VenderId = int.Parse(result[0][1].ToString());
                        textBox1.Text = (result[0][4].ToString());
                        txtRate.Text = (result[0][5].ToString());
                        issuedate = DateTime.Parse((result[0][6].ToString()));
                        string chkreturn = result[0][8].ToString();
                        btnissued.Enabled = false;
                        btnReturn.Enabled = true;
                        
                        comboVender.SelectedValue = VenderId;
                        comboVender.Enabled = false;
                        if (chkreturn != "")
                        {
                            lblissuedate.Text="Issue Date:"+(DateTime.Parse(result[0][8].ToString())).ToString("dd-MM-yyyy");
                            txtRate.Text = (result[0][5].ToString());
                            lblerr.Text = @"Item is Returned.";
                            comboVender.Enabled = false;
                            btnReturn.Visible = false;
                            btnModify.Visible = true;
                        }
                        if (vTypeNumb > 5)
                        {
                            //var res = vorderhistorydt.Select("vender_type_id = '" + (vTypeNumb-1) + "'");
                            var res = vorderhistorydt.Select("vender_type_id = '" + (vTypeNumb) + "'");
                            textBox1.Text = (res[0][4].ToString());
                        }
                    }
                }
                if (lblerr.Text=="")
                {
                    btnissued.Enabled = true;
                }
                if (lblerr.Text==@" ") //space is to identify return
                {
                    btnReturn.Enabled = true;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error on Loading SelectVenderForm:" + es.Message);
            }
            
        }

        private void venderComboLoad()
        {
            try
            {

                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select ProfileId,PName from tblProfile where PType='1' order by PName ";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                //CombVender.au = false;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    comboVender.DisplayMember = "PName";
                    comboVender.ValueMember = "ProfileId";
                    comboVender.DataSource = ds.Tables[0];
                }
                else
                {
                    ds.Tables[0].Clear();
                    comboVender.DisplayMember = "PName";
                    comboVender.ValueMember = "ProfileId";
                    comboVender.DataSource = ds.Tables[0];
                    
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public int FlagUpdate { get; set; }
        public int returned { get; set; }
        public DateTime dt { get; set; }
        public string dt_str = "";
        public string vendername { get; set; }
        public string showdata { get; set; }

        private void btnissued_Click(object sender, EventArgs e)
        {
            if (comboVender.Text=="")
            {
                MessageBox.Show("Select Vender.");
                return;
            }
            if (textBox1.Text=="" || txtRate.Text=="" || textBox1.Text=="0")
            {
                MessageBox.Show("پہلےقیمت اور تعداد داخل کریں۔");
                return ;
            }
            dt = dtPickerIssueDate.Value;
            dt_str = dt.ToString("yyyy-MM-dd");

            //dt_str =dt.Convert(VARCHAR, dt, 103);
            try
            {
                vc.Insert("INSERT INTO tblVenderOrders (ProcessiingID,ProfileId,vender_type_id,IssueRate,IssueQty,IssueDate,Note,entereddate,EnteredBy,EnteredIn) VALUES ('" + jobid + "','" + comboVender.SelectedValue + "','" + vTypeNumb + "','" + float.Parse( txtRate.Text) + "','"+textBox1.Text+"','" + dt_str + "','" + "Send" + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','"+LoginUser+"','"+SystemUser1+"')");
            }

            catch (Exception es)
            {
                MessageBox.Show("Something Missing while insertion. Contact to vender: " + es.Message);
            }
             //vendername = comboVender.Text;
            
            returned = 0;
            FlagUpdate = 1;

            showdata = dt.ToString("dd-MM-yyyy") + Environment.NewLine + comboVender.Text+Environment.NewLine+" __";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
        functions f= new functions();
        
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboVender.Text=="")
                {
                    MessageBox.Show("Select Vender.");
                    return;
                }
                if (textBox2.Text=="0")
                {
                    MessageBox.Show("Price must be greater than Zero.");
                    return;
                }
                if (textBox1.Text == "0" && textBox1.Text=="")
                {
                    MessageBox.Show("Qty must b greater than zero");
                    return;
                }
                DateTime startdate = (DateTime)dtPickerIssueDate.Value;
                string startdate1 = startdate.ToString("yyyy-MM-dd");
                vc.Insert("UPDATE tblVenderOrders SET ReturnDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', IssueRate='" + float.Parse(txtRate.Text)+ "',IssueQty='" + textBox1.Text + "', ReturnQty='"+textBox1.Text+ "',UpdateBy='"+LoginUser+ "',UpdateIN='"+SystemUser1+ "',Updateon='"+DateTime.Now+"' WHERE VenderAccountid = '" + retjobid + "' ");
                //int venderAcountId = f.findnumber("select top(1) VenderAccountID from tblVendersAccount ORDER BY VenderAccountID Desc ");
                vc.Insert("insert into tblVenderBills (JobID,VenderOrderId,ProfileID,VAmount,VDateTime,EnteredON,EnteredBy,VFlag,VRemarks,EnteredIN) values('" + jobid + "','" + retjobid + "','" + comboVender.SelectedValue + "','" + textBox2.Text + "','" + startdate1 + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + LoginUser + "','C','Work Done','"+SystemUser+"')");
                //vc.Insert("insert into tblLedger (LedgerTypeID,EventID,ProfileId,DebitAmount,CreditAmount,datetime,SpecialNOte,VenderAccountID) values('2','" + jobid + "','" + VenderId + "','" + textBox2.Text + "',0,'" + DateTime.Now + "','" + "Vender Account" + "','" + venderAcountId + "')");
                if (vTypeNumb == 6)
                {
                    vc.Insert("update tblOrders set jobStates=5 , Complete='1',jobEnteredby='"+LoginUser+"' where JobID='" + jobid + "' ");
                }
                //vendername = comboVender.Text;
                dt = dtPickerIssueDate.Value;
                dt_str = dt.ToString("yyyy-MM-dd");
                returned = 1;
                FlagUpdate = 1;

                showdata = issuedate.ToString("dd-MM-yyy") + Environment.NewLine + comboVender.Text +Environment.NewLine + dt.ToString("dd-MM-yyyy");
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            
        }
       string SystemUser = System.Environment.UserName + "~" + System.Environment.MachineName;
         private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "" && textBox1.Text != "")
            {
                //textBox2.Text = ((int.Parse(txtNextStepQty.Text) - (int.Parse(txtReturnQty.Text))).ToString());
                textBox2.Text = (Math.Round(float.Parse(textBox1.Text) * (float.Parse(txtRate.Text))).ToString());
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtRate_TextChanged(sender, e);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModify.Text == "Update")
                {
                    if (VenderId != int.Parse(comboVender.SelectedValue.ToString()))
                    {
                        string str = "insert into tblChangeLog(LogDatetime,JobID,ChangeWhat,ChangeFrom,ChangeTo,ChangeBy,ChangeIn,ChangeOn)values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + jobid + "','Vender Change','" + VenderId + "','" + comboVender.SelectedValue + "','" + LoginUser + "','" + SystemUser1+ "','" + DateTime.Now + "')";
                        vc.Insert(str);
                    }
                   
                    vc.Insert("UPDATE tblVenderOrders SET ProfileId='"+comboVender.SelectedValue+"', IssueRate='" + float.Parse(txtRate.Text) + "',IssueQty='" + textBox1.Text + "',ReturnDate='"+dtPickerIssueDate.Value.ToString("yyyy-MM-dd")+"',UpdateBy='" + LoginUser + "',UpdateIN='" + SystemUser1 + "',Updateon='" + DateTime.Now + "'  WHERE VenderAccountid = '" + retjobid + "' ");
                    vc.Insert("update tblVenderBills SET ProfileId='" + comboVender.SelectedValue + "', VAmount='" + textBox2.Text + "',VDateTime='"+dtPickerIssueDate.Value.ToString("yyyy-MM-dd")+"',EnteredON='" + DateTime.Now+ "',EnteredBy='"+LoginUser+ "',EnteredIN='"+SystemUser1+ "' where VenderOrderId='" + retjobid + "' ");

                    returned = 2; //modify
                    FlagUpdate = 1;
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    comboVender.Enabled = true;
                    textBox1.Enabled = true;
                    txtRate.Enabled = true;
                    btnModify.Text = "Update";
                }
               
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailCM));

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailSM));

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailPM));

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailProi));

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailAM));

            }
            else if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailBM));

            }
            else if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailFM));


            }
            else if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.DataSource = Enum.GetNames(typeof(enumClass.RecipeDetailJM));

            }
        }
        public string gvar = "";
        private void btnNewVender_Click(object sender, EventArgs e)
        {
            gvar = "Vendeform";
            FormProfileFm fcf = new FormProfileFm(gvar,LoginUser,SystemUser1);
            if (fcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //custID = fcf.GlobalVar;
            };

            //if (custID == 0)
            //{
            //    return;
            //}
        }

        private void btnSaveVender_Click(object sender, EventArgs e)
        {
            int numb = f.createNumber("Select top 1 profileid  from tblprofile  order by profileid desc");
            if (comboVender.Text != "")
            {
                string abc = f.findname("select PName from tblProfile where PName = '" + comboVender.Text + "'");
                if (abc != "")
                {
                    MessageBox.Show("This name is already exist.");
                    return;
                }
                {

                    try
                    {
                        string StrQuery =
                            "INSERT INTO tblprofile (ProfileId,pname,pgaurdianname,pcompanyname,pmobile,pofficenumber,pcnic,PhomeAddress,paddress,ptype,vender_type_id,PGaurdianNameID,updateby,updatein,updateon) VALUES ('" +
                            numb + "','" + comboVender.Text + "','" + "" + "','" +"" + "','" + "" + "','" + "" + "','" +"" + "','" + "" + "','" + "" + "','" + 1 + "','" + comboBox1.SelectedIndex + "','" + 0 + "','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now + "')";
                        sqlcon.Open();
                        using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                        {
                            comm.ExecuteNonQuery();
                            comboVender.SelectedValue = numb;
                            MessageBox.Show("Successfully Added.");
                            //comboVender.Text = comboVender.Text;
                        }
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

        }

        private void comboVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboVender.Items.Contains(comboVender.Text))
            {
                btnNewVender.Enabled = true;
            }
            else
            {
                btnNewVender.Enabled = false;
            }
        }

        private void comboVender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
