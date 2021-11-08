using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MüşavirForum.Models
{

    [Table("Topics")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(1500, MinimumLength = 30)]
        public string Content { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public string Seo { get; set; }


    }


}