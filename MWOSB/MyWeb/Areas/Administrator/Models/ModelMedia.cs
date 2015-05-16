using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using MyWebEntityLibrary.MediasEntity;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{

    public class ModelMedia
    {
        private readonly MyWebContext _mediaContext;
        private readonly MediasTable _mediasTable;
        public ModelMedia()
        {
            _mediaContext = new MyWebContext();
            _mediasTable = new MediasTable();
        }

        public object ComingMediaData(int id)
        {
            var comingMedia = (from p in _mediaContext.Medias select p).OrderByDescending(mId => mId.MediaId).ToPagedList(id,20);
            return comingMedia;

        }

        public void AddMedia(string mediaUrl)
        {
            _mediasTable.MediaUrl = mediaUrl;
            _mediaContext.Medias.Add(_mediasTable);
            _mediaContext.SaveChanges();


        }

        public void Delete(int id)
        {
            var delete = (from p in _mediaContext.Medias select p).FirstOrDefault(mediaId => mediaId.MediaId == id);

            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Content/UploadImages/" + delete.MediaUrl));

            _mediaContext.Medias.Remove(delete);
            _mediaContext.SaveChanges();
        }
    }
}