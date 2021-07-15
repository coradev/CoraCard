using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainProject.Common
{
    public static class NameNotAllow
    {
        public static readonly string[] NAME_NOT_ALLOWED = 
            { "admin", "error", "home", "login", "requireadmin", "requirelogin", "user", "users", "register" };
    }
}