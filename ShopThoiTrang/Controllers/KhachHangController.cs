using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class KhachHangController : Controller
    {
        QL_ShopThoiTrangEntities4 db = new QL_ShopThoiTrangEntities4();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection col)
        {
            string ten = col["txtName"];
            string mk = col["txtPass"];

            KHACHHANG khach = db.KHACHHANGs.SingleOrDefault(k => k.TENDN == ten && k.PASS == mk);
            if (khach == null) //không thành công
            {
                ViewBag.tb = "Thông tin đăng nhập sai";
                return View();
            }
            //if (khach.TENDN == "Admin" && khach.PASS == "0000")
            //{
            //    return RedirectToAction("ShowSanPham", "Admin");
            //}
            Session["kh"] = khach;
            return RedirectToAction("Index", "ThoiTrang");
            
        }



        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            GioHang gio = Session["gh"] as GioHang;
            gio.dssp.Clear();
            Session["kh"] = null;
            return RedirectToAction("DangNhap", "KhachHang");
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
            var check = db.KHACHHANGs.FirstOrDefault(s => s.TENDN == kh.TENDN);
            var check1 = db.KHACHHANGs.FirstOrDefault(s => s.SDT == kh.SDT);
            var check2 = db.KHACHHANGs.FirstOrDefault(s => s.GMAIL == kh.GMAIL);
            if (check1 == null)
            {
                if(check2 == null)
                {
                    if(check == null)
                    {
                        db.KHACHHANGs.Add(kh);
                        db.SaveChanges();
                        ViewBag.tb = "Đăng ký thành công";
                        return RedirectToAction("DangNhap", "KhachHang");
                    }
                    else
                    {
                        ViewBag.tb = "Tên đăng nhập đã tồn tại";
                        return View();
                    }
                }
                else
                {
                    ViewBag.tb = "Email đã tồn tại";
                    return View();
                }

            }
            else
            {
                ViewBag.tb = "Số điện thoại đã tồn tại";
                return View();
            }
        }


    }
}