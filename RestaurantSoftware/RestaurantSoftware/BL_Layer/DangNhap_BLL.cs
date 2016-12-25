using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantSoftware.BL_Layer
{
    class DangNhap_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public bool KiemTraQuyen(string userName, string password)
        {
            var q = from nv in dbContext.NhanViens
                    where nv.tendangnhap == userName && nv.matkhau == password
                    select nv;
            if(q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int LayIdMon(string TenMon)
        {
            IEnumerable<Mon> query = from m in dbContext.Mons where m.tenmon == TenMon select m;
            return query.First().id_mon;
        }
        public int get_IdNhanvien(string userName)
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens where nv.tendangnhap == userName select nv;
            return query.First().id_nhanvien;
        }
        public string get_TenNhanvien(string userName)
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens where nv.tendangnhap == userName select nv;
            return query.First().tennhanvien;
        }
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("OOAD"));
            }
            else keyArray = Encoding.UTF8.GetBytes("OOAD");
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string toDecrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("OOAD"));
            }
            else keyArray = Encoding.UTF8.GetBytes("OOAD");
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        } 
    }
}
