
using MyWebEntityLibrary;
using MyWebEntityLibrary.SocialMediasEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmSocialMediaController : Controller
    {
        //
        // GET: /Administrator/AdmSocialMedia/

        private readonly SocialMediasTable _socialMediasTable;
        private readonly MyWebContext _socialContext;

        public AdmSocialMediaController()
        {
            _socialMediasTable = new SocialMediasTable();
            _socialContext = new MyWebContext();
        }

        public ActionResult Index()
        {
            try
            {
                var updateSocial = (from p in _socialContext.SocialMedias select p).First(fId => fId.SocialMediasId > 0);
                return View(updateSocial);
            }
            catch (Exception)
            {
                _socialMediasTable.Image = "profil.jpg";
                _socialMediasTable.Banner = "Fatih YAZICI";
                _socialMediasTable.Explanation = ".Net Dünyasında Kaybolmuş Microsoft Sever(MEGABAYT)";
                _socialMediasTable.Facebook = "https://www.facebook.com/o.bir.coder";
                _socialMediasTable.Instagram = "http://instagram.com/obircoder";
                _socialMediasTable.Twitter = "https://twitter.com/TeknodeliFatih";
                _socialMediasTable.Youtube = "https://www.youtube.com/channel/UCG_yhERI1Q8RD_aJazfcfrA";
                _socialMediasTable.LinkedIn =
                    "https://www.linkedin.com/profile/preview?locale=tr_TR&trk=prof-0-sb-preview-primary-button";
                _socialMediasTable.Github = "https://github.com/megabayt93";
                _socialContext.SocialMedias.Add(_socialMediasTable);
                _socialContext.SaveChanges();
                return RedirectToAction("Index", "AdmSocialMedia");

            }

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SocialMediaAdd(HttpPostedFileBase Image, SocialMediasTable stable)
        {


            try
            {
                var socialControl = _socialContext.SocialMedias.OrderBy(k => k.SocialMediasId > 0).First();
                socialControl.Banner = stable.Banner;
                socialControl.Explanation = stable.Explanation;
                socialControl.Facebook = stable.Facebook;
                socialControl.Instagram = stable.Instagram;
                socialControl.Twitter = stable.Twitter;
                socialControl.Youtube = stable.Youtube;
                socialControl.LinkedIn = stable.LinkedIn;
                socialControl.Github = stable.Github;

                if (Image != null)
                {
                    string filePath = Path.GetFileName(Image.FileName);
                    var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                    Image.SaveAs(uploadPath);
                    socialControl.Image = filePath;
                }

                else
                {

                    socialControl.Image = stable.Image;

                }

                _socialContext.SaveChanges();

            }

            catch (Exception)
            {
                _socialMediasTable.Banner = stable.Banner;
                _socialMediasTable.Explanation = stable.Explanation;
                _socialMediasTable.Facebook = stable.Facebook;
                _socialMediasTable.Instagram = stable.Instagram;
                _socialMediasTable.Twitter = stable.Twitter;
                _socialMediasTable.Youtube = stable.Youtube;
                _socialMediasTable.LinkedIn = stable.LinkedIn;
                _socialMediasTable.Github = stable.Github;
                _socialMediasTable.Image = "profil.jpg";
                _socialContext.SocialMedias.Add(stable);
                _socialContext.SaveChanges();


            }



            return RedirectToAction("Index", "AdmSocialMedia");


        }

    }
}
