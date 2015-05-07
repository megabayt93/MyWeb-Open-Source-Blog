using MyWebEntityLibrary;
using MyWebEntityLibrary.ArticlesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{
    public class ModelArticle
    {
        private readonly MyWebContext _articlesContext;
        private readonly ArticlesTable _articlesTable;

        public ModelArticle()
        {
            _articlesContext = new MyWebContext();
            _articlesTable = new ArticlesTable();
        }

        public object ComingArticleData(int id)
        {
            var comingArticle = _articlesContext.Articles.OrderByDescending(aId => aId.ArticleID).ToPagedList(id, 10);
            return comingArticle;
        }

        public object ComingUpdateArticle(int id)
        {
            var updateComing = (from p in _articlesContext.Articles select p).Where(aId => aId.ArticleID == id);
            return updateComing;
        }

        public void AddArticleData(string articleTitle, string articleAuthor, string articleContent, string articleTags, DateTime dateTime, string seoTitle, int publishId, string image)
        {
            _articlesTable.ArticleTitle = articleTitle;
            _articlesTable.ArticleAuthor = articleAuthor;
            _articlesTable.ArticleContent = articleContent;
            _articlesTable.ArticleTags = articleTags;
            _articlesTable.Date = dateTime;
            _articlesTable.SeoTitle = seoTitle;
            _articlesTable.PublishId = publishId;
            _articlesTable.Image = image;
            _articlesContext.Articles.Add(_articlesTable);
            _articlesContext.SaveChanges();
                
        }

        public void UpdateArticleData(string articleTitle, string articleAuthor, string articleContent, string articleTags, DateTime dateTime, string seoTitle, int publishId, string image,int id)
        {
            ArticlesTable updateArticleTable = _articlesContext.Articles.First(uId => uId.ArticleID == id);
            updateArticleTable.ArticleTitle = articleTitle;
            updateArticleTable.ArticleAuthor = articleAuthor;
            updateArticleTable.ArticleContent = articleContent;
            updateArticleTable.ArticleTags = articleTags;
            updateArticleTable.Date = dateTime;
            updateArticleTable.SeoTitle = seoTitle;
            updateArticleTable.PublishId = publishId;
            updateArticleTable.Image = image;
            _articlesContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = (from p in _articlesContext.Articles select p).FirstOrDefault(articleId => articleId.ArticleID == id);

            if (delete.Image != "content-icon.png")
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Content/Images/" + delete.Image));
            }
            _articlesContext.Articles.Remove(delete);
            _articlesContext.SaveChanges();
        }
    }
}