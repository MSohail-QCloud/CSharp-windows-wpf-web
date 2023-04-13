namespace Qued
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxAll = new System.Windows.Forms.TextBox();
            this.RadiobtnINside = new System.Windows.Forms.RadioButton();
            this.RadiobtnOutside = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(607, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 200);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(607, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 294);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(607, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(21, 398);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(607, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBoxAll
            // 
            this.textBoxAll.Location = new System.Drawing.Point(170, 79);
            this.textBoxAll.Name = "textBoxAll";
            this.textBoxAll.Size = new System.Drawing.Size(874, 20);
            this.textBoxAll.TabIndex = 4;
            this.textBoxAll.TextChanged += new System.EventHandler(this.textBoxAll_TextChanged);
            // 
            // RadiobtnINside
            // 
            this.RadiobtnINside.AutoSize = true;
            this.RadiobtnINside.Checked = true;
            this.RadiobtnINside.Location = new System.Drawing.Point(6, 20);
            this.RadiobtnINside.Name = "RadiobtnINside";
            this.RadiobtnINside.Size = new System.Drawing.Size(79, 24);
            this.RadiobtnINside.TabIndex = 5;
            this.RadiobtnINside.TabStop = true;
            this.RadiobtnINside.Text = "IN Side";
            this.RadiobtnINside.UseVisualStyleBackColor = true;
            this.RadiobtnINside.CheckedChanged += new System.EventHandler(this.RadiobtnINside_CheckedChanged);
            // 
            // RadiobtnOutside
            // 
            this.RadiobtnOutside.AutoSize = true;
            this.RadiobtnOutside.Location = new System.Drawing.Point(6, 49);
            this.RadiobtnOutside.Name = "RadiobtnOutside";
            this.RadiobtnOutside.Size = new System.Drawing.Size(96, 24);
            this.RadiobtnOutside.TabIndex = 6;
            this.RadiobtnOutside.Text = "OUT Side";
            this.RadiobtnOutside.UseVisualStyleBackColor = true;
            this.RadiobtnOutside.CheckedChanged += new System.EventHandler(this.RadiobtnOutside_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadiobtnINside);
            this.groupBox1.Controls.Add(this.RadiobtnOutside);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "App Gate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "INTERLOOP ATTENDENCE SYSTEM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxAll);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxAll;
        private System.Windows.Forms.RadioButton RadiobtnINside;
        private System.Windows.Forms.RadioButton RadiobtnOutside;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

