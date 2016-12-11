using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class DangNhap_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public bool KiemTraQuyen(string userName, string password)
        {
            var q = from nv in dbContext.NhanViens
                    where nv.tendangnhap == userName && nv.matkhau == password
                    select nv;
            if(q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int LayIdMon(string TenMon)
        {
            IEnumerable<Mon> query = from m in dbContext.Mons where m.tenmon == TenMon select m;
            return query.First().id_mon;
        }
        public int get_IdNhanvien(string userName)
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens where nv.tendangnhap == userName select nv;
            return query.First().id_nhanvien;
        }
        public string get_TenNhanvien(string userName)
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens where nv.tendangnhap == userName select nv;
            return query.First().tennhanvien;
        }
    }
}
