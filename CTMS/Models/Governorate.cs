using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class Governorate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }

    }
}