using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DoiMatKhau : Form
    {
        RestaurantSoftware.DA_Layer.RestaurantDBDataContext dbContext = new DA_Layer.RestaurantDBDataContext();
        int ID_NHANVIEN = 0;
        string mkcu = "";
        public Frm_DoiMatKhau(int idnv, string matkhau)
        {
            InitializeComponent();
            ID_NHANVIEN = idnv;
            mkcu = matkhau;
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            if(mkcu == txtCu.Text)
            {
                var query = from nv in dbContext.NhanViens
                            where nv.id_nhanvien == ID_NHANVIEN
                            select nv;
                foreach (var i in query)
                {
                    i.matkhau = txtMoi.Text;
                }
                dbContext.SubmitChanges();
                MessageBox.Show("Thay đổi mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtCu.Text = "";
            txtMoi.Text = "";
        }

        private void checkAnMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAnMatKhau.CheckState == CheckState.Checked)
            {
                txtCu.Properties.PasswordChar = '*';
                txtMoi.Properties.PasswordChar = '*';
            }
            else
            {
                txtCu.Properties.PasswordChar = '\0';
                txtMoi.Properties.PasswordChar = '\0';
            }
        }
    }
}
