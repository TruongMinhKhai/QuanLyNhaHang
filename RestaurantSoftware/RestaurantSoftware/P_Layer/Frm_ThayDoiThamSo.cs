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
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_ThayDoiThamSo : DevExpress.XtraEditors.XtraForm
    {
        ThamSo_BLL thamso_bll = new ThamSo_BLL();
        int vat = 0;
        int km = 0;
        int datcoc = 0;
        public Frm_ThayDoiThamSo()
        {
            InitializeComponent();
            LoaDsThamSo();

        }
        public void LoaDsThamSo()
        {
            thamso_bll.LayDanhSachThamSo(txt_Vat, txt_KhuyenMai, txt_DatCoc);
            vat = int.Parse(txt_Vat.Text);
            km = int.Parse(txt_KhuyenMai.Text);
            datcoc = int.Parse(txt_DatCoc.Text);
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (vat != int.Parse(txt_Vat.Text))
            {
                ThamSo ts = new ThamSo();
                ts.giatri = int.Parse(txt_Vat.Text);
                ts.id_thamso = 1;
                thamso_bll.CapNhatthamso(ts);
                
            }
            if (km != int.Parse(txt_KhuyenMai.Text))
            {
                ThamSo a = new ThamSo();
                a.id_thamso = 2;
                a.giatri = int.Parse(txt_KhuyenMai.Text);
                thamso_bll.CapNhatthamso(a);

            }
            if (datcoc != int.Parse(txt_DatCoc.Text))
            {
                ThamSo b = new ThamSo();
                b.id_thamso = 3; 
                b.giatri = int.Parse(txt_DatCoc.Text);
                thamso_bll.CapNhatthamso(b);

            }
            Notifications.Answers("Cập nhật tham số thành công!");
            LoaDsThamSo();
        }

    }
}