using DoAnWebnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebnew.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        Models.DB_WebNCEntities1 db = new Models.DB_WebNCEntities1();
        // GET: Admin/Product
        public ActionResult Index()
        {
            List<Models.SanPham> data  = db.SanPham.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ID_LOAI = new SelectList(db.LoaiSP.ToList(), "ID_LOAI", "TENlOAI");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.SanPham obj) 
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var fImage = Request.Files["fImage"];
                    if(fImage != null && fImage.ContentLength > 0) { 
                        string fName = fImage.FileName;
                        string fullSavePath = Server.MapPath("~/Assets/Uploads/" + fName);
                        fImage.SaveAs(fullSavePath);
                        obj.HINHANH = "/Assets/Uploads/" + fName;
                    }
                    db.SanPham.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {

                }
            }

            ViewBag.ID_LOAI = new SelectList(db.LoaiSP.ToList(), "ID_LOAI", "TENlOAI");
            return View(obj);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var obj = db.SanPham.Find(ID);
            if(obj == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ID_LOAI = new SelectList(db.LoaiSP.ToList(), "ID_LOAI", "TENlOAI");
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Models.SanPham obj)
        {
            try
            {
                Models.SanPham crrobj = db.SanPham.Find(obj.ID_SP);
                
                crrobj.TENSP = obj.TENSP;
                crrobj.GIA = obj.GIA;
                var fImage = Request.Files["fImage"];
                if (fImage != null && fImage.ContentLength > 0)
                {
                    string fName = fImage.FileName;
                    string fullSavePath = Server.MapPath("~/Assets/Uploads/" + fName);
                    fImage.SaveAs(fullSavePath);
                    obj.HINHANH = "/Assets/Uploads/" + fName;
                }
                crrobj.HANSUDUNG = obj.HANSUDUNG;
                crrobj.COSAN = obj.COSAN;

                crrobj.MOTA =obj.MOTA;
                crrobj.ID_LOAI =obj.ID_LOAI;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {

            }
            ViewBag.ID_LOAI = new SelectList(db.LoaiSP.ToList(), "ID_LOAI", "TENlOAI");
            return View(obj);
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Models.SanPham obj = db.SanPham.Find(ID);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConFirm(int ID)
        {
            try
            {
                Models.SanPham obj = db.SanPham.Find(ID);
                if (obj != null)
                {
                    db.SanPham.Remove(obj);

                    db.SaveChanges();

                }

            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
        
    }
}