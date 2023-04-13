namespace VesterShoes.Reports
{
    partial class InvoiceSlipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceSlipForm));
            this.InvoicecrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // InvoicecrystalReportViewer
            // 
            this.InvoicecrystalReportViewer.ActiveViewIndex = -1;
            this.InvoicecrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoicecrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.InvoicecrystalReportViewer.DisplayBackgroundEdge = false;
            this.InvoicecrystalReportViewer.DisplayStatusBar = false;
            this.InvoicecrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoicecrystalReportViewer.EnableToolTips = false;
            this.InvoicecrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.InvoicecrystalReportViewer.Name = "InvoicecrystalReportViewer";
            this.InvoicecrystalReportViewer.ShowCloseButton = false;
            this.InvoicecrystalReportViewer.ShowCopyButton = false;
            this.InvoicecrystalReportViewer.ShowExportButton = false;
            this.InvoicecrystalReportViewer.ShowGroupTreeButton = false;
            this.InvoicecrystalReportViewer.ShowLogo = false;
            this.InvoicecrystalReportViewer.ShowParameterPanelButton = false;
            this.InvoicecrystalReportViewer.ShowRefreshButton = false;
            this.InvoicecrystalReportViewer.Size = new System.Drawing.Size(499, 461);
            this.InvoicecrystalReportViewer.TabIndex = 1;
            this.InvoicecrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InvoiceSlipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 461);
            this.Controls.Add(this.InvoicecrystalReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoiceSlipForm";
            this.Text = "InvoiceSlipForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InvoiceSlipForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer InvoicecrystalReportViewer;
    }
}