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
        bool ktCapNhatPhieuNhap = false; 
        int ID_NHANVIEN = 0;
        string TEN_NHANVIEN = "";
        int ID_NHAPHANG = 0;
        // khởi tạo 
        public Frm_QuanLyNhapHang(int idnv, string tennv)
        {
            InitializeComponent();
            dt = new DataTable();
            _nhaphangBLL = new NhapHang_BLL();
            ID_NHANVIEN = idnv;
            TEN_NHANVIEN = tennv;
            ID_NHAPHANG = _nhaphangBLL.LayID() + 1;
        }
        // load form quản lý nhập hàng
        private void Frm_QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            Init();
            LoadDsNguyenLieu();
            LoadDsNhaCungCap();
            LoadDsPhieuNhap();
            //LoadDsChiTietPhieuNhap();
        }
        // load init
        private void Init()
        {
            _nhaphangBLL.LoadTrangThai(trangthaiPhieuNhap, "nhaphang");
            txtMaPhieuNhap.Text = _nhaphangBLL.HienThiID(ID_NHAPHANG);
            txtNhanVien.Text = TEN_NHANVIEN;
            dtNgayNhap.Text = DateTime.Now.ToShortDateString();
            txtTongTien.Text = "0";
            txtThue.Text = "10";
            txtTongThanhToan.Text = "0";
            // ẩn nút thêm hàng hóa chi tiet phiếu nhập
            btn_ThemHangHoa.Buttons[0].Enabled = false;
            // ẩn nút làm mới
            btnLamMoi.Enabled = false; 
            // ẩn nút cập nhật
            btnSuaPhieu.Enabled = false;
            // ẩn nút xóa
            btnXoaPhieu.Enabled = false;
            // ẩn nút in
            btnInPhieu.Enabled = false;
            // ẩn nút nhập kho
            btnNhapKho.Enabled = false;
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
        // load danh sách phiếu nhập
        private void LoadDsPhieuNhap()
        {
            _nhaphangBLL.LoadDsPhieuNhap(grc_DsPhieuNhap);
        }
        // load chi tiết phiếu nhập
        private void LoadChiTietPhieuNhap()
        {
            _nhaphangBLL.LoadChiTietPhieuNhap(ID_NHAPHANG, grc_DsChiTietPhieuNhap);
        }
        private void LoadTinhToan()
        {
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
        // load trạng thái đang theo dõi
        public void LoadTrangThaiDangTheoDoi()
        {
            _nhaphangBLL.LayDsThamSo(txtThue);
            btnTaoPhieu.Enabled = false;
            btnNhapKho.Enabled = true;
            btnSuaPhieu.Enabled = true;
            btnThemNCC.Enabled = true;
            cmbNhaCungCap.ReadOnly = false;
            //btnLamMoi.Enabled = false;
            txtGhiChu.ReadOnly = false;
            btn_ThemHangHoa.Buttons[0].Enabled = true;
            col_DonGia.OptionsColumn.ReadOnly = false;
            col_SoLuong.OptionsColumn.ReadOnly = false;
            btnThemHangHoa.Enabled = true;
            btnSuaPhieu.Enabled = true;
        }
        // load trạng thái đã nhập kho
        public void LoadTrangThaiDaNhapKho()
        {
            btnNhapKho.Enabled = false;
            btnXoaPhieu.Enabled = false; // xóa phiếu
            btnTaoPhieu.Enabled = false;
            btnSuaPhieu.Enabled = false;
            btnThemNCC.Enabled = false;
            cmbNhaCungCap.ReadOnly = true;
            //btnLamMoi.Enabled = false;
            txtGhiChu.ReadOnly = true;
            btn_ThemHangHoa.Buttons[0].Enabled = false;
            col_DonGia.OptionsColumn.ReadOnly = true;
            col_SoLuong.OptionsColumn.ReadOnly = true;
            btnThemHangHoa.Enabled = false;
        }
        // xử lý thêm tên hàng hóa vào danh sách chi tiết nhập hàng
        private void btn_ThemHangHoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtMaPhieuNhap.Text != null && ID_NHAPHANG != 0)
            {
                Chitiet_HoaDonNhapHang cthd = new Chitiet_HoaDonNhapHang();
                cthd.id_nhaphang = ID_NHAPHANG;
                cthd.id_hanghoa = int.Parse(grv_DsNguyenLieu.GetFocusedRowCellValue(col_MaHangHoa).ToString());
                if(grv_DsChiTietPhieuNhap.EditingValue == null){
                    cthd.soluong = 1;
                    decimal dongia = decimal.Parse(grv_DsNguyenLieu.GetFocusedRowCellValue(col_GiaBanDau).ToString());
                    cthd.dongia = dongia;
                }
                else {
                    cthd.soluong = int.Parse(grv_DsChiTietPhieuNhap.EditingValue.ToString());
                    cthd.dongia = int.Parse(grv_DsChiTietPhieuNhap.EditingValue.ToString());
                }
                cthd.thanhtien = cthd.soluong * cthd.dongia;
                if (_nhaphangBLL.KiemTraHangHoaDaCoChua(cthd.id_nhaphang, cthd.id_hanghoa) > 0)
                {
                    _nhaphangBLL.CapNhatChiTietNhapHang(cthd);
                    MessageBox.Show("Thêm nguyên liệu thành công");
                }
                else
                {
                    _nhaphangBLL.ThemChiTiet(cthd);
                   MessageBox.Show("Thêm nguyên liệu thành công");
                }
                LoadChiTietPhieuNhap();
                LoadTinhToan();
            }
        }
        // xử lý xóa phiếu
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuNhap.Text != null && ID_NHAPHANG != 0)
            {
                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa phiếu không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                     _nhaphangBLL.XoaHoaDonNhapHang(ID_NHAPHANG);
                        MessageBox.Show("Xóa phiếu thành công");
                    LoadDsPhieuNhap();
                    LoadChiTietPhieuNhap();
                    LoadTinhToan();
                    LoadDsPhieuNhap();
                    LoadChiTietPhieuNhap();
                    LoadTinhToan();
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
            else if (txtNhanVien.Text == null)
            {
                MessageBox.Show("Vui lòng chọn tên nhân viên");
                return;
            }
            hd.id_nhacungcap = (int)cmbNhaCungCap.EditValue;
            hd.thoigian = dtNgayNhap.DateTime.Date;
            hd.id_nhanvien = ID_NHANVIEN;
            hd.trangthai = trangthaiPhieuNhap[0]; // 0: Đang theo dõi , 1: Đã nhập vào kho
            hd.ghichu = (txtGhiChu.Text.Equals("")) ? "" : txtGhiChu.Text;
            _nhaphangBLL.ThemHoaDonNhapHang(hd);
            //kiemtraTaoPhieu = true;
            Notifications.Success("Tạo phiếu thành công");
            // bật nút thêm hàng hóa chi tiết
            btn_ThemHangHoa.Buttons[0].Enabled = true;
            // bật nút xóa 
            btnXoaPhieu.Enabled = true;
            // bật nút cập nhật
            btnSuaPhieu.Enabled = true;
            // bật nút làm mới
            btnLamMoi.Enabled = true;
            // bật nút in 
            btnInPhieu.Enabled = true;
            // bật nút nhập kho
            btnNhapKho.Enabled = true;
            ID_NHAPHANG = _nhaphangBLL.LayID();
            //chonPhieuNhap = true;
            //Init();
            LoadDsPhieuNhap();
        }
        // xử lý sự kiện khi nhấn vào hàng
        private void grv_DsPhieuNhap_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ID_NHAPHANG = int.Parse(grv_DsPhieuNhap.GetRowCellValue(e.RowHandle, "id_nhaphang").ToString());
            //chonPhieuNhap = true;
            txtMaPhieuNhap.Text = _nhaphangBLL.HienThiID(ID_NHAPHANG);
            cmbNhaCungCap.Properties.ValueMember = "tennhacungcap";
            cmbNhaCungCap.EditValue = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"tennhacungcap").ToString();
            cmbNhaCungCap.Properties.ValueMember = "id_nhacungcap";
            dtNgayNhap.DateTime=(DateTime) grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"thoigian");
           
            txtGhiChu.Text = grv_DsPhieuNhap.GetRowCellValue(e.RowHandle,"ghichu").ToString();
            // bật nút tạo phiếu
            btnTaoPhieu.Enabled = false;
            // bật nút làm mới
            btnLamMoi.Enabled = true;
            // bật nút in 
            btnInPhieu.Enabled = true;
            // bật nút xóa
            btnXoaPhieu.Enabled = true;
            if (grv_DsPhieuNhap.GetFocusedRowCellDisplayText(col_TrangThai) == "Đang theo dõi")
            {
                LoadTrangThaiDangTheoDoi();
            }
            else if (grv_DsPhieuNhap.GetFocusedRowCellDisplayText(col_TrangThai) == "Đã nhập vào kho")
            {
                LoadTrangThaiDaNhapKho();
            }
            LoadChiTietPhieuNhap();
            LoadTinhToan();
        }
        // Tính tổng tiền số hàng hóa nhập vào
        private void TongTien()
        {
            try
            {
                int tongtien = Convert.ToInt32(grv_DsChiTietPhieuNhap.Columns["thanhtien"].SummaryItem.SummaryValue);
                txtTongTien.EditValue = (tongtien != 0) ? tongtien : 0;
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
                txtTongThanhToan.EditValue = (tongthanhtoan != 0) ? tongthanhtoan : 0;
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
        // xử lý nút thêm nhà cung cấp
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Frm_NhaCungCap ncc = new Frm_NhaCungCap();
            ncc.MdiParent = FormMain.ActiveForm;
            ncc.Show();
        }
        // cập nhật phiếu nhập
        public void CapNhatPhieuNhap()
        {
            HoaDonNhapHang hd = new HoaDonNhapHang();
            hd.id_nhaphang = ID_NHAPHANG;
            hd.id_nhacungcap = (int)cmbNhaCungCap.EditValue;
            hd.thoigian = dtNgayNhap.DateTime;
            hd.id_nhanvien = ID_NHANVIEN;
            hd.thue = int.Parse(txtThue.Text);
            hd.tongtien = decimal.Parse(txtTongThanhToan.Text);
            //hd.trangthai = trangthaiPhieuNhap[0];// trạng thái đang theo dõi
            hd.ghichu = (txtGhiChu.Text != null) ? txtGhiChu.Text : "";
            _nhaphangBLL.SuaPhieuNhap(hd);
            ktCapNhatPhieuNhap = true;
        }
        // xử lý nút cập nhật
        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhieuNhap.Text != null && ID_NHAPHANG != 0)
                {
                    CapNhatPhieuNhap();
                    if (ktCapNhatPhieuNhap)
                    {
                        MessageBox.Show("Sửa phiếu thành công");
                        LoadDsPhieuNhap();
                    }
                    else
                    {
                        MessageBox.Show("Sửa phiếu nhập không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Chọn phiếu nhập hàng muốn sửa");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        // xử lý nút xóa trên gridcontrol
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
                        LoadTinhToan();
                    }
            }
        }
        // xử lý nút làm mới 
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnTaoPhieu.Enabled = true;
            btnThemHangHoa.Enabled = true;
            ID_NHAPHANG = _nhaphangBLL.LayID() + 1;
            txtMaPhieuNhap.Text = _nhaphangBLL.HienThiID(ID_NHAPHANG);
            dtNgayNhap.Text = DateTime.Now.ToShortDateString();
            cmbNhaCungCap.EditValue = null;
            btnThemNCC.Enabled = true;
            txtGhiChu.ReadOnly = false;
            txtGhiChu.Text = "";
            txtThue.EditValue = 10;
            txtTongTien.EditValue = 0;
            txtTongThanhToan.EditValue = 0;

            cmbNhaCungCap.ReadOnly = false;
            LoadChiTietPhieuNhap();
            LoadDsPhieuNhap();
        }
        // xử lý nút thêm mới hàng hóa
        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            Frm_NguyenLieu hh = new Frm_NguyenLieu();
            hh.MdiParent = FormMain.ActiveForm;
            hh.Show();
        }
        // xử lý khi thay đổi dữ liệu trên grid
        private void grv_DsChiTietPhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia")
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
                    _nhaphangBLL.UpdateDatabase();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi!");
            }
            LoadChiTietPhieuNhap();
            LoadTinhToan();
        }
        // xử lý nút nhập kho
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhieuNhap.Text != null && ID_NHAPHANG != 0)
                {
                    if (grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang) != null
                    && grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaHang) != null)
                    {
                        // hàm kiểm tra dữ liệu hợp lệ
                        int soluong = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("soluong").ToString());
                        decimal dongia = decimal.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue("dongia").ToString());
                        if (soluong <= 0)
                        {
                            MessageBox.Show("Số lượng phải lớn hơn không");
                            return;
                        }
                        else if (dongia <= 0)
                        {
                            MessageBox.Show("Đơn giá phải lớn hơn không");
                            return;
                        }
                        int idhd = int.Parse(grv_DsChiTietPhieuNhap.GetFocusedRowCellValue(col_MaNhapHang).ToString());
                        DialogResult result = MessageBox.Show("Chắc chắn muốn nhập vào kho?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == result)
                        {
                            _nhaphangBLL.CapNhatNguyenLieuTon(idhd);// cập nhật toàn bộ hàng hóa
                            CapNhatPhieuNhap();
                            if (ktCapNhatPhieuNhap)
                            {
                                _nhaphangBLL.CapNhatTrangThai(idhd, GetTrangThaiPhieuNhap(1));
                            }
                            MessageBox.Show("Nhập kho thành công");
                        }
                        LoadDsPhieuNhap();
                        LoadDsNguyenLieu();
                        LoadTrangThaiDaNhapKho(); // load lại trạng thái đã nhập kho
                    }
                    else {
                        MessageBox.Show("Bạn chưa nhập hàng hóa");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phiếu cần nhập vào kho");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi mã phiếu nhập");
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            Frm_InPhieuNhapHang pnh = new Frm_InPhieuNhapHang(ID_NHAPHANG);
            //MessageBox.Show("ID " + ID_NHAPHANG);
            pnh.Show();
        }

        private void repositoryItemTextEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }
    }
}