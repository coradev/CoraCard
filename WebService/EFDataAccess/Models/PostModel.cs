using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class PostModel
    {
        public string PostTitle { get; set; }
        public string PostDesc { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
        public List<Tag> tags { get; set; }
    }
}
