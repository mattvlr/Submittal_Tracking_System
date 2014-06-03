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
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newMenu_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
                Globals.filepath = setDirectory.SelectedPath;
            createDatabase();

        }
        private void createDatabase()
        {

        }
    }

    public static class Globals // class that holds "global" variables
    {
        public static string filepath { get; set; }
    }

 

}
