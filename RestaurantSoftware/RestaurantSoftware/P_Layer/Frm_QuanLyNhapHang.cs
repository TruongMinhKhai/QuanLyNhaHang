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
using RestaurantSoftware.DA_Layer;
using DevExpress.XtraGrid.Columns;
namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_QuanLyNhapHang : DevExpress.XtraEditors.XtraForm
    {
        NhapHang_BLL _nhaphangBLL = null;
        List<string> trangthaiPhieuNhap = new List<string>();
        DataTable dt = null;
        bool kiemtraTaoPhieu = false;
        // khởi tạo 
        public Frm_QuanLyNhapHang()
        {
            InitializeComponent();
            dt = new DataTable();
            _nhaphangBLL = new NhapHang_BLL();
        }
        // load form quản lý nhập hàng
        private void Frm_QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            Init();
            LoadDsNguyenLieu();
            LoadDsNhanVien();
            LoadDsNhaCungCap();
            LoadDsPhieuNhap();
            //LoadDsChiTietPhieuNhap();
        }
        // load init
        private void Init()
        {
            _nhaphangBLL.LoadTrangThai(trangthaiPhieuNhap, "nhaphang");
            txtMaPhieuNhap.Text = _nhaphangBLL.LayIdNhapHang();
            dtNgayNhap.Text = DateTime.Now.ToShortDateString();
            txtTongTien.Text = "0";
            txtThue.EditValue = 10;
            txtTongThanhToan.EditValue = 0;
        }
        // load nguyên liệu
        private void LoadDsNguyenLieu() {
            _nhaphangBLL.LoadDsNguyenLieu(grc_DsNguyenLieu);
        }
        // load nhà cung cấp
        private void LoadDsNhaCungCap()
        {
            dt = Utils.Utils.ConvertToDataTable<NhaCungCap>(_nhaphangBLL.LoadDsNhaCungCap());
            cmbNhaCungCap.Properties.DataSource = dt;
            cmbNhaCungCap.Properties.DisplayMember = "tennhacungcap";
            cmbNhaCungCap.Properties.ValueMember = "id_nhacungcap";
        }
        // load nhân viên
        private void LoadDsNhanVien()
        {
            dt = Utils.Utils.ConvertToDataTable<NhanVien>(_nhaphangBLL.LoadDsNhanVien());
            cmbNhanVien.Properties.DataSource = dt;
            cmbNhanVien.Properties.DisplayMember = "tennhanvien";
            cmbNhanVien.Properties.ValueMember = "id_nhanvien";
        }
        // load danh sách phiếu nhập
        private void LoadDsPhieuNhap()
        {
            _nhaphangBLL.LoadDsPhieuNhap(grc_DsPhieuNhap);
        }
        // load chi tiết phiếu nhập
        private void LoadChiTietPhieuNhap()
        {
           //int id = int.Parse(txtMaPhieuNhap.Text);
           int id = int.Parse(grv_DsPhieuNhap.GetRowCellValue(grv_DsPhieuNhap.FocusedRowHandle, "id_nhaphang").ToString());
            _nhaphangBLL.LoadChiTietPhieuNhap(id, grc_DsChiTietPhieuNhap);
            TongTien();
            TongThanhToan();
            ChuyenVeTienTe(txtTongTien);
            ChuyenVeTienTe(txtTongThanhToan);
        }
        // lấy trạng thái phiếu nhập
        public string GetTrangThaiPhieuNhap(int index)
        {
            switch (index)
            {
                case 0:
                    return trangthaiPhieuNhap[0];
                case 1:
                    return trangthaiPhieuNhap[1];
            }
            return "";
        }
        // xử lý thêm tên hàng hóa vào danh sách chi tiết nhập hàng
        private void btn_ThemHangHoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (kiemtraTaoPhieu == true|| grv_DsPhieuNhap.GetRowCellValue(grv_DsPhieuNhap.FocusedRowHandle, "id_nhaphang") != null)
            {
                Chitiet_HoaDonNhapHang cthd = new Chitiet_HoaDonNhapHang();
                if(grv_DsPhieuNhap.GetRowCellValue(grv_DsPhieuNhap.FocusedRowHandle, "id_nhaphang")!=null){
                    cthd.id_nhaphang = int.Parse(grv_DsPhieuNhap.GetRowCellValue(grv_DsPhieuNhap.FocusedRowHandle, "id_nhaphang").ToString());
                }
                else {
                    cthd.id_nhaphang = int.Parse(txtMaPhieuNhap.Text);
                }
                cthd.id_hanghoa = int.Parse(grv_DsNguyenLieu.GetFocusedRowCellValue(Col_MaHangHoa).ToString());
                cthd.soluong = 0;
                cthd.dongia = 0;
                cthd.thanhtien = cthd.dongia * cthd.dongia;
                if (_nhaphangBLL.KiemTraHangHoaDaCoChua(cthd.id_nhaphang, cthd.id_hanghoa) > 0)
                {
                    //_nhaphangBLL.CapNhatChiTietNhapHang(cthd);
                    MessageBox.Show("Tên nguyên liệu đã tồn tại");
                }
                else
                {
                    _nhaphangBLL.ThemChiTiet(cthd);
                    MessageBox.Show("Thêm nguyên liệu thành công");
                }
                //_nhaphangBLL.ThemChiTiet(cthd);
                //_nhaphangBLL.LoadChiTietPhieuNhap(grv_DsNguyenLieu.GetFocusedRowCellValue(col_TenHangHoa).ToString(), dtNgayNhap.DateTime, grc_DsChiTietPhieuNhap);
                LoadChiTietPhieuNhap();
            }
        }
        // xử lý xóa phiếu
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (grv_DsPhieuNhap.GetFocusedRowCellValue(col_MaPhieuNhap) != null)
            {
                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa phiếu không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = int.Parse(grv_DsPhieuNhap.GetFocusedRowCellValue(col_MaPhieuNhap).ToString());
                    _nhaphangBLL.XoaHoaDonNhapHang(id);
                    MessageBox.Show("Xóa phiếu thành công");
                    LoadDsPhieuNhap();
                    LoadDsNhanVien();
                    LoadChiTietPhieuNhap();
                }
            }
            else
            {
                MessageBox.Show("Chọn phiếu nhập muốn xóa");
            }
        }
        // xử lý thêm phiếu
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            HoaDonNhapHang hd = new HoaDonNhapHang();
            if (cmbNhaCungCap.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tên nhà cung cấp");
                return;
            }
            else if (cmbNhanVien.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tên nhân viên");
                return;
            }
            hd.id_nhacungcap =(int)cmbNhaCungCap.EditValue;
            hd.thoigian = dtNgayNhap.DateTime.Date;
            hd.id_nhanvien = (int)cmbNhanVien.EditValue;
            hd.trangthai = trangthaiPhieuNhap[0]; // 0: Chưa nhập vào kho , 1: Đã nhập vào kho
            hd.ghichu = (txtGhiChu.Text.Equals("")) ? "" : txtGhiChu.Text;
            _nhaphangBLL.ThemHoaDonNhapHang(hd);
            kiemtraTaoPhieu = true;
            Notifications.Success("Tạo phiếu thành công");
            Init();
            LoadDsPhieuNhap();
        }
        // xử lý sự kiện khi nhấn vào hàng
        private void grv_DsPhieuNhap_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtMaPhieuNhap.Text = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle, "id_nhaphang").ToString();
            cmbNhaCungCap.Properties.ValueMember = "tennhacungcap";
            cmbNhaCungCap.EditValue = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"tennhacungcap").ToString();
            cmbNhaCungCap.Properties.ValueMember = "id_nhacungcap";
            dtNgayNhap.DateTime=(DateTime) grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"thoigian");
            cmbNhanVien.Properties.ValueMember = "tennhanvien";
            cmbNhanVien.EditValue = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle, "tennhanvien").ToString();
            cmbNhanVien.Properties.ValueMember = "id_nhanvien";
            txtGhiChu.Text = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"ghichu").ToString();
            btnTaoPhieu.Enabled = false;
            if (grv_DsPhieuNhap.GetFocusedRowCellDisplayText(col_TrangThai) == "Chưa nhập vào kho")
            {
                _nhaphangBLL.LayDsThamSo(txtThue);
                btnTaoPhieu.Enabled = false;
                btnNhapKho.Enabled = true;
                btnSuaPhieu.Enabled = true;
                btnThemNCC.Enabled = true;
                cmbNhaCungCap.ReadOnly = false;
                cmbNhanVien.ReadOnly = false;
                //btnLamMoi.Enabled = false;
                btnThemNV.Enabled = true;
                txtGhiChu.ReadOnly = false;
                btn_ThemHangHoa.Buttons[0].Enabled = true;
                col_DonGia.OptionsColumn.ReadOnly = false;
                col_SoLuong.OptionsColumn.ReadOnly = false;
            }
            else if (grv_DsPhieuNhap.GetFocusedRowCellDisplayText(col_TrangThai) == "Đã nhập vào kho")
            {
                //txtThue.Text = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"thue").ToString();
                btnNhapKho.Enabled = false;
                btnTaoPhieu.Enabled = false;
                btnSuaPhieu.Enabled = false;
                btnThemNCC.Enabled = false;
                cmbNhaCungCap.ReadOnly = true;
                cmbNhanVien.ReadOnly = true;
                //btnLamMoi.Enabled = false;
                btnThemNV.Enabled = false;
                txtGhiChu.ReadOnly = true;
                btn_ThemHangHoa.Buttons[0].Enabled = false;
                col_DonGia.OptionsColumn.ReadOnly = true;
                col_SoLuong.OptionsColumn.ReadOnly = true;
            }
            LoadChiTietPhieuNhap();
        }
        // Tính tổng tiền số hàng hóa nhập vào
        private void TongTien()
        {
            try
            {
                var tongtien = grv_DsChiTietPhieuNhap.Columns["thanhtien"].SummaryItem.SummaryValue;
                txtTongTien.EditValue = tongtien;
            }
            catch (Exception)
            {
                Notifications.Answers("Lỗi tổng tiền");
            }
        }
        // Tính tổng thanh toán hàng hóa  bao gồm cả thuế
        private void TongThanhToan()
        {
            try
            {
                int tongtien = Convert.ToInt32(grv_DsChiTietPhieuNhap.Columns["thanhtien"].SummaryItem.SummaryValue);
                var tongthanhtoan = tongtien + (tongtien * int.Parse(txtThue.Text)) * 0.01;
                //txtTongThanhToan.EditValue = tongthanhtoan;
                txtTongThanhToan.Text = tongthanhtoan.ToString();
            }
            catch (Exception)
            {
                Notifications.Answers("Lỗi tổng thanh toán!");
            }
        }
        // chuyển về kiểu int
        public void ChuyenVeTienTe(TextEdit txt)
        {
            try
            {
                if (txt.Text == "0")
                {
                    int c = int.Parse(txt.Text);
                    txt.Text = c.ToString("0");
                }
                else
                {
                    int c = int.Parse(txt.Text);
                    txt.Text = c.ToString("#,###");
                }
            }
            catch (Exception)
            {

            }
        }
        public int ChuyenVeKieuInt(TextEdit txt)
        {
            int temp = 0;
            try
            {
                if (txt.Text == "0")
                {
                    int c = int.Parse(txt.Text);
                    temp = int.Parse(c.ToString("0"));
                    return temp;
                }
                else
                {
                    temp = int.Parse((txt.Text).Replace(",", ""));
                    return temp;
                }
            }
            catch (Exception)
            {

                return temp;
            }
        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (grv_DsPhieuNhap.GetRowCellValue(grv_DsPhieuNhap.FocusedRowHandle, "id_nhaphang") != null)
                {
                    if (grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang) != null
                    && grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaHang) != null)
                    {
                        // hàm kiểm tra dữ liệu hợp lệ
                        int soluong = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("soluong").ToString());
                        int dongia = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("dongia").ToString());
                        if (soluong <= 0)
                        {
                            MessageBox.Show("Số lượng phải lớn hơn không");
                            return;
                        }else if(dongia <= 0){
                            MessageBox.Show("Đơn giá phải lớn hơn không");
                            return;
                        }
                        //
                        int idhd = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang).ToString());
                        int idhh = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaHang).ToString());
                        DialogResult result = MessageBox.Show("Chắc chắn muốn nhập vào kho?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == result)
                        {
                            _nhaphangBLL.CapNhatNguyenLieuTon(idhd, idhh);
                            MessageBox.Show("Nhập kho thành công");
                            _nhaphangBLL.CapNhatTrangThai(idhd, GetTrangThaiPhieuNhap(1));
                            //GetTrangThaiPhieuNhap(1);
                            //_nhaphangBLL.LoadTrangThai(trangthaiPhieuNhap, "nhaphang");
                        }
                        LoadDsPhieuNhap();
                        LoadDsNguyenLieu();
                    }
                }
                else {
                    MessageBox.Show("Vui lòng chọn phiếu cần nhập vào kho");
                }
            }
            catch (Exception)
            {

                //MessageBox.Show("Vui lòng chọn phiếu cần nhập vào kho");
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Frm_NhaCungCap ncc = new Frm_NhaCungCap();
            ncc.MdiParent = FormMain.ActiveForm;
            ncc.Show();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Frm_NguoiDung nv = new Frm_NguoiDung();
            nv.MdiParent = FormMain.ActiveForm;
            nv.Show();
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            if (grv_DsPhieuNhap.GetFocusedRowCellValue(col_MaPhieuNhap) != null)
            {
                HoaDonNhapHang hd = new HoaDonNhapHang();
                hd.id_nhaphang = int.Parse(grv_DsPhieuNhap.GetFocusedRowCellValue(col_MaPhieuNhap).ToString());
                hd.id_nhacungcap = (int)cmbNhaCungCap.EditValue;
                hd.thoigian = dtNgayNhap.DateTime;
                hd.id_nhanvien = (int)cmbNhanVien.EditValue;
                hd.ghichu = (txtGhiChu.Text != null) ? txtGhiChu.Text : "";
                _nhaphangBLL.SuaPhieuNhap(hd);
                MessageBox.Show("Sửa phiếu thành công");
                LoadDsPhieuNhap();
            }
            else
            {
                MessageBox.Show("Chọn phiếu nhập hàng muốn sửa");
            }
        }

        private void xoachitiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang)!= null 
                && grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaHang)!= null){
                    int idhd = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang).ToString());
                    int idhh = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaHang).ToString());
                    DialogResult result = MessageBox.Show("Chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        _nhaphangBLL.XoaChiTietHoaDonNhapHang(idhd,idhh);
                        MessageBox.Show("Xóa thành công");
                        _nhaphangBLL.LoadChiTietPhieuNhap(idhd,grc_DsChiTietPhieuNhap);
                    }
            }
        }

        private void grv_DsChiTietPhieuNhap_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                int soluong = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("soluong").ToString());
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn không");
                    return;
                }
                double dongia = double.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("dongia").ToString());
                double thanhtien = soluong * dongia;
                grv_DsChiTietPhieuNhap.SetFocusedRowCellValue("thanhtien", thanhtien);
                _nhaphangBLL.UpdateDatabase(); // cập nhật chi tiết nhập hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnTaoPhieu.Enabled = true;
           // _nhaphangBLL.LoadTrangThai(trangthaiPhieuNhap, "nhaphang");
            txtMaPhieuNhap.Text = (_nhaphangBLL.LayIdNhapHang() + 1).ToString();
            dtNgayNhap.Text = DateTime.Now.ToShortDateString();
            cmbNhaCungCap.EditValue = null;
            cmbNhanVien.EditValue = null;
            btnThemNCC.Enabled = true;
            btnThemNV.Enabled = true;
            txtGhiChu.ReadOnly = false;
            txtGhiChu.Text = "";
            txtThue.EditValue = 10;
            txtTongTien.EditValue = 0;
            txtTongThanhToan.EditValue = 0;

            //
            cmbNhaCungCap.ReadOnly = false;
            cmbNhanVien.ReadOnly = false;
            LoadChiTietPhieuNhap();
            LoadDsPhieuNhap();
        }
    }
}