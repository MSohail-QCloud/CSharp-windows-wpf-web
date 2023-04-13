namespace ColonyMarket
{
    partial class Agentfrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agentfrm));
            this.gridAgents = new System.Windows.Forms.DataGridView();
            this.ProfileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pcnic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErrorMsg = new System.Windows.Forms.TextBox();
            this.gridLedgerAgent = new System.Windows.Forms.DataGridView();
            this.RecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label24 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtAgentAddress = new System.Windows.Forms.TextBox();
            this.txtAgentMobile = new System.Windows.Forms.TextBox();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.txtAgentCnic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcredit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdebit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.btnPaid = new System.Windows.Forms.Button();
            this.lblprofileid = new System.Windows.Forms.Label();
            this.lblpaidstatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAgents
            // 
            this.gridAgents.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.gridAgents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAgents.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.gridAgents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAgents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAgents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProfileID,
            this.Pcnic,
            this.PName,
            this.PMobile,
            this.PAddress});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAgents.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridAgents.GridColor = System.Drawing.Color.DarkSlateGray;
            this.gridAgents.Location = new System.Drawing.Point(4, 29);
            this.gridAgents.Margin = new System.Windows.Forms.Padding(4);
            this.gridAgents.Name = "gridAgents";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAgents.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridAgents.Size = new System.Drawing.Size(411, 515);
            this.gridAgents.TabIndex = 3;
            this.gridAgents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAgents_CellClick);
            // 
            // ProfileID
            // 
            this.ProfileID.DataPropertyName = "ProfileID";
            this.ProfileID.HeaderText = "ID#";
            this.ProfileID.Name = "ProfileID";
            this.ProfileID.Visible = false;
            // 
            // Pcnic
            // 
            this.Pcnic.DataPropertyName = "Pcnic";
            this.Pcnic.HeaderText = "CNIC";
            this.Pcnic.Name = "Pcnic";
            // 
            // PName
            // 
            this.PName.DataPropertyName = "PName";
            this.PName.HeaderText = "Name";
            this.PName.Name = "PName";
            // 
            // PMobile
            // 
            this.PMobile.DataPropertyName = "PMobile";
            this.PMobile.HeaderText = "Mobile#";
            this.PMobile.Name = "PMobile";
            // 
            // PAddress
            // 
            this.PAddress.DataPropertyName = "PAddress";
            this.PAddress.HeaderText = "Address";
            this.PAddress.Name = "PAddress";
            // 
            // txtErrorMsg
            // 
            this.txtErrorMsg.BackColor = System.Drawing.SystemColors.Control;
            this.txtErrorMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.txtErrorMsg.Location = new System.Drawing.Point(173, 6);
            this.txtErrorMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtErrorMsg.Name = "txtErrorMsg";
            this.txtErrorMsg.Size = new System.Drawing.Size(782, 15);
            this.txtErrorMsg.TabIndex = 4;
            // 
            // gridLedgerAgent
            // 
            this.gridLedgerAgent.AllowUserToAddRows = false;
            this.gridLedgerAgent.AllowUserToDeleteRows = false;
            this.gridLedgerAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLedgerAgent.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.gridLedgerAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLedgerAgent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridLedgerAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLedgerAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordDate,
            this.DealID,
            this.Plot,
            this.SaleNumber,
            this.Payable,
            this.Paid,
            this.BalanceAmount,
            this.Remarks});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLedgerAgent.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridLedgerAgent.Location = new System.Drawing.Point(423, 78);
            this.gridLedgerAgent.Margin = new System.Windows.Forms.Padding(4);
            this.gridLedgerAgent.Name = "gridLedgerAgent";
            this.gridLedgerAgent.Size = new System.Drawing.Size(782, 273);
            this.gridLedgerAgent.TabIndex = 5;
            // 
            // RecordDate
            // 
            this.RecordDate.DataPropertyName = "RecordDate";
            this.RecordDate.HeaderText = "Date";
            this.RecordDate.Name = "RecordDate";
            // 
            // DealID
            // 
            this.DealID.DataPropertyName = "DealID";
            this.DealID.HeaderText = "DealID";
            this.DealID.Name = "DealID";
            // 
            // Plot
            // 
            this.Plot.DataPropertyName = "Plot";
            this.Plot.HeaderText = "Plot";
            this.Plot.Name = "Plot";
            // 
            // SaleNumber
            // 
            this.SaleNumber.DataPropertyName = "SaleNumber";
            this.SaleNumber.HeaderText = "SaleNumber";
            this.SaleNumber.Name = "SaleNumber";
            // 
            // Payable
            // 
            this.Payable.DataPropertyName = "Payable";
            this.Payable.HeaderText = "Payable";
            this.Payable.Name = "Payable";
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.DataPropertyName = "BalanceAmount";
            this.BalanceAmount.HeaderText = "BalanceAmount";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Visible = false;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Cyan;
            this.label24.Location = new System.Drawing.Point(954, 28);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 16);
            this.label24.TabIndex = 80;
            this.label24.Text = "Address :";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.Cyan;
            this.label31.Location = new System.Drawing.Point(946, 428);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 16);
            this.label31.TabIndex = 82;
            this.label31.Text = "Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Location = new System.Drawing.Point(1035, 425);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(150, 22);
            this.txtBalance.TabIndex = 81;
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Cyan;
            this.label25.Location = new System.Drawing.Point(798, 28);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 16);
            this.label25.TabIndex = 79;
            this.label25.Text = "Mobile :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Cyan;
            this.label26.Location = new System.Drawing.Point(480, 28);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 16);
            this.label26.TabIndex = 78;
            this.label26.Text = "CNIC :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Cyan;
            this.label27.Location = new System.Drawing.Point(638, 28);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 16);
            this.label27.TabIndex = 77;
            this.label27.Text = "NAME :";
            // 
            // txtAgentAddress
            // 
            this.txtAgentAddress.Enabled = false;
            this.txtAgentAddress.Location = new System.Drawing.Point(948, 48);
            this.txtAgentAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentAddress.Name = "txtAgentAddress";
            this.txtAgentAddress.Size = new System.Drawing.Size(150, 22);
            this.txtAgentAddress.TabIndex = 76;
            // 
            // txtAgentMobile
            // 
            this.txtAgentMobile.Enabled = false;
            this.txtAgentMobile.Location = new System.Drawing.Point(790, 48);
            this.txtAgentMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentMobile.Name = "txtAgentMobile";
            this.txtAgentMobile.Size = new System.Drawing.Size(150, 22);
            this.txtAgentMobile.TabIndex = 75;
            // 
            // txtAgentName
            // 
            this.txtAgentName.Enabled = false;
            this.txtAgentName.Location = new System.Drawing.Point(632, 48);
            this.txtAgentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(150, 22);
            this.txtAgentName.TabIndex = 74;
            // 
            // txtAgentCnic
            // 
            this.txtAgentCnic.Enabled = false;
            this.txtAgentCnic.Location = new System.Drawing.Point(474, 48);
            this.txtAgentCnic.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentCnic.MaxLength = 13;
            this.txtAgentCnic.Name = "txtAgentCnic";
            this.txtAgentCnic.Size = new System.Drawing.Size(150, 22);
            this.txtAgentCnic.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(1040, 377);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 84;
            this.label1.Text = "Paid";
            // 
            // txtcredit
            // 
            this.txtcredit.Enabled = false;
            this.txtcredit.Location = new System.Drawing.Point(1034, 397);
            this.txtcredit.Margin = new System.Windows.Forms.Padding(4);
            this.txtcredit.Name = "txtcredit";
            this.txtcredit.Size = new System.Drawing.Size(150, 22);
            this.txtcredit.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(871, 377);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 86;
            this.label2.Text = "Payable";
            // 
            // txtdebit
            // 
            this.txtdebit.Enabled = false;
            this.txtdebit.Location = new System.Drawing.Point(861, 397);
            this.txtdebit.Margin = new System.Windows.Forms.Padding(4);
            this.txtdebit.Name = "txtdebit";
            this.txtdebit.Size = new System.Drawing.Size(150, 22);
            this.txtdebit.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(906, 457);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 88;
            this.label3.Text = "Amount to Paid";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(1035, 454);
            this.txtPaid.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(150, 22);
            this.txtPaid.TabIndex = 87;
            // 
            // btnPaid
            // 
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.ForeColor = System.Drawing.Color.Lime;
            this.btnPaid.Location = new System.Drawing.Point(1061, 496);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(113, 34);
            this.btnPaid.TabIndex = 89;
            this.btnPaid.Text = "Paid Amount";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // lblprofileid
            // 
            this.lblprofileid.AutoSize = true;
            this.lblprofileid.Location = new System.Drawing.Point(1119, 51);
            this.lblprofileid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblprofileid.Name = "lblprofileid";
            this.lblprofileid.Size = new System.Drawing.Size(0, 16);
            this.lblprofileid.TabIndex = 90;
            // 
            // lblpaidstatus
            // 
            this.lblpaidstatus.AutoSize = true;
            this.lblpaidstatus.ForeColor = System.Drawing.Color.Red;
            this.lblpaidstatus.Location = new System.Drawing.Point(858, 505);
            this.lblpaidstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpaidstatus.Name = "lblpaidstatus";
            this.lblpaidstatus.Size = new System.Drawing.Size(0, 16);
            this.lblpaidstatus.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(1019, 400);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 92;
            this.label4.Text = "-";
            // 
            // Agentfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1218, 599);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblpaidstatus);
            this.Controls.Add(this.lblprofileid);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdebit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcredit);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtAgentAddress);
            this.Controls.Add(this.txtAgentMobile);
            this.Controls.Add(this.txtAgentName);
            this.Controls.Add(this.txtAgentCnic);
            this.Controls.Add(this.gridLedgerAgent);
            this.Controls.Add(this.txtErrorMsg);
            this.Controls.Add(this.gridAgents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Agentfrm";
            this.ShowInTaskbar = false;
            this.Text = "Agents Record";
            this.Load += new System.EventHandler(this.Agentfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerAgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridAgents;
        private System.Windows.Forms.TextBox txtErrorMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pcnic;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAddress;
        private System.Windows.Forms.DataGridView gridLedgerAgent;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtAgentAddress;
        private System.Windows.Forms.TextBox txtAgentMobile;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.TextBox txtAgentCnic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcredit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdebit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label lblprofileid;
        private System.Windows.Forms.Label lblpaidstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plot;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}