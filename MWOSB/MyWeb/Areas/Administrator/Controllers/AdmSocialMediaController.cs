
using MyWebEntityLibrary;
using MyWebEntityLibrary.SocialMediasEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmSocialMediaController : Controller
    {
        //
        // GET: /Administrator/AdmSocialMedia/

        private readonly SocialMediasTable _socialMediasTable;
        private readonly MyWebContext _socialContext;
        private readonly ModelSocialMedia _modelSocialMedia;

        public AdmSocialMediaController()
        {
            _socialMediasTable = new SocialMediasTable();
            _socialContext = new MyWebContext();
            _modelSocialMedia = new ModelSocialMedia();
        }

        public ActionResult Index()
        {
            return View(_modelSocialMedia.ComingSocialData());

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SocialMediaAdd(HttpPostedFileBase Image, SocialMediasTable stable)
        {

            string filePath = "";

            if (Image != null)
            {
                filePath = Path.GetFileName(Image.FileName);
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
              
            }
            else
            {

                filePath = stable.Image;

            }

            _modelSocialMedia.UpdateSocialMedia(stable.Banner, stable.Explanation, stable.Facebook, stable.Instagram,
                stable.Twitter, stable.Youtube, stable.LinkedIn, stable.Github, filePath);

            return RedirectToAction("Index", "AdmSocialMedia");


        }

    }
}
