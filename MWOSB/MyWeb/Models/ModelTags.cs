using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;

namespace MyWeb.Models
{
    public class ModelTags
    {
        private readonly MyWebContext _tagsContext;
        private string tag = "";
        public ModelTags()
        {
            _tagsContext = new MyWebContext();
        }

        public object ComingTagArticleData(string title)
        {
            tag = title.Replace('-', ' ');

            var comingArticleData =
                (from p in _tagsContext.Articles select p).Where(tg => tg.ArticleTags.Contains(tag))
                    .OrderByDescending(aId => aId.ArticleID);
            return comingArticleData;
        }

        public object ComingTagFileData(string title)
        {
            tag = title.Replace('-', ' ');
            var comingFileData = (from p in _tagsContext.Files select p).Where(tg => tg.FileTags.Contains(tag)).OrderByDescending(fId => fId.FileID);
            return comingFileData;
        }

        public object ComingTagWhatIDoData(string title)
        {
            tag = title.Replace('-', ' ');
            var comingWhatIDoData = (from p in _tagsContext.WhatIDos select p).Where(tg => tg.WhatIDoTags.Contains(tag)).OrderByDescending(wId => wId.WhatIDoID);
            return comingWhatIDoData;
        }

    }
}