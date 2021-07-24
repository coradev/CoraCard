using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Models
{
    public class PostModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Enter title")]
        public string PostTitle { get; set; }

        [Required(ErrorMessage = "Enter description")]
        public string PostDesc { get; set; }

        [Required(ErrorMessage = "Enter content")]
        [AllowHtml]
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
    }
}