using MyWebEntityLibrary;
using MyWebEntityLibrary.CommentsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWebEntityLibrary.ArticlesEntity;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class ContentDetailController : Controller
    {
        //
        // GET: /ContentDetail/
        private readonly ModelDetail _modelDetail;
        private readonly MyWebContext _detailContext;
        private readonly CommentsTable _commentTable;
        public ContentDetailController()
        {
            _detailContext = new MyWebContext();
            _commentTable = new CommentsTable();
            _modelDetail = new ModelDetail();
        }
        public ActionResult Index(string title)
        {
            try
            {

                ViewData["setComment"] = _modelDetail.ComingComment(title);
            }
            catch (Exception)
            {
            }
            return View(_modelDetail.ComingArticleDetail(title));
        }

        public ActionResult FileDetail(string title)
        {
            try
            {
                ViewData["setComment"] = _modelDetail.ComingFileComment(title);
            }
            catch (Exception)
            {
            }
            return View(_modelDetail.ComingFileDetail(title));
        }

        public ActionResult WhatIDoDetail(string title)
        {
            try
            {

                ViewData["setComment"] = _modelDetail.ComingWhatIDoComment(title);
            }
            catch (Exception)
            {
            }
            return View(_modelDetail.ComingWhatIDoDetail(title));
        }

        public ActionResult CommentAdd(string uri, string NameSurname, string ContentTitle, string Mail, string Comment, string CommentArea, int ContentId)
        { 
            _modelDetail.CommentAdd(NameSurname,ContentTitle,Mail,Comment,CommentArea,ContentId);
            return Redirect(uri);
        }



    }
}
