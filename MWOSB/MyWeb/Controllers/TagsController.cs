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
    public class TagsController : Controller
    {
        //
        // GET: /Tags/
     
        private readonly ModelTags _modelTags;
        public TagsController()
        {
            _modelTags = new ModelTags();
           
        }
        public ActionResult Index(string title)
        {

            ViewBag.tagName = title.Replace('-', ' ');

            ViewData["articleTags"] = _modelTags.ComingTagArticleData(title);

            ViewData["fileTags"] = _modelTags.ComingTagFileData(title);

            ViewData["whatIDoTags"] = _modelTags.ComingTagWhatIDoData(title);

            return View();
        }

    }
}
