using MyWebEntityLibrary;
using MyWebEntityLibrary.ContactsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MyWeb.Areas.Administrator.Controllers
{
    public class AdmContactController : Controller
    {
        //
        // GET: /Administrator/AdmContact/

       private readonly ContactsTable _contactsTable;
       private readonly MyWebContext _contactContext;

        public AdmContactController()
        {
            _contactContext = new MyWebContext();
            _contactsTable = new ContactsTable();
        }

        public ActionResult Index(int sayfa=1)
        {

            var comingMessage = (from p in _contactContext.Messages select p).OrderByDescending(id => id.MessageId).ToPagedList(sayfa, 10);
            if (comingMessage.Count<1)
            {
                ViewData["setData"] = null;
            }
            else
            {
                ViewData["setData"] = comingMessage;
            }


            var comingContact = (from p in _contactContext.Contacts select p).FirstOrDefault(cId => cId.ContactId > 0);

            return View(comingContact);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ContactAdd(ContactsTable contactTable)
        {
            try
            {
                ContactsTable table = (from p in _contactContext.Contacts select p).First(cID => cID.ContactId > 0);
                table.ContactInformation = contactTable.ContactInformation;
                _contactContext.SaveChanges();
            }
            catch (Exception)
            {

                ContactsTable cTable = new ContactsTable();
                cTable.ContactInformation = contactTable.ContactInformation;
                _contactContext.Contacts.Add(contactTable);
                _contactContext.SaveChanges();
            }


            return RedirectToAction("Index", "AdmContact");

        }

        public ActionResult DeleteMessage(int id)
        {
            var delete = (from p in _contactContext.Messages select p).FirstOrDefault(articleId => articleId.MessageId == id);
            _contactContext.Messages.Remove(delete);
            _contactContext.SaveChanges();
            return RedirectToAction("Index", "AdmContact");

        }

    }
}
