using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using abcstore.Forms;

namespace abcstore
{
    public partial class Invoiceform : Form
    {
        readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        
        int Rateproduct = 0;
        int invoice_number = 0;
        public int customertype { get; set; }
        int invoice_upper_part=0;
        public int resultradiobutton { get; set; }
        public int OpenInvoicefm { get; set; }
        int openInvoice_itemcode=0;
        
        public Invoiceform()
        {
            InitializeComponent();
        }

        public string Username { get; set; }

        private void Invoiceform_Load(object sender, EventArgs e)
        {
           
            if (resultradiobutton==0)
            {
                if (OpenInvoicefm != 1)
                {
                    invoice_generate();
                    custIdtextBox.Focus();
                    messradioButton.Checked = true;
                }
            }
            if (resultradiobutton==1)
            {
                invoice_generate();
                custIdtextBox.Focus();
                tukshopradioButton.Checked = true;
            }
            if (resultradiobutton==2)
            {
                invoice_generate();
                custIdtextBox.Focus();
                messradioButton.Visible = false;
                tukshopradioButton.Visible = false;
                GuestradioButton.Visible=true;
                GuestradioButton.Checked = true;
                tukshopradioButton.Hide();
                label1.Text = "Guest Invoice";
                label10.Text = "Depart:";
                label8.Text = "Person Name:";
                label5.Text = "Person/Qty";
                namelabel.Text = "Menue Description:";
                label2.Text = "Menue code:";
                label4.Text = "Rate/Menue:";
                label20.Text = "Bill:";
                
            }
            //for open invoice
            if (OpenInvoicefm == 1)
            {
                openInvoiceNumtextBox.Visible = true;
                datetimelabel.Visible = true;
                //buybutton.Text = "Update";
                Invoicelabel.Visible = false;
                OpenInvoicelabel.Visible = true;
                openInvoiceNumtextBox.Focus();
                groupBox1.Enabled = false;
            }
        }

