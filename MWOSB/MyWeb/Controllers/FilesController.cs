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
    public class FilesController : Controller
    {
        //
        // GET: /Files/
       private readonly MyWebContext _filesContext;
        public FilesController()
        {
            _filesContext = new MyWebContext();
        }
        public ActionResult Index(int sayfa=1)
        {

            return View(_filesContext.Files.Where(pId => pId.PublishId == 1).OrderByDescending(fId => fId.FileID).ToPagedList(sayfa, 4));
        }

    }
}
