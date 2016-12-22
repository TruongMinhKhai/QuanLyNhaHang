using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class SuCo_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public void LayDanhSachSuCo(GridControl grid)
        {
            var query = from db in dbContext.SuCos
                        select new
                        {
                            db.id_suco,
                            db.tensuco,
                            db.id_khachhang,
                            db.id_nhanvien,
                            db.ngaylap,
                            db.noidung,
                            db.KhachHang.tenkh
                        };
            grid.DataSource = query;
        }
        public IEnumerable<KhachHang> LayDsKhachHang()
        {
            var query = from kh in dbContext.KhachHangs select kh;
            return query;
        }
        public void ThemSuCo(SuCo suco)
        {
            dbContext.SuCos.InsertOnSubmit(suco);
            dbContext.SubmitChanges();
        }
        public void CapNhatSuCo(SuCo m)
        {
            SuCo _qd = dbContext.SuCos.Single<SuCo>(x => x.id_suco == m.id_suco);
            _qd.tensuco = m.tensuco;
            _qd.NhanVien = dbContext.NhanViens.Single<NhanVien>(l => l.id_nhanvien == m.id_nhanvien);
            _qd.ngaylap = m.ngaylap;
            _qd.noidung = m.noidung;
            _qd.id_khachhang = m.id_khachhang;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaSuCo(int _IDSuCo)
        {
            SuCo _SuCo = dbContext.SuCos.Single<SuCo>(x => x.id_suco == _IDSuCo);
            dbContext.SuCos.DeleteOnSubmit(_SuCo);

            dbContext.SubmitChanges();
        }
    }
}
