namespace lasticecream
{
    partial class billsdetail
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
            this.dataGrid_listofbills = new System.Windows.Forms.DataGridView();
            this.dataGrid_billdetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listofbills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_billdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_listofbills
            // 
            this.dataGrid_listofbills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_listofbills.Location = new System.Drawing.Point(12, 32);
            this.dataGrid_listofbills.Name = "dataGrid_listofbills";
            this.dataGrid_listofbills.Size = new System.Drawing.Size(977, 264);
            this.dataGrid_listofbills.TabIndex = 0;
            this.dataGrid_listofbills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_listofbills_RowHeaderMouseClick);
            // 
            // dataGrid_billdetail
            // 
            this.dataGrid_billdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_billdetail.Location = new System.Drawing.Point(12, 420);
            this.dataGrid_billdetail.Name = "dataGrid_billdetail";
            this.dataGrid_billdetail.Size = new System.Drawing.Size(977, 87);
            this.dataGrid_billdetail.TabIndex = 1;
            this.dataGrid_billdetail.Visible = false;
            // 
            // billsdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 530);
            this.Controls.Add(this.dataGrid_billdetail);
            this.Controls.Add(this.dataGrid_listofbills);
            this.Name = "billsdetail";
            this.Text = "billsdetail";
            this.Load += new System.EventHandler(this.billsdetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listofbills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_billdetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_listofbills;
        private System.Windows.Forms.DataGridView dataGrid_billdetail;
    }
}