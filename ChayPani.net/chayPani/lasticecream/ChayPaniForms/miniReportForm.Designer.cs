namespace lasticecream.ChayPaniForms
{
    partial class miniReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miniReportForm));
            this.MiniReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // MiniReportViewer
            // 
            this.MiniReportViewer.ActiveViewIndex = -1;
            this.MiniReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiniReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MiniReportViewer.DisplayStatusBar = false;
            this.MiniReportViewer.DisplayToolbar = false;
            this.MiniReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiniReportViewer.EnableToolTips = false;
            this.MiniReportViewer.Location = new System.Drawing.Point(0, 0);
            this.MiniReportViewer.Name = "MiniReportViewer";
            this.MiniReportViewer.ShowCloseButton = false;
            this.MiniReportViewer.ShowExportButton = false;
            this.MiniReportViewer.ShowGotoPageButton = false;
            this.MiniReportViewer.ShowGroupTreeButton = false;
            this.MiniReportViewer.ShowLogo = false;
            this.MiniReportViewer.ShowParameterPanelButton = false;
            this.MiniReportViewer.ShowPrintButton = false;
            this.MiniReportViewer.ShowRefreshButton = false;
            this.MiniReportViewer.ShowTextSearchButton = false;
            this.MiniReportViewer.ShowZoomButton = false;
            this.MiniReportViewer.Size = new System.Drawing.Size(545, 500);
            this.MiniReportViewer.TabIndex = 0;
            this.MiniReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.MiniReportViewer.Load += new System.EventHandler(this.MiniReportViewer_Load);
            // 
            // miniReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 500);
            this.Controls.Add(this.MiniReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "miniReportForm";
            this.Text = "miniReportForm";
            this.Load += new System.EventHandler(this.miniReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer MiniReportViewer;
    }
}