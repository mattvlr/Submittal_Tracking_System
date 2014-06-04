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
        private void closeMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newMenu_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
                Globals.filepath = setDirectory.SelectedPath;

            try
            {
                Directory.SetCurrentDirectory(Globals.filepath);
                tabControl1.Visible = true;
            }
            catch(DirectoryNotFoundException err)
            {
                cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: the specified directory does not exist. {0}");
                forceScroll();
            }
            JobEntry newJob = new JobEntry();
           // newJob.Show();
            createDatabase();
            
        }
        private void createDatabase()
        {
            string filename = "ContractorDB.sdf";

            if (File.Exists(filename))
                File.Delete(filename);

            Globals.connectionString = "DataSource=\"ContractorDB.sdf\"; Password=\"password\"";
            SqlCeEngine en = new SqlCeEngine(Globals.connectionString);
            en.CreateDatabase();

            SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand SubmittalsCMD;
            SqlCeCommand ConsultantCMD;

            string sql = "create table Submittals ("
            + "ReceivedDate nvarchar (40), "
            + "SectionNum nvarchar (40), "
            + "SubmittalNum nvarchar (40), "
            + "Description nvarchar (200), "
            + "NumReceived nvarchar (40), "
            + "Consultant nvarchar (200), "
            + "ToConsultantDate nvarchar (40), "
            + "DateDue nvarchar (40), "
            + "QuantityToConsultant nvarchar (40), "
            + "ConsultantVia nvarchar (40), "
            + "FromConsultantDate nvarchar (40), "
            + "ToContractorDate nvarchar (40), "
            + "Quantity nvarchar (40), " 
            + "ContractorVia nvarchar (40), "
            + "Action nvarchar (40), "
            + "Name nvarchar (40), "
            + "Comments nvarchar(200) )";
 
            string sql1 = "create table Consultant ( "
            + "Name nvarchar (200), "
            + "Address nvarchar (200), "
            + "Address2 nvarchar (200), "
            + "City nvarchar (200), "
            + "State nvarchar (2), "
            + "Zipcode nvarchar (10), " 
            + "ContactPerson nvarchar (200) )";


            SubmittalsCMD = new SqlCeCommand(sql, cn);
            ConsultantCMD = new SqlCeCommand(sql1, cn);
            try
            {
                 SubmittalsCMD.ExecuteNonQuery();
                 ConsultantCMD.ExecuteNonQuery();
                 MessageBox.Show("Tables successfully created! \n Located in directory: " + Globals.filepath);
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
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Hide();    
        }
        private void cAddButton_Click(object sender, EventArgs e)
        {
    
            int flagCounter = 0;
            string AddressLine2;

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
                if(cAddress2Text.Text == "") //ADDRESS LINE 2
                    AddressLine2 = "";
                else
                    AddressLine2 = cAddress2Text.Text;

                if (flagCounter == 6)
                {
                    SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);


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

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (setDirectory.ShowDialog() == DialogResult.OK)
            {
                Globals.filepath = setDirectory.SelectedPath;
                Directory.SetCurrentDirectory(Globals.filepath);

                if (File.Exists("ContractorDB.sdf"))
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Setting " + Globals.filepath + "\\ContractorDB.sdf as working directory.\n");
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Found ContractorDB.sdf in working directory.\n");
                    forceScroll();
                    tabControl1.Visible = true;
                    Globals.connectionString = "DataSource=\"ContractorDB.sdf\"; Password=\"password\"";
                }
                else
                {
                    cErrorBox.AppendText(DateTime.Now.ToLongTimeString() + " | Error: 'ContractorDB.sdf' was not found, please try another location.\n");
                    forceScroll();
                }
            }
   
        }
        private void consultantBox_Click(object sender, EventArgs e)
        {
            sConsultantBox.Items.Clear();
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);


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
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);


            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCeCommand cmd;

            string sql = "insert into Submittals "
            + "(ReceivedDate, SectionNum, SubmittalNum, Description, NumReceived, Consultant, DateDue, ToConsultantDate, QuantityToConsultant, ConsultantVia, FromConsultantDate, ToContractorDate, Quantity, ContractorVia, Action, Name, Comments) "
            + "values (@ReceivedDate, @SectionNum, @SubmittalNum, @Description, @NumReceived, @Consultant, @DateDue, @ToConsultantDate, @QuantityToConsultant, @ConsultantVia, @FromConsultantDate, @ToContractorDate, @Quantity, @ContractorVia, @Action, @Name, @Comments) ";

            try
            {
                cmd = new SqlCeCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ReceivedDate", sSubmittalDateBox.Text);
                cmd.Parameters.AddWithValue("@SectionNum", sSpecNumBox.Text);
                cmd.Parameters.AddWithValue("@SubmittalNum", sSubmittalNumBox.Text);
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
            }
                
                
        }

        public void forceScroll()
        {
            cErrorBox.SelectionStart = cErrorBox.Text.Length;
            cErrorBox.ScrollToCaret();
        }

        private void LRefresh_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCeCommand cmd = new SqlCeCommand("Submittals", cn);
                cmd.CommandType = CommandType.TableDirect;

                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);

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

        private void CRefresh_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(Globals.connectionString);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCeCommand cmd = new SqlCeCommand("Consultant", cn);
                cmd.CommandType = CommandType.TableDirect;

                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);

                ConsultantView.DataSource = rs;
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
        




    }

    public static class Globals // class that holds "global" variables
    {
        public static string filepath { get; set; }
        public static string connectionString { get; set; }
        public static string jobTitle { get; set; }
        public static int jobNumber { get; set; }
    }

    

}
