using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RestaurantSoftware.P_Layer.Reports
{
    public partial class ThongKeMon : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeMon()
        {
            InitializeComponent();
        }

        private void ThongKeMon_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.NgayThongKe.Value = DateTime.Today;
        }

    }
}
