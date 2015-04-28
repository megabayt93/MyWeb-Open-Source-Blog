using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyWebEntityLibrary.MessageEntity
{
    public class MessagesTable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Mail alanı boş geçilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş geçilemez")]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
