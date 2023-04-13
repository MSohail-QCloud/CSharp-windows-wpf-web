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
    public partial class CalculatorForm : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public string MenuNumber { get; set; }
        public int billnumber { get; set; }
        public string know { get; set; }
        public DateTime billdate { get; set; }
        //private static CalculatorForm alreadyOpened = null;
        //BillScreen bls=new BillScreen();
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            txt_discount.Visible = false;
            label1.Visible = false;
            refresh();
            lbl_menuNumber.Text = MenuNumber;
            lbl_billNumber.Text = billnumber.ToString();
            try
            {
                olecon.Open();
                OleDbCommand command = new OleDbCommand("Select * from menuinfo where MenuNumber=@zip", olecon);
                command.Parameters.AddWithValue("@zip", MenuNumber);
                // int result = command.ExecuteNonQuery();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //lbl_billNumber.Text = reader["MenuNumber"].ToString();
                        //lbl_menuNumber.Text = reader["MenuNumber"].ToString();
                        txt_rate.Text = reader["menurate"].ToString();
                        txt_menuName.Text = reader["menuname"].ToString();
                        //lbl_menuType.Text = reader["menutype"].ToString();
                    }
                }

                olecon.Close();
                txt_customQty.Focus();



            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_customQty.Focus();
            this.Close();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {

            //bs.gri_bill(float.Parse(txt_qty.Text), txt_menuName.Text, int.Parse(txt_rate.Text), float.Parse( txt_total.Text), billnumber   );
            string sdate = billdate.ToString("dd-MM-yyyy");
            string StrQuery = "INSERT INTO detailbill (masterbill_id,menu_name,menurate,menu_qty,total,menu_code,billingdate) VALUES ('" + billnumber.ToString() + "','" + txt_menuName.Text + "','" + txt_rate.Text + "','" + txt_qty.Text + "','" + txt_total.Text + "',"+lbl_menuNumber.Text+ ",'" + sdate + "')";
            olecon.Open();
            using (OleDbCommand comm = new OleDbCommand(StrQuery, olecon))
            {
                comm.ExecuteNonQuery();
            }
            olecon.Close();
            txt_customQty.Focus();
            //BillScreen bls = new BillScreen();
            //bls.gri_bill();
            this.Close();
        }

        private void CalculatorForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F8)
            {
                btn_accept_Click(sender,e);
            }
            if (e.KeyCode == Keys.Q)
            {
                txt_customQty.Focus();
            }
            if (e.KeyCode == Keys.R)
            {
                txt_customRate.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (chkbx_halfplate.Checked == true)
                {
                    chkbx_halfplate.Checked = false;
                }
                else
                {
                    chkbx_halfplate.Checked = true;
                }
            }

        }
        private void refresh()
        {
            txt_customQty.Text = "1";
            txt_qty.Text = "1";
            txt_customRate.Text = "";
            txt_discount.Text = "";
            chkbx_halfplate.Checked = false;
        }

        

        private void txt_qty2_TextChanged(object sender, EventArgs e)
        {
            //txt_qty.Text = txt_qty2.Text;
        }

        private void chkbx_halfplate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_halfplate.Checked == true)
            {
                txt_qty.Text = "0.5";
                
            }
            else
            {
                txt_qty.Text = "1";
            }
            calculate();
        }

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }
        private void calculate()
        {
            if(txt_qty.Text!="" && txt_rate.Text!="")
            {
                float qty = float.Parse(txt_qty.Text);
                float rate = float.Parse(txt_rate.Text);
                float total = qty * rate;
               int totalint = (int)Math.Round(total);
                txt_total.Text = totalint.ToString();
            }
            else
            {
                txt_total.Text = "";
            }
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            //calculate();
        }

        private void CalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Close();

        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void txt_customRate_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text != "" && txt_rate.Text != "" && txt_customRate.Text!="" )
            {
                float customrate = float.Parse(txt_customRate.Text);
                float rate = float.Parse(txt_rate.Text);
                float qty = customrate / rate;
               qty = (float)Math.Round(qty * 100F) / 100F;
                
                txt_qty.Text = qty.ToString();
                txt_total.Text = txt_customRate.Text;
            }
            else
            {
                txt_total.Text = "";
            }
        }

        private void txt_customQty_TextChanged(object sender, EventArgs e)
        {
            txt_qty.Text = txt_customQty.Text;
            calculate();
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            calculate();
            if (txt_discount.Text != "" )
            {
                int toatal= int.Parse(txt_total.Text);
                int dis = int.Parse(txt_discount.Text);
                int remaining = toatal - dis;
                txt_total.Text = remaining.ToString();
            }
            else
            {
                txt_discount.Text = "";
            }
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_customQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_customRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            //{
            //    chkbx_halfplate.Focus();
            //}
            if (e.KeyCode == Keys.Up) { txt_customQty.Focus(); }
            else if (e.KeyCode == Keys.Down) { txt_customRate.Focus(); }
        }

        private void txt_customQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { txt_customRate.Focus(); }
            else if (e.KeyCode == Keys.Down) { txt_customRate.Focus(); }
        }

        private void txt_customRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { txt_customQty.Focus(); }
            else if (e.KeyCode == Keys.Down) { txt_customQty.Focus(); }
        }
    }
}
