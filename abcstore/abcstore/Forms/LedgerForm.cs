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
    public partial class LedgerForm : Form
    {
        readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand cmdd;
        string q;
        int remaining = 0;
        string ponumber ;

        public LedgerForm()
        {
            InitializeComponent();
        }

        private void clear()
        {
            ProfileCodetextBox.Text = "";
            nametextBox.Text = "";
            fnametextbox.Text = "";
            mbileno1textbox.Text = "";
            companyNametextbox.Text = "";
            emailidtextbox.Text = "";
            citytextbox.Text = "";
            countrytextbox.Text = "";
            TAMtextBox.Text = "";
            PaidtextBox.Text = "";
            CashaddtextBox.Text = "";
            RemainingtextBox.Text = "";
            Ledgergrid();


        }

        private void ProfileCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ProfileCodetextBox.Text != "")
                {
                    //po number generate
                    q =
                        " select Pro_code,Pro_name,pro_fname,pro_mno1,pro_companyname,pro_email,pro_city,pro_cv from Profile where Pro_code= '" +
                        ProfileCodetextBox.Text + "' ";
                    cmdd = new SqlCommand(q, _con);
                    _con.Open();
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {

                        ProfileCodetextBox.Text = dbr["Pro_code"].ToString();
                        nametextBox.Text = (string) dbr["Pro_name"];
                        fnametextbox.Text = (string) dbr["pro_fname"];
                        mbileno1textbox.Text = (string) dbr["pro_mno1"];
                        companyNametextbox.Text = (string) dbr["pro_companyname"];
                        emailidtextbox.Text = (string) dbr["pro_email"];
                        citytextbox.Text = (string) dbr["pro_city"];
                        int customVend = (int) dbr["pro_cv"];

                        profileTypelabel.Text = customVend == 1 ? "Customer" : "Vender";

                    }
                    _con.Close();
                    dbr.Close();
                    Ledgergrid();
                }

            }
        }

        private void Ledgergrid()
        {

            var str =
                "select po_number,po_datetime,po_amount,po_paid,po_payable from PO_master where flag=1 and close_active = 1 order by po_number desc";
            var com = new SqlCommand(str, _con);
            var ada = new SqlDataAdapter(com);
            var ds = new DataSet();
            ada.Fill(ds, "b_payableam");
            ledgerdataGridView.DataMember = "b_payableam";
            ledgerdataGridView.DataSource = ds;
            ledgerdataGridView.Columns[0].HeaderCell.Value = "P O Number";
            ledgerdataGridView.Columns[1].HeaderCell.Value = "Date";
            ledgerdataGridView.Columns[2].HeaderCell.Value = "Total Amount";
            ledgerdataGridView.Columns[3].HeaderCell.Value = "Paid";
            ledgerdataGridView.Columns[4].HeaderCell.Value = "Remaining Balance";
        }

        private void LedgerForm_Load(object sender, EventArgs e)
        {

        }

        private void ledgerdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                CashaddtextBox.Text = "";
                ClosePOcheckBox.Checked = false;
                ponumber = ledgerdataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                TAMtextBox.Text = ledgerdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                PaidtextBox.Text = ledgerdataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                RemainingtextBox.Text = ledgerdataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void CashaddtextBox_TextChanged(object sender, EventArgs e)
        {
            if (TAMtextBox.Text != "")
            {
                if (CashaddtextBox.Text == "")
                {

                }
                else
                {


                    remaining = int.Parse(TAMtextBox.Text) -
                                ((int.Parse(PaidtextBox.Text) + (int.Parse(CashaddtextBox.Text))));
                    RemainingtextBox.Text = remaining.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (remaining < 0)
            {
                MessageBox.Show("Paid Amount Exceed. Check Amount.");
            }
            else
            {
                var totalrecievamount = int.Parse(PaidtextBox.Text) + int.Parse(CashaddtextBox.Text);
                var closepovar = ClosePOcheckBox.Checked ? 0 : 1;
                string sql =
                    "update PO_master set po_paid=@pn, po_payable=@pt,close_active=@re  where po_number='" +
                    ponumber + "' ";
                _con.Open();
                SqlCommand command = new SqlCommand(sql, _con);
                command.Parameters.AddWithValue("@pn", totalrecievamount);
                command.Parameters.AddWithValue("@pt", RemainingtextBox.Text);
                command.Parameters.AddWithValue("@re", closepovar);
                command.ExecuteNonQuery();
                _con.Close();
                Ledgergrid();
                
            }
        }

        private void nametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ProfileCodetextBox.Text != "")
                {
                    clear();
                    SearchProfileForm srfm = new SearchProfileForm ();
                    srfm.ShowDialog();
                    ProfileCodetextBox.Text = srfm.Sscode;
                    nametextBox.Focus();
                }
                ProfileCodetextBox_KeyDown(sender, e);

            }
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProfileCodetextBox_TextChanged(object sender, EventArgs e)
        {
            clear();
        }
    }
}
