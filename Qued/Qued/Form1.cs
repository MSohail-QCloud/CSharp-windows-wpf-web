using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Configuration;

namespace Qued
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ToString());
        Queue<string> qt = new Queue<string>(4);
        DataSet ds;
        SqlCommand cmd;
        SqlDataAdapter da;
        string entrymode = "";
        string attenddate = "";
        string attendtime = "";
        string terminalID = "";
        string rfid = "";

        public Form1()
        {
            InitializeComponent();
        }

        string RecivePortIN = "1015";
        string RecivePortOut = "1016";
        string SendPortIN = "6100";
        string SendPortOut = "6200";
        string SendIPIN = "10.0.77.44";
        string SendIPOut= "10.0.77.45";
        string RecievePort = "";
        string SendPort = "";
        string SendIP = "";

        Thread thdSendRecieve;
        string Appsetting = ConfigurationManager.AppSettings["AppType"].ToString();
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Appsetting == "IN")
            {
                RadiobtnINside.Checked = true;
                RecievePort = RecivePortIN;
                SendPort = SendPortIN;
                SendIP = SendIPIN;
            }
            else if(Appsetting=="OUT")
            {
                RadiobtnOutside.Checked = true;
                RecievePort = RecivePortOut;
                SendPort = SendPortOut;
                SendIP = SendIPOut;
            }


            thdSendRecieve = new Thread(new
           ThreadStart(RecieveSend));
            thdSendRecieve.IsBackground = true;
            thdSendRecieve.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (qt.Count == 4)
            //{
            //    qt.Dequeue();
            //}
            //qt.Enqueue(int.Parse(textBox5.Text));


            //int[] array = new int[4];
            //qt.CopyTo(array, 0);


            //textBox1.Text = array[0].ToString();
            //textBox2.Text = array[1].ToString();
            //textBox3.Text = array[2].ToString();
            //textBox4.Text = array[3].ToString();


            //string str= array[0].ToString()+ array[1].ToString()+ array[2].ToString()+ array[3].ToString();

        }


        static string RemoveWhitespace(string input)
        {
            StringBuilder output = new StringBuilder(input.Length);

            for (int index = 0; index < input.Length; index++)
            {
                if (!Char.IsWhiteSpace(input, index))
                {
                    output.Append(input[index]);
                }
            }
            return output.ToString();
        }

        int empID = 0;
        string employeeid = "";
        int empcode = 0;
        string empname = "";
        public void RecieveSend()
        {
            try
            {
                while (true)
                {
                    clearall();
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(RecievePort));
                    UdpClient udpClient1 = new UdpClient(RemoteIpEndPoint);
                    Byte[] receiveBytes = udpClient1.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes).Trim();
                    rfid = returnData.Substring(0, 8);
                    terminalID = returnData.Substring(9,3);
                    //returnData = "15450726";
                    // find employee id
                    
                    ds = new DataSet();
                    string query = "select top 1 * from( select a.attendid, e.emp_id,e.emp_code,e.empName,a.attenddate,a.attendtime,a.entrymode  from employee e inner join AttendData a on e.emp_id=a.employeeid where  e.rfid ='" + rfid + "' )a  order by attendid desc";
                    cmd = new SqlCommand(query, con);
                    da = new SqlDataAdapter(query, con);
                    con.Open();
                    da.Fill(ds, "test");
                    if (ds.Tables["test"].Rows.Count == 1)
                    {
                        empID = int.Parse(ds.Tables["test"].Rows[0]["emp_id"].ToString());
                        employeeid = empID.ToString();
                        empcode = int.Parse(ds.Tables["test"].Rows[0]["emp_code"].ToString());
                        empname = ds.Tables["test"].Rows[0]["empName"].ToString();
                        attenddate = ds.Tables["test"].Rows[0]["attenddate"].ToString();
                        attendtime = ds.Tables["test"].Rows[0]["attendtime"].ToString();
                        attenddate = DateTime.Parse(attenddate).ToString("dd-MM-yyyy");
                        attendtime = DateTime.Parse(attendtime).ToString("HH:mm");
                        entrymode = ds.Tables["test"].Rows[0]["entrymode"].ToString();
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        string time = dt.ToString("HH:mm");
                        //empID = int.Parse(rfid);
                        employeeid = "  Card";

                        empname = "Not Registered";
                        attendtime = "     ";
                        //this.Invoke(new MethodInvoker(delegate ()
                        //{
                        //    MessageBox.Show("No, Employee Data does not exit");
                        //}));
                    }
                    con.Close();

                    //Check App Type

                    if (RadiobtnINside.Checked == true)
                    {
                        if (entrymode == "O ")
                        {
                            DateTime dt = DateTime.Now;
                            string date = (dt.Year + "-" + dt.Month + "-" + dt.Day);
                            string time = DateTime.Now.TimeOfDay.ToString();
                            string elseIn = "insert into AttendData  (EmployeeID, AttendDate, AttendTime, EntryMode, TerminalID, Shift, Batch, posted) values ('" + empID + "', '" + date + "', '" + time + "', '" + "I" + "', '" + terminalID + "', '" + "X" + "', '" + "X" + "', 0)";
                            con.Open();
                            SqlCommand elseCmdd = new SqlCommand(elseIn, con);
                            elseCmdd.ExecuteNonQuery();
                            string sql = "select  top 1 employeeid,attenddate,attendtime,entrymode  from attenddata where  employeeid='" + empID + "' order by AttendID desc";
                            cmd = new SqlCommand(sql, con);
                            da = new SqlDataAdapter(sql, con);
                            da.Fill(ds, "attend");
                            if (ds.Tables["attend"].Rows.Count > 0)
                            {
                                entrymode = ds.Tables["attend"].Rows[0]["EntryMode"].ToString().Trim();
                                attenddate = ds.Tables["attend"].Rows[0]["AttendDate"].ToString();

                                attenddate = DateTime.Parse(attenddate).ToString("dd-MM-yyyy");

                                attendtime = ds.Tables["attend"].Rows[0]["AttendTime"].ToString();

                                attendtime = DateTime.Parse(attendtime).ToString("HH:mm");
                                //attendtime = attendtime.Substring(0, 8);

                            }
                            con.Close();
                            entrymode = "OUT";
                        }
                        //else if (entrymode == "I ")
                        //{
                        //    //empname = "Already IN";
                        //    //entrymode = "IN";
                        //}


                        else
                        {
                            entrymode = "No Status";
                        }

                    }
                    else if (RadiobtnOutside.Checked == true)
                    {
                        if (entrymode == "I ")
                        {
                            DateTime dt = DateTime.Now;
                            string date = (dt.Year + "-" + dt.Month + "-" + dt.Day);
                            string time = DateTime.Now.TimeOfDay.ToString();
                            string elseIn = "insert into AttendData  (EmployeeID, AttendDate, AttendTime, EntryMode, TerminalID, Shift, Batch, posted) values ('" + empID + "', '" + date + "', '" + time + "', '" + "O" + "', '" + terminalID + "', '" + "X" + "', '" + "X" + "', 0)";
                            con.Open();
                            SqlCommand elseCmdd = new SqlCommand(elseIn, con);
                            elseCmdd.ExecuteNonQuery();
                            string sql = "select  top 1 employeeid,attenddate,attendtime,entrymode  from attenddata where  employeeid='" + empID + "' order by AttendID desc";
                            cmd = new SqlCommand(sql, con);
                            da = new SqlDataAdapter(sql, con);
                            da.Fill(ds, "attend");
                            if (ds.Tables["attend"].Rows.Count > 0)
                            {
                                entrymode  = ds.Tables["attend"].Rows[0]["EntryMode"].ToString().Trim();
                                attenddate = ds.Tables["attend"].Rows[0]["AttendDate"].ToString();

                                attenddate = DateTime.Parse(attenddate).ToString("dd-MM-yyyy");

                                attendtime = ds.Tables["attend"].Rows[0]["AttendTime"].ToString();

                                attendtime = DateTime.Parse(attendtime).ToString("HH:mm");
                                //attendtime = attendtime.Substring(0, 8);

                            }
                            con.Close();
                            entrymode = "IN";
                        }
                        //else if (entrymode == "O ")
                        //{
                        //    empname = "Already Out";
                        //    entrymode = "OUT";
                        //}


                        else
                        {
                            entrymode = "No Status";
                        }
                    }

                    //qeue
                    if (empname.Length > 17)
                    {
                        empname = empname.Substring(0, 17);
                    }
                    else if (empname.Length < 18)
                    {
                        for(int i = empname.Length; i <= 16; i++)
                        {
                            empname= empname+ " ";
                        }
                    }

                    string strdisplay = employeeid.ToString() + " " + empname + " " + attendtime;

                    if (qt.Count == 4)
                        {
                            qt.Dequeue();
                        }
                        //qt.Enqueue(empID.ToString()+"-"+empname+"-"+attenddate+"-"+attendtime+"-"+entrymode);
                        qt.Enqueue(strdisplay);
                        string[] array = new string[] { "", "", "", "" };
                        qt.CopyTo(array, 0);
                    string str="";
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            
                            textBox1.Text = array[3].ToString();
                            textBox2.Text = array[2].ToString();
                            textBox3.Text = array[1].ToString();
                            textBox4.Text = array[0].ToString();
                            //str = array[0].ToString() + array[1].ToString() + array[2].ToString() + array[3].ToString();
                        }));
                    //str = array[3] + "+" + array[2] + "+" + array[1] + "+" + array[0]+"#";
                    str = array[3] +  array[2] + array[1] + array[0]+"#";
                        //string str = "kese hn";

                        //end queue

                        //send to client start

                        UdpClient udpClient = new UdpClient(SendIP, int.Parse( SendPort));
                    //UdpClient udpClient = new UdpClient("10.0.4.39", "6100");
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(str);
                        try
                        {
                            
                            udpClient.Send(sendBytes, sendBytes.Length);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            textBoxAll.Text = Encoding.ASCII.GetString(sendBytes);
                        }));
                    }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        udpClient1.Close();
                        //107013 + ZAHID RASHEED + 14:36:50.3600000 + 5 / 27 / 2018 12:00:00 AM + MORNING SHIFT + 06:00:00 to 14:00:00 + Okay + 1 +
                 }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                con.Close();
            }
        }

        private void clearall()
        {
            attenddate = "";
            attendtime = "";
            rfid = "";
            entrymode = "";
        }
        
        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadiobtnINside_CheckedChanged(object sender, EventArgs e)
        {
            if(RadiobtnINside.Checked== true)
            {
                RecievePort = RecivePortIN;
                SendPort = SendPortIN;
                SendIP = SendIPIN;
                //try
                //{
                //    thdSendRecieve.Abort();
                //}
                //catch (Exception es)
                //{

                //}
                //thdSendRecieve = new Thread(new
                //ThreadStart(RecieveSend));
                //thdSendRecieve.IsBackground = true;
                //thdSendRecieve.Start();


            }
           
        }

        private void RadiobtnOutside_CheckedChanged(object sender, EventArgs e)
        {
            if (RadiobtnOutside.Checked == true)
            {
                RecievePort = RecivePortOut;
                SendPort = SendPortOut;
                SendIP = SendIPOut;

                //try
                //{
                //    thdSendRecieve.Abort();
                //}
                //catch (Exception es)
                //{

                //}
                //thdSendRecieve = new Thread(new
                //ThreadStart(RecieveSend));
                //thdSendRecieve.IsBackground = true;
                //thdSendRecieve.Start();
            }
        }

        private void textBoxAll_TextChanged(object sender, EventArgs e)
        {

        }

        //private void changestatus()
        //{
        //    try
        //    {
        //        double v_EmployeeID = 0;
        //        double v_attendid = 0;
        //        double v_TerminalID = 0;
        //        double v_posted = 0;
        //        double v_Emp_Code = 0;
        //        double v_manual_entry = 0;
        //        double v_isexecutive = 0;
        //        double v_inactive = 0;
        //        double v_currentdate = 0;
        //        double v_currenttime = 0;
        //        string v_lastdate = null;
        //        string v_lasttime = null;
        //        string v_AttendDate = null;
        //        string v_AttendTime = null;
        //        string v_EntryMode = null;
        //        string v_Shift = null;
        //        string v_Batch = null;
        //        string v_restday = null;
        //        string v_manual_reason = null;
        //        string v_manual_enterby = null;
        //        string v_starttime = null;
        //        string v_endtime = null;
        //        string v_mtime = null;
        //        string pcname = null;
        //        string osUser = null;
        //        string terminalName = null;
        //        setmanualdate();
        //        pcname = System.Environment.MachineName;
        //        terminalName = System.Environment.MachineName;
        //        osUser = Environment.UserName;
        //        v_Emp_Code = Convert.ToDouble(ds.Tables["test"].Rows[0]["emp_Code"]);
        //        if (Convert.ToBoolean(ds.Tables["test"].Rows[0]["IsExecutive"]) == true)
        //        {
        //            v_isexecutive = 1;
        //        }
        //        else
        //        {
        //            v_isexecutive = 0;
        //        }
        //        if (Convert.ToBoolean(ds.Tables["test"].Rows[0]["inactive"]) == true)
        //        {
        //            v_inactive = 1;
        //            MessageBox.Show("Employee has been quit");
        //            return;
        //        }
        //        //if (v_inactive == 1)
        //        //{
        //        //    MessageBox.Show("Employee has been quit");
        //        //    return;
        //        //}
        //        string sqlid = "select max(attendid) as attend from attenddata where emp_code = '" + txt_empcode.Text + "' or EmployeeId='" + txt_empcode.Text + "'";
        //        cmd = new SqlCommand(sqlid, con);
        //        da = new SqlDataAdapter(sqlid, con);
        //        da.Fill(ds, "attendId");
        //        con.Close();
        //        if (ds.Tables["attendId"].Rows[0]["attend"].ToString() == "")
        //        {
        //            MessageBox.Show("There is no log for this employee. Manual Entry not Allowed");
        //            return;
        //        }
        //        else
        //        {
        //            v_attendid = Convert.ToDouble(ds.Tables["attendId"].Rows[0]["attend"]);
        //        }
        //        v_TerminalID = 1;
        //        v_posted = 0;
        //        v_manual_entry = 1;

        //        if (ds.Tables["time"] != null)
        //        {
        //            ds.Tables["time"].Clear();
        //        }
        //        string time = "select attenddate, attendtime from attenddata where (emp_code = '" + txt_empcode.Text + "' or EmployeeId='" + txt_empcode.Text + "' )and attendid = '" + v_attendid + "'";
        //        con.Open();
        //        cmd = new SqlCommand(time, con);
        //        SqlDataAdapter timeadapt = new SqlDataAdapter(time, con);
        //        timeadapt.Fill(ds, "time");
        //        con.Close();
        //        v_lastdate = Convert.ToDateTime(ds.Tables["time"].Rows[0]["attenddate"]).ToString("yyyy/MM/dd");
        //        v_lasttime = Convert.ToString(ds.Tables["time"].Rows[0]["attendtime"]);
        //        v_lastdate = v_lastdate.Substring(0, 4) + v_lastdate.Substring(5, 2) + v_lastdate.Substring(8, 2);
        //        v_lasttime = v_lasttime.Substring(0, 2) + v_lasttime.Substring(3, 2);

        //        string test = "";       // Drag arrow point here for new jionners

        //        v_AttendDate = datemanual.Substring(6, 4) + datemanual.Substring(3, 2) + datemanual.Substring(0, 2);
        //        if (Convert.ToInt32(v_AttendDate) < Convert.ToInt32(v_lastdate))
        //        {
        //            MessageBox.Show("Manual Date is less than last Attendence Date.");
        //            dt_dateManualAttendence.Focus();
        //            return;
        //        }
        //        v_AttendTime = txt_TimeManualattendence.Text.Substring(0, 2) + txt_TimeManualattendence.Text.Substring(3, 2);
        //        if (Convert.ToInt32(v_AttendDate) == Convert.ToInt32(v_lastdate))
        //        {
        //            if (Convert.ToInt32(v_AttendTime) < Convert.ToInt32(v_lasttime))
        //            {
        //                MessageBox.Show("Manual Time is less than last Attendence.");
        //                txt_TimeManualattendence.Focus();
        //                return;
        //            }
        //        }
        //        if (ds.Tables["currentD"] != null)
        //        {
        //            ds.Tables["currentD"].Clear();
        //        }
        //        con.Open();
        //        string currDa = "SELECT convert(varchar, getdate(), 112) as currDate";
        //        SqlCommand currDCom = new SqlCommand(currDa, con);
        //        SqlDataAdapter currDdata = new SqlDataAdapter(currDa, con);
        //        currDdata.Fill(ds, "currentD");
        //        con.Close();
        //        v_currentdate = Convert.ToDouble(ds.Tables["currentD"].Rows[0]["currDate"]);

        //        if (ds.Tables["currentT"] != null)
        //        {
        //            ds.Tables["currentT"].Clear();
        //        }
        //        con.Open();
        //        string currT = "SELECT convert(varchar, getdate(), 108)as currTime";
        //        SqlCommand currTCom = new SqlCommand(currT, con);
        //        SqlDataAdapter currTdata = new SqlDataAdapter(currT, con);
        //        currTdata.Fill(ds, "currentT");
        //        con.Close();
        //        string ct = Convert.ToString(ds.Tables["currentT"].Rows[0]["currTime"]);
        //        v_currenttime = Convert.ToDouble(ct.Substring(0, 2) + ct.Substring(3, 2));
        //        if (Convert.ToInt32(v_currentdate) < Convert.ToInt32(v_AttendDate))
        //        {
        //            MessageBox.Show("Future Date Not Allowed");
        //            return;
        //        }
        //        if (Convert.ToInt32(v_currentdate) == Convert.ToInt32(v_AttendDate))
        //        {
        //            if (Convert.ToInt32(v_currenttime) < Convert.ToInt32(v_AttendTime))
        //            {
        //                MessageBox.Show("Future Time Not Allowed");
        //                return;
        //            }
        //        }
        //        string v_currenttimeN = Convert.ToString(v_currenttime);
        //        //pcname =user+"-"+ pcname + "-" + v_AttendDate + "-" + v_currenttimeN.Substring(0, 2) + ":" + v_currenttimeN.Substring(2, 2);
        //        pcname = Username + "-" + pcname + "-" + v_AttendDate + "-" + v_currenttimeN;
        //        v_AttendDate = v_AttendDate.Substring(0, 4) + "-" + v_AttendDate.Substring(4, 2) + "-" + v_AttendDate.Substring(6, 2);
        //        v_AttendTime = txt_TimeManualattendence.Text;
        //        if (entrymode == "I")
        //        {
        //            v_EntryMode = "O";
        //        }
        //        else
        //        {
        //            v_EntryMode = "I";
        //        }
        //        if (ds.Tables["shiftGroup"] != null)
        //        {
        //            ds.Tables["shiftGroup"].Clear();
        //        }
        //        con.Open();
        //        string shift = "select * from shiftgroup where employeeid = '" + newcode + "'";
        //        SqlCommand shiftCom = new SqlCommand(shift, con);
        //        SqlDataAdapter shiftdata = new SqlDataAdapter(shift, con);
        //        shiftdata.Fill(ds, "shiftGroup");
        //        con.Close();
        //        v_Shift = Convert.ToString(ds.Tables["shiftGroup"].Rows[0]["ShiftID"]);
        //        v_Batch = Convert.ToString(ds.Tables["shiftGroup"].Rows[0]["Batch"]);
        //        v_restday = Convert.ToString(ds.Tables["shiftGroup"].Rows[0]["RestDay"]);
        //        v_manual_reason = Convert.ToString(combo_reasonManualAtten.Text);
        //        v_manual_enterby = System.Environment.MachineName + DateTime.Now;
        //        if (v_EntryMode == "O")
        //        {
        //            if (ds.Tables["firstIn"] != null)
        //            {
        //                ds.Tables["firstIn"].Clear();
        //            }
        //            con.Open();
        //            string inFirst = "select * from attenddata where attendid = '" + v_attendid + "' and (emp_code = '" + v_Emp_Code + "' or EmployeeId='" + v_Emp_Code + "')";
        //            SqlCommand fCom = new SqlCommand(inFirst, con);
        //            SqlDataAdapter fdata = new SqlDataAdapter(inFirst, con);
        //            fdata.Fill(ds, "firstIn");
        //            con.Close();
        //            v_Shift = Convert.ToString(ds.Tables["firstIn"].Rows[0]["Shift"]);
        //            v_Batch = Convert.ToString(ds.Tables["firstIn"].Rows[0]["Batch"]);
        //            con.Open();
        //            string manual = "insert into AttendData(EmployeeID, AttendDate, AttendTime, EntryMode, TerminalID, Shift, Batch, posted, Emp_Code, manual_enter, manual_reason,Enter_Date,Terminal,OS_User) values ('" + newcode + "', '" + v_AttendDate + "', '" + v_AttendTime + "', '" + v_EntryMode + "', 0, '" + v_Shift + "', '" + v_Batch + "', 0, " + v_Emp_Code + ", '" + pcname + "', '" + v_manual_reason + "','" + DateTime.Now + "','" + terminalName + "','" + osUser + "')";
        //            SqlCommand sqlCmdd = new SqlCommand(manual, con);
        //            sqlCmdd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        else
        //        {
        //            string currentDay = DateTime.Now.ToString("dddd");
        //            currentDay = currentDay.ToUpper();
        //            if (v_restday == currentDay)
        //            {
        //                MessageBox.Show("Manual Attendence on Rest Day Not Allowed");
        //                return;
        //            }
        //            if (v_Shift != "F")
        //            {
        //                if (Convert.ToInt32(v_isexecutive) != 1)
        //                {
        //                    if (ds.Tables["shiftTime"] != null)
        //                    {
        //                        ds.Tables["shiftTime"].Clear();
        //                    }
        //                    con.Open();
        //                    string shiftTime = "select * from shifts where shiftid = '" + v_Shift + "'";
        //                    SqlCommand stimeCom = new SqlCommand(shiftTime, con);
        //                    SqlDataAdapter stimedata = new SqlDataAdapter(shiftTime, con);
        //                    stimedata.Fill(ds, "shiftTime");
        //                    con.Close();
        //                    v_starttime = Convert.ToString(ds.Tables["shiftTime"].Rows[0]["fromtime"]);
        //                    v_starttime = v_starttime.Substring(0, 2) + v_starttime.Substring(3, 2);
        //                    v_endtime = Convert.ToString(ds.Tables["shiftTime"].Rows[0]["totime"]);
        //                    v_endtime = v_endtime.Substring(0, 2) + v_endtime.Substring(3, 2);
        //                    v_starttime = Convert.ToString(Convert.ToInt32(v_starttime) - 55);
        //                    v_endtime = Convert.ToString(Convert.ToInt32(v_endtime) + 59);
        //                    v_mtime = txt_TimeManualattendence.Text.Substring(0, 2) + txt_TimeManualattendence.Text.Substring(3, 2);
        //                    if (Convert.ToInt32(v_mtime) < Convert.ToInt32(v_starttime))
        //                    {
        //                        MessageBox.Show("Wrong shift time");
        //                        return;
        //                    }
        //                    if (lbl_shift.ToString() != "C")
        //                    {
        //                        if (Convert.ToInt32(v_mtime) > Convert.ToInt32(v_endtime))
        //                        {
        //                            MessageBox.Show("Wrong shift time");
        //                            return;
        //                        }

        //                    }
        //                    string v_statrtime = "";
        //                    if (Convert.ToInt32(v_mtime) > Convert.ToInt32(v_starttime) + 155)
        //                    {
        //                        if (ds.Tables["inTime"] != null)
        //                        {
        //                            ds.Tables["inTime"].Clear();
        //                        }
        //                        con.Open();
        //                        string inTime = "select * from AttendData where Emp_Code = " + v_Emp_Code + " and AttendDate = '" + v_AttendDate + "' and attendtime > '" + v_statrtime + "'";
        //                        SqlCommand inCom = new SqlCommand(inTime, con);
        //                        SqlDataAdapter indata = new SqlDataAdapter(inTime, con);
        //                        indata.Fill(ds, "inTime");
        //                        con.Close();
        //                        if (ds.Tables["inTime"].Rows.Count < 1)
        //                        {
        //                            MessageBox.Show("Employee Late than 1 hour");
        //                            return;
        //                        }
        //                    }
        //                }
        //            }
        //            con.Open();
        //            string elseIn = "insert into AttendData(EmployeeID, AttendDate, AttendTime, EntryMode, TerminalID, Shift, Batch, posted, Emp_Code, manual_enter, manual_reason,Enter_Date,Terminal,OS_User) values ('" + newcode + "', '" + v_AttendDate + "', '" + v_AttendTime + "', '" + v_EntryMode + "', 0, '" + v_Shift + "', '" + v_Batch + "', 0, " + v_Emp_Code + ", '" + pcname + "', '" + combo_reasonManualAtten.SelectedItem + "','" + DateTime.Now + "','" + terminalName + "','" + osUser + "')";
        //            SqlCommand elseCmdd = new SqlCommand(elseIn, con);
        //            elseCmdd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        MessageBox.Show("Your Status Changed.");
        //        clear();
        //        if (checkbx_multipleEntries.IsChecked != true)
        //        {
        //            txt_TimeManualattendence.Text = "";
        //        }
        //        txt_empcode.Text = "";
        //        txt_empcode.Focus();
        //        btn_changestatus.IsEnabled = false;
        //    }

        //    catch (Exception es)
        //    {
        //        MessageBox.Show("Error on Manual IN" + "=" + es.ToString());
        //        con.Close();
        //    }
        //}

    }
}

