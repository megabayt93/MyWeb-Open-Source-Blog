using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MyWebEntityLibrary;
using MyWebEntityLibrary.MailEntity;

namespace MyWeb.Areas.Administrator.Models
{
    public class ModelMail
    {
        private readonly MailsTable _mailsTable;
        private readonly MyWebContext _mailContext;

        public ModelMail()
        {
            _mailContext = new MyWebContext();
            ;
            _mailsTable = new MailsTable();
        }

        public object ComingMailInfo()
        {
            var mailControl = _mailContext.Mails.OrderBy(m => m.MailId > 0).FirstOrDefault();
            return mailControl;
        }

        public string MailAdd(string smtp, string mail, string password,int port)
        {
            var mailControl = _mailContext.Mails.OrderBy(m => m.MailId > 0).FirstOrDefault();
            if (mailControl != null)
            {
                mailControl.MailSmtp = smtp;
                mailControl.MailAdress = mail;
                mailControl.MailPassword = password;
                mailControl.MailPort = port;
                _mailContext.SaveChanges();
            }
            else
            {
                _mailsTable.MailSmtp = smtp;
                _mailsTable.MailAdress = mail;
                _mailsTable.MailPassword = password;
                _mailsTable.MailPort = port;
                _mailContext.Mails.Add(_mailsTable);
                _mailContext.SaveChanges();
            }
            return "$('#divError').html('Mail Bilgileri Güncellendi!');";
        }
    }
}