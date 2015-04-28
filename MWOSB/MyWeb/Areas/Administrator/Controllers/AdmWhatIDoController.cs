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
       private readonly WhatIDoTable _whatIDoTableTable;
       private readonly MyWebContext _whatIDoContext;

        public AdmWhatIDoController()
        {
            _whatIDoTableTable = new WhatIDoTable();
            _whatIDoContext = new MyWebContext();

        }

        public ActionResult Index(int sayfa=1)
        {
            var comingWhatIDo = (from p in _whatIDoContext.WhatIDos select p).OrderByDescending(aId => aId.WhatIDoID).ToPagedList(sayfa, 10);
            ViewData["setWhatIDo"] = comingWhatIDo;
            return View();           
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WhatIDoAdd(HttpPostedFileBase Image, bool chkPublish, WhatIDoTable whatIDoTable)
        {
            var seoMake = Seo.Translate(whatIDoTable.WhatIDoTitle);
            if (Image != null)
            {
                string filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
                _whatIDoTableTable.WhatIDoImage = filePath;

            }
            else
            {

                _whatIDoTableTable.WhatIDoImage = "content-icon.png";

            }
            if (chkPublish == true)
            {

                _whatIDoTableTable.PublishId = 1;

            }
            else
            {
                _whatIDoTableTable.PublishId = 0;
            }
            _whatIDoTableTable.WhatIDoTitle = whatIDoTable.WhatIDoTitle;

            _whatIDoTableTable.WhatIDoContent = whatIDoTable.WhatIDoContent;
            _whatIDoTableTable.WhatIDoTags = whatIDoTable.WhatIDoTags;
            _whatIDoTableTable.Date = DateTime.Now;
            _whatIDoTableTable.SeoTitle = seoMake;
            _whatIDoContext.WhatIDos.Add(_whatIDoTableTable);
            _whatIDoContext.SaveChanges();
            return RedirectToAction("Index", "AdmWhatIDo");



        }

        public ActionResult UpdateWhatIdo(int id)
        {
           
            var updateComing = (from p in _whatIDoContext.WhatIDos select p).Where(fID => fID.WhatIDoID == id);
         
            ViewBag.Update = updateComing;
           
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateWhatIDoAdd(HttpPostedFileBase Image, bool? chkPublish, WhatIDoTable whatIDoTable)
        {
            var seoMake = Seo.Translate(whatIDoTable.WhatIDoTitle);
            WhatIDoTable updateWhatIDoTable = (from p in _whatIDoContext.WhatIDos select p).First(uId => uId.WhatIDoID == whatIDoTable.WhatIDoID);

            if (Image != null)
            {
                string filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
                updateWhatIDoTable.WhatIDoImage = filePath;

            }
            else
            {

                updateWhatIDoTable.WhatIDoImage = whatIDoTable.WhatIDoImage;

            }
            if (chkPublish == true)
            {

                updateWhatIDoTable.PublishId = 1;

            }
            else
            {
                updateWhatIDoTable.PublishId = 0;
            }
            updateWhatIDoTable.WhatIDoTitle = whatIDoTable.WhatIDoTitle;

            updateWhatIDoTable.WhatIDoContent = whatIDoTable.WhatIDoContent;
            updateWhatIDoTable.WhatIDoTags = whatIDoTable.WhatIDoTags;
            updateWhatIDoTable.Date = DateTime.Now;
            updateWhatIDoTable.SeoTitle = seoMake;
            _whatIDoContext.SaveChanges();

            return RedirectToAction("Index", "AdmWhatIDo");

        }

        public ActionResult DeleteWhatIDo(int id)
        {



            var delete = (from p in _whatIDoContext.WhatIDos select p).FirstOrDefault(whatidoId => whatidoId.WhatIDoID == id);

            if (delete.WhatIDoImage != "content-icon.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Images/" + delete.WhatIDoImage));
            }
            
            _whatIDoContext.WhatIDos.Remove(delete);
            _whatIDoContext.SaveChanges();
            return RedirectToAction("Index", "AdmWhatIDo");
        }

    }
}
