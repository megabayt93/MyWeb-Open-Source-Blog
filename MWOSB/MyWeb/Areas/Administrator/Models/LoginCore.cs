using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyWebEntityLibrary.AdminInformationsEntity;
using MyWebEntityLibrary;

namespace MyWeb.Models
{
    public class LoginCore : System.Web.Mvc.AuthorizeAttribute
    {
        AdminInformationsTable _adminMainTable;
        private readonly MyWebContext _loginContext;
        public LoginCore()
        {
            _adminMainTable = new AdminInformationsTable();
            _loginContext = new MyWebContext();
        }
        public bool status;
        public void Log(string userName, string userPassword)
        {
            try
            {
                AdminInformationsTable adminTable = (from p in _loginContext.AdminInformations select p).First();

                if (userName == adminTable.AdminName && userPassword == adminTable.AdminPassword)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }


            }
            catch (Exception)
            {

                _adminMainTable.AdminName = "admin";
                _adminMainTable.AdminPassword = "adminIlkParola123";
                using (MyWebContext db = new MyWebContext())
                {
                    db.AdminInformations.Add(_adminMainTable);
                    db.SaveChanges();
                }

                _adminMainTable = (from p in _loginContext.AdminInformations select p).First();


                if (userName == _adminMainTable.AdminName && userPassword == _adminMainTable.AdminPassword)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

            }

        }

    }

}
