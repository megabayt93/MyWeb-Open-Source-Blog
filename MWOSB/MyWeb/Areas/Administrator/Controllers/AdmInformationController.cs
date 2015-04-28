using MyWebEntityLibrary;
using MyWebEntityLibrary.AdminInformationsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmInformationController : Controller
    {
        //
        // GET: /Administrator/AdmInformation/
       private readonly MyWebContext _admContext;
       private readonly AdminInformationsTable _admMainTable;
        public AdmInformationController()
        {
            _admContext = new MyWebContext();
            _admMainTable = new AdminInformationsTable();
        }
        public ActionResult Index()
        {
            var updateAdm = (from p in _admContext.AdminInformations select p).First(fId => fId.AdminId > 0);
            return View(updateAdm);
        }

       

        public JavaScriptResult AdminAdd(string AdminName,string oldPassword, string newPassword)
        {
            var comingAdmin = (from p in _admContext.AdminInformations select p).First(cId => cId.AdminId > 0);

            if (oldPassword == comingAdmin.AdminPassword)
            {

                comingAdmin.AdminName = AdminName;
                comingAdmin.AdminPassword = newPassword;
                _admContext.SaveChanges();

                string s = "$('#divError').html('Şifre Güncellendi!');";
                return JavaScript(s);  
            }
            else
            {
                string s = "$('#divError').html('Eski Şifre Uyuşmuyor!');";
                return JavaScript(s);   
               
            }
           
        }

    }
}
