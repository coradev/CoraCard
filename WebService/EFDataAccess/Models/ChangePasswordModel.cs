﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
