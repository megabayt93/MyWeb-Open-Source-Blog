using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;
using MyWebEntityLibrary.MailEntity;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmMailController : Controller
    {
        //
        // GET: /Administrator/AdmMail/
        private readonly ModelMail _modelMail;

        public AdmMailController()
        {
            _modelMail=new ModelMail();
        }
        public ActionResult Index()
        {
            return View(_modelMail.ComingMailInfo());
        }

        public JavaScriptResult MailAdd(MailsTable mailsTable)
        {
          
            return JavaScript(_modelMail.MailAdd(mailsTable.MailSmtp, mailsTable.MailAdress, mailsTable.MailPassword,mailsTable.MailPort));
        }

    }
}
