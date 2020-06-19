using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public BloodType BloodType { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }

        public string PatientEmail { get; set; }

        public string Patient_Id { get; set; }
        public ApplicationUser Patient_ { get; set; }

        public int? GovernorateId { get; set; }
        public Governorate Governorate { get; set; }

        public int? CityId { get; set; }
        public City City{ get; set; }

        
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - BirthDate.Year;
                if (BirthDate > now.AddYears(-age)) age--;
                return age;
            }

        }
        public int AppointmentId { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}