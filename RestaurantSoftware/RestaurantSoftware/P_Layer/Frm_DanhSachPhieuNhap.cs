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
using RestaurantSoftware.BL_Layer;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DanhSachPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        //DataTable dt = null;
        private NhapHang_BLL _nhaphangBLL= null;
        public Frm_DanhSachPhieuNhap()
        {
            InitializeComponent();
            //dt = new DataTable();
            _nhaphangBLL = new NhapHang_BLL();
        }
        private void Frm_DanhSachPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhapHang();
        }
        private void LoadDanhSachPhieuNhapHang() {
            //RestaurantSoftware.Utils.Utils.ConvertToDataTable<NhapHang_BLL>(_nhaphangBLL.LayDanhSachPhieuNhap(gridControl1));
            //_nhaphangBLL.LayDanhSachPhieuNhap(grc_DanhSachPhieuNhap);
        }
    }
}