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


       private  readonly MyWebContext _entity;
        public HomeController()
        {
            _entity = new MyWebContext();
        }


        public ActionResult Index()
        {



            int countArticle = _entity.Articles.Count();
            int calcArticle = countArticle - 2;
            if (countArticle < 2)
            {
                calcArticle = 0;
            }



            int countFile = _entity.Files.Count();
            int calcFile = countFile - 2;
            if (countFile < 2)
            {
                calcFile = 0;
            }

            int countWhatIDo = _entity.WhatIDos.Count();
            int calcWhatIDo = countWhatIDo - 2;
            if (countWhatIDo < 2)
            {
                calcWhatIDo = 0;
            }

            var comingArticle = (from p in _entity.Articles select p).OrderBy(id => id.ArticleID > 0).Skip(calcArticle).Take(2).Where(pId => pId.PublishId == 1);
            var comingFiles = (from p in _entity.Files select p).OrderBy(id => id.FileID > 0).Skip(calcFile).Take(2).ToList().Where(pId => pId.PublishId == 1);
            var comingWhatIDo = (from p in _entity.WhatIDos select p).OrderBy(id => id.WhatIDoID > 0).Skip(calcWhatIDo).Take(2).ToList().Where(pId
                => pId.PublishId == 1);
            ViewData["setArticle"] = comingArticle;
            ViewData["setFile"] = comingFiles;
            ViewData["setWhatIDo"] = comingWhatIDo;
            return View();


        }

    }
}
