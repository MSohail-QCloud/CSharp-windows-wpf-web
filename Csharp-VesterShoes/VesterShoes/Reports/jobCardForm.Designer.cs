namespace VesterShoes.Reports
{
    partial class jobCardForm
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
            this.JobCardcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // JobCardcrystalReportViewer
            // 
            this.JobCardcrystalReportViewer.ActiveViewIndex = -1;
            this.JobCardcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobCardcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.JobCardcrystalReportViewer.DisplayBackgroundEdge = false;
            this.JobCardcrystalReportViewer.DisplayStatusBar = false;
            this.JobCardcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobCardcrystalReportViewer.EnableToolTips = false;
            this.JobCardcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.JobCardcrystalReportViewer.Name = "JobCardcrystalReportViewer";
            this.JobCardcrystalReportViewer.ShowCloseButton = false;
            this.JobCardcrystalReportViewer.ShowCopyButton = false;
            this.JobCardcrystalReportViewer.ShowExportButton = false;
            this.JobCardcrystalReportViewer.ShowGotoPageButton = false;
            this.JobCardcrystalReportViewer.ShowGroupTreeButton = false;
            this.JobCardcrystalReportViewer.ShowLogo = false;
            this.JobCardcrystalReportViewer.ShowPageNavigateButtons = false;
            this.JobCardcrystalReportViewer.ShowParameterPanelButton = false;
            this.JobCardcrystalReportViewer.ShowRefreshButton = false;
            this.JobCardcrystalReportViewer.ShowTextSearchButton = false;
            this.JobCardcrystalReportViewer.ShowZoomButton = false;
            this.JobCardcrystalReportViewer.Size = new System.Drawing.Size(471, 354);
            this.JobCardcrystalReportViewer.TabIndex = 0;
            this.JobCardcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // jobCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 354);
            this.Controls.Add(this.JobCardcrystalReportViewer);
            this.Name = "jobCardForm";
            this.Text = "jobCardForm";
            this.Load += new System.EventHandler(this.jobCardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer JobCardcrystalReportViewer;
    }
}