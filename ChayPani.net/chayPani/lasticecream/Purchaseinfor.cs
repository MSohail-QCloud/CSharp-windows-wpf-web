using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lasticecream
{
    public partial class Purchaseinfor : Form
    {
        private static Purchaseinfor alreadyOpened = null;

        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        DataTable dt_bill = new DataTable();
        //DataRow dr_billgrid;
        OleDbDataReader dr;
        //int indexbill = 0;
        int purchasenumber = 0;
        public Purchaseinfor()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;

            InitializeComponent();
        }

        private void Purchaseinfor_Load(object sender, EventArgs e)
        {

            createpurchaseordernumber();
            txt_partyname.Focus();
            this.WindowState = FormWindowState.Maximized;
            
            
        }

       
        private void createpurchaseordernumber()
        {
            olecon.Open();
            string query = "select top 1 POnumber  from PurchaseOrders order by POnumber desc";
            OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                purchasenumber = int.Parse(dr.GetValue(0).ToString());
                purchasenumber = purchasenumber + 1;
                dr.Close();
                txt_ponumber.Text = purchasenumber.ToString();

            }
            else
            {
                purchasenumber = 1;
                txt_ponumber.Text = purchasenumber.ToString();
                dr.Close();
            }
            olecon.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_saveprint_Click(object sender, EventArgs e)
        {
            if (txt_ponumber.Text != "" && txt_partyname.Text != "" && txt_itemnaem.Text != "" && txt_ratesingle.Text != "" && txt_qty.Text != "" && txt_totalprice.Text != "")
            {
                //SqlDataReader dbr;
                try
                {
                   String query = "insert into PurchaseOrders (POnumber,partyname,podatetime,itemname,pricesingle,itemqty,totalprice) values ('" + this.txt_ponumber.Text + "','" + this.txt_partyname.Text + "','" + DateTime.Now + "','" + this.txt_itemnaem.Text + "','" + this.txt_ratesingle.Text + "','" + this.txt_qty.Text+ "','" + this.txt_totalprice.Text + "')";
                    olecon.Open();
                    OleDbCommand cmd = new OleDbCommand(query, olecon);
                    cmd.ExecuteNonQuery();
                    olecon.Close();
                    
                    txt_itemnaem.Text = "";
                    txt_ratesingle.Text = "";
                    txt_qty.Text = "";
                    txt_totalprice.Text = "";
                    txt_itemnaem.Focus();
                    showpodetail(int.Parse(txt_ponumber.Text));
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("تمام ریکارڈز مکمل کریں۔");
            }
        }

        private void btn_newPO_Click(object sender, EventArgs e)
        {
            createpurchaseordernumber();
            txt_partyname.Text = "";
            txt_itemnaem.Text = "";
            txt_ratesingle.Text = "";
            txt_qty.Text = "";
            txt_totalprice.Text = "";
            txt_partyname.Focus();
           
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text != "" && txt_ratesingle.Text != "")
            {
                int rate = int.Parse(txt_ratesingle.Text);
                int qty = int.Parse(txt_qty.Text);
                txt_totalprice.Text = (rate * qty).ToString();
            }
        }

        private void grid_listpos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
       
        private void showpodetail(int ponumb)
        {
            olecon.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter("SELECT * from PurchaseOrders  where POnumber="+ponumb+ " order by POnumber desc  ;", olecon);
            oleadapt.Fill(dt);
            olecon.Close();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    grid_po.DataSource = dt;
                    txt_srchPO.Text = dt.Rows[0]["POnumber"].ToString();
                    txt_srchName.Text = dt.Rows[0]["partyname"].ToString();
                    lbl_datePo.Text = dt.Rows[0]["podatetime"].ToString();
                    grid_po.Columns["POid"].Visible = false;
                    grid_po.Columns["POnumber"].Visible = false;
                    grid_po.Columns["partyname"].Visible = false;
                    grid_po.Columns["podatetime"].Visible = false;
                    grid_po.Columns[4].HeaderText = "آئٹم نام";
                    grid_po.Columns[5].HeaderText = "ریٹ";
                    grid_po.Columns[6].HeaderText = "تعداد";
                    grid_po.Columns[7].HeaderText = "کل قیمت";
                    grid_po.Columns[5].Width = 40;
                    grid_po.Columns[6].Width = 40;
                    grid_po.Columns[7].Width = 40;
                    //txt_forSrchPO.Text = "";

                }
                else
                {
                    dt.Clear();
                    lbl_datePo.Text = "";
                    txt_srchPO.Text = "";
                    txt_srchName.Text = "";
                    grid_po.DataSource = null;
                    grid_po.Refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_ratesingle_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_totalprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_ponumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {

                if (lbl_poid.Text != ".")
                {
                    OleDbCommand olcmd = new OleDbCommand("delete * from PurchaseOrders where POid=@id ", olecon);
                    olecon.Open();
                    olcmd.Parameters.AddWithValue("@id", lbl_poid.Text);
                    olcmd.ExecuteNonQuery();
                    String query = "insert into PurchaseOrders (POnumber,partyname,podatetime,itemname,pricesingle,itemqty,totalprice) values ('" + this.txt_ponumber.Text + "','" + this.txt_partyname.Text + "','" + DateTime.Now.ToString("dd-MMM-yy") + "','" + this.txt_itemnaem.Text + "','" + this.txt_ratesingle.Text + "','" + this.txt_qty.Text + "','" + this.txt_totalprice.Text + "')";
                    
                    OleDbCommand cmd = new OleDbCommand(query, olecon);
                    cmd.ExecuteNonQuery();
                    olecon.Close();
                    showpodetail(int.Parse(txt_ponumber.Text));
                }
                else
                {
                    MessageBox.Show("تبدیل کرنےکیلئے ریکارڈ سیلیکٹ کریں۔");
                }


            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                olecon.Close();
            }
        }

        private void clear()
        {
            txt_totalprice.Text = "";
            txt_partyname.Text = "";
            txt_itemnaem.Text = "";
            txt_ratesingle.Text = "";
            txt_qty.Text = "";
            //txt_ponumber.Text = "";
            lbl_poid.Text = ".";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void grid_po_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_partyname.Text = grid_po.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_itemnaem.Text = grid_po.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_ratesingle.Text = grid_po.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_qty.Text = grid_po.Rows[e.RowIndex].Cells[6].Value.ToString();
            txt_totalprice.Text = grid_po.Rows[e.RowIndex].Cells[7].Value.ToString();
            lbl_poid.Visible = true;
            lbl_poid.Text = grid_po.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ponumber.Text = grid_po.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (lbl_poid.Text != ".")
                {
                    OleDbCommand olcmd = new OleDbCommand("delete * from PurchaseOrders where POid=@id ", olecon);
                    olecon.Open();
                    olcmd.Parameters.AddWithValue("@id", lbl_poid.Text);
                    olcmd.ExecuteNonQuery();
                    olecon.Close();
                    showpodetail(int.Parse(txt_ponumber.Text));
                    clear();
                    showpodetail(int.Parse(txt_ponumber.Text));
                }
                else
                {
                    MessageBox.Show("ڈیلیٹ کرنےکیلئے ریکارڈ سیلیکٹ کریں۔");
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
                olecon.Close();
            }
        }

        private void txt_ratesingle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_qty.Focus();
            }
        }

        private void txt_totalprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_saveprint.Focus();
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_saveprint.Focus();
            }
        }
        

        private void txt_forSrchPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showpodetail(int.Parse(txt_forSrchPO.Text));
            }
        }

        private void btn_inc_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                olecon.Open();
                OleDbDataReader myReader = null;
                int smallestpo = 0;
                OleDbCommand myCommand = new OleDbCommand(" select top 1 POnumber from PurchaseOrders order by POnumber desc ", olecon);

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    smallestpo = int.Parse(myReader["POnumber"].ToString());
                }
                olecon.Close();
                if (txt_forSrchPO.Text != "")
                {
                    int ponumber = int.Parse(txt_forSrchPO.Text);
                    if (ponumber < smallestpo)
                    {
                        ponumber = ponumber + 1;
                        txt_forSrchPO.Text = ponumber.ToString();

                    }
                }
                else
                {
                    txt_forSrchPO.Text = smallestpo.ToString();
                }
                showpodetail(int.Parse(txt_forSrchPO.Text));
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                olecon.Close();
            }
        }

        private void btn_dec_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                olecon.Open();
                OleDbDataReader myReader = null;
                int smallestpo = 0;
                OleDbCommand myCommand = new OleDbCommand(" select top 1 POnumber from PurchaseOrders order by POnumber asc ", olecon);

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    smallestpo = int.Parse(myReader["POnumber"].ToString());
                }
                olecon.Close();
                if (txt_forSrchPO.Text != "")
                {
                    int ponumber = int.Parse(txt_forSrchPO.Text);
                    if (ponumber > smallestpo )
                    {
                        ponumber = ponumber - 1;
                        txt_forSrchPO.Text = ponumber.ToString();

                    }
                }
                else
                {
                    txt_forSrchPO.Text = smallestpo.ToString();
                }
                showpodetail(int.Parse(txt_forSrchPO.Text));
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
                olecon.Close();
            }
       }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txt_itemnaem.Text = "";
            txt_qty.Text = "";
            txt_ratesingle.Text = "";
            txt_totalprice.Text = "";
        }
    }
}
