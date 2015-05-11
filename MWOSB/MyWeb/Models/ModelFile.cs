using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using PagedList;

namespace MyWeb.Models
{
    public class ModelFile
    {
        private readonly MyWebContext _fileContext;

        public ModelFile()
        {
            _fileContext=new MyWebContext();
        }
        public object ComingArticles(int id)
        {
            var comingData = _fileContext.Files.Where(pId => pId.PublishId == 1)
                  .OrderByDescending(fId => fId.FileID)
                  .ToPagedList(id, 4);

            return comingData;
        }
    }
}