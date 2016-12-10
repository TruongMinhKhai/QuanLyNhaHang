using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class DatBan_BLL
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
                        where bn.trangthai == "Trống"
                        select bn; 
                       
            return query;
        }

        public IEnumerable<Ban> LayDanhSachBanDat(DateTime ngaydat)
        {
            var query = from ban in dbContext.Bans
                        where
                          !
                            (from DatBans in dbContext.DatBans
                             where
                               DatBans.thoigian == ngaydat.Date && DatBans.trangthai == "Chưa nhận bàn"
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

        public void LayDsDatBan(GridControl grid)
        {
            var query = from db in dbContext.DatBans
                        select new
                        {
                            db.id_datban,
                            db.Ban.tenban,
                            db.trangthai,
                            db.thoigian,
                            db.NhanVien.tennhanvien,
                            db.KhachHang.tenkh,
                            db.KhachHang.sdt
                        };
            grid.DataSource = query;
        }
       
        public void ThemMoiPhieuDatBan(DatBan db)
        {
            dbContext.DatBans.InsertOnSubmit(db);
            dbContext.SubmitChanges();
        }
       
        public void LoadChiTietDatBan(int iddatban, GridControl grid)
        {
            try
            {
                var query = from ct in dbContext.Chitiet_DatBans
                            join m in dbContext.Mons on ct.id_mon equals m.id_mon
                            where
                              ct.id_datban == iddatban
                            select new
                            {
                                ct.id_datban,
                                ct.id_mon,
                                m.tenmon,
                                ct.soluong,
                                m.gia,
                                thanhtien = ct.soluong*m.gia
                            };
                grid.DataSource = query;
            }
            catch (Exception)
            {

                Notifications.Answers("Chưa có món ăn");
            }

        }
        public void loadid(int iddatban, string trangthai, LookUpEdit nhanvien, DateEdit ngay, TextEdit tenkh, TextEdit sdt, TextEdit tenban)
        {
            try
            {
                int idkh = -1;
                var query = (from db in dbContext.DatBans
                             join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                             join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                             where db.trangthai == trangthai
                             select new ChiTiet_DatBan
                             {
                                 Iddatban = db.id_datban,
                                 Idban = bn.id_ban,
                                 Tenban = bn.tenban,
                                 Trangthai = bn.trangthai,
                                 Idnhanvien = nv.id_nhanvien,
                                 Tennhanvien = nv.tennhanvien,
                                 Ngay = Convert.ToDateTime(db.thoigian)

                             }).ToList();
                foreach (var id in query)
                {
                    if (id.Iddatban == iddatban)
                    {
                        nhanvien.EditValue = id.Idnhanvien;
                        ngay.DateTime = id.Ngay;
                        tenban.Text = id.Tenban;
                        idkh = id.Iddatban;
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
            var query = (from db in dbContext.DatBans
                         join kh in dbContext.KhachHangs on db.id_khachhang equals kh.id_khachhang
                         where db.id_datban == id
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
        public void load(int iddatban, LookUpEdit nhanvien, DateEdit ngay, TextEdit tenkh, TextEdit sdt, TextEdit tenban)
        {
            try
            {
                int idkh = -1;
                var query = (from db in dbContext.DatBans
                             join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                             join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                             select new ChiTiet_DatBan
                             {
                                 Iddatban = db.id_datban,
                                 Idban = bn.id_ban,
                                 Tenban = bn.tenban,
                                 Idnhanvien = nv.id_nhanvien,
                                 Tennhanvien = nv.tennhanvien,
                                 Ngay = Convert.ToDateTime(db.thoigian),

                             }).ToList();
                foreach (var id in query)
                {
                    if (id.Iddatban == iddatban)
                    {
                        nhanvien.EditValue = id.Idnhanvien;
                        ngay.DateTime = id.Ngay;
                        tenban.Text = id.Tenban;
                        idkh = id.Iddatban;
                        laykhachhang(idkh, tenkh, sdt);
                    }
                }
            }
            catch (Exception)
            {
                Notifications.Answers("Hóa đơn này chưa có khách hàng.");

            }

        }
    }
}
