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
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/
      private  readonly MyWebContext _articlesContext;
        public ArticlesController()
        {
            _articlesContext = new MyWebContext();
        }
        public ActionResult Index(int sayfa = 1)
        {
            return View(_articlesContext.Articles.Where(pId=>pId.PublishId==1).OrderByDescending(aId=>aId.ArticleID).ToPagedList(sayfa,4));
        }
       

    }
}
