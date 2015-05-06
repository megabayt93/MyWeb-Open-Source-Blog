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


            ViewData["articleSearch"] = (from p in _searchContext.Articles select p).Where(tg => tg.ArticleTags.Contains(searchText)).OrderBy(aId => aId.ArticleID);

            ViewData["fileSearch"] = (from p in _searchContext.Files select p).Where(tg => tg.FileTags.Contains(searchText)).OrderBy(fId => fId.FileID);

            ViewData["whatIDoSearch"] = (from p in _searchContext.WhatIDos select p).Where(tg => tg.WhatIDoTags.Contains(searchText)).OrderBy(aId => aId.WhatIDoID);

            ViewBag.searchKeyword = searchText;
            ViewBag.searchContinue = "ile etiketlenmiş konular.";

            return View();

        }

    }
}
