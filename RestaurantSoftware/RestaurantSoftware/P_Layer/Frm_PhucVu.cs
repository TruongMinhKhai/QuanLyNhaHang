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

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_PhucVu : DevExpress.XtraEditors.XtraForm
    {
        PhucVu_BLL phucvubll = new PhucVu_BLL();
        DateTime today = DateTime.Today;
        List<string> ttban = new List<string>(); //0. trống, 1. đầy, 2.đặt
        List<string> ttdatban = new List<string>(); //0. chờ, 1.nhận, 2.hủy
        List<string> tthoadon = new List<string>(); //0.chưa thanh toán, 1.đã thanh toán
        IQueryable<Ban> DsBan;
        int idbanSelected;
        int idhoadonSelected;
        int idhoadonMoved;
        int ID_NHANVIEN = 0;
        bool ischuyenban = false;
        string trangthaibanSelected ="";
        public Frm_PhucVu(int idnv)
        {
            InitializeComponent();
            ID_NHANVIEN = idnv;
        }
        public void Init()
        {
            btn_ChuyenBan.Enabled = false;
            idbanSelected = 0;
            idbanSelected = 0;
            dateEdit1.DateTime = today;
            ttban = phucvubll.TrangThaiBan(); //0. trống, 1. đầy, 2.đặt
            ttdatban = phucvubll.TrangThaiPhieuDatBan(); //0. chờ, 1.nhận, 2.hủy
            tthoadon = phucvubll.TrangThaiHoaDon(); //0.chưa thanh toán, 1.đã thanh toán
            DsBan = phucvubll.LayDanhSachBan();
            LoadThucDon();
        }
        public void LoadDsBan()
        {
            lvBan.Clear();
            lvBan.LargeImageList = imageList1;

            foreach (var dr in DsBan)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr.tenban;
                
                if(dr.trangthai == ttban[0])
                {
                    lvItem.ImageIndex = 2; //trống
                }
                else if(dr.trangthai == ttban[1])
                {
                    lvItem.ImageIndex = 0; //đầy
                }
                else
                {
                    lvItem.ImageIndex = 1; //đặt
                }

                lvItem.Name = dr.id_ban.ToString();
                lvGroup.Header = dr.LoaiBan.tenloaiban;
                lvItem.Group = lvGroup;

                if (lvBan.Groups.Count != 0)
                {
                    foreach (ListViewGroup gr in lvBan.Groups)
                    {
                        if (gr.Header == lvGroup.Header)
                        {
                            exsistGroup = true;
                            lvItem.Group = gr;
                            break;
                        }
                    }
                    if (exsistGroup == false)
                    {
                        lvBan.Groups.Add(lvGroup);
                    }

                }
                else lvBan.Groups.Add(lvGroup);
                lvBan.Items.Add(lvItem);

            }
        }

        public void CapNhatTrangThaiBan()
        {
            phucvubll.CapNhatTrangThaiBan(today, ttban, ttdatban, tthoadon);
        }
        private void Frm_PhucVu_Load(object sender, EventArgs e)
        {
            Init();
            CapNhatTrangThaiBan();
            LoadDsBan();
        }

        public void LoadThucDon()
        {
            phucvubll.LayDanhSachMon(gridControl_ThucDon);
        }

        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView_ChitietHoaDon.GetFocusedRowCellValue(chitiet_idhoadon) != null
                    && gridView_ChitietHoaDon.GetFocusedRowCellValue(chitiet_idmon) != null)
            {
                int idhd = int.Parse(gridView_ChitietHoaDon.GetFocusedRowCellValue(chitiet_idhoadon).ToString());
                int idm = int.Parse(gridView_ChitietHoaDon.GetFocusedRowCellValue(chitiet_idmon).ToString());

                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    phucvubll.XoaChiTietHoaDon(idhd, idm);
                    MessageBox.Show("Xóa thành công");
                    phucvubll.LoadChiTietHoaDon(idhd, gridControl_ChitietHoaDon);
                }
            }
        }

        private void btnThemMon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txt_idHoadon.Text != "")
            {
                Chitiet_HoaDonThanhToan cthd = new Chitiet_HoaDonThanhToan();
                cthd.id_hoadon = int.Parse(txt_idHoadon.Text);
                if (gridView_ThucDon.EditingValue == null)
                {
                    cthd.soluong = 1;
                }
                else
                    cthd.soluong = int.Parse(gridView_ThucDon.EditingValue.ToString());

                cthd.dongia = decimal.Parse(gridView_ThucDon.GetFocusedRowCellValue(thucdon_gia).ToString());
                cthd.thanhtien = cthd.soluong * cthd.dongia;
                cthd.id_mon = int.Parse(gridView_ThucDon.GetFocusedRowCellValue(thucdon_idmon).ToString());
                if (phucvubll.KiemTraMonDaCoChua(cthd.id_hoadon, cthd.id_mon) > 0)
                {
                    //update
                    phucvubll.CapNhatChiTietHoaDon(cthd);
                    MessageBox.Show("Thêm món thành công");
                }
                else
                {
                    //add new
                    phucvubll.ThemMoiChiTietHoaDon(cthd);
                    MessageBox.Show("Thêm món mới thành công");
                }
                phucvubll.LoadChiTietHoaDon(idhoadonSelected, gridControl_ChitietHoaDon);

            }
            else
                MessageBox.Show("Bàn chưa có khách!");
        }

        public string GetTrangThaiBan(int index)
        {
            switch(index)
            {
                case 0:
                    return ttban[1];
                case 1:
                    return ttban[2];
                case 2:
                    return ttban[0];
            }
            return "";
        }
        public void SetTrangThaiChuyenBan(string trangthai)
        {
            if(trangthai == ttban[0]) //trống
            {
                btn_ChuyenBan.Enabled = false;
            }
            if(trangthai == ttban[1]) //đầy
            {
                btn_ChuyenBan.Enabled = true;
            }
        }
        private void lvBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBan.SelectedItems.Count > 0)
            {
                txt_idHoadon.Text = "";
                idhoadonSelected = 0;
                txt_Ban.Text = lvBan.SelectedItems[0].Text;
                trangthaibanSelected = GetTrangThaiBan(lvBan.SelectedItems[0].ImageIndex);
                idbanSelected = Convert.ToInt16(lvBan.SelectedItems[0].Name);
                ReLoadHoaDon();
                //chuyen ban
                if(ischuyenban == true)
                {
                    //sửa hóa đơn: id_ban
                    if(idhoadonSelected != 0)
                    {
                        MessageBox.Show("Xin chọn bàn trống");
                        ischuyenban = false;
                        SetEnableControl(true);
                        return;
                    }
                    else
                    {
                        phucvubll.SuaHoaDon(idbanSelected, idhoadonMoved);
                        ischuyenban = false;
                        SetEnableControl(true);
                        ReLoadHoaDon();
                        CapNhatTrangThaiBan();
                        LoadDsBan();
                        MessageBox.Show("Đã chuyển bàn!");
                    }
                }
                else
                {
                    SetTrangThaiChuyenBan(trangthaibanSelected);
                }
                
            }
        }

        public void ReLoadHoaDon()
        {
            var query = phucvubll.LoadHoaDon(idbanSelected, today, tthoadon[0]);
                foreach(var i in query)
                {
                    idhoadonSelected = i.id_hoadon;
                    txt_idHoadon.Text = i.id_hoadon.ToString();
                }
                phucvubll.LoadChiTietHoaDon(idhoadonSelected, gridControl_ChitietHoaDon);
        }
        private void btnNhanBan_Click(object sender, EventArgs e)
        {
            if(txt_idHoadon.Text == "")
            {
                HoaDonThanhToan hd = new HoaDonThanhToan();
                hd.id_ban = idbanSelected;
                hd.id_nhanvien = ID_NHANVIEN;
                hd.thoigian = today;
                hd.trangthai = tthoadon[0];
                hd.id_khachhang = 5;
                phucvubll.ThemMoiHoaDon(hd);
                MessageBox.Show("Đã nhận bàn");
                ReLoadHoaDon();
                //làm tiếp: nhận bàn đã đặt. chuyển chitiet đặt bàn -> chi tiết hóa đơn.
                if(trangthaibanSelected == ttban[2])
                {
                    phucvubll.ChuyenChiTietDatBan(idbanSelected, today, idhoadonSelected);
                    phucvubll.LoadChiTietHoaDon(idhoadonSelected, gridControl_ChitietHoaDon);
                    phucvubll.SetTrangThaiPhieuDatBan(idbanSelected, today, ttdatban[1]); //đã nhận đơn đặt.
                }
                CapNhatTrangThaiBan();
                LoadDsBan();
            }
            else
            {
                MessageBox.Show("Bàn đã có khách. Xin chọn bàn khác");
            }
        }

        public void SetEnableControl(bool b)
        {
            btnNhanBan.Enabled = b;
            btnThanhToan.Enabled = b;
            gridControl_ChitietHoaDon.Enabled = b;
            gridControl_ThucDon.Enabled = b;
        }
        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            //Chọn bàn (đk:bàn đã có khách -> bàn trống) -> tắt thao tác
            ischuyenban = true;
            idhoadonMoved = idhoadonSelected;
            SetEnableControl(false);
            MessageBox.Show("Chọn bàn trống để chuyển đến.");

        }

        private void gridView_ChitietHoaDon_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                int soluong = int.Parse(gridView_ChitietHoaDon.GetFocusedRowCellValue("soluong").ToString());
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return;
                }
                double dongia = double.Parse(gridView_ChitietHoaDon.GetFocusedRowCellValue("Mon.gia").ToString());
                double thanhtien = soluong * dongia;
                gridView_ChitietHoaDon.SetFocusedRowCellValue("thanhtien", thanhtien);
                phucvubll.UpdateDatabase();
                MessageBox.Show("Đã thay đổi");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Frm_ThanhToan frmThanhtoan = new Frm_ThanhToan(ID_NHANVIEN);
            frmThanhtoan.MdiParent = FormMain.ActiveForm;
            frmThanhtoan.Show();
        }
        
        
    }
}