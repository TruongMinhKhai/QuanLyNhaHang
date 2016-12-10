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
    class PhucVu_BLL
    {

        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<Ban> LayDanhSachBan()
        {
            //var query = from ban in dbContext.Bans
            //            where
            //              !
            //                (from DatBans in dbContext.DatBans
            //                 where
            //                   DatBans.thoigian == ngaydat.Date
            //                 select new
            //                 {
            //                     DatBans.id_ban
            //                 }).Contains(new { id_ban = (System.Int32?)ban.id_ban })
            //            select ban;
            //return query;

            var query = from bn in dbContext.Bans
                        select bn;

            return query;
        }

        public IEnumerable<Ban> LayDanhSachBanDat()
        {
            var query = from ban in dbContext.Bans
                        where
                          !
                            (from DatBans in dbContext.DatBans
                             where
                               DatBans.thoigian == DateTime.Now && DatBans.trangthai == "Chưa nhận bàn"
                             select new
                             {
                                 DatBans.id_ban
                             }).Contains(new { id_ban = (System.Int32?)ban.id_ban })
                        select ban;
            return query;


        }

        public void LayDanhSachMon(GridControl grid)
        {
            var query = from
                            m in dbContext.Mons
                        join
                            lm in dbContext.LoaiMons
                        on
                        m.id_loaimon equals lm.id_loaimon
                        select new
                        {
                            tenmon = m.tenmon,
                            tenviettat = m.tenviettat,
                            gia = m.gia,
                            tenloaimon = lm.tenloaimon,
                            id_mon = m.id_mon,
                            trangthai = m.trangthai
                        };

            grid.DataSource = query;
        }

       
        public void ThemMoiHoaDon(HoaDonThanhToan db)
        {
            dbContext.HoaDonThanhToans.InsertOnSubmit(db);
            dbContext.SubmitChanges();
        }
        public void loadid(int idban, string trangthai, TextEdit idhoadon, LookUpEdit nhanvien, DateEdit ngay, LookUpEdit kh)
        {
            try
            {
                int idhd = -1;
                var query = (from db in dbContext.HoaDonThanhToans
                             join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                             join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                             where db.trangthai==trangthai
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
                        idhd = id.Idhoadon;
                        laykhachhang(idhd, kh);
                        
                    }
                }

            }
            catch (Exception)
            {

                Notifications.Answers("Hóa đơn này chưa có khách hàng.");
            }
        }


        void laykhachhang(int id, LookUpEdit khachhang)
        {
            var query = (from db in dbContext.HoaDonThanhToans
                         join kh in dbContext.KhachHangs on db.id_khanhhang equals kh.id_khachhang
                         where db.id_hoadon == id
                         select new ChiTiet_ThanhToan
                         {
                             Idkhachhang = kh.id_khachhang

                         }).ToList();
            foreach (var i in query)
            {
                khachhang.EditValue = i.Idkhachhang;
            }
        }
        //public void load(int iddatban, LookUpEdit nhanvien, DateEdit ngay, TextEdit tenkh, TextEdit sdt, TextEdit tenban)
        //{
        //    try
        //    {
        //        int idkh = -1;
        //        var query = (from db in dbContext.DatBans
        //                     join bn in dbContext.Bans on db.id_ban equals bn.id_ban
        //                     join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
        //                     select new ChiTiet_DatBan
        //                     {
        //                         Iddatban = db.id_datban,
        //                         Idban = bn.id_ban,
        //                         Tenban = bn.tenban,
        //                         Idnhanvien = nv.id_nhanvien,
        //                         Tennhanvien = nv.tennhanvien,
        //                         Ngay = Convert.ToDateTime(db.thoigian),

        //                     }).ToList();
        //        foreach (var id in query)
        //        {
        //            if (id.Iddatban == iddatban)
        //            {
        //                nhanvien.EditValue = id.Idnhanvien;
        //                ngay.DateTime = id.Ngay;
        //                tenban.Text = id.Tenban;
        //                idkh = id.Iddatban;
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
