namespace Submittal_Tracking_System
{
    partial class JobEntry
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
            this.jobTitleBox = new System.Windows.Forms.TextBox();
            this.JobNumberBox = new System.Windows.Forms.TextBox();
            this.okayBut = new System.Windows.Forms.Button();
            this.cancelBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Title: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Job Number:";
            // 
            // jobTitleBox
            // 
            this.jobTitleBox.Location = new System.Drawing.Point(99, 35);
            this.jobTitleBox.Name = "jobTitleBox";
            this.jobTitleBox.Size = new System.Drawing.Size(170, 20);
            this.jobTitleBox.TabIndex = 2;
            // 
            // JobNumberBox
            // 
            this.JobNumberBox.Location = new System.Drawing.Point(99, 61);
            this.JobNumberBox.Name = "JobNumberBox";
            this.JobNumberBox.Size = new System.Drawing.Size(170, 20);
            this.JobNumberBox.TabIndex = 3;
            // 
            // okayBut
            // 
            this.okayBut.Location = new System.Drawing.Point(99, 87);
            this.okayBut.Name = "okayBut";
            this.okayBut.Size = new System.Drawing.Size(80, 23);
            this.okayBut.TabIndex = 4;
            this.okayBut.Text = "Submit";
            this.okayBut.UseVisualStyleBackColor = true;
            this.okayBut.Click += new System.EventHandler(this.okayBut_Click);
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(189, 87);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(80, 23);
            this.cancelBut.TabIndex = 5;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // JobEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 122);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.okayBut);
            this.Controls.Add(this.JobNumberBox);
            this.Controls.Add(this.jobTitleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JobEntry";
            this.Text = "New Job Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jobTitleBox;
        private System.Windows.Forms.TextBox JobNumberBox;
        private System.Windows.Forms.Button okayBut;
        private System.Windows.Forms.Button cancelBut;
    }
}