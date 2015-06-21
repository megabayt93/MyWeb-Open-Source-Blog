using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;
using MyWebEntityLibrary.SeoContent;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmSeoSettingsController : Controller
    {
        //
        // GET: /Administrator/AdmSeoSettings/
        private readonly ModelSeo _modelSeo;

        public AdmSeoSettingsController()
        {
            _modelSeo = new ModelSeo();
        }
        public ActionResult Index()
        {
            return View(_modelSeo.ComingSeoInfo());
        }

        public JavaScriptResult SeoAdd(SeoContentsTable seoContentsTable)
        {

            return
                JavaScript(_modelSeo.SeoAdd(seoContentsTable.Author, seoContentsTable.Description,
                    seoContentsTable.Keywords));
        }

    }
}
