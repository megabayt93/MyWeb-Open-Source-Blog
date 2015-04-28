using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class WhatIDoController : Controller
    {
        //
        // GET: /WhatIDo/
      private  readonly MyWebContext _whatIDosContext;
        public WhatIDoController()
        {
            _whatIDosContext = new MyWebContext();
        }
        public ActionResult Index(int sayfa= 1)
        {
            return View(_whatIDosContext.WhatIDos.Where(pId => pId.PublishId == 1).OrderByDescending(wId => wId.WhatIDoID).ToPagedList(sayfa, 4));
        }

    }
}
