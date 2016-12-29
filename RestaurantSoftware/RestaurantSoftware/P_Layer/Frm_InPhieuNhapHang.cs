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
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer.Reports;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_InPhieuNhapHang : DevExpress.XtraEditors.XtraForm
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        int idNhapHang = 0;
        public Frm_InPhieuNhapHang(int idDatBanSelected)
        {
            InitializeComponent();
            idNhapHang = idDatBanSelected;
        }
        private void Frm_InPhieuNhapHang_Load(object sender, EventArgs e)
        {
            var query = from cthd in dbContext.Chitiet_HoaDonNhapHangs
                        where cthd.id_nhaphang == idNhapHang
                        select cthd;
            PhieuNhapHang report = new PhieuNhapHang();
            report.DataSource = query;
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }
    }
}