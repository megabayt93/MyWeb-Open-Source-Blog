using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        private readonly ModelSearch _modelSearch;
        public SearchController()
        {
            _modelSearch = new ModelSearch();

        }
        public ActionResult Index(string searchText)
        {


            ViewData["articleSearch"] = _modelSearch.ComingSearchArticleData(searchText);

            ViewData["fileSearch"] = _modelSearch.ComingSearchFileData(searchText);

            ViewData["whatIDoSearch"] = _modelSearch.ComingSearchWhatIDoData(searchText);

                
         
            ViewBag.searchKeyword = searchText;
            ViewBag.searchContinue = "ile etiketlenmiş konular aşağıdadır.";

            return View();

        }

    }
}
