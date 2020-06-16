using CTMS.Models;
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
            ViewBag.SpecialityName = db.Cities.SingleOrDefault(c => c.Id == doctor.SpecialityId);



            // السيشن دا ممكن استخدمه عشان ابعتت الايدي بتاع الدكتور مع التقديم ومع اضافت الكومنات
            Session["DoctorId"] = DoctorID;

            return View(doctor);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}