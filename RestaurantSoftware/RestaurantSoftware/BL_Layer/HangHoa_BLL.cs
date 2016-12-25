using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class HangHoa_BLL
    {
        RestaurantDBDataContext dbContext = null;
        NhapHang_BLL _nhaphangBll = null;
        // hàm khởi tạo hàng hóa
        public HangHoa_BLL()
        {
            dbContext = new RestaurantDBDataContext();
            _nhaphangBll = new NhapHang_BLL();
        }

        // hàm lấy danh sách hàng hóa
        public IEnumerable<HangHoa> LayDanhSachHangHoa()
        {
            IEnumerable<HangHoa> query = from hh in dbContext.HangHoas 
                                         where hh.trangthai != "Xoa"
                                         select hh;
            return query;
        }

        // hàm lấy danh sách hàng hóa theo id đơn vị
        public IEnumerable<HangHoa> LayDanhSachHangHoaTheoIdDonVi(int _DonViID)
        {
            IEnumerable<HangHoa> query = from m in dbContext.HangHoas
                                         where m.id_donvi == _DonViID
                                         select m;
            return query;
        }
        // hàm thêm hàng hóa
        public void ThemHangHoaMoi(HangHoa hh)
        {
            dbContext.HangHoas.InsertOnSubmit(hh);
            dbContext.SubmitChanges();
        }
        // hàm cập nhật hàng hoá
        public void CapNhatHangHoa(HangHoa hh)
        {
            HangHoa _hanghoa = dbContext.HangHoas.Single<HangHoa>(x => x.id_hanghoa == hh.id_hanghoa);
            _hanghoa.tenhanghoa = hh.tenhanghoa;
            _hanghoa.soluong = hh.soluong;
            _hanghoa.dongia = hh.dongia;
            dbContext.SubmitChanges();
        }
        // hàm kiểm tra hàng hóa có tồn tại hay không
        public bool KiemTraHangHoaTonTai(string _TenHangHoa, int id=-1)
        {
            IEnumerable<HangHoa> query = from hh in dbContext.HangHoas
                                         where hh.tenhanghoa == _TenHangHoa
                                         select hh;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.id_hanghoa == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        // hàm xóa hàng hóa
        public bool KiemTraThongTin(int _HangHoaID)
        {
            IEnumerable<Chitiet_HoaDonNhapHang> _KiemTraHangHoa = from db in dbContext.Chitiet_HoaDonNhapHangs
                                                         where db.id_hanghoa == _HangHoaID
                                                         select db;
            if (_KiemTraHangHoa.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public void XoaTam(int _HangHoaID)
        {
            HangHoa _hanghoa = dbContext.HangHoas.Single<HangHoa>(x=>x.id_hanghoa == _HangHoaID);
            _hanghoa.trangthai = "Xoa";
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaHangHoa(int _HangHoaID)
        {
            HangHoa _hanghoa = dbContext.HangHoas.Single<HangHoa>(x=>x.id_hanghoa == _HangHoaID);
            dbContext.HangHoas.DeleteOnSubmit(_hanghoa);
            dbContext.SubmitChanges();
        }
        // hàm lấy danh sách hàng hóa tồn
        public IEnumerable<HangHoaTon> LayDanhSachHangHoaTon()
        {
            IEnumerable<HangHoaTon> query = from cthh in dbContext.Chitiet_HoaDonNhapHangs
                                            join hh in dbContext.HangHoas
                                            on cthh.id_hanghoa equals hh.id_hanghoa
                                            select new HangHoaTon
                                            {
                                                Tenhanghoa = hh.tenhanghoa,
                                                Tondau = (int)hh.soluong,
                                                Soluongnhap = (int)cthh.soluong,
                                                Toncuoi = (int)(hh.soluong + cthh.soluong)
                                            };
            return query;
        }
    }
}
