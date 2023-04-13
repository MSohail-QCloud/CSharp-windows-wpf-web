using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Windows.Forms;

namespace Calendar.NET
{

    internal partial class EventDetails : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        private IEvent _event;
        private IEvent _newEvent;

        public IEvent Event
        {
            get { return _event; }
            set
            {
                _event = value;
                FillValues();
            }
        }

        public IEvent NewEvent
        {
            get { return _newEvent; }
        }

        public EventDetails()
        {
            InitializeComponent();
            PopulateComboBox();
            lblFont.Text = "Verdana , 12, FontStyle.Regular";
            pnlEventColor.BackColor = System.Drawing.Color.FromArgb(80, 170, 255);// 50aaff
            pnlTextColor.BackColor = System.Drawing.Color.White;
        }

        private void EventDetailsLoad(object sender, EventArgs e)
        {
          
        }

        private void PopulateComboBox()
        {
            cbRecurringFrequency.Items.Add("None");
            //cbRecurringFrequency.Items.Add("Custom");
            cbRecurringFrequency.Items.Add("Daily");
            cbRecurringFrequency.Items.Add("Every Monday, Wednesday and Friday");
            cbRecurringFrequency.Items.Add("Every Tuesday and Thursday");
            cbRecurringFrequency.Items.Add("Every Week Day (Mon - Fri)");
            cbRecurringFrequency.Items.Add("Every Weekend (Sat & Sun)");
            cbRecurringFrequency.Items.Add("Every Month");
            cbRecurringFrequency.Items.Add("Every week");
            cbRecurringFrequency.Items.Add("Every year");
            cbRecurringFrequency.SelectedIndex = 0;
        }

        private RecurringFrequencies StringToRecurringFrequencies(string f)
        {
            RecurringFrequencies retval = RecurringFrequencies.None;

            if (f.Equals("Custom"))
                retval = RecurringFrequencies.Custom;
            if (f.Equals("Daily"))
                retval = RecurringFrequencies.Daily;
            if (f.Equals("Every Monday, Wednesday and Friday"))
                retval = RecurringFrequencies.EveryMonWedFri;
            if (f.Equals("Every Tuesday and Thursday"))
                retval = RecurringFrequencies.EveryTueThurs;
            if (f.Equals("Every Week Day (Mon - Fri)"))
                retval = RecurringFrequencies.EveryWeekday;
            if (f.Equals("Every Weekend (Sat & Sun)"))
                retval = RecurringFrequencies.EveryWeekend;
            if (f.Equals("Every Month"))
                retval = RecurringFrequencies.Monthly;
            if (f.Equals("Every week"))
                retval = RecurringFrequencies.Weekly;
            if (f.Equals("Every year"))
                retval = RecurringFrequencies.Yearly;
            if (f.Equals("None"))
                retval = RecurringFrequencies.None;
            return retval;
        }

        private string RecurringFrequencyToString(RecurringFrequencies f)
        {
            string retval = "";

            switch (f)
            {
                case RecurringFrequencies.Custom:
                    retval = "Custom";
                    break;
                case RecurringFrequencies.Daily:
                    retval = "Daily";
                    break;
                case RecurringFrequencies.EveryMonWedFri:
                    retval = "Every Monday, Wednesday and Friday";
                    break;
                case RecurringFrequencies.EveryTueThurs:
                    retval = "Every Tuesday and Thursday";
                    break;
                case RecurringFrequencies.EveryWeekday:
                    retval = "Every Week Day (Mon - Fri)";
                    break;
                case RecurringFrequencies.EveryWeekend:
                    retval = "Every Weekend (Sat & Sun)";
                    break;
                case RecurringFrequencies.Monthly:
                    retval = "Every Month";
                    break;
                case RecurringFrequencies.None:
                    retval = "None";
                    break;
                case RecurringFrequencies.Weekly:
                    retval = "Every week";
                    break;
                case RecurringFrequencies.Yearly:
                    retval = "Every year";
                    break;
            }
            return retval;
        }

