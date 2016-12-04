using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
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
                            Tenloaiban = lb.tenloaiban
                        };
            return query;
        }
        public void LoadHoaDon(GridControl gr)
        {
            var query = from db in dbContext.HoaDonThanhToans
                        join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                        select new
                        {
                            db.id_hoadon,
                            db.id_ban,
                            bn.tenban,
                            db.trangthai,
                            db.thoigian
                        };
            gr.DataSource = query;
        }
        public IEnumerable<KhachHang> LayDsKhachHang()
        {
            var query = from kh in dbContext.KhachHangs select kh;
            return query;
        }

        public void LoadChiTietHoaDon(int idhoadon, GridControl grid)
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
                            m.gia,
                            ct.thanhtien
                        };
            grid.DataSource = query;
        }
        public void loadid(int idban, string trangthai, TextEdit idhoadon, LookUpEdit nhanvien, DateEdit ngay)
        {
            var query = (from db in dbContext.HoaDonThanhToans
                         join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                         join lb in dbContext.LoaiBans on bn.id_loaiban equals lb.id_loaiban
                         join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                         where db.trangthai == trangthai
                         select new ChiTiet_ThanhToan
                         {
                             Idhoadon = db.id_hoadon,
                             Idban = bn.id_ban,
                             Tenban = bn.tenban,
                             Trangthai = bn.trangthai,
                             Tenloaiban = lb.tenloaiban,
                             Idnhanvien = nv.id_nhanvien,
                             Tennhanvien = nv.tennhanvien,
                             Ngay = Convert.ToDateTime(db.thoigian)
                         }).ToList();
            foreach (var id in query)
            {
                if (id.Idban == idban)
                {
                    idhoadon.Text = (id.Idhoadon).ToString();
                    nhanvien.EditValue = id.Idnhanvien;
                    ngay.DateTime = id.Ngay;
                }
            }
        }
        public void load(int idban, TextEdit idhoadon, LookUpEdit nhanvien, DateEdit ngay)
        {
            var query = (from db in dbContext.HoaDonThanhToans
                         join bn in dbContext.Bans on db.id_ban equals bn.id_ban
                         join lb in dbContext.LoaiBans on bn.id_loaiban equals lb.id_loaiban
                         join nv in dbContext.NhanViens on db.id_nhanvien equals nv.id_nhanvien
                         select new ChiTiet_ThanhToan
                         {
                             Idhoadon = db.id_hoadon,
                             Idban = bn.id_ban,
                             Tenban = bn.tenban,
                             Trangthai = bn.trangthai,
                             Tenloaiban = lb.tenloaiban,
                             Idnhanvien = nv.id_nhanvien,
                             Tennhanvien = nv.tennhanvien,
                             Ngay = Convert.ToDateTime(db.thoigian)
                         }).ToList();
            foreach (var id in query)
            {
                if (id.Idban == idban)
                {
                    idhoadon.Text = (id.Idhoadon).ToString();
                    nhanvien.EditValue = id.Idnhanvien;
                    ngay.DateTime = id.Ngay;
                }
            }
        }
    }
}
