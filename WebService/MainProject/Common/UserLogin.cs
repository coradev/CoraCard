using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainProject.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
    }
}