namespace ColonyMarket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ledger));
            this.gridLedgerAgent = new System.Windows.Forms.DataGridView();
            this.gridAgents = new System.Windows.Forms.DataGridView();
            this.ProfileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pcnic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErrorMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.btnLoadCustomers = new System.Windows.Forms.Button();
            this.btnLoadAgents = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLedgerAgent
            // 
            this.gridLedgerAgent.AllowUserToAddRows = false;
            this.gridLedgerAgent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Aqua;
            this.gridLedgerAgent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLedgerAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLedgerAgent.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLedgerAgent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLedgerAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLedgerAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordDate,
            this.DealID,
            this.PlotNumber,
            this.SaleNumber,
            this.Debit,
            this.Credit,
            this.BalanceAmount,
            this.Remarks});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLedgerAgent.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridLedgerAgent.Location = new System.Drawing.Point(429, 92);
            this.gridLedgerAgent.Margin = new System.Windows.Forms.Padding(4);
            this.gridLedgerAgent.Name = "gridLedgerAgent";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLedgerAgent.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridLedgerAgent.RowHeadersVisible = false;
            this.gridLedgerAgent.Size = new System.Drawing.Size(831, 460);
            this.gridLedgerAgent.TabIndex = 7;
            this.gridLedgerAgent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLedgerAgent_CellContentClick);
            // 
            // gridAgents
            // 
            this.gridAgents.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Aqua;
            this.gridAgents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAgents.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAgents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAgents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProfileID,
            this.Pcnic,
            this.PName,
            this.PMobile,
            this.PAddress});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAgents.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridAgents.Location = new System.Drawing.Point(10, 92);
            this.gridAgents.Margin = new System.Windows.Forms.Padding(4);
            this.gridAgents.Name = "gridAgents";
            this.gridAgents.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAgents.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridAgents.RowHeadersVisible = false;
            this.gridAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAgents.ShowEditingIcon = false;
            this.gridAgents.Size = new System.Drawing.Size(411, 531);
            this.gridAgents.TabIndex = 6;
            this.gridAgents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAgents_CellClick);
            // 
            // ProfileID
            // 
            this.ProfileID.DataPropertyName = "ProfileID";
            this.ProfileID.HeaderText = "ID#";
            this.ProfileID.Name = "ProfileID";
            this.ProfileID.ReadOnly = true;
            this.ProfileID.Visible = false;
            // 
            // Pcnic
            // 
            this.Pcnic.DataPropertyName = "Pcnic";
            this.Pcnic.HeaderText = "CNIC";
            this.Pcnic.Name = "Pcnic";
            this.Pcnic.ReadOnly = true;
            // 
            // PName
            // 
            this.PName.DataPropertyName = "PName";
            this.PName.HeaderText = "Name";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            // 
            // PMobile
            // 
            this.PMobile.DataPropertyName = "PMobile";
            this.PMobile.HeaderText = "Mobile#";
            this.PMobile.Name = "PMobile";
            this.PMobile.ReadOnly = true;
            // 
            // PAddress
            // 
            this.PAddress.DataPropertyName = "PAddress";
            this.PAddress.HeaderText = "Address";
            this.PAddress.Name = "PAddress";
            this.PAddress.ReadOnly = true;
            // 
            // txtErrorMsg
            // 
            this.txtErrorMsg.BackColor = System.Drawing.SystemColors.Control;
            this.txtErrorMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.txtErrorMsg.Location = new System.Drawing.Point(429, 35);
            this.txtErrorMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtErrorMsg.Name = "txtErrorMsg";
            this.txtErrorMsg.Size = new System.Drawing.Size(782, 15);
            this.txtErrorMsg.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(122, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "List of All Persons";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(801, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ledger Detail";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(464, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 24);
            this.lblName.TabIndex = 11;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.Location = new System.Drawing.Point(951, 62);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(0, 24);
            this.lblMobile.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(615, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Paid Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(825, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(1035, 575);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Balance Amount";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(705, 572);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(100, 22);
            this.txtPaidAmount.TabIndex = 16;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(918, 572);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAmount.TabIndex = 17;
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.Location = new System.Drawing.Point(1154, 572);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.Size = new System.Drawing.Size(100, 22);
            this.txtBalanceAmount.TabIndex = 18;
            // 
            // btnLoadCustomers
            // 
            this.btnLoadCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCustomers.ForeColor = System.Drawing.Color.Lime;
            this.btnLoadCustomers.Location = new System.Drawing.Point(56, 57);
            this.btnLoadCustomers.Name = "btnLoadCustomers";
            this.btnLoadCustomers.Size = new System.Drawing.Size(90, 29);
            this.btnLoadCustomers.TabIndex = 39;
            this.btnLoadCustomers.Text = "Customers";
            this.btnLoadCustomers.UseVisualStyleBackColor = true;
            this.btnLoadCustomers.Click += new System.EventHandler(this.btnLoadCustomers_Click);
            // 
            // btnLoadAgents
            // 
            this.btnLoadAgents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAgents.ForeColor = System.Drawing.Color.Lime;
            this.btnLoadAgents.Location = new System.Drawing.Point(162, 57);
            this.btnLoadAgents.Name = "btnLoadAgents";
            this.btnLoadAgents.Size = new System.Drawing.Size(90, 29);
            this.btnLoadAgents.TabIndex = 40;
            this.btnLoadAgents.Text = "Agents";
            this.btnLoadAgents.UseVisualStyleBackColor = true;
            this.btnLoadAgents.Click += new System.EventHandler(this.btnLoadAgents_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(268, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 29);
            this.button1.TabIndex = 41;
            this.button1.Text = "Partners";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // RecordDate
            // 
            this.RecordDate.DataPropertyName = "RecordDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.RecordDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.RecordDate.FillWeight = 84.89296F;
            this.RecordDate.HeaderText = "Date";
            this.RecordDate.Name = "RecordDate";
            // 
            // DealID
            // 
            this.DealID.DataPropertyName = "DealID";
            this.DealID.FillWeight = 108.1439F;
            this.DealID.HeaderText = "Deal#";
            this.DealID.Name = "DealID";
            // 
            // PlotNumber
            // 
            this.PlotNumber.DataPropertyName = "p_s_name";
            this.PlotNumber.FillWeight = 152.2843F;
            this.PlotNumber.HeaderText = "Plot#";
            this.PlotNumber.Name = "PlotNumber";
            // 
            // SaleNumber
            // 
            this.SaleNumber.DataPropertyName = "SaleNumber";
            this.SaleNumber.HeaderText = "Sale#";
            this.SaleNumber.Name = "SaleNumber";
            this.SaleNumber.Visible = false;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            this.Debit.FillWeight = 84.89296F;
            this.Debit.HeaderText = "Paid Amount (Rs)";
            this.Debit.Name = "Debit";
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.FillWeight = 84.89296F;
            this.Credit.HeaderText = "Total Amount (Rs)";
            this.Credit.Name = "Credit";
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.DataPropertyName = "BalanceAmount";
            this.BalanceAmount.HeaderText = "Remaining Amount(Rs)";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Visible = false;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.FillWeight = 84.89296F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // Ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1266, 636);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadAgents);
            this.Controls.Add(this.btnLoadCustomers);
            this.Controls.Add(this.txtBalanceAmount);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtErrorMsg);
            this.Controls.Add(this.gridLedgerAgent);
            this.Controls.Add(this.gridAgents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ledger";
            this.ShowInTaskbar = false;
            this.Text = "Ledger All";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ledger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLedgerAgent;
        private System.Windows.Forms.DataGridView gridAgents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pcnic;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAddress;
        private System.Windows.Forms.TextBox txtErrorMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.Button btnLoadCustomers;
        private System.Windows.Forms.Button btnLoadAgents;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}