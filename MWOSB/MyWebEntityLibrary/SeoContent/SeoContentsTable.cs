using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.SeoContent
{
    public class SeoContentsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeoId { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string Author { get; set; }

    }
}
