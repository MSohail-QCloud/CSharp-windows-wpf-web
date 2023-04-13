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

namespace abcstore.Forms
{
    public partial class PurchaseOrderForm : Form
    {
        readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public int Resultradiobutton { get; set; }
        int logid = 0;
        SqlCommand cmd2;
        int master_part;

        public PurchaseOrderForm()
        {
            InitializeComponent();
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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

        private void ItemRatetextBox_TextChanged(object sender, EventArgs e)
        {
            if (itmcodetextBox.Text != "")
            {


                string query = ("select quantity from store_stock where p_code='" + itmcodetextBox.Text + "'");
                SqlCommand cmd = new SqlCommand(query, _con);
                try
                {
                    _con.Open();
                    var dbr1 = cmd.ExecuteReader();
                    while (dbr1.Read())
                    {

                        int mch = (int) dbr1["quantity"];
                        PrevQtytextBox.Text = mch.ToString();

                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                finally
                {
                    _con.Close();

                }
            }
        }

        private void NewQtytextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemRatetextBox.Text != "" && PrevQtytextBox.Text != "")
            {
                if (NewQtytextBox.Text != "")
                {
                    int sum = int.Parse(NewQtytextBox.Text) + int.Parse(PrevQtytextBox.Text);
                    TotalQtytextBox.Text = sum.ToString();
                    int mul = int.Parse(NewQtytextBox.Text)*int.Parse(ItemRatetextBox.Text);
                    totaltextBox.Text = mul.ToString();
                }
                else
                {
                    TotalQtytextBox.Text = "";
                    totaltextBox.Text = "";
                }
            }

        }

        private void Po_number_generate()
        {
            //po number generate
            string q = " select top(1) po_number from PO_master order by po_number desc";
            SqlCommand cmdd = new SqlCommand(q, _con);
            _con.Open();
            var dbr = cmdd.ExecuteReader();
            while (dbr.Read())
            {

                int log = (int)dbr["po_number"];
                logid = log + 1;
                POlabel.Text = "PO#" + logid.ToString();
                //label17.Text = "Transaction ID:" + log;

            }
            dbr.Close();
            _con.Close();
            //finish_button.Enabled = false;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            if (Resultradiobutton == 0)
            {
                tukshopradioButton.Checked = true;
            }
            else
            {
                messradioButton.Checked = true;
            }
            Po_number_generate();
            master_part = 0;
        }

        private void itmcodetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (NewQtytextBox.Text != "" && suppliertextBox.Text != "")
            {
                try
                {
                    if (master_part == 0)
                    {


                        Resultradiobutton = messradioButton.Checked ? 1 : 0;

                        DateTime dt = DateTime.Now;
                        string sql2 = null;
                        sql2 =
                            "INSERT INTO PO_master (supplier_bill_no,Pro_code ,po_number,p_TuckMess,po_datetime) VALUES ('" +
                            Bill_no_textBox.Text + "','" + SupplierIdtextBox.Text + "','" + logid + "','" +
                            Resultradiobutton + "','" + dt + "')";
                        _con.Open();
                        cmd2 = new SqlCommand(sql2, _con);
                        var dataReader = cmd2.ExecuteReader();
                        dataReader.Close();
                        cmd2.Dispose();
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        _con.Close();
                        master_part = 1;
                    }


                    //detail part
                    string sql1 = null;
                    sql1 = "INSERT INTO PO_detail (po_number,p_code,po_rate,po_qty,po_itemsum) VALUES ('" + logid +
                           "','" + itmcodetextBox.Text + "','" + ItemRatetextBox.Text + "','" + NewQtytextBox.Text +
                           "','" + totaltextBox.Text + "')";
                    _con.Open();
                    var command1 = new SqlCommand(sql1, _con);
                    var dataReader1 = command1.ExecuteReader();
                    dataReader1.Close();
                    command1.Dispose();
                    _con.Close();
                    Purchasegrid();
                    Sumcal();
                    Clear();
                    //update
                    string sql =
                        "update PO_master set po_amount=@pn, po_paid=@pt, po_payable=@ps,po_remarks=@re  where po_number='" +
                        logid + "' ";
                    _con.Open();
                    SqlCommand command = new SqlCommand(sql, _con);
                    command.Parameters.AddWithValue("@pn", AmounttextBox.Text);
                    command.Parameters.AddWithValue("@pt", paidtextBox.Text);
                    command.Parameters.AddWithValue("@ps", payabletextBox.Text);
                    command.Parameters.AddWithValue("@re", RemarkstextBox.Text);
                    command.ExecuteNonQuery();
                    _con.Close();
                    //MessageBox.Show("Record Update.");
                    Clear();
                    itmcodetextBox.Focus();
                    finish_button.Enabled = true;
                }
                catch (Exception ds)
                {

                    MessageBox.Show("Error On Save Command:" + ds);
                }
             }
        }

        private void Clear()
        {
            itmcodetextBox.Text = "";
            itemdesctextBox.Text = "";
            ItemRatetextBox.Text = "";
            NewQtytextBox.Text ="";
            PrevQtytextBox.Text = "";
            TotalQtytextBox.Text = "";
            totaltextBox.Text = "";
        }
        private void Sumcal()
        {
            int sum = 0;
            for (int i = 0; i < purchasedataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(purchasedataGridView.Rows[i].Cells[5].Value);
            }
            AmounttextBox.Text = sum.ToString();
        }

        private void Purchasegrid()
        {

            var str = "select p.p_code, p.p_name,p.p_size,pd.po_rate,pd.po_qty,pd.po_itemsum from store_product p right join PO_detail pd on  p.p_code=pd.p_code where po_number= '" + logid + "'";
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
        private void messradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewQtytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Bill_no_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ItemRatetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void finish_button_Click(object sender, EventArgs e)
        {
            string sql =
                        "update PO_master set po_amount=@pn, po_paid=@pt, po_payable=@ps,po_remarks=@re ,flag='1'  where po_number='" +
                        logid + "' ";
            _con.Open();
            SqlCommand command = new SqlCommand(sql, _con);
            command.Parameters.AddWithValue("@pn", AmounttextBox.Text);
            command.Parameters.AddWithValue("@pt", paidtextBox.Text);
            command.Parameters.AddWithValue("@ps", payabletextBox.Text);
            command.Parameters.AddWithValue("@re", RemarkstextBox.Text);
            command.ExecuteNonQuery();
            _con.Close();
            master_part = 0;
            Po_number_generate();
            Masterclear();
            Purchasegrid();
            Clear();
        }

        private void Masterclear()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            suppliertextBox.Text="";
            SupplierCompnytextBox.Text = "";
            SupplierIdtextBox.Text = "";
            Bill_no_textBox.Text = "";
            AmounttextBox.Text = "";
            paidtextBox.Text = "";
            payabletextBox.Text = "";


        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AmounttextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SupplierIdtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SupplierCompnytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bill_no_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemdesctextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrevQtytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalQtytextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void totaltextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void suppliertextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void paidtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void payabletextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RemarkstextBox_TextChanged(object sender, EventArgs e)
        {

        }
        }
    }
