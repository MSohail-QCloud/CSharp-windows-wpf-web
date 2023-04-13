namespace lasticecream
{
    partial class AnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
            this.btn_print = new System.Windows.Forms.Button();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_totalamount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comb_itemlist = new System.Windows.Forms.ComboBox();
            this.txt_itemCode = new System.Windows.Forms.TextBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateto = new System.Windows.Forms.DateTimePicker();
            this.CombItemcodelistfrom = new System.Windows.Forms.ComboBox();
            this.txt_itemcodeFrom = new System.Windows.Forms.TextBox();
            this.btn_execute = new System.Windows.Forms.Button();
            this.grid_analysis = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_analysis)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.Green;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_print.Location = new System.Drawing.Point(773, 634);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(156, 45);
            this.btn_print.TabIndex = 447;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Visible = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // txt_qty
            // 
            this.txt_qty.Enabled = false;
            this.txt_qty.Location = new System.Drawing.Point(827, 598);
            this.txt_qty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.ReadOnly = true;
            this.txt_qty.Size = new System.Drawing.Size(164, 26);
            this.txt_qty.TabIndex = 440;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(747, 601);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 439;
            this.label6.Text = "Total Qty";
            // 
            // txt_totalamount
            // 
            this.txt_totalamount.Enabled = false;
            this.txt_totalamount.Location = new System.Drawing.Point(125, 601);
            this.txt_totalamount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalamount.Name = "txt_totalamount";
            this.txt_totalamount.ReadOnly = true;
            this.txt_totalamount.Size = new System.Drawing.Size(164, 26);
            this.txt_totalamount.TabIndex = 438;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 604);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 437;
            this.label5.Text = "Total Amount";
            // 
            // comb_itemlist
            // 
            this.comb_itemlist.FormattingEnabled = true;
            this.comb_itemlist.Location = new System.Drawing.Point(244, 54);
            this.comb_itemlist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comb_itemlist.Name = "comb_itemlist";
            this.comb_itemlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comb_itemlist.Size = new System.Drawing.Size(212, 28);
            this.comb_itemlist.TabIndex = 448;
            this.comb_itemlist.Visible = false;
            this.comb_itemlist.SelectedIndexChanged += new System.EventHandler(this.comb_itemlist_SelectedIndexChanged);
            // 
            // txt_itemCode
            // 
            this.txt_itemCode.Location = new System.Drawing.Point(47, 134);
            this.txt_itemCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_itemCode.Name = "txt_itemCode";
            this.txt_itemCode.Size = new System.Drawing.Size(53, 26);
            this.txt_itemCode.TabIndex = 449;
            this.txt_itemCode.Visible = false;
            this.txt_itemCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(115, 16);
            this.dateFrom.MinDate = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(122, 26);
            this.dateFrom.TabIndex = 451;
            this.dateFrom.Value = new System.DateTime(2018, 7, 20, 4, 34, 36, 0);
            // 
            // dateto
            // 
            this.dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateto.Location = new System.Drawing.Point(115, 54);
            this.dateto.MinDate = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dateto.Name = "dateto";
            this.dateto.Size = new System.Drawing.Size(122, 26);
            this.dateto.TabIndex = 452;
            this.dateto.Value = new System.DateTime(2018, 7, 20, 4, 34, 36, 0);
            // 
            // CombItemcodelistfrom
            // 
            this.CombItemcodelistfrom.FormattingEnabled = true;
            this.CombItemcodelistfrom.Location = new System.Drawing.Point(244, 16);
            this.CombItemcodelistfrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CombItemcodelistfrom.Name = "CombItemcodelistfrom";
            this.CombItemcodelistfrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CombItemcodelistfrom.Size = new System.Drawing.Size(212, 28);
            this.CombItemcodelistfrom.TabIndex = 453;
            this.CombItemcodelistfrom.SelectedIndexChanged += new System.EventHandler(this.CombItemcodelistfrom_SelectedIndexChanged);
            // 
            // txt_itemcodeFrom
            // 
            this.txt_itemcodeFrom.Location = new System.Drawing.Point(47, 98);
            this.txt_itemcodeFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_itemcodeFrom.Name = "txt_itemcodeFrom";
            this.txt_itemcodeFrom.Size = new System.Drawing.Size(53, 26);
            this.txt_itemcodeFrom.TabIndex = 449;
            this.txt_itemcodeFrom.Visible = false;
            this.txt_itemcodeFrom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_execute
            // 
            this.btn_execute.BackColor = System.Drawing.Color.Green;
            this.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_execute.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_execute.Location = new System.Drawing.Point(738, 35);
            this.btn_execute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(156, 45);
            this.btn_execute.TabIndex = 447;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = false;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
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
            this.grid_analysis.Location = new System.Drawing.Point(12, 88);
            this.grid_analysis.Name = "grid_analysis";
            this.grid_analysis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grid_analysis.RowHeadersWidth = 25;
            this.grid_analysis.RowTemplate.Height = 25;
            this.grid_analysis.Size = new System.Drawing.Size(979, 505);
            this.grid_analysis.TabIndex = 454;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(-14, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 28);
            this.button1.TabIndex = 455;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.comboBox1.Location = new System.Drawing.Point(578, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(155, 28);
            this.comboBox1.TabIndex = 456;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.comboBox2.Location = new System.Drawing.Point(578, 52);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(155, 28);
            this.comboBox2.TabIndex = 457;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(469, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 458;
            this.label1.Text = "Table # From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(488, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 458;
            this.label2.Text = "Table # To";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1008, 693);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid_analysis);
            this.Controls.Add(this.CombItemcodelistfrom);
            this.Controls.Add(this.dateto);
            this.Controls.Add(this.dateFrom);
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
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnalysisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_analysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_totalamount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comb_itemlist;
        private System.Windows.Forms.TextBox txt_itemCode;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateto;
        private System.Windows.Forms.ComboBox CombItemcodelistfrom;
        private System.Windows.Forms.TextBox txt_itemcodeFrom;
        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.DataGridView grid_analysis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}