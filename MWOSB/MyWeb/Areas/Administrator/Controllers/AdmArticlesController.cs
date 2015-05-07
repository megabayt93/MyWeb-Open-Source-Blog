using MyWeb.Areas.Administrator.Models;
using MyWebEntityLibrary;
using MyWebEntityLibrary.ArticlesEntity;
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

    [myAuthorize(Roles = "Admin")]
    public class AdmArticlesController : Controller
    {
        //
        // GET: /Administrator/AdmArticles/
      
        private readonly ArticlesTable _articlesTable;
        private readonly ModelArticle _modelArticle;
        public AdmArticlesController()
        {
            _modelArticle = new ModelArticle();
            _articlesTable = new ArticlesTable();
           
        }

        public ActionResult Index(int sayfa = 1)
        {
            ViewData["setArticle"] = _modelArticle.ComingArticleData(sayfa);
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesAdd(HttpPostedFileBase Image, bool chkPublish, ArticlesTable articleTable)
        {
            var seoMake = Seo.Translate(articleTable.ArticleTitle);
            string filePath = "content-icon.png";
            const int publishId = 0;
            if (Image != null)
            {
                filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);

            }

            if (chkPublish == true)
            {

                _articlesTable.PublishId = 1;

            }

            _modelArticle.AddArticleData(articleTable.ArticleTitle, articleTable.ArticleAuthor,
                    articleTable.ArticleContent, articleTable.ArticleTags, DateTime.Now, seoMake, publishId, filePath);
            return RedirectToAction("Index", "AdmArticles");
        }
        public ActionResult UpdateArticle(int id)
        {
            ViewBag.Update = _modelArticle.ComingUpdateArticle(id);
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateArticleAdd(HttpPostedFileBase Image, bool? chkPublish, ArticlesTable articleTable)
        {
            var seoMake = Seo.Translate(articleTable.ArticleTitle);

            string filePath = articleTable.Image;
            int PublishId = articleTable.PublishId;
            if (Image != null)
            {
                filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
            }

            if (chkPublish == true)
            {
                PublishId = 1;
            }
            else
            {
                PublishId = 0;
            }

            _modelArticle.UpdateArticleData(articleTable.ArticleTitle, articleTable.ArticleAuthor,
                articleTable.ArticleContent, articleTable.ArticleTags, DateTime.Now, seoMake, PublishId, filePath, articleTable.ArticleID);

            return RedirectToAction("Index", "AdmArticles");

        }
        public ActionResult DeleteArticle(int id)
        {
           
            _modelArticle.Delete(id);
            return RedirectToAction("Index", "AdmArticles");
        }

    }
}
