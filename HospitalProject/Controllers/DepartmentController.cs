using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using HospitalProject.Models;
using System.Web.Script.Serialization;

namespace HospitalProject.Controllers
{
    public class DepartmentController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static DepartmentController()
    {
        client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44312/api/departmentdata/");
    }
 
        // GET: Department/List
        public ActionResult List()
        {
            //curl https://localhost:44312/api/departmentdata/listdepartments
            string url = "listdepartments";
            HttpResponseMessage response = client.GetAsync(url).Result;

           // Debug.WriteLine("the response code is >>" + response.StatusCode);

            IEnumerable<DepartmentDto> departments = response.Content.ReadAsAsync<IEnumerable<DepartmentDto>>().Result;
           // Debug.WriteLine("number of departments received >>");
           // Debug.WriteLine(departments.Count());

            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            //curl https://localhost:44312/api/departmentdata/findDepartment/{id}
            string url = "findDepartment/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

           // Debug.WriteLine("the response code is >>" + response.StatusCode);

            DepartmentDto selectedDepartment = response.Content.ReadAsAsync<DepartmentDto>().Result;
            //Debug.WriteLine("departments received >>");
            //Debug.WriteLine(selectedDepartment.DName);

            return View(selectedDepartment);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Department/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            Debug.WriteLine("the jsonpatlaod is: ");
            // add new department into system using the API
            //curl -H "Content-Type:application/json" -d @department.json https://localhost:44312/api/departmentdata/adddepartment
            string url = "adddepartment";

            string jsonpayload = jss.Serialize(department);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            } else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "findDepartment/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            DepartmentDto selectedDepartment = response.Content.ReadAsAsync<DepartmentDto>().Result;

            return View(selectedDepartment);
        }

        // POST: Department/Update/5
        [HttpPost]
        public ActionResult Update(int id, Department department)
        {
            string url = "updatedepartment/"+id;

            string jsonpayload = jss.Serialize(department);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Department/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "findDepartment/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            DepartmentDto selectedDepartment = response.Content.ReadAsAsync<DepartmentDto>().Result;

            return View(selectedDepartment);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "deletedepartment/" + id;

            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
