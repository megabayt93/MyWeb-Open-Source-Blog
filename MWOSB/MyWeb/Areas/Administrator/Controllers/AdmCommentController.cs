using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmCommentController : Controller
    {
        //
        // GET: /Administrator/AdmComment/
      

        private readonly ModelComment _modelComment;

        public AdmCommentController()
        {
            _modelComment = new ModelComment();
          
        }

        public ActionResult Index(int sayfa = 1)
        {
          
            if (_modelComment.ComingCommentData(sayfa)!=null)
            {
                ViewData["setData"] = _modelComment.ComingCommentData(sayfa);
            }
            else
            {
                ViewData["setData"] = null;
            }

            return View();
        }

        public ActionResult DeleteComment(int id)
        {
           _modelComment.Delete(id);
            return RedirectToAction("Index", "AdmComment");
        }

    }
}
