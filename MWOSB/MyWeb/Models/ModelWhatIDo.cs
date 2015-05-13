using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using PagedList;

namespace MyWeb.Models
{
    public class ModelWhatIDo
    {
        private readonly MyWebContext _whatIDoContext;

        public ModelWhatIDo()
        {
            _whatIDoContext=new MyWebContext();
        }

        public object ComingWhatIDo(int id)
        {
            var comingData = _whatIDoContext.WhatIDos.Where(pId => pId.PublishId == 1)
                   .OrderByDescending(wId => wId.WhatIDoID)
                   .ToPagedList(id, 4);

            return comingData;

        }
    }
}