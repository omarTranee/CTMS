using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CTMS.Models
{
    public class PatientPic
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
        public string PicUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}