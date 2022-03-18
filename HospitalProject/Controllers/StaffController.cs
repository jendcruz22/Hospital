using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalProject.Models;
using System.Diagnostics;

namespace HospitalProject.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Staff/ListStaff
        [HttpGet]
        public ActionResult ListStaff(string searchKey = null)
        {
            //this class will help us gather information from the hospital database
            StaffDataController controller = new StaffDataController();
            IEnumerable<Staff> staffs = controller.ListStaff(searchKey);
            return View(staffs);
        }

        // GET : /Staff/ShowStaff/{SID}
        [HttpGet]
        [Route("Staff/ShowStaff/{SID}")]
        public ActionResult ShowStaff(int Id)
        {
            StaffDataController controller = new StaffDataController();
            Staff selectedStaff = controller.FindStaff(Id);

            return View(selectedStaff);
        }

        // GET : /Staff/NewStaff
        public ActionResult NewStaff()
        {
            return View();
        }

        // POST : /Staff/CreateStaff
        [HttpPost]
        public ActionResult CreateStaff(string FName, string LName, DateTime DOB, long Contact, string DID)
        {
            Staff newStaff = new Staff();
            newStaff.FName = FName;
            newStaff.LName = LName;
            newStaff.DOB = DOB;
            newStaff.Contact = Contact;
            newStaff.DID = DID;

            StaffDataController controller = new StaffDataController();
            controller.AddStaff(newStaff);

            return RedirectToAction("ListStaff");
        }

        public ActionResult UpdateStaff(int Id)
        {
            StaffDataController controller = new StaffDataController();
            Staff selectedStaff = controller.FindStaff(Id);
            return View(selectedStaff);
        }

        [HttpPost]
        public ActionResult UpdateStaff(int Id, string FName, string LName, DateTime DOB, long Contact, string DID)
        {
            Staff staffInfo = new Staff();
            staffInfo.FName = FName;
            staffInfo.LName = LName;
            staffInfo.DOB = DOB;
            staffInfo.Contact = Contact;
            staffInfo.DID = DID;

            StaffDataController controller = new StaffDataController();
            controller.UpdateStaff(Id, staffInfo);

            return RedirectToAction("ShowStaff/" + Id);
        }

        // GET : /Staff/DeleteStaffConfirm/{SID}
        public ActionResult DeleteStaffConfirm(int Id)
        {
            StaffDataController controller = new StaffDataController();
            Staff newstaff = controller.FindStaff(Id);
            return View(newstaff);
        }

        // POST : /Staff/DeleteStaff/{SID}
        [HttpPost]
        public ActionResult DeleteStaff(int Id)
        {
            StaffDataController controller = new StaffDataController();
            controller.DeleteStaff(Id);
            return RedirectToAction("ListStaff");
        }

    }
}