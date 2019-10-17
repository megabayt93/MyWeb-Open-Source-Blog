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
                _socialMediasTable.Facebook = "https://www.facebook.com/fyazici34";
                _socialMediasTable.Instagram = "http://instagram.com/fyazici34";
                _socialMediasTable.Twitter = "https://twitter.com/fyazici34";
                _socialMediasTable.Youtube = "https://www.youtube.com/channel/UCG_yhERI1Q8RD_aJazfcfrA";
                _socialMediasTable.LinkedIn =
                    "https://www.linkedin.com/profile/preview?locale=tr_TR&trk=prof-0-sb-preview-primary-button";
                _socialMediasTable.Github = "https://github.com/megabayt93";
                _socialMediasTable.FacebookPage = "<iframe src='//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2FYatechIndustries%3Fref%3Dhl&amp;width=300&amp;height=290&amp;colorscheme=light&amp;show_faces=true&amp;header=true&amp;stream=false&amp;show_border=false' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width: 100% !important;     background-color:white; height:290px;' allowtransparency='true'></iframe>'";
                _socialMediasTable.TwitterPage = "<a class='twitter-timeline' href='https://twitter.com/TeknodeliFatih' data-widget-id='567120614155386880'>TeknodeliFatih tarafından gönderilen tweetler</a>";
                _socialContext.SocialMedias.Add(_socialMediasTable);
                _socialContext.SaveChanges();

                Thread.Sleep(1000);

                var updateSocial = (from p in _socialContext.SocialMedias select p).First(fId => fId.SocialMediasId > 0);
                return updateSocial;

            }


        }


        public void UpdateSocialMedia(string banner, string explanation, string facebook, string instagram, string twitter, string youtube, string linkedin, string github, string image,string facebookPage,string twitterPage)
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
                socialControl.FacebookPage = facebookPage;
                socialControl.TwitterPage = twitterPage;



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
                _socialMediasTable.FacebookPage = facebookPage;
                _socialMediasTable.TwitterPage = twitterPage;
                _socialContext.SocialMedias.Add(_socialMediasTable);
                _socialContext.SaveChanges();


            }
        }
    }
}
