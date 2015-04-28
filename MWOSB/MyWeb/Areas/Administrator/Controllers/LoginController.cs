using MyWeb.Models;
using MyWebEntityLibrary.AdminInformationsEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MyWeb.Areas.Administrator.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        //
        // GET: /Administrator/Login/

        public ActionResult Index()
        {
            return View();
        }


      private  readonly LoginCore _core;

        public LoginController()
        {
            _core = new LoginCore();
        }

        [HttpPost]
        public ActionResult LoginControl(AdminInformationsTable com)
        {
       
            if (ModelState.IsValid)
            {
                _core.Log(com.AdminName, com.AdminPassword);
                if (_core.status == true)
                {
                    const int userId = 1;
                    const string role = "Admin";
                    string userData = userId.ToString(CultureInfo.InvariantCulture) + "," + com.AdminName.Trim() + "," + role;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                 1,
                 com.AdminName,
                 DateTime.Now,
                 DateTime.Now.AddMinutes(120),
                 false,
                 userData,
                 FormsAuthentication.FormsCookiePath);

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "AdmArticles");


                }
                else
                {

                    return RedirectToAction("Index", "Login/");
                }

            }
            return View();

            
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login/");
        }

    }
}
