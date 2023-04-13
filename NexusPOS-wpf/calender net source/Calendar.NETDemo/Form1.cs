using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.NET;
using System.Data.OleDb;
using System.Configuration;

namespace Calendar.NETDemo
{
    public partial class Form1 : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        [CustomRecurringFunction("RehabDates", "Calculates which days I should be getting Rehab")]
        private bool RehabDays(IEvent evnt, DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Friday)
            {
                if (day.Ticks >= (new DateTime(2012, 7, 1)).Ticks)
                    return false;
                return true;
            }

            return false;
        }

        private void loadEvents()
        {
            DataTable results = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Calendar", olecon);
            olecon.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(results);
            foreach (DataRow row in results.Rows)
            {               
                var ce = new CustomEvent();
                ce.IgnoreTimeComponent = false;
                ce.EventText = row["EventText"].ToString();
                DateTime dt = DateTime.Parse(row["Event_Date"].ToString());
                ce.Date = dt;
                ce.EventLengthInHours = 2f;

                int d = int.Parse(row["RecurringFrequency"].ToString());
                var rf = (RecurringFrequencies)d;
                //ce.EventColor = Color.FromArgb(120, 255, 120);
                ce.RecurringFrequency = rf;
                ce.EventFont = new Font("Verdana", 10, FontStyle.Regular);
                
                string ecolor= row["Event_Color"].ToString();
                ce.EventColor = System.Drawing.ColorTranslator.FromHtml(ecolor);

                string Tcolor = row["Text_Color"].ToString();
                ce.EventTextColor = System.Drawing.ColorTranslator.FromHtml(Tcolor);

                int Enab = int.Parse(row["Event_Enabled"].ToString());
                if (Enab == 0)
                {
                    ce.Enabled = false;
                }
                else
                {
                    ce.Enabled = true;
                }

                calendar1.AddEvent(ce);


              //  IgnoreTimeComponent = false,
            //        EventText = "Dinner",
            //        Date = new DateTime(2012, 5, 15, 18, 0, 0),
            //        EventLengthInHours = 2f,
            //        RecurringFrequency = RecurringFrequencies.None,
            //        EventFont = new Font("Verdana", 12, FontStyle.Regular),
            //        Enabled = true,
            //        EventColor = Color.FromArgb(120, 255, 120),
            //        EventTextColor = Color.Black,
            //        ThisDayForwardOnly=true
            }
        }
        public Form1()
        {
            InitializeComponent();
            loadEvents();
            //calendar1.CalendarDate = new DateTime(2012, 5, 2, 0, 0, 0);
            calendar1.CalendarDate = DateTime.Now;
            calendar1.CalendarView = CalendarViews.Month;
            calendar1.AllowEditingEvents = true;

            //var groundhogEvent = new HolidayEvent
            //                         {
            //                             Date = new DateTime(2012, 2, 2),
            //                             EventText = "Groundhog Day",
            //                             RecurringFrequency = RecurringFrequencies.Yearly
            //                         };

            //calendar1.AddEvent(groundhogEvent);

            //var exerciseEvent = new CustomEvent
            //                        {
            //                            Date = DateTime.Now,
            //                            RecurringFrequency = RecurringFrequencies.EveryMonWedFri,
            //                            EventLengthInHours = 1,
            //                            EventText = "Time for Exercise!"
            //                        };


            //calendar1.AddEvent(exerciseEvent);


            //var rehabEvent = new CustomEvent
            //    {
            //        Date = DateTime.Now,
            //        RecurringFrequency = RecurringFrequencies.Custom,
            //        EventText = "Rehab Therapy",
            //        Rank = 3,
            //        CustomRecurringFunction = RehabDays
            //    };

            //calendar1.AddEvent(rehabEvent);

            //var ce = new CustomEvent();

            //ce.EventText = "My Event";
            //ce.Date = new DateTime(2012, 4, 1);
            //ce.RecurringFrequency = RecurringFrequencies.Monthly;
            //ce.EventFont = new Font("Verdana", 12, FontStyle.Regular);
            //ce.ThisDayForwardOnly = true;
            //ce.Enabled = true;
            //calendar1.AddEvent(ce);

            //var ce2 = new HolidayEvent();

            //ce2.EventText = "test";
            //ce2.Date = new DateTime(2012, 4, 2);
            //ce2.RecurringFrequency = RecurringFrequencies.EveryMonWedFri;
            //ce2.Rank = 3;
            //calendar1.AddEvent(ce2);

            ////DataTable results = new DataTable();
            ////OleDbCommand cmd = new OleDbCommand("SELECT * FROM Calendar", olecon);
            ////olecon.Open();
            ////OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            ////adapter.Fill(results);


            ////foreach (DataRow row in results.Rows)
            ////{
            ////    //string name = row["name"].ToString();
            ////    //string description = row["description"].ToString();
            ////    //string icoFileName = row["iconFile"].ToString();
            ////    //string installScript = row["installScript"].ToString();


            ////    var ce = new CustomEvent();
            ////    ce.IgnoreTimeComponent = false;
            ////    ce.EventText = row["EventText"].ToString();
            ////    DateTime dt =DateTime.Parse( row["Event_Date"].ToString());
            ////    ce.Date = dt;
            ////    ce.EventLengthInHours = 2f;

            ////    int  d = int.Parse( row["RecurringFrequency"].ToString());
            ////    var rf = (RecurringFrequencies)d;

            ////    ce.RecurringFrequency = rf;
            ////    ce.EventFont = new Font("Verdana", 12, FontStyle.Regular);

            ////    int Enab = int.Parse(row["Event_Enabled"].ToString());
            ////    if (Enab == 0)
            ////    {
            ////        ce.Enabled = false;
            ////    }
            ////    else
            ////    {
            ////        ce.Enabled =true ;
            ////    }
                
            ////    calendar1.AddEvent(ce);
            ////}




            //var ce2 = new CustomEvent
            //    {
            //        IgnoreTimeComponent = false,
            //        EventText = "Dinner",
            //        Date = new DateTime(2012, 5, 15, 18, 0, 0),
            //        EventLengthInHours = 2f,
            //        RecurringFrequency = RecurringFrequencies.None,
            //        EventFont = new Font("Verdana", 12, FontStyle.Regular),
            //        Enabled = true,
            //        EventColor = Color.FromArgb(120, 255, 120),
            //        EventTextColor = Color.Black,
            //        ThisDayForwardOnly=true
            //    };
            //calendar1.AddEvent(ce2);
        }

        [CustomRecurringFunction("Get Monday and Wednesday", "Selects the Monday and Wednesday of each month")]
        public bool GetMondayAndWednesday(IEvent evnt, DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday || dt.DayOfWeek == DayOfWeek.Wednesday)
                return true;
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_Load(object sender, EventArgs e)
        {

        }
    }
}
