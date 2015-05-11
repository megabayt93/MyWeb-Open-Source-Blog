using MyWebEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.Administrator.Models
{
      
    public class ModelInformation
    {
        private readonly MyWebContext _admContext;

        public ModelInformation()
        {
            _admContext=new MyWebContext();
        }

        public object ComingInformation()
        {
            var updateAdm = (from p in _admContext.AdminInformations select p).First(fId => fId.AdminId > 0);
            return updateAdm;
        }

        public string AddInformation(string adminName, string oldPassword, string newPassword)
        {
            var comingAdmin = (from p in _admContext.AdminInformations select p).First(cId => cId.AdminId > 0);
            string sendInfo = "";
            if (oldPassword == comingAdmin.AdminPassword)
            {

                comingAdmin.AdminName = adminName;
                comingAdmin.AdminPassword = newPassword;
                _admContext.SaveChanges();

                sendInfo = "$('#divError').html('Şifre Güncellendi!');";
              
            }
            else
            {
                sendInfo = "$('#divError').html('Eski Şifre Uyuşmuyor!');";
               

            }

            return sendInfo;
        }
    }
}