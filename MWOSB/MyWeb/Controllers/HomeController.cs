using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWebEntityLibrary.ArticlesEntity;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ModelHome _modelHome;
        public HomeController()
        {
            _modelHome=new ModelHome();
           
        }

        public ActionResult Index()
        {    
            ViewData["setArticle"] = _modelHome.ComingArticleData();
            ViewData["setFile"] = _modelHome.ComingFileData();
            ViewData["setWhatIDo"] = _modelHome.ComingWhatIDoData();
            return View();
        }

    }
}
