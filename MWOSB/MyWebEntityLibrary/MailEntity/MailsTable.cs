using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.MailEntity
{
   public class MailsTable
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int MailId { get; set; }

       [Required(ErrorMessage = "Alan Boş Geçilemez")]
       public string MailSmtp { get; set; }

       [Required(ErrorMessage = "Alan Boş Geçilemez")]
       public string MailAdress { get; set; }

       [Required(ErrorMessage = "Alan Boş Geçilemez")]
       public string MailPassword { get; set; }

       public int MailPort { get; set; }
    }
}
