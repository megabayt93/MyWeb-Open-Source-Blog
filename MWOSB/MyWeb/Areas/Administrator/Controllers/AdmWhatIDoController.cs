using MyWeb.Areas.Administrator.Models;
using MyWebEntityLibrary;
using MyWebEntityLibrary.WhatIDoEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmWhatIDoController : Controller
    {
        //
        // GET: /Administrator/AdmWhatIDo/
     
       
        private readonly ModelWhatIDo _modelWhatIDo;

        public AdmWhatIDoController()
        {
           
        
            _modelWhatIDo = new ModelWhatIDo();

        }

        public ActionResult Index(int sayfa = 1)
        {

            ViewData["setWhatIDo"] = _modelWhatIDo.ComingWhatIDoData(sayfa);
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WhatIDoAdd(HttpPostedFileBase Image, bool chkPublish, WhatIDoTable whatIDoTable)
        {
            var seoMake = Seo.Translate(whatIDoTable.WhatIDoTitle);
            string filePath = "content-icon.png";
            int publishId = 0;
            if (Image != null)
            {
                filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);


            }

            if (chkPublish == true)
            {

                publishId = 1;

            }

            _modelWhatIDo.AddArticleData(whatIDoTable.WhatIDoTitle, whatIDoTable.WhatIDoContent,
                whatIDoTable.WhatIDoTags, DateTime.Now, seoMake, publishId, filePath);

            return RedirectToAction("Index", "AdmWhatIDo");



        }

        public ActionResult UpdateWhatIdo(int id)
        {

            ViewBag.Update = _modelWhatIDo.ComingUpdateWhatIDo(id);
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateWhatIDoAdd(HttpPostedFileBase Image, bool? chkPublish, WhatIDoTable whatIDoTable)
        {
            var seoMake = Seo.Translate(whatIDoTable.WhatIDoTitle);
            string filePath = whatIDoTable.WhatIDoImage;
            int publishId = whatIDoTable.PublishId;

            if (Image != null)
            {
                filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
            }

            if (chkPublish == true)
            {

                publishId = 1;

            }
            _modelWhatIDo.UpdateWhatIDoData(whatIDoTable.WhatIDoTitle, whatIDoTable.WhatIDoContent,
                whatIDoTable.WhatIDoTags, DateTime.Now, seoMake, publishId, filePath, whatIDoTable.WhatIDoID);

            return RedirectToAction("Index", "AdmWhatIDo");

        }

        public ActionResult DeleteWhatIDo(int id)
        {
            _modelWhatIDo.Delete(id);
            return RedirectToAction("Index", "AdmWhatIDo");
        }

    }
}
