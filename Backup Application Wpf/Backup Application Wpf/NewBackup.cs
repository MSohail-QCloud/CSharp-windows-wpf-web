using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backup_Application_Wpf
{
    public partial class NewBackup : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);


        public NewBackup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                char isactive = 'y';
                //if (txtfilename.Text != "" && txtcopypath.Text != "" && txtpastepath.Text != "" && txtfilext.Text != "" &&
                //    txtserverloc.Text != "" && combservercat.SelectedItem.ToString() != "--Select Item--" && combobackpschedule.SelectedItem.ToString() != "--Select Schedule--"
                //    && txtcopyIP.Text != "" && txtcopyusername.Text != "" && txtcopypasword.Text != "" &&
                //    txtpastipadd.Text != "" && txtpasteusername.Text != "" && txtpastepassword.Text != "")
                //{
                    var sql = "";
                    if (checkBox1.Checked == true)
                    {
                        sql = "INSERT INTO sqlbk (DestinaionIP,SystemUser,SystemPwd,SqlServerName,SqlUser,SqlPwd ) VALUES ('" + txtSqlServerIP.Text + "','" + txtSqlSystemUser.Text + "','" + txtSqlSystemPwd.Text + "' ,'" + txtSqlServerName.Text + "' ,'" + txtSqlServerUser.Text+ "','" + txtSqlServerPwd.Text + "')";
                    }
                    else
                    {
                        sql ="INSERT INTO BackupFile_Info (Filename,FilePathFrom,FilePathTo,FileEXt,Servertype,ServerLocation,CopyIpaddress,CopyUsername,CopyPassword,PasteIPaddress,PasteUsername,PastePassword,BackupSchedule,IsActive ) VALUES ('" +
                        txtfilename.Text + "','" + txtcopypath.Text + "','" + txtpastepath.Text + "' ,'" + txtfilext.Text + "' ,'" + combservercat.SelectedItem + "','" + txtserverloc.Text + "','" + txtcopyIP.Text + "','" + txtcopyusername.Text + "','" + txtcopypasword.Text + "','" + txtpastipadd.Text + "','" + txtpasteusername.Text + "','" + txtpastepassword.Text + "','" + combobackpschedule.SelectedItem + "','" + isactive + "')";
                    }
                    
                    con.Open();
                    var command = new OleDbCommand(sql, con);
                    var dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                    MessageBox.Show("Record Saved.");
                    Clear();
                    txtfilename.Focus();
                //}
                //else
                //{
                //    MessageBox.Show("Fill complete records.");
                //    txtfilename.Focus();
                //}

            }
            catch (Exception ds)
            {

                MessageBox.Show("Error on save user:" + ds);
            }
            finally
            {
                con.Close();
            }
            

        }

        private void Clear()
        {
            txtfilename.Text = "";
            txtcopyIP.Text = "";
            txtcopypasword.Text = "";
            txtcopyusername.Text = "";
            txtcopypath.Text = "";
            txtpasteusername.Text = "";
            txtfilext.Text = "";
            txtpastepassword.Text = "";
            txtpastepath.Text = "";
            txtpastipadd.Text = "";
            txtserverloc.Text = "";
            combservercat.SelectedIndex = 1;
            combobackpschedule.SelectedIndex = 1;


        }

        private void NewBackup_Load(object sender, EventArgs e)
        {
            combservercat.SelectedIndex = 0;
            combobackpschedule.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

            }
            if (checkBox1.Checked == false)
            {

            }
        }
    }
}
