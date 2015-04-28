using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebEntityLibrary.ArticlesEntity;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {


        MyWebContext Entity;
        public HomeController()
        {
            Entity = new MyWebContext();
        }


        public ActionResult Index()
        {



            int countArticle = Entity.Articles.Count();
            int calcArticle = countArticle - 2;
            if (countArticle < 2)
            {
                calcArticle = 0;
            }



            int countFile = Entity.Files.Count();
            int calcFile = countFile - 2;
            if (countFile < 2)
            {
                calcFile = 0;
            }

            int countWhatIDo = Entity.WhatIDos.Count();
            int calcWhatIDo = countWhatIDo - 2;
            if (countWhatIDo < 2)
            {
                calcWhatIDo = 0;
            }

            var comingArticle = (from p in Entity.Articles select p).OrderBy(id => id.ArticleID > 0).Skip(calcArticle).Take(2).Where(pId => pId.PublishId == 1);
            var comingFiles = (from p in Entity.Files select p).OrderBy(id => id.FileID > 0).Skip(calcFile).Take(2).ToList().Where(pId => pId.PublishId == 1);
            var comingWhatIDo = (from p in Entity.WhatIDos select p).OrderBy(id => id.WhatIDoID > 0).Skip(calcWhatIDo).Take(2).ToList().Where(pId
                => pId.PublishId == 1);
            ViewData["setArticle"] = comingArticle;
            ViewData["setFile"] = comingFiles;
            ViewData["setWhatIDo"] = comingWhatIDo;
            return View();


        }

    }
}
