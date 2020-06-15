using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CTMS.Models;

namespace CTMS.ViewModels
{
    public class DoctorFormViewModel
    {
        public Doctor Doctor { get; set; }
        [Required]
        public int SpecislityId { get; set; }
        public IEnumerable<Speciality> Specialities { get; set; }
        [Required]
        public int GovernorateId { get; set; }
        public IEnumerable<Governorate> Governorates { get; set; }
        [Required]
        public int CityId { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public RegisterViewModel registerViewModel { get; set; }


    }
}