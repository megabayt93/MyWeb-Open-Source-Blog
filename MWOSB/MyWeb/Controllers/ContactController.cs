using MyWebEntityLibrary;
using MyWebEntityLibrary.MessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        private readonly MyWebContext _contactContext;
        private readonly ModelContact _modelContact;
        private readonly MessagesTable _messageTable;
        public ContactController()
        {
            _contactContext = new MyWebContext();
            _modelContact = new ModelContact();
            _messageTable = new MessagesTable();

        }
        public ActionResult Index()
        {

            return View(_modelContact.ComingContact());
        }

        public JavaScriptResult SendMessage(string nameSurname, string mail, string content)
        {
           return JavaScript(_modelContact.Send(nameSurname, mail, content));

        }

    }
}
