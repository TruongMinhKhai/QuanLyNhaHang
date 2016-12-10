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
            IEnumerable<DonVi> query = from hh in dbContext.DonVis select hh;
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
        //Xóa nhà cung cấp
        public void XoaDonVi(int _DonViID)
        {
            HangHoa[] array = (_hanghoaBLL.LayDanhSachHangHoaTheoIdDonVi(_DonViID)).ToArray();

            foreach (var row in array)
            {
                _hanghoaBLL.XoaHangHoa(row.id_hanghoa);
            }
            DonVi _DonVi = dbContext.DonVis.Single<DonVi>(x => x.id_donvi == _DonViID);
            dbContext.DonVis.DeleteOnSubmit(_DonVi);
            dbContext.SubmitChanges();
        }
    }
}
