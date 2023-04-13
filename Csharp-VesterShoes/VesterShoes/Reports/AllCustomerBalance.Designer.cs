namespace VesterShoes.Reports
{
    partial class AllCustomerBalance
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
            this.AllCustomerBal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // AllCustomerBal
            // 
            this.AllCustomerBal.ActiveViewIndex = -1;
            this.AllCustomerBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllCustomerBal.Cursor = System.Windows.Forms.Cursors.Default;
            this.AllCustomerBal.DisplayBackgroundEdge = false;
            this.AllCustomerBal.DisplayStatusBar = false;
            this.AllCustomerBal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCustomerBal.EnableToolTips = false;
            this.AllCustomerBal.Location = new System.Drawing.Point(0, 0);
            this.AllCustomerBal.Name = "AllCustomerBal";
            this.AllCustomerBal.ShowCloseButton = false;
            this.AllCustomerBal.ShowCopyButton = false;
            this.AllCustomerBal.ShowExportButton = false;
            this.AllCustomerBal.ShowGroupTreeButton = false;
            this.AllCustomerBal.ShowLogo = false;
            this.AllCustomerBal.ShowParameterPanelButton = false;
            this.AllCustomerBal.ShowRefreshButton = false;
            this.AllCustomerBal.Size = new System.Drawing.Size(606, 464);
            this.AllCustomerBal.TabIndex = 2;
            this.AllCustomerBal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AllCustomerBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 464);
            this.Controls.Add(this.AllCustomerBal);
            this.Name = "AllCustomerBalance";
            this.Text = "AllCustomerBalance";
            this.Load += new System.EventHandler(this.AllCustomerBalance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer AllCustomerBal;
    }
}