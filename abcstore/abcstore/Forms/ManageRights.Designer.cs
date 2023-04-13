namespace abcstore
{
    partial class ManageRights
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UsercomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormcomboBox = new System.Windows.Forms.ComboBox();
            this.formNOlabel = new System.Windows.Forms.Label();
            this.addformbutton = new System.Windows.Forms.Button();
            this.rightsdataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rightsdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UsercomboBox
            // 
            this.UsercomboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsercomboBox.FormattingEnabled = true;
            this.UsercomboBox.Location = new System.Drawing.Point(164, 52);
            this.UsercomboBox.Name = "UsercomboBox";
            this.UsercomboBox.Size = new System.Drawing.Size(217, 26);
            this.UsercomboBox.TabIndex = 0;
            this.UsercomboBox.SelectedIndexChanged += new System.EventHandler(this.UsercomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(109, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(390, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Form Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FormcomboBox
            // 
            this.FormcomboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormcomboBox.FormattingEnabled = true;
            this.FormcomboBox.Location = new System.Drawing.Point(487, 52);
            this.FormcomboBox.Name = "FormcomboBox";
            this.FormcomboBox.Size = new System.Drawing.Size(285, 26);
            this.FormcomboBox.TabIndex = 2;
            this.FormcomboBox.SelectedIndexChanged += new System.EventHandler(this.FormcomboBox_SelectedIndexChanged);
            // 
            // formNOlabel
            // 
            this.formNOlabel.AutoSize = true;
            this.formNOlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formNOlabel.ForeColor = System.Drawing.Color.Orange;
            this.formNOlabel.Location = new System.Drawing.Point(707, 31);
            this.formNOlabel.Name = "formNOlabel";
            this.formNOlabel.Size = new System.Drawing.Size(65, 18);
            this.formNOlabel.TabIndex = 4;
            this.formNOlabel.Text = "FormNo";
            this.formNOlabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // addformbutton
            // 
            this.addformbutton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.addformbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addformbutton.ForeColor = System.Drawing.Color.Orange;
            this.addformbutton.Location = new System.Drawing.Point(778, 52);
            this.addformbutton.Name = "addformbutton";
            this.addformbutton.Size = new System.Drawing.Size(75, 24);
            this.addformbutton.TabIndex = 5;
            this.addformbutton.Text = "Add Rights";
            this.addformbutton.UseVisualStyleBackColor = false;
            this.addformbutton.Click += new System.EventHandler(this.addformbutton_Click);
            // 
            // rightsdataGridView
            // 
            this.rightsdataGridView.AllowUserToAddRows = false;
            this.rightsdataGridView.AllowUserToDeleteRows = false;
            this.rightsdataGridView.AllowUserToResizeColumns = false;
            this.rightsdataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightsdataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rightsdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rightsdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rightsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rightsdataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.rightsdataGridView.Location = new System.Drawing.Point(100, 81);
            this.rightsdataGridView.Name = "rightsdataGridView";
            this.rightsdataGridView.ReadOnly = true;
            this.rightsdataGridView.RowHeadersVisible = false;
            this.rightsdataGridView.Size = new System.Drawing.Size(642, 385);
            this.rightsdataGridView.TabIndex = 6;
            // 
            // ManageRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(984, 481);
            this.Controls.Add(this.rightsdataGridView);
            this.Controls.Add(this.addformbutton);
            this.Controls.Add(this.formNOlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FormcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsercomboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageRights";
            this.Load += new System.EventHandler(this.ManageRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightsdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox UsercomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FormcomboBox;
        private System.Windows.Forms.Label formNOlabel;
        private System.Windows.Forms.Button addformbutton;
        private System.Windows.Forms.DataGridView rightsdataGridView;
    }
}