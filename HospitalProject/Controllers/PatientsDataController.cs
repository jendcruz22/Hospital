using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using HospitalProject.Models;
using HospitalProject.Data;
using System.Diagnostics;

namespace HospitalProject.Controllers
{
    public class PatientsDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private HospitalProjectContext Hospital = new HospitalProjectContext();

        [HttpGet]
        [Route("api/patientdata/listpatients/{searchKey?}")]
        public IEnumerable<Patient> ListPatient(string searchKey = null)
        {
            if (searchKey == null)
            {
                return Hospital.Patients;
            }
            else
            {
                return Hospital.Patients.Where(p => p.FName.Contains(searchKey));
            }
        }

        [HttpGet]
        [Route("api/patientdata/findpatient/{PID}")]
        public Patient FindPatient(int Id)
        {
            return Hospital.Patients.SingleOrDefault(p => p.PID == Id);
        }

        [HttpPost]
        public void DeletePatient(int Id)
        {
            var patient = Hospital.Patients.SingleOrDefault(p => p.PID == Id);
            if (patient != null)
            {
                Hospital.Patients.Remove(patient);
                Hospital.SaveChanges();
            }
        }

        [HttpPost]
        public void AddPatient(Patient newPatient)
        {
            Hospital.Patients.Add(newPatient);
            Hospital.SaveChanges();
        }

        public void UpdatePatient(int Id, [FromBody] Patient patientInfo)
        {
            var patient = Hospital.Patients.SingleOrDefault(p => p.PID == Id);
            if (patient != null)
            {
                patient.FName = patientInfo.FName;
                patient.LName = patientInfo.LName;
                patient.HC = patientInfo.HC;
                patient.DOB = patientInfo.DOB;
                patient.Address = patientInfo.Address;
                patient.Contact = patientInfo.Contact;

                Hospital.SaveChanges();
            }
        }

    }
}
