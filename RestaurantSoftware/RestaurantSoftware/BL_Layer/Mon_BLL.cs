using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    public class Mon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<Mon> LayDanhSachMon()
        {
            IEnumerable<Mon> query = from m in dbContext.Mons select m;
            return query;
        }

        public void ThemMonMoi(Mon mon)
        {

            dbContext.Mons.InsertOnSubmit(mon);
            dbContext.SubmitChanges();
        }

        public void CapNhatMon(Mon m)
        {
            Mon _mon = dbContext.Mons.Single<Mon>(x => x.id_mon == m.id_mon);
            _mon.tenmon = m.tenmon;
            _mon.LoaiMon= dbContext.LoaiMons.Single<LoaiMon>(l => l.id_loaimon == m.id_loaimon);
            _mon.gia = m.gia;
            _mon.tenviettat = m.tenviettat;
            _mon.trangthai = m.trangthai;
            // update 
            dbContext.SubmitChanges();
        }
        public bool KiemTraTenMonTonTai(string _tenMon, int id = -1)
        {
            IEnumerable<Mon> query = from m in dbContext.Mons
                                     where m.tenmon == _tenMon
                                     select m;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.id_mon == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public int LayIdMon(string TenMon)
        {
            IEnumerable<Mon> query = from m in dbContext.Mons where m.tenmon == TenMon select m;
            return query.First().id_mon;
        }

        public void XoaMon(int _MonID)
        {
            Mon _Mon = dbContext.Mons.Single<Mon>(x => x.id_mon == _MonID);
            dbContext.Mons.DeleteOnSubmit(_Mon);
            dbContext.SubmitChanges();
        }

        public void XoaMons(int _id_LoaiMon)
        {
            IEnumerable<Mon> _mons = ((from m in dbContext.Mons select m).Where(lm => lm.id_loaimon == _id_LoaiMon)).ToList();
                //(from m in dbContext.Mons where m.id_loaimon == _id_LoaiMon select m).ToList();
            dbContext.Mons.DeleteAllOnSubmit(_mons);
            dbContext.SubmitChanges();
        }
    }
}
