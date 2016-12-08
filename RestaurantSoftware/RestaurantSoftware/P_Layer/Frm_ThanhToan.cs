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
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private Ban_BLL _banBll = new Ban_BLL();
        private HoaDon_BLL _hoadonBll = new HoaDon_BLL();
        private ThanhToan_BLL _thanhToanBll = new ThanhToan_BLL();
        private List<int> _listUpdate = new List<int>();


        public Frm_ThanhToan()
        {
            InitializeComponent();
            dt_NgayLap.Text = DateTime.Now.ToShortDateString();
            // This line of code is generated by Data Source Configuration Wizard
            cmb_NhanVien.Properties.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().NhanViens;
        }


        private void Frm_ThanhToan_Load(object sender, EventArgs e)
        {
            LoadDataSource();

        }
        private void LoadDataSource()
        {
            LoadDsBan();
            _thanhToanBll.LoadHoaDon(grv_HoaDon);
        }
        public void LoadDsBan()
        {
            lvDsBan.Clear();
            DataTable ban = Utils.Utils.ConvertToDataTable<ChiTiet_ThanhToan>(_thanhToanBll.LayDanhSachBan("Chưa thanh toán"));

            lvDsBan.LargeImageList = imageList1;

            foreach (DataRow dr in ban.Rows)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr["tenban"].ToString();
                switch (dr["trangthai"].ToString())
                {
                    case "Trống":
                        lvItem.ImageIndex = 2;
                        break;
                    case "Đã đặt":
                        lvItem.ImageIndex = 1;
                        break;
                    case "Đang sử dụng":
                        lvItem.ImageIndex = 0;
                        break;
                }
                lvItem.Name = dr["Idban"].ToString();
                lvGroup.Header = dr["Tenloaiban"].ToString();
                lvItem.Group = lvGroup;

                if (lvDsBan.Groups.Count != 0)
                {
                    foreach (ListViewGroup gr in lvDsBan.Groups)
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
                        lvDsBan.Groups.Add(lvGroup);
                    }

                }
                else lvDsBan.Groups.Add(lvGroup);
                lvDsBan.Items.Add(lvItem);

            }
        }

        private void lvDsBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDsBan.SelectedItems.Count > 0)
            {
                txt_TenKH.Text = "";
                txt_SDT.Text = "";
                txt_KhachDua.Text = "";
                txt_TraLai.Text = "";

                txt_Ban.Text = lvDsBan.SelectedItems[0].Text;
                _thanhToanBll.loadid(int.Parse(lvDsBan.SelectedItems[0].Name), "Chưa thanh toán", txt_MaHoaDon, cmb_NhanVien, dt_NgayLap,txt_TenKH,txt_SDT);
                _thanhToanBll.LayDsThamSo(txt_VAT, txt_KhuyenMai);
                LoadChiTietHoaDon();
                btn_ThanhToan.Enabled = true;

            }
        }
        public void LoadChiTietHoaDon()
        {
            try
            {
                int a = int.Parse(txt_MaHoaDon.Text);
                _thanhToanBll.LoadChiTietHoaDon(a, grd_DanhSachMon);
                TongTien();
                TongHoaDon();
                chuyenvetiente(txt_TongTien);
                chuyenvetiente(txt_TongHoaDon);


            }
            catch (Exception)
            {
                Notifications.Answers("Lỗi load chi tiết");

            }

        }
        public void KiemtraTextBox()
        {
            if (txt_TongTien.Text == "")
            {
                txt_TongTien.Text = "0";
            }
            if (txt_KhuyenMai.Text == "")
            {
                txt_KhuyenMai.Text = "0";
            }
            if (txt_VAT.Text == "")
            {
                txt_VAT.Text = "0";
            }
            if (txt_TongHoaDon.Text == "")
            {
                txt_TongHoaDon.Text = "0";
            }

        }

        private void gv_HoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txt_TenKH.Text = "";
            txt_SDT.Text = "";
            txt_KhachDua.Text = "";
            txt_TraLai.Text = "";
            txt_TenKH.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_khachHang);
            txt_MaHoaDon.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_MaHoaDon);
            txt_SDT.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_sdt);
            dt_NgayLap.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_ThoiGian);
            txt_VAT.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_Vat);
            txt_KhuyenMai.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_KhuyenMai);
            KiemtraTextBox();
            //_thanhToanBll.load(int.Parse(gv_HoaDon.GetFocusedRowCellDisplayText(col_MaBan)), txt_MaHoaDon, cmb_NhanVien, dt_NgayLap, txt_TenKH, txt_SDT);
            LoadChiTietHoaDon();
            if (gv_HoaDon.GetFocusedRowCellDisplayText(col_TrangThai) == "Đã thanh toán")
            {
                btn_ThanhToan.Enabled = false;
            }
            else
                if (gv_HoaDon.GetFocusedRowCellDisplayText(col_TrangThai) == "Chưa thanh toán")
                {
                    btn_ThanhToan.Enabled = true;
                }
        }

        public void TinhToan()
        {
            TongTien();
            TongHoaDon();
            if (txt_KhachDua.Text != "")
            {
                int a = int.Parse(txt_KhachDua.Text) - int.Parse(txt_TongHoaDon.Text);
                txt_TraLai.Text = a.ToString();
            }
            //chuyenvetiente(txt_KhachDua);
            chuyenvetiente(txt_TraLai);
            chuyenvetiente(txt_TongTien);
            chuyenvetiente(txt_TongHoaDon);
        }
        public void chuyenvetiente(TextEdit txt)
        {
            try
            {
                if (txt.Text == "0")
                {
                    int c = int.Parse(txt.Text);
                    txt.Text = c.ToString("0 VNĐ");
                }
                else
                {
                    int c = int.Parse(txt.Text);
                    txt.Text = c.ToString("#,### VNĐ");
                }
            }
            catch (Exception)
            {
                
               
            }
            
            
        }
        public void TongTien()
        {
            try
            {
                var a = gv_DanhSachMon.Columns["thanhtien"].SummaryItem.SummaryValue;
                txt_TongTien.EditValue = a;   

            }
            catch (Exception)
            {

                Notifications.Answers("Lỗi tổng tiền");
            }
           
        }

        private void checkBoxKhuyenmai_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKhuyenmai.Checked == true)
            {
                txt_KhuyenMai.Properties.ReadOnly = false;

            }
            else
            {
                txt_KhuyenMai.Properties.ReadOnly = true;
                txt_KhuyenMai.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_KhuyenMai);
            }
        }

        private void checkBoxVat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVat.Checked == true)
            {
                txt_VAT.Properties.ReadOnly = false;
            }
            else
            {
                txt_VAT.Properties.ReadOnly = true;
                txt_VAT.Text = gv_HoaDon.GetFocusedRowCellDisplayText(col_Vat);
            }
        }
        public void TongHoaDon()
        {
            try
            {
                KiemtraTextBox();                         
                int a = int.Parse(txt_TongTien.Text);
                int b = ((int.Parse(txt_TongTien.Text)) * (int.Parse(txt_VAT.Text))) / 100;
                int c = ((int.Parse(txt_TongTien.Text)) * (int.Parse(txt_KhuyenMai.Text))) / 100;
                txt_TongHoaDon.Text = (a + b - c).ToString();
                
                
            }
            catch (Exception)
            {


            }

        }

        private void txt_KhuyenMai_EditValueChanged(object sender, EventArgs e)
        {
            if(checkBoxKhuyenmai.Checked ==true)
            {
                TinhToan();
            }
           

        }

        private void txt_VAT_EditValueChanged(object sender, EventArgs e)
        {
            if (checkBoxVat.Checked==true)
            {
                TinhToan();
            }
           

        }

        private void txt_KhachDua_EditValueChanged(object sender, EventArgs e)
        {
            TinhToan();
        }

        private void txt_KhachDua_Leave(object sender, EventArgs e)
        {
            chuyenvetiente(txt_KhachDua);
            chuyenvetiente(txt_TraLai);
            chuyenvetiente(txt_TongTien);
            chuyenvetiente(txt_TongHoaDon);
        }

        private void txt_KhachDua_Click(object sender, EventArgs e)
        {
            txt_KhachDua.Text = "";
            txt_TraLai.Text = "";
        }


    }
}