using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebEntityLibrary.WhatIDoEntity
{
    public class WhatIDoTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WhatIDoID { get; set; }

        [Required(ErrorMessage = " * Başlık Alanı Boş Bırakılamaz")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = " * Başlık Alanı maksimum 100, minimum 3 olmalı")]
        public string WhatIDoTitle { get; set; }

        public string WhatIDoContent { get; set; }

        public string WhatIDoImage { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage=" * Etiket Alanı Boş Geçilemez")]
        public string WhatIDoTags { get; set; }

        public int PublishId { get; set; }

        public string SeoTitle { get; set; }

    }
}