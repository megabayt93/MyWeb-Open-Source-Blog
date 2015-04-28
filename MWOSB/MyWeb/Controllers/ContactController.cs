using MyWebEntityLibrary;
using MyWebEntityLibrary.MessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
       private readonly MyWebContext _contactContext;
       private readonly MessagesTable _messageTable;
        public ContactController()
        {
            _contactContext = new MyWebContext();
            _messageTable = new MessagesTable();

        }
        public ActionResult Index()
        {
            var contactInformation = (from p in _contactContext.Contacts select p).FirstOrDefault(cId => cId.ContactId > 0);
            return View(contactInformation);
        }

        public JavaScriptResult SendMessage(string nameSurname, string mail, string content)
        {
            try
            {
                _messageTable.NameSurname = nameSurname;
                _messageTable.Mail = mail;
                _messageTable.Message = content;
                _messageTable.Date = DateTime.Now;
                _contactContext.Messages.Add(_messageTable);
                _contactContext.SaveChanges();
                string s = "$('#sendDiv').html('Mesaj Gönderildi!');";
                return JavaScript(s);  
            }
            catch (Exception)
            {
                string s = "$('#sendDiv').html('HATA! Mesaj Gönderilemedi!');";
                return JavaScript(s); throw;
            }
            
          
        }

    }
}
