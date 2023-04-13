namespace VesterShoes.Reports
{
    partial class ProductionCountByVTypeFrm
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
            this.CrystlReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystlReportViewer
            // 
            this.CrystlReportViewer.ActiveViewIndex = -1;
            this.CrystlReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystlReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystlReportViewer.DisplayBackgroundEdge = false;
            this.CrystlReportViewer.DisplayStatusBar = false;
            this.CrystlReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystlReportViewer.EnableToolTips = false;
            this.CrystlReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CrystlReportViewer.Name = "CrystlReportViewer";
            this.CrystlReportViewer.ShowCloseButton = false;
            this.CrystlReportViewer.ShowCopyButton = false;
            this.CrystlReportViewer.ShowExportButton = false;
            this.CrystlReportViewer.ShowGotoPageButton = false;
            this.CrystlReportViewer.ShowGroupTreeButton = false;
            this.CrystlReportViewer.ShowLogo = false;
            this.CrystlReportViewer.ShowPageNavigateButtons = false;
            this.CrystlReportViewer.ShowParameterPanelButton = false;
            this.CrystlReportViewer.ShowRefreshButton = false;
            this.CrystlReportViewer.ShowTextSearchButton = false;
            this.CrystlReportViewer.ShowZoomButton = false;
            this.CrystlReportViewer.Size = new System.Drawing.Size(800, 450);
            this.CrystlReportViewer.TabIndex = 2;
            this.CrystlReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ProductionCountByVTypeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrystlReportViewer);
            this.Name = "ProductionCountByVTypeFrm";
            this.Text = "ProductionCountByVTypeFrm";
            this.Load += new System.EventHandler(this.ProductionCountByVTypeFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystlReportViewer;
    }
}