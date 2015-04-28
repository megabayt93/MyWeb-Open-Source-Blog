using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class CategoriController : Controller
    {
        //
        // GET: /Categori/

        public ActionResult Index()
        {
            return View();
        }

    }
}
