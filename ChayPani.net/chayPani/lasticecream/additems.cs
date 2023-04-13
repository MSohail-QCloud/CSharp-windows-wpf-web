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
using System.Data.OleDb;

namespace lasticecream
{
    public partial class additems : Form
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        DataSet ds = new DataSet();
        private static additems alreadyOpened = null;
        Myclass mc = new Myclass();

        public additems()
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


        private void btn_savemenu_Click(object sender, EventArgs e)
        {
            if (txt_menuname.Text != "" && txt_menurate.Text != "" &&  comboBox_menucatagory.SelectedIndex != 0)
            {
                try
                {
                    OleDbCommand olecmd;
                    string sql = "select * from menuinfo where MenuNumber=" + txt_menuNumber.Text + "";
                    olecmd = new OleDbCommand(sql, olecon);
                    olecon.Open();
                    olecmd.ExecuteNonQuery();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                    ds = new DataSet("test");
                    adapt.Fill(ds, "test");
                    //olecon.Close();
                    if (ds.Tables["test"].Rows.Count == 0)
                    {
                        String query = "insert into menuinfo (MenuNumber,menuname,menutype,menurate) values ('" + this.txt_menuNumber.Text + "','" + this.txt_menuname.Text + "','" + this.comboBox_menucatagory.SelectedItem + "','" + this.txt_menurate.Text + "')";
                        //SqlDataReader dbr;

                        //olecon.Open();
                        OleDbCommand cmd = new OleDbCommand(query, olecon);
                        cmd.ExecuteNonQuery();
                        olecon.Close();
                        txt_menuname.Focus();
                        clear();

                        Fillgridview_catagory1();
                        Fillgridview_catagory2();
                        Fillgridview_catagory3();
                        Fillgridview_catagory4();
                        Fillgridview_catagory5();
                        Fillgridview_catagory6();
                        Fillgridview_catagory7();
                        Fillgridview_catagory8();
                        Fillgridview_catagory9();
                        generateMenuNumber();
                    }
                    else
                    {
                        MessageBox.Show("Menu Number already Exists.");
                        olecon.Close();
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("تمام فیلڈز مکمل کریں۔");
            }
        }

        OleDbDataReader dr;
        int MenuNumber=0;

        private void generateMenuNumber()
        {
            olecon.Open();
            string query = "select top 1 MenuNumber  from menuinfo order by MenuNumber desc";
            OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MenuNumber = int.Parse(dr.GetValue(0).ToString());
                MenuNumber = MenuNumber + 1;

            }
            else
            {
                MenuNumber = 1;

            }
            dr.Close();
            txt_menuNumber.Text = MenuNumber.ToString();
            olecon.Close();
        }

        private void additems_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                var catagory1 = (menucatagory)1;
                var catagory2 = (menucatagory)2;
                var catagory3 = (menucatagory)3;
                var catagory4 = (menucatagory)4;
                var catagory5 = (menucatagory)5;
                var catagory6 = (menucatagory)6;
                var catagory7 = (menucatagory)7;
                var catagory8 = (menucatagory)8;
                var catagory9 = (menucatagory)9;

                comboBox_menucatagory.Items.Add("Catagory");
                comboBox_menucatagory.Items.Add(catagory1);
                comboBox_menucatagory.Items.Add(catagory2);
                comboBox_menucatagory.Items.Add(catagory3);
                comboBox_menucatagory.Items.Add(catagory4);
                comboBox_menucatagory.Items.Add(catagory5);
                comboBox_menucatagory.Items.Add(catagory6);
                comboBox_menucatagory.Items.Add(catagory7);
                comboBox_menucatagory.Items.Add(catagory8);
                comboBox_menucatagory.Items.Add(catagory9);
                comboBox_menucatagory.SelectedIndex = 0;

                lbl_catagory1.Text = catagory1.ToString();
                lbl_catagory2.Text = catagory2.ToString();
                lbl_catagory3.Text = catagory3.ToString();
                lbl_catagory4.Text = catagory4.ToString();
                lbl_catagory5.Text = catagory5.ToString();
                lbl_catagory6.Text = catagory6.ToString();
                lbl_catagory7.Text = catagory7.ToString();
                lbl_catagory8.Text = catagory8.ToString();
                lbl_catagory9.Text = catagory9.ToString();

            
           
                Fillgridview_catagory1();
                Fillgridview_catagory2();
                Fillgridview_catagory3();
                Fillgridview_catagory4();
                Fillgridview_catagory5();
                Fillgridview_catagory6();
                Fillgridview_catagory7();
                Fillgridview_catagory8();
                Fillgridview_catagory9();
            

                generateMenuNumber();
                txt_menuname.Focus();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                olecon.Close();
            }

        }
        private void clear()
        {
            txt_menuname.Text = "";
            lbl_id.Text = "";
            txt_menurate.Text = "";
            txt_menuNumber.Text = "";
        }

        private void urduTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Fillgridview_catagory1()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)1 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory1.DataSource = dt1;
            grid_menu_catagory1.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory1.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory1.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory1.Columns[1].Width = 30;
            grid_menu_catagory1.Columns[2].Width = 110;
            grid_menu_catagory1.Columns[3].Width = 40;
            grid_menu_catagory1.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory2()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)2 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory2.DataSource = dt1;
            grid_menu_catagory2.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory2.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory2.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory2.Columns[1].Width = 30;
            grid_menu_catagory2.Columns[2].Width = 110;
            grid_menu_catagory2.Columns[3].Width = 40;
            grid_menu_catagory2.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory3()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)3 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory3.DataSource = dt1;
            grid_menu_catagory3.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory3.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory3.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory3.Columns[1].Width = 30;
            grid_menu_catagory3.Columns[2].Width = 110;
            grid_menu_catagory3.Columns[3].Width = 40;
            grid_menu_catagory3.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory4()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)4 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory4.DataSource = dt1;
            grid_menu_catagory4.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory4.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory4.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory4.Columns[1].Width = 30;
            grid_menu_catagory4.Columns[2].Width = 110;
            grid_menu_catagory4.Columns[3].Width = 40;
            grid_menu_catagory4.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory5()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)5 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory5.DataSource = dt1;
            grid_menu_catagory5.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory5.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory5.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory5.Columns[1].Width = 30;
            grid_menu_catagory5.Columns[2].Width = 110;
            grid_menu_catagory5.Columns[3].Width = 40;
            grid_menu_catagory5.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory6()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)6 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory6.DataSource = dt1;
            grid_menu_catagory6.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory6.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory6.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory6.Columns[1].Width = 30;
            grid_menu_catagory6.Columns[2].Width = 110;
            grid_menu_catagory6.Columns[3].Width = 40;
            grid_menu_catagory6.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory7()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)7 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory7.DataSource = dt1;
            grid_menu_catagory7.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory7.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory7.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory7.Columns[1].Width = 30;
            grid_menu_catagory7.Columns[2].Width = 110;
            grid_menu_catagory7.Columns[3].Width = 40;
            grid_menu_catagory7.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory8()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)8 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory8.DataSource = dt1;
            grid_menu_catagory8.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory8.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory8.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory8.Columns[1].Width = 30;
            grid_menu_catagory8.Columns[2].Width = 110;
            grid_menu_catagory8.Columns[3].Width = 40;
            grid_menu_catagory8.Columns["menuid"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory9()
        {
            DataTable dt1;
            string querry = "select menuid,MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)9 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory9.DataSource = dt1;
            grid_menu_catagory9.Columns[1].HeaderText = "نمبر";
            grid_menu_catagory9.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory9.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory9.Columns[1].Width = 30;
            grid_menu_catagory9.Columns[2].Width = 110;
            grid_menu_catagory9.Columns[3].Width = 40;
            grid_menu_catagory9.Columns["menuid"].Visible = false;
            olecon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_menuNumber.Text != "" && lbl_id.Text!="")
            {
                OleDbCommand olcmd = new OleDbCommand("delete * from menuinfo where menuid=@id ", olecon);
                olecon.Open();
                olcmd.Parameters.AddWithValue("@id", lbl_id.Text);
                olcmd.ExecuteNonQuery();
                olecon.Close();
                //MessageBox.Show("مینو ڈیلیٹ کر دیا گیا ہے۔");
                Fillgridview_catagory1();
                Fillgridview_catagory2();
                Fillgridview_catagory3();
                Fillgridview_catagory4();
                Fillgridview_catagory5();
                Fillgridview_catagory6();
                Fillgridview_catagory7();
                Fillgridview_catagory8();
                Fillgridview_catagory9();

                clear();
            }
            else
            {
                MessageBox.Show("ڈیلیٹ کرنےکیلئے ریکارڈ سیلیکٹ کریں۔");
            }
        }

        private void update()
        {
            OleDbCommand command = new OleDbCommand(@"UPDATE menuinfo SET MenuNumber = @number, menuname = @name, menutype = @type, menurate = @rate WHERE menuid = @CID", olecon);

            command.Parameters.AddWithValue("@number", txt_menuNumber.Text);
            command.Parameters.AddWithValue("@name", txt_menuname.Text);
            command.Parameters.AddWithValue("@type", comboBox_menucatagory.Text);
            command.Parameters.AddWithValue("@rate", txt_menurate.Text);
            command.Parameters.AddWithValue("@CID", lbl_id.Text);

            try
            {
                olecon.Open();
            }
            catch (Exception expe)
            {
                MessageBox.Show(expe.Source);
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception expe)
            {
                MessageBox.Show(expe.Source);
            }
            finally
            {
                olecon.Close();
            }

        }

        private void btn_updatemenu_Click(object sender, EventArgs e)
        {
            if (lbl_id.Text != "")
            {
                update();
                clear();
                generateMenuNumber();
                Fillgridview_catagory1();
                Fillgridview_catagory2();
                Fillgridview_catagory3();
                Fillgridview_catagory4();
                Fillgridview_catagory5();
                Fillgridview_catagory6();
                Fillgridview_catagory7();
                Fillgridview_catagory8();
                Fillgridview_catagory9();
                txt_menuname.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_menurate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_menuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_menurate_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_menuid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_menuNumber.Text != "")
                {
                    try
                    {
                        olecon.Open();

                        OleDbCommand command = new OleDbCommand("Select * from menuinfo where MenuNumber=@zip", olecon);
                        command.Parameters.AddWithValue("@zip", txt_menuNumber.Text);
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_menuname.Text = reader["menuname"].ToString();
                                txt_menurate.Text = reader["menurate"].ToString();
                                comboBox_menucatagory.Text = reader["menutype"].ToString();
                                txt_menuNumber.Text = reader["MenuNumber"].ToString();
                            }
                        }

                        olecon.Close();
                        txt_menuname.Focus();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.ToString());
                    }
                }
            }

                
        }

        private void txt_menuname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_menurate.Focus();
            }
        }

        private void txt_menurate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox_menucatagory.Focus();
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

        private void comboBox_menucatagory_DropDownClosed(object sender, EventArgs e)
        {
            btn_savemenu.Focus();
        }

        

        private void comboBox_menucatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_savemenu.Focus();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grid_menu_catagory1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 1;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory2.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 2;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory3.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory3.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory3.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory3.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 3;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory4.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory4.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory4.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory4.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 4;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory5.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory5.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory5.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory5.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 5;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory6_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory6.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory6.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory6.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory6.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 6;
            txt_menuname.Focus();
        }

       

        private void grid_menu_catagory8_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory8.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory8.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory8.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory8.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 8;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory9_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory9.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory9.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory9.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory9.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 9;
            txt_menuname.Focus();
        }

        private void grid_menu_catagory7_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_id.Text = grid_menu_catagory7.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuNumber.Text = grid_menu_catagory7.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_menuname.Text = grid_menu_catagory7.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_menurate.Text = grid_menu_catagory7.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_menucatagory.SelectedIndex = 7;
            txt_menuname.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clear();
            generateMenuNumber();
            Fillgridview_catagory1();
            Fillgridview_catagory2();
            Fillgridview_catagory3();
            Fillgridview_catagory4();
            Fillgridview_catagory5();
            Fillgridview_catagory6();
            Fillgridview_catagory7();
            Fillgridview_catagory8();
            Fillgridview_catagory9();
            lbl_id.Text = "";
        }

        private void comboBox_menucatagory_Enter(object sender, EventArgs e)
        {
            comboBox_menucatagory.DroppedDown= true;
        }

        private void comboBox_menucatagory_Leave(object sender, EventArgs e)
        {
            comboBox_menucatagory.DroppedDown = false;
        }

        private void urduTextBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt_menuname.Text = txt_menuname.Text;
        }
    }
}
