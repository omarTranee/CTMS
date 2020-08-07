using CTMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTMS.Controllers
{
    public class PatientPicController : Controller
    {
        ApplicationDbContext db;
        public PatientPicController()
        {
            db = new ApplicationDbContext();
        }
        // GET: PatientPic
        public ActionResult AddNewPic()
        {
            int id = 1;
            var appointment = db.Appointments.Find(id);
            Session["PatientId"] = appointment.PatientId;
            return View("AddNewPic",db.PatientPics.ToList());
        }
        public ActionResult SaveData(PatientPic Pic)
        {
            var userId = User.Identity.GetUserId();
            var doctorId = db.Doctors.SingleOrDefault(p => p.PhysicianId == userId);


            if (Pic.Note != null && Pic.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(Pic.ImageUpload.FileName);
                string extension = Path.GetExtension(Pic.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                Pic.PicUrl = fileName;
                Pic.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
                Pic.DoctorId = doctorId.Id;
                Pic.PatientId = (int)Session["PatientId"];
                db.PatientPics.Add(Pic);
                db.SaveChanges();
            }

            var result = "Successfully Added";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}