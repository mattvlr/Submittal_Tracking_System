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
            this.tabConsultant = new System.Windows.Forms.TabPage();
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
            this.cAddButton = new System.Windows.Forms.Button();
            this.cDeleteButton = new System.Windows.Forms.Button();
            this.cErrorBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.welcomeTab = new System.Windows.Forms.TabPage();
            this.ContractorDB = new System.Windows.Forms.OpenFileDialog();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tabList = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabConsultant.SuspendLayout();
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
            this.newMenu.Size = new System.Drawing.Size(152, 22);
            this.newMenu.Text = "New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(152, 22);
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // closeMenu
            // 
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(152, 22);
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
            this.tabSubmittals.Location = new System.Drawing.Point(4, 22);
            this.tabSubmittals.Name = "tabSubmittals";
            this.tabSubmittals.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubmittals.Size = new System.Drawing.Size(1306, 504);
            this.tabSubmittals.TabIndex = 1;
            this.tabSubmittals.Text = "Submittals";
            this.tabSubmittals.UseVisualStyleBackColor = true;
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
            // cDeleteButton
            // 
            this.cDeleteButton.Location = new System.Drawing.Point(494, 221);
            this.cDeleteButton.Name = "cDeleteButton";
            this.cDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.cDeleteButton.TabIndex = 16;
            this.cDeleteButton.Text = "Delete";
            this.cDeleteButton.UseVisualStyleBackColor = true;
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
            // ContractorDB
            // 
            this.ContractorDB.FileName = " ContractorDB.sdf";
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
    }
}

