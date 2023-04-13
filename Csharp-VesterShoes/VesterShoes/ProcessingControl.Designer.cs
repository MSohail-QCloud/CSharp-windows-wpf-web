namespace VesterShoes
{
    partial class ProcessingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessingControl));
            this.label1 = new System.Windows.Forms.Label();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblItemDescription = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblQ = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProcessingdetailID = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblItemID = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblTrackID = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddNextStep = new System.Windows.Forms.Button();
            this.btnAddVender = new System.Windows.Forms.Button();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtPickerIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNextStepRemainingQty = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtNextStepQty = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.lblVenderId = new System.Windows.Forms.Label();
            this.CombVender = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.CombNextStemp = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dtReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReturnQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBalanceQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReturnBill = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSortID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblModifyId = new System.Windows.Forms.Label();
            this.lblVesterTypeid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Customer ID  :";
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistory.Location = new System.Drawing.Point(0, 22);
            this.gridHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(832, 369);
            this.gridHistory.TabIndex = 19;
            this.gridHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistory_CellClick);
            this.gridHistory.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridHistory_RowHeaderMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Order ID :";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCompanyName.Location = new System.Drawing.Point(91, 7);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(158, 24);
            this.lblCompanyName.TabIndex = 16;
            this.lblCompanyName.Text = "Company Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblItemDescription);
            this.groupBox1.Controls.Add(this.lblQty);
            this.groupBox1.Controls.Add(this.lblQ);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblProcessingdetailID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(455, 119);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.BackColor = System.Drawing.SystemColors.Control;
            this.lblItemDescription.Enabled = false;
            this.lblItemDescription.Location = new System.Drawing.Point(0, 46);
            this.lblItemDescription.Multiline = true;
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(443, 64);
            this.lblItemDescription.TabIndex = 42;
            this.lblItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(398, 20);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(35, 19);
            this.lblQty.TabIndex = 30;
            this.lblQty.Text = "Qty";
            // 
            // lblQ
            // 
            this.lblQ.AutoSize = true;
            this.lblQ.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ.Location = new System.Drawing.Point(355, 20);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(35, 19);
            this.lblQ.TabIndex = 27;
            this.lblQ.Text = "Qty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Process ID  :";
            // 
            // lblProcessingdetailID
            // 
            this.lblProcessingdetailID.AutoSize = true;
            this.lblProcessingdetailID.Location = new System.Drawing.Point(84, 20);
            this.lblProcessingdetailID.Name = "lblProcessingdetailID";
            this.lblProcessingdetailID.Size = new System.Drawing.Size(66, 16);
            this.lblProcessingdetailID.TabIndex = 41;
            this.lblProcessingdetailID.Text = "Processid";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(467, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 36;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(258, 100);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(20, 16);
            this.lblItemID.TabIndex = 40;
            this.lblItemID.Text = "ID";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(191, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 16);
            this.label26.TabIndex = 39;
            this.label26.Text = "Item ID  :";
            // 
            // lblTrackID
            // 
            this.lblTrackID.AutoSize = true;
            this.lblTrackID.Location = new System.Drawing.Point(166, 100);
            this.lblTrackID.Name = "lblTrackID";
            this.lblTrackID.Size = new System.Drawing.Size(20, 16);
            this.lblTrackID.TabIndex = 38;
            this.lblTrackID.Text = "ID";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(92, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 16);
            this.label25.TabIndex = 37;
            this.label25.Text = "Track ID  :";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(190, 60);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(84, 16);
            this.lblCustomerID.TabIndex = 24;
            this.lblCustomerID.Text = "Customer ID ";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(175, 38);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(21, 18);
            this.lblOrderID.TabIndex = 22;
            this.lblOrderID.Text = "id";
            // 
            // btnStep
            // 
            this.btnStep.BackColor = System.Drawing.Color.Lime;
            this.btnStep.Enabled = false;
            this.btnStep.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStep.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnStep.Location = new System.Drawing.Point(71, 268);
            this.btnStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(172, 29);
            this.btnStep.TabIndex = 29;
            this.btnStep.Text = "Proceed to Next";
            this.btnStep.UseVisualStyleBackColor = false;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddNextStep);
            this.groupBox3.Controls.Add(this.btnAddVender);
            this.groupBox3.Controls.Add(this.txtBill);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtNote);
            this.groupBox3.Controls.Add(this.dtPickerIssueDate);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtRate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtNextStepRemainingQty);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.txtNextStepQty);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.lblVenderId);
            this.groupBox3.Controls.Add(this.CombVender);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.CombNextStemp);
            this.groupBox3.Controls.Add(this.btnStep);
            this.groupBox3.Location = new System.Drawing.Point(552, 35);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(304, 305);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Next Step";
            this.groupBox3.Visible = false;
            // 
            // btnAddNextStep
            // 
            this.btnAddNextStep.BackgroundImage = global::VesterShoes.Properties.Resources.addicon;
            this.btnAddNextStep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNextStep.FlatAppearance.BorderSize = 0;
            this.btnAddNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNextStep.Location = new System.Drawing.Point(254, 258);
            this.btnAddNextStep.Name = "btnAddNextStep";
            this.btnAddNextStep.Size = new System.Drawing.Size(40, 40);
            this.btnAddNextStep.TabIndex = 54;
            this.btnAddNextStep.UseVisualStyleBackColor = true;
            this.btnAddNextStep.Click += new System.EventHandler(this.btnAddNextStep_Click);
            // 
            // btnAddVender
            // 
            this.btnAddVender.BackColor = System.Drawing.Color.Transparent;
            this.btnAddVender.BackgroundImage = global::VesterShoes.Properties.Resources.addiconblue;
            this.btnAddVender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddVender.FlatAppearance.BorderSize = 0;
            this.btnAddVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVender.Location = new System.Drawing.Point(230, 38);
            this.btnAddVender.Name = "btnAddVender";
            this.btnAddVender.Size = new System.Drawing.Size(47, 43);
            this.btnAddVender.TabIndex = 53;
            this.btnAddVender.UseVisualStyleBackColor = false;
            this.btnAddVender.Click += new System.EventHandler(this.btnAddVender_Click);
            // 
            // txtBill
            // 
            this.txtBill.Enabled = false;
            this.txtBill.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBill.Location = new System.Drawing.Point(218, 134);
            this.txtBill.Name = "txtBill";
            this.txtBill.ReadOnly = true;
            this.txtBill.Size = new System.Drawing.Size(59, 29);
            this.txtBill.TabIndex = 52;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(189, 142);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 16);
            this.label24.TabIndex = 51;
            this.label24.Text = "Bill";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 242);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 19);
            this.label23.TabIndex = 50;
            this.label23.Text = "Note :";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(69, 200);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(174, 61);
            this.txtNote.TabIndex = 49;
            // 
            // dtPickerIssueDate
            // 
            this.dtPickerIssueDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtPickerIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerIssueDate.Location = new System.Drawing.Point(118, 172);
            this.dtPickerIssueDate.Name = "dtPickerIssueDate";
            this.dtPickerIssueDate.Size = new System.Drawing.Size(159, 22);
            this.dtPickerIssueDate.TabIndex = 47;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 175);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 19);
            this.label22.TabIndex = 46;
            this.label22.Text = "OrderDate:";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(37, 134);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(75, 29);
            this.txtRate.TabIndex = 44;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Rate";
            // 
            // txtNextStepRemainingQty
            // 
            this.txtNextStepRemainingQty.Enabled = false;
            this.txtNextStepRemainingQty.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextStepRemainingQty.Location = new System.Drawing.Point(218, 89);
            this.txtNextStepRemainingQty.Name = "txtNextStepRemainingQty";
            this.txtNextStepRemainingQty.ReadOnly = true;
            this.txtNextStepRemainingQty.Size = new System.Drawing.Size(59, 29);
            this.txtNextStepRemainingQty.TabIndex = 42;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(116, 97);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(102, 16);
            this.label34.TabIndex = 41;
            this.label34.Text = "Remaining Qty";
            // 
            // txtNextStepQty
            // 
            this.txtNextStepQty.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextStepQty.Location = new System.Drawing.Point(37, 91);
            this.txtNextStepQty.Name = "txtNextStepQty";
            this.txtNextStepQty.Size = new System.Drawing.Size(75, 29);
            this.txtNextStepQty.TabIndex = 40;
            this.txtNextStepQty.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtNextStepQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(2, 97);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 16);
            this.label33.TabIndex = 37;
            this.label33.Text = "Qty";
            this.label33.Click += new System.EventHandler(this.label33_Click);
            // 
            // lblVenderId
            // 
            this.lblVenderId.AutoSize = true;
            this.lblVenderId.Location = new System.Drawing.Point(32, 38);
            this.lblVenderId.Name = "lblVenderId";
            this.lblVenderId.Size = new System.Drawing.Size(0, 16);
            this.lblVenderId.TabIndex = 39;
            // 
            // CombVender
            // 
            this.CombVender.FormattingEnabled = true;
            this.CombVender.Location = new System.Drawing.Point(71, 58);
            this.CombVender.Name = "CombVender";
            this.CombVender.Size = new System.Drawing.Size(147, 24);
            this.CombVender.TabIndex = 38;
            this.CombVender.SelectedIndexChanged += new System.EventHandler(this.CombVender_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(1, 59);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(61, 16);
            this.label32.TabIndex = 37;
            this.label32.Text = "Vender :";
            // 
            // CombNextStemp
            // 
            this.CombNextStemp.FormattingEnabled = true;
            this.CombNextStemp.Location = new System.Drawing.Point(71, 22);
            this.CombNextStemp.Name = "CombNextStemp";
            this.CombNextStemp.Size = new System.Drawing.Size(147, 24);
            this.CombNextStemp.TabIndex = 36;
            this.CombNextStemp.SelectedIndexChanged += new System.EventHandler(this.CombNextStemp_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridHistory);
            this.groupBox4.Location = new System.Drawing.Point(8, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(838, 391);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "History";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.GreenYellow;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturn.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnReturn.Location = new System.Drawing.Point(623, 485);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(101, 29);
            this.btnReturn.TabIndex = 41;
            this.btnReturn.Text = "Returned";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dtReturnDate
            // 
            this.dtReturnDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReturnDate.Location = new System.Drawing.Point(694, 371);
            this.dtReturnDate.Name = "dtReturnDate";
            this.dtReturnDate.Size = new System.Drawing.Size(172, 22);
            this.dtReturnDate.TabIndex = 54;
            this.dtReturnDate.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(553, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 19);
            this.label5.TabIndex = 53;
            this.label5.Text = "Return Date:";
            this.label5.Visible = false;
            // 
            // txtReturnQty
            // 
            this.txtReturnQty.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnQty.Location = new System.Drawing.Point(609, 410);
            this.txtReturnQty.Name = "txtReturnQty";
            this.txtReturnQty.Size = new System.Drawing.Size(66, 29);
            this.txtReturnQty.TabIndex = 54;
            this.txtReturnQty.Visible = false;
            this.txtReturnQty.TextChanged += new System.EventHandler(this.txtReturnQty_TextChanged);
            this.txtReturnQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReturnQty_KeyPress);
            this.txtReturnQty.Leave += new System.EventHandler(this.txtReturnQty_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(559, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Qty";
            this.label6.Visible = false;
            // 
            // txtBalanceQty
            // 
            this.txtBalanceQty.Enabled = false;
            this.txtBalanceQty.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceQty.Location = new System.Drawing.Point(770, 408);
            this.txtBalanceQty.Name = "txtBalanceQty";
            this.txtBalanceQty.ReadOnly = true;
            this.txtBalanceQty.Size = new System.Drawing.Size(59, 29);
            this.txtBalanceQty.TabIndex = 57;
            this.txtBalanceQty.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(684, 418);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 55;
            this.label10.Text = "Balance Qty";
            this.label10.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(609, 449);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(66, 29);
            this.textBox4.TabIndex = 58;
            this.textBox4.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(553, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "Waste";
            this.label11.Visible = false;
            // 
            // txtReturnBill
            // 
            this.txtReturnBill.Enabled = false;
            this.txtReturnBill.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnBill.Location = new System.Drawing.Point(770, 447);
            this.txtReturnBill.Name = "txtReturnBill";
            this.txtReturnBill.ReadOnly = true;
            this.txtReturnBill.Size = new System.Drawing.Size(59, 29);
            this.txtReturnBill.TabIndex = 54;
            this.txtReturnBill.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(740, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 16);
            this.label9.TabIndex = 53;
            this.label9.Text = "Bill";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblSortID
            // 
            this.lblSortID.AutoSize = true;
            this.lblSortID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortID.Location = new System.Drawing.Point(217, 38);
            this.lblSortID.Name = "lblSortID";
            this.lblSortID.Size = new System.Drawing.Size(67, 18);
            this.lblSortID.TabIndex = 59;
            this.lblSortID.Text = "lblSortID";
            this.lblSortID.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(467, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 37;
            this.button1.Text = "Open Order";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.BackColor = System.Drawing.Color.Silver;
            this.btnDuplicate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDuplicate.Enabled = false;
            this.btnDuplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicate.ForeColor = System.Drawing.Color.Black;
            this.btnDuplicate.Location = new System.Drawing.Point(467, 19);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(75, 47);
            this.btnDuplicate.TabIndex = 60;
            this.btnDuplicate.Text = "Duplicat Print";
            this.btnDuplicate.UseVisualStyleBackColor = false;
            this.btnDuplicate.Visible = false;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Lime;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnModify.Location = new System.Drawing.Point(623, 521);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(101, 29);
            this.btnModify.TabIndex = 55;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lblModifyId
            // 
            this.lblModifyId.AutoSize = true;
            this.lblModifyId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifyId.Location = new System.Drawing.Point(741, 527);
            this.lblModifyId.Name = "lblModifyId";
            this.lblModifyId.Size = new System.Drawing.Size(20, 16);
            this.lblModifyId.TabIndex = 61;
            this.lblModifyId.Text = "Id";
            this.lblModifyId.Visible = false;
            // 
            // lblVesterTypeid
            // 
            this.lblVesterTypeid.AutoSize = true;
            this.lblVesterTypeid.Location = new System.Drawing.Point(254, 84);
            this.lblVesterTypeid.Name = "lblVesterTypeid";
            this.lblVesterTypeid.Size = new System.Drawing.Size(29, 16);
            this.lblVesterTypeid.TabIndex = 63;
            this.lblVesterTypeid.Text = "VID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "VesterID  :";
            // 
            // ProcessingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblVesterTypeid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblModifyId);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblTrackID);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSortID);
            this.Controls.Add(this.txtReturnBill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBalanceQty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtReturnQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtReturnDate);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProcessingControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessingControl";
            this.Load += new System.EventHandler(this.ProcessingControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CombNextStemp;
        private System.Windows.Forms.ComboBox CombVender;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblVenderId;
        private System.Windows.Forms.TextBox txtNextStepQty;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtNextStepRemainingQty;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DateTimePicker dtPickerIssueDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrackID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DateTimePicker dtReturnDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReturnQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBalanceQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblProcessingdetailID;
        private System.Windows.Forms.TextBox txtReturnBill;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSortID;
        private System.Windows.Forms.Button btnAddVender;
        private System.Windows.Forms.Button btnAddNextStep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.TextBox lblItemDescription;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblModifyId;
        private System.Windows.Forms.Label lblVesterTypeid;
        private System.Windows.Forms.Label label8;
    }
}