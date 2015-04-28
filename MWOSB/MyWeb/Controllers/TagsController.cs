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
    public class TagsController : Controller
    {
        //
        // GET: /Tags/
       private readonly MyWebContext _tagsContext;
        public TagsController()
        {
            _tagsContext = new MyWebContext();
        }
        public ActionResult Index(string title)
        {



            string tag = title.Replace('-', ' ');
            ViewBag.tagName = tag;

            ViewData["articleTags"] = (from p in _tagsContext.Articles select p).OrderBy(aID => aID.ArticleID).Where(tg => tg.ArticleTags.Contains(tag));

            ViewData["fileTags"] = (from p in _tagsContext.Files select p).OrderBy(fID => fID.FileID).Where(tg => tg.FileTags.Contains(tag));

            ViewData["whatIDoTags"] = (from p in _tagsContext.WhatIDos select p).OrderBy(aID => aID.WhatIDoID).Where(tg => tg.WhatIDoTags.Contains(tag));
         

       

            return View();
        }

    }
}
