using MyWebEntityLibrary;
using MyWebEntityLibrary.ContactsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MyWeb.Areas.Administrator.Models
{
   
    
    public class ModelContact
    {
        private readonly ContactsTable _contactsTable;
        private readonly MyWebContext _contactContext;

        public ModelContact()
        {
            _contactContext=new MyWebContext();
            _contactsTable=new ContactsTable();
        }

        public object ComingContactData(int id)
        {
            var comingMessage = (from p in _contactContext.Messages select p).OrderByDescending(cId => cId.MessageId).ToPagedList(id, 10);

            if (comingMessage.Count < 1)
            {
                comingMessage = null;
            }

            return comingMessage;
        }

        public object ComingContactInfo()
        {
            var comingContact = (from p in _contactContext.Contacts select p).FirstOrDefault(cId => cId.ContactId > 0);
            return comingContact;
        }
    }
}