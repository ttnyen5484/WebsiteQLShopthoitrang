using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class CartItem
    {
        QL_ShopThoiTrangEntities4 db = new QL_ShopThoiTrangEntities4();
        public string iMaSP { get; set; }
        public string iTenSp { get; set; }
        public string iAnhBia { get; set; }
        public int iDonGia { get; set; }
        public int isoluong { get; set; }

        public int ThanhTien
        {
            get { return isoluong * iDonGia; }
        }
        public CartItem(string Masp)
        {
            SANPHAM sp = db.SANPHAMs.Single(n => n.MASP == Masp);
            if (sp != null)
            {
                iMaSP = Masp;
                iTenSp = sp.TENSP;
                iAnhBia = sp.ANH;
                iDonGia = int.Parse(sp.GIA.ToString());
                isoluong = 1;
            }
        }
    }
}