        private void nametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectbtn("buy");
                searchrecordfm srfm = new searchrecordfm();
                srfm.ShowDialog();
                ItemCodetextBox.Text = srfm.Sscode;
                desctextBox.Text = srfm.Ssname+"-"+srfm.Sstype+"-"+srfm.Sssize+"-"+srfm.Ssdetail;
                pricetextBox.Text = srfm.Ssprice;
                QtytextBox.Focus();
            }
            if (e.KeyCode == Keys.Tab)
            {
                PaidtextBox.Focus();
            }
        }

        private void QtytextBox_TextChanged(object sender, EventArgs e)
        {
            if (pricetextBox.Text != "" && QtytextBox.Text != "")
            {
                var pric = int.Parse(pricetextBox.Text);
                var quantity = int.Parse(QtytextBox.Text);
                var total = pric * quantity;
                payabletextBox.Text = total.ToString();
            }
            else
            {
                payabletextBox.Text = "";
            }
        }

        private void pricetextBox_TextChanged(object sender, EventArgs e)
        {
            if (QtytextBox.Text != "" && pricetextBox.Text != "")
            {
                var pric = int.Parse(pricetextBox.Text);
                var quantity = int.Parse(QtytextBox.Text);
                var total = pric * quantity;
                payabletextBox.Text = total.ToString();
            }
            else
            {
                payabletextBox.Text = "";
            }
            
        }

        private void QtytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void QtytextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buybutton_Click(sender, e);
                //buybutton.Focus();
            }

        }

        private void invoice_generate()
        {
            if (Invoicelabel.Text == "Invoice #")
            {
                string q = (" select top(1)invoice_number from invoice_master order by invoice_number desc");
                SqlCommand cmdd = new SqlCommand(q, _con);
                _con.Open();
                var dbr = cmdd.ExecuteReader();
                while (dbr.Read())
                {

                    invoice_number = (int)dbr["invoice_number"] +1;
                    Invoicelabel.Text = "Invoice #" + invoice_number.ToString();

                }
                _con.Close();
            }
        }

        private void buybutton_Click(object sender, EventArgs e)
        {
            if (QtytextBox.Text != "" && ItemCodetextBox.Text != "")
            {
                if (invoice_upper_part==0 && OpenInvoicefm != 1)
                {
                    int resultradiobuton = messradioButton.Checked ? 1 : 0;
                    DateTime dt=DateTime.Now;
                    string sql = null;
                    
                        sql = "insert into invoice_master (invoice_number,Pro_code,invoice_datetime,invoice_amount,invoice_paid,invoice_remaining,p_TuckMess) values ('" + invoice_number + "','" +
                              custIdtextBox.Text +
                              "','" + dt + "','" + AmounttextBox.Text + "','" + PaidtextBox.Text + "','" + RemainingtextBox.Text + "','" + resultradiobuton + "')";
                        _con.Open();
                        var command = new SqlCommand(sql, _con);
                        var dataReader = command.ExecuteReader();
                        dataReader.Close();
                        command.Dispose(); 
                    _con.Close();
                    
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    invoice_upper_part = 1;
                }

                string sql1 = null;
                
                       sql1 = "insert into invoice_detail( invoice_number,p_code,invoice_detail_qty,invoice_detail_rate,invoice_detail_payable)values ('" + invoice_number + "','" +
                      ItemCodetextBox.Text +
                      "','" + QtytextBox.Text + "','" + pricetextBox.Text + "','" + payabletextBox.Text + "')";
                    _con.Open();
                    var command1 = new SqlCommand(sql1, _con);
                    var dataReader1 = command1.ExecuteReader();
                    dataReader1.Close();
                    command1.Dispose();
               
                
                _con.Close();
               
                Invoicegrid();
                Sumcal();
                Clear();
                ItemCodetextBox.Focus();
              
                string sql2 =
                        "update invoice_master set invoice_amount=@pn,invoice_paid=@pt,invoice_remaining=@ps, flag='0' where invoice_number='" +
                        invoice_number + "' ";
                _con.Open();
                SqlCommand command2 = new SqlCommand(sql2, _con);
                command2.Parameters.AddWithValue("@pn", AmounttextBox.Text);
                command2.Parameters.AddWithValue("@pt", PaidtextBox.Text);
                command2.Parameters.AddWithValue("@ps", RemainingtextBox.Text);
                command2.ExecuteNonQuery();
                _con.Close();
                
            }


            else
            {
                MessageBox.Show("Fill complete records");
                ItemCodetextBox.Focus();
            }

        }

        public void InvoiceClear()
        {
            Invoicelabel.Text = "Invoice #";
            PaidtextBox.Text = "";
            RemainingtextBox.Text = "";
            AmounttextBox.Text = "";
            suppliertextBox.Text = "";
            SupplierCompnytextBox.Text = "";
            custIdtextBox.Text = "";

        }

        public void Clear()
        {
            ItemCodetextBox.Text = "";
            desctextBox.Text = "";
            pricetextBox.Text = "";
            QtytextBox.Text = "";
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (AmounttextBox.Text != "" && PaidtextBox.Text != "")
            {
                var amount = int.Parse(AmounttextBox.Text);
                var paid = int.Parse(PaidtextBox.Text);
                var remaining = paid - amount;
                RemainingtextBox.Text = remaining.ToString();
            }
            else
            {
                RemainingtextBox.Text = "";
            }
        }

        private void Invoicegrid()
        {

            var str = "select p.p_code, p.p_name,p.p_size,invD.invoice_detail_rate,invD.invoice_detail_qty,invD.invoice_detail_payable  from store_product p right join invoice_detail invD on  p.p_code=invD.p_code where invD.invoice_number= '" + invoice_number + "'";
            var com = new SqlCommand(str, _con);
            var ada = new SqlDataAdapter(com);
            var ds = new DataSet();
            ada.Fill(ds, "b_payableam");
            invoicedataGridView.DataMember = "b_payableam";
            invoicedataGridView.DataSource = ds;
            invoicedataGridView.Columns[0].HeaderCell.Value = "Item Code";
            invoicedataGridView.Columns[1].HeaderCell.Value = "Item Name";
            invoicedataGridView.Columns[2].HeaderCell.Value = "Item Size";
            invoicedataGridView.Columns[3].HeaderCell.Value = "Item Rate";
            invoicedataGridView.Columns[4].HeaderCell.Value = "Quantity";
            invoicedataGridView.Columns[5].HeaderCell.Value = "Payable";
        }

        private void invoicedataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                ItemCodetextBox.Text = invoicedataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                openInvoice_itemcode = int.Parse(invoicedataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                desctextBox.Text = invoicedataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() +"-"
                    + invoicedataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                pricetextBox.Text = invoicedataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                QtytextBox.Text = invoicedataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                payabletextBox.Text = invoicedataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();

                selectbtn("update");
                //buybutton.Visible = false;
                //updatebutton.Visible = true;

            }

        }
        private void Sumcal()
        {
            int sum = 0;
            for (int i = 0; i < invoicedataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(invoicedataGridView.Rows[i].Cells[5].Value);
            }
            AmounttextBox.Text = sum.ToString();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                savprintbutton.Focus();
            }
        }

        private void savprintbutton_Click(object sender, EventArgs e)
        {
            if (PaidtextBox.Text != "")
            {

                string sql =
                    "update invoice_master set invoice_amount=@pn, invoice_paid=@pt, invoice_remaining=@ps, flag='1'  where invoice_number='" +
                    invoice_number + "' ";
                _con.Open();
                SqlCommand command = new SqlCommand(sql, _con);
                command.Parameters.AddWithValue("@pn", AmounttextBox.Text);
                command.Parameters.AddWithValue("@pt", PaidtextBox.Text);
                command.Parameters.AddWithValue("@ps", payabletextBox.Text);
                command.ExecuteNonQuery();
                _con.Close();
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                invoice_upper_part = 0;
                InvoiceClear();
                Clear();
                custIdtextBox.Focus();
                if (OpenInvoicefm == 1)
                {
                    openInvoiceNumtextBox.Text = "";
                }
                else
                {
                    invoice_generate();
                }
            }
            else
            {
                MessageBox.Show("Enter Paid amount. If not press '0'.");
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Clear();
            desctextBox.Focus();

        }

        private void ItemCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int resultradiobution = messradioButton.Checked ? 1 : 0;
                if (ItemCodetextBox.Text != "")
                {
                    string q =
                        " select p_name,p_type,p_size,p_price, p_detail from store_product where p_TuckMess='" + resultradiobution + "' and p_code='" +
                        ItemCodetextBox.Text + "'";
                    SqlCommand cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {
                        desctextBox.Text = (string)dbr["p_name"] + "-" + (string)dbr["p_size"] + "-" + (string)dbr["p_type"] + "-" +
                                           (string) dbr["p_detail"];
                        Rateproduct = (int) dbr["p_price"];
                        pricetextBox.Text = Rateproduct.ToString();
                    }
                    dbr.Close();
                    _con.Close();
                    QtytextBox.Focus();
                }
            }
        }

        private void SupplierIdtextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                
                if (custIdtextBox.Text != "")
                {
                    string q =
                        " select Pro_name,pro_companyname from Profile where pro_cv=1 and  Pro_code='"+custIdtextBox.Text+"' ";
                    SqlCommand cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {
                        suppliertextBox.Text = (string)dbr["Pro_name"];
                        SupplierCompnytextBox.Text = (string)dbr["pro_companyname"];
                        pricetextBox.Text = Rateproduct.ToString();
                    }
                    dbr.Close();
                    _con.Close();
                    ItemCodetextBox.Focus();
                }
            }
        }

        private void suppliertextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProfileForm srfm = new SearchProfileForm {cutom_vender = 1};
                srfm.ShowDialog();
                suppliertextBox.Text = srfm.Ssname;
                custIdtextBox.Text = srfm.Sscode;
                SupplierCompnytextBox.Text = srfm.Scompany;
                ItemCodetextBox.Focus();
            }
            if (e.KeyCode == Keys.Tab)
            {
                desctextBox.Focus();
            }
        }

        private void maingroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void openInvoiceNumtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                invoice_number = int.Parse(openInvoiceNumtextBox.Text);
                Invoicegrid();
                

                if (openInvoiceNumtextBox.Text != "")
                {
                    string q =
                        " select Pro_code,invoice_datetime,invoice_amount,invoice_paid,invoice_remaining,p_TuckMess,flag from invoice_master where invoice_number='" + openInvoiceNumtextBox.Text + "' ";
                    SqlCommand cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {
                        custIdtextBox.Text = (string)dbr["Pro_code"].ToString();
                       DateTime dt = (DateTime)dbr["invoice_datetime"];
                        datetimelabel.Text = dt.ToString();
                        int invoiceAm = (int)dbr["invoice_amount"];
                        AmounttextBox.Text = invoiceAm.ToString();
                        int invoicepaid = (int)dbr["invoice_paid"];
                        PaidtextBox.Text = invoicepaid.ToString();
                        int invoiceremain = (int)dbr["invoice_remaining"];
                        RemainingtextBox.Text = invoiceremain.ToString();
                        resultradiobutton = (int)dbr["p_TuckMess"];
                     }
                    dbr.Close();
                    _con.Close();
                    SupplierIdtextBox_KeyDown(sender, e);
                    radiobuttonfunc();
                    ItemCodetextBox.Focus();
                }

            }

        }
        

        private void radiobuttonfunc()
        {
            if (resultradiobutton == 1)
            {
                messradioButton.Checked = true;
            }
            if (resultradiobutton == 0)
            {
                tukshopradioButton.Checked = true;
            }
            if (resultradiobutton == 2)
            {
                messradioButton.Visible = false;
                tukshopradioButton.Visible = false;
                GuestradioButton.Visible = true;
                GuestradioButton.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            
                {
                        int resultradiobuton = messradioButton.Checked ? 1 : 0;
                        DateTime dt=DateTime.Now;
                        string sql = null;
                   
                        sql = "update invoice_master set Pro_code=@pc,invoice_datetime='" + dt + "', invoice_amount=@iam,invoice_paid=@ip,invoice_remaining=@ir,p_TuckMess='" + resultradiobuton + "' where invoice_number='" + invoice_number + "' ";
                        _con.Open();
                        SqlCommand command = new SqlCommand(sql, _con);
                        command.Parameters.AddWithValue("@pc", custIdtextBox.Text);
                        command.Parameters.AddWithValue("@iam", AmounttextBox.Text);
                        command.Parameters.AddWithValue("@ip", PaidtextBox.Text);
                        command.Parameters.AddWithValue("@ir", RemainingtextBox.Text);
                        command.ExecuteNonQuery();
                        _con.Close();
                    
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        invoice_upper_part = 1;
                }

                    string sql1 = null;
                    sql1 = "update invoice_detail set p_code=@pc, invoice_detail_qty=@iam,invoice_detail_rate=@ip,invoice_detail_payable=@ir where invoice_number='" + invoice_number + "' and p_code='" + ItemCodetextBox.Text + "' ";
                    _con.Open();
                    SqlCommand command1 = new SqlCommand(sql1, _con);
                    command1.Parameters.AddWithValue("@pc", ItemCodetextBox.Text);
                    command1.Parameters.AddWithValue("@iam", QtytextBox.Text);
                    command1.Parameters.AddWithValue("@ip", pricetextBox.Text);
                    command1.Parameters.AddWithValue("@ir", payabletextBox.Text);
                    command1.ExecuteNonQuery();
                    _con.Close();
                    Invoicegrid();
                    Sumcal();
                    Clear();
                    ItemCodetextBox.Focus();
                //update part
                string sql2 =
                        "update invoice_master set invoice_amount=@pn,invoice_paid=@pt,invoice_remaining=@ps, flag='0' where invoice_number='" +
                        invoice_number + "' ";
                _con.Open();
                SqlCommand command2 = new SqlCommand(sql2, _con);
                command2.Parameters.AddWithValue("@pn", AmounttextBox.Text);
                command2.Parameters.AddWithValue("@pt", PaidtextBox.Text);
                command2.Parameters.AddWithValue("@ps", RemainingtextBox.Text);
                command2.ExecuteNonQuery();
                _con.Close();
                selectbtn( "buy");
                //updatebutton.Visible = false;
                //buybutton.Visible = true;
                
            }
            private void selectbtn(string btn)
            {
            if (btn == "update")
            {
                buybutton.Visible = false;
                updatebutton.Visible = true;

            }
            if (btn == "buy")
            {
                updatebutton.Visible = false;
                buybutton.Visible = true;
            }
        }

            private void ItemCodetextBox_TextChanged(object sender, EventArgs e)
            {
                selectbtn("buy");
            }

     }
}

