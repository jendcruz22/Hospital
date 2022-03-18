using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using HospitalProject.Models;
using HospitalProject.Data;

namespace HospitalProject.Controllers
{
    public class StaffDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private HospitalProjectContext Hospital = new HospitalProjectContext();

        [HttpGet]
        [Route("api/staffdata/liststaffs/{searchKey?}")]
        public IEnumerable<Staff> ListStaff(string searchKey = null)
        {
            if (searchKey == null)
            {
                return Hospital.Staffs;
            }
            else
            {
                return Hospital.Staffs.Where(s => s.FName.Contains(searchKey));
            }
        }

        [HttpGet]
        [Route("api/staffdata/findstaff/{SID}")]
        public Staff FindStaff(int Id)
        {
            return Hospital.Staffs.SingleOrDefault(s => s.SID == Id);
        }

        [HttpPost]
        public void DeleteStaff(int Id)
        {
            var staff = Hospital.Staffs.SingleOrDefault(s => s.SID == Id);
            if (staff != null)
            {
                Hospital.Staffs.Remove(staff);
                Hospital.SaveChanges();
            }
        }

        [HttpPost]
        public void AddStaff(Staff newStaff)
        {
            Hospital.Staffs.Add(newStaff);
            Hospital.SaveChanges();
        }

        public void UpdateStaff(int Id, [FromBody] Staff staffInfo)
        {
            var staff = Hospital.Staffs.SingleOrDefault(p => p.SID == Id);
            if (staff != null)
            {
                staff.FName = staffInfo.FName;
                staff.LName = staffInfo.LName;
                staff.DOB = staffInfo.DOB;
                staff.Contact = staffInfo.Contact;
                staff.DID = staffInfo.DID;

                Hospital.SaveChanges();
            }
        }

    }
}
