using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.SocialMediasEntity
{
    public class SocialMediasTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SocialMediasId { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Youtube { get; set; }

        public string Instagram { get; set; }

        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public string Banner { get; set; }

        public string Explanation { get; set; }

        public string Image { get; set; }

    }
}
