using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        //
        // GET: /Search/
       private readonly MyWebContext _searchContext;
        public SearchController()
        {
            _searchContext = new MyWebContext();
        }
        public ActionResult Index(string searchText)
        {


            ViewData["articleSearch"] = (from p in _searchContext.Articles select p).OrderBy(aId => aId.ArticleID).Where(tg => tg.ArticleTags.Contains(searchText));

            ViewData["fileSearch"] = (from p in _searchContext.Files select p).OrderBy(fId => fId.FileID).Where(tg => tg.FileTags.Contains(searchText));

            ViewData["whatIDoSearch"] = (from p in _searchContext.WhatIDos select p).OrderBy(aId => aId.WhatIDoID).Where(tg => tg.WhatIDoTags.Contains(searchText));

            ViewBag.searchKeyword = searchText;
            ViewBag.searchContinue = "ile etiketlenmiş konular.";

            return View();

        }

    }
}
