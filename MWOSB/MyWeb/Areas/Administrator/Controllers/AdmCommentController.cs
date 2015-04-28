using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmCommentController : Controller
    {
        //
        // GET: /Administrator/AdmComment/
      private  readonly MyWebContext _commentContext;

        public AdmCommentController()
        {
          _commentContext = new MyWebContext();
        }

        public ActionResult Index(int sayfa=1)
        {
            var comingComments = (from p in _commentContext.Comments select p).OrderByDescending(id => id.CommentID).ToPagedList(sayfa, 20);
            if (comingComments.Count<1)
            {
                ViewData["setData"] = null;
            }
            else
            {
                ViewData["setData"] = comingComments;
            }
           
            return View();
        }

        public ActionResult DeleteComment(int id)
        {
            var delete = (from p in _commentContext.Comments select p).FirstOrDefault(articleID => articleID.CommentID == id);
            _commentContext.Comments.Remove(delete);
            _commentContext.SaveChanges();
            return RedirectToAction("Index", "AdmComment");
        }

    }
}
