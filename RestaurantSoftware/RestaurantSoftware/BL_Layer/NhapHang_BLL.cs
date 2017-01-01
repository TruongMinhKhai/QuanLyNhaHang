using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
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
        private int ID = 0;
        // hàm khởi tạo lớp nhập hàng
        public NhapHang_BLL()
        {
            dbContext = new RestaurantDBDataContext();
            ID = LayID();
        }
        // load trạng thái
        public void LoadTrangThai(List<string> list, string str)
        {
            var query = dbContext.TrangThais.Where(TrangThai => TrangThai.lienket == str);
            foreach (var q in query)
            {
                list.Add(q.tentrangthai);
            }
        }
        // lấy danh sách hàng hoá
        public void LoadDsNguyenLieu(GridControl gridcontrol)
        {
            var query = from hanghoa in dbContext.GetTable<HangHoa>()
                        select hanghoa;
            gridcontrol.DataSource = query;
        }
        // lấy danh sách phiếu nhập
        public void LoadDsPhieuNhap(GridControl grid)
        {
            var query = from hd in dbContext.GetTable<HoaDonNhapHang>()
                        select new
                        {
                            hd.id_nhaphang,
                            hd.NhaCungCap.tennhacungcap,
                            hd.thoigian,
                            hd.NhanVien.tennhanvien,
                            hd.trangthai,
                            hd.thue,
                            hd.tongtien,
                            hd.ghichu
                        };
            grid.DataSource = query;
        }
        //lấy danh sách nhân viên
        public IEnumerable<NhanVien> LoadDsNhanVien()
        {
            var query = from nv in dbContext.NhanViens
                        select nv;
            return query;
        }
        // lấy danh sách nhà cung cấp
        public IEnumerable<NhaCungCap> LoadDsNhaCungCap()
        {
            var query = from ncc in dbContext.NhaCungCaps
                        where ncc.trangthai != "Ngừng cung cấp"
                        select ncc;
            return query;
        }
        public void LoadDsChiTietPhieuNhap(GridControl grid)
        {
            var query = from hd in dbContext.Chitiet_HoaDonNhapHangs
                        select hd;
            foreach(var row in query){
                row.thanhtien = row.soluong * row.dongia;
            }
            grid.DataSource = query;

        }
        // them hoa don nhap hang
        public void ThemHoaDonNhapHang(HoaDonNhapHang hd)
        {
            dbContext.HoaDonNhapHangs.InsertOnSubmit(hd);
            dbContext.SubmitChanges();
        }
        // kiểm tra thông tin hàng hóa có tồn tại hay không
        public bool KiemTraThongTin(int id)
        {
            IEnumerable<Chitiet_HoaDonNhapHang> _KiemTraHoaDon = from hd in dbContext.Chitiet_HoaDonNhapHangs
                                                                 where hd.id_nhaphang == id
                                                                 select hd;
            if (_KiemTraHoaDon.Count() > 0)
            {
                return true;
            }
            return false;
        }
        // xóa tạm
        public void XoaTam(int id)
        {
            //Mon _mon = dbContext.Mons.Single<Mon>(x => x.id_mon == id_mon);
            HoaDonNhapHang hd = dbContext.HoaDonNhapHangs.Single<HoaDonNhapHang>(x => x.id_nhaphang == id);
            hd.trangthai = "Xoa";
            // update 
            dbContext.SubmitChanges();
        }
        //Xóa hóa đơn nhập hàng
        public void XoaHoaDonNhapHang(int _HoaDonNhapHangID)
        {
            var queryChiTietNhapHang = from cthd in dbContext.Chitiet_HoaDonNhapHangs
                        where cthd.id_nhaphang == _HoaDonNhapHangID
                        select cthd;
            foreach (var del in queryChiTietNhapHang)
            {
                dbContext.Chitiet_HoaDonNhapHangs.DeleteOnSubmit(del);
            }
            var queryNhapHang = from hd in dbContext.HoaDonNhapHangs
                                where hd.id_nhaphang == _HoaDonNhapHangID
                                select hd;
            foreach(var del in queryNhapHang){
                dbContext.HoaDonNhapHangs.DeleteOnSubmit(del);
            }
            dbContext.SubmitChanges();
        }
        // Xóa một chi tiết đơn hàng
        //public void XoaChiTietHoaDonNhapHang(int _HoaDonChiTietID)
        //{
        //    Chitiet_HoaDonNhapHang _ChiTietHonDonNhapHang = dbContext.Chitiet_HoaDonNhapHangs.Single<Chitiet_HoaDonNhapHang>(x => x.id_ctnhaphang == _HoaDonChiTietID);
        //    dbContext.Chitiet_HoaDonNhapHangs.DeleteOnSubmit(_ChiTietHonDonNhapHang);
        //    dbContext.SubmitChanges();
        //}
        // Xóa một chi tiết hóa đơn nhập hàng
        public void XoaChiTietHoaDonNhapHang(int _HoaDonChiTietID, int _HangHoaID)
        {
            var query =
                from ctnh in dbContext.Chitiet_HoaDonNhapHangs
                where
                ctnh.id_nhaphang == _HoaDonChiTietID && ctnh.id_hanghoa == _HangHoaID
                select ctnh;
            foreach(var del in query){
                dbContext.Chitiet_HoaDonNhapHangs.DeleteOnSubmit(del);
            }
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
        public int LayID()
        {
            var query = from hd in dbContext.HoaDonNhapHangs
                        select hd;
            //ID = query.Count();
            foreach (var row in query)
            {
                ID = row.id_nhaphang;
            }
            return ID;
        }
        //Hien thi ID
        public string HienThiID(int ID)
        {
            string ID_NHAPHANG = "";
            if (ID < 10)
                ID_NHAPHANG = "PN000" + ID;
            else if (ID > 9 && ID < 100)
                ID_NHAPHANG = "PN00" + ID;
            else if (ID > 99 && ID < 1000)
                ID_NHAPHANG = "PN" + ID;
            return ID_NHAPHANG;
        }
        // lấy tên nhà cung cấp
        public void LoadNhaCungCap(string tenhanghoa, TextEdit txtNhaCungCap)
        {
            //var query = from hh in dbContext.HangHoas
            //            where hh.tenhanghoa == tenhanghoa
            //            select hh;
            //foreach(var row in query){
            //    txtNhaCungCap.Text = row.NhaCungCap.tennhacungcap;
            //}
        }
        public void LoadChiTietPhieuNhap(String tenhanghoa, DateTime ngaynhap,GridControl grc)
        {
            try
            {
                var query = from cthh in dbContext.Chitiet_HoaDonNhapHangs
                            where cthh.HoaDonNhapHang.thoigian == ngaynhap.Date && cthh.HangHoa.tenhanghoa == tenhanghoa
                            select cthh;
                grc.DataSource = query;
            }
            catch (Exception)
            {

            }
         
        }
        public void LoadPhieuNhap(DateTime dt)
        {
           
        }
        // kiểm tra hàng hóa đã có chưa 
        public int KiemTraHangHoaDaCoChua(int? id_nhaphang, int? id_hanghoa)
        {
            var query = (from cthd in dbContext.Chitiet_HoaDonNhapHangs
                         where cthd.id_nhaphang == id_nhaphang && cthd.id_hanghoa == id_hanghoa
                         select cthd).Count();
            return query;
        }
        // cập nhật chi tiết nhập hàng
        public void CapNhatChiTietNhapHang(Chitiet_HoaDonNhapHang ct)
        {
            var query = from cthd in dbContext.Chitiet_HoaDonNhapHangs
                        where cthd.id_nhaphang == ct.id_nhaphang && cthd.id_hanghoa == ct.id_hanghoa
                        select cthd;
            foreach(var cthd in query){
                // cập nhật chi tiết phiếu nhập
                cthd.soluong += ct.soluong;
                cthd.dongia = ct.dongia;
                cthd.thanhtien += ct.thanhtien;
            }
            dbContext.SubmitChanges();
        }
        public void ThemChiTiet(Chitiet_HoaDonNhapHang cthd)
        {
            dbContext.Chitiet_HoaDonNhapHangs.InsertOnSubmit(cthd);
            dbContext.SubmitChanges();
        }
        // hàm lấy VAT
        public void LayDsThamSo(TextEdit Vat)
        {
            try
            {
                var query = (from db in dbContext.ThamSos
                             where db.tenthamso.Contains("vat")
                             select new
                             {
                                 db.tenthamso,
                                 db.giatri

                             }).ToList();
                foreach (var id in query)
                {
                    Vat.Text = id.giatri.ToString();
                }

            }
            catch (Exception)
            {

                Notifications.Answers("Chưa có tham số");
            }
        }
        public void LoadChiTietPhieuNhap(int id, GridControl grc)
        {
            var query = from cthd in dbContext.Chitiet_HoaDonNhapHangs
                        where cthd.id_nhaphang == id
                       select cthd;
            //foreach(var row in query){
            //    row.thanhtien = row.soluong * row.dongia;
            //}
            grc.DataSource = query;
        }
        public void SuaPhieuNhap(HoaDonNhapHang hd)
        {
            var query =
                from nh in dbContext.HoaDonNhapHangs
                where
                    nh.id_nhaphang == hd.id_nhaphang
                select nh;
            foreach (var row in query)
            {
                row.id_nhaphang = hd.id_nhaphang;
                row.id_nhacungcap = hd.id_nhacungcap;
                row.id_nhanvien = hd.id_nhanvien;
                row.thoigian = hd.thoigian;
                row.thue = hd.thue;
                row.tongtien = hd.tongtien;
            }
            dbContext.SubmitChanges();
        }
        // hàm cập nhật database
        public void UpdateDatabase()
        {
            dbContext.SubmitChanges();
        }
        // hàm cập nhật hàng tồn
        public void CapNhatNguyenLieuTon(int idnhaphang)
        {
            var query = from cthd in dbContext.Chitiet_HoaDonNhapHangs
                        where cthd.id_nhaphang == idnhaphang
                        select cthd;
            foreach(var row in query){
                row.HangHoa.soluong += row.soluong;
                decimal dongia =(decimal) ((row.HangHoa.dongia * row.HangHoa.soluong + row.soluong * row.dongia) /(row.HangHoa.soluong + row.soluong));
                row.HangHoa.dongia = dongia;
            }
            dbContext.SubmitChanges();
        }
        public void CapNhatTrangThai(int idnhaphang, string trangthai)
        {
            var query = from cthd in dbContext.HoaDonNhapHangs
                        where cthd.id_nhaphang == idnhaphang
                        select cthd;
            foreach(var row in query){
                row.trangthai = trangthai;
            }
            dbContext.SubmitChanges();
        }
    }

}