        private void FillValues()
        {
            btnOk.Text = "Update";
            txtEventName.Text = _event.EventText;
            previouseText= _event.EventText;
            DataTable results = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Calendar where EventText='"+txtEventName.Text+"'", olecon);
            olecon.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(results);
            foreach (DataRow row in results.Rows)
            {
                dtDate.Value = _event.Date;
                dtDate.CustomFormat = _event.IgnoreTimeComponent ? "M/d/yyyy" : "M/d/yyyy h:mm tt";
                cbRecurringFrequency.SelectedItem = RecurringFrequencyToString(_event.RecurringFrequency);
                chkThisDayForwardOnly.Enabled = _event.RecurringFrequency != RecurringFrequencies.None;
                chkEnabled.Checked = _event.Enabled;
                lblFont.Text = _event.EventFont.FontFamily.Name + " " + _event.EventFont.Size.ToString(CultureInfo.InvariantCulture) + "pt";
                pnlEventColor.BackColor = _event.EventColor;
                pnlTextColor.BackColor = _event.EventTextColor;
                chkIgnoreTimeComponent.Checked = _event.IgnoreTimeComponent;
                chkEnableTooltip.Checked = _event.TooltipEnabled;

                Text = char.ToUpper(_event.EventText[0]) + _event.EventText.Substring(1) + " Details";

                _newEvent = _event.Clone();


                //var ce = new CustomEvent();
                //ce.IgnoreTimeComponent = false;
                //ce.EventText = row["EventText"].ToString();
                //DateTime dt = DateTime.Parse(row["Event_Date"].ToString());
                //ce.Date = dt;
                //ce.EventLengthInHours = 2f;

                //int d = int.Parse(row["RecurringFrequency"].ToString());
                //var rf = (RecurringFrequencies)d;
                ////ce.EventColor = Color.FromArgb(120, 255, 120);
                //ce.RecurringFrequency = rf;
                ////ce.EventFont = new Font("Verdana", 10, FontStyle.Regular);

                //string ecolor = row["Event_Color"].ToString();
                //ce.EventColor = System.Drawing.ColorTranslator.FromHtml(ecolor);

                //string Tcolor = row["Text_Color"].ToString();
                //ce.EventTextColor = System.Drawing.ColorTranslator.FromHtml(Tcolor);

                //int Enab = int.Parse(row["Event_Enabled"].ToString());
                //if (Enab == 0)
                //{
                //    ce.Enabled = false;
                //}
                //else
                //{
                //    ce.Enabled = true;
                //}

            }
           

                //dtDate.Value = _event.Date;
                //dtDate.CustomFormat = _event.IgnoreTimeComponent ? "M/d/yyyy" : "M/d/yyyy h:mm tt";
                //cbRecurringFrequency.SelectedItem = RecurringFrequencyToString(_event.RecurringFrequency);
                //chkThisDayForwardOnly.Enabled = _event.RecurringFrequency != RecurringFrequencies.None;
                //chkEnabled.Checked = _event.Enabled;
                //lblFont.Text = _event.EventFont.FontFamily.Name + " " + _event.EventFont.Size.ToString(CultureInfo.InvariantCulture) + "pt";
                //pnlEventColor.BackColor = _event.EventColor;
                //pnlTextColor.BackColor = _event.EventTextColor;
                //chkIgnoreTimeComponent.Checked = _event.IgnoreTimeComponent;
                //chkEnableTooltip.Checked = _event.TooltipEnabled;

                //Text = char.ToUpper(_event.EventText[0]) + _event.EventText.Substring(1) + " Details";

                //_newEvent = _event.Clone();
            }
        string previouseText="";
        private void BtnOkClick(object sender, EventArgs e)
        {
            //_newEvent.EventText = txtEventName.Text;
            //_newEvent.Date = dtDate.Value;
            //_newEvent.Enabled = chkEnabled.Checked;
            //_newEvent.RecurringFrequency = StringToRecurringFrequencies(cbRecurringFrequency.SelectedItem.ToString());
            //_newEvent.ThisDayForwardOnly = chkThisDayForwardOnly.Checked;
            //_newEvent.IgnoreTimeComponent = chkIgnoreTimeComponent.Checked;
            //_newEvent.TooltipEnabled = chkEnableTooltip.Checked;
            if (btnOk.Text == "Update")
            {
                var hexEcolor = System.Drawing.ColorTranslator.ToHtml(pnlEventColor.BackColor);
                var hexTcolor = System.Drawing.ColorTranslator.ToHtml(pnlTextColor.BackColor);
                OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
                string abc = cbRecurringFrequency.SelectedText;
                olecon.Open();
                String query1 = "update Calendar SET EventText='" + this.txtEventName.Text + "' ,  Event_Date='" + this.dtDate.Value + "' , RecurringFrequency='" + cbRecurringFrequency.SelectedIndex + "' , Event_Color='" + hexEcolor + "' , Text_Color='" + hexTcolor + "' , Event_Enabled='" + checkenabled + "' WHERE EventText = '" + previouseText +"'" ;
                //command.CommandText = "UPDATE Tcostumers SET cfname= " + cfname + "clname= " + clname + " WHERE cid = " + cid;
                OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                cmd1.ExecuteNonQuery();
                olecon.Close();
            }
            else
            {
                var hexEcolor = System.Drawing.ColorTranslator.ToHtml(pnlEventColor.BackColor);
                var hexTcolor = System.Drawing.ColorTranslator.ToHtml(pnlTextColor.BackColor);
                OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
                string abc = cbRecurringFrequency.SelectedText;
                olecon.Open();
                String query1 = "insert into Calendar (EventText,Event_Date,RecurringFrequency,Event_Color,Text_Color,Event_Enabled) values ('" + this.txtEventName.Text + "','" + this.dtDate.Value + "','" + cbRecurringFrequency.SelectedIndex + "','" + hexEcolor + "','" + hexTcolor + "', '" + checkenabled + "')";
                OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                cmd1.ExecuteNonQuery();
                olecon.Close();
            }
            DialogResult = DialogResult.OK;
            Application.Restart();
        }

