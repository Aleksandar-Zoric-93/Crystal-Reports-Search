using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchCrystal
{
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\WorkingOn\\Customer Sales Report by Brand.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
