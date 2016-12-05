using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
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
                        where bn.trangthai == "trống"
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
                            id_mon = m.id_mon
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
        public IEnumerable<KhachHang> LayDsKhachHang()
        {
            var query = from kh in dbContext.KhachHangs select kh;
            return query;
        }

        public void ThemMoiPhieuDatBan(DatBan db)
        {
            dbContext.DatBans.InsertOnSubmit(db);
            dbContext.SubmitChanges();
        }
        public void LoadChiTietDatBan(string TenBan, DateTime ngaydat, GridControl grid)
        {
            var query = from ct in dbContext.Chitiet_DatBans
                        where
                          ct.DatBan.Ban.tenban == TenBan &&
                          ct.DatBan.thoigian == ngaydat.Date
                        select new
                        {
                            ct.id_datban,
                            ct.id_mon,
                            ct.Mon.tenmon,
                            ct.soluong,
                            gia = (decimal?)ct.Mon.gia,
                            ct.thanhtien
                        };
            grid.DataSource = query;
        }
    }
}
