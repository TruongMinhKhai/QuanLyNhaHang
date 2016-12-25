using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class KhachHang_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<KhachHang> LayDanhSachKhachHang()
        {
            IEnumerable<KhachHang> query = from kh in dbContext.KhachHangs where kh.trangthai != false select kh;
            return query;
        }

        public void ThemKhachHang(KhachHang khachhang)
        {

            dbContext.KhachHangs.InsertOnSubmit(khachhang);
            dbContext.SubmitChanges();
        }

        public void CapNhatKhachHang(KhachHang kh)
        {
            KhachHang _khachhang = dbContext.KhachHangs.Single<KhachHang>(x => x.id_khachhang == kh.id_khachhang);
            _khachhang.tenkh = kh.tenkh;
            _khachhang.sdt = kh.sdt;
            _khachhang.diachi = kh.diachi;
            // update 
            dbContext.SubmitChanges();
        }

        public void XoaTam(int id_khachhang)
        {
            KhachHang _khachhang = dbContext.KhachHangs.Single<KhachHang>(x => x.id_khachhang == id_khachhang);
            _khachhang.trangthai = false;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaKhachHang(int _KhachHagID)
        {
            KhachHang _khachhang = dbContext.KhachHangs.Single<KhachHang>(x => x.id_khachhang == _KhachHagID);
            dbContext.KhachHangs.DeleteOnSubmit(_khachhang);
            dbContext.SubmitChanges();
        }

        public bool KiemTraSDTTonTai(string sdt, int id = -1)
        {
            IEnumerable<KhachHang> query = from kh in dbContext.KhachHangs
                                     where kh.sdt == sdt && kh.trangthai != false
                                     select kh;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(kh=> kh.id_khachhang == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool KiemTraThongTin(int id_khachhang)
        {
            IEnumerable<DatBan> _KiemTraDatBan = from db in dbContext.DatBans
                                                 where db.id_khachhang == id_khachhang
                                                 select db;
            IEnumerable<HoaDonThanhToan> _KiemTraHoaDon = from hd in dbContext.HoaDonThanhToans
                                                          where hd.id_khachhang == id_khachhang
                                                          select hd;
            IEnumerable<SuCo> _KiemTraSuCo = from sc in dbContext.SuCos
                                                          where sc.id_khachhang == id_khachhang
                                                          select sc;
            if (_KiemTraDatBan.Count() > 0 || _KiemTraHoaDon.Count() > 0 || _KiemTraSuCo.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