        private void clear()
        {
            txtEventName.Text = "";
        }

        private void PnlEventColorDoubleClick(object sender, EventArgs e)
        {
            //_newEvent.EventColor = System.Drawing.Color.Blue;
            //colorDialog1.Color = _newEvent.EventColor;
            colorDialog1.Color = System.Drawing.Color.Blue;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlEventColor.BackColor = colorDialog1.Color;
                //_newEvent.EventColor = colorDialog1.Color;
            }
        }

        private void PnlTextColorDoubleClick(object sender, EventArgs e)
        {
           // _newEvent.EventTextColor = System.Drawing.Color.Black;
            colorDialog1.Color = System.Drawing.Color.Black;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlTextColor.BackColor = colorDialog1.Color;
               // _newEvent.EventTextColor = colorDialog1.Color;
            }
        }

        private void ChkIgnoreTimeComponentCheckedChanged(object sender, EventArgs e)
        {
            dtDate.CustomFormat = chkIgnoreTimeComponent.Checked ? "M/d/yyyy" : "M/d/yyyy h:mm tt";
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbRecurringFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int checkenabled = 1;
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEnabled.Checked)
            {
                checkenabled = 0;
            }
            else if (chkEnabled.Checked)
            {
                checkenabled = 1;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            
            lblFont.Text ="Verdana , 12, FontStyle.Regular" ;
            //DialogResult dr = fontDialog1.ShowDialog();

            //if (dr == DialogResult.OK)
            //{
            //    _newEvent.EventFont = fontDialog1.Font;
            //}
        }

        private void chkEnableTooltip_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
