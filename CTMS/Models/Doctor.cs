using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [DisplayName("Your Image")]
        public string DoctorImage { get; set; }
        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public int Price { get; set; }
        public string DoctorEmail { get; set; }


        public string DoctorInformation { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
        [Required]
        public string PhysicianId { get; set; }
        public ApplicationUser Physician { get; set; }
        [Required]
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }

        public int AppointmentId { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }


    }
}