using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class Ban_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<Ban> LayDanhSachBan()
        {
            IEnumerable<Ban> query = from B in dbContext.Bans where B.trangthai != "Hỏng" select B;
            return query;
        }

        public void ThemBanMoi(Ban ban)
        {
            dbContext.Bans.InsertOnSubmit(ban);
            dbContext.SubmitChanges();
        }

        public void CapNhatBan(Ban ban)
        {
            Ban _ban = dbContext.Bans.Single<Ban>(x => x.id_ban == ban.id_ban);
            _ban.tenban = ban.tenban;
            _ban.LoaiBan = dbContext.LoaiBans.Single<LoaiBan>(l => l.id_loaiban == ban.id_loaiban);
            _ban.trangthai = ban.trangthai;
            // update 
            dbContext.SubmitChanges();
        }
        public void CapNhatBanThanhToan(Ban ban)
        {
            Ban _ban = dbContext.Bans.Single<Ban>(x => x.id_ban == ban.id_ban);
            _ban.trangthai = ban.trangthai;
            // update 
            dbContext.SubmitChanges();
        }

        public int LayIdBan(string TenBan)
        {
            IEnumerable<Ban> query = from b in dbContext.Bans where b.tenban  == TenBan select b;
            return query.First().id_ban;
        }

        public int KiemTraBanTonTai(string _tenBan, int id = -1)
        {
            IEnumerable<Ban> query = from b in dbContext.Bans
                                     where b.tenban  == _tenBan
                                     select b;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(b => b.id_ban == id);
                    if (query.Count() == 1)
                    {
                        return 1;
                    }
                }

                if (query.Where(y => y.trangthai.Equals("Hỏng")).Count() > 0)
                {
                    return 0;
                }
                return -1;
            }
            return 1;
        }

        public bool KiemTraThongTin(int id_ban)
        {
            IEnumerable<DatBan> _KiemTraDatBan = from db in dbContext.DatBans
                                     where db.id_ban == id_ban
                                     select db;
            IEnumerable<HoaDonThanhToan> _KiemTraHoaDon = from hd in dbContext.HoaDonThanhToans
                                        where hd.id_ban == id_ban
                                        select hd;
            if(_KiemTraDatBan.Count() > 0 || _KiemTraHoaDon.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraBan(Ban ban)
        {
            if (ban.tenban != null && ban.tenban.ToString() != "")
                return true;
            return false;
        }

        public void XoaTam(int id_ban)
        {
            Ban _ban = dbContext.Bans.Single<Ban>(b => b.id_ban == id_ban);
            _ban.trangthai = "Hỏng";
            // update 
            dbContext.SubmitChanges();
        }

        public void XoaBan(int _BanID)
        {
            Ban _ban = dbContext.Bans.Single<Ban>(b => b.id_ban == _BanID);
            dbContext.Bans.DeleteOnSubmit(_ban);
            dbContext.SubmitChanges();
        }
    }
}
