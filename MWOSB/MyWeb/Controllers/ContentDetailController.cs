using MyWebEntityLibrary;
using MyWebEntityLibrary.CommentsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class ContentDetailController : Controller
    {
        //
        // GET: /ContentDetail/
       private readonly MyWebContext _detailContext;
       private readonly CommentsTable _commentTable;
        public ContentDetailController()
        {
            _detailContext = new MyWebContext();
            _commentTable = new CommentsTable();
        }
        public ActionResult Index(string title)
        {

            var detailArticle = (from p in _detailContext.Articles select p).FirstOrDefault(pId => pId.SeoTitle == title);

            try
            {
                var comments = (from p in _detailContext.Comments select p).Where(cID => cID.ContentId == detailArticle.ArticleID).Where(ar => ar.Area == "Makaleler").ToList();
                ViewData["setComment"] = comments;
            }
            catch (Exception)
            {

              
            } 
            return View(detailArticle);
        }

        public ActionResult FileDetail(string title)
        {
            var detailFile = (from p in _detailContext.Files select p).FirstOrDefault(pId => pId.SeoTitle == title);

            try
            {
                var comments = (from p in _detailContext.Comments select p).Where(cId => cId.ContentId == detailFile.FileID).Where(ar => ar.Area == "Dosyalar").ToList();
                ViewData["setComment"] = comments;
            }
            catch (Exception)
            {
                
               
            }
           
            return View(detailFile);
        }

        public ActionResult WhatIDoDetail(string title)
        {
            var detailWhatIDo = (from p in _detailContext.WhatIDos select p).FirstOrDefault(pId => pId.SeoTitle == title);
            try
            {
                var comments = (from p in _detailContext.Comments select p).Where(cID => cID.ContentId == detailWhatIDo.WhatIDoID).Where(ar => ar.Area == "Neler Yaparım").ToList();
                ViewData["setComment"] = comments;
            }
            catch (Exception)
            {
                
               
            }
           
            return View(detailWhatIDo);

        }

        public ActionResult CommentAdd(string uri, string NameSurname,string ContentTitle, string Mail, string Comment, string CommentArea, int ContentId)
        {
            _commentTable.Area = CommentArea;
            _commentTable.Comment = Comment;
            _commentTable.ContentId = ContentId;
            _commentTable.Date = DateTime.Now;
            _commentTable.Mail = Mail;
            _commentTable.ContentTitle = ContentTitle;
            _commentTable.NameSurname = NameSurname;
            _detailContext.Comments.Add(_commentTable);
            _detailContext.SaveChanges();

            return Redirect(uri);

           
        }

     

    }
}
