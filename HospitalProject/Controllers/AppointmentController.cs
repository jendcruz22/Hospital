using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HospitalProject.Models;

namespace HospitalProject.Controllers
{
    public class AppointmentController : Controller
    {
        /// <summary>
        /// Display list of all appointments
        /// </summary>
        /// <returns>List of all appointments</returns>
        // GET: Appointment/List
        public ActionResult List()
        {
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44312/api/AppointmentData/ListAppointments";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<AppointmentDto> appointmentDtos = response.Content.ReadAsAsync<IEnumerable<AppointmentDto>>().Result;
            return View(appointmentDtos);
        }

        /// <summary>
        /// Display Details of perticular appointment
        /// </summary>
        /// <param name="id">appointmnet id passing parameter</param>
        /// <returns>Details of selected appointment</returns>
        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44312/api/AppointmentData/FindAppointment/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            AppointmentDto selectedAppointmentDto = response.Content.ReadAsAsync<AppointmentDto>().Result;
            return View(selectedAppointmentDto);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
