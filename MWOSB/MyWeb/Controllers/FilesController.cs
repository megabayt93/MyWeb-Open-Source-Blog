using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class FilesController : Controller
    {
        //
        // GET: /Files/
        private readonly ModelFile _modelFile;
        public FilesController()
        {
         _modelFile=new ModelFile();
        }
        public ActionResult Index(int sayfa=1)
        {
            return View(_modelFile.ComingArticles(sayfa));
        }

    }
}
