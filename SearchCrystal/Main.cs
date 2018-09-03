using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
                    rptDoc.Load(@reportSelected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Report not loaded.  Please select a Crystal report (.rpt)", "Crystal Reports Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }

            // < 20 as there is no current report that will exceed 20 commands
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    SQLqueries.Append(
                    ((dynamic)pi.GetValue(rd.Database.Tables, pi.GetIndexParameters()))[i].CommandText);
                    SQLqueries.Append(delimiter);
                }
                catch (Exception ex)
                {
                    //Exception caught earlier
                }
            }

            return SQLqueries.ToString();
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
                }
            }

            rptDoc = new ReportDocument();
            try
            {
                //Disable search button before load
                searchBtn.Text = "Loading";
                searchBtn.Enabled = false;

                rptDoc.Load(@reportSelected);

                //Enable search button after load
                searchBtn.Text = "Search";
                searchBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                //Exception caught earlier
            }

            clearScreen();
            returnedQuery = readSqlQuery(rptDoc);
        }
        #endregion



        #region Clear Screen
        //Clears all text on screen
        private void clearScreen()
        {
            foundSearchTxt.Text = "";
            reportNameLbl.Text = "";
            reportPathLbl.Text = "";
        }
        #endregion



        #region Search Report
        //Compares search value against SQL query and returns information the user
        private void parameterSearch()
        {
            //Clear screen and set data to lowercase for better comparison
            clearScreen();
            returnedQuery = readSqlQuery(rptDoc);
            returnedQuery = returnedQuery.ToLower();

            //Contains matched data
            searchCriteriaFound = new StringBuilder();

            //Regular expressions are used to search report against search criteria
            var regex = new Regex(string.Format("[^.!?;]*({0})[^.?!;]*[.?!;]", searchTxt.Text.ToLower()));
            var results = regex.Matches(returnedQuery);

            for (int i = 0; i < results.Count; i++)
            {
                searchCriteriaFound.Append((results[i].Value.Trim()));
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
        }
        #endregion


        #region View SQL Query Button
        //Show all SQL queries found in report
        private void viewSQLBtn_Click(object sender, EventArgs e)
        {
            SQLandTblNames = new StringBuilder();
            if (string.IsNullOrEmpty(returnedQuery))
            {

                MessageBox.Show("Report not selected or query not found", "Crystal Reports Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SQLandTblNames.Append(returnedQuery);
                SQLandTblNames.Append("Database field/table names: " + Environment.NewLine + Environment.NewLine + getCommandNames());

                foundSearchTxt.Text = SQLandTblNames.ToString().ToLower();
                copyBtn.Visible = true;
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
            helpSection = Environment.NewLine + Environment.NewLine + "Welcome to the Crystal Reports Search Help Section" + Environment.NewLine + Environment.NewLine +
                          "Please see guide below on how to use the application:" + Environment.NewLine + Environment.NewLine +
                          "1. Select a report.  Report must be in .RPT format." + Environment.NewLine +
                          "2. Enter a search criteria and click on Search. This will search the report SQL query and table/command names against your search criteria." + Environment.NewLine +
                          "3. You can now review matches found or use the copy button to copy the matches to your clipboard." + Environment.NewLine +
                          "4. To view the entire SQL query and command/table names, select the View SQL button." + Environment.NewLine +
                          "5. To preview the report, select the Preview Report button." + Environment.NewLine + Environment.NewLine +
                          "Notes: " + Environment.NewLine +
                          "The search feature will return any similar data that is found between the search critera and the SQL query." + Environment.NewLine +
                          "While it will look for exact matches when searching  for command/table names." + Environment.NewLine + Environment.NewLine +
                          "For example, if you want to see if a command called command_main exists, your search criteria must be spelled exactly as such." + Environment.NewLine +
                          "If you are looking for a table called InvenDet in the SQL query, having just inven in your search critera will return the result.";

            foundSearchTxt.Text = helpSection;
        }
        #endregion
    }
}

