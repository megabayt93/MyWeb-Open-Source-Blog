using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using MyWebEntityLibrary.SeoContent;

namespace MyWeb.Areas.Administrator.Models
{
    public class ModelSeo
    {
        private readonly SeoContentsTable _seoContentsTable;
        private readonly MyWebContext _seoContext;

        public ModelSeo()
        {
            _seoContentsTable=new SeoContentsTable();
            _seoContext=new MyWebContext();
        }

        public object ComingSeoInfo()
        {
            var seoInfo = _seoContext.SeoContentsTables.FirstOrDefault();
            return seoInfo;
        }

        public string SeoAdd(string author, string description, string keywords)
        {
            var seoControl = _seoContext.SeoContentsTables.FirstOrDefault();
            if (seoControl != null)
            {
                seoControl.Author = author;
                seoControl.Description = description;
                seoControl.Keywords = keywords;

                _seoContext.SaveChanges();
            }
            else
            {
                _seoContentsTable.Author = author;
                _seoContentsTable.Description = description;
                _seoContentsTable.Keywords = keywords;
                _seoContext.SeoContentsTables.Add(_seoContentsTable);
                _seoContext.SaveChanges();
            }
            return "$('#divError').html('Seo Bilgileri Güncellendi!');";
        }
    }
}