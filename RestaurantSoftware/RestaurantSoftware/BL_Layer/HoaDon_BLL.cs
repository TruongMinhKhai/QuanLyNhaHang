using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class HoaDon_BLL
    {
        ChiTiet_ThanhToan ctth = new ChiTiet_ThanhToan();
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public void LoadHoaDon(GridControl gr)
        {
            var query = from db in dbContext.HoaDonThanhToans
                        join kh in dbContext.KhachHangs on db.id_khachhang equals kh.id_khachhang
                        join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                        where db.trangthai == "Đã thanh toán"
                        select new
                        {
                            db.id_hoadon,
                            db.id_ban,
                            bn.tenban,
                            db.trangthai,
                            db.thoigian,
                            db.id_khachhang,
                            kh.tenkh,
                            kh.sdt,
                            db.vat,
                            db.khuyenmai,
                            datra = (decimal?)db.datra,
                            db.id_nhanvien,
                            tongtien = (int?)db.tongtien
                        };
            gr.DataSource = query;
        }
    }
}
