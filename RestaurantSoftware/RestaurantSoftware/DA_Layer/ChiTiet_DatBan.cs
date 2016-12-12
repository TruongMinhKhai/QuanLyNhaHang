using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.DA_Layer
{
    class ChiTiet_DatBan
    {
        int iddatban;

        public int Iddatban
        {
            get { return iddatban; }
            set { iddatban = value; }
        }
        int idban;

        public int Idban
        {
            get { return idban; }
            set { idban = value; }
        }
        string tenban;

        public string Tenban
        {
            get { return tenban; }
            set { tenban = value; }
        }
        string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        string tenloaiban;


        public string Tenloaiban
        {
            get { return tenloaiban; }
            set { tenloaiban = value; }
        }
        string tennhanvien;

        public string Tennhanvien
        {
            get { return tennhanvien; }
            set { tennhanvien = value; }
        }
        int idnhanvien;

        public int Idnhanvien
        {
            get { return idnhanvien; }
            set { idnhanvien = value; }
        }
        DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        int idkhachhang;

        public int Idkhachhang
        {
            get { return idkhachhang; }
            set { idkhachhang = value; }
        }
        string tenkhachhang;

        public string Tenkhachhang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }

        string sodienthoai;

        public string Sodienthoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }
    }
}
