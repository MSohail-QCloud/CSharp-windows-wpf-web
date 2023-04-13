namespace VesterShoes
{
    partial class formOrderModificationfm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrderModificationfm));
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderid = new System.Windows.Forms.TextBox();
            this.txtProcessid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemDetail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProcessJobid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSortid = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblitemid = new System.Windows.Forms.Label();
            this.comboJobStatus = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtJobStartDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblerrormsg = new System.Windows.Forms.Label();
            this.btnjobcardPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Lime;
            this.lblCompanyName.Location = new System.Drawing.Point(10, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(0, 24);
            this.lblCompanyName.TabIndex = 0;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.ForeColor = System.Drawing.Color.Cyan;
            this.lblCustomerID.Location = new System.Drawing.Point(143, 88);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(23, 16);
            this.lblCustomerID.TabIndex = 2;
            this.lblCustomerID.Text = "Mr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer ID  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order ID :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtOrderid
            // 
            this.txtOrderid.Location = new System.Drawing.Point(119, 61);
            this.txtOrderid.Name = "txtOrderid";
            this.txtOrderid.Size = new System.Drawing.Size(47, 22);
            this.txtOrderid.TabIndex = 16;
            this.txtOrderid.TextChanged += new System.EventHandler(this.txtOrderid_TextChanged);
            this.txtOrderid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderid_KeyDown);
            this.txtOrderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderid_KeyPress);
            // 
            // txtProcessid
            // 
            this.txtProcessid.Location = new System.Drawing.Point(339, 61);
            this.txtProcessid.Name = "txtProcessid";
            this.txtProcessid.Size = new System.Drawing.Size(100, 22);
            this.txtProcessid.TabIndex = 18;
            this.txtProcessid.TextChanged += new System.EventHandler(this.txtProcessid_TextChanged);
            this.txtProcessid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessid_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(249, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Process ID :";
            // 
            // txtItemDetail
            // 
            this.txtItemDetail.Location = new System.Drawing.Point(174, 42);
            this.txtItemDetail.Name = "txtItemDetail";
            this.txtItemDetail.Size = new System.Drawing.Size(727, 22);
            this.txtItemDetail.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Cyan;
            this.label7.Location = new System.Drawing.Point(40, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Item Detail:";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(130, 77);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(115, 22);
            this.txtQty.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(85, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Qty";
            // 
            // txtRate
            // 
            this.txtRate.Enabled = false;
            this.txtRate.Location = new System.Drawing.Point(337, 77);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 22);
            this.txtRate.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Cyan;
            this.label9.Location = new System.Drawing.Point(288, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Rate :";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(513, 77);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Cyan;
            this.label10.Location = new System.Drawing.Point(458, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Total :";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.Location = new System.Drawing.Point(130, 105);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(115, 22);
            this.txtOrderDate.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Cyan;
            this.label11.Location = new System.Drawing.Point(35, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Order Date :";
            // 
            // txtProcessJobid
            // 
            this.txtProcessJobid.Enabled = false;
            this.txtProcessJobid.Location = new System.Drawing.Point(337, 105);
            this.txtProcessJobid.Name = "txtProcessJobid";
            this.txtProcessJobid.Size = new System.Drawing.Size(100, 22);
            this.txtProcessJobid.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Cyan;
            this.label12.Location = new System.Drawing.Point(251, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "Process ID :";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Cyan;
            this.label13.Location = new System.Drawing.Point(166, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 22);
            this.label13.TabIndex = 31;
            this.label13.Text = "-";
            // 
            // txtSortid
            // 
            this.txtSortid.Location = new System.Drawing.Point(181, 61);
            this.txtSortid.Name = "txtSortid";
            this.txtSortid.Size = new System.Drawing.Size(47, 22);
            this.txtSortid.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblitemid);
            this.groupBox1.Controls.Add(this.comboJobStatus);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtInvoiceID);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtJobStartDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblCompanyName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtItemDetail);
            this.groupBox1.Controls.Add(this.txtProcessJobid);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtOrderDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(29, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(997, 170);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(892, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 28);
            this.button1.TabIndex = 39;
            this.button1.Text = "Update Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblitemid
            // 
            this.lblitemid.AutoSize = true;
            this.lblitemid.ForeColor = System.Drawing.Color.Cyan;
            this.lblitemid.Location = new System.Drawing.Point(641, 77);
            this.lblitemid.Name = "lblitemid";
            this.lblitemid.Size = new System.Drawing.Size(43, 16);
            this.lblitemid.TabIndex = 38;
            this.lblitemid.Text = "itemid";
            this.lblitemid.Visible = false;
            // 
            // comboJobStatus
            // 
            this.comboJobStatus.FormattingEnabled = true;
            this.comboJobStatus.Location = new System.Drawing.Point(513, 105);
            this.comboJobStatus.Name = "comboJobStatus";
            this.comboJobStatus.Size = new System.Drawing.Size(100, 24);
            this.comboJobStatus.TabIndex = 37;
            this.comboJobStatus.SelectedIndexChanged += new System.EventHandler(this.comboJobStatus_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Cyan;
            this.label16.Location = new System.Drawing.Point(458, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 16);
            this.label16.TabIndex = 36;
            this.label16.Text = "Status";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Enabled = false;
            this.txtInvoiceID.Location = new System.Drawing.Point(337, 133);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(100, 22);
            this.txtInvoiceID.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Cyan;
            this.label15.Location = new System.Drawing.Point(260, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 16);
            this.label15.TabIndex = 33;
            this.label15.Text = "Invoice ID :";
            // 
            // txtJobStartDate
            // 
            this.txtJobStartDate.Enabled = false;
            this.txtJobStartDate.Location = new System.Drawing.Point(130, 133);
            this.txtJobStartDate.Name = "txtJobStartDate";
            this.txtJobStartDate.Size = new System.Drawing.Size(115, 22);
            this.txtJobStartDate.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Cyan;
            this.label14.Location = new System.Drawing.Point(15, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 16);
            this.label14.TabIndex = 31;
            this.label14.Text = "Job Start Date :";
            // 
            // lblerrormsg
            // 
            this.lblerrormsg.AutoSize = true;
            this.lblerrormsg.ForeColor = System.Drawing.Color.Red;
            this.lblerrormsg.Location = new System.Drawing.Point(16, 9);
            this.lblerrormsg.Name = "lblerrormsg";
            this.lblerrormsg.Size = new System.Drawing.Size(0, 16);
            this.lblerrormsg.TabIndex = 34;
            // 
            // btnjobcardPrint
            // 
            this.btnjobcardPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnjobcardPrint.ForeColor = System.Drawing.Color.Lime;
            this.btnjobcardPrint.Location = new System.Drawing.Point(864, 87);
            this.btnjobcardPrint.Name = "btnjobcardPrint";
            this.btnjobcardPrint.Size = new System.Drawing.Size(162, 28);
            this.btnjobcardPrint.TabIndex = 40;
            this.btnjobcardPrint.Text = "Duplicate Job Card";
            this.btnjobcardPrint.UseVisualStyleBackColor = true;
            this.btnjobcardPrint.Click += new System.EventHandler(this.btnjobcardPrint_Click);
            // 
            // formOrderModificationfm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1073, 356);
            this.Controls.Add(this.btnjobcardPrint);
            this.Controls.Add(this.lblerrormsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSortid);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtProcessid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formOrderModificationfm";
            this.ShowInTaskbar = false;
            this.Text = "Order Modification";
            this.Load += new System.EventHandler(this.formOrderModificationfm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderid;
        private System.Windows.Forms.TextBox txtProcessid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtItemDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProcessJobid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSortid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtJobStartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboJobStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblitemid;
        private System.Windows.Forms.Label lblerrormsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnjobcardPrint;
    }
}