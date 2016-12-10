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
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_NguyenLieuTon : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = null;
        HangHoa_BLL _hanghoaBLL = null;
        public Frm_NguyenLieuTon()
        {
            InitializeComponent();
            dt = new DataTable();
            _hanghoaBLL = new HangHoa_BLL();
        }

        private void Frm_NguyenLieuTon_Load(object sender, EventArgs e)
        {
            LayDanhSachNguyenLieuTon();
        }
        private void LayDanhSachNguyenLieuTon()
        {
            //HangHoaTon hht = new HangHoaTon();
            dt = RestaurantSoftware.Utils.Utils.ConvertToDataTable<HangHoaTon>(_hanghoaBLL.LayDanhSachHangHoaTon());
            gridControl1.DataSource = dt;
        }

    }
}