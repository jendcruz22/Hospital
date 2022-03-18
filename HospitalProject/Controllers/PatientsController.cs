using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalProject.Models;
using System.Diagnostics;

namespace HospitalProject.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Patient/ListPatient
        [HttpGet]
        public ActionResult ListPatient(string searchKey = null)
        {
            //this class will help us gather information from the hospital database
            PatientsDataController controller = new PatientsDataController();
            IEnumerable<Patient> patients = controller.ListPatient(searchKey);
            return View(patients);
        }

        // GET : /Patient/ShowPatient/{PID}
        [HttpGet]
        [Route("Patient/ShowPatient/{PID}")]
        public ActionResult ShowPatient(int Id)
        {
            PatientsDataController controller = new PatientsDataController();
            Patient selectedPatient = controller.FindPatient(Id);

            return View(selectedPatient);
        }

        // GET : /Patient/NewPatient
        public ActionResult NewPatient()
        {
            return View();
        }

        // POST : /Patient/CreatePatient
        [HttpPost]
        public ActionResult CreatePatient(string FName, string LName, string HC, long Contact, string Address, DateTime DOB)
        {
            Patient newPatient = new Patient();
            newPatient.FName = FName;
            newPatient.LName = LName;
            newPatient.HC = HC;
            newPatient.Contact = Contact;
            newPatient.Address = Address;
            newPatient.DOB = DOB;

            PatientsDataController controller = new PatientsDataController();
            controller.AddPatient(newPatient);

            return RedirectToAction("ListPatient");
        }

        public ActionResult UpdatePatient(int Id)
        {
           PatientsDataController controller = new PatientsDataController();
           Patient selectedPatient = controller.FindPatient(Id);
           return View(selectedPatient);
        }

        [HttpPost]
        public ActionResult UpdatePatient(int Id, string FName, string LName, string HC, DateTime DOB, string Address, long Contact)
        {
            Patient patientInfo = new Patient();
            patientInfo.FName = FName;
            patientInfo.LName = LName;
            patientInfo.HC = HC;
            patientInfo.DOB = DOB;
            patientInfo.Address = Address;
            patientInfo.Contact = Contact;

            PatientsDataController controller = new PatientsDataController();
            controller.UpdatePatient(Id, patientInfo);

            return RedirectToAction("ShowPatient/" + Id);
        }

        // GET : /Patient/DeletePatientConfirm/{PID}
        public ActionResult DeletePatientConfirm(int Id)
        {
          PatientsDataController controller = new PatientsDataController();
          Patient newpatient = controller.FindPatient(Id);
          return View(newpatient);
        }

        // POST : /Patient/DeletePatient/{PID}
        [HttpPost]
        public ActionResult DeletePatient(int Id)
        {
            PatientsDataController controller = new PatientsDataController();
            controller.DeletePatient(Id);
            return RedirectToAction("ListPatient");
        }

    }
}