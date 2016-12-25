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
    class ThanhToan_BLL
    {
        ChiTiet_ThanhToan ctth = new ChiTiet_ThanhToan();
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<ChiTiet_ThanhToan> LayDanhSachBan(string trangthai)
        {

            var query = from db in dbContext.HoaDonThanhToans
                        join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                        join lb in dbContext.LoaiBans on bn.id_loaiban equals lb.id_loaiban
                        where db.trangthai == trangthai
                        select new ChiTiet_ThanhToan
                        {
                            Idhoadon = db.id_hoadon,
                            Idban = bn.id_ban,
                            Tenban = bn.tenban,
                            Trangthai = bn.trangthai,
                            Tenloaiban = lb.tenloaiban,
                        };
            return query;
        }
        public void LoadHoaDon(GridControl gr)
        {
            var query = from db in dbContext.HoaDonThanhToans
                        join kh in dbContext.KhachHangs on db.id_khachhang equals kh.id_khachhang
                        join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                        where db.trangthai == "Đã thanh toán"
                        select new
                        {
                            db.id_hoadon,
                            db.id_nhanvien,
                            db.id_ban,
                            bn.tenban,
                            db.trangthai,
                            db.thoigian,
                            db.id_khachhang,
                            kh.tenkh,
                            kh.sdt,
                            db.vat,
                            db.khuyenmai,
                            datra = (decimal?)db.datra
                        };
            gr.DataSource = query;
        }
        public IEnumerable<KhachHang> LayDsKhachHang()
        {
            var query = from kh in dbContext.KhachHangs select kh;
            return query;
        }
        public void LayDsThamSo(TextEdit Vat, TextEdit km)
        {
            LayVAT(Vat);
            LayKM(km);
        }
        public void LayVAT(TextEdit vat)
        {
            try
            {
                var query = (from db in dbContext.ThamSos
                             where db.tenthamso == "vat"
                             select new
                             {
                                 db.giatri
                             }).ToList();
                foreach (var id in query)
                {
                    vat.Text = id.giatri.ToString();
                }
            }
            catch (Exception)
            {

                Notifications.Answers("Chưa có tham số VAT");
            }
        }
        public void LayKM(TextEdit km)
        {
            try
            {
                var query = (from db in dbContext.ThamSos
                             where db.tenthamso == "khuyenmai"
                             select new
                             {
                                 db.giatri
                             }).ToList();
                foreach (var id in query)
                {
                    km.Text = id.giatri.ToString();
                }
            }
            catch (Exception)
            {
                Notifications.Answers("Chưa có tham số khuyến mãi");

            }
        }
        
        public void LoadChiTietHoaDon(int idhoadon, GridControl grid)
        {
            try
            {
                var query = from ct in dbContext.Chitiet_HoaDonThanhToans
                            join m in dbContext.Mons on ct.id_mon equals m.id_mon
                            where
                              ct.id_hoadon == idhoadon
                            select new
                            {
                                ct.id_cthoadon,
                                ct.id_mon,
                                m.tenmon,
                                ct.soluong,
                                thanhtien = ct.soluong * ct.dongia,
                                ct.dongia
                                
                            };
                grid.DataSource = query;
            }
            catch (Exception)
            {

                Notifications.Answers("Lỗi load món ăn");
            }
            
        }
        public void loadid(int idban, string trangthai, TextEdit idhoadon, TextEdit kd)
        {
            var query = (from db in dbContext.HoaDonThanhToans
                        where db.id_ban == idban && db.trangthai==trangthai
                        select new
                        {
                            Idhoadon = db.id_hoadon,
                            
                        }).ToList();
          
            foreach (var id in query)
            {
                    idhoadon.EditValue = id.Idhoadon;
            }
            
            
            
        }
     

        public void ThanhToan(HoaDonThanhToan m)
        {
            HoaDonThanhToan _qd = dbContext.HoaDonThanhToans.Single<HoaDonThanhToan>(x => x.id_hoadon == m.id_hoadon);
            _qd.khuyenmai = m.khuyenmai;
            _qd.vat = m.vat;
            _qd.tongtien = m.tongtien;
            _qd.trangthai = m.trangthai;
            _qd.id_khachhang = m.id_khachhang;
            // update 
            dbContext.SubmitChanges();
        }
        

    }
}
