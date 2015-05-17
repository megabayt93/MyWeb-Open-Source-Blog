using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MyWebEntityLibrary;
using MyWebEntityLibrary.ArticlesEntity;
using MyWebEntityLibrary.CommentsEntity;
using MyWebEntityLibrary.FilesEntity;

namespace MyWeb.Models
{
    public class ModelDetail
    {
        private readonly MyWebContext _detailContext;
        private readonly CommentsTable _commentTable;

        public ModelDetail()
        {
            _detailContext=new MyWebContext();
            _commentTable=new CommentsTable();
        }

        public object ComingArticleDetail(string title)
        {
            var detailArticle = (from p in _detailContext.Articles select p).Where(pId=>pId.PublishId==1).FirstOrDefault(pId => pId.SeoTitle == title);
            return detailArticle;
        }

        public object ComingComment(string title)
        {
            var detailCommentArticle = (from p in _detailContext.Articles select p).FirstOrDefault(pId => pId.SeoTitle == title);
            var comments = (from p in _detailContext.Comments select p).Where(cId => cId.ContentId == detailCommentArticle.ArticleID).Where(ar => ar.Area == "Makaleler").OrderByDescending(cId=>cId.CommentID);
            return comments;
        }


        public object ComingFileDetail(string title)
        {
            var detailFile = (from p in _detailContext.Files select p).Where(pId => pId.PublishId == 1).FirstOrDefault(pId => pId.SeoTitle == title);
            return detailFile;
        }

        public object ComingFileComment(string title)
        {
            var detailCommentFile = (from p in _detailContext.Files select p).FirstOrDefault(pId => pId.SeoTitle == title);
            var comments = (from p in _detailContext.Comments select p).Where(cId => cId.ContentId == detailCommentFile.FileID).Where(ar => ar.Area == "Dosyalar").OrderByDescending(cId => cId.CommentID);
            return comments;
        }

        public object ComingWhatIDoDetail(string title)
        {
            var detailWhatIDo = (from p in _detailContext.WhatIDos select p).Where(pId => pId.PublishId == 1).FirstOrDefault(pId => pId.SeoTitle == title);
            return detailWhatIDo;
        }

        public object ComingWhatIDoComment(string title)
        {
            var detailCommentWhatIDo = (from p in _detailContext.WhatIDos select p).FirstOrDefault(pId => pId.SeoTitle == title);
            var comments = (from p in _detailContext.Comments select p).Where(cId => cId.ContentId == detailCommentWhatIDo.WhatIDoID).Where(ar => ar.Area == "Neler Yaparım").OrderByDescending(cId => cId.CommentID);
            return comments;
        }

        public void CommentAdd(string NameSurname, string ContentTitle, string Mail, string Comment, string CommentArea, int ContentId)
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
        }
    }
}