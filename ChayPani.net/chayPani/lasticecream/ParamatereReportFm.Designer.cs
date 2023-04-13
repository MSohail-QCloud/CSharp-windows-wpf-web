namespace lasticecream
{
    partial class ParamatereReportFm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_runonlytablequery = new System.Windows.Forms.Button();
            this.datetime_from = new System.Windows.Forms.DateTimePicker();
            this.datetime_to = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "To";
            // 
            // btn_runonlytablequery
            // 
            this.btn_runonlytablequery.Location = new System.Drawing.Point(364, 122);
            this.btn_runonlytablequery.Name = "btn_runonlytablequery";
            this.btn_runonlytablequery.Size = new System.Drawing.Size(189, 28);
            this.btn_runonlytablequery.TabIndex = 48;
            this.btn_runonlytablequery.Text = "Run Report";
            this.btn_runonlytablequery.UseVisualStyleBackColor = true;
            this.btn_runonlytablequery.Click += new System.EventHandler(this.btn_runonlytablequery_Click);
            // 
            // datetime_from
            // 
            this.datetime_from.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.datetime_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetime_from.Location = new System.Drawing.Point(35, 85);
            this.datetime_from.Name = "datetime_from";
            this.datetime_from.Size = new System.Drawing.Size(116, 26);
            this.datetime_from.TabIndex = 49;
            // 
            // datetime_to
            // 
            this.datetime_to.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.datetime_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetime_to.Location = new System.Drawing.Point(177, 85);
            this.datetime_to.Name = "datetime_to";
            this.datetime_to.Size = new System.Drawing.Size(116, 26);
            this.datetime_to.TabIndex = 50;
            this.datetime_to.Value = new System.DateTime(2018, 5, 18, 0, 0, 0, 0);
            this.datetime_to.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datetime_to_KeyDown);
            this.datetime_to.Validating += new System.ComponentModel.CancelEventHandler(this.datetime_to_Validating);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(382, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 24);
            this.checkBox1.TabIndex = 52;
            this.checkBox1.Text = "Daily Report";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_runonlytablequery);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 225);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datetime_from);
            this.groupBox2.Controls.Add(this.datetime_to);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 198);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(693, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 56;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ParamatereReportFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(953, 466);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ParamatereReportFm";
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParamatereReportFm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_runonlytablequery;
        private System.Windows.Forms.DateTimePicker datetime_from;
        private System.Windows.Forms.DateTimePicker datetime_to;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
    }
}