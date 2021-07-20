using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainProject.Models
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Enter your email")]
        public string MailTo { get; set; }

        public string MailSubject { get; set; }
        
        public string MailContent { get; set; }
    }
}