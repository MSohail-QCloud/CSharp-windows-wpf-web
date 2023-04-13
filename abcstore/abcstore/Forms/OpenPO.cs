using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace abcstore.Forms
{
    public partial class OpenPO : Form
    {
        readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public int Resultradiobutton { get; set; }
        //int logid = 0;
        //SqlCommand cmd2;
        SqlCommand cmdd;
        //int master_part;
        string q="";
        public OpenPO()
        {
            InitializeComponent();
        }

        private void OpenPO_Load(object sender, EventArgs e)
        {
            POtextBox.Focus();
        }

        private void POtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (POtextBox.Text != "")
                {
                    //po number generate
                     q = " select supplier_bill_no,Pro_code,po_datetime,po_amount,po_paid,po_payable,po_remarks,p_TuckMess from PO_master where po_number= '"+POtextBox.Text+"' and flag=1 ";
                     cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {

                        int billNo = (int)dbr["supplier_bill_no"];
                        int proCode = (int)dbr["Pro_code"];
                        DateTime dt = (DateTime)dbr["po_datetime"];
                        int amount = (int)dbr["po_amount"];
                        int paid = (int)dbr["po_paid"];
                        int payable = (int)dbr["po_payable"];
                        string remarks = (string)dbr["po_remarks"];
                        int tukmess = (int)dbr["p_TuckMess"];
                        //string profileName = (string)dbr["Pro_name"];
                        //string profileCompnayName = (string)dbr["pro_companyname"];
                        Bill_no_textBox.Text = billNo.ToString();
                        SupplierIdtextBox.Text = proCode.ToString();
                        datetimelabel.Text = dt.ToString(CultureInfo.CurrentCulture);
                        AmounttextBox.Text = amount.ToString();
                        paidtextBox.Text = paid.ToString();
                        payabletextBox.Text = payable.ToString();
                        RemarkstextBox.Text = remarks;
                        
                        if (tukmess==1)
                        {
                            messradioButton.Checked = true;
                        }
                        else
                        {
                            tukshopradioButton.Checked = true;
                        }
                        
                    }
                    _con.Close();
                    dbr.Close();
                    //step2
                    
                    q = " select Pro_name,pro_companyname from Profile where Pro_code= '" + SupplierIdtextBox.Text + "'  ";
                    cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr1 = cmdd.ExecuteReader();
                    while (dbr1.Read())
                    {
                        string profileName = (string)dbr1["Pro_name"];
                        string profileCompnayName = (string)dbr1["pro_companyname"];
                        suppliertextBox.Text = profileName;
                        SupplierCompnytextBox.Text = profileCompnayName;
                    }
                    dbr1.Close();
                    _con.Close();
                    Purchasegrid();
                    //finish_button.Enabled = false;

                }
            }
        }
        private void Purchasegrid()
        {

            var str = "select p.p_code, p.p_name,p.p_size,pd.po_rate,pd.po_qty,pd.po_itemsum from store_product p right join PO_detail pd on  p.p_code=pd.p_code where po_number= '" + POtextBox.Text + "'";
            var com = new SqlCommand(str, _con);
            var ada = new SqlDataAdapter(com);
            var ds = new DataSet();
            ada.Fill(ds, "b_payableam");
            purchasedataGridView.DataMember = "b_payableam";
            purchasedataGridView.DataSource = ds;
            purchasedataGridView.Columns[0].HeaderCell.Value = "Item code";
            purchasedataGridView.Columns[1].HeaderCell.Value = "Name";
            purchasedataGridView.Columns[2].HeaderCell.Value = "Size";
            purchasedataGridView.Columns[3].HeaderCell.Value = "Rate";
            purchasedataGridView.Columns[4].HeaderCell.Value = "Quantity";
            purchasedataGridView.Columns[5].HeaderCell.Value = "Sub Total";
        }

        private void SupplierIdtextBox_TextChanged(object sender, EventArgs e)
        {
        //   if (SupplierIdtextBox.Text != "")
        //        {
                   
        //        }
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void purchasedataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                 itmcodetextBox.Text = purchasedataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                itemdesctextBox.Text = purchasedataGridView.Rows[e.RowIndex].Cells[1].Value
                                       + purchasedataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                 ItemRatetextBox.Text = purchasedataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                NewQtytextBox.Text = purchasedataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                totaltextBox.Text = purchasedataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                
                
                
            }
        }

        private void NewQtytextBox_TextChanged(object sender, EventArgs e)
        {
            if (NewQtytextBox.Text!="")
            {
                TotalQtytextBox.Text = (int.Parse(PrevQtytextBox.Text) + int.Parse(NewQtytextBox.Text)).ToString();
            }
            else
            {
                TotalQtytextBox.Text = PrevQtytextBox.Text;
            }
        }

        private void finish_button_Click(object sender, EventArgs e)
        {
            string sql =
                        "update PO_master set po_amount=@pn, po_paid=@pt, po_payable=@ps,po_remarks=@re ,flag='1'  where po_number='" +
                        POtextBox.Text + "' ";
            _con.Open();
            SqlCommand command = new SqlCommand(sql, _con);
            command.Parameters.AddWithValue("@pn", AmounttextBox.Text);
            command.Parameters.AddWithValue("@pt", paidtextBox.Text);
            command.Parameters.AddWithValue("@ps", payabletextBox.Text);
            command.Parameters.AddWithValue("@re", RemarkstextBox.Text);
            command.ExecuteNonQuery();
            _con.Close();
            //master_part = 0;
            //Po_number_generate();
            Masterclear();
            Purchasegrid();
            Clear();
        }
        private void Masterclear()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            suppliertextBox.Text = "";
            SupplierCompnytextBox.Text = "";
            SupplierIdtextBox.Text = "";
            Bill_no_textBox.Text = "";
            AmounttextBox.Text = "";
            paidtextBox.Text = "";
            payabletextBox.Text = "";


        }
        private void Clear()
        {
            itmcodetextBox.Text = "";
            itemdesctextBox.Text = "";
            ItemRatetextBox.Text = "";
            NewQtytextBox.Text = "";
            PrevQtytextBox.Text = "";
            TotalQtytextBox.Text = "";
            totaltextBox.Text = "";
        }

        private void POtextBox_TextChanged(object sender, EventArgs e)
        {
            if (POtextBox.Text=="")
            {
                Clear();
                Masterclear();
                Purchasegrid();
            }
        }

        private void suppliertextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProfileForm spfm = new SearchProfileForm();
                spfm.ShowDialog();
                //prlabel.Text = srfm.Sscode;
                suppliertextBox.Text = spfm.Ssname;
                SupplierIdtextBox.Text = spfm.Sscode;
                SupplierCompnytextBox.Text = spfm.Scompany;
                itmcodetextBox.Focus();
            }
            if (e.KeyCode == Keys.Tab)
            {
                itmcodetextBox.Focus();
            }
        }

        private void itmcodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (suppliertextBox.Text != "")
                {


                    searchrecordfm srfm = new searchrecordfm();
                    srfm.ShowDialog();
                    Clear();
                    itmcodetextBox.Text = srfm.Sscode;
                    itemdesctextBox.Text = srfm.Ssname + "-" + srfm.Sstype + "-" + srfm.Sssize + "-" + srfm.Ssdetail;
                    ItemRatetextBox.Text = srfm.Ssprice;
                    NewQtytextBox.Focus();
                    finish_button.Enabled = false;
                }
                if (e.KeyCode == Keys.Tab)
                {
                    NewQtytextBox.Focus();
                }
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            //if (NewQtytextBox.Text != "" && suppliertextBox.Text != "")
            //{
            //    try
            //    {
            //        if (master_part == 0)
            //        {


            //            Resultradiobutton = messradioButton.Checked ? 1 : 0;

            //            DateTime dt = DateTime.Now;
            //            string sql2 = null;
            //            sql2 =
            //                "INSERT INTO PO_master (supplier_bill_no,Pro_code ,po_number,p_TuckMess,po_datetime) VALUES ('" +
            //                Bill_no_textBox.Text + "','" + SupplierIdtextBox.Text + "','" + logid + "','" +
            //                Resultradiobutton + "','" + dt + "')";
            //            _con.Open();
            //            cmd2 = new SqlCommand(sql2, _con);
            //            var dataReader = cmd2.ExecuteReader();
            //            dataReader.Close();
            //            cmd2.Dispose();
            //            groupBox1.Enabled = false;
            //            groupBox2.Enabled = false;
            //            _con.Close();
            //            master_part = 1;
            //        }


            //        //detail part
            //        string sql1 = null;
            //        sql1 = "INSERT INTO PO_detail (po_number,p_code,po_rate,po_qty,po_itemsum) VALUES ('" + logid +
            //               "','" + itmcodetextBox.Text + "','" + ItemRatetextBox.Text + "','" + NewQtytextBox.Text +
            //               "','" + totaltextBox.Text + "')";
            //        _con.Open();
            //        var command1 = new SqlCommand(sql1, _con);
            //        var dataReader1 = command1.ExecuteReader();
            //        dataReader1.Close();
            //        command1.Dispose();
            //        _con.Close();
            //        Purchasegrid();
            //        Sumcal();
            //        Clear();
            //        //update
            //        string sql =
            //            "update PO_master set po_amount=@pn, po_paid=@pt, po_payable=@ps,po_remarks=@re  where po_number='" +
            //            logid + "' ";
            //        _con.Open();
            //        SqlCommand command = new SqlCommand(sql, _con);
            //        command.Parameters.AddWithValue("@pn", AmounttextBox.Text);
            //        command.Parameters.AddWithValue("@pt", paidtextBox.Text);
            //        command.Parameters.AddWithValue("@ps", payabletextBox.Text);
            //        command.Parameters.AddWithValue("@re", RemarkstextBox.Text);
            //        command.ExecuteNonQuery();
            //        _con.Close();
            //        //MessageBox.Show("Record Update.");
            //        Clear();
            //        itmcodetextBox.Focus();
            //        finish_button.Enabled = true;
            //    }
            //    catch (Exception ds)
            //    {

            //        MessageBox.Show("Error On Save Command:" + ds);
            //    }
            //}
        }

        private void SupplierCompnytextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
