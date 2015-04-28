using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebEntityLibrary.FilesEntity
{
    public class FilesTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileID { get; set; }

        [Required(ErrorMessage = " * Başlık Boş Geçilemez")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = " * Başlık Alanı maksimum 100, minimum 3 olmalı")]
        public string FileTitle { get; set; }

        public string FileContent { get; set; }

        public string FileImage { get; set; }

        public string FileStream { get; set; }

        [Required(ErrorMessage = " * Yazar Alanı Boş Bırakılamaz")]
        public string FileAuthor { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = " * Etiket Alanı Boş Geçilemez")]
        public string FileTags { get; set; }

        public int PublishId { get; set; }

        public string SeoTitle { get; set; }


    }
}