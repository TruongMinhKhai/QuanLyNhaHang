using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class LoaiMon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        Mon_BLL _monBll = new Mon_BLL();
        public IEnumerable<LoaiMon> LayDanhSachLoaiMon()
        {
            IEnumerable<LoaiMon> query = from lm in dbContext.LoaiMons where lm.trangthai != false select lm;
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

        public bool KiemTraThongTin(int id_loaimon)
        {
            int id_mon = _monBll.getIDMon(id_loaimon);
            if(id_mon > 0)
            {
                if (_monBll.KiemTraThongTin(id_mon))
                    return true;
                return false;
            }
            return false;
        }

        public void XoaTam(int id_loaimon)
        {
            LoaiMon _loaimon = dbContext.LoaiMons.Single<LoaiMon>(x => x.id_loaimon == id_loaimon);
            _loaimon.trangthai = false;
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
