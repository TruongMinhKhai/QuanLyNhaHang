using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class LoaiHang_BLL
    {
        RestaurantDBDataContext dbContext = null;
        // hàm khởi tạo loại hàng hoá
        public LoaiHang_BLL() {
            dbContext = new RestaurantDBDataContext();
        }
        // hàm lấy danh sách loại hàng
        public IEnumerable<LoaiHangHoa> LayDanhSachLoaiHangHoa(){
            IEnumerable<LoaiHangHoa> query = from lhh in dbContext.LoaiHangHoas select lhh;
            return query;
        }
        // hàm thêm loại hàng hoá
        public void ThemLoaiHangHoa(LoaiHangHoa lhh){
            dbContext.LoaiHangHoas.InsertOnSubmit(lhh);
            dbContext.SubmitChanges();
        }
        // hàm cập nhật loại hàng hoá
        public void CapNhatNhaCungCap(LoaiHangHoa lhh){
            LoaiHangHoa _loaihanghoa = dbContext.LoaiHangHoas.Single<LoaiHangHoa>(x=> x.id_loaihang == lhh.id_loaihang);
            _loaihanghoa.tenloaihang = lhh.tenloaihang;
            dbContext.SubmitChanges();
        }
        // hàm kiểm tra loại hàng hoá có tồn tại hay không
        public bool KiemTraLoaiHangHoaTonTai(int _MaLoaiHang, string _TenLoaiHang) {
            IEnumerable<LoaiHangHoa> query = from hh in dbContext.LoaiHangHoas
                                         where hh.tenloaihang == _TenLoaiHang || hh.id_loaihang== _MaLoaiHang
                                         select hh;
            return true;
        }
    }
}
