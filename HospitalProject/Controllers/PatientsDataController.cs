using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using HospitalProject.Models;
using HospitalProject.Data;

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
                return Hospital.Patients.Where(m => m.FName.Contains(searchKey));
            }
        }

        [HttpGet]
        [Route("api/patientdata/findpatient/{id}")]
        public Patient FindPatient(int id)
        {
            return Hospital.Patients.SingleOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void DeletePatient(int id)
        {
            var patient = Hospital.Patients.SingleOrDefault(p => p.Id == id);
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

        public void UpdatePatient(int id, [FromBody] Patient patientInfo)
        {
            var patient = Hospital.Patients.SingleOrDefault(p => p.Id == id);
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
