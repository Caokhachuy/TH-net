using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiQuanCafe
{
    public class menu
    {
        string maHang;

        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }

        string tenHang;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }

        int donGia;

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
    }
}