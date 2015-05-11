using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary.FilesEntity;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{

    public class ModelFiles
    {
        private readonly MyWebContext _filesContext;
        private readonly FilesTable _filesTable;
        public ModelFiles()
        {
            _filesTable = new FilesTable();
            _filesContext = new MyWebContext();

        }

        public object ComingFilesData(int id)
        {
            var comingFiles = (from p in _filesContext.Files select p).OrderByDescending(aId => aId.FileID).ToPagedList(id, 10);

            return comingFiles;
        }

        public object ComingUpdateFile(int id)
        {
            var updateComing = (from p in _filesContext.Files select p).Where(fId => fId.FileID == id);
            return updateComing;
        }

        public void AddFileData(string fileTitle, string fileAuthor, string fileContent, string fileTags,string stream, DateTime dateTime, string seoTitle, int publishId, string image)
        {
            _filesTable.FileTitle = fileTitle;
            _filesTable.FileAuthor = fileAuthor;
            _filesTable.FileContent = fileContent;
            _filesTable.FileTags = fileTags;
            _filesTable.FileStream = stream;
            _filesTable.Date = dateTime;
            _filesTable.SeoTitle = seoTitle;
            _filesTable.PublishId = publishId;
            _filesTable.FileImage = image;
            _filesContext.Files.Add(_filesTable);
            _filesContext.SaveChanges();

        }

        public void UpdateFileData(string fileTitle, string fileAuthor, string fileContent, string fileTags, DateTime dateTime, string seoTitle, int publishId, string image, int id)
        {
            FilesTable updateFileTable = _filesContext.Files.First(uId => uId.FileID == id);
            updateFileTable.FileTitle = fileAuthor;
            updateFileTable.FileAuthor = fileAuthor;
            updateFileTable.FileContent = fileContent;
            updateFileTable.FileTags = fileTags;
            updateFileTable.Date = dateTime;
            updateFileTable.SeoTitle = seoTitle;
            updateFileTable.PublishId = publishId;
            updateFileTable.FileImage = image;
            _filesContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var delete = (from p in _filesContext.Files select p).FirstOrDefault(fId => fId.FileID == id);

            if (delete.FileImage != "content-icon.png")
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Content/Images/" + delete.FileImage));
            }
            _filesContext.Files.Remove(delete);
            _filesContext.SaveChanges();
        }
    }
}