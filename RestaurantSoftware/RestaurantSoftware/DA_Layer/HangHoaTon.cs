using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.Utils
{
    public class HangHoaTon
    {
        string tenhanghoa;

        public string Tenhanghoa
        {
            get { return tenhanghoa; }
            set { tenhanghoa = value; }
        }
        int tondau;

        public int Tondau
        {
            get { return tondau; }
            set { tondau = value; }
        }
        int soluongnhap;

        public int Soluongnhap
        {
            get { return soluongnhap; }
            set { soluongnhap = value; }
        }
        int toncuoi;

        public int Toncuoi
        {
            get { return toncuoi; }
            set { toncuoi = value; }
        }
    }
}
