using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class WhatIDoController : Controller
    {
        //
        // GET: /WhatIDo/

        private readonly ModelWhatIDo _modelWhatIDo;
        public WhatIDoController()
        {
            _modelWhatIDo = new ModelWhatIDo();

        }
        public ActionResult Index(int sayfa = 1)
        {
            return View(_modelWhatIDo.ComingWhatIDo(sayfa));
        }

    }
}
