using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebnew.Controllers
{
    public class CartController : Controller
    {
        [Authorize]
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int ID)
        {

            return RedirectToAction("Index");
        }
    }
}