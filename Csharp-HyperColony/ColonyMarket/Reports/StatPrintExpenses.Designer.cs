namespace ColonyMarket.Reports
{
    partial class StatPrintExpenses
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
            this.statPrintExpensesReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // statPrintExpensesReportViewer
            // 
            this.statPrintExpensesReportViewer.ActiveViewIndex = -1;
            this.statPrintExpensesReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statPrintExpensesReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.statPrintExpensesReportViewer.DisplayBackgroundEdge = false;
            this.statPrintExpensesReportViewer.DisplayStatusBar = false;
            this.statPrintExpensesReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statPrintExpensesReportViewer.EnableToolTips = false;
            this.statPrintExpensesReportViewer.Location = new System.Drawing.Point(0, 0);
            this.statPrintExpensesReportViewer.Name = "statPrintExpensesReportViewer";
            this.statPrintExpensesReportViewer.ShowCloseButton = false;
            this.statPrintExpensesReportViewer.ShowCopyButton = false;
            this.statPrintExpensesReportViewer.ShowExportButton = false;
            this.statPrintExpensesReportViewer.ShowGotoPageButton = false;
            this.statPrintExpensesReportViewer.ShowGroupTreeButton = false;
            this.statPrintExpensesReportViewer.ShowLogo = false;
            this.statPrintExpensesReportViewer.ShowPageNavigateButtons = false;
            this.statPrintExpensesReportViewer.ShowParameterPanelButton = false;
            this.statPrintExpensesReportViewer.ShowRefreshButton = false;
            this.statPrintExpensesReportViewer.ShowTextSearchButton = false;
            this.statPrintExpensesReportViewer.ShowZoomButton = false;
            this.statPrintExpensesReportViewer.Size = new System.Drawing.Size(760, 438);
            this.statPrintExpensesReportViewer.TabIndex = 2;
            this.statPrintExpensesReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StatPrintExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 438);
            this.Controls.Add(this.statPrintExpensesReportViewer);
            this.Name = "StatPrintExpenses";
            this.Text = "StatPrintExpenses";
            this.Load += new System.EventHandler(this.StatPrintExpenses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer statPrintExpensesReportViewer;
    }
}