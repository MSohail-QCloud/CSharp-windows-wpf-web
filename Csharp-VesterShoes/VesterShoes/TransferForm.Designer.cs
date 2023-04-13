namespace VesterShoes
{
    partial class TransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferForm));
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRefrsh = new System.Windows.Forms.Button();
            this.rdbtnOrderTransfer = new System.Windows.Forms.RadioButton();
            this.rdbtnInvoiceTransfer = new System.Windows.Forms.RadioButton();
            this.ComboCustomer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_InvoiceDetail = new System.Windows.Forms.TabPage();
            this.dgv_invoicDetail = new System.Windows.Forms.DataGridView();
            this.tb_JobDetail = new System.Windows.Forms.TabPage();
            this.dgv_JobDetail = new System.Windows.Forms.DataGridView();
            this.tb_OrderDetail = new System.Windows.Forms.TabPage();
            this.dgv_Orderdetail = new System.Windows.Forms.DataGridView();
            this.tb_ctrl = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPreviousCustID = new System.Windows.Forms.Label();
            this.lblPreviouseCustomer = new System.Windows.Forms.Label();
            this.lblSelectedCustomerid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnInvoiceDelete = new System.Windows.Forms.Button();
            this.btnBilllRetrive = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tb_InvoiceDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoicDetail)).BeginInit();
            this.tb_JobDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_JobDetail)).BeginInit();
            this.tb_OrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orderdetail)).BeginInit();
            this.tb_ctrl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(13, 49);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(148, 26);
            this.txtOrderNumber.TabIndex = 0;
            this.txtOrderNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order #";
            // 
            // txtJobID
            // 
            this.txtJobID.Location = new System.Drawing.Point(183, 49);
            this.txtJobID.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(148, 26);
            this.txtJobID.TabIndex = 2;
            this.txtJobID.TextChanged += new System.EventHandler(this.txtJobID_TextChanged);
            this.txtJobID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobID_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "Job #";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(348, 49);
            this.txtBillNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(148, 26);
            this.txtBillNumber.TabIndex = 4;
            this.txtBillNumber.TextChanged += new System.EventHandler(this.txtBillNumber_TextChanged);
            this.txtBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillNumber_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 18);
            this.label11.TabIndex = 5;
            this.label11.Text = "Bill #";
            // 
            // btnRefrsh
            // 
            this.btnRefrsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrsh.Location = new System.Drawing.Point(585, 36);
            this.btnRefrsh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrsh.Name = "btnRefrsh";
            this.btnRefrsh.Size = new System.Drawing.Size(112, 44);
            this.btnRefrsh.TabIndex = 6;
            this.btnRefrsh.Text = "Refresh";
            this.btnRefrsh.UseVisualStyleBackColor = true;
            this.btnRefrsh.Click += new System.EventHandler(this.btnRefrsh_Click);
            // 
            // rdbtnOrderTransfer
            // 
            this.rdbtnOrderTransfer.AutoSize = true;
            this.rdbtnOrderTransfer.Location = new System.Drawing.Point(10, 23);
            this.rdbtnOrderTransfer.Name = "rdbtnOrderTransfer";
            this.rdbtnOrderTransfer.Size = new System.Drawing.Size(126, 22);
            this.rdbtnOrderTransfer.TabIndex = 8;
            this.rdbtnOrderTransfer.Text = "Order Transfer";
            this.rdbtnOrderTransfer.UseVisualStyleBackColor = true;
            this.rdbtnOrderTransfer.CheckedChanged += new System.EventHandler(this.rdbtnOrderTransfer_CheckedChanged);
            // 
            // rdbtnInvoiceTransfer
            // 
            this.rdbtnInvoiceTransfer.AutoSize = true;
            this.rdbtnInvoiceTransfer.Location = new System.Drawing.Point(10, 63);
            this.rdbtnInvoiceTransfer.Name = "rdbtnInvoiceTransfer";
            this.rdbtnInvoiceTransfer.Size = new System.Drawing.Size(130, 22);
            this.rdbtnInvoiceTransfer.TabIndex = 9;
            this.rdbtnInvoiceTransfer.Text = "InvoiceTransfer";
            this.rdbtnInvoiceTransfer.UseVisualStyleBackColor = true;
            this.rdbtnInvoiceTransfer.CheckedChanged += new System.EventHandler(this.rdbtnInvoiceTransfer_CheckedChanged);
            // 
            // ComboCustomer
            // 
            this.ComboCustomer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboCustomer.FormattingEnabled = true;
            this.ComboCustomer.Location = new System.Drawing.Point(411, 64);
            this.ComboCustomer.Name = "ComboCustomer";
            this.ComboCustomer.Size = new System.Drawing.Size(308, 30);
            this.ComboCustomer.TabIndex = 10;
            this.ComboCustomer.SelectedIndexChanged += new System.EventHandler(this.ComboCustomer_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBillNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtJobID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtOrderNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 82);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // tb_InvoiceDetail
            // 
            this.tb_InvoiceDetail.Controls.Add(this.dgv_invoicDetail);
            this.tb_InvoiceDetail.Location = new System.Drawing.Point(4, 27);
            this.tb_InvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tb_InvoiceDetail.Name = "tb_InvoiceDetail";
            this.tb_InvoiceDetail.Size = new System.Drawing.Size(900, 164);
            this.tb_InvoiceDetail.TabIndex = 3;
            this.tb_InvoiceDetail.Text = "Invoice Detail";
            this.tb_InvoiceDetail.UseVisualStyleBackColor = true;
            // 
            // dgv_invoicDetail
            // 
            this.dgv_invoicDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_invoicDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_invoicDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_invoicDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_invoicDetail.Name = "dgv_invoicDetail";
            this.dgv_invoicDetail.Size = new System.Drawing.Size(900, 164);
            this.dgv_invoicDetail.TabIndex = 1;
            // 
            // tb_JobDetail
            // 
            this.tb_JobDetail.Controls.Add(this.dgv_JobDetail);
            this.tb_JobDetail.Location = new System.Drawing.Point(4, 27);
            this.tb_JobDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tb_JobDetail.Name = "tb_JobDetail";
            this.tb_JobDetail.Size = new System.Drawing.Size(900, 164);
            this.tb_JobDetail.TabIndex = 4;
            this.tb_JobDetail.Text = "Job Detail";
            this.tb_JobDetail.UseVisualStyleBackColor = true;
            // 
            // dgv_JobDetail
            // 
            this.dgv_JobDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_JobDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_JobDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_JobDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_JobDetail.Name = "dgv_JobDetail";
            this.dgv_JobDetail.Size = new System.Drawing.Size(900, 164);
            this.dgv_JobDetail.TabIndex = 1;
            // 
            // tb_OrderDetail
            // 
            this.tb_OrderDetail.Controls.Add(this.dgv_Orderdetail);
            this.tb_OrderDetail.Location = new System.Drawing.Point(4, 27);
            this.tb_OrderDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tb_OrderDetail.Name = "tb_OrderDetail";
            this.tb_OrderDetail.Size = new System.Drawing.Size(900, 224);
            this.tb_OrderDetail.TabIndex = 2;
            this.tb_OrderDetail.Text = "Order Detail";
            this.tb_OrderDetail.UseVisualStyleBackColor = true;
            // 
            // dgv_Orderdetail
            // 
            this.dgv_Orderdetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Orderdetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Orderdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Orderdetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Orderdetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_Orderdetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Orderdetail.Name = "dgv_Orderdetail";
            this.dgv_Orderdetail.Size = new System.Drawing.Size(900, 224);
            this.dgv_Orderdetail.TabIndex = 0;
            // 
            // tb_ctrl
            // 
            this.tb_ctrl.Controls.Add(this.tb_OrderDetail);
            this.tb_ctrl.Controls.Add(this.tb_JobDetail);
            this.tb_ctrl.Controls.Add(this.tb_InvoiceDetail);
            this.tb_ctrl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ctrl.Location = new System.Drawing.Point(29, 214);
            this.tb_ctrl.Margin = new System.Windows.Forms.Padding(8);
            this.tb_ctrl.Name = "tb_ctrl";
            this.tb_ctrl.SelectedIndex = 0;
            this.tb_ctrl.Size = new System.Drawing.Size(908, 255);
            this.tb_ctrl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lblSelectedCustomerid);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnTransfer);
            this.groupBox2.Controls.Add(this.ComboCustomer);
            this.groupBox2.Controls.Add(this.rdbtnOrderTransfer);
            this.groupBox2.Controls.Add(this.rdbtnInvoiceTransfer);
            this.groupBox2.Location = new System.Drawing.Point(29, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 108);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPreviousCustID);
            this.groupBox3.Controls.Add(this.lblPreviouseCustomer);
            this.groupBox3.Location = new System.Drawing.Point(174, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 108);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Previous";
            // 
            // lblPreviousCustID
            // 
            this.lblPreviousCustID.AutoSize = true;
            this.lblPreviousCustID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousCustID.Location = new System.Drawing.Point(7, 38);
            this.lblPreviousCustID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreviousCustID.Name = "lblPreviousCustID";
            this.lblPreviousCustID.Size = new System.Drawing.Size(129, 16);
            this.lblPreviousCustID.TabIndex = 18;
            this.lblPreviousCustID.Text = "Previous CustomerID";
            // 
            // lblPreviouseCustomer
            // 
            this.lblPreviouseCustomer.AutoSize = true;
            this.lblPreviouseCustomer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviouseCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPreviouseCustomer.Location = new System.Drawing.Point(6, 69);
            this.lblPreviouseCustomer.Name = "lblPreviouseCustomer";
            this.lblPreviouseCustomer.Size = new System.Drawing.Size(29, 19);
            this.lblPreviouseCustomer.TabIndex = 14;
            this.lblPreviouseCustomer.Text = "hh";
            // 
            // lblSelectedCustomerid
            // 
            this.lblSelectedCustomerid.AutoSize = true;
            this.lblSelectedCustomerid.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCustomerid.Location = new System.Drawing.Point(569, 36);
            this.lblSelectedCustomerid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedCustomerid.Name = "lblSelectedCustomerid";
            this.lblSelectedCustomerid.Size = new System.Drawing.Size(45, 16);
            this.lblSelectedCustomerid.TabIndex = 16;
            this.lblSelectedCustomerid.Text = "Select";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Selected Customer Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Customer";
            // 
            // btnTransfer
            // 
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Location = new System.Drawing.Point(792, 45);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(112, 30);
            this.btnTransfer.TabIndex = 13;
            this.btnTransfer.Text = "Change";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnInvoiceDelete
            // 
            this.btnInvoiceDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceDelete.Location = new System.Drawing.Point(707, 36);
            this.btnInvoiceDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvoiceDelete.Name = "btnInvoiceDelete";
            this.btnInvoiceDelete.Size = new System.Drawing.Size(112, 44);
            this.btnInvoiceDelete.TabIndex = 13;
            this.btnInvoiceDelete.Text = "Bill Delete";
            this.btnInvoiceDelete.UseVisualStyleBackColor = true;
            this.btnInvoiceDelete.Click += new System.EventHandler(this.btnInvoiceDelete_Click);
            // 
            // btnBilllRetrive
            // 
            this.btnBilllRetrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilllRetrive.Location = new System.Drawing.Point(827, 36);
            this.btnBilllRetrive.Margin = new System.Windows.Forms.Padding(4);
            this.btnBilllRetrive.Name = "btnBilllRetrive";
            this.btnBilllRetrive.Size = new System.Drawing.Size(112, 44);
            this.btnBilllRetrive.TabIndex = 14;
            this.btnBilllRetrive.Text = "Bill Retrive";
            this.btnBilllRetrive.UseVisualStyleBackColor = true;
            this.btnBilllRetrive.Click += new System.EventHandler(this.btnBilllRetrive_Click);
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 476);
            this.Controls.Add(this.btnBilllRetrive);
            this.Controls.Add(this.btnInvoiceDelete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRefrsh);
            this.Controls.Add(this.tb_ctrl);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransferForm";
            this.Text = "TransferForm";
            this.Load += new System.EventHandler(this.TransferForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tb_InvoiceDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoicDetail)).EndInit();
            this.tb_JobDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_JobDetail)).EndInit();
            this.tb_OrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orderdetail)).EndInit();
            this.tb_ctrl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRefrsh;
        private System.Windows.Forms.RadioButton rdbtnOrderTransfer;
        private System.Windows.Forms.RadioButton rdbtnInvoiceTransfer;
        private System.Windows.Forms.ComboBox ComboCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tb_InvoiceDetail;
        private System.Windows.Forms.DataGridView dgv_invoicDetail;
        private System.Windows.Forms.TabPage tb_JobDetail;
        private System.Windows.Forms.DataGridView dgv_JobDetail;
        private System.Windows.Forms.TabPage tb_OrderDetail;
        private System.Windows.Forms.DataGridView dgv_Orderdetail;
        private System.Windows.Forms.TabControl tb_ctrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnInvoiceDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPreviouseCustomer;
        private System.Windows.Forms.Label lblSelectedCustomerid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblPreviousCustID;
        private System.Windows.Forms.Button btnBilllRetrive;
    }
}