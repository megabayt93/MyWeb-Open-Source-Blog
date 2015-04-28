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
       private readonly MyWebContext _articlesContext;
       private readonly ArticlesTable _articlesTable;
        public AdmArticlesController()
        {
            _articlesTable = new ArticlesTable();
            _articlesContext = new MyWebContext();
        }

        public ActionResult Index(int sayfa=1)
        {
          
            var comingArticle=(from p in _articlesContext.Articles select p).OrderByDescending(aId=>aId.ArticleID).ToPagedList(sayfa, 10);
            ViewData["setArticle"] = comingArticle;
            return View();
             
           
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesAdd(HttpPostedFileBase Image, bool chkPublish, ArticlesTable articleTable)
        {
            var seoMake = Seo.Translate(articleTable.ArticleTitle);

            if (Image != null)
            {
                string filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
                _articlesTable.Image = filePath;

            }
            else
            {

                _articlesTable.Image = "content-icon.png";

            }
            if (chkPublish == true)
            {

                _articlesTable.PublishId = 1;

            }
            else
            {
                _articlesTable.PublishId = 0;
            }
            _articlesTable.ArticleTitle = articleTable.ArticleTitle;
            _articlesTable.ArticleAuthor = articleTable.ArticleAuthor;
            _articlesTable.ArticleContent = articleTable.ArticleContent;
            _articlesTable.ArticleTags = articleTable.ArticleTags;
            _articlesTable.Date = DateTime.Now;
            _articlesTable.SeoTitle = seoMake;
            _articlesContext.Articles.Add(_articlesTable);
            _articlesContext.SaveChanges();
            return RedirectToAction("Index", "AdmArticles");



        }
        public ActionResult UpdateArticle(int id)
        {

            var updateComing = (from p in _articlesContext.Articles select p).Where(aID => aID.ArticleID == id);
            ViewBag.Update = updateComing;
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateArticleAdd(HttpPostedFileBase Image, bool? chkPublish, ArticlesTable articleTable)
        {
            var seoMake = Seo.Translate(articleTable.ArticleTitle);
            ArticlesTable updateArticleTable = (from p in _articlesContext.Articles select p).First(uId => uId.ArticleID == articleTable.ArticleID);

            if (Image != null)
            {
                string filePath = Path.GetFileName(Image.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                Image.SaveAs(uploadPath);
                updateArticleTable.Image = filePath;

            }
            else
            {

                updateArticleTable.Image = articleTable.Image;

            }
            if (chkPublish == true)
            {

                updateArticleTable.PublishId = 1;

            }
            else
            {
                updateArticleTable.PublishId = 0;
            }
            updateArticleTable.ArticleTitle = articleTable.ArticleTitle;
            updateArticleTable.ArticleAuthor = articleTable.ArticleAuthor;
            updateArticleTable.ArticleContent = articleTable.ArticleContent;
            updateArticleTable.ArticleTags = articleTable.ArticleTags;
            updateArticleTable.SeoTitle = seoMake;
            updateArticleTable.Date = DateTime.Now;
            _articlesContext.SaveChanges();

            return RedirectToAction("Index", "AdmArticles");

        }
        public ActionResult DeleteArticle(int id)
        {
            var delete = (from p in _articlesContext.Articles select p).FirstOrDefault(articleID => articleID.ArticleID == id);

            if (delete.Image!="content-icon.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Images/" + delete.Image));
            }

            
            
            _articlesContext.Articles.Remove(delete);
            _articlesContext.SaveChanges();
            return RedirectToAction("Index", "AdmArticles");
        }

    }
}
