using MyWebEntityLibrary;
using MyWebEntityLibrary.ContactsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Areas.Administrator.Models;
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
        private readonly ModelContact _modelContact;

        public AdmContactController()
        {
            _contactContext = new MyWebContext();
            _contactsTable = new ContactsTable();
            _modelContact = new ModelContact();
        }

        public ActionResult Index(int sayfa = 1)
        {


            if (_modelContact.ComingContactData(sayfa) != null)
            {
                ViewData["setData"] = _modelContact.ComingContactData(sayfa);
            }
            else
            {
                ViewData["setData"] = null;
            }

            return View(_modelContact.ComingContactInfo());
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
