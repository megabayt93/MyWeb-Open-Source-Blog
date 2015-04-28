using MyWeb.Areas.Administrator.Models;
using MyWebEntityLibrary;
using MyWebEntityLibrary.FilesEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmFilesController : Controller
    {
        //
        // GET: /Administrator/AdmFiles/
       private readonly FilesTable _filesTable;
      private  readonly MyWebContext _filesContext;

        public AdmFilesController()
        {
            _filesTable = new FilesTable();
            _filesContext = new MyWebContext();
        }

        public ActionResult Index(int sayfa = 1)
        {
            var comingFiles = (from p in _filesContext.Files select p).OrderByDescending(aId => aId.FileID).ToPagedList(sayfa, 10);
            ViewData["setFile"] = comingFiles;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FilesAdd(HttpPostedFileBase Image, HttpPostedFileBase FileStream, bool chkPublish, FilesTable fileTable)
        {
            var seoMake = Seo.Translate(fileTable.FileTitle);
            if (FileStream != null)
            {

                string filePath = Path.GetFileName(FileStream.FileName);
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Files/"), filePath);
                FileStream.SaveAs(uploadPath);
                _filesTable.FileStream = filePath;
            }
            else
            {
                _filesTable.FileStream = "Dosya Yok";
            }
            if (Image != null)
            {
                string imagePath = Path.GetFileName(Image.FileName);
                imagePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), imagePath);
                Image.SaveAs(uploadPath);
                _filesTable.FileImage = imagePath;

            }
            else
            {

                _filesTable.FileImage = "content-icon.png";

            }
            if (chkPublish == true)
            {

                _filesTable.PublishId = 1;

            }
            else
            {
                _filesTable.PublishId = 0;
            }
            _filesTable.FileTitle = fileTable.FileTitle;
            _filesTable.FileAuthor = fileTable.FileAuthor;
            _filesTable.FileContent = fileTable.FileContent;
            _filesTable.FileTags = fileTable.FileTags;
            _filesTable.Date = DateTime.Now;
            _filesTable.SeoTitle = seoMake;
            _filesContext.Files.Add(_filesTable);
            _filesContext.SaveChanges();
            return RedirectToAction("Index", "AdmFiles");
        }
        public ActionResult UpdateFile(int id)
        {
            var updateComing = (from p in _filesContext.Files select p).Where(fID => fID.FileID == id);
            ViewBag.Update = updateComing;
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateFilesAdd(HttpPostedFileBase FileImage, bool? chkPublish, FilesTable fileTable)
        {
            var seoMake = Seo.Translate(fileTable.FileTitle);
            FilesTable updateFileTable = (from p in _filesContext.Files select p).First(uID => uID.FileID == fileTable.FileID);

            if (FileImage != null)
            {
                string filePath = Path.GetFileName(FileImage.FileName);
                filePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), filePath);
                FileImage.SaveAs(uploadPath);
                updateFileTable.FileImage = filePath;

            }
            else
            {

                updateFileTable.FileImage = fileTable.FileImage;

            }
            if (chkPublish == true)
            {

                updateFileTable.PublishId = 1;

            }
            else
            {
                updateFileTable.PublishId = 0;
            }
            updateFileTable.FileTitle = fileTable.FileTitle;
            updateFileTable.FileAuthor = fileTable.FileAuthor;
            updateFileTable.FileContent = fileTable.FileContent;
            updateFileTable.FileTags = fileTable.FileTags;
            updateFileTable.Date = DateTime.Now;
            updateFileTable.SeoTitle = seoMake;
            _filesContext.SaveChanges();

            return RedirectToAction("Index", "AdmFiles");

        }

        public ActionResult DeleteFile(int id)
        {
            var delete = (from p in _filesContext.Files select p).FirstOrDefault(articleID => articleID.FileID == id);

            if (delete.FileImage != "content-icon.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Images/" + delete.FileImage));
            }

            if (delete.FileStream!="Dosya Yok")
            {
                  System.IO.File.Delete(Server.MapPath("~/Content/Files/" + delete.FileStream));
            }
            _filesContext.Files.Remove(delete);
            _filesContext.SaveChanges();
            return RedirectToAction("Index", "AdmFiles");
        }


    }
}
