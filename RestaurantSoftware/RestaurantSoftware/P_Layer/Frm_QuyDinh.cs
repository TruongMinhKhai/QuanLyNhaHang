﻿using System;
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
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_QuyDinh : DevExpress.XtraEditors.XtraForm
    {
        int ID_NHANVIEN = 0;
        public Frm_QuyDinh(int idnv)
        {
            InitializeComponent();
            dt_NgayLap.Text = DateTime.Now.ToShortDateString();
            // This line of code is generated by Data Source Configuration Wizard
            ID_NHANVIEN = idnv;
            cmb_NhanVienLap.Properties.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().NhanViens;
            cmb_NhanVienLap.EditValue = ID_NHANVIEN;
            cmb_NhanVienLap.ReadOnly = true;
        }
        DataTable dt = new DataTable();
        private QuyDinh_BLL _quydinhBLL = new QuyDinh_BLL();
        private List<int> _listUpdate = new List<int>();
        string kt = "Them";

       
        private void LoadDataSource()
        {
            _quydinhBLL.LayDanhSachQuyDinh(grd_QuyDinh);

        }

        private void Frm_QuyDinh_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void gv_QuyDinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txt_MaQuyDinh.Text = gv_QuyDinh.GetFocusedRowCellDisplayText(col_MaQuyDinh);
            txt_TenQuyDinh.Text = gv_QuyDinh.GetFocusedRowCellDisplayText(col_TenQuyDinh);
            string a = gv_QuyDinh.GetFocusedRowCellDisplayText(col_NhanVien);
            cmb_NhanVienLap.EditValue = int.Parse(a);
            dt_NgayLap.DateTime = Convert.ToDateTime(gv_QuyDinh.GetFocusedRowCellDisplayText(col_NgayLap));
            rxt_NoiDung.Text = gv_QuyDinh.GetFocusedRowCellDisplayText(col_NoiDung);
            kt = "Sua";

        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaQuyDinh.Text = "";
            txt_TenQuyDinh.Text = "";
            dt_NgayLap.Text = DateTime.Now.ToShortDateString();
            rxt_NoiDung.Text = "";
            kt = "Them";
            cmb_NhanVienLap.EditValue = ID_NHANVIEN;
            LoadDataSource();


        }
        public void ReLoadQuyDinh()
        {
            var query = _quydinhBLL.LoadQuyDinh(txt_TenQuyDinh.Text);
            foreach (var i in query)
            {
                txt_MaQuyDinh.Text = i.id_quydinh.ToString();
            }
        }
        public bool KiemTraLuu()
        {
            var query = _quydinhBLL.KiemTraQuyDinh();
            foreach (var i in query)
            {
                if(i.tenquydinh == txt_TenQuyDinh.Text)
                {
                    return false;
                }
            }
            return true;
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (kt == "Them")
            {
                QuyDinh qd = new QuyDinh();
                qd.tenquydinh = txt_TenQuyDinh.Text;
                qd.id_nhanvien = (int)cmb_NhanVienLap.EditValue;
                qd.ngaylap = dt_NgayLap.DateTime;
                qd.noidung = rxt_NoiDung.Text;
                if (KiemTraLuu() == true)
                {
                    _quydinhBLL.ThemQuyDinh(qd);
                    Notifications.Answers("Thêm thành công!");
                    ReLoadQuyDinh();
                    LoadDataSource();
                }
                else
                {
                    if (txt_MaQuyDinh.Text != "")
                    {
                        QuyDinh qd1 = new QuyDinh();
                        qd1.id_quydinh = int.Parse(txt_MaQuyDinh.Text);
                        qd1.tenquydinh = txt_TenQuyDinh.Text;
                        qd1.id_nhanvien = (int)cmb_NhanVienLap.EditValue;
                        qd1.ngaylap = dt_NgayLap.DateTime;
                        qd1.noidung = rxt_NoiDung.Text;
                        _quydinhBLL.CapNhatQuyDinh(qd1);
                        Notifications.Answers("Sửa thành công!");
                        LoadDataSource();
                    }
                    else
                        Notifications.Answers("Quy định đã có trong danh sách!");

                   

                }
                
            }
            else
                if (kt == "Sua")
                {
                    QuyDinh qd = new QuyDinh();
                    qd.id_quydinh = int.Parse(txt_MaQuyDinh.Text);
                    qd.tenquydinh = txt_TenQuyDinh.Text;
                    qd.id_nhanvien = (int)cmb_NhanVienLap.EditValue;
                    qd.ngaylap = dt_NgayLap.DateTime;
                    qd.noidung = rxt_NoiDung.Text;
                    _quydinhBLL.CapNhatQuyDinh(qd);
                    Notifications.Answers("Sửa thành công!");
                    LoadDataSource();



                }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa quy định này!", "THÔNG BÁO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                _quydinhBLL.XoaQuyDinh(int.Parse(txt_MaQuyDinh.Text));
                Notifications.Answers("Xóa thành công!");
                btn_LamMoi_Click(sender, e);
                LoadDataSource();
            }
            else
                Notifications.Answers("Xóa không thành công!");
           

        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_InQuyDinh sc = new Frm_InQuyDinh(int.Parse(txt_MaQuyDinh.Text));
                sc.Show();
            }
            catch (Exception)
            {

                Notifications.Answers(" Bạn chưa chọn sự cố để in");
            }
        }

     

    }
}