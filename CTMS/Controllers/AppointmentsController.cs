using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CTMS.Models;
using Microsoft.AspNet.Identity;

namespace CTMS.Controllers
{
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorImage");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // شوف هل يقصد بالبرامتر اللي ف الانكلود هل يقصد النام اللي ف 
        // html helper
        public ActionResult Create([Bind(Include = "Id,BookingDate,NumberInQueue,PatientEmail,Paid,DoctorId,PatientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorImage", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }
        #region MethdsToReturnAppointmentsTo Doctors and Patients
        [Route("appointment/patients")]
        public ActionResult GetAppointmentForPatients()
        {
            var userId = User.Identity.GetUserId();

            var patientId = db.Patients.SingleOrDefault(p => p.Patient_Id == userId);
            
            // دي هتبقي العيادات
            var appointments = db.Appointments.Include(a=>a.Doctor).Where(a => a.PatientId == patientId.Id).ToList();
            //ViewBag.Doctors = db.Appointments.SelectMany(a => a.Doctor.Name);
            return View(appointments);
        }
        [Route("/appointment/doctors")]
        public ActionResult GetAppointmentForDoctors()
        {
            var userId = User.Identity.GetUserId();

            var doctorId = db.Doctors.SingleOrDefault(p => p.PhysicianId == userId);

            // دي هتبقي العيادات
            var appointments = db.Appointments.Include(a=>a.Patient).Where(a => a.DoctorId  == doctorId.Id).ToList();

            return View(appointments);
        }
        #endregion
        // GET: Appointments/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorImage", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookingDate,NumberInQueue,PatientEmail,Paid,DoctorId,PatientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "DoctorImage", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        //  : Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
