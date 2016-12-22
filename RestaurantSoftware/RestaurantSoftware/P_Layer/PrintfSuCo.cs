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
    public partial class PrintfSuCo : DevExpress.XtraEditors.XtraForm
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        int idsuco = 0;
        public PrintfSuCo(int idsucoselec)
        {
            InitializeComponent();
            idsuco = idsucoselec;
        }

        private void PrintfSuCo_Load(object sender, EventArgs e)
        {
            var query = from ct in dbContext.SuCos
                        where ct.id_suco == idsuco
                        select ct;
            InSuCo hd = new InSuCo();
            hd.DataSource = query;
            documentViewer2.PrintingSystem = hd.PrintingSystem;
            hd.CreateDocument();
        }
    }
}