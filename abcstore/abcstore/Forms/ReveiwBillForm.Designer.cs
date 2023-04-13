namespace abcstore
{
    partial class ReveiwBillForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReveiwBillForm));
            this.label1 = new System.Windows.Forms.Label();
            this.transNotextBox = new System.Windows.Forms.TextBox();
            this.ReciptgroupBox = new System.Windows.Forms.GroupBox();
            this.invoicedataGridView = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.savprintbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ReciptgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction/Bill no";
            // 
            // transNotextBox
            // 
            this.transNotextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.transNotextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transNotextBox.Location = new System.Drawing.Point(154, 101);
            this.transNotextBox.Name = "transNotextBox";
            this.transNotextBox.Size = new System.Drawing.Size(131, 26);
            this.transNotextBox.TabIndex = 1;
            this.transNotextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.transNotextBox_MouseClick);
            this.transNotextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ReciptgroupBox
            // 
            this.ReciptgroupBox.Controls.Add(this.invoicedataGridView);
            this.ReciptgroupBox.Controls.Add(this.label22);
            this.ReciptgroupBox.Controls.Add(this.label19);
            this.ReciptgroupBox.Controls.Add(this.label21);
            this.ReciptgroupBox.Controls.Add(this.label18);
            this.ReciptgroupBox.Controls.Add(this.label17);
            this.ReciptgroupBox.Controls.Add(this.textBox4);
            this.ReciptgroupBox.Controls.Add(this.textBox3);
            this.ReciptgroupBox.Controls.Add(this.label14);
            this.ReciptgroupBox.Controls.Add(this.textBox2);
            this.ReciptgroupBox.Controls.Add(this.label13);
            this.ReciptgroupBox.Controls.Add(this.label11);
            this.ReciptgroupBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReciptgroupBox.ForeColor = System.Drawing.Color.White;
            this.ReciptgroupBox.Location = new System.Drawing.Point(411, 5);
            this.ReciptgroupBox.Name = "ReciptgroupBox";
            this.ReciptgroupBox.Size = new System.Drawing.Size(517, 503);
            this.ReciptgroupBox.TabIndex = 2;
            this.ReciptgroupBox.TabStop = false;
            this.ReciptgroupBox.Text = "Sales Invoice";
            // 
            // invoicedataGridView
            // 
            this.invoicedataGridView.AllowUserToAddRows = false;
            this.invoicedataGridView.AllowUserToDeleteRows = false;
            this.invoicedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invoicedataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.invoicedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.invoicedataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoicedataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.invoicedataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.invoicedataGridView.Location = new System.Drawing.Point(32, 96);
            this.invoicedataGridView.MultiSelect = false;
            this.invoicedataGridView.Name = "invoicedataGridView";
            this.invoicedataGridView.ReadOnly = true;
            this.invoicedataGridView.RowHeadersVisible = false;
            this.invoicedataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.invoicedataGridView.ShowCellToolTips = false;
            this.invoicedataGridView.ShowEditingIcon = false;
            this.invoicedataGridView.Size = new System.Drawing.Size(462, 254);
            this.invoicedataGridView.TabIndex = 32;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(279, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 18);
            this.label22.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(104, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 18);
            this.label19.TabIndex = 30;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Orange;
            this.label21.Location = new System.Drawing.Point(239, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 18);
            this.label21.TabIndex = 29;
            this.label21.Text = "User:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Orange;
            this.label18.Location = new System.Drawing.Point(29, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 18);
            this.label18.TabIndex = 27;
            this.label18.Text = "Date/Time:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Orange;
            this.label17.Location = new System.Drawing.Point(23, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 18);
            this.label17.TabIndex = 26;
            this.label17.Text = "Transaction#";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(328, 374);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(166, 26);
            this.textBox4.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(329, 457);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(166, 26);
            this.textBox3.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(240, 459);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 18);
            this.label14.TabIndex = 20;
            this.label14.Text = "Remaining";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(328, 414);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(166, 26);
            this.textBox2.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(239, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 18);
            this.label13.TabIndex = 19;
            this.label13.Text = "Total Paid";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Orange;
            this.label11.Location = new System.Drawing.Point(256, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 17;
            this.label11.Text = "Amount";
            // 
            // savprintbutton
            // 
            this.savprintbutton.BackColor = System.Drawing.Color.Orange;
            this.savprintbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savprintbutton.Location = new System.Drawing.Point(-12, 265);
            this.savprintbutton.Name = "savprintbutton";
            this.savprintbutton.Size = new System.Drawing.Size(188, 42);
            this.savprintbutton.TabIndex = 25;
            this.savprintbutton.Text = "Print ";
            this.savprintbutton.UseVisualStyleBackColor = false;
            this.savprintbutton.Click += new System.EventHandler(this.savprintbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cancelbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.Location = new System.Drawing.Point(-12, 313);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(188, 42);
            this.cancelbutton.TabIndex = 33;
            this.cancelbutton.Text = "Close (X)";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(141, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 22);
            this.label7.TabIndex = 34;
            this.label7.Text = "Open Invoice";
            // 
            // ReveiwBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.ReciptgroupBox);
            this.Controls.Add(this.transNotextBox);
            this.Controls.Add(this.savprintbutton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReveiwBillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReveiwBillForm";
            this.Load += new System.EventHandler(this.ReveiwBillForm_Load);
            this.ReciptgroupBox.ResumeLayout(false);
            this.ReciptgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox transNotextBox;
        private System.Windows.Forms.GroupBox ReciptgroupBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button savprintbutton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView invoicedataGridView;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label label7;
    }
}