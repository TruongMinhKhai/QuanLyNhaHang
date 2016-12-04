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
            IEnumerable<KhachHang> query = from kh in dbContext.KhachHangs select kh;
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

        public void XoaKhachHang(int _KhachHagID)
        {
            KhachHang _khachhang = dbContext.KhachHangs.Single<KhachHang>(x => x.id_khachhang == _KhachHagID);
            dbContext.KhachHangs.DeleteOnSubmit(_khachhang);
            dbContext.SubmitChanges();
        }

        public bool KiemTraSDTTonTai(string sdt, int id = -1)
        {
            IEnumerable<KhachHang> query = from kh in dbContext.KhachHangs
                                     where kh.sdt == sdt
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
    }
}
