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
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/
     
        private readonly ModelArticles _modelArticles;
        public ArticlesController()
        {
            _modelArticles=new ModelArticles();
        }
        public ActionResult Index(int sayfa = 1)
        {
            return View(_modelArticles.ComingArticles(sayfa));
        }


    }
}
