namespace VesterShoes
{
    partial class OrderProduction
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
            this.lblOrderid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProcessiingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CombStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Vend_orderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderid
            // 
            this.lblOrderid.AutoSize = true;
            this.lblOrderid.Location = new System.Drawing.Point(137, 8);
            this.lblOrderid.Name = "lblOrderid";
            this.lblOrderid.Size = new System.Drawing.Size(56, 16);
            this.lblOrderid.TabIndex = 21;
            this.lblOrderid.Text = "Order ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Customer ID  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Order ID :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessiingID,
            this.CombStatus,
            this.Vend_orderid,
            this.ItemsDescription,
            this.OrderQty});
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(969, 515);
            this.dataGridView1.TabIndex = 19;
            // 
            // ProcessiingID
            // 
            this.ProcessiingID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessiingID.DataPropertyName = "ProcessiingID";
            this.ProcessiingID.FillWeight = 172.1355F;
            this.ProcessiingID.HeaderText = "Process ID";
            this.ProcessiingID.Name = "ProcessiingID";
            this.ProcessiingID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CombStatus
            // 
            this.CombStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CombStatus.DataPropertyName = "JobStatesDesc";
            this.CombStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.CombStatus.FillWeight = 130.1434F;
            this.CombStatus.HeaderText = "Status";
            this.CombStatus.Items.AddRange(new object[] {
            "Pending",
            "Start",
            "Stop",
            "Resume",
            "End",
            "Complete",
            "Delete",
            "Cancel"});
            this.CombStatus.Name = "CombStatus";
            this.CombStatus.ReadOnly = true;
            // 
            // Vend_orderid
            // 
            this.Vend_orderid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vend_orderid.DataPropertyName = "Vend_orderid";
            this.Vend_orderid.FillWeight = 105.1277F;
            this.Vend_orderid.HeaderText = "ID";
            this.Vend_orderid.Name = "Vend_orderid";
            // 
            // ItemsDescription
            // 
            this.ItemsDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemsDescription.DataPropertyName = "ItemsDescription";
            this.ItemsDescription.FillWeight = 109.7633F;
            this.ItemsDescription.HeaderText = "Detail";
            this.ItemsDescription.Name = "ItemsDescription";
            this.ItemsDescription.ReadOnly = true;
            // 
            // OrderQty
            // 
            this.OrderQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderQty.DataPropertyName = "OrderQty";
            this.OrderQty.FillWeight = 48.00829F;
            this.OrderQty.HeaderText = "Qty";
            this.OrderQty.Name = "OrderQty";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(137, 36);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(23, 16);
            this.lblCustomerID.TabIndex = 18;
            this.lblCustomerID.Text = "Mr";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCompanyName.Location = new System.Drawing.Point(360, 8);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(158, 24);
            this.lblCompanyName.TabIndex = 16;
            this.lblCompanyName.Text = "Company Name";
            // 
            // OrderProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 594);
            this.Controls.Add(this.lblOrderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.lblCompanyName);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderProduction";
            this.Text = "OrderProduction";
            this.Load += new System.EventHandler(this.OrderProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOrderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessiingID;
        private System.Windows.Forms.DataGridViewComboBoxColumn CombStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vend_orderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQty;
    }
}