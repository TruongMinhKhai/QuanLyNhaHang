using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class LoaiMon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<LoaiMon> LayDanhSachLoaiMon()
        {
            IEnumerable<LoaiMon> query = from lm in dbContext.LoaiMons select lm;
            return query;
        }

        public void ThemLoaiMon(LoaiMon loaimon)
        {
            dbContext.LoaiMons.InsertOnSubmit(loaimon);
            dbContext.SubmitChanges();
        }

        public bool KiemTraLoaiMonTonTai(string _LoaiMon, int id = -1)
        {
            IEnumerable<LoaiMon> query = from lm in dbContext.LoaiMons
                                     where lm.tenloaimon == _LoaiMon
                                     select lm;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(lm => lm.id_loaimon == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void CapNhatLoaiMon(LoaiMon lm)
        {
            LoaiMon _loaimon = dbContext.LoaiMons.Single<LoaiMon>(x => x.id_loaimon == lm.id_loaimon);
            _loaimon.tenloaimon = lm.tenloaimon;
            // update 
            dbContext.SubmitChanges();
        }

        public void XoaLoaiMon(int _LoaiMonID)
        {
            LoaiMon _loaimon = dbContext.LoaiMons.Single<LoaiMon>(x => x.id_loaimon == _LoaiMonID);
            dbContext.LoaiMons.DeleteOnSubmit(_loaimon);
            dbContext.SubmitChanges();
        }
    }
}
