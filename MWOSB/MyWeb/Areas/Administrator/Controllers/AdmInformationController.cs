using MyWebEntityLibrary;
using MyWebEntityLibrary.AdminInformationsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmInformationController : Controller
    {
        //
        // GET: /Administrator/AdmInformation/
      
        private readonly ModelInformation _modelInformation;
     
        public AdmInformationController()
        {
           
            _modelInformation = new ModelInformation();
           
        }
        public ActionResult Index()
        {

            return View(_modelInformation.ComingInformation());
        }



        public JavaScriptResult AdminAdd(string AdminName, string oldPassword, string newPassword)
        {

            return JavaScript(_modelInformation.AddInformation(AdminName,oldPassword,newPassword));

        }

      
    }
}
