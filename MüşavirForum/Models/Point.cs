using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MüşavirForum.Models
{
    [Table("Points")]
    public class Point
    {
        [Key]
        public int PointId { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }
        [Range(1, 5)]
        public int PointVal { get; set; }
        public string Date { get; set; }

    }
}