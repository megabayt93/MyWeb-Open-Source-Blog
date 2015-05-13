using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;

namespace MyWeb.Models
{
    public class ModelHome
    {
        private readonly MyWebContext _homeContext;

        public ModelHome()
        {
            _homeContext=new MyWebContext();
        }


        public object ComingArticleData()
        {
            int countArticle = _homeContext.Articles.Count();
            int calcArticle = countArticle - 2;
            if (countArticle < 2)
            {
                calcArticle = 0;
            }

            var comingArticle = (from p in _homeContext.Articles select p).Where(pId => pId.PublishId == 1).OrderByDescending(id => id.ArticleID > 0).Skip(calcArticle).Take(2);
            return comingArticle;
        }

        public object ComingFileData()
        {
            int countFile = _homeContext.Files.Count();
            int calcFile = countFile - 2;
            if (countFile < 2)
            {
                calcFile = 0;
            }

            var comingFiles = (from p in _homeContext.Files select p).Where(pId => pId.PublishId == 1).OrderByDescending(id => id.FileID > 0).Skip(calcFile).Take(2).ToList();
            return comingFiles;
        }

        public object ComingWhatIDoData()
        {
            int countWhatIDo = _homeContext.WhatIDos.Count();
            int calcWhatIDo = countWhatIDo - 2;
            if (countWhatIDo < 2)
            {
                calcWhatIDo = 0;
            }

            var comingWhatIDo = (from p in _homeContext.WhatIDos select p).Where(pId
                => pId.PublishId == 1).OrderByDescending(id => id.WhatIDoID > 0).Skip(calcWhatIDo).Take(2).ToList();
            return comingWhatIDo;
        }
    }
}