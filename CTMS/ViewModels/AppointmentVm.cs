using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTMS.ViewModels
{
    public class AppointmentVm
    {
        public int Id { get; set; }

        [Required]
        [ValidDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }


        public DateTime GetStartDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }




    }
}