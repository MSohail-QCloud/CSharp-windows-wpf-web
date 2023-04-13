using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Shapes;
using VesterShoes.classes;
using BorderStyle = System.Windows.Forms.BorderStyle;
using Label = System.Windows.Forms.Label;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using TextBox = System.Windows.Forms.TextBox;

namespace VesterShoes
{
    public partial class NewProductionForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        SqlConnection sqlcon2 = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        VestureClass vc = new VestureClass();


        public NewProductionForm()
        {
            InitializeComponent();
        }

        int xtitle = 10;
        int ytitle = 130;
        int xOne = 0;
        int yOne = 1;
        int xTwo = 70;
        int yTwo = 1;
        int xThree = 280;
        int yThree = 1;
        int xFour = 340;
        int yFour = 1;
        int xFive = 340;
        int yFive = 20;
        int xSix = 340;
        int ySix = 40;
        int xSeven = 460;
        int ySeven = 1;
        int xEight = 460;
        int yEight = 20;
        int xNine = 460;
        int yNine = 40;
        int xten = 580;
        int yten = 1;
        int xeleven = 580;
        int yeleven = 20;
        int xtwelve = 580;
        int ytwelve = 40;
        int xthirteen = 700;
        int ythirteen = 1;
        int xfourteen = 700;
        int yfourteen = 20;
        int xfifteen = 700;
        int yfifteen = 40;
        int xsixteen = 810;
        int ysixteen = 1;
        int xseventeen = 810;
        int yseventeen = 20;
        int xeighteen = 810;
        int yeighteen = 40;
        int xninteen = 930;
        int yninteen = 1;
        int xtwenty = 930;
        int ytwenty = 20;
        int x21 = 930;
        int y21 = 40;
        int x22 = 1050;
        int y22 = 1;
        int x23 = 1050;
        int y23 = 20;
        int x24 = 1050;
        int y24 = 40;
        int x25 = 1160;
        int y25 = 1;
        int x26 = 1300;
        int y26 = 1;
        int ij = 0;
        int xline = 65;
        int yline = 0;
        string chem;
        int i;
        string dateformate = "";
        Thread thdUDPServer1;
        private void NewProductionForm_Load(object sender, EventArgs e)
        {

            jobstate = 1;
            startthread = 1;
            //txtJobID.Text = this.Width.ToString();
           // panel1.Width = this.Width-100;
            thdUDPServer1 = new Thread(new
           ThreadStart(loadControls));
            thdUDPServer1.IsBackground = true;
            thdUDPServer1.Start();
            
            //DataSet dst = vc.Select("select vender_type_Descr from tblProcessStates");
            //for (i = 0; i < dst.Tables["table"].Rows.Count; i++)
            //{
            //    Label title = new Label
            //    {
            //        Text = dst.Tables["table"].Rows[i]["vender_type_Descr"].ToString(),
            //        Location = new Point(xtitle, yOne),
            //        Size = new Size(60, 20),
            //        ForeColor = Color.Gray,
            //        Name = "vender_type_Descr" + i.ToString()
            //    };
            //    this.Controls.Add(title);
            //panel1.Show();
            //yOne += 70;
            //a.TextChanged += new System.EventHandler(this.PIDTextBox_Changed);


            //Invoke((Action)(() =>
            //{
            //}));

        }

