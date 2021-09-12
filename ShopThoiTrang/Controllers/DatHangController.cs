using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{

    public class DatHangController : Controller
    {
        QL_ShopThoiTrangEntities4 db = new QL_ShopThoiTrangEntities4();
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GioHangTrong()
        {
            return View();
        }
        public ActionResult ThemMatHang(string msp)
        {
            GioHang gio = (GioHang)Session["gh"];
            if (gio == null)
                gio = new GioHang();
            int kq = gio.Them(msp);
            Session["gh"] = gio;
            return RedirectToAction("Index", "ThoiTrang");
        }
        [HttpGet]
        public ActionResult XemGioHang()
        {
            GioHang gio = (GioHang)Session["gh"];
            //KhachHang khach = Session["kh"] as KhachHang;
            //if (khach == null)
            //{
            //    return RedirectToAction("DangNhap", "KhachHang");
            //}
            if (gio != null)
            {
                gio = Session["gh"] as GioHang;
                //ViewBag.kh = khach;
                ViewBag.tongsl = gio.tongSLHang().ToString();
                ViewBag.tongthanhtien = gio.tongThanhTien().ToString();
                return View(gio);
            }
            return RedirectToAction("GioHangTrong", "DatHang");
        }
        public ActionResult XoaGioHang(string msp)
        {
            GioHang gio = (GioHang)Session["gh"];
            CartItem sp = gio.dssp.Single(m => m.iMaSP == msp);
            if (sp != null)
            {
                gio.dssp.RemoveAll(m => m.iMaSP == msp);
                return RedirectToAction("XemGioHang", "DatHang");
            }
            else if (gio.dssp.Count == 0)
            {
                return RedirectToAction("GioHangTrong", "DatHang");
            }
            return RedirectToAction("XemGioHang", "DatHang");
        }
        public ActionResult UpdateGioHang(string msp, FormCollection f)
        {
            GioHang gio = (GioHang)Session["gh"];
            CartItem sp = gio.dssp.Single(m => m.iMaSP == msp);
            if (sp != null)
            {
                sp.isoluong = int.Parse(f["txtSoLuong"].ToString());
            }
            if (gio.dssp.Count == 0)
            {
                return RedirectToAction("GioHangTrong", "DatHang");
            }
            return RedirectToAction("XemGioHang", "DatHang");
        }
        public ActionResult XoaGioHangAll()
        {
            GioHang gio = (GioHang)Session["gh"];
            gio.dssp.Clear();
            return RedirectToAction("Index", "ThoiTrang");
        }
        public ActionResult kiemTraDH()
        {
            KHACHHANG khach = Session["kh"] as KHACHHANG;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            GioHang gio = Session["gh"] as GioHang;
            ViewBag.k = khach;
            ViewBag.tsl = gio.tongSLHang();
            ViewBag.ttt = gio.tongThanhTien();
            return View(gio);
        }
        [HttpPost]
        public ActionResult XacNhanDonHang(FormCollection col)
        {
            KHACHHANG khach = Session["kh"] as KHACHHANG;
            GioHang gio = Session["gh"] as GioHang;
            string ghiChu = col["txtGhiChu"];
            //lưu thông tin 1 dòng vào hóa đơn
            HOADON dh = new HOADON();
            dh.MAKH = khach.MAKH;
            dh.MANV = "NV01";
            dh.NGAYTAO = DateTime.Now;
            dh.THANHTOAN = gio.tongThanhTien();
            //dh.TinhTrang = Int32.Parse(tinhTrang);
            //dh.GhiChu = ghiChu;
            dh.TTTHANHTOAN = "Đang giao hàng";
            db.HOADONs.Add(dh);
            db.SaveChanges();

            foreach (CartItem item in gio.dssp)
            {
                CT_HOADON ct = new CT_HOADON();
                ct.MAHD = dh.MAHD;
                ct.MASP = item.iMaSP;
                ct.SOLUONG = item.isoluong;
                ct.GIABAN = item.iDonGia;
                ct.THANHTIEN = item.ThanhTien;
                db.CT_HOADON.Add(ct);
                db.SaveChanges();
            }
            gio.dssp.Clear();
            return View(dh);
        }


        public ActionResult HistoryOrder(int makh)
        {
            KHACHHANG khach = Session["kh"] as KHACHHANG;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            HOADON sp = db.HOADONs.SingleOrDefault(item => item.MAKH == makh);
            List<HOADON> ds_Loai = db.HOADONs.Where(s => s.MAHD == sp.MAHD).Take(8).ToList();
            ViewBag.Loai = ds_Loai;
            return View(sp);
        }
    }
}