namespace ColonyMarket
{
    partial class changeDBform
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
            this.lblolddb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblbrowsedbName = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtbrowsepath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblolddb
            // 
            this.lblolddb.AutoSize = true;
            this.lblolddb.ForeColor = System.Drawing.Color.Lime;
            this.lblolddb.Location = new System.Drawing.Point(116, 31);
            this.lblolddb.Name = "lblolddb";
            this.lblolddb.Size = new System.Drawing.Size(281, 16);
            this.lblolddb.TabIndex = 0;
            this.lblolddb.Text = "_______________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Old Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Project";
            // 
            // lblbrowsedbName
            // 
            this.lblbrowsedbName.AutoSize = true;
            this.lblbrowsedbName.ForeColor = System.Drawing.Color.Lime;
            this.lblbrowsedbName.Location = new System.Drawing.Point(116, 78);
            this.lblbrowsedbName.Name = "lblbrowsedbName";
            this.lblbrowsedbName.Size = new System.Drawing.Size(281, 16);
            this.lblbrowsedbName.TabIndex = 2;
            this.lblbrowsedbName.Text = "_______________________________________";
            // 
            // btnbrowse
            // 
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.ForeColor = System.Drawing.Color.Lime;
            this.btnbrowse.Location = new System.Drawing.Point(428, 71);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 30);
            this.btnbrowse.TabIndex = 4;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(368, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Change Project";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbrowsepath
            // 
            this.txtbrowsepath.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtbrowsepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbrowsepath.ForeColor = System.Drawing.Color.Lime;
            this.txtbrowsepath.Location = new System.Drawing.Point(119, 173);
            this.txtbrowsepath.Multiline = true;
            this.txtbrowsepath.Name = "txtbrowsepath";
            this.txtbrowsepath.ReadOnly = true;
            this.txtbrowsepath.Size = new System.Drawing.Size(384, 88);
            this.txtbrowsepath.TabIndex = 6;
            this.txtbrowsepath.TextChanged += new System.EventHandler(this.txtbrowsepath_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(16, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Full Selected Path";
            // 
            // changeDBform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(530, 321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbrowsepath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblbrowsedbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnbrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblolddb);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changeDBform";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Project";
            this.Load += new System.EventHandler(this.changeDBform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblolddb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblbrowsedbName;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbrowsepath;
        private System.Windows.Forms.Label label4;
    }
}