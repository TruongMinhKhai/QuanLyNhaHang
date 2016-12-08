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
    public partial class Frm_DatBan : DevExpress.XtraEditors.XtraForm
    {
        DatBan_BLL datban_bll = new DatBan_BLL();
        bool checkClickRow = false;

        public Frm_DatBan()
        {
            InitializeComponent();
            dt_NgayDat.DateTime = DateTime.Now;

        }
        private void Frm_DatBan_Load(object sender, EventArgs e)
        {
            LoadDsBan();
            LoadDsMon();
            LoadDsDatBan();
            LoadDsKhachHang();
        }

        public void LoadDsBan()
        {
            lvDsBan.Clear();
            DataTable ban = Utils.Utils.ConvertToDataTable<Ban>(datban_bll.LayDanhSachBan());

            lvDsBan.LargeImageList = imageList1;

            foreach (DataRow dr in ban.Rows)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr["tenban"].ToString();
                lvItem.ImageIndex = 2;
                lvItem.Name = dr["id_ban"].ToString();
                lvGroup.Header = ((LoaiBan)dr[6]).tenloaiban;
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
        public void LoadDsBanDat()
        {
            lvDsBan.Clear();
            DataTable ban = Utils.Utils.ConvertToDataTable<Ban>(datban_bll.LayDanhSachBanDat(dt_NgayDat.DateTime));

            lvDsBan.LargeImageList = imageList1;

            foreach (DataRow dr in ban.Rows)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr["tenban"].ToString();
                lvItem.ImageIndex = 2;
                lvItem.Name = dr["id_ban"].ToString();
                lvGroup.Header = ((LoaiBan)dr[6]).tenloaiban;
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

        public void LoadDsDatBan()
        {
            datban_bll.LayDsDatBan(gridControl_DsDatBan);
        }

        public void LoadDsMon()
        {

            datban_bll.LayDanhSachMon(gridControl_DsMon); ;

        }
        public void LoadDsKhachHang()
        {
            DataTable dt = Utils.Utils.ConvertToDataTable<KhachHang>(datban_bll.LayDsKhachHang());
            txt_TenKH.Properties.DataSource = dt;
            txt_TenKH.Properties.DisplayMember = "tenkh";
            txt_TenKH.Properties.ValueMember = "id_khachhang";
        }

        private void dtNgayDat_EditValueChanged(object sender, EventArgs e)
        {
            LoadDsBanDat();
        }

        private void lvDsBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDsBan.SelectedItems.Count > 0)
            {
                txt_TenBan.Text = lvDsBan.SelectedItems[0].Text;
            }
        }

        private void cbxKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            txt_SDT.Text = row["sdt"].ToString();
            txt_DiaChi.Text = row["diachi"].ToString();
        }

        private void gridView_DsDatBan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView_DsDatBan.GetFocusedRowCellDisplayText(col_TrangThai) == "Đã nhận bàn")
            {
                txt_TenKH.Text = "";
                txt_SDT.Text = "";
                datban_bll.load(int.Parse(gridView_DsDatBan.GetFocusedRowCellDisplayText(col_MaDatBan)), cmb_NhanVien, dt_NgayDat, txt_TenKH, txt_SDT, txt_TenBan);
                datban_bll.LoadChiTietDatBan(int.Parse(gridView_DsDatBan.GetFocusedRowCellDisplayText(col_MaDatBan)), gridControl_ChiTietDatBan);
            }
            else
                if (gridView_DsDatBan.GetFocusedRowCellDisplayText(col_TrangThai) == "Chưa nhận bàn")
                {
                    txt_TenKH.Text = "";
                    txt_SDT.Text = "";
                    //txt_Ban.Text = gridView_DsDatBan.GetFocusedRowCellDisplayText(col_TenBan);
                    datban_bll.loadid(int.Parse(gridView_DsDatBan.GetFocusedRowCellDisplayText(col_MaDatBan)), "Chưa nhận bàn", cmb_NhanVien, dt_NgayDat, txt_TenKH, txt_SDT, txt_TenBan);
                    datban_bll.LoadChiTietDatBan(int.Parse(gridView_DsDatBan.GetFocusedRowCellDisplayText(col_MaDatBan)), gridControl_ChiTietDatBan);

                }
        }
    }
}