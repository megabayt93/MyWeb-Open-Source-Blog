using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{

    public class ModelComment
    {

        private readonly MyWebContext _commentContext;

        public ModelComment()
        {
            _commentContext=new MyWebContext();
        }

        public object ComingCommentData(int id)
        {
            var comingComments = (from p in _commentContext.Comments select p).OrderByDescending(cId => cId.CommentID).ToPagedList(id, 20);

            if (comingComments.Count < 1)
            {
                comingComments = null;
            }
          

            return comingComments;
        }

        public void Delete(int id)
        {
            var delete = (from p in _commentContext.Comments select p).FirstOrDefault(cId => cId.CommentID == id);
            _commentContext.Comments.Remove(delete);
            _commentContext.SaveChanges();
        }

    }
}