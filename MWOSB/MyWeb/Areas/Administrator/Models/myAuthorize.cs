using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWeb.Areas.Administrator.Models
{
    public class myAuthorize : AuthorizeAttribute
    {
        private readonly List<string> _allowedroles = new List<string>();
        public myAuthorize()
        {
            List<string> roles = new List<string>(); // Rolleri oluşturturuyoruz
            roles.Add("Admin");
            roles.Add("TestRolü");

            _allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string userRole = null;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName]; // Cookie yi alıyoruz
            if (authCookie != null) // Cokie boş değil ise
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value); // Cookie şifresini kaldırıyoruz

                string[] roles = authTicket.UserData.Split(new[] { ',' }); // , e göre ayırıyoruz

                userRole = roles[2]; // Kullanıcı rolü [3]'den geliyor. 2. virgüle göre split ediyoruz
            }


            bool authorize = false;


            foreach (var role in _allowedroles) // Roller içinde foreach ile dönüyoruz
            {
                if (userRole == role) // Eğer kullanıcının rolü "AdminTestRol" ise 
                {
                    authorize = true; // Yetkiyi true yapıyoruz ve ActionResult'a erişme hakkı  veriyoruz
                    return authorize;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}