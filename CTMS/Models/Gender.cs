﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female
    }
}