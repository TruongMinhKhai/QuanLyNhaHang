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
    public partial class Frm_InQuyDinh : DevExpress.XtraEditors.XtraForm

    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        int idquydinh = 0;
        public Frm_InQuyDinh(int idquydinhselec)
        {
            InitializeComponent();
            idquydinh = idquydinhselec;

        }

        private void Frm_InQuyDinh_Load(object sender, EventArgs e)
        {
            var query = from ct in dbContext.QuyDinhs
                        where ct.id_quydinh == idquydinh
                        select ct;
            InQuyDinh hd = new InQuyDinh();
            hd.DataSource = query;
            documentViewer1.PrintingSystem = hd.PrintingSystem;
            hd.CreateDocument();
        }
        
       
    }
}