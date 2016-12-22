using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class NhaCungCap_BLL
    {
        RestaurantDBDataContext dbContext = null;
        HangHoa_BLL _hanghoaBll;
        // hàm khởi tạo lớp NhaCungCap_BLL
        public NhaCungCap_BLL()
        {
            dbContext = new RestaurantDBDataContext();
            _hanghoaBll = new HangHoa_BLL();
        }
        // hàm lấy danh sách nhà cung cấp
        public IEnumerable<NhaCungCap> LayDanhSachNhaCungCap()
        {
            IEnumerable<NhaCungCap> query = from ncc in dbContext.NhaCungCaps select ncc;
            return query;
        }
        // hàm thêm nhà cung cấp
        public void ThemNhaCungCapMoi(NhaCungCap ncc)
        {
            dbContext.NhaCungCaps.InsertOnSubmit(ncc);
            dbContext.SubmitChanges();
        }
        // hàm cập nhật nhà cung cấp
        public void CapNhatNhaCungCap(NhaCungCap ncc)
        {
            NhaCungCap _nhacungcap = dbContext.NhaCungCaps.Single<NhaCungCap>(x => x.id_nhacungcap == ncc.id_nhacungcap);
            _nhacungcap.tennhacungcap = ncc.tennhacungcap;
            _nhacungcap.sdt = ncc.sdt;
            _nhacungcap.diachi = ncc.diachi;
            _nhacungcap.ghichu = ncc.ghichu;
            dbContext.SubmitChanges();
        }
        //Kiểm tra nhà cung cấp có tồn tại hay không
        public bool KiemTraNhaCungCapTonTai(string _TenNhaCungCap, int id = -1)
        {
            IEnumerable<NhaCungCap> query = from ncc in dbContext.NhaCungCaps
                                            where ncc.tennhacungcap == _TenNhaCungCap
                                            select ncc;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.id_nhacungcap == id);
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
        public void XoaNhaCungCap(int _NhaCungCapID)
        {
            //HangHoa[] array = (_hanghoaBll.LayDanhSachHangHoa(_NhaCungCapID)).ToArray();

            //foreach (var row in array)
            //{
            //    _hanghoaBll.XoaHangHoa(row.id_hanghoa);
            //}
            //NhaCungCap _NhaCungCap = dbContext.NhaCungCaps.Single<NhaCungCap>(x => x.id_nhacungcap == _NhaCungCapID);
            //dbContext.NhaCungCaps.DeleteOnSubmit(_NhaCungCap);
            //dbContext.SubmitChanges();
        }
    }
}
