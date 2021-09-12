using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class ChuDeController : Controller
    {
        QL_ShopThoiTrangEntities4 db = new QL_ShopThoiTrangEntities4(); 
        // GET: ChuDe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChuDePaial()
        {
            var listChuDe = db.LOAISPs.Take(10).OrderBy(cd => cd.TENLOAI).ToList();
            return View(listChuDe);
        }
        public ViewResult SPTheoChuDe(string MaCD)
        {
            var ListSP = db.SANPHAMs.Where(s => s.MALOAI == MaCD).OrderBy(s => s.GIA).ToList();
            if (ListSP.Count == 0)
            {
                ViewBag.SP = "Tạm hết hàng";
            }
            return View(ListSP);
        }


    }
}