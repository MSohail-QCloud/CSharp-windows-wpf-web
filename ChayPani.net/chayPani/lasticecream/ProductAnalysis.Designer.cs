namespace lasticecream
{
    partial class ProductAnalysis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductAnalysis));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grid_analysis = new System.Windows.Forms.DataGridView();
            this.CombItemcodelistfrom = new System.Windows.Forms.ComboBox();
            this.dateto = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_itemcodeFrom = new System.Windows.Forms.TextBox();
            this.txt_itemCode = new System.Windows.Forms.TextBox();
            this.comb_itemlist = new System.Windows.Forms.ComboBox();
            this.btn_execute = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_totalamount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_analysis)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(920, 78);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(230, 28);
            this.comboBox2.TabIndex = 475;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(920, 20);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(230, 28);
            this.comboBox1.TabIndex = 474;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(-4, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 31);
            this.button1.TabIndex = 473;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grid_analysis
            // 
            this.grid_analysis.AllowUserToAddRows = false;
            this.grid_analysis.AllowUserToDeleteRows = false;
            this.grid_analysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_analysis.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.grid_analysis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_analysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_analysis.ColumnHeadersHeight = 35;
            this.grid_analysis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_analysis.Location = new System.Drawing.Point(116, 122);
            this.grid_analysis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_analysis.Name = "grid_analysis";
            this.grid_analysis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grid_analysis.RowHeadersWidth = 25;
            this.grid_analysis.RowTemplate.Height = 25;
            this.grid_analysis.Size = new System.Drawing.Size(1034, 480);
            this.grid_analysis.TabIndex = 472;
            // 
            // CombItemcodelistfrom
            // 
            this.CombItemcodelistfrom.FormattingEnabled = true;
            this.CombItemcodelistfrom.Location = new System.Drawing.Point(310, 23);
            this.CombItemcodelistfrom.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.CombItemcodelistfrom.Name = "CombItemcodelistfrom";
            this.CombItemcodelistfrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CombItemcodelistfrom.Size = new System.Drawing.Size(316, 28);
            this.CombItemcodelistfrom.TabIndex = 471;
            this.CombItemcodelistfrom.SelectedIndexChanged += new System.EventHandler(this.CombItemcodelistfrom_SelectedIndexChanged);
            // 
            // dateto
            // 
            this.dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateto.Location = new System.Drawing.Point(116, 81);
            this.dateto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateto.MinDate = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dateto.Name = "dateto";
            this.dateto.Size = new System.Drawing.Size(181, 26);
            this.dateto.TabIndex = 470;
            this.dateto.Value = new System.DateTime(2018, 7, 20, 4, 34, 36, 0);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(116, 23);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateFrom.MinDate = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(181, 26);
            this.dateFrom.TabIndex = 469;
            this.dateFrom.Value = new System.DateTime(2018, 7, 20, 4, 34, 36, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(803, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 468;
            this.label2.Text = ":آئٹم کوڈ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(803, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 467;
            this.label1.Text = ":آئٹم کوڈ";
            // 
            // txt_itemcodeFrom
            // 
            this.txt_itemcodeFrom.Location = new System.Drawing.Point(640, 26);
            this.txt_itemcodeFrom.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_itemcodeFrom.Name = "txt_itemcodeFrom";
            this.txt_itemcodeFrom.Size = new System.Drawing.Size(151, 26);
            this.txt_itemcodeFrom.TabIndex = 466;
            // 
            // txt_itemCode
            // 
            this.txt_itemCode.Location = new System.Drawing.Point(640, 81);
            this.txt_itemCode.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_itemCode.Name = "txt_itemCode";
            this.txt_itemCode.Size = new System.Drawing.Size(151, 26);
            this.txt_itemCode.TabIndex = 465;
            // 
            // comb_itemlist
            // 
            this.comb_itemlist.FormattingEnabled = true;
            this.comb_itemlist.Location = new System.Drawing.Point(310, 81);
            this.comb_itemlist.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.comb_itemlist.Name = "comb_itemlist";
            this.comb_itemlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comb_itemlist.Size = new System.Drawing.Size(316, 28);
            this.comb_itemlist.TabIndex = 464;
            this.comb_itemlist.SelectedIndexChanged += new System.EventHandler(this.comb_itemlist_SelectedIndexChanged);
            // 
            // btn_execute
            // 
            this.btn_execute.BackColor = System.Drawing.Color.Green;
            this.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_execute.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_execute.Location = new System.Drawing.Point(1162, 32);
            this.btn_execute.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(117, 47);
            this.btn_execute.TabIndex = 463;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = false;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.Green;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_print.Location = new System.Drawing.Point(987, 652);
            this.btn_print.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(163, 37);
            this.btn_print.TabIndex = 462;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Visible = false;
            // 
            // txt_qty
            // 
            this.txt_qty.Enabled = false;
            this.txt_qty.Location = new System.Drawing.Point(187, 613);
            this.txt_qty.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.ReadOnly = true;
            this.txt_qty.Size = new System.Drawing.Size(153, 26);
            this.txt_qty.TabIndex = 461;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 615);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 460;
            this.label6.Text = "Total Qty";
            // 
            // txt_totalamount
            // 
            this.txt_totalamount.Enabled = false;
            this.txt_totalamount.Location = new System.Drawing.Point(468, 612);
            this.txt_totalamount.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txt_totalamount.Name = "txt_totalamount";
            this.txt_totalamount.ReadOnly = true;
            this.txt_totalamount.Size = new System.Drawing.Size(153, 26);
            this.txt_totalamount.TabIndex = 459;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(352, 615);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 458;
            this.label5.Text = "Total Amount";
            // 
            // ProductAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid_analysis);
            this.Controls.Add(this.CombItemcodelistfrom);
            this.Controls.Add(this.dateto);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_itemcodeFrom);
            this.Controls.Add(this.txt_itemCode);
            this.Controls.Add(this.comb_itemlist);
            this.Controls.Add(this.btn_execute);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_totalamount);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductAnalysis";
            this.Text = "ProductAnalysis";
            this.Load += new System.EventHandler(this.ProductAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_analysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grid_analysis;
        private System.Windows.Forms.ComboBox CombItemcodelistfrom;
        private System.Windows.Forms.DateTimePicker dateto;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_itemcodeFrom;
        private System.Windows.Forms.TextBox txt_itemCode;
        private System.Windows.Forms.ComboBox comb_itemlist;
        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_totalamount;
        private System.Windows.Forms.Label label5;
    }
}