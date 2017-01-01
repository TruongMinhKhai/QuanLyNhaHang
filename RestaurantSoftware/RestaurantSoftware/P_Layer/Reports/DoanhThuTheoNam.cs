using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RestaurantSoftware.P_Layer.Reports
{
    public partial class DoanhThuTheoNam : DevExpress.XtraReports.UI.XtraReport
    {
        public DoanhThuTheoNam()
        {
            InitializeComponent();
        }

        private void DoanhThuTheoNam_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.NamBaoCao.Value = DateTime.Now.Year;
        }

    }
}
