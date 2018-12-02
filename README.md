
# Crystal Report Search

## Overview
This tool will allow users to search for a specific criteria against a selected report.  

### Features
* It will compare the search criteria against the entire SQL query contained in the selected report. 
* It will search for exact matches of table/command names against search criteria.
* Ability to view entire SQL query and command/table names by a click of a button
* Ability to preview the report from within the application itself.

This tool will prove to be useful when we have to check if a certain field or table is contained within a report.  Currently we have to manually open each report in Crystal Reports and inspect the SQL query.  

## How to Use

Welcome to the Crystal Reports Search Help Section

Please see guide below on how to use the application:

1. Select a report.  Report must be in .RPT format.
2. Enter a search criteria and click on Search. This will search the report SQL query and table/command names against your search criteria.
3. You can now review matches found or use the copy button to copy the matches to your clipboard.
4. To view the entire SQL query and command/table names, select the View SQL button.
5. To preview the report, select the Preview Report button.

Notes: 
The search feature will return any similar data that is found between the search critera and the SQL query.
While it will look for exact matches when searching  for command/table names.

## For Development:
[Link for Crystal Reports SDK](https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports%2C+Developer+for+Visual+Studio+Downloads)
