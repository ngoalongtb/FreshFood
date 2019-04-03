using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace FreshFood.Reports
{
    public partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public object DataBindingMode { get; private set; }

        public OrderReport()
        {
            InitializeComponent();
        }

    }
}
