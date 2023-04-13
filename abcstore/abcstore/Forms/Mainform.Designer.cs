namespace abcstore
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProductsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewProductsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.venderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateVenderProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MnuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolUserID = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.ledgerToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.myAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1141, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pToolStripMenuItem
            // 
            this.pToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderToolStripMenuItem,
            this.openPOToolStripMenuItem,
            this.openPOToolStripMenuItem1});
            this.pToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.pToolStripMenuItem.Name = "pToolStripMenuItem";
            this.pToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.pToolStripMenuItem.Text = "Purchase";
            this.pToolStripMenuItem.Click += new System.EventHandler(this.pToolStripMenuItem_Click);
            // 
            // purchaseOrderToolStripMenuItem
            // 
            this.purchaseOrderToolStripMenuItem.Name = "purchaseOrderToolStripMenuItem";
            this.purchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.purchaseOrderToolStripMenuItem.Text = "Purchase Order Tuckshop";
            this.purchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.tuckShopToolStripMenuItem_Click);
            // 
            // openPOToolStripMenuItem
            // 
            this.openPOToolStripMenuItem.Name = "openPOToolStripMenuItem";
            this.openPOToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.openPOToolStripMenuItem.Text = "Purchase Order Mess";
            this.openPOToolStripMenuItem.Click += new System.EventHandler(this.messToolStripMenuItem_Click);
            // 
            // openPOToolStripMenuItem1
            // 
            this.openPOToolStripMenuItem1.Name = "openPOToolStripMenuItem1";
            this.openPOToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.openPOToolStripMenuItem1.Text = "Open PO";
            this.openPOToolStripMenuItem1.Click += new System.EventHandler(this.openPOToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.openInvoiceToolStripMenuItem});
            this.saleToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.saleToolStripMenuItem.Text = "Sale";
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.invoiceToolStripMenuItem.Text = "Invoice Tuck Shop";
            this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.tuckShopToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem3.Text = "Invoice Mess";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.messToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem2.Text = "Invoice Guest";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.guestInvoiceToolStripMenuItem1_Click);
            // 
            // openInvoiceToolStripMenuItem
            // 
            this.openInvoiceToolStripMenuItem.Name = "openInvoiceToolStripMenuItem";
            this.openInvoiceToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openInvoiceToolStripMenuItem.Text = "Open Invoice";
            this.openInvoiceToolStripMenuItem.Click += new System.EventHandler(this.openInvoiceToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem1,
            this.deleteProductsToolStripMenuItem1,
            this.updateProductsToolStripMenuItem1,
            this.viewProductsToolStripMenuItem1});
            this.productsToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // productsToolStripMenuItem1
            // 
            this.productsToolStripMenuItem1.Name = "productsToolStripMenuItem1";
            this.productsToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.productsToolStripMenuItem1.Text = "Add Products";
            this.productsToolStripMenuItem1.Click += new System.EventHandler(this.addProductsToolStripMenuItem_Click);
            // 
            // deleteProductsToolStripMenuItem1
            // 
            this.deleteProductsToolStripMenuItem1.Name = "deleteProductsToolStripMenuItem1";
            this.deleteProductsToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.deleteProductsToolStripMenuItem1.Text = "Delete Products";
            this.deleteProductsToolStripMenuItem1.Click += new System.EventHandler(this.deleteProductsToolStripMenuItem1_Click);
            // 
            // updateProductsToolStripMenuItem1
            // 
            this.updateProductsToolStripMenuItem1.Name = "updateProductsToolStripMenuItem1";
            this.updateProductsToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.updateProductsToolStripMenuItem1.Text = "Update Products";
            this.updateProductsToolStripMenuItem1.Click += new System.EventHandler(this.updateProductsToolStripMenuItem_Click);
            // 
            // viewProductsToolStripMenuItem1
            // 
            this.viewProductsToolStripMenuItem1.Name = "viewProductsToolStripMenuItem1";
            this.viewProductsToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.viewProductsToolStripMenuItem1.Text = "View Products";
            this.viewProductsToolStripMenuItem1.Click += new System.EventHandler(this.viewProductsToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockToolStripMenuItem,
            this.messStockToolStripMenuItem});
            this.stockToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addStockToolStripMenuItem.Text = "Tuck Shop Stock";
            // 
            // messStockToolStripMenuItem
            // 
            this.messStockToolStripMenuItem.Name = "messStockToolStripMenuItem";
            this.messStockToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.messStockToolStripMenuItem.Text = "Mess Stock";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.venderToolStripMenuItem,
            this.updateVenderProfileToolStripMenuItem});
            this.profileToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.customerToolStripMenuItem.Text = "Add Profile Customer  Profile";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.addProfileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(279, 22);
            this.toolStripMenuItem1.Text = " Update Customer Profile";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.viewOrUpdateProfileToolStripMenuItem_Click);
            // 
            // venderToolStripMenuItem
            // 
            this.venderToolStripMenuItem.Name = "venderToolStripMenuItem";
            this.venderToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.venderToolStripMenuItem.Text = "Add Vender Profile";
            this.venderToolStripMenuItem.Click += new System.EventHandler(this.addVenderToolStripMenuItem_Click);
            // 
            // updateVenderProfileToolStripMenuItem
            // 
            this.updateVenderProfileToolStripMenuItem.Name = "updateVenderProfileToolStripMenuItem";
            this.updateVenderProfileToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.updateVenderProfileToolStripMenuItem.Text = "Update Vender Profile";
            this.updateVenderProfileToolStripMenuItem.Click += new System.EventHandler(this.viewOrUpdateVenderToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(70, 22);
            this.ledgerToolStripMenuItem.Text = "Ledger";
            this.ledgerToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.aboutToolStripMenuItem.Text = "About ";
            // 
            // myAccountToolStripMenuItem
            // 
            this.myAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageRightsToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            this.myAccountToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.myAccountToolStripMenuItem.Text = "my account";
            // 
            // manageRightsToolStripMenuItem
            // 
            this.manageRightsToolStripMenuItem.Name = "manageRightsToolStripMenuItem";
            this.manageRightsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.manageRightsToolStripMenuItem.Text = "manage rights";
            this.manageRightsToolStripMenuItem.Click += new System.EventHandler(this.manageRightsToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(826, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.label2.Font = new System.Drawing.Font("Buxton Sketch", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(760, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "WELCOME";
            // 
            // MnuStrip
            // 
            this.MnuStrip.Location = new System.Drawing.Point(0, 26);
            this.MnuStrip.Name = "MnuStrip";
            this.MnuStrip.Size = new System.Drawing.Size(1141, 24);
            this.MnuStrip.TabIndex = 8;
            this.MnuStrip.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUserID,
            this.toolStripLabel1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 458);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1141, 23);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolUserID
            // 
            this.toolUserID.Name = "toolUserID";
            this.toolUserID.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(30, 15);
            this.toolStripLabel1.Text = "EXIT";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 481);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MnuStrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem venderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInvoiceToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openPOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteProductsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateProductsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewProductsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem messStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateVenderProfileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MnuStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolUserID;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem myAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}