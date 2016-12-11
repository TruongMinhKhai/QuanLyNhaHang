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
    public class DatBan_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IQueryable<Ban> LayDanhSachBan(DateTime ngaydat)
        {
            var query = from ban in dbContext.Bans
                        where
                          !
                            (from DatBans in dbContext.DatBans
                             where
                               DatBans.thoigian == ngaydat.Date
                             select new
                             {
                                 DatBans.id_ban
                             }).Contains(new { id_ban = (System.Int32?)ban.id_ban })
                        select ban;
            return query;
        }

        public void LoadTrangThai(List<string> list, string str)
        {
            var query = dbContext.TrangThais.Where(TrangThai => TrangThai.lienket == str);
            foreach(var q in query)
            {
                list.Add(q.tentrangthai);
            }
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
        public int KiemTraMonDaCoChua(int? id_datban, int? id_mon)
        {
            var query = (from ct_db in dbContext.Chitiet_DatBans
                         where ct_db.id_datban == id_datban &&
                               ct_db.id_mon == id_mon
                         select ct_db).Count();
            return query;
        }
        public void ThemChiTiet(Chitiet_DatBan ct)
        {
            dbContext.Chitiet_DatBans.InsertOnSubmit(ct);
            dbContext.SubmitChanges();
        }
        public void CapNhatChiTiet(Chitiet_DatBan ct)
        {
            var queryChitiet_DatBans =
                from Chitiet_DatBans in dbContext.Chitiet_DatBans
                where
                  Chitiet_DatBans.id_datban == ct.id_datban &&
                  Chitiet_DatBans.id_mon == ct.id_mon
                select Chitiet_DatBans;
            foreach (var Chitiet_DatBans in queryChitiet_DatBans)
            {
                Chitiet_DatBans.soluong += ct.soluong;
                Chitiet_DatBans.dongia = ct.dongia;
                Chitiet_DatBans.thanhtien += ct.thanhtien;
            }
            dbContext.SubmitChanges();
        }
        public void XoaChiTiet(int id_datban, int id_mon)
        {
            var queryChitiet_DatBans =
                from Chitiet_DatBans in dbContext.Chitiet_DatBans
                where
                  Chitiet_DatBans.id_datban == id_datban &&
                  Chitiet_DatBans.id_mon == id_mon
                select Chitiet_DatBans;
            foreach (var del in queryChitiet_DatBans)
            {
                dbContext.Chitiet_DatBans.DeleteOnSubmit(del);
            }
            dbContext.SubmitChanges();
        }
        public void SuaPhieuDatBan(DatBan db)
        {
            var query =
                from datban in dbContext.DatBans
                where
                  datban.id_datban == db.id_datban
                select datban;
            foreach (var q in query)
            {
                q.id_ban = db.id_ban;
                q.id_khachhang = db.id_khachhang;
                q.thoigian = db.thoigian;
            }
            dbContext.SubmitChanges();
        }
        public void XoaPhieuDatBan(int id)
        {
            var queryChitiet_DatBans =
                from Chitiet_DatBans in dbContext.Chitiet_DatBans
                where
                  Chitiet_DatBans.id_datban == id 
                select Chitiet_DatBans;
            foreach (var del in queryChitiet_DatBans)
            {
                dbContext.Chitiet_DatBans.DeleteOnSubmit(del);
            }

            var queryDatban = from datban in dbContext.DatBans
                              where
                                datban.id_datban == id
                              select datban;
            foreach (var del in queryDatban)
            {
                dbContext.DatBans.DeleteOnSubmit(del);
            }
            dbContext.SubmitChanges();
        }
        public IQueryable<DatBan> LoadPhieuDatBan(int? idban,DateTime? dt)
        {
            var query = from datban in dbContext.DatBans
                        where datban.thoigian == dt && datban.id_ban == idban
                        select datban;
            return query;
        }
    }
}
