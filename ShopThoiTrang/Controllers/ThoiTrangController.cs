using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class ThoiTrangController : Controller
    {
        QL_ShopThoiTrangEntities4 db = new QL_ShopThoiTrangEntities4();
        // GET: ThoiTrang
        public ActionResult Index()
        {
            List<SANPHAM> ds = db.SANPHAMs.ToList();
            return View(ds);
        }
        public ActionResult Details(string msp)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(item => item.MASP == msp);
            List<SANPHAM> ds_Loai = db.SANPHAMs.Where(s => s.MALOAI == sp.MALOAI).Take(8).ToList();
            ViewBag.Loai = ds_Loai;
            return View(sp);
        }
        public ActionResult KhoiTaoLayout()
        {
            GioHang gio = (GioHang)Session["gh"];
            return PartialView(gio);
        }

        public ActionResult KhoiTaoTen()
        {

            //bổ sung
            KHACHHANG Khach = Session["kh"] as KHACHHANG;
            ViewBag.kh = Khach;
            //
            return PartialView(Khach);
        }
        public ActionResult Search(FormCollection col)
        {
            string keyword = col["txtsearch"];
            List<SANPHAM> dssp = db.SANPHAMs.Where(s => s.TENSP.Contains(keyword)).ToList();
            ViewBag.tb = "Tìm Kiếm " + keyword.ToString();
            return View("Index", dssp);
        }
        public ActionResult ThoiTrangNam()
        {
            List<SANPHAM> msp = db.SANPHAMs.ToList();
            return View(msp);
        }
        public ActionResult ThoiTrangNu()
        {
            List<SANPHAM> msp = db.SANPHAMs.ToList();
            return View(msp);
        }
    }
}