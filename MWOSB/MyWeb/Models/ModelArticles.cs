using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using PagedList;

namespace MyWeb.Models
{
    public class ModelArticles
    {
        private readonly MyWebContext _articlesContext;

        public ModelArticles()
        {
            _articlesContext = new MyWebContext();
        }

        public object ComingArticles(int id)
        {
          var comingData =  _articlesContext.Articles.Where(pId => pId.PublishId == 1)
                .OrderByDescending(aId => aId.ArticleID)
                .ToPagedList(id, 4);

            return comingData;
        }
    }
}