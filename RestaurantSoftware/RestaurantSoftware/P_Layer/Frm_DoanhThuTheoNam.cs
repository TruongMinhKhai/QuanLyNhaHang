using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DoanhThuTheoNam : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DoanhThuTheoNam()
        {
            InitializeComponent();
        }

        private void btn_ChartDTNam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                P_Layer.Frm_ChartDoanhThuNam DT = new P_Layer.Frm_ChartDoanhThuNam();
                DT.MdiParent = FormMain.ActiveForm;
                DT.Show();
        }
    }
}