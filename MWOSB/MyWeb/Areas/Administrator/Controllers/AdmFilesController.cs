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
   
    

        private readonly ModelFiles _modelFiles;

        public AdmFilesController()
        {
            _modelFiles = new ModelFiles();
        }

        public ActionResult Index(int sayfa = 1)
        {

            ViewData["setFile"] = _modelFiles.ComingFilesData(sayfa);
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FilesAdd(HttpPostedFileBase Image, HttpPostedFileBase FileStream, bool chkPublish, FilesTable fileTable)
        {
            string filePath = "Dosya Yok!";
            string imagePath = "content-icon.png";
            int publishId = 0;
            var seoMake = Seo.Translate(fileTable.FileTitle);

            if (FileStream != null)
            {
                filePath = Path.GetFileName(FileStream.FileName);


                var uploadPath = Path.Combine(Server.MapPath("~/Content/Files/"), filePath);
                FileStream.SaveAs(uploadPath);

            }

            if (Image != null)
            {
                imagePath = Path.GetFileName(Image.FileName);
                imagePath = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), imagePath);
                Image.SaveAs(uploadPath);
            }

            if (chkPublish == true)
            {

                publishId = 1;

            }


            _modelFiles.AddFileData(fileTable.FileTitle, fileTable.FileAuthor, fileTable.FileContent,
                    fileTable.FileTags, filePath, DateTime.Now, seoMake, publishId, imagePath);

            return RedirectToAction("Index", "AdmFiles");
        }
        public ActionResult UpdateFile(int id)
        {
            ViewBag.Update = _modelFiles.ComingUpdateFile(id);
            Session["id"] = id;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateFilesAdd(HttpPostedFileBase FileImage, bool? chkPublish, FilesTable fileTable)
        {
            var seoMake = Seo.Translate(fileTable.FileTitle);
         
            string fileImage = fileTable.FileStream;
            int publishId = 0;
            if (FileImage != null)
            {
                fileImage = Path.GetFileName(FileImage.FileName);
                fileImage = seoMake + ".jpg";
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Images/"), fileImage);
                FileImage.SaveAs(uploadPath);


            }

            if (chkPublish == true)
            {

                publishId = 1;

            }

            _modelFiles.UpdateFileData(fileTable.FileTitle, fileTable.FileAuthor, fileTable.FileContent, fileTable.FileTags, DateTime.Now, seoMake, publishId, fileImage, fileTable.FileID);

            return RedirectToAction("Index", "AdmFiles");

        }

        public ActionResult DeleteFile(int id)
        {
            _modelFiles.Delete(id);
            return RedirectToAction("Index", "AdmFiles");
        }


    }
}
