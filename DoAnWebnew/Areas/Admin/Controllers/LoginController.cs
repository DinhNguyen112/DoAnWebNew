using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoAnWebnew.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Models.DB_WebNCEntities1 db = new Models.DB_WebNCEntities1();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index(Models.NguoiDung obj)
        {
            //Kiểm tra đăng nhập của người dùng
            if(ModelState.IsValid)
            {
                var check = db.NguoiDung.FirstOrDefault(m=>m.USERNAME== obj.USERNAME && m.PASSWORD==obj.PASSWORD);
                if(check == null)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");

                }
                else
                {
                    //Đăng nhập thành công
                    //C1 : Lưu trạng thái người dùng vào Session
                    //Session["NguoiDung"] = check;
                    //C2 : Sử dụng Authentication Cookie để lưu trạng thái đăng nhập người dùng(true sử dụng vĩnh viễn ,false thời gian cố định
                    FormsAuthentication.SetAuthCookie(check.USERNAME, false);
                    //Them UX
                    if (Request.QueryString["ReturnUrl"] == null || Request.QueryString["ReturnUrl"] == "")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]);
                    }
                    
                    

                }
            }
            return View(obj);
        }
        public ActionResult Logout()
        {
            // Hủy Cookie đã tạo
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}