using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MyWebEntityLibrary.SocialMediasEntity;
using System.Threading;

namespace MyWeb.Areas.Administrator.Models
{
    public class ModelSocialMedia
    {
        private readonly MyWebContext _socialContext;
        private readonly SocialMediasTable _socialMediasTable;

        public ModelSocialMedia()
        {
            _socialContext = new MyWebContext();
            _socialMediasTable = new SocialMediasTable();
        }


         public object ComingSocialData()
        {
            try
            {
                var updateSocial = (from p in _socialContext.SocialMedias select p).First(fId => fId.SocialMediasId > 0);
                return updateSocial;
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

                Thread.Sleep(1000);

                var updateSocial = (from p in _socialContext.SocialMedias select p).First(fId => fId.SocialMediasId > 0);
                return updateSocial;

            }

           
        }
        

        public void UpdateSocialMedia(string banner,string explanation,string facebook,string instagram,string twitter,string youtube,string linkedin,string github,string image)
        {
            try
            {
                var socialControl = _socialContext.SocialMedias.OrderBy(k => k.SocialMediasId > 0).First();
                socialControl.Banner = banner;
                socialControl.Explanation = explanation;
                socialControl.Facebook = facebook;
                socialControl.Instagram = instagram;
                socialControl.Twitter = twitter;
                socialControl.Youtube = youtube;
                socialControl.LinkedIn = linkedin;
                socialControl.Github = github;
                socialControl.Image = image;
               

                _socialContext.SaveChanges();

            }

            catch (Exception)
            {
                _socialMediasTable.Banner = banner;
                _socialMediasTable.Explanation = explanation;
                _socialMediasTable.Facebook = facebook;
                _socialMediasTable.Instagram = instagram;
                _socialMediasTable.Twitter = twitter;
                _socialMediasTable.Youtube = youtube;
                _socialMediasTable.LinkedIn = linkedin;
                _socialMediasTable.Github = github;
                _socialMediasTable.Image = "profil.jpg";
                _socialContext.SocialMedias.Add(_socialMediasTable);
                _socialContext.SaveChanges();


            }
        }
    }
}