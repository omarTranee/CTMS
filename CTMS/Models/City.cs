﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Governorate Governorate { get; set; }

    }
}