using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            var contactInformation =
                (from p in _contactContext.Contacts select p).FirstOrDefault(cId => cId.ContactId > 0);
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


                var mailControl = _contactContext.Mails.OrderBy(m => m.MailId > 0).FirstOrDefault();
                if (mailControl!=null)
                {
                    SmtpClient smtpServer = new SmtpClient(mailControl.MailSmtp, mailControl.MailPort);
                    var sendMail = new MailMessage();
                    sendMail.From = new MailAddress(mailControl.MailAdress);
                    sendMail.To.Add(mailControl.MailAdress);
                    sendMail.Subject = "Mesaj Gönderildi";
                    sendMail.IsBodyHtml = true;
                    sendMail.Body =
                        "<html><body><b>YENİ BİR MESAJ VAR!</b><br><br><b>Bilgiler Aşağıdaki Gibidir.</b><br><br>Mesaj Gönderenin<br> İsmi: " +
                        nameSurname + " <br>e-Mail: " + mail + "<br>Mesaj: " + content + "</body></html>";
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new System.Net.NetworkCredential(mailControl.MailAdress,
                        mailControl.MailPassword);
                    smtpServer.Send(sendMail);
                    return info;
                }
                else
                {
                   
                    return info;
                }
             
            }
            catch (Exception ex)
            {
                info = "$('#sendDiv').html('HATA! Mesaj Gönderilemedi!');";
                return info;
            }


        }

    }
}
