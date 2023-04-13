namespace lasticecream
{
    partial class Ledger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ledger));
            this.gridview_data = new System.Windows.Forms.DataGridView();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_tablenumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_Billnumber = new System.Windows.Forms.ComboBox();
            this.datepickerTo = new System.Windows.Forms.DateTimePicker();
            this.datepicker_from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_execute_time = new System.Windows.Forms.Button();
            this.chk_tablnumber = new System.Windows.Forms.CheckBox();
            this.chk_billnumbe = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_totalamount = new System.Windows.Forms.TextBox();
            this.txt_dscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_changeReturn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_paidamount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_grnadtotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridview_data
            // 
            this.gridview_data.AllowUserToAddRows = false;
            this.gridview_data.AllowUserToDeleteRows = false;
            this.gridview_data.AllowUserToResizeColumns = false;
            this.gridview_data.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.gridview_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridview_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridview_data.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.gridview_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridview_data.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.gridview_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDate,
            this.BillNumber,
            this.billAmount,
            this.tblenumber,
            this.ServedBy,
            this.PrintDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridview_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridview_data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridview_data.GridColor = System.Drawing.SystemColors.HotTrack;
            this.gridview_data.Location = new System.Drawing.Point(12, 139);
            this.gridview_data.Name = "gridview_data";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridview_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridview_data.RowHeadersVisible = false;
            this.gridview_data.RowHeadersWidth = 25;
            this.gridview_data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Maroon;
            this.gridview_data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridview_data.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridview_data.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            this.gridview_data.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridview_data.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gridview_data.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.gridview_data.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gridview_data.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Red;
            this.gridview_data.RowTemplate.Height = 25;
            this.gridview_data.RowTemplate.ReadOnly = true;
            this.gridview_data.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridview_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridview_data.ShowCellToolTips = false;
            this.gridview_data.ShowEditingIcon = false;
            this.gridview_data.ShowRowErrors = false;
            this.gridview_data.Size = new System.Drawing.Size(906, 542);
            this.gridview_data.TabIndex = 96;
            this.gridview_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview_data_CellClick);
            // 
            // TransactionDate
            // 
            this.TransactionDate.DataPropertyName = "billingdate";
            this.TransactionDate.HeaderText = "Tr Date";
            this.TransactionDate.Name = "TransactionDate";
            // 
            // BillNumber
            // 
            this.BillNumber.DataPropertyName = "billnumber";
            this.BillNumber.HeaderText = "Transaction #";
            this.BillNumber.Name = "BillNumber";
            // 
            // billAmount
            // 
            this.billAmount.DataPropertyName = "billamount";
            this.billAmount.HeaderText = "Amount";
            this.billAmount.Name = "billAmount";
            // 
            // tblenumber
            // 
            this.tblenumber.DataPropertyName = "table_no";
            this.tblenumber.HeaderText = "Served @";
            this.tblenumber.Name = "tblenumber";
            // 
            // ServedBy
            // 
            this.ServedBy.DataPropertyName = "WaiterName";
            this.ServedBy.HeaderText = "Served By";
            this.ServedBy.Name = "ServedBy";
            // 
            // PrintDate
            // 
            this.PrintDate.DataPropertyName = "printdatetime";
            this.PrintDate.HeaderText = "Print Date";
            this.PrintDate.Name = "PrintDate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combo_tablenumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combo_Billnumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 89);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 29);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2018, 11, 21, 23, 49, 44, 0);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Location = new System.Drawing.Point(374, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 29);
            this.button2.TabIndex = 435;
            this.button2.Text = "All";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table Number";
            // 
            // combo_tablenumber
            // 
            this.combo_tablenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_tablenumber.FormattingEnabled = true;
            this.combo_tablenumber.Location = new System.Drawing.Point(222, 43);
            this.combo_tablenumber.Name = "combo_tablenumber";
            this.combo_tablenumber.Size = new System.Drawing.Size(146, 32);
            this.combo_tablenumber.TabIndex = 2;
            this.combo_tablenumber.SelectedIndexChanged += new System.EventHandler(this.combo_tablenumber_SelectedIndexChanged);
            this.combo_tablenumber.DropDownClosed += new System.EventHandler(this.combo_tablenumber_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill Number";
            // 
            // combo_Billnumber
            // 
            this.combo_Billnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Billnumber.FormattingEnabled = true;
            this.combo_Billnumber.Location = new System.Drawing.Point(18, 43);
            this.combo_Billnumber.Name = "combo_Billnumber";
            this.combo_Billnumber.Size = new System.Drawing.Size(78, 32);
            this.combo_Billnumber.TabIndex = 0;
            this.combo_Billnumber.SelectedIndexChanged += new System.EventHandler(this.combo_Billnumber_SelectedIndexChanged);
            // 
            // datepickerTo
            // 
            this.datepickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepickerTo.Location = new System.Drawing.Point(184, 43);
            this.datepickerTo.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.datepickerTo.MinDate = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            this.datepickerTo.Name = "datepickerTo";
            this.datepickerTo.Size = new System.Drawing.Size(130, 29);
            this.datepickerTo.TabIndex = 7;
            this.datepickerTo.Value = new System.DateTime(2018, 6, 27, 0, 0, 0, 0);
            this.datepickerTo.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // datepicker_from
            // 
            this.datepicker_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepicker_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepicker_from.Location = new System.Drawing.Point(20, 47);
            this.datepicker_from.MaxDate = new System.DateTime(2018, 6, 27, 0, 0, 0, 0);
            this.datepicker_from.MinDate = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            this.datepicker_from.Name = "datepicker_from";
            this.datepicker_from.Size = new System.Drawing.Size(130, 29);
            this.datepicker_from.TabIndex = 6;
            this.datepicker_from.Value = new System.DateTime(2018, 6, 27, 0, 0, 0, 0);
            this.datepicker_from.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date From";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(-16, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 28);
            this.button1.TabIndex = 421;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_execute_time);
            this.groupBox2.Controls.Add(this.datepickerTo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.datepicker_from);
            this.groupBox2.Location = new System.Drawing.Point(501, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 89);
            this.groupBox2.TabIndex = 422;
            this.groupBox2.TabStop = false;
            this.groupBox2.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date To";
            // 
            // btn_execute_time
            // 
            this.btn_execute_time.BackColor = System.Drawing.Color.Green;
            this.btn_execute_time.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_execute_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_execute_time.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_execute_time.Location = new System.Drawing.Point(338, 43);
            this.btn_execute_time.Name = "btn_execute_time";
            this.btn_execute_time.Size = new System.Drawing.Size(111, 29);
            this.btn_execute_time.TabIndex = 8;
            this.btn_execute_time.Text = "EXECUTE";
            this.btn_execute_time.UseVisualStyleBackColor = false;
            this.btn_execute_time.Click += new System.EventHandler(this.btn_execute_time_Click);
            // 
            // chk_tablnumber
            // 
            this.chk_tablnumber.AutoSize = true;
            this.chk_tablnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_tablnumber.Location = new System.Drawing.Point(978, 390);
            this.chk_tablnumber.Name = "chk_tablnumber";
            this.chk_tablnumber.Size = new System.Drawing.Size(183, 24);
            this.chk_tablnumber.TabIndex = 9;
            this.chk_tablnumber.Text = "Include Table Number";
            this.chk_tablnumber.UseVisualStyleBackColor = true;
            this.chk_tablnumber.Visible = false;
            // 
            // chk_billnumbe
            // 
            this.chk_billnumbe.AutoSize = true;
            this.chk_billnumbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_billnumbe.Location = new System.Drawing.Point(978, 360);
            this.chk_billnumbe.Name = "chk_billnumbe";
            this.chk_billnumbe.Size = new System.Drawing.Size(164, 24);
            this.chk_billnumbe.TabIndex = 4;
            this.chk_billnumbe.Text = "Include Bill Number";
            this.chk_billnumbe.UseVisualStyleBackColor = true;
            this.chk_billnumbe.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(947, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 423;
            this.label5.Text = "Total Amount";
            this.label5.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // txt_totalamount
            // 
            this.txt_totalamount.Enabled = false;
            this.txt_totalamount.Location = new System.Drawing.Point(1072, 249);
            this.txt_totalamount.Name = "txt_totalamount";
            this.txt_totalamount.ReadOnly = true;
            this.txt_totalamount.Size = new System.Drawing.Size(111, 20);
            this.txt_totalamount.TabIndex = 424;
            this.txt_totalamount.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // txt_dscount
            // 
            this.txt_dscount.Enabled = false;
            this.txt_dscount.Location = new System.Drawing.Point(1072, 145);
            this.txt_dscount.Name = "txt_dscount";
            this.txt_dscount.ReadOnly = true;
            this.txt_dscount.Size = new System.Drawing.Size(111, 20);
            this.txt_dscount.TabIndex = 426;
            this.txt_dscount.Visible = false;
            this.txt_dscount.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(947, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 425;
            this.label6.Text = "Discount";
            this.label6.Visible = false;
            this.label6.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // txt_changeReturn
            // 
            this.txt_changeReturn.Enabled = false;
            this.txt_changeReturn.Location = new System.Drawing.Point(1072, 223);
            this.txt_changeReturn.Name = "txt_changeReturn";
            this.txt_changeReturn.ReadOnly = true;
            this.txt_changeReturn.Size = new System.Drawing.Size(111, 20);
            this.txt_changeReturn.TabIndex = 428;
            this.txt_changeReturn.Visible = false;
            this.txt_changeReturn.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(947, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 427;
            this.label8.Text = "Change Return";
            this.label8.Visible = false;
            this.label8.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // txt_paidamount
            // 
            this.txt_paidamount.Enabled = false;
            this.txt_paidamount.Location = new System.Drawing.Point(1072, 197);
            this.txt_paidamount.Name = "txt_paidamount";
            this.txt_paidamount.ReadOnly = true;
            this.txt_paidamount.Size = new System.Drawing.Size(111, 20);
            this.txt_paidamount.TabIndex = 434;
            this.txt_paidamount.Visible = false;
            this.txt_paidamount.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(947, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 433;
            this.label9.Text = "Paid Amount";
            this.label9.Visible = false;
            this.label9.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // txt_grnadtotal
            // 
            this.txt_grnadtotal.Enabled = false;
            this.txt_grnadtotal.Location = new System.Drawing.Point(1072, 171);
            this.txt_grnadtotal.Name = "txt_grnadtotal";
            this.txt_grnadtotal.ReadOnly = true;
            this.txt_grnadtotal.Size = new System.Drawing.Size(111, 20);
            this.txt_grnadtotal.TabIndex = 432;
            this.txt_grnadtotal.Visible = false;
            this.txt_grnadtotal.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(947, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 431;
            this.label10.Text = "GrandTotal";
            this.label10.Visible = false;
            this.label10.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.Green;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_print.Location = new System.Drawing.Point(1059, 304);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(104, 29);
            this.btn_print.TabIndex = 436;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Visible = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // Ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1208, 673);
            this.ControlBox = false;
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.chk_tablnumber);
            this.Controls.Add(this.txt_paidamount);
            this.Controls.Add(this.chk_billnumbe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_grnadtotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_changeReturn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_dscount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_totalamount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridview_data);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ledger";
            this.Text = "Ledger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ledger_Load);
            this.BackColorChanged += new System.EventHandler(this.txt_grnadtotal_BackColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridview_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datepicker_from;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_tablenumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_Billnumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datepickerTo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_execute_time;
        private System.Windows.Forms.CheckBox chk_billnumbe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_tablnumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_totalamount;
        private System.Windows.Forms.TextBox txt_dscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_changeReturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_paidamount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_grnadtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn billAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintDate;
    }
}