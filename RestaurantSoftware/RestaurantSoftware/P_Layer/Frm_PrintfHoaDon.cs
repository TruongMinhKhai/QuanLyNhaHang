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
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer.Reports;


namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_PrintfHoaDon : DevExpress.XtraEditors.XtraForm
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        int idhoadon = 0;
        public Frm_PrintfHoaDon(int idhoadonSelect)
        {
            InitializeComponent();
            idhoadon = idhoadonSelect;
        }

        private void Frm_PrintfHoaDon_Load(object sender, EventArgs e)
        {
            var query = from ct in dbContext.Chitiet_HoaDonThanhToans
                        where ct.id_hoadon == idhoadon
                        select ct;
            HoaDon hd = new HoaDon();
            hd.DataSource = query;
            documentViewer2.PrintingSystem = hd.PrintingSystem;
            hd.CreateDocument();
        }
    }
}