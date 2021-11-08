using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MüşavirForum.Models
{
    [Table("Categories")]
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(90, MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [StringLength(180, MinimumLength = 6)]
        public string Description { get; set; }
        public string Seo { get; set; }
        public int ParentId { get; set; }
        public int Status { get; set; }

    }
}