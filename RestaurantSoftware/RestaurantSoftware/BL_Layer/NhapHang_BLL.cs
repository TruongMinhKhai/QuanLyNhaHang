using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class NhapHang_BLL
    {
        RestaurantDBDataContext dbContext = null;
        // hàm khởi tạo lớp nhập hàng
        public NhapHang_BLL()
        {
            dbContext = new RestaurantDBDataContext();
        }
        // Lấy danh sách hàng hoá có chọn lọc
        public void LayThongTinHangHoa(GridControl gridcontrol)
        {
            var query = (from hh in dbContext.GetTable<HangHoa>()
                         from lhh in dbContext.GetTable<LoaiHangHoa>()
                         //where (hh.id_hanghoa == lhh.id_loaihang)
                         select new
                         {
                             hh.tenhanghoa,
                             //lhh.tenloaihang,
                             hh.soluong
                         });
            gridcontrol.DataSource = query;
        }
        // lấy danh sách hoá đơn nhập hàng
        public IEnumerable<HoaDonNhapHang> LayDanhSachHoaDonNhapHang()
        {
            IEnumerable<HoaDonNhapHang> query = from hd in dbContext.HoaDonNhapHangs select hd;
            return query;
        }
        // lấy danh sách hàng hoá
        public void LayDanhSachNguyenLieu(GridControl gridcontrol)
        {
            var query = from hanghoa in dbContext.GetTable<HangHoa>()
                        select hanghoa;
            gridcontrol.DataSource = query;
        }
        // lấy danh sách phiếu nhập
        public void LayThongTinPhieuNhap(GridControl grid)
        {
            var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
                         from nv in dbContext.GetTable<NhanVien>()
                         where (hd.id_nhanvien == nv.id_nhanvien)
                         select new
                         {
                             nv.tennhanvien,
                             hd.thoigian
                         });
            grid.DataSource = query;
        }
        // them hoa don nhap hang
        public void ThemHoaDonNhapHang(HoaDonNhapHang hd)
        {
            dbContext.HoaDonNhapHangs.InsertOnSubmit(hd);
            dbContext.SubmitChanges();
        }
        //Xóa hóa đơn nhập hàng
        public void XoaHoaDonNhapHang(int _HoaDonNhapHangID)
        {
            //Chitiet_HoaDonNhapHang[] array = LayDanhSachChiTietDonHangTheoIdNhapHang(_HoaDonNhapHangID).ToArray();
            //foreach(var row in array){
            //    XoaChiTietHoaDonNhapHang(row.id_ctnhaphang);
            //}
            //HoaDonNhapHang hd = dbContext.HoaDonNhapHangs.Single<HoaDonNhapHang>(x=>x.id_nhaphang == _HoaDonNhapHangID);
            //dbContext.HoaDonNhapHangs.DeleteOnSubmit(hd);
            //dbContext.SubmitChanges();
        }
        // Xóa một chi tiết đơn hàng
        public void XoaChiTietHoaDonNhapHang(int _HoaDonChiTietID)
        {
            Chitiet_HoaDonNhapHang _ChiTietHonDonNhapHang = dbContext.Chitiet_HoaDonNhapHangs.Single<Chitiet_HoaDonNhapHang>(x => x.id_ctnhaphang == _HoaDonChiTietID);
            dbContext.Chitiet_HoaDonNhapHangs.DeleteOnSubmit(_ChiTietHonDonNhapHang);
            dbContext.SubmitChanges();
        }
        //Lấy danh sách chi tiết đơn hàng theo id_nhaphang
        public IEnumerable<Chitiet_HoaDonNhapHang> LayDanhSachChiTietDonHangTheoIdNhapHang(int _NhapHangID)
        {
            IEnumerable<Chitiet_HoaDonNhapHang> query = from cthh in dbContext.Chitiet_HoaDonNhapHangs
                                                        where cthh.id_nhaphang == _NhapHangID
                                                        select cthh;
            return query;
        }
        // Lấy danh sách chi tiết đơn hàng theo id_hanghoa
        public IEnumerable<Chitiet_HoaDonNhapHang> LayDanhSachChiTietDonHang(int _HangHoaID)
        {
            //IEnumerable<HangHoa> query = from m in dbContext.HangHoas
            //                             where m.id_nhacungcap == _NhaCungCapID
            //                             select m;
            //return query;
            IEnumerable<Chitiet_HoaDonNhapHang> query = from cthh in dbContext.Chitiet_HoaDonNhapHangs
                                                        where cthh.id_hanghoa == _HangHoaID
                                                        select cthh;
            return query;
        }
        // Lấy danh sách phiếu nhập chi tiết 
        public void LayDanhSachPhieuNhap(GridControl grc) {
            var query = from hd in dbContext.GetTable<HoaDonNhapHang>()
                        from cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
                        from hh in dbContext.GetTable<HangHoa>()
                        from nv in dbContext.GetTable<NhanVien>()
                        where ((hd.id_nhaphang == cthd .id_nhaphang) && (cthd.id_hanghoa == hh.id_hanghoa) &&(nv.id_nhanvien == hd.id_nhanvien))
                        select new {
                            hh.tenhanghoa,
                            nv.tennhanvien,
                            hd.thoigian,
                            cthd.soluong,
                            cthd.dongia,
                            hd.thue,
                        };
            grc.DataSource = query;    
        }
        // lấy danh sách nguyên liệu nhập
        public void LayDanhSachNguyenLieuNhap(GridControl grc)
        {
            var query = from hd in dbContext.GetTable<HoaDonNhapHang>()
                        from cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
                        from hh in dbContext.GetTable<HangHoa>()
                        from nv in dbContext.GetTable<NhanVien>()
                        where ((hd.id_nhaphang == cthd.id_nhaphang) && (cthd.id_hanghoa == hh.id_hanghoa) && (nv.id_nhanvien == hd.id_nhanvien))
                        select new
                        {
                            hd.id_nhaphang,
                            hh.tenhanghoa,
                            cthd.soluong,
                            cthd.dongia,
                        };
            grc.DataSource = query;    
        }
        // Lấy id
        public string LayIdNhapHang()
        {
            int count = 0;
            string id="";
            var query = from hd in dbContext.HoaDonNhapHangs
                        select hd;
            count = Enumerable.Count(query);
            if (count < 10)
            {
                id += "000" + (count++);
            }
            else {
                id += "00" + (count++);
            }
            return id;
        }
    }
}
