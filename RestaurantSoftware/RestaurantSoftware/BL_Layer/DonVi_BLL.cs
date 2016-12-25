using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class DonVi_BLL
    {
        RestaurantDBDataContext dbContext = null;
        HangHoa_BLL _hanghoaBLL = null;
        // hàm khởi tạo lớp DonVi_BLL

        public DonVi_BLL()
        {
            dbContext = new RestaurantDBDataContext();
            _hanghoaBLL = new HangHoa_BLL();
        }
        // hàm lấy danh sách đơn vị
        public IEnumerable<DonVi> LayDanhSachDonVi()
        {
            IEnumerable<DonVi> query = from dv in dbContext.DonVis 
                                       where dv.trangthai != "Xoa"
                                       select dv;
            return query;
        }
        // hàm thêm đơn vị
        public void ThemDonViMoi(DonVi dv)
        {
            dbContext.DonVis.InsertOnSubmit(dv);
            dbContext.SubmitChanges();
        }
        // hàm cập nhật nhà cung cấp
        public void CapNhatDonVi(DonVi dv)
        {
            DonVi _donvi = dbContext.DonVis.Single<DonVi>(x => x.id_donvi == dv.id_donvi);
            _donvi.tendonvi = dv.tendonvi;
            dbContext.SubmitChanges();
        }
        //Kiểm tra đơn vị có tồn tại hay không
        public bool KiemTraDonViTonTai(string _TenDonVi, int id = -1)
        {
            IEnumerable<DonVi> query = from ncc in dbContext.DonVis
                                            where ncc.tendonvi == _TenDonVi
                                            select ncc;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.id_donvi == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool KiemTraThongTin(int _DonViID)
        {
            IEnumerable<HangHoa> _KiemTraHangHoa = from db in dbContext.HangHoas
                                                   where db.id_donvi == _DonViID
                                                   select db;
            IEnumerable<Mon> _KiemTraMon = from db in dbContext.Mons
                                           where db.id_donvi == _DonViID
                                           select db;
            if (_KiemTraHangHoa.Count() > 0 && _KiemTraMon.Count() > 0)
            {
                return true;
            }
            return false;
        }
        // xóa tạm
        public void XoaTam(int _DonViID)
        {
            DonVi _dv = dbContext.DonVis.Single<DonVi>(x => x.id_donvi == _DonViID);
            _dv.trangthai = "Xoa";
            // update 
            dbContext.SubmitChanges();
        }
        // xóa món
        public void XoaMon(int _DonViID)
        {
            DonVi _dv = dbContext.DonVis.Single<DonVi>(x=> x.id_donvi == _DonViID);
            dbContext.SubmitChanges();
        }

    }
}
