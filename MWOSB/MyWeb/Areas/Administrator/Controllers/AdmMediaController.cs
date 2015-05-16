using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmMediaController : Controller
    {
        //
        // GET: /Administrator/AdmMedia/
        private readonly ModelMedia _modelMedia;

        public AdmMediaController()
        {
            _modelMedia = new ModelMedia(); ;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(HttpPostedFileBase Image)
        {
            string imagePath = "";
            if (Image != null)
            {
                imagePath = Path.GetFileName(Image.FileName.Replace(' ', '-'));

                var uploadPath = Path.Combine(Server.MapPath("~/Content/UploadImages/"), imagePath);
                Image.SaveAs(uploadPath);
                _modelMedia.AddMedia(imagePath);
                return RedirectToAction("AllMedia", "AdmMedia");
            }

            else
            {
                return RedirectToAction("Index", "AdmMedia");
            }

        }

        public ActionResult AllMedia(int sayfa = 1)
        {
            ViewData["sendMedia"] = _modelMedia.ComingMediaData(sayfa);
            return View();
        }

        public ActionResult Delete(int id)
        {
            _modelMedia.Delete(id);
            return RedirectToAction("AllMedia", "AdmMedia");
        }

    }
}
