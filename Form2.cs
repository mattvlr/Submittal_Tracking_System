using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Submittal_Tracking_System
{
    public partial class JobEntry : Form
    {
        public JobEntry()
        {
            InitializeComponent();
        }

        private void okayBut_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (jobTitleBox.Text == "")
            {
                jobTitleBox.BackColor = Color.MistyRose;
            }
            else
            {
                jobTitleBox.BackColor = Color.White;
                Globals.jobTitle = jobTitleBox.Text;
                count++;
            }

            if(JobNumberBox.Text == "")
            {
                JobNumberBox.BackColor = Color.MistyRose;

            }
            else
            {
                JobNumberBox.BackColor = Color.White;
                Globals.jobTitle = JobNumberBox.Text;
                count++;
            }

            if (count == 2)
            {
                this.Close();
            }
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
