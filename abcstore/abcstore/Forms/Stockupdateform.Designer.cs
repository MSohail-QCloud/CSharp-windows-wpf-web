namespace abcstore
{
    partial class Stockupdateform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stockupdateform));
            this.backbutton = new System.Windows.Forms.Button();
            this.addproductbutton = new System.Windows.Forms.Button();
            this.balancetextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.productdetailtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.productpricetextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productsizetextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.producttypetextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.productnametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.QtytextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.productidlabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.totalqtylabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backbutton
            // 
            this.backbutton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.backbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbutton.Location = new System.Drawing.Point(854, 109);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(154, 39);
            this.backbutton.TabIndex = 0;
            this.backbutton.Text = "Cancel";
            this.backbutton.UseVisualStyleBackColor = false;
            this.backbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addproductbutton
            // 
            this.addproductbutton.BackColor = System.Drawing.Color.Orange;
            this.addproductbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addproductbutton.Location = new System.Drawing.Point(854, 60);
            this.addproductbutton.Name = "addproductbutton";
            this.addproductbutton.Size = new System.Drawing.Size(154, 39);
            this.addproductbutton.TabIndex = 27;
            this.addproductbutton.Text = "Update Stock";
            this.addproductbutton.UseVisualStyleBackColor = false;
            this.addproductbutton.Click += new System.EventHandler(this.addproductbutton_Click);
            // 
            // balancetextBox
            // 
            this.balancetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.balancetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancetextBox.Location = new System.Drawing.Point(479, 297);
            this.balancetextBox.Name = "balancetextBox";
            this.balancetextBox.ReadOnly = true;
            this.balancetextBox.Size = new System.Drawing.Size(246, 26);
            this.balancetextBox.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(476, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Balance Qty";
            // 
            // productdetailtextBox
            // 
            this.productdetailtextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productdetailtextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productdetailtextBox.Location = new System.Drawing.Point(61, 232);
            this.productdetailtextBox.Multiline = true;
            this.productdetailtextBox.Name = "productdetailtextBox";
            this.productdetailtextBox.ReadOnly = true;
            this.productdetailtextBox.Size = new System.Drawing.Size(281, 123);
            this.productdetailtextBox.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(59, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Product Detail:";
            // 
            // productpricetextBox
            // 
            this.productpricetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productpricetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productpricetextBox.Location = new System.Drawing.Point(479, 149);
            this.productpricetextBox.Name = "productpricetextBox";
            this.productpricetextBox.ReadOnly = true;
            this.productpricetextBox.Size = new System.Drawing.Size(246, 26);
            this.productpricetextBox.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(476, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Product Price:";
            // 
            // productsizetextBox
            // 
            this.productsizetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productsizetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsizetextBox.Location = new System.Drawing.Point(479, 232);
            this.productsizetextBox.Name = "productsizetextBox";
            this.productsizetextBox.ReadOnly = true;
            this.productsizetextBox.Size = new System.Drawing.Size(246, 26);
            this.productsizetextBox.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(482, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Product Size:";
            // 
            // producttypetextBox
            // 
            this.producttypetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.producttypetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producttypetextBox.Location = new System.Drawing.Point(61, 153);
            this.producttypetextBox.Name = "producttypetextBox";
            this.producttypetextBox.ReadOnly = true;
            this.producttypetextBox.Size = new System.Drawing.Size(281, 26);
            this.producttypetextBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(58, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Product type:";
            // 
            // productnametextBox
            // 
            this.productnametextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productnametextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productnametextBox.Location = new System.Drawing.Point(61, 75);
            this.productnametextBox.Name = "productnametextBox";
            this.productnametextBox.ReadOnly = true;
            this.productnametextBox.Size = new System.Drawing.Size(281, 26);
            this.productnametextBox.TabIndex = 0;
            this.productnametextBox.TextChanged += new System.EventHandler(this.productnametextBox_TextChanged);
            this.productnametextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productnametextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(58, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Product Name:";
            // 
            // QtytextBox
            // 
            this.QtytextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.QtytextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtytextBox.Location = new System.Drawing.Point(479, 76);
            this.QtytextBox.Name = "QtytextBox";
            this.QtytextBox.Size = new System.Drawing.Size(246, 26);
            this.QtytextBox.TabIndex = 29;
            this.QtytextBox.TextChanged += new System.EventHandler(this.QtytextBox_TextChanged);
            this.QtytextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QtytextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(476, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 28;
            this.label7.Text = "Qty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(476, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Product ID:";
            // 
            // productidlabel
            // 
            this.productidlabel.AutoSize = true;
            this.productidlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productidlabel.ForeColor = System.Drawing.Color.White;
            this.productidlabel.Location = new System.Drawing.Point(586, 337);
            this.productidlabel.Name = "productidlabel";
            this.productidlabel.Size = new System.Drawing.Size(23, 18);
            this.productidlabel.TabIndex = 31;
            this.productidlabel.Text = "ID";
            this.productidlabel.TextChanged += new System.EventHandler(this.productidlabel_TextChanged);
            this.productidlabel.Click += new System.EventHandler(this.productidlabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(771, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // totalqtylabel
            // 
            this.totalqtylabel.AutoSize = true;
            this.totalqtylabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalqtylabel.ForeColor = System.Drawing.Color.Orange;
            this.totalqtylabel.Location = new System.Drawing.Point(562, 54);
            this.totalqtylabel.Name = "totalqtylabel";
            this.totalqtylabel.Size = new System.Drawing.Size(37, 18);
            this.totalqtylabel.TabIndex = 33;
            this.totalqtylabel.Text = "total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(287, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "Stock Update Form";
            // 
            // Stockupdateform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.totalqtylabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.productidlabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.QtytextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addproductbutton);
            this.Controls.Add(this.balancetextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.productdetailtextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.productpricetextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.productsizetextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.producttypetextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productnametextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stockupdateform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Update Screen";
            this.Load += new System.EventHandler(this.Stockupdateform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button addproductbutton;
        private System.Windows.Forms.TextBox balancetextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox productdetailtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox productpricetextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productsizetextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox producttypetextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productnametextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QtytextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label productidlabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label totalqtylabel;
        private System.Windows.Forms.Label label9;
    }
}