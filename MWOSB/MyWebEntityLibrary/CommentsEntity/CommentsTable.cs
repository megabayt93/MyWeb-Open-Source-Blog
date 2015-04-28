using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.CommentsEntity
{
   public class CommentsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [Required(ErrorMessage = "Ad Soyad Alanı Boş Bırakılamaz")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Mail Alanı Boş Bırakılamaz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Yorum Alanı Boş Bırakılamaz")]
        public string Comment { get; set; }

        public string Area { get; set; }

        public string ContentTitle { get; set; }

        public int ContentId { get; set; }

        public DateTime Date { get; set; }
    }
}
