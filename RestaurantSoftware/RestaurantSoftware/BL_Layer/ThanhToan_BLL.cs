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
                        join kh in dbContext.KhachHangs on db.id_khanhhang equals kh.id_khachhang
                        join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                        select new
                        {
                            db.id_hoadon,
                            db.id_ban,
                            bn.tenban,
                            db.trangthai,
                            db.thoigian,
                            db.id_khanhhang,
                            kh.tenkh,
                            kh.sdt,
                            db.vat,
                            db.khuyenmai
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
            try
            {
                var query = (from db in dbContext.ThamSos
                             
                             select new 
                             {
                                db.khuyenmai,
                                db.vat

                             }).ToList();
                foreach (var id in query)
                {
                    Vat.Text = id.vat.ToString();
                    km.Text = id.khuyenmai.ToString();
                }

            }
            catch (Exception)
            {

                Notifications.Answers("Chưa có tham số");
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
                                thanhtien = ct.soluong * m.gia,
                                m.gia,
                                
                            };
                grid.DataSource = query;
            }
            catch (Exception)
            {

                Notifications.Answers("Lỗi load món ăn");
            }
            
        }
        public void loadid(int idban, string trangthai, TextEdit idhoadon, LookUpEdit nhanvien, DateEdit ngay, TextEdit tenkh, TextEdit sdt)
        {
            try
            {
                int idkh = -1;
                var query = (from db in dbContext.HoaDonThanhToans
                             join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                             join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                             where db.trangthai == trangthai
                             select new ChiTiet_ThanhToan
                             {
                                 Idhoadon = db.id_hoadon,
                                 Idban = bn.id_ban,
                                 Tenban = bn.tenban,
                                 Trangthai = bn.trangthai,
                                 Idnhanvien = nv.id_nhanvien,
                                 Tennhanvien = nv.tennhanvien,
                                 Ngay = Convert.ToDateTime(db.thoigian),

                             }).ToList();
                foreach (var id in query)
                {
                    if (id.Idban == idban)
                    {
                        idhoadon.Text = (id.Idhoadon).ToString();
                        nhanvien.EditValue = id.Idnhanvien;
                        ngay.DateTime = id.Ngay;
                        idkh = id.Idhoadon;
                        laykhachhang(idkh, tenkh, sdt);
                    }
                }
           
            }
            catch (Exception)
            {

                Notifications.Answers("Hóa đơn này chưa có khách hàng.");
            }
            
            
        }
        void laykhachhang(int id, TextEdit tenkh, TextEdit sdt)
        {
            var query = (from db in dbContext.HoaDonThanhToans
                         join kh in dbContext.KhachHangs on db.id_khanhhang equals kh.id_khachhang
                         where db.id_hoadon == id
                         select new ChiTiet_ThanhToan
                         {
                             Tenkhachhang = kh.tenkh,
                             Sodienthoai = kh.sdt

                         }).ToList();
            foreach (var i in query)
            {
                tenkh.Text = i.Tenkhachhang;
                sdt.Text = i.Sodienthoai;
            }
        }

        public void ThanhToan(HoaDonThanhToan m)
        {
            HoaDonThanhToan _qd = dbContext.HoaDonThanhToans.Single<HoaDonThanhToan>(x => x.id_hoadon == m.id_hoadon);
            _qd.khuyenmai = m.khuyenmai;
            _qd.vat = m.vat;
            _qd.tongtien = m.tongtien;
            _qd.trangthai = m.trangthai;
            // update 
            dbContext.SubmitChanges();
        }
        //public void load(int idban, TextEdit idhoadon, LookUpEdit nhanvien, DateEdit ngay, TextEdit tenkh, TextEdit sdt)
        //{
        //    try
        //    {
        //        int idkh = -1;
        //        var query = (from db in dbContext.HoaDonThanhToans
        //                     join bn in dbContext.Bans on db.id_ban equals bn.id_ban
        //                     join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
        //                     select new ChiTiet_ThanhToan
        //                     {
        //                         Idhoadon = db.id_hoadon,
        //                         Idban = bn.id_ban,
        //                         Tenban = bn.tenban,
        //                         Trangthai = bn.trangthai,
        //                         Idnhanvien = nv.id_nhanvien,
        //                         Tennhanvien = nv.tennhanvien,
        //                         Ngay = Convert.ToDateTime(db.thoigian),

        //                     }).ToList();
        //        foreach (var id in query)
        //        {
        //            if (id.Idban == idban)
        //            {
        //                idhoadon.Text = (id.Idhoadon).ToString();
        //                nhanvien.EditValue = id.Idnhanvien;
        //                ngay.DateTime = id.Ngay;
        //                idkh = id.Idhoadon;
        //                laykhachhang(idkh, tenkh, sdt);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Notifications.Answers("Hóa đơn này chưa có khách hàng.");

        //    }
           
        //}


    }
}
