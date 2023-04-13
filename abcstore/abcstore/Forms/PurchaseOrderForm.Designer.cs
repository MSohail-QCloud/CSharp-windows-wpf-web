namespace abcstore.Forms
{
    partial class PurchaseOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Bill_no_textBox = new System.Windows.Forms.TextBox();
            this.SupplierCompnytextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SupplierIdtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suppliertextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purchasedataGridView = new System.Windows.Forms.DataGridView();
            this.itmcodetextBox = new System.Windows.Forms.TextBox();
            this.itemdesctextBox = new System.Windows.Forms.TextBox();
            this.ItemRatetextBox = new System.Windows.Forms.TextBox();
            this.PrevQtytextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NewQtytextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TotalQtytextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tukshopradioButton = new System.Windows.Forms.RadioButton();
            this.messradioButton = new System.Windows.Forms.RadioButton();
            this.addbutton = new System.Windows.Forms.Button();
            this.POlabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AmounttextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.paidtextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.payabletextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.totaltextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.RemarkstextBox = new System.Windows.Forms.TextBox();
            this.finish_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(435, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Order";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Bill_no_textBox);
            this.groupBox1.Controls.Add(this.SupplierCompnytextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SupplierIdtextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.suppliertextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Bill_no_textBox
            // 
            this.Bill_no_textBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Bill_no_textBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bill_no_textBox.Location = new System.Drawing.Point(945, 16);
            this.Bill_no_textBox.Name = "Bill_no_textBox";
            this.Bill_no_textBox.Size = new System.Drawing.Size(87, 26);
            this.Bill_no_textBox.TabIndex = 7;
            this.Bill_no_textBox.TextChanged += new System.EventHandler(this.Bill_no_textBox_TextChanged);
            this.Bill_no_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Bill_no_textBox_KeyPress);
            // 
            // SupplierCompnytextBox
            // 
            this.SupplierCompnytextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SupplierCompnytextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierCompnytextBox.Location = new System.Drawing.Point(522, 16);
            this.SupplierCompnytextBox.Name = "SupplierCompnytextBox";
            this.SupplierCompnytextBox.Size = new System.Drawing.Size(267, 26);
            this.SupplierCompnytextBox.TabIndex = 5;
            this.SupplierCompnytextBox.TextChanged += new System.EventHandler(this.SupplierCompnytextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(795, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Supplier Bill NO#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(366, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Supplier Company";
            // 
            // SupplierIdtextBox
            // 
            this.SupplierIdtextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SupplierIdtextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierIdtextBox.Location = new System.Drawing.Point(274, 16);
            this.SupplierIdtextBox.Name = "SupplierIdtextBox";
            this.SupplierIdtextBox.Size = new System.Drawing.Size(86, 26);
            this.SupplierIdtextBox.TabIndex = 3;
            this.SupplierIdtextBox.TextChanged += new System.EventHandler(this.SupplierIdtextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Supplier ID";
            // 
            // suppliertextBox
            // 
            this.suppliertextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.suppliertextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliertextBox.Location = new System.Drawing.Point(84, 16);
            this.suppliertextBox.Name = "suppliertextBox";
            this.suppliertextBox.Size = new System.Drawing.Size(87, 26);
            this.suppliertextBox.TabIndex = 1;
            this.suppliertextBox.TextChanged += new System.EventHandler(this.suppliertextBox_TextChanged);
            this.suppliertextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suppliertextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier";
            // 
            // purchasedataGridView
            // 
            this.purchasedataGridView.AllowUserToAddRows = false;
            this.purchasedataGridView.AllowUserToDeleteRows = false;
            this.purchasedataGridView.AllowUserToResizeColumns = false;
            this.purchasedataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasedataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.purchasedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.purchasedataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.purchasedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.purchasedataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.purchasedataGridView.Location = new System.Drawing.Point(18, 271);
            this.purchasedataGridView.Name = "purchasedataGridView";
            this.purchasedataGridView.ReadOnly = true;
            this.purchasedataGridView.RowHeadersVisible = false;
            this.purchasedataGridView.Size = new System.Drawing.Size(820, 126);
            this.purchasedataGridView.TabIndex = 2;
            // 
            // itmcodetextBox
            // 
            this.itmcodetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.itmcodetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itmcodetextBox.Location = new System.Drawing.Point(20, 173);
            this.itmcodetextBox.Name = "itmcodetextBox";
            this.itmcodetextBox.ReadOnly = true;
            this.itmcodetextBox.Size = new System.Drawing.Size(239, 26);
            this.itmcodetextBox.TabIndex = 6;
            this.itmcodetextBox.TextChanged += new System.EventHandler(this.itmcodetextBox_TextChanged);
            this.itmcodetextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // itemdesctextBox
            // 
            this.itemdesctextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.itemdesctextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemdesctextBox.Location = new System.Drawing.Point(292, 173);
            this.itemdesctextBox.Name = "itemdesctextBox";
            this.itemdesctextBox.ReadOnly = true;
            this.itemdesctextBox.Size = new System.Drawing.Size(773, 26);
            this.itemdesctextBox.TabIndex = 7;
            this.itemdesctextBox.TextChanged += new System.EventHandler(this.itemdesctextBox_TextChanged);
            // 
            // ItemRatetextBox
            // 
            this.ItemRatetextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ItemRatetextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemRatetextBox.Location = new System.Drawing.Point(20, 228);
            this.ItemRatetextBox.Name = "ItemRatetextBox";
            this.ItemRatetextBox.Size = new System.Drawing.Size(239, 26);
            this.ItemRatetextBox.TabIndex = 8;
            this.ItemRatetextBox.TextChanged += new System.EventHandler(this.ItemRatetextBox_TextChanged);
            this.ItemRatetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemRatetextBox_KeyPress);
            // 
            // PrevQtytextBox
            // 
            this.PrevQtytextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PrevQtytextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevQtytextBox.Location = new System.Drawing.Point(292, 228);
            this.PrevQtytextBox.Name = "PrevQtytextBox";
            this.PrevQtytextBox.ReadOnly = true;
            this.PrevQtytextBox.Size = new System.Drawing.Size(127, 26);
            this.PrevQtytextBox.TabIndex = 9;
            this.PrevQtytextBox.Text = "0";
            this.PrevQtytextBox.TextChanged += new System.EventHandler(this.PrevQtytextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(16, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Item Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(379, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Item Descriptions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(16, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Item Rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(288, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Prv Quantity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(491, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "New Quantity";
            // 
            // NewQtytextBox
            // 
            this.NewQtytextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NewQtytextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewQtytextBox.Location = new System.Drawing.Point(495, 228);
            this.NewQtytextBox.Name = "NewQtytextBox";
            this.NewQtytextBox.Size = new System.Drawing.Size(127, 26);
            this.NewQtytextBox.TabIndex = 14;
            this.NewQtytextBox.TextChanged += new System.EventHandler(this.NewQtytextBox_TextChanged);
            this.NewQtytextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewQtytextBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(707, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "Total Quantity";
            // 
            // TotalQtytextBox
            // 
            this.TotalQtytextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TotalQtytextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalQtytextBox.Location = new System.Drawing.Point(711, 228);
            this.TotalQtytextBox.Name = "TotalQtytextBox";
            this.TotalQtytextBox.ReadOnly = true;
            this.TotalQtytextBox.Size = new System.Drawing.Size(127, 26);
            this.TotalQtytextBox.TabIndex = 16;
            this.TotalQtytextBox.TextChanged += new System.EventHandler(this.TotalQtytextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tukshopradioButton);
            this.groupBox2.Controls.Add(this.messradioButton);
            this.groupBox2.Location = new System.Drawing.Point(857, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 33);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // tukshopradioButton
            // 
            this.tukshopradioButton.AutoSize = true;
            this.tukshopradioButton.ForeColor = System.Drawing.Color.White;
            this.tukshopradioButton.Location = new System.Drawing.Point(104, 10);
            this.tukshopradioButton.Name = "tukshopradioButton";
            this.tukshopradioButton.Size = new System.Drawing.Size(93, 17);
            this.tukshopradioButton.TabIndex = 17;
            this.tukshopradioButton.TabStop = true;
            this.tukshopradioButton.Text = "for Tuck Shop";
            this.tukshopradioButton.UseVisualStyleBackColor = true;
            // 
            // messradioButton
            // 
            this.messradioButton.AutoSize = true;
            this.messradioButton.ForeColor = System.Drawing.Color.White;
            this.messradioButton.Location = new System.Drawing.Point(24, 10);
            this.messradioButton.Name = "messradioButton";
            this.messradioButton.Size = new System.Drawing.Size(65, 17);
            this.messradioButton.TabIndex = 16;
            this.messradioButton.TabStop = true;
            this.messradioButton.Text = "for Mess";
            this.messradioButton.UseVisualStyleBackColor = true;
            this.messradioButton.CheckedChanged += new System.EventHandler(this.messradioButton_CheckedChanged);
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.Color.Orange;
            this.addbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.Location = new System.Drawing.Point(923, 282);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(142, 32);
            this.addbutton.TabIndex = 21;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // POlabel
            // 
            this.POlabel.AutoSize = true;
            this.POlabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.POlabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POlabel.ForeColor = System.Drawing.Color.White;
            this.POlabel.Location = new System.Drawing.Point(18, 20);
            this.POlabel.Name = "POlabel";
            this.POlabel.Size = new System.Drawing.Size(54, 26);
            this.POlabel.TabIndex = 22;
            this.POlabel.Text = "PO#";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Orange;
            this.label11.Location = new System.Drawing.Point(851, 342);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Amount";
            // 
            // AmounttextBox
            // 
            this.AmounttextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AmounttextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmounttextBox.Location = new System.Drawing.Point(923, 339);
            this.AmounttextBox.Name = "AmounttextBox";
            this.AmounttextBox.ReadOnly = true;
            this.AmounttextBox.Size = new System.Drawing.Size(142, 26);
            this.AmounttextBox.TabIndex = 23;
            this.AmounttextBox.Text = "0";
            this.AmounttextBox.TextChanged += new System.EventHandler(this.AmounttextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(871, 378);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 18);
            this.label13.TabIndex = 26;
            this.label13.Text = "Paid";
            // 
            // paidtextBox
            // 
            this.paidtextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.paidtextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidtextBox.Location = new System.Drawing.Point(923, 375);
            this.paidtextBox.Name = "paidtextBox";
            this.paidtextBox.ReadOnly = true;
            this.paidtextBox.Size = new System.Drawing.Size(142, 26);
            this.paidtextBox.TabIndex = 25;
            this.paidtextBox.Text = "0";
            this.paidtextBox.TextChanged += new System.EventHandler(this.paidtextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(847, 413);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 18);
            this.label14.TabIndex = 28;
            this.label14.Text = "Payable";
            // 
            // payabletextBox
            // 
            this.payabletextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.payabletextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payabletextBox.Location = new System.Drawing.Point(923, 410);
            this.payabletextBox.Name = "payabletextBox";
            this.payabletextBox.ReadOnly = true;
            this.payabletextBox.Size = new System.Drawing.Size(142, 26);
            this.payabletextBox.TabIndex = 27;
            this.payabletextBox.Text = "0";
            this.payabletextBox.TextChanged += new System.EventHandler(this.payabletextBox_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Orange;
            this.label15.Location = new System.Drawing.Point(919, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "Sub Total";
            // 
            // totaltextBox
            // 
            this.totaltextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.totaltextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaltextBox.Location = new System.Drawing.Point(923, 228);
            this.totaltextBox.Name = "totaltextBox";
            this.totaltextBox.ReadOnly = true;
            this.totaltextBox.Size = new System.Drawing.Size(142, 26);
            this.totaltextBox.TabIndex = 29;
            this.totaltextBox.TextChanged += new System.EventHandler(this.totaltextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Orange;
            this.label16.Location = new System.Drawing.Point(17, 413);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 18);
            this.label16.TabIndex = 32;
            this.label16.Text = "Reminder Note:";
            // 
            // RemarkstextBox
            // 
            this.RemarkstextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RemarkstextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemarkstextBox.Location = new System.Drawing.Point(140, 410);
            this.RemarkstextBox.Name = "RemarkstextBox";
            this.RemarkstextBox.ReadOnly = true;
            this.RemarkstextBox.Size = new System.Drawing.Size(698, 26);
            this.RemarkstextBox.TabIndex = 31;
            this.RemarkstextBox.TextChanged += new System.EventHandler(this.RemarkstextBox_TextChanged);
            // 
            // finish_button
            // 
            this.finish_button.BackColor = System.Drawing.Color.Silver;
            this.finish_button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish_button.ForeColor = System.Drawing.Color.DarkGreen;
            this.finish_button.Location = new System.Drawing.Point(927, 453);
            this.finish_button.Name = "finish_button";
            this.finish_button.Size = new System.Drawing.Size(142, 32);
            this.finish_button.TabIndex = 33;
            this.finish_button.Text = "Finish";
            this.finish_button.UseVisualStyleBackColor = false;
            this.finish_button.Click += new System.EventHandler(this.finish_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cancel_button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.ForeColor = System.Drawing.Color.Black;
            this.cancel_button.Location = new System.Drawing.Point(923, 501);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(142, 32);
            this.cancel_button.TabIndex = 34;
            this.cancel_button.Text = "cancel";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // PurchaseOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(71)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1087, 545);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.finish_button);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.RemarkstextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.totaltextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.payabletextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.paidtextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AmounttextBox);
            this.Controls.Add(this.POlabel);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TotalQtytextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NewQtytextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PrevQtytextBox);
            this.Controls.Add(this.ItemRatetextBox);
            this.Controls.Add(this.itemdesctextBox);
            this.Controls.Add(this.itmcodetextBox);
            this.Controls.Add(this.purchasedataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchaseOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Screen";
            this.Load += new System.EventHandler(this.PurchaseOrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SupplierIdtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox suppliertextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SupplierCompnytextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView purchasedataGridView;
        private System.Windows.Forms.TextBox itmcodetextBox;
        private System.Windows.Forms.TextBox itemdesctextBox;
        private System.Windows.Forms.TextBox ItemRatetextBox;
        private System.Windows.Forms.TextBox PrevQtytextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NewQtytextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TotalQtytextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton tukshopradioButton;
        private System.Windows.Forms.RadioButton messradioButton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label POlabel;
        private System.Windows.Forms.TextBox Bill_no_textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AmounttextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox paidtextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox payabletextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox totaltextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox RemarkstextBox;
        private System.Windows.Forms.Button finish_button;
        private System.Windows.Forms.Button cancel_button;
    }
}