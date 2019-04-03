using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FreshFood.EF;

namespace FreshFood.Reports
{
    public partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        private SellOrder sellOrder;
        public object DataBindingMode { get; private set; }

        public OrderReport()
        {
            InitializeComponent();
        }

        public OrderReport(SellOrder sellOrder)
        {
            InitializeComponent();
            this.sellOrder = sellOrder;

            lblFullName.Text = sellOrder.Fullname;
            lblAddress.Text = sellOrder.Address;
            lblPhoneNumber.Text = sellOrder.PhoneNumber;

            lblToDay.Text = DateTime.Today.ToString("dd/M/yyyy");
        }

    }
}
