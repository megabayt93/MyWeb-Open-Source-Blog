using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebEntityLibrary;
using MyWebEntityLibrary.MessageEntity;

namespace MyWeb.Models
{
    public class ModelContact
    {
        private readonly MyWebContext _contactContext;
        private readonly MessagesTable _messagesTable;

        public ModelContact()
        {
            _messagesTable = new MessagesTable();
            _contactContext = new MyWebContext();
        }

        public object ComingContact()
        {
            var contactInformation = (from p in _contactContext.Contacts select p).FirstOrDefault(cId => cId.ContactId > 0);
            return contactInformation;
        }

        public string Send(string nameSurname, string mail, string content)
        {
            string info = "";
            try
            {
                _messagesTable.NameSurname = nameSurname;
                _messagesTable.Mail = mail;
                _messagesTable.Message = content;
                _messagesTable.Date = DateTime.Now;
                _contactContext.Messages.Add(_messagesTable);
                _contactContext.SaveChanges();
                info = "$('#sendDiv').html('Mesaj Gönderildi!');";
                return info;
            }
            catch (Exception)
            {
                info = "$('#sendDiv').html('HATA! Mesaj Gönderilemedi!');";
                return info; throw;
            }

        }
    }
}