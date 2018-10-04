using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SearchCrystal
{
    public partial class Main : Form
    {
        #region Variables
        ReportDocument rptDoc;
        String returnedQuery;
        String reportSelected;
        String reportPath;
        StringBuilder SQLandTblNames;
        StringBuilder searchCriteriaFound;
        String helpSection;
        int numberOfCommands = 0;
        StringBuilder multiReport = new StringBuilder();
        #endregion

        public Main()
        {
            InitializeComponent();
        }


        #region Search Button
        //On search button click, report is loaded and the parameter function is executed
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTxt.Text))
            {
                MessageBox.Show("You must enter a search criteria", "Crystal Reports Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    rptDoc.Load(reportSelected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Report not loaded.  Please select a Crystal report (.rpt)", "Crystal Reports Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    searchBtn.Text = "Search";
                    searchBtn.Enabled = true;
                    logException(ex);
                    return;
                }
                parameterSearch();
            }
        }
        #endregion





        #region Get report SQL query
        //Returns SQL query based on index parameter
        public string readSqlQuery(ReportDocument rd)
        {
            //Check if report is loaded
            if (!rd.IsLoaded)
            {
                MessageBox.Show("Report not loaded.  Please select a Crystal report (.rpt)", "Crystal Reports Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchBtn.Text = "Search";
                searchBtn.Enabled = true;
                return string.Empty;
            }


            //Get report property information
            PropertyInfo pi = rd.Database.Tables.GetType().GetProperty("RasTables", BindingFlags.NonPublic | BindingFlags.Instance);


            StringBuilder SQLqueries = new StringBuilder();
            String delimiter = Environment.NewLine + Environment.NewLine;

            try
            {
                PropertyInfo[] properties = rptDoc.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured:" + Environment.NewLine + ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                logException(ex);
            }

            getNumberOfCommands();

            //Return SQL query in all found commands
            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    SQLqueries.Append(
                    ((dynamic)pi.GetValue(rd.Database.Tables, pi.GetIndexParameters()))[i].CommandText);
                    SQLqueries.Append(delimiter);
                }
                catch (Exception ex)
                {
                    logException(ex);
                }
            }
            return SQLqueries.ToString();
        }

        //Function to get number of commands/tables
        private int getNumberOfCommands()
        {
            numberOfCommands = 0;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rptDoc.Database.Tables)
            {
                numberOfCommands += 1;
            }
            return numberOfCommands;
        }
        #endregion





        #region File Dialog Handler
        //Open file dialog handler and load report
        private void selReportBtn_Click(object sender, EventArgs e)
        {
            copyBtn.Visible = false;
            OpenFileDialog reportSelector = new OpenFileDialog();

            if (reportSelector.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Save report information (per session)
                    reportSelected = reportSelector.FileName;
                    reportPath = Path.GetDirectoryName(reportSelected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occured:" + Environment.NewLine + ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logException(ex);
                }
            }

            rptDoc = new ReportDocument();
            try
            {
                //Disable search button before load
                searchBtn.Text = "Loading";
                searchBtn.Enabled = false;

                rptDoc.Load(reportSelected);

                //Enable search button after load
                searchBtn.Text = "Search";
                searchBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                logException(ex);
            }

            if (multiSelChk.Checked)
            {
                returnedQuery = readSqlQuery(rptDoc);

                try
                {
                    //Display report name and report path, if found. 
                    if (string.IsNullOrEmpty(rptDoc.SummaryInfo.ReportTitle) || string.IsNullOrEmpty(reportPath))
                    {
                        reportNameLbl.Text = "Report failed to load";
                    }
                    else
                    {
                        //Search SQL query against search criteria
                        reportNameLbl.Text = "Report Title: " + rptDoc.SummaryInfo.ReportTitle;
                        reportPathLbl.Text = "Report Path: " + reportPath;
                    }
                }
                catch (Exception ex)
                {
                    reportNameLbl.Text = "Report failed to load";
                    logException(ex);
                }
            }
            else
            {
                clearScreen();
                returnedQuery = readSqlQuery(rptDoc);

                try
                {
                    //Display report name and report path, if found. 
                    if (string.IsNullOrEmpty(rptDoc.SummaryInfo.ReportTitle) || string.IsNullOrEmpty(reportPath))
                    {
                        reportNameLbl.Text = "Report failed to load";
                    }
                    else
                    {
                        //Search SQL query against search criteria
                        reportNameLbl.Text = "Report Title: " + rptDoc.SummaryInfo.ReportTitle;
                        reportPathLbl.Text = "Report Path: " + reportPath;
                    }
                }
                catch (Exception ex)
                {
                    reportNameLbl.Text = "Report failed to load";
                    logException(ex);
                }
            }
        }
        #endregion






        #region Clear Screen
        //Clears all text on screen
        private void clearScreen()
        {
            foundSearchTxt.Text = "";
            reportNameLbl.Text = "";
            reportPathLbl.Text = "";
            commandNamesTxt.Text = "";
        }
        #endregion







        #region Search Report
        //Compares search value against SQL query and returns information the user
        private void parameterSearch()
        {
            if (multiSelChk.Checked)
            {
                returnedQuery = multiReport.ToString();
                returnedQuery = returnedQuery.ToLower();
            }
            if (!multiSelChk.Checked)
            {
                returnedQuery = readSqlQuery(rptDoc);
                returnedQuery = returnedQuery.ToLower();
            }

            //Clear screen and set data to lowercase for better comparison
            clearScreen();

            searchCriteriaFound = new StringBuilder();
            int numberOfCriteriaFound = 0;
            //Regular expressions are used to search report against search criteria
            string pattern = @".*(" + searchTxt.Text.ToLower() + ")+.*";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(returnedQuery, pattern, options))
            {
                numberOfCriteriaFound += 1;
                searchCriteriaFound.Append("Result: " + numberOfCriteriaFound + Environment.NewLine);

                searchCriteriaFound.Append(m.Value.ToString());
                searchCriteriaFound.Append(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }

            //Display if no matches found
            if (string.IsNullOrEmpty(searchCriteriaFound.ToString()))
            {
                searchCriteriaFound.Append("Search criteria did not match to anything.");
            }

            //Display report name and report path, if found. 
            if (string.IsNullOrEmpty(rptDoc.SummaryInfo.ReportTitle) || string.IsNullOrEmpty(reportPath))
            {
                reportNameLbl.Text = "Report Title: " + "Not Found";
                reportPathLbl.Text = "Report Path: " + "Not Found";
            }
            else
            {
                //Search and display if table with search criteria found
                searchCriteriaFound.Append(Environment.NewLine + Environment.NewLine + searchTable());

                //Search SQL query against search criteria
                foundSearchTxt.Text = searchCriteriaFound.ToString();
                reportNameLbl.Text = "Report Title: " + rptDoc.SummaryInfo.ReportTitle;
                reportPathLbl.Text = "Report Path: " + reportPath;
                copyBtn.Visible = true;
            }
        }
        #endregion






        #region Preview Report Button
        // Preview Report
        private void viewReportBtn_Click(object sender, EventArgs e)
        {
            copyBtn.Visible = false;
            try
            {

                if (File.Exists("C:\\Program Files (x86)\\Business Objects\\BusinessObjects Enterprise 12.0\\win32_x86\\crw32.exe"))
                {
                    Process.Start(reportSelected);
                }

                else
                {
                    MessageBox.Show("Crystal Reports is not installed.  Please install Crystal Reports to use this feature.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Report not loaded.  Please select a Crystal report (.rpt)", "Crystal Reports Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logException(ex);
            }
        }
        #endregion

        #region View SQL Query Button
        //Show all SQL queries found in report
        private void viewSQLBtn_Click(object sender, EventArgs e)
        {
            if (multiSelChk.Checked)
            {
                if (String.IsNullOrEmpty(multiReport.ToString()))
                {
                    MessageBox.Show("Multi-Select is enabled, please add a report to preview query.", "Crystal Reports Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    foundSearchTxt.Text = multiReport.ToString();
                }
            }
            else
            {
                SQLandTblNames = new StringBuilder();
                if (string.IsNullOrEmpty(returnedQuery))
                {

                    MessageBox.Show("Report not selected or query not found", "Crystal Reports Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    foundSearchTxt.Text = returnedQuery.ToLower();
                    displayCommandNames();
                    copyBtn.Visible = true;
                }
            }
        }
        #endregion






        #region Get report table/command names and search
        //Get command/table names
        private string getCommandNames()
        {
            StringBuilder commandNamesFound = new StringBuilder();
            String delimiter = Environment.NewLine;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rptDoc.Database.Tables)
            {
                commandNamesFound.Append(table.Name);
                commandNamesFound.Append(delimiter);
            }

            return commandNamesFound.ToString().ToLower();
        }

        //Search command/table names against search criteria.  Only looking for exact matches.
        private string searchTable()
        {
            bool checkForTable = Regex.IsMatch(getCommandNames(), @"(^|\s)" + searchTxt.Text + "(\\s|$)");

            if (checkForTable == true)
            {
                return "A table with that name has been found.  Please check the report.";
            }
            else
            {
                return "No table found with that name.";
            }
        }

        private void displayCommandNames()
        {
            commandNamesTxt.Text = "Command/Table Names:" + Environment.NewLine + Environment.NewLine + getCommandNames();
        }
        #endregion






        //Copy text to clipboard
        private void copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(foundSearchTxt.Text);
            copyLbl.Visible = true;
            copyLbl.Text = "Copied!";

            var timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, f) =>
            {
                copyLbl.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }






        #region HelpSection
        private void helpBox_Click(object sender, EventArgs e)
        {
            commandNamesTxt.Clear();

            helpSection = Environment.NewLine + Environment.NewLine + "Welcome to the Crystal Reports Search Help Section" + Environment.NewLine + Environment.NewLine +
                          "Please see guide below on how to use the application:" + Environment.NewLine + Environment.NewLine +
                          "1. Select a report.  Report must be in .RPT format." + Environment.NewLine +
                          "2. Enter a search criteria and click on Search. This will search the report SQL query and table/command names against your search criteria." + Environment.NewLine +
                          "3. You can now review matches found or use the copy button to copy the matches to your clipboard." + Environment.NewLine +
                          "4. To view the entire SQL query and command/table names, select the View SQL button." + Environment.NewLine +
                          "5. To select multiple reports, enable multi-select and click on the Add button once a report is selected.  You can then select a different report and click on the Add button again" + Environment.NewLine +
                          "6. To preview the report, select the Preview Report button." + Environment.NewLine + Environment.NewLine +
                          "Notes: " + Environment.NewLine +
                          "The search feature will return any similar data that is found between the search critera and the SQL query." + Environment.NewLine +
                          "While it will look for exact matches when searching  for command/table names." + Environment.NewLine + Environment.NewLine +
                          "For example, if you want to see if a command called command_main exists, your search criteria must be spelled exactly as such." + Environment.NewLine +
                          "If you are looking for a table called InvenDet in the SQL query, having just inven in your search critera will return the result.";

            foundSearchTxt.Text = helpSection;
        }
        #endregion


        #region Exception Logging
        private void logException(Exception ex)
        {
            System.IO.Directory.CreateDirectory(@"C:\Crystal Reports Search");
            string filePath = @"C:\Crystal Reports Search\Log.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Date: " + DateTime.Now.ToString() + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine + "StackTrace: " + ex.StackTrace +
                   "" + Environment.NewLine);
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        #endregion



        #region Multi Report Select
        private void multiAddBtn_Click(object sender, EventArgs e)
        {
            //Confirm returned query is not empty
            if (string.IsNullOrEmpty(returnedQuery))
            {
                MessageBox.Show("Report not selected or query not found", "Crystal Reports Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Do not allow report to be added twice

                try
                {
                    //Check if report already added
                    String queryFromMultiReports = multiReport.ToString();
                    if (queryFromMultiReports.Contains(reportSelected))
                    {
                        MessageBox.Show("Report has already been added", "Crystal Reports Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    //Append each returned query from a report to a string builder
                    String delimiter = Environment.NewLine + Environment.NewLine;

                    multiReport.Append("Report: " + reportSelected);
                    multiReport.Append(delimiter);
                    multiReport.Append(returnedQuery);
                    multiReport.Append(delimiter);

                    foundSearchTxt.Text = "Added " + reportSelected;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not add report.  Review log file for more information.", "Crystal Reports Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logException(ex);
                }
            }
        }

        //On checkbox event
        private void multiSelChk_CheckedChanged(object sender, EventArgs e)
        {
            if (multiSelChk.Checked)
            {
                multiAddBtn.Visible = true;
                viewReportBtn.Enabled = false;
            }
            else
            {
                multiAddBtn.Visible = false;
                viewReportBtn.Enabled = true;
            }

        }
        #endregion
    }
}

