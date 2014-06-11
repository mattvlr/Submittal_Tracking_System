using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;

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
            tabControl1.Hide();
            cErrorBox.Hide();

        }
        private void closeMenu_Click(object sender, EventArgs e)
        {
         Globals.Consultantfilepath = "";
         Globals.Projectfilepath = "";
         Globals.connectionStringConsultant = "";
         Globals.connectionStringProject = "";
         Globals.jobTitle = "";
         Globals.jobNumber = "";
         tabControl1.Visible = false;
         cErrorBox.Visible = false;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        public void forceScroll()
        {
            cErrorBox.SelectionStart = cErrorBox.Text.Length;
            cErrorBox.ScrollToCaret();
        }

        //Create Database methods
        private void createProjectDatabase()
        {
            string filename = "DB.sdf";

            if (File.Exists(filename))
                File.Delete(filename);

            Globals.connectionStringProject = "DataSource=\"DB.sdf\"; Password=\"password\"";
            SqlCeEngine en = new SqlCeEngine(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);
            en.CreateDatabase();

            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand SubmittalsCMD;
            SqlCeCommand ContractorCMD;

            string sql = "create table Submittals ("
            + "SubmittalNum INT IDENTITY(1,1) PRIMARY KEY, "
            + "SectionNum nvarchar (40), "
            + "NumReceived nvarchar (40), "
            + "Description nvarchar (200), "
            + "ReceivedDate nvarchar (40), "
            + "DateDue nvarchar (40), "
            + "Consultant nvarchar (200), "
            + "ToConsultantDate nvarchar (40), "
            + "QuantityToConsultant nvarchar (40), "
            + "ConsultantVia nvarchar (40), "
            + "FromConsultantDate nvarchar (40), "
            + "ToContractorDate nvarchar (40), "
            + "Quantity nvarchar (40), " 
            + "ContractorVia nvarchar (40), "
            + "Action nvarchar (40), "
            + "Name nvarchar (40), "
            + "Comments nvarchar(200) )";
 
            string sql1 = "create table Contractor ( "
            + "Name nvarchar (200), "
            + "Address nvarchar (200), "
            + "Address2 nvarchar (200), "
            + "City nvarchar (200), "
            + "State nvarchar (2), "
            + "Zipcode nvarchar (10), " 
            + "ContactPerson nvarchar (200) )";


            SubmittalsCMD = new SqlCeCommand(sql, cn);
            ContractorCMD = new SqlCeCommand(sql1, cn);
            try
            {
                 SubmittalsCMD.ExecuteNonQuery();
                 ContractorCMD.ExecuteNonQuery();
                 MessageBox.Show("Tables successfully created! \n Located in directory: " + Globals.Projectfilepath);
            }
            catch (SqlCeException sqlexception)
            {
                 MessageBox.Show(sqlexception.Message, "SQL Error.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Other Error.", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();  
            }
        }
        private void createConsultantDatabase()
        {
            string filename = "ConsultantDB.sdf";

            if (File.Exists(filename))
                File.Delete(filename);

            Globals.connectionStringConsultant = "DataSource=\"ConsultantDB.sdf\"; Password=\"password\"";
            SqlCeEngine en = new SqlCeEngine(Globals.connectionStringConsultant);
            en.CreateDatabase();

            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand ConsultantCMD;

            string sql = "create table Consultant ( "
            + "ConsultantNum INT IDENTITY(1,1) PRIMARY KEY, "
            + "Name nvarchar (200), "
            + "Address nvarchar (200), "
            + "Address2 nvarchar (200), "
            + "City nvarchar (200), "
            + "State nvarchar (2), "
            + "Zipcode nvarchar (10), "
            + "ContactPerson nvarchar (200) )";

            ConsultantCMD = new SqlCeCommand(sql, cn);
            try
            {
                ConsultantCMD.ExecuteNonQuery();
                MessageBox.Show("Consultant database successfully created! \n Located in directory: " + Globals.Consultantfilepath);
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "SQL Error.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Other Error.", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }

        //Consultant Tab methods
        private void cAddButton_Click(object sender, EventArgs e)
        {
    
            int flagCounter = 0;
            string AddressLine2 = "";
            if (cNoRB.Checked)
            {
                if (cNameText.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No name entered!\n"); // NAME
                    forceScroll();
                    cNameText.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cNameText.BackColor = Color.White;
                }

                if (cAddress1Text.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No address entered!\n"); //ADDRESS
                    forceScroll();
                    cAddress1Text.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cAddress1Text.BackColor = Color.White;
                }

                if (cCityText.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No city entered!\n"); //CITY
                    forceScroll();
                    cCityText.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cCityText.BackColor = Color.White;
                }
                if (cStateText.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No state entered!\n"); //STATE
                    forceScroll();
                    cStateText.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cStateText.BackColor = Color.White;
                }
                if (cZipcodeText.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No zipcode entered!\n"); //ZIPCODE
                    forceScroll();
                    cZipcodeText.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cZipcodeText.BackColor = Color.White;
                }
                if (cContactText.Text == "")
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: No contact person entered!\n"); // CONTACT PERSON
                    forceScroll();
                    cContactText.BackColor = Color.MistyRose;
                }
                else
                {
                    flagCounter++;
                    cContactText.BackColor = Color.White;
                }
                if (cAddress2Text.Text == "") //ADDRESS LINE 2
                    AddressLine2 = "";
                else
                    AddressLine2 = cAddress2Text.Text;

                if (flagCounter == 6)
                {
                    SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
                    Directory.SetCurrentDirectory(Globals.Consultantfilepath);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCeCommand cmd;

                    string sql = "insert into Consultant "
                    + "(Name, Address, Address2, City, State, Zipcode, ContactPerson) "
                    + "values (@name, @address, @address2, @city, @state, @zipcode, @contactperson) ";

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@name", cNameText.Text);
                        cmd.Parameters.AddWithValue("@address", cAddress1Text.Text);
                        cmd.Parameters.AddWithValue("@address2", AddressLine2);
                        cmd.Parameters.AddWithValue("@city", cCityText.Text);
                        cmd.Parameters.AddWithValue("@state", cStateText.Text);
                        cmd.Parameters.AddWithValue("@zipcode", cZipcodeText.Text);
                        cmd.Parameters.AddWithValue("@contactperson", cContactText.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant added to database!\n");
                        forceScroll();
                        ConsultantRefresh();
                        
                    }
                    catch (SqlCeException sqlexception)
                    {
                        MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();

                    }

                }
            }
            else if(cYesRB.Checked)
            {

                    cContactText.BackColor = Color.White;
                    cZipcodeText.BackColor = Color.White;
                    cStateText.BackColor = Color.White;
                    cCityText.BackColor = Color.White;
                    cAddress1Text.BackColor = Color.White;
                    cNameText.BackColor = Color.White;

                    SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
                    Directory.SetCurrentDirectory(Globals.Consultantfilepath);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCeCommand cmd;

                    string sql = "insert into Consultant "
                    + "(Name, Address, Address2, City, State, Zipcode, ContactPerson) "
                    + "values (@name, @address, @address2, @city, @state, @zipcode, @contactperson) ";

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@name", cNameText.Text);
                        cmd.Parameters.AddWithValue("@address", cAddress1Text.Text);
                        cmd.Parameters.AddWithValue("@address2", AddressLine2);
                        cmd.Parameters.AddWithValue("@city", cCityText.Text);
                        cmd.Parameters.AddWithValue("@state", cStateText.Text);
                        cmd.Parameters.AddWithValue("@zipcode", cZipcodeText.Text);
                        cmd.Parameters.AddWithValue("@contactperson", cContactText.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant added to database!\n");
                        forceScroll();
                        ConsultantRefresh();
                    }
                    catch (SqlCeException sqlexception)
                    {
                        MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();

                    }

                
            }
        }
        private void cDeleteButton_Click(object sender, EventArgs e)
        {
            int count = ConsultantView.SelectedRows.Count;

            while (count > 0)
            {
                if (!ConsultantView.SelectedRows[0].IsNewRow)
                    ConsultantView.Rows.RemoveAt(ConsultantView.SelectedRows[0].Index);

                count--;
            }
        }
        private void cClearButton_Click(object sender, EventArgs e)
        {
            if (cNameText.Text != "")
                cNameText.Text = "";
            if (cAddress1Text.Text != "")
                cAddress1Text.Text = "";
            if (cAddress2Text.Text != "")
                cAddress2Text.Text = "";
            if (cCityText.Text != "")
                cCityText.Text = "";
            if (cStateText.Text != "")
                cStateText.Text = "";
            if (cZipcodeText.Text != "")
                cZipcodeText.Text = "";
            if (cContactText.Text != "")
                cContactText.Text = "";
            cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Form cleared.\n"); // NAME
            forceScroll();

        }
        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        string messageBoxText1 = "Are you sure you wish to delete the currently selected row?";
                        string caption1 = "Delete row.";
                        MessageBoxButtons button = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Warning;

                        if (MessageBox.Show(messageBoxText1, caption1, button, icon) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ConsultantView.Rows.RemoveAt(this.ConsultantView.SelectedRows[0].Index);
                            ConsultantRefresh();
                        }
        }


        private void cConsultantEditCB_Click(object sender, EventArgs e)
        {
            cConsultantEditCB.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
            Directory.SetCurrentDirectory(Globals.Consultantfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT Name FROM Consultant";
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving Consultants from database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);
                using (SqlCeDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        cConsultantEditCB.Items.Add(oReader["Name"].ToString());
                    }
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Dropdown populated!\n");
                forceScroll();
            }
        }
        private void cConsultantEditCB_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
            Directory.SetCurrentDirectory(Globals.Consultantfilepath);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT * FROM Consultant where Name = " + cConsultantEditCB.Text;
            try
            {
               // cmd = new SqlCeCommand(sql, cn);
               // returnVal = cmd.ExecuteScalar();
               // zlabel31.Text = returnVal.ToString();
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant retrieved.\n");
                forceScroll();
            }
        }

        private void ConsultantView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ConsultantView.ClearSelection();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ConsultantView.Rows[e.RowIndex].Selected = true;
                Rectangle r = ConsultantView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                contextMenuStrip1.Show((Control)sender, r.Left + e.X, r.Top + e.Y);

            }
        }

        //File I/O methods
        private void openMenu_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
            {
                Globals.Projectfilepath = setDirectory.SelectedPath;
                Directory.SetCurrentDirectory(Globals.Projectfilepath);
                wProjectLoc.Text = Globals.Projectfilepath;

                if (File.Exists("DB.sdf"))
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Setting " + Globals.Projectfilepath + "\\DB.sdf as working directory.\n");
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Found DB.sdf in working directory.\n");
                    forceScroll();

                    Globals.connectionStringProject = "DataSource=\"DB.sdf\"; Password=\"password\"";
                    SubmittalRefresh();

                    if (Globals.connectionStringConsultant == null)
                    {
                        string messageBoxText1 = "The path for ConsultantDB.sdf has not been set, would you like to browse for it now?";
                        string caption1 = "Path to ConsultantDB.sdf";
                        MessageBoxButtons button = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Information;

                        if (MessageBox.Show(messageBoxText1, caption1, button, icon) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (setDirectory.ShowDialog() == DialogResult.OK)
                                Globals.Consultantfilepath = setDirectory.SelectedPath;

                            wConsultantLoc.Text = Globals.Consultantfilepath;
                            Directory.SetCurrentDirectory(Globals.Consultantfilepath);
                            Globals.connectionStringConsultant = "DataSource=\"ConsultantDB.sdf\"; Password=\"password\"";

                            try
                            {
                                if (File.Exists("ConsultantDB.sdf"))
                                {
                                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Path set for ConsultantDB.sdf  " + Globals.Consultantfilepath + "\n");
                                    forceScroll();
                                    tabControl1.Visible = true;
                                    cErrorBox.Visible = true;
                                    ConsultantRefresh();
                                }
                                else
                                {
                                    string messageBoxText2 = "Could no find ConsultantDB.sdf in the chosen directory, would you like to create a new one?";
                                    string caption2 = "Create new ConsultantaDB.sdf";

                                    if (MessageBox.Show(messageBoxText2, caption2, button, icon) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        if (setDirectory.ShowDialog() == DialogResult.OK)
                                            Globals.Consultantfilepath = setDirectory.SelectedPath;

                                        wConsultantLoc.Text = Globals.Consultantfilepath;
                                        try
                                        {
                                            if (File.Exists("ConsultantDB.sdf"))
                                            {
                                                MessageBox.Show("ConsultantDB.sdf already exists in " + Globals.Consultantfilepath + " please pick another location. ");
                                            }
                                            else
                                            {
                                                Directory.SetCurrentDirectory(Globals.Consultantfilepath);
                                                tabControl1.Visible = true;
                                                cErrorBox.Visible = true;
                                                createConsultantDatabase();

                                            }

                                        }
                                        catch (DirectoryNotFoundException err)
                                        {
                                            cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: The specified directory does not exist. {0} \n");
                                            forceScroll();
                                        }
                                    }

                                }

                            }
                            catch (DirectoryNotFoundException err)
                            {
                                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: The specified directory does not exist. {0} \n");
                                forceScroll();
                            }

                            if ((Globals.Projectfilepath == null) || (Globals.Consultantfilepath == null))
                            {
                                SubmittalRefresh();
                                ConsultantRefresh();
                            }
                        }
                        else // if the answer to the messagebox was not yes
                        {
                            tabControl1.Visible = true;
                            cErrorBox.Visible = true;
                            wConsultantLoc.BackColor = Color.MistyRose;
                            zlabel29.Text = "Please browse to ConsultantDB.sdf or make a new one.";
                            wConsultantLoc.Focus();
                        }
                    }
                else
                {
                     cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: 'DB.sdf' was not found, please try another location.\n");
                     forceScroll();
                }
                    

                }
            }
        }
        private void consultantDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
                Globals.Consultantfilepath = setDirectory.SelectedPath;

            wConsultantLoc.Text = Globals.Consultantfilepath;
            try
            {
                if (File.Exists("ConsultantDB.sdf"))
                {
                    MessageBox.Show("ConsultantDB.sdf already exists in " + Globals.Consultantfilepath + " please pick another location.");
                }
                else
                {
                    Directory.SetCurrentDirectory(Globals.Consultantfilepath);
                    tabControl1.Visible = true;
                    cErrorBox.Visible = true;
                    createConsultantDatabase();

                }

            }
            catch (DirectoryNotFoundException err)
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: The specified directory does not exist. {0}");
                forceScroll();
            }
        }
        private void submittalDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
                Globals.Projectfilepath = setDirectory.SelectedPath;

            wProjectLoc.Text = Globals.Projectfilepath;
            try
            {
                if (File.Exists("DB.sdf"))
                {
                    MessageBox.Show("DB.sdf already exists in " + Globals.Projectfilepath + " please pick another location.");
                }
                else
                {
                    Directory.SetCurrentDirectory(Globals.Projectfilepath);
                    tabControl1.Visible = true;
                    cErrorBox.Visible = true;
                    createProjectDatabase();
                    zlabel29.Text = "Please browse to ConsultantDB.sdf or make a new one.";
                    wConsultantLoc.Focus();
                    wConsultantLoc.BackColor = Color.MistyRose;
                    tabControl1.SelectedIndex = 0;


                }

            }
            catch (DirectoryNotFoundException err)
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: the specified directory does not exist. {0}");
                forceScroll();
            }

        }
        private void wBrowseConsultant_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
            {
                Globals.Consultantfilepath = setDirectory.SelectedPath;
                Directory.SetCurrentDirectory(Globals.Consultantfilepath);
                if (File.Exists("ConsultantDB.sdf") == true)
                {
                    wConsultantLoc.Text = Globals.Consultantfilepath;
                    Globals.connectionStringConsultant = "DataSource=\"ConsultantDB.sdf\"; Password=\"password\"";
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Location of 'ConsultantDB.sdf' is now: " + Globals.Projectfilepath + "\n");
                    forceScroll();
                    ConsultantRefresh();
                }
                else
                {
                    MessageBox.Show("Could not find 'DB.sdf' in that location, please browse again or create a new one.");
                    Globals.Consultantfilepath = "";
                }
            }
        }
        private void wBrowseProject_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
            {
                Globals.Projectfilepath = setDirectory.SelectedPath;
                Directory.SetCurrentDirectory(Globals.Projectfilepath);
                if (File.Exists("DB.sdf") == true)
                {
                    wProjectLoc.Text = Globals.Projectfilepath;
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Location of 'DB.sdf' is now: " + Globals.Projectfilepath + "\n");
                    forceScroll();
                }
                else
                {
                    MessageBox.Show("Could not find 'DB.sdf' in that location, please browse again or create a new one.");
                    Globals.Projectfilepath = "";
                }
            }
        }

        private void wConsultantLoc_TextChanged(object sender, EventArgs e)
        {
            zlabel29.Text = "Path to ConsultantDB.sdf: ";
            wConsultantLoc.BackColor = Color.White;
        }

        //Submittal Tab methods
        private void consultantBox_Click(object sender, EventArgs e)
        {
            sConsultantBox.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
            Directory.SetCurrentDirectory(Globals.Consultantfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT Name FROM Consultant";
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving Consultants from database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);
                using (SqlCeDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        sConsultantBox.Items.Add(oReader["Name"].ToString());
                    }
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Dropdown populated!\n");
                forceScroll();
            }
        }
        private void logSubmittalButton_Click(object sender, EventArgs e)
        {
            
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "insert into Submittals "
            + "(ReceivedDate, SectionNum, Description, NumReceived, Consultant, DateDue, ToConsultantDate, QuantityToConsultant, ConsultantVia, FromConsultantDate, ToContractorDate, Quantity, ContractorVia, Action, Name, Comments) "
            + "values (@ReceivedDate, @SectionNum, @Description, @NumReceived, @Consultant, @DateDue, @ToConsultantDate, @QuantityToConsultant, @ConsultantVia, @FromConsultantDate, @ToContractorDate, @Quantity, @ContractorVia, @Action, @Name, @Comments) ";

            try
            {
                cmd = new SqlCeCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                cmd.Parameters.AddWithValue("@SectionNum", sSpecNumBox.Text);
                //cmd.Parameters.AddWithValue("@SubmittalNum", sSubmittalDropdown.Text);
                cmd.Parameters.AddWithValue("@Description", sDescriptionBox.Text);
                cmd.Parameters.AddWithValue("@NumReceived", sNumReceivedBox.Text);
                cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                cmd.ExecuteNonQuery();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal added to database!\n");
                forceScroll();

            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                SubmittalRefresh();
            }
                
                
        }
        private void sSubmittalDropdown_Click(object sender, EventArgs e)
        {
            sSubmittalDropdown.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT SubmittalNum FROM Submittals";
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving Submittals from database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);
                using (SqlCeDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        sSubmittalDropdown.Items.Add(oReader["SubmittalNum"].ToString());
                    }
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Dropdown populated!\n");
                forceScroll();
            }


        }
        private void sSubmittalDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        //Database Tab button methods
        private void subDeletebtn_Click(object sender, EventArgs e)
        {
            int count = 0;

            string text = "Are you should you want to delete " + count + " rows?";
            string caption = "Delete selected rows.";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            if (MessageBox.Show(text, caption, button, icon) == System.Windows.Forms.DialogResult.Yes)
            {

                int yCoord = SubmittalsView.CurrentCellAddress.Y;
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }


                foreach (DataGridViewRow row in SubmittalsView.SelectedRows)
                {

                    SqlCeCommand cmd;
                    int y = SubmittalsView.CurrentCellAddress.Y;
                    string sql = "DELETE * FROM Submittals where SubmittalNum = " + y;

                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Deleting row: " + y + " from table.\n");
                    forceScroll();
                    cmd = new SqlCeCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }

                SubmittalRefresh();
            }

        }

        //Database refreshers
        private void SubmittalRefresh()
        {
            Directory.SetCurrentDirectory(Globals.Projectfilepath);
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCeCommand cmd = new SqlCeCommand("Submittals", cn);
                cmd.CommandType = CommandType.TableDirect;

                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal table was refreshed.\n");
                forceScroll();
                SubmittalsView.DataSource = rs;
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConsultantRefresh()
        {
            Directory.SetCurrentDirectory(Globals.Consultantfilepath);
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringConsultant);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCeCommand cmd = new SqlCeCommand("Consultant", cn);
                cmd.CommandType = CommandType.TableDirect;

                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant table was refreshed.\n");
                forceScroll();
                ConsultantView.DataSource = rs;
                cRowsCountLB.Text = ConsultantView.Rows.Count.ToString();
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Misc Database methods
        private void SubmittalsView_DoubleClick(object sender, EventArgs e)
        {
            int yCoord = SubmittalsView.CurrentCellAddress.Y;

            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            
            this.tabControl1.SelectedIndex = 3;

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT * FROM Submittals where SubmittalNum = " + yCoord;

            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving row contents from database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);
                using (SqlCeDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        sSubmittalDateBox.Text = oReader["ReceivedDate"].ToString();
                        sSubmittalDropdown.Text = oReader["SubmittalNum"].ToString();
                        sDescriptionBox.Text = oReader["Description"].ToString();
                        sNumReceivedBox.Text = oReader["NumReceived"].ToString();
                        sConsultantBox.Text = oReader["Consultant"].ToString();
                        sConsultantDateDueBox.Text = oReader["DateDue"].ToString();
                        sToConsultantDateBox.Text = oReader["ToConsultantDate"].ToString();
                        sQuantityConsultantBox.Text = oReader["QuantityToConsultant"].ToString();
                        sConsultantViaBox.Text = oReader["ConsultantVia"].ToString();
                        sFromConsultantDateBox.Text = oReader["FromConsultantDate"].ToString();
                        sReturnedCBox.Text = oReader["ToContractorDate"].ToString();
                        sQuantityReturnedBox.Text = oReader["Quantity"].ToString();
                        sContractorViaBox.Text = oReader["ContractorVia"].ToString();
                        sActionBox.Text = oReader["Action"].ToString();
                        sNameBox.Text = oReader["Name"].ToString();
                        sCommentBox.Text = oReader["Comments"].ToString();
                    }
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal tab populated!\n");
                forceScroll();
            }

        }
      
        //Tab locker
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (wConsultantLoc.Text == "")
          //      tabControl1.SelectedIndex = 0;
         //   if (wProjectLoc.Text == "")
         //       tabControl1.SelectedIndex = 0;

            if (wConsultantLoc.Text == "")
                tabControl1.SelectedTab = welcomeTab;
            if (wProjectLoc.Text == "")
                tabControl1.SelectedTab = welcomeTab;
        }


   



 

  







    }

    public static class Globals // class that holds "global" variables
    {
        public static string Consultantfilepath { get; set; }
        public static string Projectfilepath { get; set; }
        public static string connectionStringConsultant { get; set; }
        public static string connectionStringProject { get; set; }
        public static string jobTitle { get; set; }
        public static string jobNumber { get; set; }
    }

    

}
