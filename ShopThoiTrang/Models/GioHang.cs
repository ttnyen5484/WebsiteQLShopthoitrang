using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class GioHang
    {
        public List<CartItem> dssp;
        public GioHang()
        {
            dssp = new List<CartItem>();
        }
        public GioHang(List<CartItem> lst)
        {
            dssp = lst;
        }
        public int soMatHang()
        {
            if (dssp == null)
                return 0;
            return dssp.Count();
        }
        public int tongSLHang()
        {
            if (dssp == null)
                return 0;
            return dssp.Sum(t => t.isoluong);
        }

        public int tongThanhTien()
        {
            if (dssp == null)
                return 0;
            return dssp.Sum(t => t.ThanhTien);
        }
        public int Them(string msp)
        {
            CartItem a = dssp.SingleOrDefault(i => i.iMaSP == msp);
            if (a == null) //chưa có sp trong giỏ
            {
                CartItem sp = new CartItem(msp);
                if (sp == null)
                    return -1;
                dssp.Add(sp);
            }
            else
                a.isoluong++;
            return 1;
        }
    }
}