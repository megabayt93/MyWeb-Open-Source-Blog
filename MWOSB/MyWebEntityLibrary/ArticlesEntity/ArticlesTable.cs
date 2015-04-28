using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebEntityLibrary.ArticlesEntity
{
    public class ArticlesTable
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleID { get; set; }

        [Required(ErrorMessage=" * Makale Başlık Alanı Boş Bırakılamaz")]
        [StringLength(100,MinimumLength=1, ErrorMessage=" * Başlık Alanı maksimum 100, minimum 3 olmalı")]
        public string ArticleTitle { get; set; }
      
        public string ArticleContent { get; set; }
        public string Image { get; set; }
        
        [Required(ErrorMessage=" * Yazar Alanı Boş Bırakılamaz")]
        public string ArticleAuthor { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = " * Etiket Alanı Boş Geçilemez")]
        public string ArticleTags { get; set; }

        public int PublishId { get; set; }

        public string SeoTitle { get; set; }
   

    }
}