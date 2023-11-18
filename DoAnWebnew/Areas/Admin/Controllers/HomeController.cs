using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebnew.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
         /*   if (Session["NguoiDung"] == null)
            {
                return RedirectToAction("Index","Login");
            }*/
            return View();
        }
    }
}