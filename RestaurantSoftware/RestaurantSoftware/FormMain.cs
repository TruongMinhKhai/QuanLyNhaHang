using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;

namespace RestaurantSoftware
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int idnv = 0;
        string tennv ="";
        int? capdo = 0;
        string chucvu = "";
        RestaurantSoftware.DA_Layer.RestaurantDBDataContext dbContext = new DA_Layer.RestaurantDBDataContext();
        public FormMain()
        {
            InitializeComponent();
            InitSkinGallery();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(ribbonGallery, true);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            P_Layer.Frm_DangNhap dangnhap = new P_Layer.Frm_DangNhap();
            dangnhap.LoginEvent += dangnhap_LoginEvent;
            dangnhap.ShowDialog();
        }

        void dangnhap_LoginEvent(string username, string pass)
        {
            var query = from a in dbContext.NhanViens
                        where a.tendangnhap == username && a.matkhau == pass
                        select a;
            foreach(var i in query)
            {
                idnv = i.id_nhanvien;
                tennv = i.tennhanvien;
                capdo = i.PhanQuyen.capdo;
                chucvu = i.PhanQuyen.tenquyen;
            }
            tenNguoiDung.Caption += ": " + tennv;
            chucVu.Caption += " " + chucvu;
            PhanQuyen();
        }

        void PhanQuyen()
        {
            if(capdo == 1) //thu ngan
            {
                nghiepvu.Visible = true;
                hethong.Visible = false;
                baocaothongke.Visible = false;
                quanlyhethong.Visible = false;
            }
            if (capdo == 2) //admin
            {
                nghiepvu.Visible = true;
                hethong.Visible = true;
                baocaothongke.Visible = true;
                quanlyhethong.Visible = true;
            }
        }
        private void btn_Ban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_Ban));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_Ban Ban = new P_Layer.Frm_Ban();
                Ban.MdiParent = this;
                Ban.Show();
            }
            
           
        }

        private void btn_KhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btn_Mon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_Mon));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_Mon Mon = new P_Layer.Frm_Mon();
                Mon.MdiParent = this;
                Mon.Show();
            }
        }

        private void btn_LoaiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_LoaiMon));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_LoaiMon LoaiMon = new P_Layer.Frm_LoaiMon();
                LoaiMon.MdiParent = this;
                LoaiMon.Show();
            }
        }

        private void btn_KhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_KhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_KhachHang KhachHang = new P_Layer.Frm_KhachHang();
                KhachHang.MdiParent = this;
                KhachHang.Show();
            }
        }

        private void btn_NguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_NguoiDung));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_NguoiDung NhanVien = new P_Layer.Frm_NguoiDung();
                NhanVien.MdiParent = this;
                NhanVien.Show();
            }
        }

        private void btn_QuyDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_QuyDinh));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_QuyDinh QuyDinh = new P_Layer.Frm_QuyDinh();
                QuyDinh.MdiParent = this;
                QuyDinh.Show();
            }
        }

        private void btn_PhieuNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_NguyenLieu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_NguyenLieu DSPhieuNhap = new P_Layer.Frm_NguyenLieu();
                DSPhieuNhap.MdiParent = this;
                DSPhieuNhap.Show();
            }
        }

        private void btn_NhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_NhaCungCap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_NhaCungCap NhaCungCap = new P_Layer.Frm_NhaCungCap();
                NhaCungCap.MdiParent = this;
                NhaCungCap.Show();
            }
        }

        private void btn_PhucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_PhucVu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_PhucVu PhucVu = new P_Layer.Frm_PhucVu(idnv);
                PhucVu.MdiParent = this;
                PhucVu.Show();
            }
        }

        private void btn_DatBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_DatBan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_DatBan DatBan = new P_Layer.Frm_DatBan(idnv);
                DatBan.MdiParent = this;
                DatBan.Show();
            }
        }

        private void btn_ThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_ThanhToan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_ThanhToan ThanhToan = new P_Layer.Frm_ThanhToan();
                ThanhToan.MdiParent = this;
                ThanhToan.Show();
            }
        }

        private void btn_NhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_QuanLyNhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_QuanLyNhapHang QuanLyNhapHang = new P_Layer.Frm_QuanLyNhapHang();
                QuanLyNhapHang.MdiParent = this;
                QuanLyNhapHang.Show();
            }
        }

        private void btn_SuCo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_SuCo));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_SuCo SuCo = new P_Layer.Frm_SuCo();
                SuCo.MdiParent = this;
                SuCo.Show();
            }
        }

        private void btn_LoaiSuCo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_LoaiSuCo));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_LoaiSuCo LoaiSuCo = new P_Layer.Frm_LoaiSuCo();
                LoaiSuCo.MdiParent = this;
                LoaiSuCo.Show();
            }
        }

        private void btn_LoaiQuyDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_LoaiQuyDinh));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_LoaiQuyDinh LoaiQuyDinh = new P_Layer.Frm_LoaiQuyDinh();
                LoaiQuyDinh.MdiParent = this;
                LoaiQuyDinh.Show();
            }
           
        }

        private Form ExistForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }

            return null;
        }

        private void btn_Backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btn_ThongKeMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_ThongKeMon));
            
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_ThongKeMon tkmon = new P_Layer.Frm_ThongKeMon();
                tkmon.MdiParent = this;
                tkmon.Show();
            }
        }

        private void btn_DonVi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_DonVi));

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_DonVi donvi = new P_Layer.Frm_DonVi();
                donvi.MdiParent = this;
                donvi.Show();
            }
        }

        private void btn_DoanhThuThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_DoanhThuTheoThang));

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_DoanhThuTheoThang dtThang = new P_Layer.Frm_DoanhThuTheoThang();
                dtThang.MdiParent = this;
                dtThang.Show();
            }
        }

        private void btn_DoanhThuNam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.ExistForm(typeof(P_Layer.Frm_DoanhThuTheoNam));

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                P_Layer.Frm_DoanhThuTheoNam dtnam = new P_Layer.Frm_DoanhThuTheoNam();
                dtnam.MdiParent = this;
                dtnam.Show();
            }
        }
    }
}
