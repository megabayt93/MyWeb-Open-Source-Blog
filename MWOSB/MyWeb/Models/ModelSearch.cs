using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;

namespace MyWeb.Models
{
    public class ModelSearch
    {
         private readonly MyWebContext _searchContext;

        public ModelSearch()
        {
            _searchContext=new MyWebContext();
        }

        public object ComingSearchArticleData(string searchText)
        {
            var comingArticleData = (from p in _searchContext.Articles select p).Where(tag => tag.ArticleTags.Contains(searchText)||tag.ArticleTitle.Contains(searchText)).OrderByDescending(aId => aId.ArticleID);
            return comingArticleData;
        }

        public object ComingSearchFileData(string searchText)
        {
            var comingFileData = (from p in _searchContext.Files select p).Where(tag => tag.FileTags.Contains(searchText) || tag.FileTitle.Contains(searchText)).OrderByDescending(fId => fId.FileID);
            return comingFileData;
        }

        public object ComingSearchWhatIDoData(string searchText)
        {
            var comingWhatIDoData = (from p in _searchContext.WhatIDos select p).Where(tag => tag.WhatIDoTags.Contains(searchText) || tag.WhatIDoTitle.Contains(searchText)).OrderByDescending(aId => aId.WhatIDoID);
            return comingWhatIDoData;
        }
    }
}