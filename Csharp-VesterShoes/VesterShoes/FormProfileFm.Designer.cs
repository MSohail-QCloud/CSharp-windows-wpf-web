namespace VesterShoes
{
    partial class FormProfileFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfileFm));
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerchCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CommCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCompnyName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOfficeAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHomeAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCnic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPOfficeNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CombVenderType = new System.Windows.Forms.ComboBox();
            this.CombProfileType = new System.Windows.Forms.ComboBox();
            this.lblProfileId = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewProfile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Gridcustomer = new System.Windows.Forms.DataGridView();
            this.ProfileId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PGaurdianName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVender = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridcustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVender)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search By Id#";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.White;
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(8, 37);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(98, 26);
            this.txtCustomerID.TabIndex = 2;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            this.txtCustomerID.Enter += new System.EventHandler(this.txtCustomerID_Enter);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            this.txtCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerID_KeyPress);
            this.txtCustomerID.Leave += new System.EventHandler(this.txtCustomerID_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSerchCompanyName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerID);
            this.groupBox1.Location = new System.Drawing.Point(756, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search By Company Name:";
            // 
            // txtSerchCompanyName
            // 
            this.txtSerchCompanyName.BackColor = System.Drawing.Color.White;
            this.txtSerchCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerchCompanyName.Location = new System.Drawing.Point(126, 37);
            this.txtSerchCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerchCompanyName.Name = "txtSerchCompanyName";
            this.txtSerchCompanyName.Size = new System.Drawing.Size(221, 26);
            this.txtSerchCompanyName.TabIndex = 4;
            this.txtSerchCompanyName.TextChanged += new System.EventHandler(this.txtSerchCompanyName_TextChanged);
            this.txtSerchCompanyName.Enter += new System.EventHandler(this.txtSerchCompanyName_Enter);
            this.txtSerchCompanyName.Leave += new System.EventHandler(this.txtSerchCompanyName_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CommCombo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtCompnyName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOfficeAddress);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtHomeAddress);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCnic);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPOfficeNumber);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPMobile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProfileName);
            this.groupBox2.Location = new System.Drawing.Point(756, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 308);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // CommCombo
            // 
            this.CommCombo.BackColor = System.Drawing.Color.White;
            this.CommCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommCombo.FormattingEnabled = true;
            this.CommCombo.Location = new System.Drawing.Point(169, 43);
            this.CommCombo.MaxLength = 30;
            this.CommCombo.Name = "CommCombo";
            this.CommCombo.Size = new System.Drawing.Size(178, 28);
            this.CommCombo.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Company Name:";
            // 
            // txtCompnyName
            // 
            this.txtCompnyName.BackColor = System.Drawing.Color.White;
            this.txtCompnyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompnyName.ForeColor = System.Drawing.Color.Black;
            this.txtCompnyName.Location = new System.Drawing.Point(168, 152);
            this.txtCompnyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompnyName.MaxLength = 30;
            this.txtCompnyName.Name = "txtCompnyName";
            this.txtCompnyName.Size = new System.Drawing.Size(179, 26);
            this.txtCompnyName.TabIndex = 16;
            this.txtCompnyName.Enter += new System.EventHandler(this.txtCompnyName_Enter);
            this.txtCompnyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompnyName_KeyDown);
            this.txtCompnyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompnyName_KeyPress);
            this.txtCompnyName.Leave += new System.EventHandler(this.txtCompnyName_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 250);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Office Address";
            // 
            // txtOfficeAddress
            // 
            this.txtOfficeAddress.BackColor = System.Drawing.Color.White;
            this.txtOfficeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficeAddress.ForeColor = System.Drawing.Color.Black;
            this.txtOfficeAddress.Location = new System.Drawing.Point(7, 274);
            this.txtOfficeAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtOfficeAddress.MaxLength = 50;
            this.txtOfficeAddress.Name = "txtOfficeAddress";
            this.txtOfficeAddress.Size = new System.Drawing.Size(340, 26);
            this.txtOfficeAddress.TabIndex = 14;
            this.txtOfficeAddress.Enter += new System.EventHandler(this.txtOfficeAddress_Enter);
            this.txtOfficeAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOfficeAddress_KeyDown);
            this.txtOfficeAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOfficeAddress_KeyPress);
            this.txtOfficeAddress.Leave += new System.EventHandler(this.txtOfficeAddress_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 185);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Home Address:";
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.BackColor = System.Drawing.Color.White;
            this.txtHomeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHomeAddress.ForeColor = System.Drawing.Color.Black;
            this.txtHomeAddress.Location = new System.Drawing.Point(7, 209);
            this.txtHomeAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtHomeAddress.MaxLength = 50;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.Size = new System.Drawing.Size(340, 26);
            this.txtHomeAddress.TabIndex = 12;
            this.txtHomeAddress.Enter += new System.EventHandler(this.txtHomeAddress_Enter);
            this.txtHomeAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHomeAddress_KeyDown);
            this.txtHomeAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHomeAddress_KeyPress);
            this.txtHomeAddress.Leave += new System.EventHandler(this.txtHomeAddress_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 130);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cnic #";
            // 
            // txtCnic
            // 
            this.txtCnic.BackColor = System.Drawing.Color.White;
            this.txtCnic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnic.ForeColor = System.Drawing.Color.Black;
            this.txtCnic.Location = new System.Drawing.Point(7, 152);
            this.txtCnic.Margin = new System.Windows.Forms.Padding(4);
            this.txtCnic.MaxLength = 13;
            this.txtCnic.Name = "txtCnic";
            this.txtCnic.Size = new System.Drawing.Size(150, 26);
            this.txtCnic.TabIndex = 10;
            this.txtCnic.Enter += new System.EventHandler(this.txtCnic_Enter);
            this.txtCnic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCnic_KeyDown);
            this.txtCnic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnic_KeyPress);
            this.txtCnic.Leave += new System.EventHandler(this.txtCnic_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Office #";
            // 
            // txtPOfficeNumber
            // 
            this.txtPOfficeNumber.BackColor = System.Drawing.Color.White;
            this.txtPOfficeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOfficeNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPOfficeNumber.Location = new System.Drawing.Point(169, 97);
            this.txtPOfficeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPOfficeNumber.MaxLength = 11;
            this.txtPOfficeNumber.Name = "txtPOfficeNumber";
            this.txtPOfficeNumber.Size = new System.Drawing.Size(178, 26);
            this.txtPOfficeNumber.TabIndex = 8;
            this.txtPOfficeNumber.Enter += new System.EventHandler(this.txtPOfficeNumber_Enter);
            this.txtPOfficeNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPOfficeNumber_KeyDown);
            this.txtPOfficeNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOfficeNumber_KeyPress);
            this.txtPOfficeNumber.Leave += new System.EventHandler(this.txtPOfficeNumber_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mobile #";
            // 
            // txtPMobile
            // 
            this.txtPMobile.BackColor = System.Drawing.Color.White;
            this.txtPMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMobile.ForeColor = System.Drawing.Color.Black;
            this.txtPMobile.Location = new System.Drawing.Point(7, 97);
            this.txtPMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtPMobile.MaxLength = 11;
            this.txtPMobile.Name = "txtPMobile";
            this.txtPMobile.Size = new System.Drawing.Size(150, 26);
            this.txtPMobile.TabIndex = 6;
            this.txtPMobile.Enter += new System.EventHandler(this.txtPMobile_Enter);
            this.txtPMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPMobile_KeyDown);
            this.txtPMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPMobile_KeyPress);
            this.txtPMobile.Leave += new System.EventHandler(this.txtPMobile_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "C/F:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // txtProfileName
            // 
            this.txtProfileName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileName.ForeColor = System.Drawing.Color.Black;
            this.txtProfileName.Location = new System.Drawing.Point(7, 43);
            this.txtProfileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfileName.MaxLength = 30;
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(150, 26);
            this.txtProfileName.TabIndex = 2;
            this.txtProfileName.TextChanged += new System.EventHandler(this.txtProfileName_TextChanged);
            this.txtProfileName.Enter += new System.EventHandler(this.txtProfileName_Enter);
            this.txtProfileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProfileName_KeyDown);
            this.txtProfileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfileName_KeyPress);
            this.txtProfileName.Leave += new System.EventHandler(this.txtProfileName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CombVenderType);
            this.groupBox3.Controls.Add(this.CombProfileType);
            this.groupBox3.Location = new System.Drawing.Point(756, 385);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 65);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // CombVenderType
            // 
            this.CombVenderType.BackColor = System.Drawing.Color.White;
            this.CombVenderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombVenderType.FormattingEnabled = true;
            this.CombVenderType.Location = new System.Drawing.Point(191, 22);
            this.CombVenderType.Name = "CombVenderType";
            this.CombVenderType.Size = new System.Drawing.Size(130, 28);
            this.CombVenderType.TabIndex = 3;
            this.CombVenderType.Visible = false;
            this.CombVenderType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CombVenderType_KeyDown);
            // 
            // CombProfileType
            // 
            this.CombProfileType.BackColor = System.Drawing.Color.White;
            this.CombProfileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombProfileType.FormattingEnabled = true;
            this.CombProfileType.Location = new System.Drawing.Point(35, 22);
            this.CombProfileType.Name = "CombProfileType";
            this.CombProfileType.Size = new System.Drawing.Size(150, 28);
            this.CombProfileType.TabIndex = 2;
            this.CombProfileType.SelectedIndexChanged += new System.EventHandler(this.CombProfileType_SelectedIndexChanged);
            // 
            // lblProfileId
            // 
            this.lblProfileId.AutoSize = true;
            this.lblProfileId.Location = new System.Drawing.Point(696, 70);
            this.lblProfileId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfileId.Name = "lblProfileId";
            this.lblProfileId.Size = new System.Drawing.Size(0, 16);
            this.lblProfileId.TabIndex = 7;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Transparent;
            this.btnModify.BackgroundImage = global::VesterShoes.Properties.Resources.btnEdit;
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Location = new System.Drawing.Point(658, 95);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(50, 50);
            this.btnModify.TabIndex = 8;
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(926, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 38);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(808, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewProfile
            // 
            this.btnNewProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnNewProfile.BackgroundImage = global::VesterShoes.Properties.Resources.btnNew;
            this.btnNewProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewProfile.FlatAppearance.BorderSize = 0;
            this.btnNewProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProfile.Location = new System.Drawing.Point(658, 8);
            this.btnNewProfile.Name = "btnNewProfile";
            this.btnNewProfile.Size = new System.Drawing.Size(50, 50);
            this.btnNewProfile.TabIndex = 6;
            this.btnNewProfile.UseVisualStyleBackColor = false;
            this.btnNewProfile.Click += new System.EventHandler(this.btnNewProfile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(668, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "ID";
            // 
            // Gridcustomer
            // 
            this.Gridcustomer.AllowUserToAddRows = false;
            this.Gridcustomer.AllowUserToDeleteRows = false;
            this.Gridcustomer.AllowUserToResizeColumns = false;
            this.Gridcustomer.AllowUserToResizeRows = false;
            this.Gridcustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Gridcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridcustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProfileId,
            this.PCompanyName,
            this.PName,
            this.PGaurdianName});
            this.Gridcustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Gridcustomer.Location = new System.Drawing.Point(7, 7);
            this.Gridcustomer.Margin = new System.Windows.Forms.Padding(4);
            this.Gridcustomer.MultiSelect = false;
            this.Gridcustomer.Name = "Gridcustomer";
            this.Gridcustomer.ReadOnly = true;
            this.Gridcustomer.RowHeadersVisible = false;
            this.Gridcustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Gridcustomer.Size = new System.Drawing.Size(644, 489);
            this.Gridcustomer.TabIndex = 2;
            this.Gridcustomer.TabStop = false;
            this.Gridcustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridcustomer_CellClick);
            this.Gridcustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridcustomer_CellContentClick);
            this.Gridcustomer.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridcustomer_CellContentDoubleClick);
            this.Gridcustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridcustomer_CellDoubleClick);
            this.Gridcustomer.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Gridcustomer_RowHeaderMouseClick);
            // 
            // ProfileId
            // 
            this.ProfileId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProfileId.DataPropertyName = "ProfileId";
            this.ProfileId.FillWeight = 40.60913F;
            this.ProfileId.HeaderText = "ID#";
            this.ProfileId.Name = "ProfileId";
            this.ProfileId.ReadOnly = true;
            // 
            // PCompanyName
            // 
            this.PCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PCompanyName.DataPropertyName = "PCompanyName";
            this.PCompanyName.FillWeight = 102.2865F;
            this.PCompanyName.HeaderText = "Company";
            this.PCompanyName.Name = "PCompanyName";
            this.PCompanyName.ReadOnly = true;
            // 
            // PName
            // 
            this.PName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PName.DataPropertyName = "PName";
            this.PName.FillWeight = 123.8338F;
            this.PName.HeaderText = "Name";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            // 
            // PGaurdianName
            // 
            this.PGaurdianName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PGaurdianName.DataPropertyName = "PGaurdianName";
            this.PGaurdianName.FillWeight = 133.2705F;
            this.PGaurdianName.HeaderText = "C/Of";
            this.PGaurdianName.Name = "PGaurdianName";
            this.PGaurdianName.ReadOnly = true;
            // 
            // gridVender
            // 
            this.gridVender.AllowUserToAddRows = false;
            this.gridVender.AllowUserToDeleteRows = false;
            this.gridVender.AllowUserToResizeColumns = false;
            this.gridVender.AllowUserToResizeRows = false;
            this.gridVender.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVender.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gridVender.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridVender.Location = new System.Drawing.Point(7, 6);
            this.gridVender.Margin = new System.Windows.Forms.Padding(4);
            this.gridVender.MultiSelect = false;
            this.gridVender.Name = "gridVender";
            this.gridVender.ReadOnly = true;
            this.gridVender.RowHeadersVisible = false;
            this.gridVender.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVender.Size = new System.Drawing.Size(463, 490);
            this.gridVender.TabIndex = 3;
            this.gridVender.TabStop = false;
            this.gridVender.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVender_CellClick);
            this.gridVender.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVender_CellContentClick);
            this.gridVender.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVender_CellDoubleClick);
            this.gridVender.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridVender_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProfileId";
            this.dataGridViewTextBoxColumn1.FillWeight = 77.7909F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PName";
            this.dataGridViewTextBoxColumn2.FillWeight = 147.089F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "vender_type_name";
            this.dataGridViewTextBoxColumn3.FillWeight = 81.61623F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Job Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(658, 174);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FormProfileFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1123, 501);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblProfileId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewProfile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Gridcustomer);
            this.Controls.Add(this.gridVender);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProfileFm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile Screen";
            this.Load += new System.EventHandler(this.FormCustomerFm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gridcustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerchCompanyName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOfficeAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCnic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPOfficeNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CombProfileType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewProfile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCompnyName;
        private System.Windows.Forms.Label lblProfileId;
        private System.Windows.Forms.ComboBox CombVenderType;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHomeAddress;
        private System.Windows.Forms.DataGridView Gridcustomer;
        private System.Windows.Forms.DataGridView gridVender;
        private System.Windows.Forms.ComboBox CommCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PGaurdianName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}