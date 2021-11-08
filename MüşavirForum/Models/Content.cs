using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MüşavirForum.Models
{
    [Table("Contents")]
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        [Required]
        [StringLength(1500, MinimumLength = 6)]
        public string ContentDetail { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }

    }
}