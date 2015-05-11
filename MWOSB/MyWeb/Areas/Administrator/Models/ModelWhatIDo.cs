using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary.WhatIDoEntity;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{
    public class ModelWhatIDo
    {
        private readonly MyWebContext _whatIDoContext;
        private readonly WhatIDoTable _whatIDoTable;

        public ModelWhatIDo()
        {
            _whatIDoContext = new MyWebContext();
            _whatIDoTable = new WhatIDoTable();
        }

        public object ComingWhatIDoData(int id)
        {
            var comingWhatIDo = (from p in _whatIDoContext.WhatIDos select p).OrderByDescending(aId => aId.WhatIDoID).ToPagedList(id, 10);
            return comingWhatIDo;
        }

        public object ComingUpdateWhatIDo(int id)
        {
            var updateComing = (from p in _whatIDoContext.WhatIDos select p).Where(fID => fID.WhatIDoID == id);
            return updateComing;
        }

        public void AddArticleData(string whatIDoTitle, string whatIDoContent, string whatIDoTags, DateTime dateTime, string seoTitle, int publishId, string image)
        {
            _whatIDoTable.WhatIDoTitle = whatIDoTitle;

            _whatIDoTable.WhatIDoContent = whatIDoContent;
            _whatIDoTable.WhatIDoTags = whatIDoTags;
            _whatIDoTable.Date = dateTime;
            _whatIDoTable.SeoTitle = seoTitle;
            _whatIDoTable.PublishId = publishId;
            _whatIDoTable.WhatIDoImage = image;
            _whatIDoContext.WhatIDos.Add(_whatIDoTable);
            _whatIDoContext.SaveChanges();

        }

        public void UpdateWhatIDoData(string whatIDoTitle, string whatIDoContent, string whatIDoTags, DateTime dateTime, string seoTitle, int publishId, string image, int id)
        {
            WhatIDoTable updateWhatIDoTable = _whatIDoContext.WhatIDos.First(uId => uId.WhatIDoID == id);
            updateWhatIDoTable.WhatIDoTitle = whatIDoTitle;

            updateWhatIDoTable.WhatIDoContent = whatIDoContent;
            updateWhatIDoTable.WhatIDoTags = whatIDoTags;
            updateWhatIDoTable.Date = dateTime;
            updateWhatIDoTable.SeoTitle = seoTitle;
            updateWhatIDoTable.PublishId = publishId;
            updateWhatIDoTable.WhatIDoImage = image;
            _whatIDoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = (from p in _whatIDoContext.WhatIDos select p).FirstOrDefault(whatIDoId => whatIDoId.WhatIDoID == id);

            if (delete.WhatIDoImage != "content-icon.png")
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Content/Images/" + delete.WhatIDoImage));
            }
            _whatIDoContext.WhatIDos.Remove(delete);
            _whatIDoContext.SaveChanges();
        }

    }
}