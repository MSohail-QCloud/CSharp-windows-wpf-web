namespace lasticecream
{
    partial class Purchaseinfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchaseinfor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ratesingle = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_totalprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_newPO = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ponumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_saveprint = new System.Windows.Forms.Button();
            this.grid_po = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_poid = new System.Windows.Forms.Label();
            this.txt_forSrchPO = new System.Windows.Forms.TextBox();
            this.btn_inc = new System.Windows.Forms.Button();
            this.btn_dec = new System.Windows.Forms.Button();
            this.txt_srchPO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_datePo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_srchName = new UrduTextBoxDemo.UrduTextBox();
            this.txt_partyname = new UrduTextBoxDemo.UrduTextBox();
            this.txt_itemnaem = new UrduTextBoxDemo.UrduTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_po)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "آئٹم نام";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "قیمت سنگل";
            // 
            // txt_ratesingle
            // 
            this.txt_ratesingle.Location = new System.Drawing.Point(19, 54);
            this.txt_ratesingle.Name = "txt_ratesingle";
            this.txt_ratesingle.Size = new System.Drawing.Size(64, 26);
            this.txt_ratesingle.TabIndex = 2;
            this.txt_ratesingle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_ratesingle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ratesingle_KeyDown);
            this.txt_ratesingle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ratesingle_KeyPress);
            // 
            // txt_qty
            // 
            this.txt_qty.Location = new System.Drawing.Point(156, 87);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(64, 26);
            this.txt_qty.TabIndex = 3;
            this.txt_qty.TextChanged += new System.EventHandler(this.txt_qty_TextChanged);
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            this.txt_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "تعداد";
            // 
            // txt_totalprice
            // 
            this.txt_totalprice.Location = new System.Drawing.Point(19, 87);
            this.txt_totalprice.Name = "txt_totalprice";
            this.txt_totalprice.Size = new System.Drawing.Size(64, 26);
            this.txt_totalprice.TabIndex = 4;
            this.txt_totalprice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_totalprice_KeyDown);
            this.txt_totalprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_totalprice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "کل قیمت";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btn_newPO);
            this.groupBox1.Controls.Add(this.lbl_poid);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txt_partyname);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_ponumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_saveprint);
            this.groupBox1.Controls.Add(this.txt_ratesingle);
            this.groupBox1.Controls.Add(this.txt_totalprice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_itemnaem);
            this.groupBox1.Controls.Add(this.txt_qty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(22, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 167);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_newPO
            // 
            this.btn_newPO.BackColor = System.Drawing.Color.Green;
            this.btn_newPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newPO.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_newPO.Location = new System.Drawing.Point(284, 119);
            this.btn_newPO.Name = "btn_newPO";
            this.btn_newPO.Size = new System.Drawing.Size(83, 33);
            this.btn_newPO.TabIndex = 6;
            this.btn_newPO.Text = "New PO";
            this.btn_newPO.UseVisualStyleBackColor = false;
            this.btn_newPO.Click += new System.EventHandler(this.btn_newPO_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(19, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Green;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_update.Location = new System.Drawing.Point(110, 119);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(81, 33);
            this.btn_update.TabIndex = 7;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(199, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 45;
            this.label6.Text = "پارٹی نام";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txt_ponumber
            // 
            this.txt_ponumber.Location = new System.Drawing.Point(273, 24);
            this.txt_ponumber.Name = "txt_ponumber";
            this.txt_ponumber.ReadOnly = true;
            this.txt_ponumber.Size = new System.Drawing.Size(100, 26);
            this.txt_ponumber.TabIndex = 42;
            this.txt_ponumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ponumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(382, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "پرچیزنمبر";
            // 
            // btn_saveprint
            // 
            this.btn_saveprint.BackColor = System.Drawing.Color.Green;
            this.btn_saveprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveprint.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_saveprint.Location = new System.Drawing.Point(197, 119);
            this.btn_saveprint.Name = "btn_saveprint";
            this.btn_saveprint.Size = new System.Drawing.Size(81, 33);
            this.btn_saveprint.TabIndex = 5;
            this.btn_saveprint.Text = "save";
            this.btn_saveprint.UseVisualStyleBackColor = false;
            this.btn_saveprint.Click += new System.EventHandler(this.btn_saveprint_Click);
            // 
            // grid_po
            // 
            this.grid_po.AllowUserToAddRows = false;
            this.grid_po.AllowUserToDeleteRows = false;
            this.grid_po.AllowUserToOrderColumns = true;
            this.grid_po.AllowUserToResizeColumns = false;
            this.grid_po.AllowUserToResizeRows = false;
            this.grid_po.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_po.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.grid_po.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_po.Location = new System.Drawing.Point(529, 53);
            this.grid_po.Name = "grid_po";
            this.grid_po.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grid_po.RowHeadersWidth = 25;
            this.grid_po.ShowEditingIcon = false;
            this.grid_po.Size = new System.Drawing.Size(430, 393);
            this.grid_po.TabIndex = 48;
            this.grid_po.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_po_RowHeaderMouseClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Brown;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(-10, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 33);
            this.button3.TabIndex = 49;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_poid
            // 
            this.lbl_poid.AutoSize = true;
            this.lbl_poid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poid.Location = new System.Drawing.Point(283, 95);
            this.lbl_poid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_poid.Name = "lbl_poid";
            this.lbl_poid.Size = new System.Drawing.Size(10, 13);
            this.lbl_poid.TabIndex = 46;
            this.lbl_poid.Text = ".";
            this.lbl_poid.Visible = false;
            // 
            // txt_forSrchPO
            // 
            this.txt_forSrchPO.Location = new System.Drawing.Point(180, 53);
            this.txt_forSrchPO.Name = "txt_forSrchPO";
            this.txt_forSrchPO.Size = new System.Drawing.Size(100, 26);
            this.txt_forSrchPO.TabIndex = 50;
            this.txt_forSrchPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_forSrchPO_KeyDown);
            // 
            // btn_inc
            // 
            this.btn_inc.Location = new System.Drawing.Point(292, 53);
            this.btn_inc.Name = "btn_inc";
            this.btn_inc.Size = new System.Drawing.Size(75, 26);
            this.btn_inc.TabIndex = 51;
            this.btn_inc.Text = ">>";
            this.btn_inc.UseVisualStyleBackColor = true;
            this.btn_inc.Click += new System.EventHandler(this.btn_inc_Click);
            // 
            // btn_dec
            // 
            this.btn_dec.Location = new System.Drawing.Point(78, 53);
            this.btn_dec.Name = "btn_dec";
            this.btn_dec.Size = new System.Drawing.Size(75, 26);
            this.btn_dec.TabIndex = 52;
            this.btn_dec.Text = "<<";
            this.btn_dec.UseVisualStyleBackColor = true;
            this.btn_dec.Click += new System.EventHandler(this.btn_dec_Click);
            // 
            // txt_srchPO
            // 
            this.txt_srchPO.Location = new System.Drawing.Point(145, 105);
            this.txt_srchPO.Name = "txt_srchPO";
            this.txt_srchPO.Size = new System.Drawing.Size(100, 26);
            this.txt_srchPO.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(268, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 46;
            this.label7.Text = "پرچیزنمبر";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(315, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 47;
            this.label8.Text = "پارٹی نام";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btn_inc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_srchName);
            this.groupBox2.Controls.Add(this.txt_forSrchPO);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_dec);
            this.groupBox2.Controls.Add(this.txt_srchPO);
            this.groupBox2.Location = new System.Drawing.Point(22, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 199);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(164, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 24);
            this.label9.TabIndex = 53;
            this.label9.Text = "Seach Bar";
            // 
            // lbl_datePo
            // 
            this.lbl_datePo.AutoSize = true;
            this.lbl_datePo.Location = new System.Drawing.Point(676, 30);
            this.lbl_datePo.Name = "lbl_datePo";
            this.lbl_datePo.Size = new System.Drawing.Size(0, 20);
            this.lbl_datePo.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(622, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 55;
            this.label10.Text = "Date:";
            // 
            // txt_srchName
            // 
            this.txt_srchName.Location = new System.Drawing.Point(84, 157);
            this.txt_srchName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_srchName.Name = "txt_srchName";
            this.txt_srchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_srchName.Size = new System.Drawing.Size(196, 26);
            this.txt_srchName.TabIndex = 46;
            // 
            // txt_partyname
            // 
            this.txt_partyname.Location = new System.Drawing.Point(19, 20);
            this.txt_partyname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_partyname.Name = "txt_partyname";
            this.txt_partyname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_partyname.Size = new System.Drawing.Size(172, 26);
            this.txt_partyname.TabIndex = 0;
            // 
            // txt_itemnaem
            // 
            this.txt_itemnaem.Location = new System.Drawing.Point(207, 58);
            this.txt_itemnaem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_itemnaem.Name = "txt_itemnaem";
            this.txt_itemnaem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_itemnaem.Size = new System.Drawing.Size(166, 26);
            this.txt_itemnaem.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lasticecream.Properties.Resources.rsz_button_refresh_icon;
            this.pictureBox1.Location = new System.Drawing.Point(391, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Purchaseinfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1020, 709);
            this.ControlBox = false;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_datePo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.grid_po);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Purchaseinfor";
            this.Text = "خریداری";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Purchaseinfor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_po)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UrduTextBoxDemo.UrduTextBox txt_itemnaem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ratesingle;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_totalprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_ponumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_saveprint;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private UrduTextBoxDemo.UrduTextBox txt_partyname;
        private System.Windows.Forms.Button btn_newPO;
        private System.Windows.Forms.DataGridView grid_po;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_poid;
        private System.Windows.Forms.TextBox txt_forSrchPO;
        private System.Windows.Forms.Button btn_inc;
        private System.Windows.Forms.Button btn_dec;
        private System.Windows.Forms.TextBox txt_srchPO;
        private System.Windows.Forms.Label label7;
        private UrduTextBoxDemo.UrduTextBox txt_srchName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_datePo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}