namespace VesterShoes
{
    partial class selectVender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectVender));
            this.label1 = new System.Windows.Forms.Label();
            this.comboVender = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveVender = new System.Windows.Forms.Button();
            this.btnNewVender = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblerr = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnissued = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPickerIssueDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblissuedate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(92, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Vender";
            // 
            // comboVender
            // 
            this.comboVender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboVender.BackColor = System.Drawing.Color.White;
            this.comboVender.FormattingEnabled = true;
            this.comboVender.Location = new System.Drawing.Point(58, 130);
            this.comboVender.Name = "comboVender";
            this.comboVender.Size = new System.Drawing.Size(188, 26);
            this.comboVender.TabIndex = 1;
            this.comboVender.SelectedIndexChanged += new System.EventHandler(this.comboVender_SelectedIndexChanged);
            this.comboVender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboVender_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblissuedate);
            this.groupBox1.Controls.Add(this.btnSaveVender);
            this.groupBox1.Controls.Add(this.btnNewVender);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.lblerr);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnissued);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtPickerIssueDate);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboVender);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 446);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveVender
            // 
            this.btnSaveVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVender.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSaveVender.ForeColor = System.Drawing.Color.SeaShell;
            this.btnSaveVender.Location = new System.Drawing.Point(157, 167);
            this.btnSaveVender.Name = "btnSaveVender";
            this.btnSaveVender.Size = new System.Drawing.Size(89, 25);
            this.btnSaveVender.TabIndex = 61;
            this.btnSaveVender.Text = "Add New Ven";
            this.btnSaveVender.UseVisualStyleBackColor = true;
            this.btnSaveVender.Click += new System.EventHandler(this.btnSaveVender_Click);
            // 
            // btnNewVender
            // 
            this.btnNewVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewVender.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNewVender.ForeColor = System.Drawing.Color.SeaShell;
            this.btnNewVender.Location = new System.Drawing.Point(58, 167);
            this.btnNewVender.Name = "btnNewVender";
            this.btnNewVender.Size = new System.Drawing.Size(89, 25);
            this.btnNewVender.TabIndex = 60;
            this.btnNewVender.Text = "View Ven";
            this.btnNewVender.UseVisualStyleBackColor = true;
            this.btnNewVender.Click += new System.EventHandler(this.btnNewVender_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(58, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(188, 26);
            this.comboBox2.TabIndex = 59;
            // 
            // lblerr
            // 
            this.lblerr.AutoSize = true;
            this.lblerr.Location = new System.Drawing.Point(13, 416);
            this.lblerr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(0, 18);
            this.lblerr.TabIndex = 58;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 26);
            this.comboBox1.TabIndex = 57;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnModify
            // 
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.ForeColor = System.Drawing.Color.Lime;
            this.btnModify.Location = new System.Drawing.Point(211, 376);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 28);
            this.btnModify.TabIndex = 56;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(123, 276);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 26);
            this.textBox2.TabIndex = 55;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(21, 278);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 54;
            this.label5.Text = "Total Amount";
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.Color.White;
            this.txtRate.Location = new System.Drawing.Point(123, 244);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(121, 26);
            this.txtRate.TabIndex = 53;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(23, 246);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Rate/Pair";
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.Color.Lime;
            this.btnReturn.Location = new System.Drawing.Point(120, 376);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 28);
            this.btnReturn.TabIndex = 51;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnissued
            // 
            this.btnissued.Enabled = false;
            this.btnissued.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnissued.ForeColor = System.Drawing.Color.Lime;
            this.btnissued.Location = new System.Drawing.Point(28, 376);
            this.btnissued.Name = "btnissued";
            this.btnissued.Size = new System.Drawing.Size(75, 28);
            this.btnissued.TabIndex = 50;
            this.btnissued.Text = "Issued";
            this.btnissued.UseVisualStyleBackColor = true;
            this.btnissued.Click += new System.EventHandler(this.btnissued_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(21, 307);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = " Date";
            // 
            // dtPickerIssueDate
            // 
            this.dtPickerIssueDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtPickerIssueDate.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtPickerIssueDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerIssueDate.Location = new System.Drawing.Point(25, 332);
            this.dtPickerIssueDate.Margin = new System.Windows.Forms.Padding(1);
            this.dtPickerIssueDate.Name = "dtPickerIssueDate";
            this.dtPickerIssueDate.ShowUpDown = true;
            this.dtPickerIssueDate.Size = new System.Drawing.Size(258, 26);
            this.dtPickerIssueDate.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(123, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "12";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(25, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issue Qty";
            // 
            // lblissuedate
            // 
            this.lblissuedate.AutoSize = true;
            this.lblissuedate.Location = new System.Drawing.Point(100, 308);
            this.lblissuedate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblissuedate.Name = "lblissuedate";
            this.lblissuedate.Size = new System.Drawing.Size(0, 18);
            this.lblissuedate.TabIndex = 62;
            // 
            // selectVender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(351, 455);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectVender";
            this.Text = "selectVender";
            this.Load += new System.EventHandler(this.selectVender_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboVender;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnissued;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPickerIssueDate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnNewVender;
        private System.Windows.Forms.Button btnSaveVender;
        private System.Windows.Forms.Label lblissuedate;
    }
}