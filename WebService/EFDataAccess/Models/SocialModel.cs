using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EFDataAccess.Models
{
    public class SocialModel
    {
        [Required(ErrorMessage = "Enter name")]
        public string SocialName { get; set; }

        [Required(ErrorMessage = "Enter link")]
        public string SocialLink { get; set; }
        
        public string SocialImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
