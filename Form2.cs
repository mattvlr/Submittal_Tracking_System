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
            string title = "";
            string number = "";
            title = jobTitleBox.Text;
            number = JobNumberBox.Text;

        }
    }
}
