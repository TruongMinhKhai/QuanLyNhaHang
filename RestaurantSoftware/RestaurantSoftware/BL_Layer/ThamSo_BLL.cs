using DevExpress.XtraEditors;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class ThamSo_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public void LayDanhSachThamSo(TextEdit vat, TextEdit km, TextEdit datcoc)
        {
            try
            {
                var query = (from db in dbContext.ThamSos
                             select new
                             {
                                 db.tenthamso,
                                 db.giatri

                             }).ToList();
                foreach (var id in query)
                {
                    if (id.tenthamso=="vat")
                    {
                        vat.Text = id.giatri.ToString();
                    }
                    else
                        if (id.tenthamso == "khuyenmai")
                        {
                            km.Text = id.giatri.ToString();
                        }
                    else
                            if (id.tenthamso == "datcoc")
                            {
                                datcoc.Text = id.giatri.ToString();
                            }
                    
                }

            }
            catch (Exception)
            {

                Notifications.Answers("Chưa có tham số");
            }
        }
        public void CapNhatthamso(ThamSo ts)
        {
            ThamSo _ts = dbContext.ThamSos.Single<ThamSo>(x => x.id_thamso == ts.id_thamso);
            _ts.giatri = ts.giatri;

            // update 
            dbContext.SubmitChanges();
        }

    }
}
