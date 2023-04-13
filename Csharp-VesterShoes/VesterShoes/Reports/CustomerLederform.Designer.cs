namespace VesterShoes.Reports
{
    partial class CustomerLederform
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
            this.CustLedgerCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CustLedgerCrystalReportViewer
            // 
            this.CustLedgerCrystalReportViewer.ActiveViewIndex = -1;
            this.CustLedgerCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustLedgerCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustLedgerCrystalReportViewer.DisplayBackgroundEdge = false;
            this.CustLedgerCrystalReportViewer.DisplayStatusBar = false;
            this.CustLedgerCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustLedgerCrystalReportViewer.EnableToolTips = false;
            this.CustLedgerCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CustLedgerCrystalReportViewer.Name = "CustLedgerCrystalReportViewer";
            this.CustLedgerCrystalReportViewer.ShowCloseButton = false;
            this.CustLedgerCrystalReportViewer.ShowCopyButton = false;
            this.CustLedgerCrystalReportViewer.ShowExportButton = false;
            this.CustLedgerCrystalReportViewer.ShowGroupTreeButton = false;
            this.CustLedgerCrystalReportViewer.ShowLogo = false;
            this.CustLedgerCrystalReportViewer.ShowParameterPanelButton = false;
            this.CustLedgerCrystalReportViewer.ShowRefreshButton = false;
            this.CustLedgerCrystalReportViewer.ShowTextSearchButton = false;
            this.CustLedgerCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.CustLedgerCrystalReportViewer.TabIndex = 2;
            this.CustLedgerCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CustomerLederform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustLedgerCrystalReportViewer);
            this.Name = "CustomerLederform";
            this.Text = "CustomerLederform";
            this.Load += new System.EventHandler(this.CustomerLederform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CustLedgerCrystalReportViewer;
    }
}