using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer.Reports;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_InPhieuDatBan : Form
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        int idDatban = 0;
        public Frm_InPhieuDatBan(int idDatBanSelected)
        {
            InitializeComponent();
            idDatban = idDatBanSelected;
        }

        private void Frm_InPhieuDatBan_Load(object sender, EventArgs e)
        {
            var query = from ct in dbContext.Chitiet_DatBans
                        where ct.id_datban == idDatban
                        select ct;
            PhieuDatBan report = new PhieuDatBan();
            report.DataSource = query;
            documentViewer2.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }

    }
}
