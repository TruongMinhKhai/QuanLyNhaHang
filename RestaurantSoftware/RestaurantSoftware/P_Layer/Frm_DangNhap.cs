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
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        private DangNhap_BLL _dangnhap_Bll = new DangNhap_BLL();
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if(_dangnhap_Bll.KiemTraQuyen(txt_TenTaiKhoan.Text.ToString(),txt_MatKhau.Text.ToString()))
            {
                Notifications.Success("Đăng nhập thành công!");
                this.Close();
            }
            else
            {
                Notifications.Warning("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}