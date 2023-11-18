using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebnew.Controllers
{
    
    public class HomeController : Controller
    {
        Models.DB_WebNCEntities1 db = new Models.DB_WebNCEntities1();
        // GET: Home
        public ActionResult Index()
        {
            List<Models.SanPham> sanPham = db.SanPham.OrderByDescending(m=>m.ID_SP).ToList();
            ViewBag.sanPham = sanPham;
            return View();
        }
    }
}