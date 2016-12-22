using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class PhucVu_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IQueryable<Ban> LayDanhSachBan()
        {
            var query = from ban in dbContext.Bans
                        select ban;
            return query;
        }
        public List<string> TrangThaiBan()
        {
            List<string> list = new List<string>();
            var trangthai_ban = from tt in dbContext.TrangThais
                                where tt.lienket == "ban"
                                select tt;
            foreach(var i in trangthai_ban)
            {
                list.Add(i.tentrangthai);
            }
            return list;
        }
        public List<string> TrangThaiPhieuDatBan()
        {
            List<string> list = new List<string>();
            var trangthai_ban = from tt in dbContext.TrangThais
                                where tt.lienket == "datban"
                                select tt;
            foreach (var i in trangthai_ban)
            {
                list.Add(i.tentrangthai);
            }
            return list;
        }

        public List<string> TrangThaiHoaDon()
        {
            List<string> list = new List<string>();
            var trangthai_ban = from tt in dbContext.TrangThais
                                where tt.lienket == "hoadon"
                                select tt;
            foreach (var i in trangthai_ban)
            {
                list.Add(i.tentrangthai);
            }
            return list;
        }

        public void CapNhatTrangThaiDatBan(DateTime dt, List<string> ttdatban)
        {
            var query = from datban in dbContext.DatBans
                        where datban.trangthai == ttdatban[0]
                        select datban;
            foreach(var i in query)
            {
                if(DateTime.Compare((DateTime)i.thoigian,dt) < 0)
                {
                    i.trangthai = ttdatban[2]; //hủy
                }
            }
        }
        public void CapNhatTrangThaiBan(DateTime dt,List<string> ttban,List<string> ttdatban,List<string> tthoadon) //cập nhật trạng thái của bàn đã được đặt, bàn đang có khách
        {
            var dsban = from ban in dbContext.Bans
                        select ban;
            foreach(var i in dsban)
            {
                i.trangthai = ttban[0]; // reset trạng thái bàn về Trống
            }
            dbContext.SubmitChanges();
           CapNhatTrangThaiDatBan(dt, ttdatban); //hủy phiếu đặt bàn quá ngày.
           var sql = from ban in dbContext.Bans
                    join datban in dbContext.DatBans
                    on ban.id_ban equals datban.id_ban
                    where datban.trangthai == ttdatban[0] // chờ
                    && datban.thoigian == dt
                    select ban;
           foreach(var i in sql)
           {
               i.trangthai = ttban[2]; //đặt
           }
           

           var query = from ban in dbContext.Bans
                       join hoadon in dbContext.HoaDonThanhToans
                       on ban.id_ban equals hoadon.id_ban
                       where hoadon.thoigian == dt
                       && hoadon.trangthai == tthoadon[0] //chưa thanh toán
                       select ban;
            foreach(var i in query)
            {
                i.trangthai = ttban[1]; //đầy
            }
            dbContext.SubmitChanges();
        }
        public void SetTrangThaiBan(int id, string trangthai)
        {
            var sql = from ban in dbContext.Bans
                      where ban.id_ban == id
                      select ban;
            foreach(var i in sql)
            {
                i.trangthai = trangthai;
            }
            dbContext.SubmitChanges();
        }
        public void SetTrangThaiPhieuDatBan(int idban, DateTime dt, string trangthai)
        {
            var sql = from datban in dbContext.DatBans
                      where datban.id_ban == idban &&
                      datban.thoigian == dt
                      select datban;
            foreach(var i in sql)
            {
                i.trangthai = trangthai;
            }
            dbContext.SubmitChanges();
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

        public IQueryable<HoaDonThanhToan> LoadHoaDon(int idban, DateTime dt, string trangthai)
        {
            var query = from hd in dbContext.HoaDonThanhToans
                        where hd.id_ban == idban && hd.thoigian == dt && hd.trangthai == trangthai
                        select hd;
            return query;
        }

        public void LoadChiTietHoaDon(int idhoadon,GridControl grid)
        {
            var query = from cthd in dbContext.Chitiet_HoaDonThanhToans
                        where cthd.id_hoadon == idhoadon
                        select new
                                    {
                                        cthd.id_hoadon,
                                        cthd.id_mon,
                                        cthd.Mon.tenmon,
                                        cthd.soluong,
                                        gia = (decimal?)cthd.Mon.gia,
                                        cthd.thanhtien
                                    };
  
            grid.DataSource = query;
        }

        public void ThemMoiHoaDon(HoaDonThanhToan db)
        {
            dbContext.HoaDonThanhToans.InsertOnSubmit(db);
            dbContext.SubmitChanges();
        }
        public void ThemMoiChiTietHoaDon(Chitiet_HoaDonThanhToan ct)
        {
            dbContext.Chitiet_HoaDonThanhToans.InsertOnSubmit(ct);
            dbContext.SubmitChanges();
        }
        public void CapNhatChiTietHoaDon(Chitiet_HoaDonThanhToan ct)
        {
            var query =
                from cthd in dbContext.Chitiet_HoaDonThanhToans
                where
                  cthd.id_hoadon == ct.id_hoadon &&
                  cthd.id_mon == ct.id_mon
                select cthd;
            foreach (var cthd in query)
            {
                cthd.soluong += ct.soluong;
                cthd.dongia = ct.dongia;
                cthd.thanhtien += ct.thanhtien;
            }
            dbContext.SubmitChanges();
        }
        public void XoaChiTietHoaDon(int id_hoadon, int id_mon)
        {
            var query =
                from cthd in dbContext.Chitiet_HoaDonThanhToans
                where
                  cthd.id_hoadon == id_hoadon &&
                  cthd.id_mon == id_mon
                select cthd;
            foreach (var del in query)
            {
                dbContext.Chitiet_HoaDonThanhToans.DeleteOnSubmit(del);
            }
            dbContext.SubmitChanges();
        }
        public int KiemTraMonDaCoChua(int? id_hoadon, int? id_mon)
        {
            var query = (from cthd in dbContext.Chitiet_HoaDonThanhToans
                         where cthd.id_hoadon == id_hoadon &&
                               cthd.id_mon == id_mon
                         select cthd).Count();
            return query;
        }
        public void ChuyenChiTietDatBan(int idban,DateTime today,int idhoadon)
        {
            var chitietdatban = from ct in dbContext.Chitiet_DatBans
                        where
                          ct.DatBan.id_ban == idban &&
                          ct.DatBan.thoigian == today
                        select new
                        {
                            ct.id_datban,
                            ct.id_mon,
                            ct.Mon.tenmon,
                            ct.soluong,
                            gia = (decimal?)ct.Mon.gia,
                            ct.thanhtien
                        };
            foreach(var ctdb in chitietdatban)
            {
                Chitiet_HoaDonThanhToan cthoadon = new Chitiet_HoaDonThanhToan();
                cthoadon.id_hoadon = idhoadon;
                cthoadon.id_mon = ctdb.id_mon;
                cthoadon.soluong = ctdb.soluong;
                cthoadon.dongia = ctdb.gia;
                cthoadon.thanhtien = ctdb.thanhtien;
                ThemMoiChiTietHoaDon(cthoadon);
            }
        }

        public void SuaHoaDon(int idbanSelected,int idhd)
        {
            var query = from hd in dbContext.HoaDonThanhToans
                        where hd.id_hoadon == idhd 
                        select hd;
            foreach(var i in query)
            {
                i.id_ban = idbanSelected;
            }
            dbContext.SubmitChanges();
        }

    }
}
