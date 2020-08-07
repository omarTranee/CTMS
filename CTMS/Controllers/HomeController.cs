using CTMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTMS.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        #region SearchOperation

        public ActionResult Index()
        {
            ViewBag.GovernorateName = db.Governorates.ToList();
            ViewBag.SpecialityName = db.Specialities.ToList();
            return View();
        }
        public JsonResult GetCityByID(int ID)
        {
            return Json(db.Cities.Where(c => c.Governorate.Id == ID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //public JsonResult GetDoctors(int stateId = -1, int cityId = -1, int categoryid = -1)
        public ActionResult GetDoctors(int stateId = -1, int cityId = -1, int categoryid = -1)

        {

            //return $" - City  : {cityId} co- State : {stateId}  -Categoery : {categoryid}";
            //return Json(db.Doctors.Where(d => d.Speciality.Id == categoryid && d.City.Id == cityId).ToList());
            ViewBag.GoveName = db.Governorates.SingleOrDefault(g => g.Id == stateId);
            ViewBag.CityName = db.Cities.SingleOrDefault(g => g.Id == cityId);
            ViewBag.SpecialityName = db.Specialities.SingleOrDefault(g => g.Id == categoryid);

            return View(db.Doctors.Where(d => d.Speciality.Id == categoryid && d.City.Id == cityId).ToList());
            //return Json(0);
        }
        #endregion
        public ActionResult Details(int DoctorID)
        {

            var doctor = db.Doctors.Find(DoctorID);
            ViewBag.GoveName = db.Governorates.SingleOrDefault(c=>c.Id== doctor.GovernorateId);
            ViewBag.CityName = db.Cities.SingleOrDefault(c => c.Id == doctor.CityId);
            ViewBag.SpecialityName = db.Specialities.SingleOrDefault(c => c.Id == doctor.SpecialityId);



            // السيشن دا ممكن استخدمه عشان ابعتت الايدي بتاع الدكتور مع التقديم ومع اضافت الكومنات
            Session["DoctorId"] = DoctorID;

            return View(doctor);
        }

        #region AppointmentActions
        [Authorize]

        // GET: Appointments/Create
        public ActionResult CreateAppointment()
        {
            //ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorImage");
            //ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        // html helper
        public ActionResult CreateAppointment( Appointment appointment)
        {
            var userId = User.Identity.GetUserId();
            int i = 1;
            var patientId = db.Patients.SingleOrDefault(p => p.Patient_Id == userId);
            appointment.PatientId = patientId.Id;
            appointment.DoctorId = (int)Session["DoctorId"];
            appointment.NumberInQueue = i++;
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(appointment);
        }


        #endregion

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DoctorLayOut()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
        public ActionResult Tables()
        {
            return View();
        }
        public ActionResult PatientLayOut()
        {
            return View();
        }



    }
}