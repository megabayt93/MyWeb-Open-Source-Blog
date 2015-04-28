using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.AdminInformationsEntity
{
    public class AdminInformationsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez")]
        public string AdminPassword { get; set; }
    }
}
