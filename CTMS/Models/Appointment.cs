using CTMS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime BookingDate { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        //[ValidDate]
        //public string Date { get; set; }
        public int? NumberInQueue { get; set; }
        public string PatientEmail { get; set; }

        public bool? Paid { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}