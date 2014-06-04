namespace Submittal_Tracking_System
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.welcomeTab = new System.Windows.Forms.TabPage();
            this.tabConsultant = new System.Windows.Forms.TabPage();
            this.cDeleteButton = new System.Windows.Forms.Button();
            this.cAddButton = new System.Windows.Forms.Button();
            this.cZipcodeText = new System.Windows.Forms.TextBox();
            this.cStateText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cContactText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cCityText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cAddress2Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cAddress1Text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSubmittals = new System.Windows.Forms.TabPage();
            this.logSubmittalButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.consultantBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tabList = new System.Windows.Forms.TabPage();
            this.cErrorBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ContractorDB = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabConsultant.SuspendLayout();
            this.tabSubmittals.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1320, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.openMenu,
            this.closeMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            this.newMenu.Size = new System.Drawing.Size(103, 22);
            this.newMenu.Text = "New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(103, 22);
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // closeMenu
            // 
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(103, 22);
            this.closeMenu.Text = "Close";
            this.closeMenu.Click += new System.EventHandler(this.closeMenu_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.welcomeTab);
            this.tabControl1.Controls.Add(this.tabConsultant);
            this.tabControl1.Controls.Add(this.tabSubmittals);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1314, 530);
            this.tabControl1.TabIndex = 1;
            // 
            // welcomeTab
            // 
            this.welcomeTab.Location = new System.Drawing.Point(4, 22);
            this.welcomeTab.Name = "welcomeTab";
            this.welcomeTab.Padding = new System.Windows.Forms.Padding(3);
            this.welcomeTab.Size = new System.Drawing.Size(1306, 504);
            this.welcomeTab.TabIndex = 2;
            this.welcomeTab.Text = "Welcome";
            this.welcomeTab.UseVisualStyleBackColor = true;
            // 
            // tabConsultant
            // 
            this.tabConsultant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabConsultant.Controls.Add(this.cDeleteButton);
            this.tabConsultant.Controls.Add(this.cAddButton);
            this.tabConsultant.Controls.Add(this.cZipcodeText);
            this.tabConsultant.Controls.Add(this.cStateText);
            this.tabConsultant.Controls.Add(this.label8);
            this.tabConsultant.Controls.Add(this.label7);
            this.tabConsultant.Controls.Add(this.label6);
            this.tabConsultant.Controls.Add(this.cContactText);
            this.tabConsultant.Controls.Add(this.label5);
            this.tabConsultant.Controls.Add(this.cCityText);
            this.tabConsultant.Controls.Add(this.label4);
            this.tabConsultant.Controls.Add(this.cAddress2Text);
            this.tabConsultant.Controls.Add(this.label3);
            this.tabConsultant.Controls.Add(this.cAddress1Text);
            this.tabConsultant.Controls.Add(this.label2);
            this.tabConsultant.Controls.Add(this.cNameText);
            this.tabConsultant.Controls.Add(this.label1);
            this.tabConsultant.Location = new System.Drawing.Point(4, 22);
            this.tabConsultant.Name = "tabConsultant";
            this.tabConsultant.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsultant.Size = new System.Drawing.Size(1306, 504);
            this.tabConsultant.TabIndex = 0;
            this.tabConsultant.Text = "Consultant";
            this.tabConsultant.UseVisualStyleBackColor = true;
            // 
            // cDeleteButton
            // 
            this.cDeleteButton.Location = new System.Drawing.Point(494, 221);
            this.cDeleteButton.Name = "cDeleteButton";
            this.cDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.cDeleteButton.TabIndex = 16;
            this.cDeleteButton.Text = "Delete";
            this.cDeleteButton.UseVisualStyleBackColor = true;
            // 
            // cAddButton
            // 
            this.cAddButton.Location = new System.Drawing.Point(413, 221);
            this.cAddButton.Name = "cAddButton";
            this.cAddButton.Size = new System.Drawing.Size(75, 23);
            this.cAddButton.TabIndex = 15;
            this.cAddButton.Text = "Add";
            this.cAddButton.UseVisualStyleBackColor = true;
            this.cAddButton.Click += new System.EventHandler(this.cAddButton_Click);
            // 
            // cZipcodeText
            // 
            this.cZipcodeText.Location = new System.Drawing.Point(466, 169);
            this.cZipcodeText.Name = "cZipcodeText";
            this.cZipcodeText.Size = new System.Drawing.Size(103, 20);
            this.cZipcodeText.TabIndex = 14;
            // 
            // cStateText
            // 
            this.cStateText.Location = new System.Drawing.Point(374, 169);
            this.cStateText.MaxLength = 2;
            this.cStateText.Name = "cStateText";
            this.cStateText.Size = new System.Drawing.Size(27, 20);
            this.cStateText.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Zip Code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "State:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Contact Person:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cContactText
            // 
            this.cContactText.Location = new System.Drawing.Point(202, 195);
            this.cContactText.Name = "cContactText";
            this.cContactText.Size = new System.Drawing.Size(367, 20);
            this.cContactText.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "City:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cCityText
            // 
            this.cCityText.Location = new System.Drawing.Point(202, 169);
            this.cCityText.Name = "cCityText";
            this.cCityText.Size = new System.Drawing.Size(125, 20);
            this.cCityText.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address Line 2:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cAddress2Text
            // 
            this.cAddress2Text.Location = new System.Drawing.Point(202, 143);
            this.cAddress2Text.Name = "cAddress2Text";
            this.cAddress2Text.Size = new System.Drawing.Size(367, 20);
            this.cAddress2Text.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cAddress1Text
            // 
            this.cAddress1Text.Location = new System.Drawing.Point(202, 117);
            this.cAddress1Text.Name = "cAddress1Text";
            this.cAddress1Text.Size = new System.Drawing.Size(367, 20);
            this.cAddress1Text.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cNameText
            // 
            this.cNameText.Location = new System.Drawing.Point(202, 91);
            this.cNameText.Name = "cNameText";
            this.cNameText.Size = new System.Drawing.Size(367, 20);
            this.cNameText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultant Information";
            // 
            // tabSubmittals
            // 
            this.tabSubmittals.Controls.Add(this.logSubmittalButton);
            this.tabSubmittals.Controls.Add(this.panel3);
            this.tabSubmittals.Controls.Add(this.panel2);
            this.tabSubmittals.Controls.Add(this.panel1);
            this.tabSubmittals.Controls.Add(this.label9);
            this.tabSubmittals.Location = new System.Drawing.Point(4, 22);
            this.tabSubmittals.Name = "tabSubmittals";
            this.tabSubmittals.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubmittals.Size = new System.Drawing.Size(1306, 504);
            this.tabSubmittals.TabIndex = 1;
            this.tabSubmittals.Text = "Submittals";
            this.tabSubmittals.UseVisualStyleBackColor = true;
            // 
            // logSubmittalButton
            // 
            this.logSubmittalButton.AutoSize = true;
            this.logSubmittalButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.logSubmittalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logSubmittalButton.Location = new System.Drawing.Point(799, 48);
            this.logSubmittalButton.Name = "logSubmittalButton";
            this.logSubmittalButton.Size = new System.Drawing.Size(127, 53);
            this.logSubmittalButton.TabIndex = 5;
            this.logSubmittalButton.Text = "Log";
            this.logSubmittalButton.UseVisualStyleBackColor = true;
            this.logSubmittalButton.Click += new System.EventHandler(this.logSubmittalButton_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Controls.Add(this.textBox8);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.dateTimePicker3);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(39, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 143);
            this.panel3.TabIndex = 4;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(174, 116);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(300, 20);
            this.textBox9.TabIndex = 15;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(174, 90);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(300, 20);
            this.textBox8.TabIndex = 14;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Accepted",
            "Approved As Noted",
            "Revise and Resubmit",
            "Not Accepted",
            "Resubmittal Received"});
            this.comboBox3.Location = new System.Drawing.Point(174, 63);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(173, 21);
            this.comboBox3.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(174, 37);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(54, 20);
            this.textBox7.TabIndex = 12;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(174, 11);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker3.TabIndex = 11;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Delivered",
            "US Mail",
            "Fedex",
            "UPS?",
            "Courier Service",
            "Picked Up"});
            this.comboBox2.Location = new System.Drawing.Point(353, 10);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(109, 119);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 13);
            this.label25.TabIndex = 5;
            this.label25.Text = "Comments:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(128, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 4;
            this.label24.Text = "Action:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(146, 93);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "By:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(280, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Shipped Via:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(72, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Quantity Returned:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Date Returned to Contractor:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.consultantBox);
            this.panel2.Location = new System.Drawing.Point(39, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 124);
            this.panel2.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(174, 91);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(174, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Delivered",
            "US Mail",
            "Fedex",
            "UPS?",
            "Courier Service",
            "Picked Up"});
            this.comboBox1.Location = new System.Drawing.Point(353, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(174, 39);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(54, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Quantity to Consultant:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 94);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Date Returned From Consultant:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(280, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Shipped Via:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Date Forwarded to Consultant:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(77, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Consultant Name:";
            // 
            // consultantBox
            // 
            this.consultantBox.FormattingEnabled = true;
            this.consultantBox.Location = new System.Drawing.Point(174, 12);
            this.consultantBox.Name = "consultantBox";
            this.consultantBox.Size = new System.Drawing.Size(300, 21);
            this.consultantBox.TabIndex = 0;
            this.consultantBox.Click += new System.EventHandler(this.consultantBox_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(39, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 151);
            this.panel1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(174, 37);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(174, 63);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(300, 20);
            this.textBox4.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(174, 115);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(70, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Quantity Received:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Date Received:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Description:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Submittal Number:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Specification Section:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(293, 42);
            this.label9.TabIndex = 1;
            this.label9.Text = "Log New Submittal\r\n";
            // 
            // tabLog
            // 
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1306, 504);
            this.tabLog.TabIndex = 3;
            this.tabLog.Text = "Submittal Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // tabList
            // 
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(1306, 504);
            this.tabList.TabIndex = 4;
            this.tabList.Text = "Consultant List";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // cErrorBox
            // 
            this.cErrorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cErrorBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cErrorBox.ForeColor = System.Drawing.Color.Red;
            this.cErrorBox.Location = new System.Drawing.Point(3, 539);
            this.cErrorBox.Name = "cErrorBox";
            this.cErrorBox.Size = new System.Drawing.Size(1314, 89);
            this.cErrorBox.TabIndex = 17;
            this.cErrorBox.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cErrorBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 631);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ContractorDB
            // 
            this.ContractorDB.FileName = " ContractorDB.sdf";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 655);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Submittal Tracking System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabConsultant.ResumeLayout(false);
            this.tabConsultant.PerformLayout();
            this.tabSubmittals.ResumeLayout(false);
            this.tabSubmittals.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem closeMenu;
        private System.Windows.Forms.FolderBrowserDialog setDirectory;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConsultant;
        private System.Windows.Forms.TextBox cZipcodeText;
        private System.Windows.Forms.TextBox cStateText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cContactText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cCityText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cAddress2Text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cAddress1Text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSubmittals;
        private System.Windows.Forms.Button cDeleteButton;
        private System.Windows.Forms.Button cAddButton;
        private System.Windows.Forms.RichTextBox cErrorBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage welcomeTab;
        private System.Windows.Forms.OpenFileDialog ContractorDB;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox consultantBox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button logSubmittalButton;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
    }
}

