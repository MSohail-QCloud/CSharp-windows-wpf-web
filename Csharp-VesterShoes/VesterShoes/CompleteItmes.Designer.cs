namespace VesterShoes
{
    partial class CompleteItmes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompleteItmes));
            this.GridCompleteItems = new System.Windows.Forms.DataGridView();
            this.JobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridCompleteItems)).BeginInit();
            this.SuspendLayout();
            // 
            // GridCompleteItems
            // 
            this.GridCompleteItems.AllowUserToAddRows = false;
            this.GridCompleteItems.AllowUserToDeleteRows = false;
            this.GridCompleteItems.AllowUserToResizeColumns = false;
            this.GridCompleteItems.AllowUserToResizeRows = false;
            this.GridCompleteItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridCompleteItems.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.GridCompleteItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridCompleteItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCompleteItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobID,
            this.ItemsDescription,
            this.ItemsQty,
            this.ItemsRate,
            this.ItemsTotal,
            this.PCompanyName});
            this.GridCompleteItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCompleteItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridCompleteItems.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GridCompleteItems.Location = new System.Drawing.Point(0, 0);
            this.GridCompleteItems.Margin = new System.Windows.Forms.Padding(5);
            this.GridCompleteItems.Name = "GridCompleteItems";
            this.GridCompleteItems.ReadOnly = true;
            this.GridCompleteItems.RowHeadersVisible = false;
            this.GridCompleteItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridCompleteItems.Size = new System.Drawing.Size(884, 388);
            this.GridCompleteItems.TabIndex = 39;
            this.GridCompleteItems.TabStop = false;
            this.GridCompleteItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCompleteItems_CellClick);
            this.GridCompleteItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCompleteItems_CellContentClick);
            // 
            // JobID
            // 
            this.JobID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.JobID.DataPropertyName = "JobID";
            this.JobID.FillWeight = 50.76142F;
            this.JobID.HeaderText = "Job ID";
            this.JobID.Name = "JobID";
            this.JobID.ReadOnly = true;
            this.JobID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.JobID.Width = 72;
            // 
            // ItemsDescription
            // 
            this.ItemsDescription.DataPropertyName = "ItemsDescription";
            this.ItemsDescription.FillWeight = 464.205F;
            this.ItemsDescription.HeaderText = "Description";
            this.ItemsDescription.Name = "ItemsDescription";
            this.ItemsDescription.ReadOnly = true;
            // 
            // ItemsQty
            // 
            this.ItemsQty.DataPropertyName = "ItemsQty";
            this.ItemsQty.FillWeight = 15.18335F;
            this.ItemsQty.HeaderText = "Qty";
            this.ItemsQty.Name = "ItemsQty";
            this.ItemsQty.ReadOnly = true;
            // 
            // ItemsRate
            // 
            this.ItemsRate.DataPropertyName = "ItemsRate";
            this.ItemsRate.FillWeight = 19.81383F;
            this.ItemsRate.HeaderText = "Rate";
            this.ItemsRate.Name = "ItemsRate";
            this.ItemsRate.ReadOnly = true;
            // 
            // ItemsTotal
            // 
            this.ItemsTotal.DataPropertyName = "ItemsTotal";
            this.ItemsTotal.FillWeight = 26.00928F;
            this.ItemsTotal.HeaderText = "Total";
            this.ItemsTotal.Name = "ItemsTotal";
            this.ItemsTotal.ReadOnly = true;
            // 
            // PCompanyName
            // 
            this.PCompanyName.DataPropertyName = "PCompanyName";
            this.PCompanyName.FillWeight = 96.82322F;
            this.PCompanyName.HeaderText = "Company";
            this.PCompanyName.Name = "PCompanyName";
            this.PCompanyName.ReadOnly = true;
            // 
            // CompleteItmes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(884, 388);
            this.Controls.Add(this.GridCompleteItems);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompleteItmes";
            this.Text = "Complete Orders";
            this.Load += new System.EventHandler(this.CompleteItmes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridCompleteItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridCompleteItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCompanyName;
    }
}