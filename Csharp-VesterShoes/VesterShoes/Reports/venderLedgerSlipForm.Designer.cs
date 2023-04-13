namespace VesterShoes.Reports
{
    partial class venderLedgerSlipForm
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
            this.VendLedgerCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // VendLedgerCrystalReportViewer
            // 
            this.VendLedgerCrystalReportViewer.ActiveViewIndex = -1;
            this.VendLedgerCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VendLedgerCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.VendLedgerCrystalReportViewer.DisplayBackgroundEdge = false;
            this.VendLedgerCrystalReportViewer.DisplayStatusBar = false;
            this.VendLedgerCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VendLedgerCrystalReportViewer.EnableToolTips = false;
            this.VendLedgerCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.VendLedgerCrystalReportViewer.Name = "VendLedgerCrystalReportViewer";
            this.VendLedgerCrystalReportViewer.ShowCloseButton = false;
            this.VendLedgerCrystalReportViewer.ShowCopyButton = false;
            this.VendLedgerCrystalReportViewer.ShowExportButton = false;
            this.VendLedgerCrystalReportViewer.ShowGotoPageButton = false;
            this.VendLedgerCrystalReportViewer.ShowGroupTreeButton = false;
            this.VendLedgerCrystalReportViewer.ShowLogo = false;
            this.VendLedgerCrystalReportViewer.ShowPageNavigateButtons = false;
            this.VendLedgerCrystalReportViewer.ShowParameterPanelButton = false;
            this.VendLedgerCrystalReportViewer.ShowRefreshButton = false;
            this.VendLedgerCrystalReportViewer.ShowTextSearchButton = false;
            this.VendLedgerCrystalReportViewer.ShowZoomButton = false;
            this.VendLedgerCrystalReportViewer.Size = new System.Drawing.Size(385, 487);
            this.VendLedgerCrystalReportViewer.TabIndex = 1;
            this.VendLedgerCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.VendLedgerCrystalReportViewer.Load += new System.EventHandler(this.VendLedgerCrystalReportViewer_Load);
            // 
            // venderLedgerSlipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 487);
            this.Controls.Add(this.VendLedgerCrystalReportViewer);
            this.Name = "venderLedgerSlipForm";
            this.Text = "venderLedgerSlipForm";
            this.Load += new System.EventHandler(this.venderLedgerSlipForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer VendLedgerCrystalReportViewer;
    }
}