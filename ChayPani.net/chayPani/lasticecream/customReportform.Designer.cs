namespace lasticecream
{
    partial class customReportform
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
            this.crystalReportVewer_custom = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportVewer_custom
            // 
            this.crystalReportVewer_custom.ActiveViewIndex = -1;
            this.crystalReportVewer_custom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportVewer_custom.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportVewer_custom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportVewer_custom.Location = new System.Drawing.Point(0, 0);
            this.crystalReportVewer_custom.Name = "crystalReportVewer_custom";
            this.crystalReportVewer_custom.ShowCloseButton = false;
            this.crystalReportVewer_custom.ShowCopyButton = false;
            this.crystalReportVewer_custom.ShowExportButton = false;
            this.crystalReportVewer_custom.ShowGotoPageButton = false;
            this.crystalReportVewer_custom.ShowGroupTreeButton = false;
            this.crystalReportVewer_custom.ShowLogo = false;
            this.crystalReportVewer_custom.ShowPageNavigateButtons = false;
            this.crystalReportVewer_custom.ShowParameterPanelButton = false;
            this.crystalReportVewer_custom.ShowTextSearchButton = false;
            this.crystalReportVewer_custom.Size = new System.Drawing.Size(1265, 540);
            this.crystalReportVewer_custom.TabIndex = 1;
            this.crystalReportVewer_custom.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportVewer_custom.Load += new System.EventHandler(this.crystalReportVewer_custom_Load);
            // 
            // customReportform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 540);
            this.Controls.Add(this.crystalReportVewer_custom);
            this.Name = "customReportform";
            this.Text = "Report Screen";
            this.Load += new System.EventHandler(this.customReportform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportVewer_custom;
    }
}