using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EFDataAccess.Models
{
    public class EditProfileModel
    {
        public int UserId { get; set; }

        [Display(Name = "Avatar")]
        public string UserAvatar { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Enter name")]
        public string UserFullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Enter bio")]
        public string UserBio { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}
