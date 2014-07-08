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
using ClosedXML;

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
          //  tabControl1.Hide();
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
            SqlCeCommand ProjectInfoCMD;

            string sql = "create table Submittals ("
            + "SubmittalNum INT IDENTITY(1,1) PRIMARY KEY, "
            + "SpecSection nvarchar (40), "
            + "NumReceived nvarchar (40), "
            + "ProjectTitle nvarchar (200), "
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
            + "TotalDays nvarchar (40), "
            + "Action nvarchar (40), "
            + "Name nvarchar (40), "
            + "Comments nvarchar(200) )";

            string sql1 = "create table Contractor ( "
            + "Num INT IDENTITY(1,1) PRIMARY KEY, "
            + "Name nvarchar (200), "
            + "Address nvarchar (200), "
            + "Address2 nvarchar (200), "
            + "City nvarchar (200), "
            + "State nvarchar (2), "
            + "Zipcode nvarchar (10), "
            + "ContactPerson nvarchar (200) )";

            string sql2 = "create table ProjectInfo ( "
            + "Num INT IDENTITY(1,1) PRIMARY KEY, "
            + "Title nvarchar (200), "
            + "Number nvarchar (40) )";


            SubmittalsCMD = new SqlCeCommand(sql, cn);
            ContractorCMD = new SqlCeCommand(sql1, cn);
            ProjectInfoCMD = new SqlCeCommand(sql2, cn);
            try
            {
                SubmittalsCMD.ExecuteNonQuery();
                ContractorCMD.ExecuteNonQuery();
                ProjectInfoCMD.ExecuteNonQuery();
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
                // + "ConsultantNum INT IDENTITY(1,1), "
            + "ConsultantNum INT IDENTITY(1,1) PRIMARY KEY, "
                //+ "ConsultantNum nvarchar(10), "
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
                        cmd.Parameters.AddWithValue("@address2", cAddress2Text.Text);
                        cmd.Parameters.AddWithValue("@city", cCityText.Text);
                        cmd.Parameters.AddWithValue("@state", cStateText.Text);
                        cmd.Parameters.AddWithValue("@zipcode", cZipcodeText.Text);
                        cmd.Parameters.AddWithValue("@contactperson", cContactText.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant added to database!\n");
                        forceScroll();
                        ConsultantRefresh();
                        //RC();
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
            else if (cYesRB.Checked)
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
                    cmd.Parameters.AddWithValue("@address2", cAddress2Text.Text);
                    cmd.Parameters.AddWithValue("@city", cCityText.Text);
                    cmd.Parameters.AddWithValue("@state", cStateText.Text);
                    cmd.Parameters.AddWithValue("@zipcode", cZipcodeText.Text);
                    cmd.Parameters.AddWithValue("@contactperson", cContactText.Text);
                    cmd.ExecuteNonQuery();

                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Consultant added to database!\n");
                    forceScroll();
                    ConsultantRefresh();
                    //RC();
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
                //RC();
            }
        }
        private void ConsultantView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ConsultantView.ClearSelection();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ConsultantView.Rows[e.RowIndex].Selected = true;
                Rectangle r = ConsultantView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                consultantMenuStrip.Show((Control)sender, r.Left + e.X, r.Top + e.Y);

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
                    GetProjectInfoDataBase();
                    GetContractorInfoDataBase();
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
                                    //RC();
                                }
                                else
                                {
                                    string messageBoxText2 = "Could not find ConsultantDB.sdf in the chosen directory, would you like to create a new one?";
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
                                                ConsultantRefresh();
                                                //RC();
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
                                //RC();
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
                else
                {
                    MessageBox.Show("Error: 'DB.sdf' was not found, please try another location.\n");
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
            
            Globals.ProjectTitle = Microsoft.VisualBasic.Interaction.InputBox("Set Project Title: ", "Project Title");
            Globals.ProjectNum = Microsoft.VisualBasic.Interaction.InputBox("Set Project Number: ", "Project Number");


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
                    if (Globals.Consultantfilepath == "")
                    {
                        zlabel29.Text = "Please browse to ConsultantDB.sdf or make a new one.";
                        wConsultantLoc.Focus();
                        wConsultantLoc.BackColor = Color.MistyRose;
                    }
                    tabControl1.SelectedIndex = 0;

                    if (Globals.ProjectTitle != "" && Globals.ProjectNum != "")
                        SetProjectInfoDataBase();

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
                    //RC();
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
                   // Globals.Projectfilepath = setDirectory.SelectedPath;
                   // Directory.SetCurrentDirectory(Globals.Projectfilepath);
                    wProjectLoc.Text = Globals.Projectfilepath;
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Location of 'DB.sdf' is now: " + Globals.Projectfilepath + "\n");
                    forceScroll();
                    SubmittalRefresh();
                    GetProjectInfoDataBase();
                    GetContractorInfoDataBase();
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

        private void wTitleBTN_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "Update ProjectInfo set Title = @Title "
            + "where Num = 1" ;
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Updating Project title in database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Title", wTitleTxT.Text);
                cmd.ExecuteNonQuery();

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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Project title updated!\n");
                forceScroll();
                Globals.ProjectTitle = wTitleTxT.Text;
                this.Text = "Submittal Tracking System | " + Globals.ProjectNum + " | " + Globals.ProjectTitle;
            }
        }
        private void wNumberBTN_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "Update ProjectInfo set Number = @Number "
            + "where Num = 1";
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Updating Project number in database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Number", wNumberTxT.Text);
                cmd.ExecuteNonQuery();

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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Project number updated!\n");
                forceScroll();
                Globals.ProjectNum = wNumberTxT.Text;
                this.Text = "Submittal Tracking System | " + Globals.ProjectNum + " | " + Globals.ProjectTitle;
            }
        }

        private void wConSet_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "Update Contractor set Name = @Name, Address = @Address, Address2 = @Address2, City = @city, State = @state, Zipcode = @zipcode, ContactPerson = @contactperson "
                       + "where Num = 1";
                  
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Updating Contractor information in database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);

                cmd.Parameters.AddWithValue("@name", wName.Text);
                cmd.Parameters.AddWithValue("@address", wAddress.Text);
                cmd.Parameters.AddWithValue("@address2", wAddress2.Text);
                cmd.Parameters.AddWithValue("@city", wCity.Text);
                cmd.Parameters.AddWithValue("@state", wState.Text);
                cmd.Parameters.AddWithValue("@zipcode", wZipcode.Text);
                cmd.Parameters.AddWithValue("@contactperson", wContact.Text);
                cmd.ExecuteNonQuery();
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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Contractor updated!\n");
                forceScroll();
            }
        }


        private void toExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.Projectfilepath != null)
            {
                var wb = new ClosedXML.Excel.XLWorkbook();

                Directory.SetCurrentDirectory(Globals.Projectfilepath);
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                try
                {
                    SqlCeCommand cmd = new SqlCeCommand("Submittals", cn);
                    SqlCeCommand cmd1 = new SqlCeCommand("Contractor", cn);
                    SqlCeCommand cmd2 = new SqlCeCommand("ProjectInfo", cn);

                    cmd.CommandType = CommandType.TableDirect;
                    cmd1.CommandType = CommandType.TableDirect;
                    cmd2.CommandType = CommandType.TableDirect;

                    DataTable Submittals = new DataTable();
                    DataTable Contractor = new DataTable();
                    DataTable ProjectInfo = new DataTable();

                    SqlCeDataReader reader = cmd.ExecuteReader();
                    SqlCeDataReader reader1 = cmd1.ExecuteReader();
                    SqlCeDataReader reader2 = cmd2.ExecuteReader();

                    Submittals.Load(reader);
                    wb.Worksheets.Add(Submittals);

                    Contractor.Load(reader1);
                    wb.Worksheets.Add(Contractor);

                    ProjectInfo.Load(reader2);
                    wb.Worksheets.Add(ProjectInfo);


                    wb.SaveAs(wTitleTxT.Text + wNumberTxT.Text + ".xlsx");
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
            else
                MessageBox.Show("Please open a Submittal file first.");
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
        private void logSubmittalButtonPart1_Click(object sender, EventArgs e)
        {
            sSubmittalDropdown.BackColor = Color.White;
            if (sNoRB.Checked)
            {
                string sql = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text != "")
                {
                    sql = "Update Submittals set SpecSection = @SpecSection, ProjectTitle = @ProjectTitle, Description = @Description, ReceivedDate = @ReceivedDate, NumReceived = @NumReceived "
                    + "where SubmittalNum = " + sSubmittalDropdown.Text;

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@SpecSection", sSpecNumBox.Text);
                        cmd.Parameters.AddWithValue("@Description", sDescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@ProjectTitle", Globals.ProjectTitle);
                        cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                        cmd.Parameters.AddWithValue("@NumReceived", sNumReceivedBox.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Updated the database!\n");
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
                else
                {
                    MessageBox.Show("Please select a submittal from the dropdown to edit.");
                    sSubmittalDropdown.BackColor = Color.MistyRose;
                }
                
            }

            if (sYesRB.Checked)
            {
                string sql = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text == "")
                {
                    sql = "insert into Submittals "
                    + "(SpecSection, ProjectTitle, Description, ReceivedDate, NumReceived) "
                    + "values (@SpecSection, @ProjectTitle, @Description, @ReceivedDate, @NumReceived) ";

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@SpecSection", sSpecNumBox.Text);
                        cmd.Parameters.AddWithValue("@Description", sDescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@ProjectTitle", Globals.ProjectTitle);
                        cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                        cmd.Parameters.AddWithValue("@NumReceived", sNumReceivedBox.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal Part 1 added to database!\n");
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
                else
                {
                    MessageBox.Show("Submittal Number dropdown needs to be blank if you are logging a new submittal. Try clicking clear form.");
                }
                
            }
        }
        private void logSubmittalButtonPart2_Click(object sender, EventArgs e)
        {
                sSubmittalDropdown.BackColor = Color.White;
                if (sNoRB.Checked)
                {
                    string sql = "";
                    SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                    Directory.SetCurrentDirectory(Globals.Projectfilepath);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCeCommand cmd;


                    if (sSubmittalDropdown.Text != "")
                    {
                        sql = "Update Submittals set Consultant = @Consultant, ToConsultantDate = @ToConsultantDate, DateDue = @DateDue, QuantityToConsultant = @QuantityToConsultant, ConsultantVia = @ConsultantVia, FromConsultantDate = @FromConsultantDate "
                        + "where SubmittalNum = " + sSubmittalDropdown.Text;

                        try
                        {
                            cmd = new SqlCeCommand(sql, cn);
                            cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                            cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                            cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                            cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                            cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                            cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                            cmd.ExecuteNonQuery();
                            cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Updated the database!\n");
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
                    else
                    {
                        MessageBox.Show("Please select a submittal from the dropdown to edit.");
                        sSubmittalDropdown.BackColor = Color.MistyRose;
                    }
                   
                }
                if (sYesRB.Checked)
                {
                    string sql = "";
                    SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                    Directory.SetCurrentDirectory(Globals.Projectfilepath);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCeCommand cmd;


                    if (sSubmittalDropdown.Text == "")
                    {
                        sql = "insert into Submittals "
                         + "(Consultant, ToConsultantDate, DateDue, QuantityToConsultant, ConsultantVia, FromConsultantDate) "
                         + "values (@Consultant, @ToConsultantDate, @DateDue, @QuantityToConsultant, @ConsultantVia, @FromConsultantDate) ";

                        try
                        {
                            cmd = new SqlCeCommand(sql, cn);
                            cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                            cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                            cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                            cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                            cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                            cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                            cmd.ExecuteNonQuery();
                            cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal Part 2 added to database!\n");
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
                    else
                    {
                        
                        MessageBox.Show("Submittal Number dropdown needs to be blank if you are logging a new submittal. Try clicking clear form.");
                    }
                   
                }
        }
        private void logSubmittalButtonPart3_Click(object sender, EventArgs e)
        {
            sSubmittalDropdown.BackColor = Color.White;
            if (sNoRB.Checked)
            {
                string sql = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text != "")
                {
                    sql = "Update Submittals set ToContractorDate = @ToContractorDate, ContractorVia = @ContractorVia, Quantity = @Quantity, Action = @Action, Name = @Name, Comments = @Comments "
                    + "where SubmittalNum = " + sSubmittalDropdown.Text;

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Updated the database!\n");
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
                else
                {
                    MessageBox.Show("Please select a submittal from the dropdown to edit.");
                    sSubmittalDropdown.BackColor = Color.MistyRose;
                }

            }
            if (sYesRB.Checked)
            {
                string sql = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text == "")
                {
                    sql = "insert into Submittals "
                     + "(ToContractorDate, ContractorVia, Quantity, Action, Name, Comments) "
                     + "values (@ToContractorDate, @ContractorVia, @Quantity, @Action, @Name, @Comments) ";

                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal Part 3 added to database!\n");
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
                else
                {

                    MessageBox.Show("Submittal Number dropdown needs to be blank if you are logging a new submittal. Try clicking clear form.");
                }

            }
        }
        private void sLogBTN_Click(object sender, EventArgs e)
        {
            sSubmittalDropdown.BackColor = Color.White;
            if (sNoRB.Checked)
            {
                string sql = "";
                string sql1 = "";
                string sql2 = "";
                string totaldays = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text != "")
                {
                    sql = "Update Submittals set SpecSection = @SpecSection, ProjectTitle = @ProjectTitle, Description = @Description, ReceivedDate = @ReceivedDate, NumReceived = @NumReceived, Consultant = @Consultant, ToConsultantDate = @ToConsultantDate, DateDue = @DateDue, QuantityToConsultant = @QuantityToConsultant, ConsultantVia = @ConsultantVia, FromConsultantDate = @FromConsultantDate,ToContractorDate = @ToContractorDate, ContractorVia = @ContractorVia, Quantity = @Quantity, Action = @Action, Name = @Name, Comments = @Comments, TotalDays = @TotalDays  "
                    + "where SubmittalNum = " + sSubmittalDropdown.Text;

               //     sql1 = "Update Submittals set Consultant = @Consultant, ToConsultantDate = @ToConsultantDate, DateDue = @DateDue, QuantityToConsultant = @QuantityToConsultant, ConsultantVia = @ConsultantVia, FromConsultantDate = @FromConsultantDate "
                  //  + "where SubmittalNum = " + sSubmittalDropdown.Text;

                  //  sql2 = "Update Submittals set ToContractorDate = @ToContractorDate, ContractorVia = @ContractorVia, Quantity = @Quantity, Action = @Action, Name = @Name, Comments = @Comments "
                  //  + "where SubmittalNum = " + sSubmittalDropdown.Text;

                    try
                    {
                        totaldays = calcTotalDays(sReturnedCBox.Text, sSubmittalDateBox.Text);
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@SpecSection", sSpecNumBox.Text);
                        cmd.Parameters.AddWithValue("@Description", sDescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@ProjectTitle", Globals.ProjectTitle);
                        cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                        cmd.Parameters.AddWithValue("@NumReceived", sNumReceivedBox.Text);
                        cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                        cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                        cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.Parameters.AddWithValue("@TotalDays", totaldays);
                        cmd.ExecuteNonQuery();

                       /* cmd = new SqlCeCommand(sql1, cn);
                        cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                        cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                        cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCeCommand(sql2, cn);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.ExecuteNonQuery();
                        */
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Updated the database!\n");
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
                else
                {
                    MessageBox.Show("Please select a submittal from the dropdown to edit.");
                    sSubmittalDropdown.BackColor = Color.MistyRose;
                }

            }

            if (sYesRB.Checked)
            {
                string sql = "";
                string sql1 = "";
                string sql2 = "";
                string totaldays = "";
                SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
                Directory.SetCurrentDirectory(Globals.Projectfilepath);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;


                if (sSubmittalDropdown.Text == "")
                {
                    sql = "insert into Submittals "
                    + "(SpecSection, ProjectTitle, Description, ReceivedDate, NumReceived, Consultant, ToConsultantDate, DateDue, QuantityToConsultant, ConsultantVia, FromConsultantDate, ToContractorDate, ContractorVia, Quantity, Action, Name, Comments, TotalDays) "
                    + "values (@SpecSection, @ProjectTitle, @Description, @ReceivedDate, @NumReceived,@Consultant, @ToConsultantDate, @DateDue, @QuantityToConsultant, @ConsultantVia, @FromConsultantDate,@ToContractorDate, @ContractorVia, @Quantity, @Action, @Name, @Comments, @TotalDays) ";

               //     sql1 = "insert into Submittals "
                 //   + "(Consultant, ToConsultantDate, DateDue, QuantityToConsultant, ConsultantVia, FromConsultantDate) "
                   // + "values (@Consultant, @ToConsultantDate, @DateDue, @QuantityToConsultant, @ConsultantVia, @FromConsultantDate) ";

//                    sql2 = "insert into Submittals "
  //                  + "(ToContractorDate, ContractorVia, Quantity, Action, Name, Comments) "
    //                + "values (@ToContractorDate, @ContractorVia, @Quantity, @Action, @Name, @Comments) ";

                    try
                    {
                        totaldays = calcTotalDays(sReturnedCBox.Text, sSubmittalDateBox.Text);
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@SpecSection", sSpecNumBox.Text);
                        cmd.Parameters.AddWithValue("@Description", sDescriptionBox.Text);
                        cmd.Parameters.AddWithValue("@ProjectTitle", Globals.ProjectTitle);
                        cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                        cmd.Parameters.AddWithValue("@NumReceived", sNumReceivedBox.Text);
                        cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                        cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                        cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.Parameters.AddWithValue("@TotalDays", totaldays);
                        cmd.ExecuteNonQuery();
                        cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal added to database!\n");
                        forceScroll();

                       /* cmd = new SqlCeCommand(sql1, cn);
                        cmd.Parameters.AddWithValue("@Consultant", sConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@DateDue", sConsultantDateDueBox.Text);
                        cmd.Parameters.AddWithValue("@ToConsultantDate", sToConsultantDateBox.Text);
                        cmd.Parameters.AddWithValue("@QuantityToConsultant", sQuantityConsultantBox.Text);
                        cmd.Parameters.AddWithValue("@ConsultantVia", sConsultantViaBox.Text);
                        cmd.Parameters.AddWithValue("@FromConsultantDate", sFromConsultantDateBox.Text);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCeCommand(sql2, cn);
                        cmd.Parameters.AddWithValue("@ToContractorDate", sReturnedCBox.Text);
                        cmd.Parameters.AddWithValue("@ContractorVia", sContractorViaBox.Text);
                        cmd.Parameters.AddWithValue("@Quantity", sQuantityReturnedBox.Text);
                        cmd.Parameters.AddWithValue("@Action", sActionBox.Text);
                        cmd.Parameters.AddWithValue("@Name", sNameBox.Text);
                        cmd.Parameters.AddWithValue("@Comments", sCommentBox.Text);
                        cmd.ExecuteNonQuery();
                        */
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
                else
                {
                    MessageBox.Show("Submittal Number dropdown needs to be blank if you are logging a new submittal. Try clicking clear form.");
                }

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
        private void SubmittalsView_DoubleClick(object sender, EventArgs e)
        {

            int yCoord = 0;
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);
            //string yCoord = ((DataGridView)sender).SelectedRows[0].Cells[0].Value.ToString();

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT * FROM Submittals where SubmittalNum = " + (yCoord + 1);

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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal form populated!\n");
                forceScroll();
                sNoRB.Checked = true;
            }

        }
        private void sClearFormBTN_Click(object sender, EventArgs e)
        {

            clearSubmittalForm();
        }
        private void clearSubmittalForm()
        {
            if (sSpecNumBox.Text != "")
                sSpecNumBox.Text = "";
            if (sSubmittalDropdown.Text != "")
                sSubmittalDropdown.Text = "";
            if (sDescriptionBox.Text != "")
                sDescriptionBox.Text = "";
            if (sNumReceivedBox.Text != "")
                sNumReceivedBox.Text = "";
            if (sConsultantBox.Text != "")
                sConsultantBox.Text = "";
            if (sQuantityConsultantBox.Text != "")
                sQuantityConsultantBox.Text = "";
            if (sConsultantViaBox.Text != "")
                sConsultantViaBox.Text = "";
            if (sQuantityReturnedBox.Text != "")
                sQuantityReturnedBox.Text = "";
            if (sContractorViaBox.Text != "")
                sContractorViaBox.Text = "";
            if (sActionBox.Text != "")
                sActionBox.Text = "";
            if (sNameBox.Text != "")
                sNameBox.Text = "";
            if (sCommentBox.Text != "")
                sCommentBox.Text = "";

            cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Form cleared.\n"); // NAME
            forceScroll();
        }
        private void sSubmittalDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yCoord = sSubmittalDropdown.Text;
            sSubmittalDropdown.BackColor = Color.White;
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);


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
                sNoRB.Checked = true;
            }
        }
        private void submittalMenuStrip_Click(object sender, EventArgs e)
        {
            string messageBoxText1 = "Are you sure you wish to delete the currently selected row?";
            string caption1 = "Delete row.";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            if (MessageBox.Show(messageBoxText1, caption1, button, icon) == System.Windows.Forms.DialogResult.Yes)
            {
                SubmittalsView.Rows.RemoveAt(this.SubmittalsView.SelectedRows[0].Index);
                SubmittalRefresh();
                //RC();
            }
        }
        private void SubmittalsView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SubmittalsView.ClearSelection();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                SubmittalsView.Rows[e.RowIndex].Selected = true;
                Rectangle r = SubmittalsView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                submittalMenuStrip.Show((Control)sender, r.Left + e.X, r.Top + e.Y);

            }
        }
        private string calcTotalDays(string x, string y)
        {
            string days;
            DateTime rec = Convert.ToDateTime(x);
            DateTime returned = Convert.ToDateTime(y);
            days = (rec - returned).TotalDays.ToString();
            return days;
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

                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
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
                //   ConsultantView.DataSource = Globals.Consultants.ToList();
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
        private void actionBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Globals.Projectfilepath);
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                string sql = "SELECT * FROM Submittals where Action = '" + actionBx.Text + "'";
                SqlCeCommand cmd = new SqlCeCommand(sql, cn);
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
                actionview.DataSource = rs;


                // 

                // 
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal table was refreshed.\n");
                forceScroll();
                // 

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
        private void SetProjectInfoDataBase()
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "insert into ProjectInfo"
            + "(Title, Number) "
            + "values (@Title, @Number) ";
            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Saving ProjectInfo to database.\n");
                forceScroll();
                cmd = new SqlCeCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Title", Globals.ProjectTitle);
                cmd.Parameters.AddWithValue("@Number", Globals.ProjectNum);
                cmd.ExecuteNonQuery();

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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Data written!\n");
                forceScroll();
                wTitleTxT.Text = Globals.ProjectTitle;
                wNumberTxT.Text = Globals.ProjectNum;
                this.Text = "Submittal Tracking System | " + Globals.ProjectNum + " | " + Globals.ProjectTitle;
            }
        }
        private void GetProjectInfoDataBase()
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }


            string sql = "SELECT Title, Number FROM ProjectInfo";

            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving Project Info from database.\n");
                forceScroll();
                SqlCeCommand cmd = new SqlCeCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);


                if (rs.HasRows)
                {
                    int ordTitle = rs.GetOrdinal("Title");
                    int ordNum = rs.GetOrdinal("Number");

                    rs.ReadFirst();
                    Globals.ProjectTitle = rs.GetString(ordTitle);
                    Globals.ProjectNum = rs.GetString(ordNum);


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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Project Information retrieved!\n");
                forceScroll();
                wTitleTxT.Text = Globals.ProjectTitle;
                wNumberTxT.Text = Globals.ProjectNum;
                this.Text = "Submittal Tracking System | " + Globals.ProjectNum + " | " + Globals.ProjectTitle;
            }
        }
        private void GetContractorInfoDataBase()
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            string sql = "SELECT Name, Address, Address2, City, State, Zipcode, ContactPerson FROM Contractor";

            try
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Retrieving Contractor Info from database.\n");
                forceScroll();
                SqlCeCommand cmd = new SqlCeCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);


                if (rs.HasRows)
                {

                    int ordName = rs.GetOrdinal("Name");
                    int ordAddress = rs.GetOrdinal("Address");
                    int ordAddress2 = rs.GetOrdinal("Address2");
                    int ordCity = rs.GetOrdinal("City");
                    int ordState = rs.GetOrdinal("State");
                    int ordZipcode = rs.GetOrdinal("Zipcode");
                    int ordContact = rs.GetOrdinal("ContactPerson");
                    

                    rs.ReadFirst();
                    Globals.cName = rs.GetString(ordName);
                    Globals.cAddress = rs.GetString(ordAddress);
                    Globals.cAddress2 = rs.GetString(ordAddress2);
                    Globals.cCity = rs.GetString(ordCity);
                    Globals.cState = rs.GetString(ordState);
                    Globals.cZipcode = rs.GetString(ordZipcode);
                    Globals.cContactPerson = rs.GetString(ordContact);


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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Contractor Information retrieved!\n");
                forceScroll();
                wName.Text = Globals.cName;
                wAddress.Text = Globals.cAddress;
                wAddress2.Text = Globals.cAddress2;
                wCity.Text = Globals.cCity;
                wState.Text = Globals.cState;
                wZipcode.Text = Globals.cZipcode;
                wContact.Text = Globals.cContactPerson;
                
            }
        }
        //data gates (lockers)
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
        private void sYesRB_CheckedChanged(object sender, EventArgs e)
        {
            if (sYesRB.Checked)
            {
                label9.Text = "Log New Submittal";
                label11.Hide();
                sSubmittalDropdown.Hide();
                clearSubmittalForm();
            }
            else
            {
                label9.Text = "Log Submittal";
                label11.Visible = true;
                sSubmittalDropdown.Visible = true;
            }
        }

        private void actionview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedTab = tabSubmittals;
            int yCoord = actionview.CurrentCellAddress.Y;

            SqlCeConnection cn = new SqlCeConnection(Globals.connectionStringProject);
            Directory.SetCurrentDirectory(Globals.Projectfilepath);


            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "SELECT * FROM Submittals where SubmittalNum = " + (yCoord + 1);

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
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Success: Submittal form populated!\n");
                forceScroll();
                sNoRB.Checked = true;
            }

        }

 

      


    


   

     



 

     

        /*  private void ConsultantView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
          {
              DataGridViewColumn newColumn = ConsultantView.Columns[e.ColumnIndex];
              DataGridViewColumn oldColumn = ConsultantView.SortedColumn;
              ListSortDirection direction;

              // If oldColumn is null, then the DataGridView is not sorted. 
              if (oldColumn != null)
              {
                  // Sort the same column again, reversing the SortOrder. 
                  if (oldColumn == newColumn &&
                      ConsultantView.SortOrder == SortOrder.Ascending)
                  {
                      direction = ListSortDirection.Descending;
                  }
                  else
                  {
                      // Sort a new column and remove the old SortGlyph.
                      direction = ListSortDirection.Ascending;
                      oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                  }
              }
              else
              {
                  direction = ListSortDirection.Ascending;
              }

              // Sort the selected column.
              ConsultantView.Sort(newColumn, direction);
              newColumn.HeaderCell.SortGlyphDirection =
                  direction == ListSortDirection.Ascending ?
                  SortOrder.Ascending : SortOrder.Descending;
          }

          private void ConsultantView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
          {
              foreach (DataGridViewColumn column in ConsultantView.Columns)
              {
                  column.SortMode = DataGridViewColumnSortMode.Programmatic;
              }
          }
          */






    }

    public static class Globals // class that holds "global" variables
    {
        public static string Consultantfilepath { get; set; }
        public static string Projectfilepath { get; set; }
        public static string connectionStringConsultant { get; set; }
        public static string connectionStringProject { get; set; }
        public static string jobTitle { get; set; }
        public static string jobNumber { get; set; }
        public static string ProjectTitle { get; set; }
        public static string ProjectNum { get; set; }

        public static string cName { get; set; }
        public static string cAddress { get; set; }
        public static string cAddress2 { get; set; }
        public static string cCity { get; set; }
        public static string cState { get; set; }
        public static string cZipcode { get; set; }
        public static string cContactPerson { get; set; }

    }
}