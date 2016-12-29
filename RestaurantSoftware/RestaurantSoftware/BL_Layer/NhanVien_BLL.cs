using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class NhanVien_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<NhanVien> LayDanhSachNhanVien()
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens where nv.trangthai != false select nv;
            return query;
        }

        public void ThemNhanVien(NhanVien NhanVien)
        {
            dbContext.NhanViens.InsertOnSubmit(NhanVien);
            dbContext.SubmitChanges();
        }

        public void CapNhatNhanVien(NhanVien nv)
        {
            NhanVien _NhanVien = dbContext.NhanViens.Single<NhanVien>(x => x.id_nhanvien == nv.id_nhanvien);
            _NhanVien.id_nhanvien = nv.id_nhanvien;
            _NhanVien.tendangnhap = nv.tendangnhap;
            _NhanVien.matkhau = nv.matkhau;
            _NhanVien.id_quyen = nv.id_quyen;
            // update 
            dbContext.SubmitChanges();
        }

        public bool KiemTraThongTin(int id_nhanvien)
        {
            IEnumerable<QuyDinh> _KiemTraQuyDinh = from qd in dbContext.QuyDinhs
                                                 where qd.id_nhanvien == id_nhanvien
                                                 select qd;
            IEnumerable<HoaDonThanhToan> _KiemTraHoaDon = from hd in dbContext.HoaDonThanhToans
                                                          where hd.id_nhanvien == id_nhanvien
                                                          select hd;
            IEnumerable<HoaDonNhapHang> _KiemTraHoaDonNhap = from hdn in dbContext.HoaDonNhapHangs
                                                          where hdn.id_nhanvien == id_nhanvien
                                                          select hdn;
            IEnumerable<SuCo> _KiemTraSuCo = from sc in dbContext.SuCos
                                             where sc.id_nhanvien == id_nhanvien
                                             select sc;
            if (_KiemTraQuyDinh.Count() > 0 || _KiemTraHoaDon.Count() > 0 || _KiemTraHoaDonNhap.Count() > 0 || _KiemTraSuCo.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraThongTinNV(int id_nhanvien)
        {
            IEnumerable<HoaDonThanhToan> _KiemTraHoaDon = from hd in dbContext.HoaDonThanhToans
                                                          where hd.id_nhanvien == id_nhanvien
                                                          select hd;
            IEnumerable<SuCo> _KiemTraSuCo = from sc in dbContext.SuCos
                                             where sc.id_nhanvien == id_nhanvien
                                             select sc;
            IEnumerable<HoaDonNhapHang> _KiemTraHoaDonNhap = from hdn in dbContext.HoaDonNhapHangs
                                                          where hdn.id_nhanvien == id_nhanvien
                                                          select hdn;
            IEnumerable<QuyDinh> _KiemTraQuyDinh = from qd in dbContext.QuyDinhs
                                             where qd.id_nhanvien == id_nhanvien
                                             select qd;
            if (_KiemTraHoaDon.Count() > 0 || _KiemTraSuCo.Count() > 0 
                || _KiemTraHoaDonNhap.Count() > 0 || _KiemTraQuyDinh.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public void XoaTam(int id_nhanvien)
        {
            NhanVien _nhanvien = dbContext.NhanViens.Single<NhanVien>(nv => nv.id_nhanvien == id_nhanvien);
            _nhanvien.trangthai = false;
            // update 
            dbContext.SubmitChanges();
        }

        public void XoaNhanVien(int _NhanVienID)
        {
            NhanVien _NhanVien = dbContext.NhanViens.Single<NhanVien>(x => x.id_nhanvien == _NhanVienID);
            dbContext.NhanViens.DeleteOnSubmit(_NhanVien);
            dbContext.SubmitChanges();
        }

        public bool KiemTraTDNTonTai(string _tendangnhap, int id = -1)
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens
                                     where nv.tendangnhap == _tendangnhap
                                     select nv;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(nv => nv.id_nhanvien == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool KiemTraNhanVien(NhanVien NV)
        {
            if (NV.tennhanvien != null && NV.tennhanvien.ToString() != "")
                return true;
            return false;
        }
    }
}