        int jobstate;
        int startthread = 0;
        private void loadControls()
        {

            while (true)
            {
                if (startthread==1)
                {
                    startthread = 0;
                //Invoke((Action) (() =>
                //{
                //    btnReload.Enabled = false;
                //    panel1.Enabled = false;
                

                try
                {
                    DataSet ds =
                        vc.Select("select   ProcessiingID  from tblProcessingDetail where jobStates='" + jobstate + "'");
                    //string inv;
                    TextBox[] Shapes = new TextBox[ds.Tables["table"].Rows.Count];
                    
                    //panel1.Controls.Clear();
                    for (i = 0; i < ds.Tables["table"].Rows.Count; i++)
                    {
                        TextBox a = new TextBox
                        {
                            Text = ds.Tables["table"].Rows[i]["ProcessiingID"].ToString(),
                            Location = new Point(xOne, yOne),
                            Size = new Size(60, 20),
                            ReadOnly = true,
                            ForeColor = Color.Gray,
                            Name = "ProcessiingID" + i.ToString()
                        };
                        yOne += 70;
                        a.TextChanged += new System.EventHandler(this.PIDTextBox_Changed);

                        Label Linez = new Label
                        {
                            Location = new Point(xOne, yOne - 5),
                            Size = new Size(1200, 03),
                            BackColor = Color.Black,
                            BorderStyle = BorderStyle.Fixed3D,
                            AutoSize = false
                            //Height = 2
                        };
                        //Invoke((Action)(() =>
                        //{
                        //    panel1.Controls.Add(Linez);
                        //    panel1.Show();
                        //}));
                        //yline += 60;
                        DataSet dsb =
                            vc.Select(
                                "select ItemsDescription from tblProcessingDetail p , tblItems i  where p.ItemID=i.ItemsID and ProcessiingID='" +
                                a.Text + "'");
                        //------------------------
                        TextBox b = new TextBox
                        {
                            //Text = dsb.Tables["table"].Rows[i]["ItemsDescription"].ToString(),
                            Location = new Point(xTwo, yTwo),
                            Size = new Size(200, 60),
                            Multiline = true,
                            Name = "ItemsDescription" + i,
                            Text =
                                dsb.Tables["table"].Rows.Count > 0
                                    ? dsb.Tables["table"].Rows[0]["ItemsDescription"].ToString()
                                    : ""
                        };
                        //Invoke((Action)(() =>
                        //{
                        //    panel1.Controls.Add(b);
                        //    panel1.Show();
                        //}));
                        yTwo += 70;

                        DataSet dsc =
                            vc.Select(
                                "select OrderQty from tblProcessingDetail where ProcessiingID='" + a.Text + "'");
                        //---------thre  qty----------------
                        TextBox c = new TextBox
                        {
                            //Text = dsc.Tables["table"].Rows[0]["OrderQty"].ToString(),
                            Location = new Point(xThree, yThree),
                            Size = new Size(40, 20),
                            Name = "OrderQty" + i,
                            Text =
                                dsc.Tables["table"].Rows.Count > 0
                                    ? dsc.Tables["table"].Rows[0]["OrderQty"].ToString()
                                    : ""
                        };
                        //Invoke((Action)(() =>
                        //{
                        //    panel1.Controls.Add(c);
                        //    panel1.Show();
                        //}));
                        yThree += 70;

                        DataSet dsd =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 0" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");

                        //---------Cm Date in----------------
                        Label d = new Label
                        {

                            //Text = dsd.Tables["table"].Rows[0]["IssueDate"].ToString(),
                            Location = new Point(xFour, yFour),
                            Size = new Size(100, 20),
                            Name = "CM_IssueDate" + i,
                            Text =
                                (dsd.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsd.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : "")
                        };
                        yFour += 70;

                        //---------Cm ---------------
                        TextBox f = new TextBox
                        {
                            Location = new Point(xFive, yFive),
                            Size = new Size(100, 20),
                            Name = "CM_PName_" + a.Text + "_" + i
                        };
                        f.Text = dsd.Tables["table"].Rows.Count > 0
                            ? dsd.Tables["table"].Rows[0]["PName"].ToString()
                            : "";
                        f.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (f.Text == "")
                        {
                            f.BackColor = Color.LightPink;
                        }
                        else
                        {
                            f.BackColor = Color.Wheat;
                        }
                        yFive += 70;

                        //---------Cm Date out----------------
                        Label g = new Label
                        {
                            Location = new Point(xSix, ySix),
                            Size = new Size(100, 20),
                            Name = "CM_ReturnDate" + i,
                            Text =
                                dsd.Tables["table"].Rows.Count > 0
                                    ? dsd.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsd.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        ySix += 70;


                        DataSet dsh =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 1" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");

                        //---------SM Date in----------------
                        Label h = new Label
                        {
                            Location = new Point(xSeven, ySeven),
                            Size = new Size(100, 20),
                            Name = "SM_IssueDate" + i,
                            Text =
                                dsh.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsh.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : ""
                        };
                        ySeven += 70;




                        //---------SM ---------------
                        TextBox ii = new TextBox
                        {
                            Location = new Point(xEight, yEight),
                            Size = new Size(100, 20),
                            Name = "SM_PName_" + a.Text + "_" + i,
                            Text =
                                dsh.Tables["table"].Rows.Count > 0
                                    ? dsh.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        ii.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (ii.Text == "")
                        {
                            ii.BackColor = Color.LightPink;
                        }
                        else
                        {
                            ii.BackColor = Color.Wheat;
                        }
                        yEight += 70;

                        //---------SM Date out----------------
                        Label j = new Label
                        {
                            //  Text = dsh.Tables["table"].Rows[0]["ReturnDate"].ToString(),
                            Location = new Point(xNine, yNine),
                            Size = new Size(100, 20),
                            Name = "SM_ReturnDate" + i,
                            Text =
                                dsh.Tables["table"].Rows.Count > 0
                                    ? dsh.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsh.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        yNine += 70;


                        DataSet dsk =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 2" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");


                        //---------AM Date in----------------
                        Label K = new Label
                        {
                            Location = new Point(xten, yten),
                            Size = new Size(100, 20),
                            Name = "AM_IssueDate_" + i,
                            Text =
                                dsk.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsk.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : ""
                        };
                        yten += 70;
                        //---------AM ---------------
                        TextBox L = new TextBox
                        {
                            Location = new Point(xeleven, yeleven),
                            Size = new Size(100, 20),
                            Name = "AM_PName_" + a.Text + "_" + i,
                            Text =
                                dsk.Tables["table"].Rows.Count > 0
                                    ? dsk.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        L.MouseDown += new MouseEventHandler(this.cmMousedown);
                        yeleven += 70;
                        if (L.Text == "")
                        {
                            L.BackColor = Color.LightPink;
                        }
                        else
                        {
                            L.BackColor = Color.Wheat;
                        }
                        //---------AM Date out----------------
                        Label M = new Label
                        {
                            //   Text = dsk.Tables["table"].Rows[0]["ReturnDate"].ToString(),
                            Location = new Point(xtwelve, ytwelve),
                            Size = new Size(100, 20),
                            Name = "AM_ReturnDate" + i,
                            Text =
                                dsk.Tables["table"].Rows.Count > 0
                                    ? dsk.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsk.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        DataSet dsn =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 3" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");
                        // string abc = dsn.Tables["table"].Rows[0]["IssueDate"].ToString();
                        //---------BM Date in----------------
                        Label N = new Label
                        {
                            Location = new Point(xthirteen, ythirteen),
                            Size = new Size(100, 20),
                            Name = "BM_IssueDate" + i,
                            Text =
                                dsn.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsn.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : ""
                        };
                        ythirteen += 70;

                        //---------BM ---------------
                        TextBox o = new TextBox
                        {
                            Location = new Point(xfourteen, yfourteen),
                            Size = new Size(100, 20),
                            Name = "BM_PName_" + a.Text + "_" + i,
                            Text =
                                dsn.Tables["table"].Rows.Count > 0
                                    ? dsn.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        o.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (o.Text == "")
                        {
                            o.BackColor = Color.LightPink;
                        }
                        else
                        {
                            o.BackColor = Color.Wheat;
                        }
                        yfourteen += 70;

                        //---------BM Date out----------------
                        Label p = new Label
                        {
                            Location = new Point(xfifteen, yfifteen),
                            Size = new Size(100, 20),
                            Name = "BM_ReturnDate" + i,
                            Text =
                                dsn.Tables["table"].Rows.Count > 0
                                    ? dsn.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsn.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        yfifteen += 70;

                        DataSet dsq =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 4" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");
                        //---------PM Date in----------------
                        Label q = new Label
                        {
                            Location = new Point(xsixteen, ysixteen),
                            Size = new Size(100, 20),
                            Name = "PM_IssueDate" + i,
                            Text =
                                dsq.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsq.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : ""
                        };
                        ysixteen += 70;

                        //---------PM ---------------
                        TextBox r = new TextBox
                        {
                            Location = new Point(xseventeen, yseventeen),
                            Size = new Size(100, 20),
                            Name = "PM_PName_" + a.Text + "_" + i,
                            Text =
                                dsq.Tables["table"].Rows.Count > 0
                                    ? dsq.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        r.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (r.Text == "")
                        {
                            r.BackColor = Color.LightPink;
                        }
                        else
                        {
                            r.BackColor = Color.Wheat;
                        }
                        yseventeen += 70;

                        //---------PM Date out----------------
                        Label s = new Label
                        {
                            //   Text = dsq.Tables["table"].Rows[0]["ReturnDate"].ToString(),
                            Location = new Point(xeighteen, yeighteen),
                            Size = new Size(100, 20),
                            Name = "PM_ReturnDate" + i,
                            Text =
                                dsq.Tables["table"].Rows.Count > 0
                                    ? dsq.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsq.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        yeighteen += 70;


                        DataSet dst =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 5" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");

                        //---------PR Date in----------------
                        Label t = new Label
                        {
                            Location = new Point(xninteen, yninteen),
                            Size = new Size(100, 20),
                            Name = "PR_IssueDate" + i,
                            Text =
                                dst.Tables["table"].Rows.Count > 0
                                    ? dst.Tables["table"].Rows[0]["IssueDate"].ToString() != ""
                                        ? (DateTime.Parse(dst.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString
                                            (
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        yninteen += 70;

                        //---------PR ---------------
                        TextBox U = new TextBox
                        {
                            Location = new Point(xtwenty, ytwenty),
                            Size = new Size(100, 20),
                            Name = "PR_PName_" + a.Text + "_" + i,
                            Text =
                                dst.Tables["table"].Rows.Count > 0
                                    ? dst.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        U.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (U.Text == "")
                        {
                            U.BackColor = Color.LightPink;
                        }
                        else
                        {
                            U.BackColor = Color.Wheat;
                        }
                        ytwenty += 70;

                        //---------PR Date out----------------
                        Label v = new Label
                        {
                            Location = new Point(x21, y21),
                            Size = new Size(100, 20),
                            Name = "PR_ReturnDate" + i,
                            Text =
                                dst.Tables["table"].Rows.Count > 0
                                    ? dst.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dst.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        y21 += 70;


                        DataSet dsw =
                            vc.Select(
                                "select v.ProfileId,p.PName,v.vender_type_id,v.IssueQty,v.IssueRate,v.IssueDate,v.TotalBill,v.ReturnDate,v.ReturnQty,v.Note,v.entereddate,tp.vender_type_name" +
                                " from tblVenderOrders v, tblProfile p, tblProcessStates tp where v.ProfileId = p.ProfileId  and v.vender_type_id = 6" +
                                "and   v.vender_type_id = tp.vender_type_id and ProcessiingID ='" + a.Text + "'");


                        //---------FM Date in----------------
                        Label w = new Label
                        {
                            Location = new Point(x22, y22),
                            Size = new Size(100, 20),
                            Name = "FM_IssueDate" + i,
                            Text =
                                dsw.Tables["table"].Rows.Count > 0
                                    ? (DateTime.Parse(dsw.Tables["table"].Rows[0]["IssueDate"].ToString())).ToString(
                                        "dd-MM-yyyy")
                                    : ""
                        };
                        y22 += 70;

                        //---------fM ---------------
                        TextBox x = new TextBox
                        {
                            Location = new Point(x23, y23),
                            Size = new Size(100, 20),
                            Name = "FM_PName_" + a.Text + "_" + i,
                            Text =
                                dsw.Tables["table"].Rows.Count > 0
                                    ? dsw.Tables["table"].Rows[0]["PName"].ToString()
                                    : ""
                        };
                        x.MouseDown += new MouseEventHandler(this.cmMousedown);
                        if (x.Text == "")
                        {
                            x.BackColor = Color.LightPink;
                        }
                        else
                        {
                            x.BackColor = Color.Wheat;
                        }
                        y23 += 70;

                        //---------FM Date out----------------
                        Label y = new Label
                        {
                            Location = new Point(x24, y24),
                            Size = new Size(100, 20),
                            Name = "FM_ReturnDate" + i,
                            Text =
                                dsw.Tables["table"].Rows.Count > 0
                                    ? dsw.Tables["table"].Rows[0]["ReturnDate"].ToString() != ""
                                        ? (DateTime.Parse(dsw.Tables["table"].Rows[0]["ReturnDate"].ToString()))
                                            .ToString(
                                                "dd-MM-yyyy")
                                        : ""
                                    : ""
                        };
                        y24 += 70;

                        DataSet dsz =
                            vc.Select(
                                "select PCompanyName from tblProcessingDetail p , tblProfile i  where p.CustProfileID=i.ProfileId and ProcessiingID='" +
                                a.Text + "'");

                        //---------Company Name ---------------
                        TextBox z = new TextBox
                        {
                            Text = dsz.Tables["table"].Rows[0]["PCompanyName"].ToString(),
                            Location = new Point(x25, y25),
                            Size = new Size(150, 20),
                            Name = "PCompanyName" + i
                        };
                        //Invoke((Action)(() =>
                        //{
                        //    panel1.Controls.Add(z);
                        //    panel1.Show();
                        //}));
                        y25 += 70;

                            Invoke((Action)(() =>
                           {
                               if (i==0)
                               {
                                   panel1.Controls.Clear();
                               }
                            //    panel1.Enabled = false;
                            panel1.Controls.Add(a);
                            panel1.Controls.Add(b);
                            panel1.Controls.Add(c);
                            panel1.Controls.Add(d);
                            panel1.Controls.Add(f);
                            panel1.Controls.Add(g);
                            panel1.Controls.Add(h);
                            panel1.Controls.Add(ii);
                            panel1.Controls.Add(j);
                            panel1.Controls.Add(K);
                            panel1.Controls.Add(L);
                            panel1.Controls.Add(M);
                            panel1.Controls.Add(N);
                            panel1.Controls.Add(o);
                            panel1.Controls.Add(p);
                            panel1.Controls.Add(q);
                            panel1.Controls.Add(r);
                            panel1.Controls.Add(s);
                            panel1.Controls.Add(t);
                            panel1.Controls.Add(U);
                            panel1.Controls.Add(v);
                            panel1.Controls.Add(w);
                            panel1.Controls.Add(x);
                            panel1.Controls.Add(y);
                            panel1.Controls.Add(z);
                            panel1.Controls.Add(Linez);
                            panel1.Show();
                            //panel1.Enabled = true;


                            //Invoke((Action)(() =>
                            //{
                            //    panel1.Enabled = false;
                            }));

                    }
                        xtitle = 10;
                        ytitle = 130;
                        xOne = 0;
                        yOne = 1;
                        xTwo = 70;
                        yTwo = 1;
                        xThree = 280;
                        yThree = 1;
                        xFour = 340;
                        yFour = 1;
                        xFive = 340;
                        yFive = 20;
                        xSix = 340;
                        ySix = 40;
                        xSeven = 460;
                        ySeven = 1;
                        xEight = 460;
                        yEight = 20;
                        xNine = 460;
                        yNine = 40;
                        xten = 580;
                        yten = 1;
                        xeleven = 580;
                        yeleven = 20;
                        xtwelve = 580;
                        ytwelve = 40;
                        xthirteen = 700;
                        ythirteen = 1;
                        xfourteen = 700;
                        yfourteen = 20;
                        xfifteen = 700;
                        yfifteen = 40;
                        xsixteen = 810;
                        ysixteen = 1;
                        xseventeen = 810;
                        yseventeen = 20;
                        xeighteen = 810;
                        yeighteen = 40;
                        xninteen = 930;
                        yninteen = 1;
                        xtwenty = 930;
                         ytwenty = 20;
                         x21 = 930;
                         y21 = 40;
                         x22 = 1050;
                         y22 = 1;
                         x23 = 1050;
                         y23 = 20;
                         x24 = 1050;
                         y24 = 40;
                         x25 = 1160;
                         y25 = 1;
                         x26 = 1300;
                         y26 = 1;
                         ij = 0;
                         xline = 65;
                         yline = 0;

                    }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
                finally
                {
                       // Invoke((Action)(() =>
                       //{
                           //panel1.Enabled = true;
                           //btnReload.Enabled = true;
                      // }));

                    }
                //}));

                }
        }
    }

        private void PIDTextBox_Changed(object sender, EventArgs e)
        {
            //DataSet ds = vc.Select("select  distinct( ProcessiingID) from tblVenderOrders");
            //string inv;
            //TextBox[] Shapes = new TextBox[ds.Tables["table"].Rows.Count];
        }
        ContextMenu m = new ContextMenu();
        int vtypeNumb;
        string vtype;
        string Jobid;
        int checkreturn;
        int retjobid;
        string selecteditem;
        private void cmMousedown(object sender, MouseEventArgs e)
        {
            m.MenuItems.Clear();
            TextBox textbox = (sender as TextBox);
            if (textbox !=null)
            {
                selecteditem = textbox.Name;
                string[] info = textbox.Name.Split('_');
                vtype = info[0];
                //string desc = info[1];
                 Jobid = info[2];
                checkreturn = 1;
                //string index = info[3];
                vtypeNumb = f.findnumber("select vender_type_id from tblProcessStates where vender_type_name='" + vtype + "'");
                SqlDataReader dr;
                if (sqlcon2.State != ConnectionState.Open)
                {
                    sqlcon2.Open();
                }
                string query = "select * from tblVenderOrders where vender_type_id='" + vtypeNumb + "' and ProcessiingID='" + Jobid + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon2);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    retjobid = int.Parse(dr.GetValue(0).ToString());
                    checkreturn = 0;
                }
                if (sqlcon2.State != ConnectionState.Closed)
                {
                    sqlcon2.Close();
                }
                DataSet ds = menuSelect("select ProfileId,PName from tblProfile where PType=1 and vender_type_id='" + vtypeNumb + "'");
                
                System.Windows.Forms.MenuItem jobid = new System.Windows.Forms.MenuItem("Job ID:" + Jobid);
                System.Windows.Forms.MenuItem type = new System.Windows.Forms.MenuItem("Vender Type: " + vtype);
                System.Windows.Forms.MenuItem d = new System.Windows.Forms.MenuItem("Send To Vender");
                System.Windows.Forms.MenuItem ret= new System.Windows.Forms.MenuItem("Return");
                ret.Click += Return_Click;
                if (checkreturn == 1)
                {
                    ret.Enabled = false;
                }
                System.Windows.Forms.MenuItem mi = new System.Windows.Forms.MenuItem();
                for (int j = 0; j < ds.Tables["table"].Rows.Count; j++)
                {
                    mi = new System.Windows.Forms.MenuItem(ds.Tables["table"].Rows[j][0].ToString() + "   " + ds.Tables["table"].Rows[j][1].ToString());
                    mi.Index = int.Parse(Jobid);
                    mi.Click += menu_Click;
                    d.MenuItems.Add(mi);
                }
                m.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { jobid, type, d, ret });
                m.Show((Control)(sender), e.Location);
            }
        }

        
        void menu_Click(object sender, EventArgs e)
        {
           string  selected = ((System.Windows.Forms.MenuItem)sender).Text;
            string[] vender = selected.Split(' ');
            int vid = int.Parse(vender[0]);
            //MessageBox.Show(vender.ToString());
            DateTime dt = DateTime.Now;
            menuInsert("INSERT INTO tblVenderOrders (ProcessiingID,ProfileId,vender_type_id,IssueRate,IssueDate,Note,entereddate) VALUES ('" + Jobid + "','" + vid + "','" + vtypeNumb + "','" + "20" + "','" + DateTime.Now + "','" + "Send" + "','" + DateTime.Now + "')");

            //startthread = 1;
            //selecteditem

            foreach (Control childc in this.panel1.Controls)
            {
                if (childc is TextBox && childc.Name.Contains(selecteditem))
                {
                    childc.Text +=vender[1] ;
                    childc.Show();
                    return;
                }
                    
                //if (childc is TextBox && childc.Name.Contains("smpl"))
                //    smplratio += ((TextBox)childc).Text + ",";
            }

        }

        public void menuInsert(string s)
        {
            //startthread = 1;
            if (sqlcon2.State == ConnectionState.Closed)
            {
                sqlcon2.Open();
            }
            SqlCommand cmd = new SqlCommand(s, sqlcon2);
            cmd.ExecuteNonQuery();
            sqlcon2.Close();
        }
        void Return_Click(object sender, EventArgs e)
        {
            menuInsert( "UPDATE tblVenderOrders SET ReturnDate = '" + DateTime.Now + "'  WHERE VenderAccountid = '" + retjobid + "' ");

            //vc.Insert("INSERT INTO tblLedger (LedgerTypeID,EventID,ProfileId,CreditAmount,datetime,SpecialNOte) VALUES ('2','" + lblProcessingdetailID.Text + "','" + CombVender.SelectedValue + "','" + txtReturnBill.Text + "','" + dt + "','" + "" + "')");

            //string Query = "INSERT INTO tblVendersAccount (ProfileId,ProcessDetailID,ReturnedQty,Rate,Total,ReturnedDate) VALUES ('" + CombVender.SelectedValue + "','" + lblProcessingdetailID.Text + "','" + txtReturnQty.Text + "','" + txtRate.Text + "','" + txtReturnBill.Text + "','" + dt + "')";

        }

        public DataSet menuSelect(string s)
        {
            if (sqlcon2.State == ConnectionState.Closed)
            {
                sqlcon2.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(s, sqlcon2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (sqlcon2.State == ConnectionState.Open)
            {
                sqlcon2.Close();
            }
            return ds;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        functions f= new functions();
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == ">")
            {
                panel2.Width = 1303250;
                button1.Text = "<";
               txtJobID.Text=( f.createNumber("select top(1)ProcessiingID from tblVenderOrders order by ProcessiingID desc")).ToString();
            }
            else
            {
                panel2.Width = 0;
                button1.Text = ">";
            }
            
        }

        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            if (txtJobID.Text!="" && txtJobDesc.Text!="" && txtQty.Text!="" && txtCustomerID.Text!="" && txtCompanyName.Text!="")
            {
                vc.Insert("insert into tblProcessingDetail (ProcessiingID,SortID,Vend_orderid,ItemID,StartDate,OrderQty,LocationId,jobStates,CustProfileID) values('"+txtJobID.Text+ "','" + '1' + "','" + "1-1" + "','" + itemID + "','" + DateTime.Now + "','" + txtQty.Text + "','" + '0' + "','" + '1' + "','" + txtCustomerID.Text+ "')");
            }
            jobstate = 1;
            thdUDPServer1.Start();
        }
        public string gvar = "";
        public int itemID { get; set; }
        public string ItemDescription { get; set; }
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtJobDesc_Enter(object sender, EventArgs e)
        {
            //itemsForm Itf = new itemsForm();
            //if (Itf.ShowDialog() == DialogResult.OK)
            //{
            //    //itemID = Itf.ItemID;
            //    //txtJobDesc.Text = Itf.Gvar;
            //};

        }
        public string LoginUser { get; set; }
        public string SystemUser { get; set; }
        private void txtCustomerID_Enter(object sender, EventArgs e)
        {
            FormProfileFm fcf = new FormProfileFm(gvar,LoginUser,SystemUser);
            if (fcf.ShowDialog() == DialogResult.OK)
            {
                txtCustomerID.Text =( fcf.GlobalVar).ToString();
            };

            if (txtCustomerID.Text != "")
            {
                try
                {
                    SqlDataReader dr;
                    sqlcon.Open();
                    string query = "Select pcompanyname from tblProfile where ProfileId='" + txtCustomerID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtCompanyName.Text = (dr.GetValue(0).ToString());
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Record Found");

                    }
                    dr.Close();
                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    sqlcon.Close();
                }
            }
        }

        private void CombStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CombStatus.SelectedIndex == 0)//running
            {
                jobstate = 1;
                startthread = 1;
            }
            else if (CombStatus.SelectedIndex==1)//combpleted
            {
                jobstate = 5;
                startthread = 1;

            }
            else if (CombStatus.SelectedIndex==2)//Deliverd
            {
                jobstate = 8;
                startthread = 1;

            }


        }

        private void txtJobDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

       // Thread thdUDPServer2;

        private void button2_Click(object sender, EventArgs e)
        {
            startthread = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
