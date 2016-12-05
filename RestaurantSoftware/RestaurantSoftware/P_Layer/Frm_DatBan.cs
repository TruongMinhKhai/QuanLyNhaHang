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
            dtNgayDat.DateTime = DateTime.Now;

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
            DataTable ban = Utils.Utils.ConvertToDataTable<Ban>(datban_bll.LayDanhSachBanDat(dtNgayDat.DateTime));

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
            cbxKhachHang.Properties.DataSource = dt;
            cbxKhachHang.Properties.DisplayMember = "tenkh";
            cbxKhachHang.Properties.ValueMember = "id_khachhang";
        }

        private void dtNgayDat_EditValueChanged(object sender, EventArgs e)
        {
            LoadDsBanDat();
        }
    }
}